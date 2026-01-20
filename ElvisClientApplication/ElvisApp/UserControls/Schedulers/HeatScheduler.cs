using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using MLJSystems.Calendars;
using System.ComponentModel;

namespace Elvis.UserControls
{
    /// <summary>
    /// The graphical overview component that provides encapsulated display of the heat blocks on 
    /// the resource scheduler chart. Displays the schedule in a time based gantt chart format. 
    /// </summary>
    public partial class HeatScheduler : BaseScheduler
    {
        #region Variables + Properties
        public enum ColourSetting { Caster, Vessel };//Add more if needed
        private ColourSetting currentColourSetting = ColourSetting.Caster;//Sets up Default Colour Setting
        private ProductionEvent currentHighlightedHeat = null;
        private bool showMiscasts;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ColourSetting CurrentColourSetting
        {
            get
            {
                return this.currentColourSetting;
            }
            set
            {
                this.currentColourSetting = value;
                CustomiseColours();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowMiscasts
        {
            get { return this.showMiscasts; }
            set
            {
                this.showMiscasts = value;
                scheduler.Refresh();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the HeatScheduler class.
        /// </summary>
        public HeatScheduler()
        {
            this.InitializeComponent();
            //Needs the minus 2 hours to stop a weird scroll error.
            this.scheduler.MinDate = DateTime.Now.AddDays(-Settings.Default.OverviewDaysToShow).AddHours(-2);
            this.scheduler.MaxDate = DateTime.Now.AddDays(2);
            this.scheduler.FirstDateTime = DateTime.Now.AddHours(-6);
        }
        #endregion

        #region Delegates and Events
        /// <summary>
        /// Fires when an appointment is clicked on.
        /// </summary>
        /// <param name="sender">The HeatScheduler. </param>
        /// <param name="e">HeatScheduler Event properties.</param>
        public delegate void HeatSchedulerAppointmentClickEventHandler(object sender, SchedulerEventArgs e);

        /// <summary>
        /// Fires when a mouse double click occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void HeatSchedulerMouseDoubleClickEventHandler(object sender, SchedulerEventArgs e);

        public event HeatSchedulerAppointmentClickEventHandler HeatSchedulerAppointmentClick;
        public event HeatSchedulerMouseDoubleClickEventHandler HeatSchedulerMouseDoubleClick;

        /// <summary>
        /// Fires when the first date time property is changed.
        /// </summary>
        /// <param name="sender">The HeatScheduler.</param>
        /// <param name="e">HeatScheduler Event properties.</param>
        public delegate void HeatSchedulerFirstDateTimeEventHandler(object sender, EventArgs e);
        public event HeatSchedulerFirstDateTimeEventHandler HeatSchedulerFirstDateTimeChanged;
        #endregion

        #region Methods

        #region Display Methods
        /// <summary>
        /// Adjust the heat scheduler to display a one hour time window. 
        /// </summary>
        public void DisplayOneHourView()
        {
            this.scheduler.HoursResolution = HoursResolutions.One;
            this.scheduler.Refresh();
        }

        /// <summary>
        /// Adjust the heat scheduler to display a two hour time window. 
        /// </summary>
        public void DisplayTwoHourView()
        {
            this.scheduler.HoursResolution = HoursResolutions.Two;
            this.scheduler.Refresh();
        }

        /// <summary>
        /// Adjust the heat scheduler to display a half hour time window. 
        /// </summary>
        public void DisplayThirtyMinuteView()
        {
            this.scheduler.HoursResolution = HoursResolutions.Half;
            this.scheduler.Refresh();
        }

        /// <summary>
        /// Adjust the heat scheduler to display a 15 min time window. 
        /// </summary>
        public void DisplayFifteenMinuteView()
        {
            this.scheduler.HoursResolution = HoursResolutions.Quart;
            this.scheduler.Refresh();
        }

        /// <summary>
        /// Adjust the heat scheduler to display a 10 min time window. 
        /// </summary>
        public void DisplayTenMinuteView()
        {
            this.scheduler.HoursResolution = HoursResolutions.TenMinutes;
            this.scheduler.Refresh();
        }
        #endregion

        #region Customise Appearance
        /// <summary>
        /// Set the colour of all blocks that represent a certain heat number.
        /// </summary>
        /// <param name="heat"></param>
        public void ColourHeats(int heat)
        {
            foreach (Appointment a in this.scheduler.Appointments)
            {
                ProductionEvent eventData = a.GetHeatData();
                if (eventData.HeatNumber == heat)
                {
                    if (currentColourSetting == ColourSetting.Caster)
                        a.BackColor = Colours.GetColourByCaster(eventData.CasterName, eventData.IsPlanningBlock, eventData.ProgramNumber);
                    else if (currentColourSetting == ColourSetting.Vessel)
                        a.BackColor = Colours.GetColourByVessel(eventData.VesselNumber, eventData.IsPlanningBlock);
                }
                if (a.Text == "SlowCast")
                    a.BackColor = Colours.GetSlowCastBackColour();
            }
        }

        /// <summary>
        /// Set the colour of all blocks that represent a certain heat number.
        /// </summary>
        /// <param name="heat"></param>
        public void ColourHeats(int heat, Color colour)
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
        /// Set the colour of blocks depending on the selection
        /// </summary>
        public void CustomiseColours()
        {
            foreach (Appointment a in this.scheduler.Appointments)
            {
                ProductionEvent eventData = a.GetHeatData();

                if (currentColourSetting == ColourSetting.Caster)
                {
                    a.BackColor = Colours.GetColourByCaster(
                        eventData.CasterName, eventData.IsPlanningBlock,
                        eventData.ProgramNumber);
                }
                else if (currentColourSetting == ColourSetting.Vessel)
                {
                    a.BackColor = Colours.GetColourByVessel(
                        eventData.VesselNumber, eventData.IsPlanningBlock);
                }
                if (a.Text == "SlowCast")
                    a.BackColor = Colours.GetSlowCastBackColour();
            }
        }
        #endregion

        #region Load
        /// <summary>
        /// Loads all heat events into the scheduler
        /// </summary>
        /// <param name="events">A list of events.</param>
        /// <param name="isPlanning">Bool value stating if they are planning events or not.</param>
        public void LoadEvents(List<ProductionEvent> events, bool isPlanning)
        {
            if (!isPlanning)
                this.scheduler.Appointments.Clear();

            if (events != null)
            {
                foreach (ProductionEvent unitEvent in events)
                {
                    if (unitEvent != null)
                    {
                        if (!unitEvent.EndTime.HasValue || unitEvent.EndTime <= DateTime.MinValue)
                        {
                            if (isPlanning)//Planning
                            {
                                continue;
                            }
                            else//Normal
                            {
                                unitEvent.EndTime = DateTime.Now;
                            }
                        }

                        //Don't add silly events with dodgy heat numbers
                        if (unitEvent.HeatNumber < Settings.Default.MinHeatNumber || 
                            unitEvent.HeatNumber > Settings.Default.MaxHeatNumber)
                        {
                            continue;
                        }

                        //Find the index of the unit in the left hand column
                        int index = FindResourceIndex(unitEvent.UnitId);

                        if (isPlanning)
                        {
                            //Check if the event has started, if so set startime to now to cut the planning block
                            if (unitEvent.PlanStartTime < DateTime.Now)
                            {
                                unitEvent.StartTime = DateTime.Now;
                            }
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
                            ResourceIndex = index,
                            LinkWithNext = false
                        };

                        //Adds the predicted slow casting planning blocks to the caster units
                        if (isPlanning && unitEvent.CastDuration > 0 &&
                            unitEvent.IdealCastingTime > 0 &&
                            (unitEvent.CastDuration - unitEvent.IdealCastingTime) > 0)
                        {
                            appointment.End = unitEvent.EndTime.Value.AddMinutes(
                                -(unitEvent.CastDuration - unitEvent.IdealCastingTime));

                            DateTime start = unitEvent.EndTime.Value.AddMinutes(
                                    -(unitEvent.CastDuration - unitEvent.IdealCastingTime));
                            if (start < DateTime.Now)
                                start = DateTime.Now;//Stops overflow of blocks onto historical side of scheduler

                            Appointment slowCastEvent = new Appointment()
                            {
                                Start = start,
                                End = unitEvent.EndTime.Value,
                                Tag = unitEvent,
                                Text = "SlowCast",
                                ResourceIndex = index,
                                LinkWithNext = false
                            };

                            slowCastEvent.ForeColor = Color.Black;
                            slowCastEvent.BackColor = Colours.GetSlowCastBackColour();
                            AddAppointment(slowCastEvent);
                        }

                        if (currentColourSetting == ColourSetting.Caster)
                        {
                            appointment.BackColor = Colours.GetColourByCaster(
                                unitEvent.CasterName, unitEvent.IsPlanningBlock,
                                unitEvent.ProgramNumber);
                        }
                        else if (currentColourSetting == ColourSetting.Vessel)
                        {
                            appointment.BackColor = Colours.GetColourByVessel(
                                unitEvent.VesselNumber, unitEvent.IsPlanningBlock);
                        }

                        appointment.ForeColor = Color.Black;
                        AddAppointment(appointment);
                    }
                }
            }
        }
        #endregion

        #region Appointment / Booking Clicks
        /// <summary>
        /// Captures the HeatScheduler appointment click and forwards it to the subscribed event.
        /// </summary>
        /// <param name="sender">Heat Scheduler.</param>
        /// <param name="e">Any arguments.</param>
        private void scheduler_AppointmentClick(object sender, AppointmentClickEventArgs e)
        {
            // Grab the appointment that was clicked.
            Appointment appointment = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));

            if (this.HeatSchedulerAppointmentClick != null)
            {
                SchedulerEventArgs myArgs = new SchedulerEventArgs();
                myArgs.Appointment = appointment;
                myArgs.AppointmentClickEventArgs = e;
                this.HeatSchedulerAppointmentClick(sender, myArgs);
            }
        }

        /// <summary>
        /// Captures the HeatScheduler double click and forwards it to the subscribed event.
        /// </summary>
        /// <param name="sender">Heat Scheduler.</param>
        /// <param name="e">Any arguments.</param>
        private void scheduler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Grab the appointment that was clicked
            Appointment appointment = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));

