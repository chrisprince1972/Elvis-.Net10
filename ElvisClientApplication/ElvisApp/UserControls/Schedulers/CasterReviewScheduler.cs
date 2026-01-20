using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.Configuration;
using ElvisDataModel.EDMX;
using MLJSystems.Calendars;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Unit = ElvisDataModel.EDMX.Unit;

namespace Elvis.UserControls
{
    public partial class CasterReviewScheduler : BaseScheduler
    {
        #region Variables + Properties
        private ProductionEvent currentPlanHighlight = null;
        private TibEvent currentTibHighlight = null;
        private Appointment lastAppClicked;
        private bool show7amHMStock;
        private bool isMiscastAdmin;
        private List<ProductionEvent> Planned7AMHeats = null;
        private List<ProductionEvent> Planned10AMHeats = null;
        private List<ProductionEvent> Planned7PMHeats = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Show7PMPlan { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Show10AMPlan { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Show7amHMStock
        {
            get { return this.show7amHMStock; }
            set
            {
                show7amHMStock = value;
                ConfigureChart();
                DrawChart();
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowChart
        {
            get { return chartHMBuffer.Visible; }
            set
            {
                chartHMBuffer.Visible = value;
                AutoSizeResourceHeights();
                this.Refresh();
            }
        }
        #endregion

        #region Delegates and Events
        /// <summary>
        /// Fires when an appointment is clicked on.
        /// </summary>
        /// <param name="sender">The CasterReviewScheduler</param>
        /// <param name="e">CasterReviewScheduler Event properties</param>
        public delegate void CasterSchedulerAppointmentClickEventHandler(object sender, SchedulerEventArgs e);

        /// <summary>
        /// Fires when an appointment is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CasterSchedulerAppointmentDoubleClickEventHandler(object sender, SchedulerEventArgs e);

        public event CasterSchedulerAppointmentClickEventHandler CasterSchedulerAppointmentClick;

        #endregion

        #region Constructor
        public CasterReviewScheduler(bool isMiscastAdmin)
        {
            InitializeComponent();
            this.isMiscastAdmin = isMiscastAdmin;
            SelectedDate = DateTime.Now.Hour < 7 ? DateTime.Now.AddDays(-1) : DateTime.Now;
            SetMinMaxDate(SelectedDate);
            CustomiseColours();
        }
        #endregion

        #region Methods

        #region Colours
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                        Settings.Default.ColourBackground;
            this.ForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].BorderColor =
                chartHMBuffer.Titles["Title1"].ForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisX.LineColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisX.TitleForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisX.MajorTickMark.LineColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY.LineColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY.TitleForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY.MajorTickMark.LineColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY2.LabelStyle.ForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY2.LineColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY2.TitleForeColor =
                chartHMBuffer.ChartAreas["ChartArea1"].AxisY2.MajorTickMark.LineColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Set the colour of all blocks.
        /// </summary>
        public void ColourHeats()
        {
            foreach (Appointment a in scheduler.Appointments)
            {
                if (a.Tag is ProductionEvent)
                {
                    ProductionEvent eventData = a.GetHeatData();
                    a.BackColor = Colours.GetColourByCaster(
                        eventData.CasterName, eventData.IsPlanningBlock, eventData.ProgramNumber);
                }
                else if (a.Tag is TibEvent)
                {
                    TibEvent tibData = a.GetTibData();
                    if (tibData.ProgramNumber.HasValue &&
                        tibData.TibStatus == 2)
                    {
                        a.BackColor = Colours.GetColourByCaster(
                            tibData.PlantArea, false, tibData.ProgramNumber.Value);
                    }
                    else if (tibData.TibStatus == 2)
                    {
                        a.BackColor = Colours.GetColourByCaster(
                            tibData.PlantArea, false);
                    }
                }

                if (a.Text == "SlowCast")
                    a.BackColor = Colours.GetSlowCastBackColour();
            }
        }

        /// <summary>
        /// Set the colour of all blocks that represent a certain program number.
        /// </summary>
        /// <param name="heat">The Program Number.</param>
        /// <param name="colour">The Colour you wish to set it to.</param>
        public void ColourHeats(int programNumber, Color colour)
        {
            foreach (Appointment a in this.scheduler.Appointments)
            {
                if (a.Tag is ProductionEvent)
                {
                    ProductionEvent eventData = a.GetHeatData();
                    if (eventData.ProgramNumber == programNumber)
                    {
                        a.BackColor = colour;
                    }
                }
                if (a.Tag is TibEvent)
                {
                    TibEvent tibData = a.GetTibData();
                    if (tibData.ProgramNumber == programNumber &&
                        tibData.TibStatus == 2)
                    {
                        a.BackColor = colour;
                    }
                }
            }
        }
        #endregion

        #region Date Methods
        /// <summary>
        /// Sets up the Min and Max dates for the scheduler using the given DateTime
        /// </summary>
        /// <param name="scheduleDate">The Date Time you wish to use.</param>
        public void SetMinMaxDate(DateTime scheduleDate)
        {
            var nextDayDate = scheduleDate.AddDays(2);
            scheduler.MinDate = new DateTime(scheduleDate.Year, scheduleDate.Month, scheduleDate.Day, 7, 7, 7);
            scheduler.MaxDate = new DateTime(nextDayDate.Year, nextDayDate.Month, nextDayDate.Day, 7, 7, 7);
        }

        /// <summary>
        /// Changes the cell width so that it is set to display only a 24 hour view.
        /// </summary>
        public void Fix24HourPeriod()
        {
            int cellWidth = ((this.scheduler.Width - this.scheduler.LeftResourceWidth) / 24);

            //Stops weird divide by zero error
            //Cell width cannot be 0
            if (cellWidth > 1)
                cellWidth--;
            else
                cellWidth = 1;

            this.scheduler.CellWidth = cellWidth;
            this.scheduler.Refresh();
        }
        #endregion

        #region Chart
        /// <summary>
        /// Sets up the chart ready for values.
        /// </summary>
        public void ConfigureChart()
        {
            // X-Axis
            chartHMBuffer.ChartAreas[0].AxisX.Interval = 30;
            chartHMBuffer.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chartHMBuffer.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            chartHMBuffer.ChartAreas[0].AxisX.LabelStyle.Interval = 60;
            chartHMBuffer.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            chartHMBuffer.ChartAreas[0].AxisX.Minimum = scheduler.MinDate.ToOADate();
            chartHMBuffer.ChartAreas[0].AxisX.Maximum = scheduler.MinDate.AddDays(1).ToOADate();

            // Secondary Y-Axis
            chartHMBuffer.Series.Clear();
            chartHMBuffer.Legends[0].Position.Width = 22;
            chartHMBuffer.Legends[0].Position.X = 2;

            // Setup chart series
            chartHMBuffer.Series.Add(new Series()
            {
                ChartType = SeriesChartType.StepLine,
                XValueType = ChartValueType.DateTime,
                Name = "HM Stock",
                Color = Color.Green,
                Legend = "hmLegend",
                ToolTip = "HM Stock: #VAL{F0} -- Time: #VALX{HH:mm}",
                LegendToolTip = "Iron stocks in tonnes.",
                BorderWidth = 2
            });

            chartHMBuffer.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Name = "BF Output",
                Legend = "hmLegend",
                LegendToolTip = "Total Blast Furnace output in tonnes.",
                Color = Color.Purple,
                BorderWidth = 2
            });

            chartHMBuffer.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Name = "Oxy Spill",
                LegendToolTip = "Oxy Spill output in tonnes.",
                Color = Color.Blue,
                BorderWidth = 2
            });

