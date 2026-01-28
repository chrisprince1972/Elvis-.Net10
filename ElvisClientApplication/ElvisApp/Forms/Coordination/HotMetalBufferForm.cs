using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.Configuration;
using ElvisDataModel.EDMX;
using NLog;
using System.ComponentModel;

namespace Elvis.Forms.Coordination
{
    public partial class HotMetalBufferForm : Form
    {
        #region Variables & Properties
        private int hoursToPredict = 12;
        private List<CoordLink> plannedHeats;
        private List<HM_Stocks> hmStocks;
        private bool isLoaded;

        /// <summary>
        /// Average Iron Consumption per Blow.
        /// Possibly needs to be changed in future or added to the configurable parameters.
        /// </summary>
        private const double avgIronPerBlow = 300.0;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TimeSpan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EndDate { get; set; }
        #endregion

        /// <summary>
        /// Creates a new instance of the HotMetalBufferForm.
        /// </summary>
        public HotMetalBufferForm()
        {
            InitializeComponent();
            isLoaded = false;
            btn24Hour.PerformClick();//Default to 24 Hour Time Span
            GoToNow();
            CustomiseColours();
        }

        /// <summary>
        /// Changes the date ranges on the chart and refreshes the data.
        /// </summary>
        private void ChartDateChange()
        {
            if (EndDate >= MyDateTime.Now)
            {
                GetPlanningData();
                this.hoursToPredict = ChartFunctions.GetHoursToPredict(this.plannedHeats);
            }
            GetStockData();
            ConfigureChart();
            DrawChart();
            SetDateLabels();
        }

        /// <summary>
        /// Sets the toolstrip date labels for the form.
        /// </summary>
        private void SetDateLabels()
        {
            if (StartDate != null && EndDate != null)
            {
                stripDateFrom.Text = "From - " + StartDate.ToString("dd/MM/yy HH:mm");
                stripDateTo.Text = "To - " + EndDate.ToString("dd/MM/yy HH:mm");
            }
        }

        /// <summary>
        /// Gets the forms data.
        /// </summary>
        private void GetPlanningData()
        {
            try
            {
                this.plannedHeats = EntityHelper.CoordLink.GetAll();//Planned
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR COORD LINK -- GetPlanningData() -- ", ex);
            }
        }

        /// <summary>
        /// Gets HM Stock Data
        /// </summary>
        private void GetStockData()
        {
            try
            {
                this.hmStocks = EntityHelper.HMStocks.GetHMStocksForPeriod(StartDate, EndDate);
                if (this.hmStocks != null && this.hmStocks.Count == 0)
                {
                    hmStocks = EntityHelper.HMStocks.GetHMStocksForPeriod(MyDateTime.Now.AddHours(-1), MyDateTime.Now);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR HM STOCKS -- GetStockData() -- ", ex);
            }
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            panel1.BackColor = Settings.Default.ColourBackground;
            panel1.ForeColor = Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the default display of the chart, axis, titles etc.
        /// </summary>
        private void ConfigureChart()
        {
            // X-Axis
            chart1.ChartAreas[0].AxisX.Interval = 60;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 120;
            chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.Minimum = StartDate.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = EndDate.ToOADate();
            chart1.Series.Clear();

            // Setup chart series
            chart1.Series.Add(new Series()
            {
                ChartType = SeriesChartType.StepLine,
                XValueType = ChartValueType.DateTime,
                Name = "HM Stock",
                Color = Color.Green,
                LegendToolTip = "Iron stocks in tonnes.",
                ToolTip = "HM Stock: #VAL{F0} -- Time: #VALX{HH:mm}",
                BorderWidth = 2
            });

            chart1.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Name = "BF Output",
                LegendToolTip = "Total BF out in tonnes.",
                Color = Color.Purple,
                BorderWidth = 2
            });

            chart1.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Name = "Oxy Spill",
                LegendToolTip = "Oxy Spill output in tonnes.",
                Color = Color.Blue,
                BorderWidth = 2
            });

