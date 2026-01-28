using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Tib;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using MLJSystems.Calendars;
using NLog;
using System.ComponentModel;

namespace Elvis.UserControls
{
    public partial class TibScheduler : BaseScheduler
    {
        #region Variables + Properties
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private TibEvent currentTibHighlight = null;
        private ProductionEvent currentPlanHighlight = null;
        private Appointment lastAppClicked;
        private int tooltipYPos;
        private bool showLegend;
        private bool isMiscastAdmin;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowLegend
        {
            get { return this.showLegend; }
            set
            {
                this.showLegend = value;
                ShowHideLegend();
            }
        }
        #endregion

        #region Delegates and Events
        /// <summary>
        /// Fires when an appointment is clicked on.
        /// </summary>
        /// <param name="sender">The TibScheduler. </param>
        /// <param name="e">TibScheduler Event properties.</param>
        public delegate void TibSchedulerAppointmentClickEventHandler(object sender, SchedulerEventArgs e);
        public event TibSchedulerAppointmentClickEventHandler TibSchedulerAppointmentClick;

        /// <summary>
        /// Fires when the first date time property is changed.
        /// </summary>
        /// <param name="sender">The TibScheduler.</param>
        /// <param name="e">TibScheduler Event properties.</param>
        public delegate void TibSchedulerFirstDateTimeEventHandler(object sender, EventArgs e);
        public event TibSchedulerFirstDateTimeEventHandler TibSchedulerFirstDateTimeChanged;
        #endregion

        #region Constructor
        public TibScheduler(bool isMiscastAdmin)
        {
            InitializeComponent();
            this.isMiscastAdmin = isMiscastAdmin;
            this.scheduler.MinDate = MyDateTime.Now.AddDays(-Settings.Default.TibDaysToShow);
            this.scheduler.MaxDate = MyDateTime.Now.AddDays(2);
            ColourLegend();
        }
        #endregion

        #region Methods