            if (show7amHMStock)
            {
                chartHMBuffer.Series.Add(new Series()
                {
                    ChartType = SeriesChartType.StepLine,
                    XValueType = ChartValueType.DateTime,
                    Name = "HM Stock 7am",
                    Legend = "hmLegend",
                    LegendToolTip = "HM Stock for 7am Plan.",
                    ToolTip = "HM Stock for 7am Plan: #VAL{F0} -- Time: #VALX{HH:mm}",
                    Color = Color.Blue,
                    BorderWidth = 2,
                });
                chartHMBuffer.Legends[0].Position.Width = 25;
            }

            chartHMBuffer.Series.Add(new Series()
            {
                ChartType = SeriesChartType.StepLine,
                XValueType = ChartValueType.DateTime,
                Legend = "castingRateLegend",
                LegendToolTip = "Predicted casting rate tonnes/minute",
                Name = "Predicted t/min",
                Color = Color.Orange,
                BorderWidth = 2,
                YAxisType = AxisType.Secondary
            });

            chartHMBuffer.Series.Add(new Series()
            {
                ChartType = SeriesChartType.StepLine,
                XValueType = ChartValueType.DateTime,
                Legend = "castingRateLegend",
                LegendToolTip = "Actual casting rate tonnes/minute",
                Name = "Actual t/min",
                Color = Color.Red,
                BorderWidth = 2,
                YAxisType = AxisType.Secondary
            });