            chart1.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Legend = "castingRateLegend",
                LegendToolTip = "Predicted casting rate tonnes/minute",
                Name = "Predicted t/min",
                Color = Color.Orange,
                BorderWidth = 2
            });

            chart1.Series.Add(new Series()
            {
                ChartType = SeriesChartType.StepLine,
                XValueType = ChartValueType.DateTime,
                Legend = "castingRateLegend",
                LegendToolTip = "Actual casting rate tonnes/minute",
                Name = "Actual t/min",
                Color = Color.Red,
                BorderWidth = 2
            });

            chart1.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Legend = "castingRateLegend",
                LegendToolTip = "Target casting rate tonnes/minute",
                Name = "Target t/min",
                Color = Color.IndianRed,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Dash
            });
        }

        /// <summary>
        /// Grabs the data and draws the chart.
        /// </summary>
        private void DrawChart()
        {
            ChartFunctions.ClearChartData(chart1);

            if (this.hmStocks != null && this.hmStocks.Count > 0)
            {
                SystemConfiguration systemConfiguration = ConfigurationCoordinator.LoadConfiguration();
                double maxYValue = 4000;//Only Change max value if over 4000
                double currentBlastOutput = 0;
                double currentHMStock = 0;

                if (hmStocks[hmStocks.Count - 1].BF_OUTPUT.HasValue)
                    currentBlastOutput = Convert.ToDouble(hmStocks[hmStocks.Count - 1].BF_OUTPUT.Value);
                if (hmStocks[hmStocks.Count - 1].HM_LEVEL.HasValue)
                    currentHMStock = Convert.ToDouble(hmStocks[hmStocks.Count - 1].HM_LEVEL.Value);

                maxYValue = ChartFunctions.AddActualHMStockAndBlastOutputToChart(
                    chart1, this.hmStocks, maxYValue
                    );//Actual HM Stocks

                ChartFunctions.AddTargetCastingRateToChart(
                    chart1, StartDate, EndDate,
                    systemConfiguration.TargetCastingRate
                    );//Target Tonnes/Minute Casting Rate Line

                ChartFunctions.AddActualCastingRateToChart(
                    chart1, this.hmStocks
                    );//Actual Casting Rate

                //Only add predicted data if the future is shown.
                if (EndDate >= MyDateTime.Now)
                {
                    maxYValue = ChartFunctions.AddPredictedHMStockToChart(
                        chart1, this.plannedHeats, this.hoursToPredict,
                        currentHMStock, currentBlastOutput, maxYValue
                        );//Predicted HM Stocks

                    ChartFunctions.AddPredictedBlastOutputToChart(
                        chart1, currentBlastOutput, this.hoursToPredict
                        );//Predicted Blast Furnace Output

                    ChartFunctions.AddPredictedCastingRateToChart(
                        chart1, this.plannedHeats, StartDate, 
                        this.hoursToPredict
                        );//Predicted Casting Rate Line

                    ChartFunctions.DrawVerticalAnnotation(chart1, MyDateTime.Now);
                }

                //Set max value for Y Axis of chart.
                lblCurrentBlastOutput.Text = currentBlastOutput.ToString("#0");
                lblCurrentHMStock.Text = currentHMStock.ToString();

                ChartFunctions.ScaleSeriesYValuesToRatio(chart1.Series["BF Output"], 0, 700, 0, 4000);
                ChartFunctions.ScaleSeriesYValuesToRatio(chart1.Series["Oxy Spill"], 0, 40, 0, 4000);
                ChartFunctions.ScaleSeriesYValuesToRatio(chart1.Series["Predicted t/min"], 0, 15, 0, 4000);
                ChartFunctions.ScaleSeriesYValuesToRatio(chart1.Series["Actual t/min"], 0, 15, 0, 4000);
                ChartFunctions.ScaleSeriesYValuesToRatio(chart1.Series["Target t/min"], 0, 15, 0, 4000); 

                // Update labels for current values
                ConfigureTargetCastingRateLine();
                ConfigureCustomDateLabels();
            }
        }

        /// <summary>
        /// Adds in custom date labels to show when each day beginds and ends.
        /// </summary>
        private void ConfigureCustomDateLabels()
        {
            //Clear all labels to start fresh
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            int hourAddition = 24;
            if (TimeSpan == 12)
                hourAddition = 12;

            //Loops each day in the TimeSpan shown on the graph
            //adding in a label to show the current date.
            string lastDateAdded = "";//Used to stop duplicate labels being added.
            for (DateTime nextDay = StartDate; 
                nextDay <= EndDate;
                nextDay = nextDay.AddHours(hourAddition))
            {
                //Starts off at midnight on first day
                DateTime fromDate = new DateTime(
                    nextDay.Year, 
                    nextDay.Month, 
                    nextDay.Day, 
                    0, 0, 0);

                //Ends midnight of next day
                DateTime toDate = new DateTime(
                    nextDay.Year, 
                    nextDay.Month, 
                    nextDay.Day,
                    0, 0, 0).AddDays(1); //+1 Day

                //Checks to see if the label is going to start off the graph and corrects it.
                if (fromDate < StartDate)
                    fromDate = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, StartDate.Hour, 0, 0);

                //Checks to see if the label is going to end off the graph and corrects it.
                if (toDate > EndDate)
                    toDate = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, EndDate.Hour, 0, 0);

                if (!lastDateAdded.Equals(nextDay.Date.ToString("dd/MM/yy")))
                {
                    //Adds the label to the chart on a different row to the time (HH:mm) axis.
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(
                        fromDate.ToOADate(),
                        toDate.ToOADate(),
                        nextDay.Date.ToString("dd/MM/yy"),
                        1, LabelMarkStyle.LineSideMark);//Row 1 is important as row 0 is already taken by the time.
                    lastDateAdded = nextDay.Date.ToString("dd/MM/yy");
                }
            }
        }

        /// <summary>
        /// Checks values to see if larger than current max value for Y Axis
        /// </summary>
        /// <param name="maxYValue">The current max value to set</param>
        /// <param name="compareValue">The Value to compare</param>
        /// <returns>The new Max Value</returns>
        private double CheckYMaxValue(double maxYValue, double compareValue)
        {
            if (compareValue > maxYValue)
                return compareValue;
            return maxYValue;
        }

        #region Menu Items

        /// <summary>
        /// The menu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Print Event Handler
        /// </summary>
        /// <param name="sender">Print Menu Item</param>
        /// <param name="e">The menu event args</param>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = printDocument1;
            // Display the dialog. This returns true if the user presses the Print button.
            DialogResult print = pDialog.ShowDialog();
            if (print == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                printDocument1.Print();
            }
        }

        /// <summary>
        /// Print Preview Event Handler
        /// </summary>
        /// <param name="sender">Print Preview Menu Item</param>
        /// <param name="e">The menu event args</param>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Visible = false;
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        #endregion

        /// <summary>
        /// Handles the drawning aspect of the page which will be printed. 
        /// Adds a title and the chart to a page. It expects the page to be preconfigured in 
        /// landscape orientation.
        /// </summary>
        /// <param name="sender">Print Document</param>
        /// <param name="e">PrintPageEventArgs</param>
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Title
            e.Graphics.DrawString(
                "Hot Metal Stock Screenshot - " + MyDateTime.Now.ToString("dd MMM yyyy HH:mm"),
                new Font("Arial", 16),
                SystemBrushes.WindowText,
                e.PageBounds.X + 98, 60);

            // Chart
            Rectangle myRec = new Rectangle(e.PageBounds.X + 50, e.PageBounds.Top + 91,
                                            e.PageBounds.Width - 100, 670);

            chart1.Printing.PrintPaint(e.Graphics, myRec);
        }

        private void HotMetalBufferForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Shows or hides the Target tonnes/minute line on the graph based on user settings,
        /// and changes the context menu text accordingly.
        /// </summary>
        private void ConfigureTargetCastingRateLine()
        {
            bool showLine = Settings.Default.ShowTargetCastingRateLine;
            chart1.Series["Target t/min"].Enabled = showLine;
            showHideTargetMenuItem.Text = showLine ? "Hide Target Line" : "Show Target line";
        }


        private void showHideTargetMenuItem_Click(object sender, EventArgs e)
        {
            bool enabled = chart1.Series["Target t/min"].Enabled;

            try
            {
                Settings.Default.ShowTargetCastingRateLine = !enabled;
                ConfigureTargetCastingRateLine();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Configuration Error -- " +
                    "showHideTargetMenuItem_Click()", ex);
            }
        }

        /// <summary>
        /// Controls the Graph to display the latest data and predictions.
        /// </summary>
        private void GoToNow()
        {
            btnForward.Enabled = true;
            StartDate = new DateTime(MyDateTime.Now.Year, MyDateTime.Now.Month, MyDateTime.Now.Day, 7, 0, 0);
            if (StartDate > MyDateTime.Now)
            {
                StartDate = StartDate.AddHours(-12);
            }
            EndDate = StartDate.AddHours(TimeSpan);
            ChartDateChange();
        }

        /// <summary>
        /// Controls the graph to back in time 24 hours on each pass.
        /// </summary>
        private void GoBack1Day()
        {
            btnForward.Enabled = true;
            StartDate = StartDate.AddHours(-12);
            EndDate = StartDate.AddHours(TimeSpan);
            ChartDateChange();
        }

        /// <summary>
        /// Controls the graph to forward in time 12 hours on each pass.
        /// </summary>
        private void GoForward1Day()
        {
            StartDate = StartDate.AddHours(12);
            EndDate = StartDate.AddHours(TimeSpan);
            if (EndDate > MyDateTime.Now.AddDays(3))
                btnForward.Enabled = false;
            ChartDateChange();
        }

        /// <summary>
        /// Default the start and end dates.
        /// </summary>
        private void btnNow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GoToNow();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Event for handling the forward in time action.
        /// </summary>
        private void btnForward_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GoForward1Day();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Event for handling the back in time action.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GoBack1Day();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Menu item checked click handler.
        /// Keeps menu items from only having 1 clicked at a time.
        /// And sets the TimeSpan for the page.
        /// </summary>
        private void btnHour_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Finds the menu item
            foreach (ToolStripMenuItem item in ((ToolStripMenuItem)sender).GetCurrentParent().Items)
            {
                //Checks or unchecks it
                if (item == sender)
                {
                    item.Checked = true;
                    TimeSpan = int.Parse(item.Tag.ToString());
                }
                if (item != null && item != sender)
                    item.Checked = false;
            }

            if (this.isLoaded)
            {//Only gets the data after the page has loaded and the list is checked.
                EndDate = StartDate.AddHours(TimeSpan);
                ChartDateChange();
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Refresh event click handler.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ChartDateChange();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Keeps the buttons consistent in their enabled state.
        /// </summary>
        private void btnForward_EnabledChanged(object sender, EventArgs e)
        {
            btnMenuForward.Enabled = btnForward.Enabled;
        }

        /// <summary>
        /// Ensures the page is loaded and sets the variable.
        /// </summary>
        private void HotMetalBufferForm_Load(object sender, EventArgs e)
        {
            isLoaded = true;
        }

    }
}
