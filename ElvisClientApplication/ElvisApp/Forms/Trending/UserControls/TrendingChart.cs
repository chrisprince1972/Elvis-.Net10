using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System.Globalization;

namespace Elvis.Forms.Trending.UserControls
{
    public partial class TrendingChart : UserControl
    {
        #region Variables and Properties
        private int chartDP = 4;//Sets the Decimal Places for the chart data.
        private bool pageError = false;
        private bool isMiscastAdmin;
        private int parameterIndex;
        private GroupHighlight highlightBy;
        private Statistics stats;
        private ParConfig parConfig;
        private List<TrendData> trendDatas;
        private List<TrendDataIndex> trendDataIndices;
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Chart CurrentChart
        {
            get
            {
                if (chbDistribution.Checked)
                    return chartDist;
                return chartTrend;
            }
        }

        public Statistics ChartStats
        {
            get
            {
                return this.stats;
            }
        }

        public string Parameter
        {
            get
            {
                if (this.parConfig != null)
                {
                    return this.parConfig.Parameter;
                }
                return "";
            }
        }

        #endregion Variables and Properties

        #region Constructor and Page Setup

        /// <summary>
        /// Creates a new instance of the TrendingChart user control.
        /// </summary>
        public TrendingChart()
        {
            InitializeComponent();
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        public void SetupUserControl(int parameterIndex,
            List<TrendDataIndex> trendDataIndices, List<TrendData> trendDatas, 
            GroupHighlight highlightBy, bool isMiscastAdmin)
        {
            CommonMethods.LoadImageIntoChildPanel(Resources.loading, grpMain, pnlMain);
            this.parameterIndex = parameterIndex;
            this.trendDataIndices = trendDataIndices;
            this.trendDatas = trendDatas;
            this.highlightBy = highlightBy;
            this.stats = new Statistics();
            this.isMiscastAdmin = isMiscastAdmin;

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

        #endregion Constructor and Page Setup

        #region Methods

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlOptions.BackColor =
                pnlStats.BackColor =
                grpMain.BackColor =
                grpStats.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlOptions.ForeColor =
                pnlStats.ForeColor =
                grpMain.ForeColor =
                grpStats.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If all get datas fail then true, otherwise false.</returns>
        private bool GetData()
        {
            this.parConfig = new ParConfig();

            try
            {
                this.parConfig = EntityHelper.ParConfig.GetByID(this.parameterIndex);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Trending Chart Data -- GetData() -- ", ex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fills the form with trending data.
        /// </summary>
        private void PopulateForm()
        {
            grpMain.Controls.Clear();
            grpMain.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();

            FillFormData();
            ConfigureGraph();
            FillGraph();
            FillStats();
        }

        /// <summary>
        /// Fills the Statistics group box
        /// with the relevant data.
        /// </summary>
        private void FillStats()
        {
            if (this.stats != null && this.stats.ValueSet != null &&
                this.stats.ValueSet.Count > 0)
            {
                string numberFormat = "0.###";

                if (this.parConfig.CellWidth.HasValue)
                {
                    float cellWidth = this.parConfig.CellWidth.Value;
                    if (cellWidth > 0 && cellWidth < 0.001)
                    {
                        numberFormat = "0.####";
                    }
                }

                txtMin.Text = this.stats.Min.ToString(numberFormat);
                txtMax.Text = this.stats.Max.ToString(numberFormat);
                txtAVG.Text = this.stats.Average.ToString(numberFormat);
                txtStandardDev.Text = this.stats.StandardDeviation.ToString(numberFormat);
                txtCPK.Text = this.stats.CapabilityIndex.ToString(numberFormat);
            }
        }

        /// <summary>
        /// Fills the graph with the trend data and range data for the upper
        /// and lower limits.
        /// </summary>
        private void FillGraph()
        {
            ChartFunctions.ClearChartData(chartTrend);
            List<string> datas = new List<string>() { "Data1", "Data2", "Data3", "Data4" };

            if (this.parConfig != null &&
                chartTrend.ChartAreas.Count > 0 &&
                chartTrend.Series.Count > 0 &&
                this.trendDatas != null &&
                this.trendDatas.Count > 0)
            {
                RecordStats(parConfig.MaxLimit, parConfig.MinLimit);
                if (chbDistribution.Checked)
                {//Distribution Graph
                    chartDist.Series.Clear();
                    if (this.highlightBy.Description.Equals("None"))
                    {
                        chartDist.Series.Add(new Series()
                        {
                            ChartArea = "ChartArea1",
                            Name = "DataCore",
                            XValueMember = "XAxisGroup",
                            XValueType = ChartValueType.String,
                            YValueMembers = "YAxisCount",
                            YValueType = ChartValueType.Int64
                        });
                        chartDist.Series[0].ToolTip = "Group: #VALX -- Count: #VAL";
                        chartDist.DataSource = BuildDistrubutionData();
                    }
                    else
                    {
                        chartDist.DataBindCrossTable(
                            BuildHighlightedDistrubutionData(),
                            "Series", "XAxisGroup", "YAxisCount", ""
                            );

                        chartDist.Series[0].ChartType = SeriesChartType.StackedColumn;
                        chartDist.Series[1].ChartType = SeriesChartType.StackedColumn;

                        SetupChartDataColours(chartDist, chartDist.Series[0].Name);
                        SetupChartDataColours(chartDist, chartDist.Series[1].Name);

                        chartDist.Series[0].ToolTip = "Group: #VALX -- Count: #VAL -- " + chartDist.Series[0].Name;
                        chartDist.Series[1].ToolTip = "Group: #VALX -- Count: #VAL -- " + chartDist.Series[1].Name;

                        if (chartDist.Series.Count > 2)
                        {
                            chartDist.Series[2].ChartType = SeriesChartType.StackedColumn;
                            SetupChartDataColours(chartDist, chartDist.Series[2].Name);
                            chartDist.Series[2].ToolTip = "Group: #VALX -- Count: #VAL -- " + chartDist.Series[2].Name;
                        }

                        if (chartDist.Series.Count > 3)
                        {
                            chartDist.Series[3].ChartType = SeriesChartType.StackedColumn;
                            SetupChartDataColours(chartDist, chartDist.Series[3].Name);
                            chartDist.Series[3].ToolTip = "Group: #VALX -- Count: #VAL -- " + chartDist.Series[3].Name;
                        }
                    }
                }
                else
                {//Trending Graph
                    int pointCount = 0;
                    foreach (TrendData trend in this.trendDatas
                        .OrderBy(h => h.HeatNumber)
                        .OrderBy(h => h.HNS))
                    {//Loop each heat number to build the graph.
                        float? dataPoint = Model.Trending.GetValueForCorrectParameter(
                            trend, this.parConfig.ParFieldName);
                        if (trend.HeatNumber.HasValue)
                        {

                            //Data Limits (Range)
                            if (this.parConfig.MaxLimit.HasValue &&
                                this.parConfig.MinLimit.HasValue)
                            {
                                chartTrend.Series["Range"].Points.AddXY(
                                    trend.HeatNumber.Value.ToString(),
                                    Math.Round(this.parConfig.MaxLimit.Value, this.chartDP),
                                    Math.Round(this.parConfig.MinLimit.Value, this.chartDP));
                            }

                            //Aim Line
                            if (this.parConfig.AimTarget.HasValue)
                            {
                                chartTrend.Series["Aim"].Points.AddXY(
                                    trend.HeatNumber.Value.ToString(),
                                    Math.Round(this.parConfig.AimTarget.Value, this.chartDP));
                            }

                            if (dataPoint.HasValue)
                            {
                                RecordStats(dataPoint.Value);

                                //Keep data within in the confines of the graph limits.
                                if (dataPoint.Value > this.parConfig.DisplayMax.Value)
                                    dataPoint = this.parConfig.DisplayMax.Value;

                                if (dataPoint.Value < this.parConfig.DisplayMin.Value)
                                    dataPoint = this.parConfig.DisplayMin.Value;

                                //Data
                                chartTrend.Series["DataCore"].Points.AddXY(
                                    trend.HeatNumber.Value.ToString(),
                                    Math.Round(dataPoint.Value, this.chartDP));
                                chartTrend.Series["DataCore"].Points[pointCount].Tag = trend;


                            }
                            else
                            {
                                DataPoint dp = new DataPoint();
                                dp.IsEmpty = true;
                                chartTrend.Series["DataCore"].Points.AddXY(trend.HeatNumber.Value.ToString(), double.MinValue);
                                chartTrend.Series["DataCore"].Points[pointCount].IsEmpty = true;
                            }


                            if (!this.highlightBy.Description.Equals("None"))
                            {
                                string highlightSeries = GetSeriesToHighlightName(trend);
                                if (!string.IsNullOrEmpty(highlightSeries))
                                {
                                    if (dataPoint.HasValue)
                                    {

                                        chartTrend.Series[highlightSeries].Points.AddXY(
                                            trend.HeatNumber.Value.ToString(),
                                            Math.Round(dataPoint.Value, this.chartDP));
                                        chartTrend.Series[highlightSeries].Points[pointCount].Tag = trend;
                                    }
                                    else
                                    {
                                        DataPoint dp = new DataPoint();
                                        dp.IsEmpty = true;
                                        chartTrend.Series[highlightSeries].Points.AddXY(trend.HeatNumber.Value.ToString(), double.MinValue);
                                        chartTrend.Series[highlightSeries].Points[pointCount].IsEmpty = true;
                                    }

                                    //Add additional ToolTip info if required.
                                    if (!chartTrend.Series[highlightSeries].ToolTip.Contains(GetAdditionalToolTipInfo(trend)))
                                    {
                                        chartTrend.Series[highlightSeries].ToolTip += GetAdditionalToolTipInfo(trend);
                                    }
                                }

                                //Need to keep the points lined up so we add double.MinValue
                                //to each point that isn't in the current series
                                //for later reference (see SetEmptyPoints())
                                foreach (string series in datas.Where(d => !d.Equals(highlightSeries)))
                                {
                                    chartTrend.Series[series].Points.AddXY(
                                        trend.HeatNumber.Value.ToString(), double.MinValue);
                                }
                            }
                            pointCount++;
                        }
                    }
                    if (this.highlightBy.Description.Equals("None"))
                    {//Gets the DataCore series marker points back if no highlighting required.
                        chartTrend.Series["DataCore"].MarkerStyle = MarkerStyle.Circle;
                    }
                    SetEmptyPoints();
                }
            }
            else
            {
                CommonMethods.LoadImageIntoChildPanel(Resources.NoData, grpMain, pnlMain);
            }
        }

        /// <summary>
        /// Finds all of the points on the graph and checks for
        /// double.MinValue and sets it to an EmptyDataPoint.
        /// This technique keeps all the data points lined up.
        /// </summary>
        private void SetEmptyPoints()
        {
            foreach (Series series in chartTrend.Series)
            {
                foreach (DataPoint dataPoint in series.Points)
                {
                    if (dataPoint.YValues[0] == double.MinValue)
                    {
                        dataPoint.IsEmpty = true;
                    }
                }
            }
        }

        /// <summary>
        /// Find out which series needs to be populated
        /// </summary>
        /// <param name="trend">The Trend Data.</param>
        /// <returns>A string representing the series name.</returns>
        private string GetSeriesToHighlightName(TrendData trend)
        {
            TrendDataIndex trendDataIndex = this.trendDataIndices
                    .FirstOrDefault(t =>
                        t.TrendSampleIndex == trend.TrendSampleIndex);

            if (trendDataIndex != null)
            {
                if (this.highlightBy.Description.Equals("Rota") &&
                    trendDataIndex.Rota != null)
                {
                    switch (trendDataIndex.Rota.Trim().ToUpper())
                    {
                        case "A":
                            return "Data1";
                        case "B":
                            return "Data2";
                        case "C":
                            return "Data3";
                        case "D":
                            return "Data4";
                    }
                }
                else if (this.highlightBy.Description.Equals("Hot Metal"))
                {
                    if (trendDataIndex.HMPour.HasValue)
                    {
                        if (trendDataIndex.HMPour.Value == 1)//HM Pour North
                            return "Data1";
                        if (trendDataIndex.HMPour.Value == 2)//HM Pour South
                            return "Data2";
                    }
                }
                else if (this.highlightBy.Description.Equals("Desulph"))
                {
                    if (trendDataIndex.HMDesulph.HasValue)
                    {
                        if (trendDataIndex.HMDesulph.Value == 3)//HM Desulph North
                            return "Data1";
                        if (trendDataIndex.HMDesulph.Value == 4)//HM Desulph South
                            return "Data2";
                    }
                }
                else if (this.highlightBy.Description.Equals("Vessels"))
                {
                    if (trendDataIndex.Vessel.HasValue)
                    {
                        if (trendDataIndex.Vessel.Value == 5)//BOS Vessel 1
                            return "Data1";
                        if (trendDataIndex.Vessel.Value == 6)//BOS Vessel 2
                            return "Data2";
                    }
                }
                else if (this.highlightBy.Description.Equals("Sec Steel"))
                {
                    if (trendDataIndex.Cas1.HasValue)
                    {
                        if (trendDataIndex.Cas1.Value == 9)//CAS 1
                            return "Data1";
                    }
                    if (trendDataIndex.Cas2.HasValue)
                    {
                        if (trendDataIndex.Cas2.Value == 10)//CAS 2
                            return "Data2";
                    }
                    if (trendDataIndex.RH.HasValue)
                    {
                        if (trendDataIndex.RH.Value == 7)//RH Degasser
                            return "Data3";
                    }
                    if (trendDataIndex.RD.HasValue)
                    {
                        if (trendDataIndex.RD.Value == 8)//RD Degasser
                            return "Data4";
                    }
                }
                else if (this.highlightBy.Description.Equals("Casters"))
                {
                    if (trendDataIndex.Caster.HasValue)
                    {
                        if (trendDataIndex.Caster.Value == 11)//Caster 1
                            return "Data1";
                        if (trendDataIndex.Caster.Value == 12)//Caster 2
                            return "Data2";
                        if (trendDataIndex.Caster.Value == 13)//Caster 3
                            return "Data3";
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Find out which data needs to be returned
        /// </summary>
        /// <param name="trend">The Trend Data.</param>
        /// <returns>A string representing the extra tooltip info.</returns>
        private string GetAdditionalToolTipInfo(TrendData trend)
        {
            TrendDataIndex trendDataIndex = this.trendDataIndices
                    .FirstOrDefault(t =>
                        t.TrendSampleIndex == trend.TrendSampleIndex);

            if (trendDataIndex != null)
            {
                if (this.highlightBy.Description.Equals("Rota") &&
                    trendDataIndex.Rota != null)
                {
                    switch (trendDataIndex.Rota.Trim().ToUpper())
                    {
                        case "A":
                            return " -- A Rota";
                        case "B":
                            return " -- B Rota";
                        case "C":
                            return " -- C Rota";
                        case "D":
                            return " -- D Rota";
                    }
                }
                else if (this.highlightBy.Description.Equals("Hot Metal"))
                {
                    if (trendDataIndex.HMPour.HasValue)
                    {
                        if (trendDataIndex.HMPour.Value == 1)//HM Pour North
                            return " -- HM Pour North";
                        if (trendDataIndex.HMPour.Value == 2)//HM Pour South
                            return " -- HM Pour South";
                    }
                }
                else if (this.highlightBy.Description.Equals("Desulph"))
                {
                    if (trendDataIndex.HMDesulph.HasValue)
                    {
                        if (trendDataIndex.HMDesulph.Value == 3)//HM Desulph North
                            return " -- HM Desulph North";
                        if (trendDataIndex.HMDesulph.Value == 4)//HM Desulph South
                            return " -- HM Desulph South";
                    }
                }
                else if (this.highlightBy.Description.Equals("Vessels"))
                {
                    if (trendDataIndex.Vessel.HasValue)
                    {
                        if (trendDataIndex.Vessel.Value == 5)//BOS Vessel 1
                            return " -- BOS Vessel 1";
                        if (trendDataIndex.Vessel.Value == 6)//BOS Vessel 2
                            return " -- BOS Vessel 2";
                    }
                }
                else if (this.highlightBy.Description.Equals("Sec Steel"))
                {
                    if (trendDataIndex.Cas1.HasValue)
                    {
                        if (trendDataIndex.Cas1.Value == 9)//CAS 1
                            return " -- CAS 1";
                    }
                    if (trendDataIndex.Cas2.HasValue)
                    {
                        if (trendDataIndex.Cas2.Value == 10)//CAS 2
                            return " -- CAS 2";
                    }
                    if (trendDataIndex.RH.HasValue)
                    {
                        if (trendDataIndex.RH.Value == 7)//RH Degasser
                            return " -- RH Degasser";
                    }
                    if (trendDataIndex.RD.HasValue)
                    {
                        if (trendDataIndex.RD.Value == 8)//RD Degasser
                            return " -- RD Degasser";
                    }
                }
                else if (this.highlightBy.Description.Equals("Casters"))
                {
                    if (trendDataIndex.Caster.HasValue)
                    {
                        if (trendDataIndex.Caster.Value == 11)//Caster 1
                            return " -- Caster 1";
                        if (trendDataIndex.Caster.Value == 12)//Caster 2
                            return " -- Caster 2";
                        if (trendDataIndex.Caster.Value == 13)//Caster 3
                            return " -- Caster 3";
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Adds the value to the Statistics object
        /// for later calculations.
        /// </summary>
        /// <param name="value">The value to add.</param>
        private void RecordStats(float value)
        {
            double dblValue = 0;
            if (double.TryParse(value.ToString(), out dblValue))
            {
                this.stats.ValueSet.Add(dblValue);
            }
        }

        /// <summary>
        /// Adds the min/max values to the Statistics object
        /// for later calculations.
        /// </summary>
        /// <param name="maxLimit">The Max Limit for this Parameter.</param>
        /// <param name="minLimit">The Min Limit for this Parameter.</param>
        private void RecordStats(float? maxLimit, float? minLimit)
        {
            this.stats.MaxLimit = maxLimit;
            this.stats.MinLimit = minLimit;
        }

        /// <summary>
        /// Configures the graph ready for data binding.
        /// There are two states, Distribution or Line graph.
        /// Depends on user selection using the checkbox.
        /// </summary>
        private void ConfigureGraph()
        {
            chartDist.Visible = chbDistribution.Checked;
            chartTrend.Visible = !chartDist.Visible;

            if (this.parConfig != null)
            {
                if (chbDistribution.Checked)
                {
                    chartDist.Dock = DockStyle.Fill;
                }
                else
                {
                    chartTrend.Dock = DockStyle.Fill;

                    if (this.parConfig.DisplayMin.HasValue && this.parConfig.DisplayMax.HasValue)
                    {
                        chartTrend.ChartAreas[0].AxisY.Minimum = this.parConfig.DisplayMin.Value;

                        if (this.parConfig.DisplayMax.Value > this.parConfig.DisplayMin.Value)
                        {
                            chartTrend.ChartAreas[0].AxisY.Maximum = this.parConfig.DisplayMax.Value;
                        }
                    }

                    if (this.trendDatas.Count >= 800)
                    {
                        ChangeChartXAxisInterval(20, 40);
                    }
                    if (this.trendDatas.Count < 800)
                    {
                        ChangeChartXAxisInterval(10, 20);
                    }
                    if (this.trendDatas.Count < 600)
                    {
                        ChangeChartXAxisInterval(5, 10);
                    }
                    if (this.trendDatas.Count < 400)
                    {
                        ChangeChartXAxisInterval(4, 8);
                    }
                    if (this.trendDatas.Count < 200)
                    {
                        ChangeChartXAxisInterval(2, 4);
                    }
                    if (this.trendDatas.Count < 100)
                    {
                        ChangeChartXAxisInterval(1, 2);
                    }
                    if (this.trendDatas.Count < 75)
                    {
                        ChangeChartXAxisInterval(1, 1);
                    }

                    chartTrend.Series["DataCore"].ToolTip = "Heat: #VALX -- Value: #VAL";
                    chartTrend.Series["Range"].ToolTip = "Low: #VALY2 -- High: #VALY";
                    chartTrend.Series["Aim"].ToolTip = "Aim: #VAL";
                    chartTrend.Series["Data1"].ToolTip = "Heat: #VALX -- Value: #VAL";
                    chartTrend.Series["Data2"].ToolTip = "Heat: #VALX -- Value: #VAL";
                    chartTrend.Series["Data3"].ToolTip = "Heat: #VALX -- Value: #VAL";
                    chartTrend.Series["Data4"].ToolTip = "Heat: #VALX -- Value: #VAL";
                    SetupChartDataColours(chartTrend, "Data1");
                    SetupChartDataColours(chartTrend, "Data2");
                    SetupChartDataColours(chartTrend, "Data3");
                    SetupChartDataColours(chartTrend, "Data4");
                }
            }
        }

        /// <summary>
        /// Gets and Sets the Chart Data colour depending on
        /// highlight choice and series.
        /// </summary>
        private void SetupChartDataColours(Chart chart, string seriesName)
        {
            chart.Series[seriesName].Color =
                Colours.GetTrendHighlightColour(seriesName);
        }

        /// <summary>
        /// Changes the charts intervals and label intervals
        /// </summary>
        /// <param name="tickMarkInterval">The major tick mark interval (small line on graph).</param>
        /// <param name="labelInterval">The label interval (actual value displayed).</param>
        private void ChangeChartXAxisInterval(int tickMarkInterval, int labelInterval)
        {
            chartTrend.ChartAreas[0].AxisX.MajorTickMark.Interval = tickMarkInterval;
            chartTrend.ChartAreas[0].AxisX.LabelStyle.Interval = labelInterval;
        }

        /// <summary>
        /// Method that builds a DistributionDataPoint list
        /// to populate the chart with.
        /// </summary>
        /// <returns>A list of DistributionDataPoint objects.</returns>
        private List<DistributionDataPoint> BuildDistrubutionData()
        {
            List<DistributionDataPoint> dataPoints = new List<DistributionDataPoint>();
            float groupSpan = 0;//Used to determine the size of each x axis grouping.

            if (this.parConfig.DisplayMax.HasValue &&
                this.parConfig.DisplayMin.HasValue)
            {
                if (this.parConfig.CellWidth.HasValue &&
                    this.parConfig.CellWidth.Value > 0)
                    groupSpan = this.parConfig.CellWidth.Value;//Use database value if greater than 0.
                else
                    groupSpan = (this.parConfig.DisplayMax.Value - this.parConfig.DisplayMin.Value) / 10;//Use default if no value exists.

                //Add Lower Bucket Group to catch all points outside the range
                DistributionDataPoint lowerGroup = new DistributionDataPoint()
                {
                    XAxisGroup = string.Format(
                        "< {0}", this.parConfig.DisplayMin.Value.ToString("0.####")),
                    YAxisCount = GetDistributionCount(float.MinValue, this.parConfig.DisplayMin.Value, ""),
                    LowRange = float.MinValue,
                    HiRange = this.parConfig.DisplayMin.Value
                };
                dataPoints.Add(lowerGroup);

                for (float lowRange = this.parConfig.DisplayMin.Value;
                     lowRange < this.parConfig.DisplayMax.Value;
                     lowRange += groupSpan)
                {
                    float hiRange = lowRange + groupSpan;//Calculate High Range

                    DistributionDataPoint data = new DistributionDataPoint()
                    {
                        XAxisGroup = string.Format(
                            "{0} to {1}",
                            lowRange.ToString("0.####"),
                            hiRange.ToString("0.####")),
                        YAxisCount = GetDistributionCount(lowRange, hiRange, ""),
                        LowRange = lowRange,
                        HiRange = hiRange
                    };

                    dataPoints.Add(data);
                }

                //Add Upper Bucket Group to catch all points outside the range
                DistributionDataPoint upperGroup = new DistributionDataPoint()
                {
                    XAxisGroup = string.Format(
                        "> {0}", this.parConfig.DisplayMax.Value.ToString("0.####")),
                    YAxisCount = GetDistributionCount(this.parConfig.DisplayMax.Value, float.MaxValue, ""),
                    LowRange = this.parConfig.DisplayMax.Value,
                    HiRange = float.MaxValue
                };
                dataPoints.Add(upperGroup);
            }
            return dataPoints;
        }

        /// <summary>
        /// Method that builds a DistributionDataPoint list
        /// to populate the chart with.
        /// </summary>
        /// <returns>A list of DistributionDataPoint objects.</returns>
        private List<DistributionDataPoint> BuildHighlightedDistrubutionData()
        {
            List<DistributionDataPoint> dataPoints = new List<DistributionDataPoint>();
            List<string> serieses = Model.Trending.GetTrendHighlightList(this.highlightBy);
            float groupSpan = 0;//Used to determine the size of each x axis grouping.

            if (this.parConfig.DisplayMax.HasValue &&
                this.parConfig.DisplayMin.HasValue)
            {
                if (this.parConfig.CellWidth.HasValue &&
                    this.parConfig.CellWidth.Value > 0)
                    groupSpan = this.parConfig.CellWidth.Value;//Use database value if greater than 0.
                else
                    groupSpan = (this.parConfig.DisplayMax.Value - this.parConfig.DisplayMin.Value) / 10;//Use default if no value exists.

                foreach (string series in serieses)
                {
                    //Add Lower Bucket Group to catch all points outside the range
                    DistributionDataPoint lowerGroup = new DistributionDataPoint()
                    {
                        XAxisGroup = string.Format(
                            "< {0}", this.parConfig.DisplayMin.Value.ToString("0.###")),
                        YAxisCount = GetDistributionCount(float.MinValue, this.parConfig.DisplayMin.Value, series),
                        LowRange = float.MinValue,
                        HiRange = this.parConfig.DisplayMin.Value,
                        Series = series
                    };
                    dataPoints.Add(lowerGroup);

                    for (float lowRange = this.parConfig.DisplayMin.Value;
                         lowRange < this.parConfig.DisplayMax.Value;
                         lowRange += groupSpan)
                    {
                        float hiRange = lowRange + groupSpan;//Calculate High Range

                        DistributionDataPoint data = new DistributionDataPoint()
                        {
                            XAxisGroup = string.Format(
                                "{0} to {1}",
                                lowRange.ToString("0.###"),
                                hiRange.ToString("0.###")),
                            YAxisCount = GetDistributionCount(lowRange, hiRange, series),
                            LowRange = lowRange,
                            HiRange = hiRange,
                            Series = series
                        };

                        dataPoints.Add(data);
                    }

                    //Add Upper Bucket Group to catch all points outside the range
                    DistributionDataPoint upperGroup = new DistributionDataPoint()
                    {
                        XAxisGroup = string.Format(
                            "> {0}", this.parConfig.DisplayMax.Value.ToString("0.###")),
                        YAxisCount = GetDistributionCount(this.parConfig.DisplayMax.Value, float.MaxValue, series),
                        LowRange = this.parConfig.DisplayMax.Value,
                        HiRange = float.MaxValue,
                        Series = series
                    };
                    dataPoints.Add(upperGroup);
                }
            }
            return dataPoints;
        }

        /// <summary>
        /// Count how many values are in the data between
        /// given max and min values.
        /// </summary>
        /// <param name="lowRange">The Lowest Value.</param>
        /// <param name="hiRange">The Highest Value.</param>
        /// <returns>A count as an Int representing how many appeared in that range.</returns>
        private int GetDistributionCount(float lowRange, float hiRange, string series)
        {
            int count = 0;
            if (this.highlightBy.Description.Equals("None"))
            {
                count = TrendCount(this.trendDatas
                    .OrderBy(h => h.HeatNumber)
                    .ThenBy(h => h.HNS).ToList(),
                    lowRange,
                    hiRange);
            }
            else
            {
                List<TrendDataIndex> filteredTrendDataIndices = GetFilteredTrendDataIndices(series);

                count = TrendCount(this.trendDatas
                    .Where(trend => filteredTrendDataIndices
                        .Any(filtered => filtered.TrendSampleIndex.Equals(trend.TrendSampleIndex)))
                    .OrderBy(h => h.HeatNumber)
                    .ThenBy(h => h.HNS).ToList(),
                    lowRange,
                    hiRange);
            }
            return count;
        }

        /// <summary>
        /// Counts the amount of trend datas between two
        /// certain points in a given set of data.
        /// </summary>
        /// <param name="trendData">The Data to loop through.</param>
        /// <param name="lowRange">The Low range band.</param>
        /// <param name="hiRange">The High range band.</param>
        /// <returns>A count as an int.</returns>
        private int TrendCount(List<TrendData> trendData,
            float lowRange, float hiRange)
        {
            int count = 0;
            foreach (TrendData trend in trendData)
            {
                float? dataPoint = Model.Trending.GetValueForCorrectParameter(
                    trend, this.parConfig.ParFieldName);

                if (dataPoint.HasValue &&
                    dataPoint.Value >= lowRange &&
                    dataPoint.Value < hiRange)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns a list of TrendDataIndices after being
        /// filtered on series.
        /// </summary>
        /// <param name="series">The Series to filter the data on. e.g. "Caster 1"</param>
        /// <returns>A list of filtered data.</returns>
        private List<TrendDataIndex> GetFilteredTrendDataIndices(string series)
        {
            switch (series)
            {
                case "CAS 1":
                    return this.trendDataIndices.Where(t => t.Cas1 == 9).ToList();
                case "CAS 2":
                    return this.trendDataIndices.Where(t => t.Cas2 == 10).ToList();
                case "Caster 1":
                    return this.trendDataIndices.Where(t => t.Caster == 11).ToList();
                case "Caster 2":
                    return this.trendDataIndices.Where(t => t.Caster == 12).ToList();
                case "Caster 3":
                    return this.trendDataIndices.Where(t => t.Caster == 13).ToList();
                case "RH Degasser":
                    return this.trendDataIndices.Where(t => t.RH == 7).ToList();
                case "RD Degasser":
                    return this.trendDataIndices.Where(t => t.RD == 8).ToList();
                case "Desulph North":
                    return this.trendDataIndices.Where(t => t.HMDesulph == 3).ToList();
                case "Desulph South":
                    return this.trendDataIndices.Where(t => t.HMDesulph == 4).ToList();
                case "Hot Metal North":
                    return this.trendDataIndices.Where(t => t.HMPour == 1).ToList();
                case "Hot Metal South":
                    return this.trendDataIndices.Where(t => t.HMPour == 2).ToList();
                case "A Rota":
                    return this.trendDataIndices.Where(t =>
                            t.Rota != null &&
                            t.Rota.Contains("A"))
                        .ToList();
                case "B Rota":
                    return this.trendDataIndices.Where(t =>
                            t.Rota != null &&
                            t.Rota.Contains("B"))
                        .ToList();
                case "C Rota":
                    return this.trendDataIndices.Where(t =>
                            t.Rota != null &&
                            t.Rota.Contains("C"))
                        .ToList();
                case "D Rota":
                    return this.trendDataIndices.Where(t =>
                            t.Rota != null &&
                            t.Rota.Contains("D"))
                        .ToList();
                case "Vessel 1":
                    return this.trendDataIndices.Where(t => t.Vessel == 5).ToList();
                case "Vessel 2":
                    return this.trendDataIndices.Where(t => t.Vessel == 6).ToList();
                default:
                    return new List<TrendDataIndex>();
            }
        }

        /// <summary>
        /// Fills the Form Data with values
        /// if a ParConfig exists.
        /// </summary>
        private void FillFormData()
        {
            if (this.parConfig != null)
            {
                grpMain.Text = this.parConfig.Parameter;
                toolTip1.SetToolTip(grpMain, this.parConfig.ParDesc);
            }
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoChildPanel(Resources.error, grpMain, pnlMain);
        }

        /// <summary>
        /// Controls the forms Splitters positioning
        /// when the user Collapses or Shows the Stats Panel.
        /// </summary>
        /// <param name="state">True for Shown, false for hidden.</param>
        private void ShowStats(bool state)
        {
            if (state)//Show
            {
                btnShowHide.Image = Resources.HideButtonSmallVert;
                splitContainer1.Panel2MinSize = 106;
                splitContainer1.SplitterDistance =
                    splitContainer1.Width -
                    106;
                btnShowHide.Tag = "Hide";
            }
            else//Hide
            {
                btnShowHide.Image = Resources.ShowButtonSmallVert;
                splitContainer1.Panel2MinSize = 10;
                splitContainer1.SplitterDistance =
                    splitContainer1.Panel1.ClientSize.Width +
                    splitContainer1.Panel2.ClientSize.Width;
                btnShowHide.Tag = "Show";
            }
        }

        /// <summary>
        /// Opens the Heat Details form.
        /// </summary>
        /// <param name="heatNoString">The heat number as a string.</param>
        private void OpenHeatDetails(TrendData trendData)
        {
            this.Cursor = Cursors.WaitCursor;
            if (trendData != null)
            {
                if (trendData.HeatNumber.HasValue &&
                    trendData.HNS.HasValue)
                {//Got both HNS and HeatNo
                    HeatDetails heatDetails = new HeatDetails(
                        trendData.HeatNumber.Value,
                        false, false,
                        this.isMiscastAdmin,
                        trendData.HNS.Value);
                    heatDetails.Show();
                }
                else if (trendData.HeatNumber.HasValue)
                {//Can't find HNS so open with just Heat No
                    HeatDetails heatDetails = new HeatDetails(
                        trendData.HeatNumber.Value,
                        false, false, this.isMiscastAdmin);
                    heatDetails.Show();
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Gets the colours for the Distribution Charts.
        /// #418CF0 - Blue - Default
        /// Orange - Out of Aim Range
        /// Red - Out of Chart Range
        /// </summary>
        /// <param name="xAxisLabel">The Text in the Label</param>
        /// <returns>The Colour for the Distribution Column</returns>
        private Color GetDistributionColumnColour(string xAxisLabel)
        {
            if (!string.IsNullOrWhiteSpace(xAxisLabel))
            {
                if (xAxisLabel.Contains("<") || xAxisLabel.Contains(">"))
                {//Bucket Bands so Colour Red instantly.
                    return Color.Red;
                }
                if (xAxisLabel.Contains(" to "))
                {
                    //Split the axis text to get the upper and lower band values.
                    string[] upperLowerLimits = xAxisLabel.Split(
                        new string[] { " to " },
                        StringSplitOptions.None
                        );

                    float upperBandLimit = 0;//Used to get the Upper band value
                    float lowerBandLimit = 0;//Used to get the Lower band value

                    //Second string should be the upper band value
                    if (upperLowerLimits.Count() > 1 &&
                        float.TryParse(upperLowerLimits[0], out lowerBandLimit) &&
                        float.TryParse(upperLowerLimits[1], out upperBandLimit))
                    {
                        if (this.parConfig.MaxLimit.HasValue &&
                            this.parConfig.MinLimit.HasValue)
                        {//Safety first
                            if ((lowerBandLimit < this.parConfig.MinLimit.Value &&
                                 upperBandLimit <= this.parConfig.MinLimit.Value) || 
                                (lowerBandLimit >= this.parConfig.MaxLimit.Value &&
                                 upperBandLimit > this.parConfig.MaxLimit.Value))
                            {//Definitely outside the Lower/Upper Limits so Colour Orange
                                return Color.Orange;
                            }
                            else if (lowerBandLimit < this.parConfig.MinLimit.Value &&
                                     upperBandLimit > this.parConfig.MinLimit.Value)
                            {//Lower overlapped group
                                return Color.Pink;
                            }
                            else if (lowerBandLimit < this.parConfig.MaxLimit.Value &&
                                     upperBandLimit > this.parConfig.MaxLimit.Value)
                            {//Upper overlapped group
                                return Color.LimeGreen;
                            }
                        }
                    }
                }
            }
            return ColorTranslator.FromHtml("#418CF0");//Default Blue
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.pageError = GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.pageError)
            {
                PopulateForm();
            }
            else
            {
                ShowErrorForm();
            }
        }

        /// <summary>
        /// Button click event for the Sub Splitter's
        /// Show/Hide Button.
        /// </summary>
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (btnShowHide.Tag.ToString() == "Hide")
            {
                ShowStats(false);
            }
            else
            {
                ShowStats(true);
            }
        }

        /// <summary>
        /// Mouse Move event handler for the chart, controls the
        /// mouse display when a data point has the mouse on it.
        /// </summary>
        private void chartTrend_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;

            HitTestResult seriesHit = chartTrend.HitTest(e.X, e.Y);
            if (seriesHit.ChartElementType == ChartElementType.DataPoint &&
               (seriesHit.Series.Name.Equals("DataCore") ||
                seriesHit.Series.Name.Equals("Data1") ||
                seriesHit.Series.Name.Equals("Data2") ||
                seriesHit.Series.Name.Equals("Data3") ||
                seriesHit.Series.Name.Equals("Data4")))
            {
                this.Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// Mouse Click event handler for the chart, gets the heat number
        /// of the point clicked.
        /// </summary>
        private void chartTrend_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult pointHit = chartTrend.HitTest(e.X, e.Y);
            if (pointHit.ChartElementType == ChartElementType.DataPoint &&
               (pointHit.Series.Name.Equals("DataCore") ||
                pointHit.Series.Name.Equals("Data1") ||
                pointHit.Series.Name.Equals("Data2") ||
                pointHit.Series.Name.Equals("Data3") ||
                pointHit.Series.Name.Equals("Data4")))
            {
                try
                {
                    TrendData trendData = null;
                    //Search for the non null tag (TrendData).
                    if (chartTrend.Series[pointHit.Series.Name].Points[pointHit.PointIndex].Tag != null)
                    {
                        trendData = (TrendData)chartTrend.Series["DataCore"].Points[pointHit.PointIndex].Tag;
                    }
                    else if (chartTrend.Series["DataCore"].Points[pointHit.PointIndex].Tag != null)
                    {
                        trendData = (TrendData)chartTrend.Series["DataCore"].Points[pointHit.PointIndex].Tag;
                    }

                    //if (this.parConfig.ActionCode.Value == 0)//Starting point for the action codes.
                    //Currently every point will just open heat details, until further instruction is given.
                    OpenHeatDetails(trendData);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "ERROR -- Could not get Trend Data from Trend Chart Data Point -- chartTrend_MouseClick() -- ",
                        ex);
                }
            }
        }

        /// <summary>
        /// Checked Changed event handler for the distribution
        /// check box.
        /// </summary>
        private void chbDistribution_CheckedChanged(object sender, EventArgs e)
        {
            ConfigureGraph();
            FillGraph();
        }

        /// <summary>
        /// Customises the chart before displaying it to the user.
        /// </summary>
        private void chartDist_Customize(object sender, EventArgs e)
        {
            if (this.highlightBy.Description.Equals("None") &&
                chartDist.Series[0].Points.Count > 0)
            {//Colour columns depending on values
                foreach (DataPoint dp in chartDist.Series[0].Points)
                {
                    dp.Color = GetDistributionColumnColour(dp.AxisLabel);
                    if (dp.Color == Color.Pink)
                    {//Pink indicates a Lower overlapping group
                        dp.BackGradientStyle = GradientStyle.LeftRight;
                        dp.Color = Color.Orange;
                        dp.BackSecondaryColor = ColorTranslator.FromHtml("#418CF0");
                    }
                    else if (dp.Color == Color.LimeGreen)
                    {//LimeGreen indicates an Upper overlapping group
                        dp.BackGradientStyle = GradientStyle.LeftRight;
                        dp.Color = ColorTranslator.FromHtml("#418CF0");
                        dp.BackSecondaryColor = Color.Orange;
                    }
                }
            }
        }

        #endregion Methods
    }

    #region Supporting Classes

    /// <summary>
    /// Used to simplify the population of the Distribution chart.
    /// </summary>
    public class DistributionDataPoint
    {
        public string Series { get; set; }

        public string XAxisGroup { get; set; }

        public int YAxisCount { get; set; }

        public float LowRange { get; set; }

        public float HiRange { get; set; }
    }

    /// <summary>
    /// Stores the values to show on the trend chart
    /// under the statistics section.
    /// </summary>
    public class Statistics
    {
        private List<double> valueSet;
        private float? maxLimit;
        private float? minLimit;

        public Statistics()
        {
            this.valueSet = new List<double>();
        }

        /// <summary>
        /// The minimum value from the ValueSet.
        /// </summary>
        public double Min
        {
            get
            {
                if (this.valueSet.Count > 0)
                {
                    return this.valueSet.Min();
                }
                return 0;
            }
        }

        /// <summary>
        /// The maximum value from the ValueSet.
        /// </summary>
        public double Max
        {
            get
            {
                if (this.valueSet.Count > 0)
                {
                    return this.valueSet.Max();
                }
                return 0;
            }
        }

        /// <summary>
        /// The maximum limit value for the ValueSet
        /// </summary>
        public float? MaxLimit
        {
            get
            {
                return this.maxLimit;
            }
            set
            {
                this.maxLimit = value;
            }
        }

        /// <summary>
        /// The minimum limit value for the ValueSet
        /// </summary>
        public float? MinLimit
        {
            get
            {
                return this.minLimit;
            }
            set
            {
                this.minLimit = value;
            }
        }

        /// <summary>
        /// The average value from the ValueSet.
        /// </summary>
        public double Average
        {
            get
            {
                if (this.valueSet.Count > 0)
                {
                    return this.valueSet.Average();
                }
                return 0;
            }
        }

        /// <summary>
        /// The standard deviation from the ValueSet.
        /// </summary>
        public double StandardDeviation
        {
            get
            {
                if (this.valueSet.Count > 0)
                {
                    return this.valueSet.StdDev();
                }
                return 0;
            }
        }

        /// <summary>
        /// The Capability Index of the ValueSet.
        /// </summary>
        public double CapabilityIndex
        {
            get
            {
                if (StandardDeviation > 0 && this.maxLimit.HasValue &&
                    this.minLimit.HasValue)
                {
                    double cpu = (this.maxLimit.Value - Average) / (3 * StandardDeviation);
                    double cpl = (Average - this.minLimit.Value) / (3 * StandardDeviation);
                    double rtnValue = Math.Min(cpu, cpl);

                    //Check to make sure value does not go below 0
                    if (rtnValue >= 0)
                        return rtnValue;
                }
                return 0;
            }
        }

        /// <summary>
        /// All values from the Data Set are stored here.
        /// </summary>
        public List<double> ValueSet
        {
            get { return this.valueSet; }
            set { this.valueSet = value; }
        }
    }
     
    #endregion Supporting Classes
}