            chartHMBuffer.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Legend = "castingRateLegend",
                LegendToolTip = "Target casting rate tonnes/minute",
                Name = "Target t/min",
                Color = Color.IndianRed,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Dash,
                YAxisType = AxisType.Secondary
            });
        }

        /// <summary>
        /// Draws and populates the chart control
        /// </summary>
        public void DrawChart()
        {
            ChartFunctions.ClearChartData(chartHMBuffer);
            DateTime dateFrom = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 7, 0, 0);
            DateTime dateTo = dateFrom.AddDays(1);

            // Get Data
            List<CoordLink> plannedHeats = GetCoordLink();//Planned Heat Data.
            List<HM_Stocks> hmStocks = GetHMStocks(dateFrom, dateTo);//Actual Stocks Data.
            int hoursToPredict = ChartFunctions.GetHoursToPredict(plannedHeats);//Hours to Predict.

            if (hmStocks.Count == 0)
            {//Get most recent stocks data for calcs if no data present
                hmStocks = GetHMStocks(DateTime.Now.AddHours(-1), DateTime.Now);
            }

            SystemConfiguration systemConfiguration = ConfigurationCoordinator.LoadConfiguration();
            double maxYValue = 4000;//Only Change max value if over 4000
            double currentBlastOutput = 0;
            double currentHMStock = 0;

            if (hmStocks != null && hmStocks.Count > 0)
            {
                if (hmStocks[hmStocks.Count - 1].BF_OUTPUT.HasValue)
                    currentBlastOutput = Convert.ToDouble(hmStocks[hmStocks.Count - 1].BF_OUTPUT.Value);
                if (hmStocks[hmStocks.Count - 1].HM_LEVEL.HasValue)
                    currentHMStock = Convert.ToDouble(hmStocks[hmStocks.Count - 1].HM_LEVEL.Value);
            }

            maxYValue = ChartFunctions.AddActualHMStockAndBlastOutputToChart(
                chartHMBuffer, hmStocks, maxYValue
                );//Actual HM Stocks

            ChartFunctions.AddTargetCastingRateToChart(
                chartHMBuffer, dateFrom, dateTo,
                systemConfiguration.TargetCastingRate
                );//Target Tonnes/Minute Casting Rate Line

            ChartFunctions.AddActualCastingRateToChart(
                chartHMBuffer, hmStocks
                );//Actual Casting Rate

            //Only add predicted data if the future is shown.
            if (dateTo >= DateTime.Now)
            {
                maxYValue = ChartFunctions.AddPredictedHMStockToChart(
                    chartHMBuffer, plannedHeats, hoursToPredict,
                    currentHMStock, currentBlastOutput, maxYValue
                    );//Predicted HM Stocks

                ChartFunctions.AddPredictedBlastOutputToChart(
                    chartHMBuffer, currentBlastOutput,
                    hoursToPredict
                    );//Predicted Blast Furnace Output

                ChartFunctions.AddPredictedCastingRateToChart(
                    chartHMBuffer, plannedHeats,
                    dateFrom, hoursToPredict
                    );//Predicted Casting Rate Line

                ChartFunctions.DrawVerticalAnnotation(chartHMBuffer, DateTime.Now);
            }

            if (show7amHMStock)
            {
                List<CastersScheduleItem> hmb7amDataList = GetHMStocks7AM();

                ChartFunctions.AddPredicted7AMHMStock(
                    chartHMBuffer, hmb7amDataList,
                    currentHMStock, currentBlastOutput,
                    dateFrom
                    );//Predicted HM Stocks for 7 AM Plan
            }

            //Set max value for Y Axis of chart.
            ChartFunctions.ScaleSeriesYValuesToRatio(chartHMBuffer.Series["BF Output"], 0, 700, 0, 4000);
            ChartFunctions.ScaleSeriesYValuesToRatio(chartHMBuffer.Series["Oxy Spill"], 0, 40, 0, 4000);

            ChartFunctions.ScaleSeriesYValuesToRatio(chartHMBuffer.Series["Predicted t/min"], 0, 15, 0, 4000);
            ChartFunctions.ScaleSeriesYValuesToRatio(chartHMBuffer.Series["Actual t/min"], 0, 15, 0, 4000);
            ChartFunctions.ScaleSeriesYValuesToRatio(chartHMBuffer.Series["Target t/min"], 0, 15, 0, 4000);
            ConfigureChartLines();
        }

        /// <summary>
        /// Shows or hides the Target tonnes/minute line on the graph based on user settings,
        /// and changes the context menu text accordingly.
        /// </summary>

        private void ConfigureChartLines()
        {
            // 1. Show the HM Buffer Lines?
            bool showHMBufferLines = Settings.Default.ShowHMBufferLines;
            chartHMBuffer.Series["HM Stock"].Enabled = showHMBufferLines;
            chartHMBuffer.Series["BF Output"].Enabled = showHMBufferLines;

            // HM Stock 10am Series won't exist unless "show10amHMStock" variable is true;
            if (show7amHMStock && showHMBufferLines)
            {
                chartHMBuffer.Series["HM Stock 7am"].Enabled = show7amHMStock;
            }
            else if (show7amHMStock)
            {
                chartHMBuffer.Series["HM Stock 7am"].Enabled = false;
            }

            // 2. Show the Casting Rate Lines?
            bool showCastingRateLines = Settings.Default.ShowCastingRateLines;
            chartHMBuffer.Series["Predicted t/min"].Enabled = showCastingRateLines;
            chartHMBuffer.Series["Actual t/min"].Enabled = showCastingRateLines;

            if (Settings.Default.ShowTargetCastingRateLine)
            {
                chartHMBuffer.Series["Target t/min"].Enabled = Settings.Default.ShowTargetCastingRateLine;
            }

            // 3. Configure the Target Casting Rate Line
            if (showCastingRateLines)
            {
                chartHMBuffer.Series["Target t/min"].Enabled = Settings.Default.ShowTargetCastingRateLine;
                showHideTargetMenuItem.Enabled = true;
            }
            else
            {
                chartHMBuffer.Series["Target t/min"].Enabled = false;
                showHideTargetMenuItem.Enabled = false;
            }
            showHideTargetMenuItem.Text = Settings.Default.ShowTargetCastingRateLine ?
                "Hide Target Line" : "Show Target line";

            // 4. Configure the checkboxes on the context menus
            if (showHMBufferLines && showCastingRateLines)
            {
                showAllTrendsToolStripMenuItem.Checked = true;
                showHMBufferLinesOnlyToolStripMenuItem.Checked = false;
                showCastingRateLinesOnlyToolStripMenuItem.Checked = false;
            }
            else if (showHMBufferLines)
            {
                showAllTrendsToolStripMenuItem.Checked = false;
                showHMBufferLinesOnlyToolStripMenuItem.Checked = true;
                showCastingRateLinesOnlyToolStripMenuItem.Checked = false;
            }
            else
            {
                showAllTrendsToolStripMenuItem.Checked = false;
                showHMBufferLinesOnlyToolStripMenuItem.Checked = false;
                showCastingRateLinesOnlyToolStripMenuItem.Checked = true;
            }

            // Configure Gridlines
            bool showTonnesPerHourGridLines = Settings.Default.ShowTonnesPerHourHMGridline;
            bool showTonnesPerMinuteGridLines = Settings.Default.ShowTonnesPerMinuteHMGridline;

            chartHMBuffer.ChartAreas[0].AxisY.MajorGrid.Enabled = showTonnesPerHourGridLines;
            chartHMBuffer.ChartAreas[0].AxisY2.MajorGrid.Enabled = showTonnesPerMinuteGridLines;
        }
        #endregion

        #region Load Data
        /// <summary>
        /// Loads only the specific Units for the Caster Review Scheduler
        /// into the resources area of the scheduler.
        /// </summary>
        /// <param name="units">The Caster Units</param>
        public void LoadCasterReviewUnits(List<Unit> units)
        {
            if (units == null || units.Count == 0)
            {
                return;
            }

            scheduler.LeftResourceColumns.Clear();
            scheduler.Resources.Clear();
            scheduler.Appointments.Clear();

            //Add a column to the resources (left)
            scheduler.LeftResourceWidth = 100;
            scheduler.LeftResourceColumns.Add(new ResourceColumn
            {
                Caption = "Casters",
                DataIndex = 0,
                Width = 75
            });

            AddBlankResource(null);

            // Setup the casters. We need a 7/10 AM plan row, possibly a 7 pm plan row,
            // and an actual row for each caster.
            foreach (Unit unit in units)
            {
                int unitNumber = unit.UnitNumber; // Tmp for colours etc.

                if (Show10AMPlan)
                {
                    // 10 AM planned heats row
                    scheduler.Resources.Add(new Resource
                    {
                        Text = String.Format("{0} 10 AM Plan", unit.UnitShort),
                        Tag = unitNumber,
                        BackColor = Settings.Default.ColourHeatScheduler1
                    });
                }
                else
                {
                    // 7 AM planned heats row
                    scheduler.Resources.Add(new Resource
                    {
                        Text = String.Format("{0} 7 AM Plan", unit.UnitShort),
                        Tag = unitNumber,
                        BackColor = Settings.Default.ColourHeatScheduler1
                    });
                }

                if (Show7PMPlan)
                {
                    // 7 PM planned heats row
                    scheduler.Resources.Add(new Resource
                    {
                        Text = String.Format("{0} 7 PM Plan", unit.UnitShort),
                        Tag = unitNumber + 500,
                        BackColor = Settings.Default.ColourHeatScheduler1
                    });
                }

                // Actual heats row
                scheduler.Resources.Add(new Resource
                {
                    Text = String.Format("{0} Actual", unit.UnitShort),
                    Tag = unitNumber + 1000,
                    BackColor = Settings.Default.ColourHeatScheduler1
                });

                if (unit != units.Last())
                {
                    AddBlankResource(unit);
                }
            }
            AutoSizeResourceHeights();
        }

        /// <summary>
        /// Loads the Scheduled Heats for 7/10am plan into the Scheduler
        /// depending on the hour passed in.
        /// </summary>
        /// <param name="scheduledHeats">List of Production Events representing the scheduled heats.</param>
        /// <param name="hour">The hour of the plan to load, 7 or 10.</param>
        public void LoadXamPlan(List<ProductionEvent> scheduledHeats, int hour)
        {
            if (scheduledHeats != null && scheduledHeats.Count > 0)
            {
                SetMinMaxDate(scheduledHeats.First().StartTime);
            }
            else
            {
                SetMinMaxDate(DateTime.Now);
            }

            scheduler.Appointments.Clear();

            if (scheduledHeats == null)
            {
                return;
            }
            else
            {
                if (Show10AMPlan)
                {
                    Planned10AMHeats = scheduledHeats;
                }
                else
                {
                    Planned7AMHeats = scheduledHeats;
                }
            }

            foreach (ProductionEvent heat in scheduledHeats)
            {
                if (heat != null)
                {
                    //Find the index of the unit in the left hand column
                    int index = FindResourceIndex((int)heat.UnitId);

                    Appointment appointment = new Appointment
                    {
                        Start = heat.StartTime,
                        End = heat.EndTime.Value,
                        Text = heat.HeatNumber.ToString(),
                        Tag = heat,
                        CustomHeight = Model.Tib.GetAppointmentHeight(2),
                        ResourceIndex = index,
                        LinkWithNext = false
                    };

                    //Adds the predicted slow casting planning blocks to the caster units
                    if (heat.CastDuration > 0 &&
                        heat.IdealCastingTime > 0 &&
                        (heat.CastDuration - heat.IdealCastingTime) > 0)
                    {
                        appointment.End = heat.EndTime.Value.AddMinutes(
                            -(heat.CastDuration - heat.IdealCastingTime));

                        Appointment slowCastEvent = new Appointment()
                        {
                            Start = heat.EndTime.Value.AddMinutes(
                                -(heat.CastDuration - heat.IdealCastingTime)),
                            End = heat.EndTime.Value,
                            Tag = heat,
                            Text = "SlowCast",
                            CustomHeight = Model.Tib.GetAppointmentHeight(2),
                            ResourceIndex = index,
                            LinkWithNext = false
                        };

                        slowCastEvent.ForeColor = Color.Black;
                        slowCastEvent.BackColor = Colours.GetSlowCastBackColour();
                        AddAppointment(slowCastEvent);
                    }

                    AddAppointment(appointment);

                }
            }
        }

        /// <summary>
        /// Loads the Scheduled Heats for the 7pm plan into the Scheduler
        /// </summary>
        /// <param name="scheduledHeats">List of Production Events representing the scheduled heats.</param>
        public void Load7PMPlan(List<ProductionEvent> scheduledHeats)
        {
            if (scheduledHeats == null)
            {
                return;
            }
            else
            {
                Planned7PMHeats = scheduledHeats;
            }

            foreach (ProductionEvent heat in scheduledHeats)
            {
                if (heat != null)
                {
                    //Find the index of the unit in the left hand column
                    int index = FindResourceIndex((int)heat.UnitId + 500);

                    Appointment appointment = new Appointment
                    {
                        Start = heat.StartTime,
                        End = heat.EndTime.Value,
                        Text = heat.HeatNumber.ToString(),
                        Tag = heat,
                        CustomHeight = Model.Tib.GetAppointmentHeight(2),
                        ResourceIndex = index,
                        LinkWithNext = false
                    };

                    //Adds the predicted slow casting planning blocks to the caster units
                    if (heat.CastDuration > 0 &&
                        heat.IdealCastingTime > 0 &&
                        (heat.CastDuration - heat.IdealCastingTime) > 0)
                    {
                        appointment.End = heat.EndTime.Value.AddMinutes(
                            -(heat.CastDuration - heat.IdealCastingTime));

                        Appointment slowCastEvent = new Appointment()
                        {
                            Start = heat.EndTime.Value.AddMinutes(
                                -(heat.CastDuration - heat.IdealCastingTime)),
                            End = heat.EndTime.Value,
                            Tag = heat,
                            Text = "SlowCast",
                            CustomHeight = Model.Tib.GetAppointmentHeight(2),
                            ResourceIndex = index,
                            LinkWithNext = false
                        };

                        slowCastEvent.ForeColor = Color.Black;
                        slowCastEvent.BackColor = Colours.GetSlowCastBackColour();
                        AddAppointment(slowCastEvent);
                    }

                    AddAppointment(appointment);
                }
            }
        }

        /// <summary>
        /// Loads the Actual Heats into the Scheduler
        /// </summary>
        /// <param name="productionHeats">List of Tib Events representing the Actual heats.</param>
        public void LoadActualHeats(List<TibEvent> tibEvents)
        {
            if (tibEvents != null && tibEvents.Count > 0)
            {
                // Group the Tib Events by UnitNumber
                var eventsToFix = from e in tibEvents
                                  group e by e.UnitNumber into g
                                  select new { Unit = g.Key, Events = g };

                // Get the last event for each unit, check if it's end time is null, and if so
                // set it to the current time so that the currently ongoing event will be displayed
                foreach (var evt in eventsToFix)
                {
                    var lastEvent = evt.Events.OrderBy(e => e.StartTime).LastOrDefault();
                    if (lastEvent != null && !lastEvent.EndTime.HasValue)
                    {
                        lastEvent.EndTime = DateTime.Now;
                        lastEvent.Ongoing = true;
                    }
                }

                foreach (TibEvent tibEvent in tibEvents)
                {
                    if (!tibEvent.EndTime.HasValue || !tibEvent.StartTime.HasValue ||
                        tibEvent.EndTime <= DateTime.MinValue)
                    {
                        continue;
                    }

                    //Find the index of the unit in the left hand column
                    int index = FindResourceIndex((int)(tibEvent.UnitNumber + 1000));

                    if (tibEvent.StartTime >= tibEvent.EndTime)
                    {//Stop the drawing of negative time boxes
                        continue;
                    }

                    if (tibEvent.TibStatus == 2 || tibEvent.Delays == null ||
                        tibEvent.Delays.Count == 0)
                    {//Just add the event as a delay event with no delay reasons
                        Appointment appointment = new Appointment()
                        {
                            Start = tibEvent.StartTime.Value,
                            End = tibEvent.EndTime.Value,
                            Tag = tibEvent,
                            Text = tibEvent.HeatNumber.ToString(),
                            ResourceIndex = index,
                            LinkWithNext = false,
                            CustomHeight = Model.Tib.GetAppointmentHeight(tibEvent.TibStatus),
                            BackColor = Colours.GetTibEventColour(
                                tibEvent.TibStatus,
                                tibEvent.UnitNumber,
                                tibEvent.ProgramNumber),
                            ForeColor = Color.Black,
                        };
                        AddAppointment(appointment);
                    }
                    else if (tibEvent.Delays.Count > 0)
                    {//If event has delays, add them
                        int delayOffset = 0;
                        //Standard Delays
                        foreach (TIBDelay delay in tibEvent.Delays)
                        {
                            DateTime start = tibEvent.StartTime.Value.AddMinutes(delayOffset);
                            DateTime end = start.AddMinutes(Convert.ToDouble(delay.DelayDuration));

                            Appointment appointment = new Appointment()
                            {
                                Start = start,
                                End = end,
                                Text = delay.DelayNumber.ToString(),
                                Tag = tibEvent,
                                ResourceIndex = index,
                                LinkWithNext = false,
                                CustomHeight = Model.Tib.GetAppointmentHeight(tibEvent.TibStatus),
                                BackColor = Colours.GetTibDelayColour(delay.PlantArea),
                                ForeColor = Colours.GetTibDelayForeColour(delay.PlantArea)
                            };
                            AddAppointment(appointment);
                            delayOffset += Convert.ToInt32(delay.DelayDuration.Value);
                        }
                        //Add remaining event block as gray appointment if delays do not reach 
                        //100 percent of event coverage
                        if (delayOffset < tibEvent.Duration.Value)
                        {
                            int remainingMins = tibEvent.Duration.Value - delayOffset;
                            DateTime start = tibEvent.StartTime.Value.AddMinutes(delayOffset);
                            DateTime end = start.AddMinutes(remainingMins);

                            Appointment appointment = new Appointment()
                            {
                                Start = start,
                                End = end,
                                Tag = tibEvent,
                                ResourceIndex = index,
                                LinkWithNext = false,
                                CustomHeight = Model.Tib.GetAppointmentHeight(tibEvent.TibStatus),
                                BackColor = Colours.GetTibDelayColour(""),
                                ForeColor = Colours.GetTibDelayForeColour(""),
                            };
                            AddAppointment(appointment);
                        }
                        //Add remaining block to ongoing event to reach DateTime.Now
                        else if (tibEvent.Ongoing)
                        {
                            int remainingMins = tibEvent.Duration.Value - delayOffset;
                            DateTime start = tibEvent.StartTime.Value.AddMinutes(delayOffset);
                            DateTime end = DateTime.Now;

                            Appointment appointment = new Appointment()
                            {
                                Start = start,
                                End = end,
                                Tag = tibEvent,
                                ResourceIndex = index,
                                LinkWithNext = false,
                                CustomHeight = Model.Tib.GetAppointmentHeight(tibEvent.TibStatus),
                                BackColor = Colours.GetTibDelayColour(""),
                                ForeColor = Colours.GetTibDelayForeColour(""),
                            };
                            AddAppointment(appointment);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads the Planned Heats into the Scheduler
        /// </summary>
        /// <param name="productionHeats">List of Production Events representing the planned heats.</param>
        public void LoadCurrentPlannedHeats(List<ProductionEvent> plannedHeats)
        {
            if (plannedHeats == null || plannedHeats.Count == 0)
            {
                return;
            }

            foreach (ProductionEvent heat in plannedHeats)
            {
                if (heat != null && heat.PlanStartTime >= DateTime.Now)
                {
                    //Find the index of the unit in the left hand column
                    int index = FindResourceIndex((int)(heat.UnitId + 1000));

                    Appointment appointment = new Appointment
                    {
                        Start = heat.StartTime,
                        End = heat.EndTime.HasValue ? heat.EndTime.Value : DateTime.Now,
                        Text = heat.HeatNumber.ToString(),
                        Tag = heat,
                        CustomHeight = Model.Tib.GetAppointmentHeight(2),
                        ResourceIndex = index,
                        LinkWithNext = false
                    };

                    //Adds the predicted slow casting planning blocks to the caster units
                    if (heat.CastDuration > 0 &&
                        heat.IdealCastingTime > 0 &&
                        (heat.CastDuration - heat.IdealCastingTime) > 0)
                    {
                        appointment.End = heat.EndTime.Value.AddMinutes(
                            -(heat.CastDuration - heat.IdealCastingTime));

                        Appointment slowCastEvent = new Appointment()
                        {
                            Start = heat.EndTime.Value.AddMinutes(
                                -(heat.CastDuration - heat.IdealCastingTime)),
                            End = heat.EndTime.Value,
                            Tag = heat,
                            Text = "SlowCast",
                            CustomHeight = Model.Tib.GetAppointmentHeight(2),
                            ResourceIndex = index,
                            LinkWithNext = false
                        };

                        slowCastEvent.ForeColor = Color.Black;
                        slowCastEvent.BackColor = Colours.GetSlowCastBackColour();
                        AddAppointment(slowCastEvent);
                    }

                    AddAppointment(appointment);
                }
            }
        }

        /// <summary>
        /// Gets the coord link data safely.
        /// </summary>
        /// <returns>Returns a List of Coord Link Data.</returns>
        private List<CoordLink> GetCoordLink()
        {
            try
            {
                return EntityHelper.CoordLink.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetCoordLink() -- ", ex);
            }
            return new List<CoordLink>();
        }

        /// <summary>
        /// Gets the 7 AM HM Stocks data
        /// </summary>
        /// <returns>Returns a List of CastersScheduleItem Data.</returns>
        private List<CastersScheduleItem> GetHMStocks7AM()
        {
            try
            {
                return EntityHelper.GetDailyPlannedCasterHeats
                    .GetByDate(SelectedDate, 7, 7
                    );
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetHMStocks7AM() -- ", ex);
            }
            return new List<CastersScheduleItem>();
        }

        /// <summary>
        /// Gets the HM Stocks data safely.
        /// </summary>
        /// <param name="from">The Date from.</param>
        /// <param name="to">The Date to.</param>
        /// <returns>Returns a List of HM Stocks Data.</returns>
        private List<HM_Stocks> GetHMStocks(DateTime from, DateTime to)
        {
            try
            {
                return EntityHelper.HMStocks.GetHMStocksForPeriod(from, to);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetHMStocks() -- ", ex);
            }
            return new List<HM_Stocks>();
        }

        /// <summary>
        /// Set the colour of all blocks
        /// </summary>
        /// <param name="programNo">The Program Number</param>
        public void ColourPlanEvents(int programNo)
        {
            foreach (Appointment a in this.scheduler.Appointments)
            {
                ProductionEvent eventData = a.GetHeatData();
                if (eventData.ProgramNumber == programNo)
                {
                    a.BackColor = Colours.GetColourByCaster(
                        eventData.CasterName,
                        eventData.IsPlanningBlock,
                        eventData.ProgramNumber);
                }
                if (a.Text == "SlowCast")
                    a.BackColor = Colours.GetSlowCastBackColour();
            }
        }

        /// <summary>
        /// Colour the tib events with the pre-set colours.
        /// </summary>
        /// <param name="programNo">The Program Number.</param>
        private void ColourTibEvents(int? programNo)
        {
            List<Appointment> appointments = scheduler.Appointments
                    .Where(a =>
                        a.GetTibData().ProgramNumber == programNo &&
                        a.GetTibData().TibStatus == 2)
                    .ToList();
            foreach (Appointment a in appointments)
            {
                TibEvent tibEvent = a.GetTibData();
                a.BackColor = Colours.GetTibEventColour(
                    tibEvent.TibStatus,
                    tibEvent.UnitNumber,
                    tibEvent.ProgramNumber);
            }
        }

        /// <summary>
        /// Shows the heat details for a clicked tib event.
        /// </summary>
        private void ShowHeatDetails(TibEvent tibData)
        {
            if (tibData.TibStatus == 2 &&
                tibData.HeatNumber.HasValue &&
                tibData.HeatNumberSet.HasValue)
            {
                Elvis.HeatDetails heatDetails = new Elvis.HeatDetails(
                    tibData.HeatNumber.Value,
                    CommonMethods.IsCasterUnit(tibData.UnitNumber),
                    false,
                    this.isMiscastAdmin,
                    tibData.HeatNumberSet.Value);
                heatDetails.Show();
            }
        }

        /// <summary>
        /// Shows the heat details for a clicked production event.
        /// </summary>
        private void ShowHeatDetails(ProductionEvent eventData)
        {
            if (eventData != null)
            {
                Elvis.HeatDetails heatDetails = new Elvis.HeatDetails(
                    eventData.HeatNumber,
                    CommonMethods.IsCasterUnit(eventData.UnitId),
                    true,
                    this.isMiscastAdmin,
                    eventData.HeatNumberSet);
                heatDetails.Show();
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Manual painting of the appointments
        /// </summary>
        private void scheduler_PaintAppointment(object sender, PaintAppointmentEventArgs e)
        {
            e.UserPaint = true;

            foreach (Rectangle rt in scheduler.GetAppointmentRectangles(e.Appointment, true))
            {
                if (e.Appointment.Tag is TibEvent)
                {
                    DrawTibEvent(e, rt);
                }
                else
                {
                    DrawPlanEvent(e, rt);
                }
            }
        }

        /// <summary>
        /// Seperate method dealing with the drawing of the production event
        /// </summary>
        private void DrawPlanEvent(PaintAppointmentEventArgs e, Rectangle rt)
        {
            ProductionEvent heatData = e.Appointment.GetHeatData();
            string extraData = "##";

            if (heatData.HeatNumber.ToString().Length > 2 &&
                heatData.HeatNumber.ToString().Length < 6)
            {
                extraData = heatData.HeatNumber.ToString().Substring(3);
            }
            if (CurrentDataSetting == ExtraData.ProgramNo &&
                heatData.ProgramNumber > 0)
            {
                extraData = heatData.ProgramNumber.ToString();
            }
            else if (CurrentDataSetting == ExtraData.Grade &&
                     heatData.Grade > 0)
            {
                extraData = heatData.Grade.ToString();
            }

            if (e.Appointment.Text != string.Empty)
            {
                scheduler.DrawAppointment(
                    e.Graphics,
                    e.Appointment);

                SizeF textSize = HelperFunctions.GetFontSizeInPixels(
                    extraData,
                    Settings.Default.FontTibHeatNo);

                //Draw heat number if Process Event and is wider than the text
                if (extraData != "##" &&
                    rt.Width >= textSize.Width - 5 &&
                    e.Appointment.Text != "SlowCast")
                {
                    int x = rt.Left + ((rt.Width - Convert.ToInt16(textSize.Width)) / 2);
                    int y = rt.Top + ((rt.Height - Convert.ToInt16(textSize.Height)) / 2);

                    e.Graphics.DrawString(extraData,
                        Settings.Default.FontTibHeatNo,
                        new SolidBrush(Color.Black),
                        x, y);
                }
            }
        }

        /// <summary>
        /// Seperate method dealing with the drawing of the tib event
        /// </summary>
        private void DrawTibEvent(PaintAppointmentEventArgs e, Rectangle rt)
        {
            string extraData = "##";
            TibEvent tibEventData = e.Appointment.GetTibData();

            using (SolidBrush heatNumberBrush = new SolidBrush(Color.Black))
            using(Pen appointmentBorderPen = new Pen(Color.Black, 1.6f))
            {


                // Compare the heat against the 7/10am plan (and 7pm plan if shown) for the actual and
                // currently planned heats only.
                if ((Show7PMPlan &&                         // 7pm plan visible
                    (e.Appointment.ResourceIndex == 3 ||     // CC1 Actual row
                     e.Appointment.ResourceIndex == 7 ||     // CC2 Actual row
                     e.Appointment.ResourceIndex == 11))     // CC3 Actual row
                    ||
                    (!Show7PMPlan &&                        // 7pm plan not shown
                    (e.Appointment.ResourceIndex == 2 ||     // CC1 Actual row
                     e.Appointment.ResourceIndex == 5 ||     // CC2 Actual row
                     e.Appointment.ResourceIndex == 8)))     // CC3 Actual row
                {
                    if (tibEventData.TibStatus == 2)//Production
                    {
                        if (Show10AMPlan)
                        {
                            HighlightUnplannedItems(tibEventData, Planned10AMHeats,
                                heatNumberBrush, appointmentBorderPen);
                        }
                        else
                        {
                            HighlightUnplannedItems(tibEventData, Planned7AMHeats,
                                heatNumberBrush, appointmentBorderPen);
                        }
                    }
                }

                if (tibEventData.HeatNumber.HasValue)
                {
                    if (tibEventData.HeatNumber.Value.ToString().Length > 2 &&
                        tibEventData.HeatNumber.Value.ToString().Length < 6)
                    {
                        extraData = tibEventData.HeatNumber.ToString().Substring(3);
                    }
                }
                if (CurrentDataSetting == ExtraData.ProgramNo &&
                    tibEventData.ProgramNumber.HasValue)
                {
                    extraData = tibEventData.ProgramNumber.Value.ToString();
                }
                else if (CurrentDataSetting == ExtraData.Grade &&
                         tibEventData.Grade.HasValue)
                {
                    extraData = tibEventData.Grade.Value.ToString();
                }

                if (extraData.Equals("0"))
                    extraData = "#";

                this.scheduler.DrawAppointment(
                    e.Graphics,
                    e.Appointment);

                if (heatNumberBrush.Color != Color.Black)
                {
                    // Draw another border around the appointment in the appropriate colour to signify deviations.
                    e.Graphics.DrawRectangle(appointmentBorderPen,
                        scheduler.GetAppointmentRectangle(e.Appointment));
                }

                SizeF textSize = HelperFunctions.GetFontSizeInPixels(
                                    extraData,
                                    Settings.Default.FontTibHeatNo);

                //Draw heat number if Process Event and is wider than the text
                if (tibEventData.TibStatus == 2 &&
                    rt.Width >= textSize.Width - 5)
                {
                    int x = rt.Left + ((rt.Width - Convert.ToInt16(textSize.Width)) / 2);
                    int y = rt.Top + ((rt.Height - Convert.ToInt16(textSize.Height)) / 2);

                    using (SolidBrush extraDataBrush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString(extraData,
                        Settings.Default.FontTibHeatNo,
                        extraDataBrush,
                        x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Highlights any Heats that are not in the plan based
        /// on Program Number.
        /// </summary>
        /// <param name="heatData">The Heat Data to Check.</param>
        /// <param name="plannedHeats">The list of planned heats to check.</param>
        /// <param name="heatNumberBrush">The SolidBrush object for the heat number.</param>
        /// <param name="appointmentBorderPen">The Pen object for the border colour.</param>
        private void HighlightUnplannedItems(TibEvent tibEvent, List<ProductionEvent> plannedHeats,
            SolidBrush heatNumberBrush, Pen appointmentBorderPen)
        {
            if (plannedHeats != null && plannedHeats.Count > 0 &&
                tibEvent != null)
            {
                ProductionEvent plannedHeat = plannedHeats
                    .FirstOrDefault(h =>
                        h.ProgramNumber == tibEvent.ProgramNumber);
                if (plannedHeat == null)
                {
                    heatNumberBrush.Color = Color.Red;
                    appointmentBorderPen.Color = Color.Red;
                }
            }
        }

        /// <summary>
        /// Detects any collisions with appointments
        /// </summary>
        private void scheduler_MouseMove(object sender, MouseEventArgs e)
        {
            //Try to find appointment
            Appointment appointment = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));

            //Restore original colour and reset currently highlighted tib event
            if (currentTibHighlight != null)
            {
                currentTibHighlight = null;
                ColourHeats();
            }
            //Restore original colour and reset currently highlighted planned event
            if (currentPlanHighlight != null)
            {
                currentPlanHighlight = null;
                ColourHeats();
            }

            //If it finds an appointment, then colour it
            if (appointment != null)
            {
                int? programNo = 0;
                if (appointment.Tag is TibEvent)
                {
                    TibEvent tibData = appointment.GetTibData();//Get the data
                    programNo = tibData.ProgramNumber;
                    currentTibHighlight = tibData;//Store for later
                }
                else //Planning Event
                {
                    ProductionEvent planData = appointment.GetHeatData();//Get the data
                    programNo = planData.ProgramNumber;
                    currentPlanHighlight = planData;//Store for later
                }

                if (programNo.HasValue)
                    ColourHeats(programNo.Value, Color.White);
            }
        }

        /// <summary>
        /// Event occurs on click of an appointment
        /// </summary>
        private void scheduler_AppointmentClick(object sender, AppointmentClickEventArgs e)
        {
            // Grab the appointment that was clicked.
            lastAppClicked = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));

            if (this.CasterSchedulerAppointmentClick != null)
            {
                SchedulerEventArgs myArgs = new SchedulerEventArgs();
                myArgs.Appointment = lastAppClicked;
                myArgs.AppointmentClickEventArgs = e;
                this.CasterSchedulerAppointmentClick(sender, myArgs);
            }
        }

        /// <summary>
        /// Event handler for mouse double click on the caster review scheduler.
        /// </summary>
        private void scheduler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lastAppClicked != null)
            {
                TibEvent tibData = lastAppClicked.GetTibData();
                if (tibData != null)
                {
                    if (tibData.TibStatus.HasValue &&
                        tibData.TibStatus.Value == 2 &&
                        tibData.HeatNumber.HasValue &&
                        tibData.HeatNumber.Value >= Settings.Default.MinHeatNumber &&
                        tibData.HeatNumber.Value <= Settings.Default.MaxHeatNumber)
                    {
                        ShowHeatDetails(tibData);
                    }
                    else if (tibData.TibStatus.HasValue && tibData.TibStatus.Value != 2)
                        return;
                    else
                    {
                        ProductionEvent prodEvent = lastAppClicked.GetHeatData();
                        ShowHeatDetails(prodEvent);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Resize the Scheduler when splitter moved.
        /// </summary>
        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AutoSizeResourceHeights();
        }

        /// <summary>
        /// Keeps the scheduler fixed to a 24 hour period
        /// </summary>
        private void scheduler_Resize(object sender, EventArgs e)
        {
            Fix24HourPeriod();
        }

        private void showHideTargetMenuItem_Click(object sender, EventArgs e)
        {
            bool enabled = chartHMBuffer.Series["Target t/min"].Enabled;

            try
            {
                Settings.Default.ShowTargetCastingRateLine = !enabled;
                DrawChart();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Configuration Error -- " +
                    "showHideTargetMenuItem_Click()", ex);
            }
        }

        private void showAllTrendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.ShowHMBufferLines = true;
                Settings.Default.ShowCastingRateLines = true;
                DrawChart();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Configuration Error -- " +
                    "showAllTrendsToolStripMenuItem_Click()", ex);
            }
        }

        private void showHMBufferLinesOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.ShowHMBufferLines = true;
                Settings.Default.ShowCastingRateLines = false;
                DrawChart();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Configuration Error -- " +
                    "showHMBufferLinesOnlyToolStripMenuItem_Click()", ex);
            }
        }

        private void showCastingRateLinesOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.ShowHMBufferLines = false;
                Settings.Default.ShowCastingRateLines = true;
                DrawChart();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Configuration Error -- " +
                    "showCastingRateLinesOnlyToolStripMenuItem_Click()", ex);
            }
        }

        #endregion

        #endregion
    }
}
