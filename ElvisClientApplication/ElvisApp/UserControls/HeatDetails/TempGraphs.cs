using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class TempGraphs : UserControl
    {
        #region Variables + Properties
        private int heatNumber;
        private int heatNumberSet;
        private bool showTempsBeforeVessel;
        private bool pageError = false;
        private List<TempDipData> tempData;
        private List<TempAimsData> tempAimDataRaw;
        private List<TempAimGraphPoint> tempAimDataPoints;
        private CoordLock coordLockData;
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool NoData 
        { 
            get 
            {
                if (this.tempData != null &&
                    this.tempData.Count > 0)
                    return false;
                return true;
            } 
        }
        #endregion

        #region Constructor + Setup
        /// <summary>
        /// Initializes a new instance of the TempDetails User Control class.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public TempGraphs()
        {
            InitializeComponent();
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        /// <param name="showTempsBeforeVessel">True to show temperatures before the vessel, false otherwise.</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet, bool showTempsBeforeVessel)
        {
            CommonMethods.LoadImageIntoPanel(Resources.loading, this, pnlMain);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;
            this.showTempsBeforeVessel = showTempsBeforeVessel;
            if (chartTemperature.Titles.Count > 0)
                chartTemperature.Titles[0].Text = "Temperature Graph for Heat - " + this.heatNumber;

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor = 
                pnlTempGraph.BackColor = 
                grpProcessDetails.BackColor =
                        Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlTempGraph.ForeColor =
                grpProcessDetails.ForeColor =
                chartTemperature.ChartAreas["ChartArea1"].BorderColor =
                chartTemperature.Titles["tempTitle"].ForeColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisX.LineColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisX.TitleForeColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisX.MajorTickMark.LineColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisY.LineColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisY.TitleForeColor =
                chartTemperature.ChartAreas["ChartArea1"].AxisY.MajorTickMark.LineColor =
                    Settings.Default.ColourText;
        }

        //Populate the Temperature Chart with data
        private void PopulateForm()
        {
            ChartFunctions.ClearChartData(chartTemperature);
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();

            try
            {
                int pointIndex = 0;
                double minValue = 100000;//large value to compare against (temp will never be > 100000)
                double casterMin = GetMaxMinValue(0);
                double casterMax = GetMaxMinValue(1);
                if (tempData != null && tempData.Count > 0)
                {
                    TempDipData lastValue = new TempDipData();
                    //Actual Graph Data
                    foreach (TempDipData tempValue in tempData)
                    {
                        double temperature = GetSafeTemp(tempValue.Temperature);
                        if (tempValue.UnitText.Contains("Caster"))
                        {//Minus two minutes to increase the span
                            chartTemperature.Series["MaxMin"].Points.AddXY(
                                tempValue.TimeStamp.AddMinutes(-2).ToOADate(),
                                casterMax,
                                casterMin);
                        }
                        if (tempValue.UnitNumber >= 5)
                        {//Show anything after the vessel
                            minValue = AddPointToChart("Actual",
                                tempValue.TimeStamp,
                                temperature, ref pointIndex,
                                tempValue.UnitText,
                                minValue);
                        }
                        else if (this.showTempsBeforeVessel)
                        {//Only show value before vessel if property set
                            minValue = AddPointToChart("Actual",
                                tempValue.TimeStamp,
                                temperature, ref pointIndex,
                                tempValue.UnitText,
                                minValue);
                        }
                        lastValue = tempValue;
                    }
                    if (lastValue != null &&
                        !string.IsNullOrEmpty(lastValue.UnitText) &&
                        lastValue.UnitText.Contains("Caster"))
                    {//Add on 2 mins to last point to increase the span
                        chartTemperature.Series["MaxMin"].Points.AddXY(
                            lastValue.TimeStamp.AddMinutes(2).ToOADate(),
                            casterMax,
                            casterMin);
                    }
                }
                //Planned Graph Data
                if (tempAimDataPoints != null && tempAimDataPoints.Count > 0)
                {
                    pointIndex = 0;
                    foreach (TempAimGraphPoint tempAimValue in tempAimDataPoints)
                    {
                        if (tempAimValue.TimeStamp.HasValue)
                        {
                            minValue = AddPointToChart("Planned",
                                tempAimValue.TimeStamp.Value,
                                tempAimValue.Temperature, ref pointIndex,
                                GetLocation(tempAimValue.Location),
                                minValue, casterMin);
                        }
                    }
                }
                //Check there has been points plottes on the graph
                if (chartTemperature.Series["Actual"].Points.Count > 1 ||
                    chartTemperature.Series["Planned"].Points.Count > 1)
                {
                    FormatTempChart(minValue);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "GRAPH DATA ERROR -- TempGraphs -- PopulateForm() -- ", ex);
            }
        }

        //Adds an Actual point value to the chart.
        private double AddPointToChart(string series, DateTime xTime, double yTemperature,
            ref int pointIndex, string unitText, double minValue, double casterMin = 0)
        {
            chartTemperature.Series[series].Points.AddXY(
                xTime.ToOADate(),
                yTemperature);
            chartTemperature.Series[series].Points[pointIndex].ToolTip =
                string.Format("{0} -- {1}°C -- {2}",
                    GetLocation(unitText),
                    yTemperature,
                    xTime.ToString("HH:mm"));

            if (series == "Actual")
            {
                //Only show every other label for casters
                if (pointIndex % 2 != 0 && //Is odd number
                    unitText.Contains("Caster"))//Is caster value
                {
                    chartTemperature.Series[series].Points[pointIndex].IsValueShownAsLabel = true;
                }
                else if (!unitText.Contains("Caster"))
                {//Add all labels that aren't casters
                    chartTemperature.Series[series].Points[pointIndex].IsValueShownAsLabel = true;
                }
            }
            pointIndex++;
            if (casterMin > 0)
                return GetMinGraphTempValue(casterMin, minValue);
            else
                return GetMinGraphTempValue(yTemperature, minValue);
        }

        //Generates a location depending on the string passed in
        private string GetLocation(string location)
        {
            switch (location)
            {
                case "Hot Metal DeSulph North":
                case "Hot Metal DeSulph South":
                case "Hot Metal Pour North":
                case "Hot Metal Pour South":
                    return "Hot Metal";
                case "End Blow":
                case "BOS Vessel 1":
                case "BOS Vessel 2":
                    return "Vessel";
                case "Ladle":
                    return "Tapped";
                case "Cas1":
                case "RH":
                case "RD":
                case "RH Degasser":
                case "RD Degasser":
                case "Cas2":
                case "CAS OB 1":
                case "CAS OB 2":
                    return "Sec Steel";
                case "Caster":
                case "Caster 1":
                case "Caster 2":
                case "Caster 3":
                    return "Caster";
                default:
                    return location;
            }
        }

        //Checks to see if new temp is lower than min value and return the lowest
        private double GetMinGraphTempValue(double temperature, double minValue)
        {
            if (temperature < minValue)//Find lowest value to scale graph
                return temperature;//New Min Value
            else
                return minValue;//No Change to Min value
        }

        //Gets a Rounded Temp Value Safely (Checks for null)
        private double GetSafeTemp(float? tempValue)
        {
            double value = 0;
            if (tempValue.HasValue)
            {
                value = double.Parse(tempValue.ToString());
                value = Math.Round(value, 0);//Round the Figure
            }
            return value;
        }

        //Formats the Temperature Chart 
        private void FormatTempChart(double minValue)
        {
            if (minValue < 100000 && minValue > 0)//Make sure we have a sensible min value
                chartTemperature.ChartAreas[0].AxisY.Minimum = minValue - 20;

            chartTemperature.ChartAreas[0].AxisX.Interval = 10;
            chartTemperature.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chartTemperature.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            chartTemperature.ChartAreas[0].AxisX.LabelStyle.Interval = 20;
            chartTemperature.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
        }

        //Get Charting data
        private bool GetData()
        {
            this.tempData = new List<TempDipData>();
            this.tempAimDataRaw = new List<TempAimsData>();
            this.coordLockData = new CoordLock();

            try
            {
                this.tempData =
                    EntityHelper.TempDipData.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR TEMP DIP DATA -- " +
                    "GetGraphData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
                return true;
            }

            try
            {
                this.tempAimDataRaw =
                    EntityHelper.TempAimsData.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR TEMP AIMS DATA -- " +
                    "GetGraphData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
                return true;
            }

            try
            {
                this.coordLockData =
                    EntityHelper.CoordLock.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR COORD LOCK -- " +
                    "GetGraphData(heatNumber = " + heatNumber +
                    ", heatNumberSet = " + heatNumberSet + ")", ex);
                return true;
            }
            return false;
        }

        //Processes the tempAimDataRaw List so that we create a list of TempAimGraphPoints
        //So that we can add the data to the graph
        private void ProcessRawAimData()
        {
            tempAimDataPoints = new List<TempAimGraphPoint>();
            if (coordLockData != null && tempAimDataRaw.Count > 0)
            {
                bool secSteelDone = false;
                foreach (TempAimsData aimData in tempAimDataRaw)
                {
                    if (aimData.TemperatureType == 2)
                    {
                        DateTime? timeStamp = new DateTime();
                        double temperature = GetSafeTemp(aimData.Temperature);
                        switch (aimData.UnitText)
                        {
                            case "End Blow":
                                timeStamp = coordLockData.PLANNED_CHARGE_TIME;
                                break;
                            case "Ladle":
                                timeStamp = coordLockData.PLANNED_TAP_TIME;
                                break;
                            case "Cas1":
                            case "RH":
                            case "RD":
                            case "Cas2":
                                if (!secSteelDone)//Only adds if SecSteel hasn't already been added
                                    timeStamp = coordLockData.PLANNED_END_SS_TIME;
                                secSteelDone = true;
                                break;
                            case "Caster":
                                timeStamp = coordLockData.PLANNED_START_CAST_TIME;
                                break;
                        }
                        if (temperature > 0 && timeStamp != null &&
                            timeStamp.Value > DateTime.MinValue)
                        {
                            TempAimGraphPoint point = new
                                TempAimGraphPoint(
                                    aimData.UnitText, timeStamp,
                                    temperature);
                            tempAimDataPoints.Add(point);
                        }
                    }
                }
            }
        }

        //Finds the Max Min for that Temperature Heat
        private double GetMaxMinValue(int type)
        {
            double value = 0;
            TempAimsData tempAimData = tempAimDataRaw.FirstOrDefault(t =>
                t.HeatNumber == this.heatNumber &&
                t.HNS == this.heatNumberSet &&
                t.TemperatureType == type);

            if (tempAimData != null &&
                tempAimData.Temperature.HasValue &&
                double.TryParse(tempAimData.Temperature.ToString(), out value))
            {
                return value;
            }
            return 0;
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
        }

        #region Events
        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.pageError = GetData();
            if (!this.pageError)//No Error
            {
                ProcessRawAimData();
            }
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.pageError)
            {//No Error
                PopulateForm();
            }
            else
            {
                ShowErrorForm();
            }
        }
        #endregion

        #endregion
    }

    #region Supporting Classes
    public class TempAimGraphPoint
    {
        #region Variables
        private string location;
        private DateTime? timeStamp;
        private double temperature;
        #endregion

        #region Constructor
        public TempAimGraphPoint(string location, DateTime? timeStamp,
            double temperature)
        {
            this.location = location;
            this.timeStamp = timeStamp;
            this.temperature = temperature;
        }
        #endregion

        #region Properties
        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }
        public DateTime? TimeStamp
        {
            get { return this.timeStamp; }
            set { this.timeStamp = value; }
        }
        public double Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; }
        }
        #endregion
    }
    #endregion
}
