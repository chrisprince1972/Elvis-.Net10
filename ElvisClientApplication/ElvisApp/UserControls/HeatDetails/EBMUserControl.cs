using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.UserControls.Generic;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Elvis.Common;

namespace Elvis.UserControls.HeatDetails
{
    public partial class EBMUserControl : Elvis.UserControls.Generic.ElvisUserControl
    {
        /// <summary>
        /// Holds the name of the chart to be shown on the chart grid's group box.
        /// </summary>
        private string ChartName { get; set; }

        ///Persist the legend status.
        private List<Tuple<int, bool>> CheckBoxesChecked { get; set; }

        /// <summary>
        /// Uniquely identify the heat.
        /// </summary>
        private int HeatNumber { get; set; }
        private int HeatNumberSet { get; set; }

        /// <summary>
        /// Date range for which the chart will visualise.
        /// </summary>
        private DateTime? StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private DateTime selectedDateTime;

        /// <summary>
        /// There will only be 2 vessels.
        /// </summary>
        private bool IsVessel1 { get; set; }

        /// <summary>
        /// If the chart is in high contrast mode.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HighContrast
        {
            get { return this.chart.IsHighContrast; }
            set 
            {
                this.chart.IsHighContrast = value;
                this.legendForChart.HighContrast = value;
                Draw();
            }
        }

        /// <summary>
        /// List of chart series to display.
        /// </summary>
        private List<ElvisDataModel.EDMX.ChartSery> ListChartSeries { get; set; }

        /// <summary>
        /// Constructor.  Setup the object with initialised variables.
        /// </summary>
        public EBMUserControl()
        {
            InitializeComponent();
            this.ChartName = String.Empty;
            this.chart.AddTramLines("Tram Lines", Color.DarkTurquoise, 7, 19, 35, 20);
            this.CheckBoxesChecked = new List<Tuple<int, bool>>();
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartMouseClick);
            this.EndTime = MyDateTime.Now;
            this.ListChartSeries = null;
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlChart.BackColor =
                pnlSelection.BackColor =
                grpChart.BackColor =
                grpValues.BackColor =
                pnlEBMOptions.BackColor =
                grpRefresh.BackColor =
                grpColourScheme.BackColor =
                grpLegend.BackColor = 
                grpValues.BackColor =
                splitContainer2.Panel1.BackColor =
                splitContainer2.Panel2.BackColor = 
                    Elvis.Properties.Settings.Default.ColourBackground;

            this.ForeColor =
                pnlChart.ForeColor =
                pnlSelection.ForeColor =
                grpChart.ForeColor =
                grpValues.ForeColor =
                pnlEBMOptions.ForeColor =
                grpRefresh.ForeColor =
                grpColourScheme.ForeColor =
                rbEBMDefaultColour.ForeColor =
                rbEBMHighContrastColour.ForeColor =
                grpLegend.ForeColor = 
                grpValues.ForeColor = 
                splitContainer2.Panel1.ForeColor =
                splitContainer2.Panel2.ForeColor = 
                    Elvis.Properties.Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            this.IsVessel1 = false;

            this.HeatNumber = heatNumber;
            this.HeatNumberSet = heatNumberSet;
            this.StartTime = null;

            try
            {
                GetStartEndDates();
            }
            catch (Exception ex)
            {
                error = String.Format(
                    "Error getting start and end dates for EBM graph. Error: {0}", ex.Message);
            }

            if (this.ucEBMData != null)
            {
                ucEBMData.SetupUserControl(this.HeatNumber, this.HeatNumberSet);
            }

            if (Elvis.Properties.Settings.Default.EBMColourScheme.Equals("High Contrast"))
            {
                rbEBMHighContrastColour.Checked = true;
            }

            base.SetupUserControl(Elvis.Properties.Resources.loadingBlack);
        }


        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        protected override string GetData()
        {
            string error = String.Empty;

            try
            {
                List<ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> chartSeriesToShow
                    = new List<ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes>();


                if (this.IsVessel1)
                {
                    chartSeriesToShow.Add(ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes.EBMDataVessel1);
                }
                else
                {
                    chartSeriesToShow.Add(ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes.EBMDataVessel2);
                }

                if (this.StartTime.HasValue)
                {
                    this.selectedDateTime = this.StartTime.Value;
                    this.ListChartSeries = LegendForChart.GetChartData(chartSeriesToShow);

                    this.chart.Loaded = false;
                    this.chart.SetupUserControlByDateRange(
                        ElvisDataModel.EntityHelper.ChartsConfiguration.ChartsType.EndBlowingModel,
                        this.ListChartSeries,
                        this.StartTime.Value,
                        this.EndTime);

                    this.ChartName = GetNameForChart(chartSeriesToShow);
                }
            }
            catch (Exception ex)
            {
                error = String.Format(
                    "Error getting data for EBM graph. Error: {0}", ex.Message);
            }

            return error;
        }