            if (this.HeatSchedulerMouseDoubleClick != null)
            {
                SchedulerEventArgs myArgs = new SchedulerEventArgs();
                myArgs.Appointment = appointment;
                myArgs.MouseEventArgs = e;
                this.HeatSchedulerMouseDoubleClick(sender, myArgs);
            }
        }
        #endregion

        #region Scheduler Events
        /// <summary>
        /// Check that the user isn't trying to page back the scheduler component years
        /// This will prevent buffer overflows of dates years ago or way into the future.
        /// </summary>
        private void scheduler_FirstDateTimeChanged(object sender, EventArgs e)
        {
            DateTime firstPossibleDate = new DateTime(1990, 1, 1);
            DateTime lastPossibleDate = new DateTime(2050, 1, 1);

            // If we at the limit then stop - PAST
            if (this.scheduler.FirstDateTime <= firstPossibleDate)
            {
                this.scheduler.FirstDateTime = firstPossibleDate;
            }

            // If we at the limit then stop - FUTURE
            if (this.scheduler.FirstDateTime >= lastPossibleDate)
            {
                this.scheduler.FirstDateTime = lastPossibleDate;
            }

            if (this.HeatSchedulerFirstDateTimeChanged != null)
            {
                this.HeatSchedulerFirstDateTimeChanged(sender, e);
            }
        }