        #region Load Data
        /// <summary>
        /// Load all Tib Events/Delays into Scheduler
        /// </summary>
        /// <param name="events">A list of events.</param>
        public void LoadTibEvents(List<TibEvent> events)
        {
            this.scheduler.Appointments.Clear();

            // Group the Tib Events by UnitNumber
            var eventsToFix = from e in events
                              group e by e.UnitNumber into g
                              select new { Unit = g.Key, Events = g };

            // Get the last event for each unit, check if it's end time is null, and if so
            // set it to the current time so that the currently ongoing event will be displayed
            foreach (var evt in eventsToFix)
            {
                var lastEvent = evt.Events.OrderBy(e => e.StartTime).LastOrDefault();
                if (lastEvent != null && !lastEvent.EndTime.HasValue)
                {
                    lastEvent.EndTime = MyDateTime.Now;
                    lastEvent.Ongoing = true;
                }
            }

            foreach (TibEvent tibEvent in events)
            {
                if (!tibEvent.EndTime.HasValue || !tibEvent.StartTime.HasValue ||
                    tibEvent.EndTime <= DateTime.MinValue)
                {
                    continue;
                }

                //Find the index of the unit in the left hand column
                int index = FindResourceIndex(tibEvent.UnitNumber);

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
                    //Add remaining block to ongoing event to reach MyDateTime.Now
                    else if (tibEvent.Ongoing)
                    {
                        int remainingMins = tibEvent.Duration.Value - delayOffset;
                        DateTime start = tibEvent.StartTime.Value.AddMinutes(delayOffset);
                        DateTime end = MyDateTime.Now;

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

        /// <summary>
        /// Loads all planning heat events into the scheduler
        /// </summary>
        /// <param name="events">A list of events.</param>
        public void LoadPlanningEvents(List<ProductionEvent> events)
        {
            if (events != null)
            {
                foreach (ProductionEvent unitEvent in events)
                {
                    if (unitEvent != null)
                    {
                        if (!unitEvent.EndTime.HasValue || unitEvent.EndTime <= DateTime.MinValue)
                        {
                            continue;
                        }
                        //Find the index of the unit in the left hand column
                        int index = FindResourceIndex(unitEvent.UnitId);

                        //Check if the event has started, if so set startime to now to cut the planning block
                        if (unitEvent.PlanStartTime < MyDateTime.Now)
                        {
                            unitEvent.StartTime = MyDateTime.Now;
                        }

                        if (unitEvent.StartTime >= unitEvent.EndTime)
                        {//Stop the drawing of negative time boxes
                            continue;
                        }

                        Appointment appointment = new Appointment()
                        {
                            Start = unitEvent.StartTime,
                            End = unitEvent.EndTime.Value,
                            Tag = unitEvent,
                            Text = unitEvent.HeatNumber.ToString(),
                            CustomHeight = Model.Tib.GetAppointmentHeight(2),//Producing
                            ResourceIndex = index,
                            LinkWithNext = false
                        };

                        //Adds the predicted slow casting planning blocks to the caster units
                        if (unitEvent.CastDuration > 0 &&
                            unitEvent.IdealCastingTime > 0 &&
                            (unitEvent.CastDuration - unitEvent.IdealCastingTime) > 0)
                        {
                            appointment.End = unitEvent.EndTime.Value.AddMinutes(
                                -(unitEvent.CastDuration - unitEvent.IdealCastingTime));

                            DateTime start = unitEvent.EndTime.Value.AddMinutes(
                                -(unitEvent.CastDuration - unitEvent.IdealCastingTime));
                            if (start < MyDateTime.Now)
                                start = MyDateTime.Now;//Stops overflow of blocks onto historical side of scheduler

                            Appointment slowCastEvent = new Appointment()
                            {
                                Start = start,
                                End = unitEvent.EndTime.Value,
                                Tag = unitEvent,
                                Text = "SlowCast",
                                CustomHeight = Model.Tib.GetAppointmentHeight(2),
                                ResourceIndex = index,
                                LinkWithNext = false
                            };

                            slowCastEvent.ForeColor = Color.Black;
                            slowCastEvent.BackColor = Colours.GetSlowCastBackColour();
                            AddAppointment(slowCastEvent);
                        }

                        appointment.BackColor = Colours.GetColourByCaster(
                            unitEvent.CasterName, unitEvent.IsPlanningBlock,
                            unitEvent.ProgramNumber);
                        appointment.ForeColor = Color.Black;

                        AddAppointment(appointment);
                    }
                }
            }
        }
        #endregion

        #region Colour Methods
        /// <summary>
        /// Colour the tib events with the pre-set colours.
        /// </summary>
        /// <param name="heatNo">The Heat Number.</param>
        private void ColourTibEvents(int? heatNo)
        {
            List<Appointment> appointments = scheduler.Appointments
                    .Where(a => a.GetTibData().HeatNumber == heatNo &&
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
        /// Colour the tib events with a certain colour.
        /// </summary>
        /// <param name="heatNo">The Heat Number.</param>
        /// <param name="colour">The colour to set it.</param>
        private void ColourTibEvents(int? heatNo, Color colour)
        {
            List<Appointment> appointments = scheduler.Appointments
                    .Where(a => a.GetTibData().HeatNumber == heatNo &&
                                a.GetTibData().TibStatus == 2)
                    .ToList();
            foreach (Appointment a in appointments)
            {
                a.BackColor = colour;
            }
        }

        /// <summary>
        /// Set the colour of all blocks that represent a certain heat number.
        /// </summary>
        /// <param name="heat"></param>
        public void ColourPlanEvents(int heat)
        {
            foreach (Appointment a in this.scheduler.Appointments)
            {
                ProductionEvent eventData = a.GetHeatData();
                if (eventData.HeatNumber == heat)
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
        /// Set the colour of all blocks that represent a certain heat number.
        /// </summary>
        /// <param name="heat"></param>
        public void ColourPlanEvents(int heat, Color colour)
        {
            foreach (Appointment a in this.scheduler.Appointments)
            {
                ProductionEvent eventData = a.GetHeatData();
                if (eventData.HeatNumber == heat)
                {
                    a.BackColor = colour;
                }
            }
        }

        /// <summary>
        /// Shows or Hides the Legend on Tib
        /// </summary>
        /// <param name="state"></param>
        public void ShowHideLegend()
        {
            this.tooltipYPos = 0;
            pnlLegend.Visible = this.showLegend;
            AutoSizeResourceHeights();
            if (this.showLegend)//show
            {
                int lblWidth = (pnlLegend.Width - 12) / 9;
                foreach (Label lbl in pnlLegend.Controls)
                {
                    lbl.Width = lblWidth;
                }
                ColourLegend();
            }
            else//hide
                tooltipYPos = pnlLegend.Height;
        }

        /// <summary>
        /// Colours the Legend to the Correct User Setting colours
        /// </summary>
        private void ColourLegend()
        {
            lblExternal.BackColor = Settings.Default.TibExternal;
            lblExternal.ForeColor = Settings.Default.TibExternalText;
            lblMultiServ.BackColor = Settings.Default.TibMultiServ;
            lblMultiServ.ForeColor = Settings.Default.TibMultiServText;
            lblHMScrap.BackColor = Settings.Default.TibHMScrap;
            lblHMScrap.ForeColor = Settings.Default.TibHMScrapText;
            lblVessels.BackColor = Settings.Default.TibVessels;
            lblVessels.ForeColor = Settings.Default.TibVesselsText;
            lblPlan.BackColor = Settings.Default.TibPlan;
            lblPlan.ForeColor = Settings.Default.TibPlanText;
            lblSecSteel.BackColor = Settings.Default.TibSecSteel;
            lblSecSteel.ForeColor = Settings.Default.TibSecSteelText;
            lblCasters.BackColor = Settings.Default.TibCasters;
            lblCasters.ForeColor = Settings.Default.TibCastersText;
            lblCranes.BackColor = Settings.Default.TibCranes;
            lblCranes.ForeColor = Settings.Default.TibCranesText;
            lblNoReason.BackColor = Settings.Default.TibNoReason;
            lblNoReason.ForeColor = Settings.Default.TibNoReasonText;
        }
        #endregion

        #region Appearance Configuration
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

        /// <summary>
        /// Shows the Tib Delay Entry Screen.
        /// This method has become overly complex due to the random
        /// errors/crashes we are getting in the log from certain users
        /// when using the DelayEntry form.
        /// Most of this is test code to see if we can rectify the problem and
        /// should be refactored if the problem is solved.
        /// </summary>
        private void ShowTibDelayEntry(TibEvent tibData)
        {
            using (DelayEntry delayEntryForm =
                new DelayEntry(tibData.TibIndex))
            {
                //Open the form
                if (delayEntryForm.InvokeRequired)
                {
                    logger.Info("ShowTibDelayEntry() -- DelayEntry form required invoke before opening dialog!");
                    delayEntryForm.BeginInvoke((MethodInvoker)delegate
                    {
                        delayEntryForm.ShowDialog();
                    });
                }
                else
                {
                    delayEntryForm.ShowDialog();
                }

                //Sets countdown to 0 to refresh scheduler if delays have been changed
                if (delayEntryForm.InvokeRequired)
                {
                    logger.Info("ShowTibDelayEntry() -- DelayEntry form required invoke before checking for Dirty Delays!");
                    delayEntryForm.BeginInvoke((MethodInvoker)delegate
                    {
                        if (delayEntryForm != null &&
                            !delayEntryForm.IsDisposed &&
                            delayEntryForm.DirtyDelays)
                        {
                            Forms.MainForm main = (Forms.MainForm)FormControl.FindParentForm(this);
                            if (main != null)
                            {
                                main.CountDown = TimeSpan.Zero;
                            }
                        }
                    });
                }
                else
                {
                    if (delayEntryForm != null &&
                        !delayEntryForm.IsDisposed &&
                        delayEntryForm.DirtyDelays)
                    {
                        Forms.MainForm main = (Forms.MainForm)FormControl.FindParentForm(this);
                        if (main != null)
                        {
                            main.CountDown = TimeSpan.Zero;
                        }
                    }
                }
            }
        }
        #endregion

        #region Events
        //Paints each appointment onto the scheduler
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
        /// Seperate method dealing with the drawing of the planned event
        /// </summary>
        private void DrawPlanEvent(PaintAppointmentEventArgs e, Rectangle rt)
        {
            string shortHeatNumber = "##";
            ProductionEvent eventData = e.Appointment.GetHeatData();

            if (eventData.HeatNumber.ToString().Length > 2 &&
                eventData.HeatNumber.ToString().Length < 6)
                shortHeatNumber = eventData.HeatNumber.ToString().Substring(3);

            this.scheduler.DrawAppointment(
                e.Graphics,
                e.Appointment);

            SizeF textSize = HelperFunctions.GetFontSizeInPixels(
                                shortHeatNumber,
                                Settings.Default.FontTibHeatNo);

            //Draw heat number if Process Event and is larger than 8 pixels wide
            if (rt.Width >= textSize.Width - 5 && e.Appointment.Text != "SlowCast")
            {
                int x = rt.Left + ((rt.Width - Convert.ToInt16(textSize.Width)) / 2);
                int y = rt.Top + ((rt.Height - Convert.ToInt16(textSize.Height)) / 2);

                e.Graphics.DrawString(shortHeatNumber,
                    Settings.Default.FontTibHeatNo,
                    new SolidBrush(Color.Black),
                    x, y);
            }
        }

        /// <summary>
        /// Seperate method dealing with the drawing of the tib event
        /// </summary>
        private void DrawTibEvent(PaintAppointmentEventArgs e, Rectangle rt)
        {
            string shortHeatNumber = "##";
            TibEvent tibEventData = e.Appointment.GetTibData();

            if (tibEventData.HeatNumber.HasValue)
            {
                if (tibEventData.HeatNumber.Value.ToString().Length > 2 &&
                    tibEventData.HeatNumber.Value.ToString().Length < 6)
                {
                    shortHeatNumber = tibEventData.HeatNumber.ToString().Substring(3);
                }
                else if (tibEventData.HeatNumber.Value > 0 &&
                         tibEventData.HeatNumber.Value < 50)
                {//LimePlant Number
                    shortHeatNumber = tibEventData.HeatNumber.Value.ToString();
                }
            }

            this.scheduler.DrawAppointment(
                e.Graphics,
                e.Appointment);

            SizeF textSize = HelperFunctions.GetFontSizeInPixels(
                                shortHeatNumber,
                                Settings.Default.FontTibHeatNo);

            //Draw heat number if Process Event and is wider than the text
            if (tibEventData.TibStatus == 2 &&
                rt.Width >= textSize.Width - 5)
            {
                int x = rt.Left + ((rt.Width - Convert.ToInt16(textSize.Width)) / 2);
                int y = rt.Top + ((rt.Height - Convert.ToInt16(textSize.Height)) / 2);

                e.Graphics.DrawString(shortHeatNumber,
                    Settings.Default.FontTibHeatNo,
                    new SolidBrush(Color.Black),
                    x, y);
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
                ColourTibEvents(currentTibHighlight.HeatNumber);
                currentTibHighlight = null;
            }
            //Restore original colour and reset currently highlighted planned event
            if (currentPlanHighlight != null)
            {
                ColourPlanEvents(currentPlanHighlight.HeatNumber);
                currentPlanHighlight = null;
            }

            //If it finds an appointment, then colour it
            if (appointment != null)
            {
                if (appointment.Tag is TibEvent)
                {
                    TibEvent tibData = appointment.GetTibData();//Get the data

                    if (tibData.TibStatus == 2 &&   //Producing
                        tibData.HeatNumber.HasValue &&
                        tibData.HeatNumber.Value >= Settings.Default.MinHeatNumber &&
                        tibData.HeatNumber.Value <= Settings.Default.MaxHeatNumber)
                    {
                        ColourTibEvents(tibData.HeatNumber, Settings.Default.ColourHighlight);
                        currentTibHighlight = tibData;//Store for later
                    }
                }
                else //Planning Event
                {
                    ProductionEvent planData = appointment.GetHeatData();//Get the data
                    ColourPlanEvents(planData.HeatNumber, Color.White);
                    currentPlanHighlight = planData;//Store for later
                }
            }
        }

        /// <summary>
        /// Event occurs on click of an appointment
        /// </summary>
        private void scheduler_AppointmentClick(object sender, AppointmentClickEventArgs e)
        {
            //tipTib.Hide(this);
            //Grab the appointment that was clicked.
            lastAppClicked = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));

            if (this.TibSchedulerAppointmentClick != null)
            {
                SchedulerEventArgs myArgs = new SchedulerEventArgs();
                myArgs.Appointment = lastAppClicked;
                myArgs.AppointmentClickEventArgs = e;
                this.TibSchedulerAppointmentClick(sender, myArgs);
            }
        }

        /// <summary>
        /// Events occurs when first date time is changed on the scheduler.
        /// </summary>
        private void scheduler_FirstDateTimeChanged(object sender, EventArgs e)
        {
            if (this.TibSchedulerFirstDateTimeChanged != null)
            {
                this.TibSchedulerFirstDateTimeChanged(sender, e);
            }
        }

        /// <summary>
        /// Event occurs on mouse down of an appointment.  Detects a right click
        /// to show a context menu.
        /// </summary>
        private void scheduler_MouseDown(object sender, MouseEventArgs e)
        {
            //tipTib.Hide(this);
            lastAppClicked = null;
            lastAppClicked = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Right)
            {
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
                            ctxMenuHeat.Show(this, new Point(e.X, e.Y));
                        }
                        else if (tibData.TibStatus.HasValue && tibData.TibStatus.Value != 2)
                            ctxMenuDelay.Show(this, new Point(e.X, e.Y));
                        else
                            ctxMenuHeat.Show(this, new Point(e.X, e.Y));
                    }
                }
            }
        }

        /// <summary>
        /// Event for context menu. Shows heat details screen
        /// </summary>
        private void ctxHeatDetails_Click(object sender, EventArgs e)
        {
            if (lastAppClicked != null)
            {
                this.Cursor = Cursors.WaitCursor;
                TibEvent tibEvent = lastAppClicked.GetTibData();

                if (tibEvent.TibStatus.HasValue &&
                    tibEvent.TibStatus.Value == 2 &&
                    tibEvent.HeatNumber.HasValue &&
                    tibEvent.HeatNumber.Value >= Settings.Default.MinHeatNumber &&
                    tibEvent.HeatNumber.Value <= Settings.Default.MaxHeatNumber)
                {
                    ShowHeatDetails(tibEvent);
                }
                else if (!tibEvent.HeatNumber.HasValue)
                {
                    ProductionEvent prodEvent = lastAppClicked.GetHeatData();
                    ShowHeatDetails(prodEvent);
                }
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Event for context menu. Shows delay entry screen
        /// </summary>
        private void ctxDelayEntry_Click(object sender, EventArgs e)
        {
            if (lastAppClicked != null)
            {
                this.Cursor = Cursors.WaitCursor;
                ShowTibDelayEntry(lastAppClicked.GetTibData());
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Event for double click on a tib event.
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
                        ShowTibDelayEntry(tibData);
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
        /// Resize event for control
        /// </summary>
        private void TibScheduler_Resize(object sender, EventArgs e)
        {
            ShowHideLegend();
        }
        #endregion

        #endregion
    }
}