        /// <summary>
        /// Get date range for the chart using the heat log.  This function will be altered to the new way of getting this range.
        /// </summary>
        private void GetStartEndDates()
        {
            Vessel vessel = EntityHelper.Vessel.GetByHeat(this.HeatNumber, this.HeatNumberSet);

            if (vessel != null)
            {
                this.StartTime = vessel.TImeStampStart;
                this.EndTime = vessel.TimeStampEnd.HasValue ? vessel.TimeStampEnd.Value : MyDateTime.Now;
                // 5 = vessel 1
                this.IsVessel1 = vessel.UnitNumber == 5;
            }
        }

        /// <summary>
        /// When the thread has finished executing it will call this. So populate the data on the gridview.
        /// </summary>        
        protected override void PopulateForm()
        {
            if (this.ListChartSeries != null && this.StartTime.HasValue)
            {
                // Make the legend 5 columns wide.
                legendForChart.SetupUserControl(this.ListChartSeries, 6);
                legendForChart.OnChange += LegendChanged;

                // No point trying to populate if the chart has not loaded any data.
                if (this.chart.Loaded)
                {
                    foreach (Elvis.UserControls.Generic.ElvisChartUserControl.SeriesDataFromPI series in chart.ListSeriesDataFromPI)
                    {
                        //This is a special case - just for Lance Height.
                        if (series.SeriesName.Equals("Lance Height"))
                        {
                            foreach (Elvis.UserControls.Generic.ElvisChartUserControl.ChartValue piData in series.Data)
                            {
                                piData.ScaledValue = ConditionLanceHeight(piData.ScaledValue);
                            }
                        }
                    }

                    chart.WriteAllSeries();
                    Draw();
                    this.chart.AddVerticalLineAnnotation((this.selectedDateTime - this.StartTime.Value).TotalMinutes);

                }
            }
        }

        /// <summary>
        /// Condition lance height values.  
        /// </summary>
        /// <param name="value">The Value to condition.</param>
        /// <returns>A conditioned lance height value.</returns>
        private double ConditionLanceHeight(double value)
        {
            if (value < 1.5)
                value = 1.5;//Min of 1.5

            if (value > 3.5)
                value = 3.5;//Max of 3.5

            value -= 1.5;
            value = value * 50;

            if (value > 100)
                value = 100;//Max of 100;

            return Math.Round(value, 2);
        }

        /// <summary>
        /// Passes back the control's main panel so it can overwrite the loading image.
        /// </summary>
        protected override void ShowMainPanel()
        {
            if (this.chart.Loaded && this.StartTime.HasValue)
            {
                this.ShowMainPanel(pnlMain);
            }
            else
            {
                this.ShowImage(Elvis.Properties.Resources.error);
            }
        }

        /// <summary>
        /// Handles the mouse clicking events onthe chart.
        /// </summary>
        private void ChartMouseClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Gets the datetime of the point clicked
                List<System.Windows.Forms.DataVisualization.Charting.HitTestResult> results =
                    this
                    .chart
                    .HitTest
                        (
                            e.Location.X, 
                            e.Location.Y, 
                            false, 
                            System
                            .Windows
                            .Forms
                            .DataVisualization
                            .Charting
                            .ChartElementType
                            .PlottingArea
                        )
                    .ToList();