        /// <summary>
        /// Method to process the mouse move events.
        /// </summary>
        /// <param name="sender">The heat scheduler.</param>
        /// <param name="e">Any mouse arguments.</param>
        private void scheduler_MouseMove(object sender, MouseEventArgs e)
        {
            //Try to find appointment
            Appointment appointment = this.scheduler.HitAppointmentTest(new Point(e.X, e.Y));

            //Restore original colour and reset currently highlighted
            if (currentHighlightedHeat != null)
            {
                ColourHeats(currentHighlightedHeat.HeatNumber);
                currentHighlightedHeat = null;
            }
            //If it finds an appointment, then colour it
            if (appointment != null)
            {
                ProductionEvent heatData = appointment.GetHeatData();//Get the data
                ColourHeats(heatData.HeatNumber, Color.White);
                currentHighlightedHeat = heatData;//Store for later
            }
        }

        /// <summary>
        /// Override the normal drawing event of the appointment and add in our own labels for 
        /// the heat number etc. This will be outside the bounds of the rectangle, 
        /// but will belong to the appointment.
        /// </summary>
        /// <param name="sender">The heat scheduler base class.</param>
        /// <param name="args">The paint event args.</param>
        private void scheduler_PaintAppointment(object sender, PaintAppointmentEventArgs args)
        {
            args.UserPaint = true;

            foreach (Rectangle rt in this.scheduler.GetAppointmentRectangles(args.Appointment, true))
            {
                ProductionEvent heatData = args.Appointment.GetHeatData();
                string shortHeatNumber = "##";
                string extraData = "##";

                if (heatData != null)
                {
                    if (heatData.HeatNumber.ToString().Length > 2 &&
                        heatData.HeatNumber.ToString().Length < 6)
                    {
                        shortHeatNumber = heatData.HeatNumber.ToString().Substring(3);
                        if (heatData.IsHotConnect)
                        {
                            if (args.Appointment.ResourceIndex >= 15 && args.Appointment.ResourceIndex <= 17)
                            {
                                shortHeatNumber = "HC" + shortHeatNumber;
                            }
                        }
                    }

                    if (CurrentDataSetting == ExtraData.Grade &&
                        heatData.Grade > 0 &&
                        heatData.UnitId > 10 && heatData.UnitId < 14)//Casters only
                    {
                        extraData = heatData.Grade.ToString();
                    }
                    else if (CurrentDataSetting == ExtraData.ProgramNo &&
                             heatData.ProgramNumber > 0)
                    {
                        extraData = heatData.ProgramNumber.ToString();
                    }
                    else if (CurrentDataSetting == ExtraData.LadleNo &&
                             heatData.LadleNumber > 0)//Anything after desulph
                    {
                        extraData = heatData.LadleNumber.ToString();
                    }

                    if (args.Appointment.Text != string.Empty)
                    {
                        this.scheduler.DrawAppointment(
                            args.Graphics,
                            args.Appointment);

                        //Sets up fonts and colours for text
                        SolidBrush brush = new SolidBrush(Color.Black);
                        Font font = Settings.Default.FontOverviewHeatNo;
                        SizeF textSize = HelperFunctions.GetFontSizeInPixels(
                            shortHeatNumber,
                            font);

                        if (!string.IsNullOrWhiteSpace(heatData.MiscastType) && this.showMiscasts)
                        {//Means there has been a miscast - will only appear on Caster Events
                            brush = new SolidBrush(Color.Red);//New Font Colour
                            font = Settings.Default.FontOverviewMiscast;//New Font
                            //Add space to short type.
                            string shortType = " " + HelperFunctions.GetMiscastShort(heatData.MiscastType);
                            string miscastHN = heatData.HeatNumber.ToString() + shortType;

                            //Calculates the size of a full heat number showing
                            textSize = HelperFunctions.GetFontSizeInPixels(
                            miscastHN,
                            font);

                            if (rt.Width < textSize.Width)
                            {//Uses abbreviated heatnumber due to box size being too small
                                shortHeatNumber += shortType;
                                textSize = HelperFunctions.GetFontSizeInPixels(
                                    shortHeatNumber,
                                    font);
                            }
                            else//Uses original full heatnumber
                                shortHeatNumber = miscastHN;
                        }

                        //Only Show labels if box is wider than text size and not slow casting
                        if (rt.Width >= textSize.Width - 6 && args.Appointment.Text != "SlowCast")
                        {
                            args.Graphics.DrawString(
                                shortHeatNumber,
                                font,
                                brush,
                                rt.Left - 3,
                                rt.Top - 13);
                        }

                        SizeF extraDataSize = HelperFunctions.GetFontSizeInPixels(
                            extraData,
                            Settings.Default.FontOverviewExtraData);

                        //Show extra data if it exists, if box is big enough and it is not a slow casting event
                        if (CurrentDataSetting != ExtraData.None &&
                            extraData != "##" &&
                            rt.Width >= extraDataSize.Width - 5 &&
                            args.Appointment.Text != "SlowCast")
                        {
                            int x = rt.Left + ((rt.Width - Convert.ToInt16(extraDataSize.Width)) / 2);
                            int y = rt.Top + ((rt.Height - Convert.ToInt16(extraDataSize.Height)) / 2);

                            args.Graphics.DrawString(
                                extraData,
                                Settings.Default.FontOverviewExtraData,
                                Colours.GetAppointmentTextColour(args.Appointment.BackColor),
                                x, y);
                        }
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}