                foreach (var result in results)
                {
                    if (result.ChartElementType ==
                            System
                            .Windows
                            .Forms
                            .DataVisualization
                            .Charting
                            .ChartElementType
                            .PlottingArea
                        && StartTime.HasValue)
                    {
                        double xVal = result.ChartArea.AxisX.PixelPositionToValue(e.Location.X);
                        this.selectedDateTime = this.StartTime.Value.AddMinutes(xVal);
                        this.chart.AddVerticalLineAnnotation((this.selectedDateTime - StartTime.Value).TotalMinutes);
                        FillSelection(this.selectedDateTime);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Moves the annotated line on the graph by the amount of minutes 
        /// in the parameter.  Positive to increase, negative to decrease.
        /// </summary>
        /// <param name="mins">The amount of minutes to change the selection by.</param>
        public void MoveAnnotatedLine(int mins)
        {
            if (this.selectedDateTime != null && this.StartTime.HasValue &&
                this.selectedDateTime > DateTime.MinValue)
            {
                this.selectedDateTime = this.selectedDateTime.AddMinutes(mins);
                this.chart.AddVerticalLineAnnotation((this.selectedDateTime - StartTime.Value).TotalMinutes);
                this.FillSelection(this.selectedDateTime);
            }
        }

        /// <summary>
        /// Returns the name for the chart as a whole by getting each of the series sets requested.
        /// </summary>
        /// <param name="seriesSets">List of the sets of series to show on the chart.</param>
        /// <returns>The name of the chart to be put on chart's group control.</returns>
        private string GetNameForChart(List<ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> seriesSets)
        {
            string nameForChart = String.Empty;

            foreach (ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes chartSeriesSet in seriesSets)
            {
                if (nameForChart != String.Empty)
                {
                    nameForChart += ", ";
                }

                nameForChart +=
                    ElvisDataModel.EntityHelper
                    .ChartSeriesSet
                    .GetByChartID(chartSeriesSet);
            }

            return nameForChart;
        }

        /// <summary>
        /// This is to be called when all of the data is ready to
        /// be displayed and just calls the functions to render the chart.
        /// </summary>
        public void Draw()
        {
            if (StartTime.HasValue)
            {
                FillSelection(StartTime.Value);
                Redraw();
                grpChart.Text = ChartName;
                this.chart.AddVerticalLineAnnotation(0);
            }
        }


        /// <summary>
        /// Refresh the series that are being displayed if the check boxes change.
        /// </summary>
        public void Redraw()
        {
            chart.WriteAllSeries(GetSeriesToShow());
        }

        /// <summary>
        /// Finds which check boxes are checked and returns a list of their configurations.
        /// </summary>
        /// <returns>List of the configurations for each of the checked checkboxes.</returns>
        private List<ElvisDataModel.EDMX.ChartSery> GetSeriesToShow()
        {
            List<ElvisDataModel.EDMX.ChartSery> seriesToShow = new List<ElvisDataModel.EDMX.ChartSery>();

            foreach (object tag in this.legendForChart.GetCheckedTagValues())
            {
                seriesToShow.Add((ElvisDataModel.EDMX.ChartSery)tag);
            }

            return seriesToShow;
        }

        /// <summary>
        /// Check if InhibitCheckBoxLoading is false and if so reload all of the check boxes.
        /// </summary>
        private void LegendChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!this.legendForChart.InhibitCheckBoxLoading && this.StartTime.HasValue)
            {
                Redraw();
                this.chart.AddVerticalLineAnnotation(this.StartTime.Value.ToOADate());
                FillSelection(this.StartTime.Value);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Fills the selection box with data.
        /// </summary>
        public void FillSelection(DateTime selectedDT)
        {
            if (selectedDT != null && selectedDT > DateTime.MinValue)
            {
                this.grpValues.Text = "Time Selected - " + selectedDT.ToString("HH:mm:ss");
            }

            this.lstSelection.Items.Clear();//Clean up list box before adding more items.

            List<ElvisDataModel.EDMX.ChartSery> seriesToShow = GetSeriesToShow();

            if (seriesToShow != null && seriesToShow.Count > 0)
            {
                //Get the datetime at which to show data
                seriesToShow.Reverse();

                foreach (ElvisDataModel.EDMX.ChartSery series in seriesToShow)
                {
                    string tag
                        = ElvisDataModel.EntityHelper
                        .ChartDataLocations
                        .GetByChartDataLocationsID(series.ChartDataLocationsID)
                        .ReferenceId;

                    string val = this.chart.GetTagValue(selectedDT, tag);

                    this.lstSelection.Items.Add(new ListViewItem(new[] { series.Name, val }));
                }
            }
        }

        /// <summary>
        /// Handles the changing event for the Radio Buttons on the EBM Tab
        /// </summary>
        private void rbEBMColour_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chart != null && ucEBMData != null &&
                sender is RadioButton)
            {
                RadioButton rb = ((RadioButton)sender);

                bool highContrast = rb.Name == "rbEBMHighContrastColour" && rb.Checked;
                string scheme = this.rbEBMDefaultColour.Tag.ToString();

                if (highContrast)
                {
                    scheme = this.rbEBMHighContrastColour.Tag.ToString();
                }

                if (HighContrast != highContrast)
                {
                    Elvis.Properties.Settings.Default.EBMColourScheme = scheme;
                    CommonMethods.SaveElvisSettings();
                    HighContrast = highContrast;
                    this.ucEBMData.ColourScheme = scheme;

                }
            }
        }

        private void btnRefreshEBM_Click(object sender, EventArgs e)
        {
            SetupUserControl(this.HeatNumber, this.HeatNumberSet);
        }
    }
}
