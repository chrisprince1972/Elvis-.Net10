using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using MLJSystems.Calendars;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elvis.UserControls
{
    /// <summary>
    /// The Base Scheduler should be inherited from for any subsequent
    /// schedulers used through out the project.  All common 
    /// properties/methods etc. should be declared here.
    /// </summary>
    public partial class BaseScheduler : UserControl
    {
        #region Variables
        private ExtraData extraDataSetting = ExtraData.None;//Sets up Default Data Setting
        public enum ExtraData { None, ProgramNo, Grade, LadleNo };//Add more if needed
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Properties
        /// <summary>
        /// Modify the Cell Width.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CellWidth
        {
            get
            {
                return this.scheduler.CellWidth;
            }
            set
            {
                this.scheduler.CellWidth = value;
                this.scheduler.Refresh();
            }
        }
        /// <summary>
        /// Show/Hide Shadows Underneath Appointments.
        /// </summary>

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowShadows
        {
            get
            {
                return scheduler.ShowShadows;
            }
            set
            {
                scheduler.ShowShadows = value;
                scheduler.Refresh();
            }
        }
        /// <summary>
        /// Show/Hide the Scheduler's Timeline.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTimeline
        {
            get
            {
                return scheduler.TodayTimelineVisible;
            }
            set
            {
                scheduler.TodayTimelineVisible = value;
                scheduler.Refresh();
            }
        }
        /// <summary>
        /// Swap between different data settings to display.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExtraData CurrentDataSetting
        {
            get
            {
                return this.extraDataSetting;
            }
            set
            {
                this.extraDataSetting = value;
                scheduler.Refresh();
            }
        }
        #endregion

        #region Constructor
        public BaseScheduler()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region Scheduler Date Navidation
        /// <summary>
        /// Change Min Date of Scheduler
        /// </summary>
        /// <param name="d"></param>
        public void SetMinDate(DateTime d)
        {
            this.scheduler.MinDate = d;
        }

        /// <summary>
        /// Change Max Date of Scheduler
        /// </summary>
        /// <param name="d"></param>
        public void SetMaxDate(DateTime d)
        {
            this.scheduler.MaxDate = d;
        }

        /// <summary>
        /// Change starting date to display specific date
        /// </summary>
        public void DisplayDateTime(DateTime dt)
        {
            if (dt >= this.scheduler.MinDate && dt <= this.scheduler.MaxDate)
            {
                try
                {
                    this.scheduler.FirstDateTime = dt;
                    this.scheduler.Refresh();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.DebugException("BASE SCHEDULER DATE ERROR -- DisplayDateTime -- Out of Range -- ", ex);
                }
            }
        }

        /// <summary>
        /// Change date scale to display the last complete shift
        /// </summary>
        public void DisplayLastShift()
        {
            try
            {
                //Set to the start of the last shift.
                DateTime startOfCurrentShift = TimeFunctions.StartOfShift_PT(MyDateTime.Now);
                this.scheduler.FirstDateTime = startOfCurrentShift.AddHours(-12);
                this.scheduler.CellWidth = (this.scheduler.Width - this.scheduler.LeftResourceWidth) / 12;
                this.scheduler.HoursResolution = HoursResolutions.One;
                this.scheduler.Refresh();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger.DebugException("BASE SCHEDULER DATE ERROR -- DisplayLastShift -- Out of Range -- ", ex);
            }
        }

        /// <summary>
        /// Display the last complete day
        /// </summary>
        public void DisplayLastDay()
        {
            try
            {
                // Set to the start of the last day.
                DateTime startOfCurrentShift = TimeFunctions.StartOfShift_PT(MyDateTime.Now);
                this.scheduler.FirstDateTime = startOfCurrentShift.AddDays(-1);
                this.scheduler.CellWidth = (this.scheduler.Width - this.scheduler.LeftResourceWidth) / 24;
                this.scheduler.HoursResolution = HoursResolutions.One;
                this.scheduler.Refresh();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger.DebugException("BASE SCHEDULER DATE ERROR -- DisplayLastDay -- Out of Range -- ", ex);
            }
        }

        /// <summary>
        /// Display the day in a 7-7 view.
        /// </summary>
        public void Display7Til7View(DateTime dt)
        {
            try
            {
                this.scheduler.FirstDateTime = new DateTime(
                    dt.Year,
                    dt.Month,
                    dt.Day, 7, 0, 0
                    );
                this.scheduler.CellWidth = (this.scheduler.Width - this.scheduler.LeftResourceWidth) / 24;
                this.scheduler.HoursResolution = HoursResolutions.One;
                this.scheduler.Refresh();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger.DebugException("BASE SCHEDULER DATE ERROR -- Display7Til7View -- Out of Range -- ", ex);
            }
        }

        /// <summary>
        /// Moves the scheduler x hours backwards in time.
        /// </summary>
        public void StepBack(double x)
        {
            DateTime newDate = this.scheduler.FirstDateTime.AddHours(-x);
            if (newDate >= this.scheduler.MinDate)
            {
                try
                {
                    this.scheduler.FirstDateTime = newDate;
                    this.scheduler.Refresh();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.DebugException("BASE SCHEDULER DATE ERROR -- StepBack -- Out of Range -- ", ex);
                }
            }
        }

        /// <summary>
        /// Moves the scheduler x hours forwards in time.
        /// </summary>
        public void StepForward(double x)
        {
            DateTime newDate = this.scheduler.FirstDateTime.AddHours(x);
            if (newDate < this.scheduler.MaxDate)
            {
                try
                {
                    this.scheduler.FirstDateTime = newDate;
                    this.scheduler.Refresh();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.DebugException("BASE SCHEDULER DATE ERROR -- StepForward -- Out of Range -- ", ex);
                }
            }
        }

        /// <summary>
        /// Display a selected date
        /// </summary>
        public void DisplayDay(DateTime date)
        {
            try
            {
                // Show the selected day.
                DateTime startDate = Convert.ToDateTime(date.ToString("dd-MM-yyyy 07:00:00"));
                if ((startDate >= this.scheduler.MinDate) && (startDate <= this.scheduler.MaxDate))
                {
                    this.scheduler.FirstDateTime = startDate;
                    this.scheduler.HoursResolution = HoursResolutions.One;
                    this.scheduler.Refresh();
                }
                else if (date.Date == this.scheduler.MinDate.Date)
                {
                    this.scheduler.FirstDateTime = date;
                    this.scheduler.HoursResolution = HoursResolutions.One;
                    this.scheduler.Refresh();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger.DebugException("BASE SCHEDULER DATE ERROR -- DisplayDay -- Out of Range -- ", ex);
            }
        }

        /// <summary>
        /// Changes the view to display the number of hours given.
        /// </summary>
        /// <param name="noOfHours">The number of hours to display.</param>
        public void DisplayTimeScale(int noOfHours)
        {
            switch (noOfHours)
            {
                //case 24:
                case 12:
                    this.scheduler.HoursResolution = HoursResolutions.Half;
                    this.scheduler.CellWidth =
                        ((this.scheduler.Width - this.scheduler.LeftResourceWidth) / 24) - 1;
                    break;
                case 6:
                    this.scheduler.HoursResolution = HoursResolutions.Quart;
                    this.scheduler.CellWidth =
                        ((this.scheduler.Width - this.scheduler.LeftResourceWidth) / 24) - 1;
                    break;
                case 2:
                    this.scheduler.HoursResolution = HoursResolutions.Minute;
                    this.scheduler.CellWidth =
                        ((this.scheduler.Width - this.scheduler.LeftResourceWidth) / 120);
                    break;
                case 1:
                    this.scheduler.HoursResolution = HoursResolutions.Minute;
                    this.scheduler.CellWidth =
                        ((this.scheduler.Width - this.scheduler.LeftResourceWidth) / 60);
                    break;
                default:
                    this.scheduler.HoursResolution = HoursResolutions.One;
                    this.scheduler.CellWidth =
                        ((this.scheduler.Width - this.scheduler.LeftResourceWidth) / 24) - 1;
                    break;
            }
            this.scheduler.Refresh();
        }
        #endregion

        #region Scheduler Functions
        /// <summary>
        /// Adds the specified appointment to the scheduler
        /// </summary>
        /// <param name="appointment">The appointment to add.</param>
        public void AddAppointment(Appointment appointment)
        {
            this.scheduler.Appointments.Add(appointment);
        }

        /// <summary>
        /// Allow the system to adjust the height of the rows for a best fit.
        /// </summary>
        public void AutoSizeResourceHeights()
        {
            if (this.scheduler.Resources.Count > 0)
            {
                int resourceCount = scheduler.Resources.Where(r => r.Visible).Count();

                if (resourceCount > 0)
                {
                    this.scheduler.RowHeight = (this.scheduler.Height / (resourceCount + 3));
                }

                if (this.scheduler.RowHeight < 21)//Min Height
                    this.scheduler.RowHeight = 21;
                else if (this.scheduler.RowHeight > 45)//Max Height
                    this.scheduler.RowHeight = 45;
            }
            this.scheduler.Refresh();
        }

        /// <summary>
        /// Helper method to identify the resource index in the array
        /// from the unitId.
        /// </summary>
        /// <param name="unitId">The unit id of the resource to find.</param>
        /// <returns>The index of the resource in the Resource array. If not found -1 will be returned.</returns>
        public int FindResourceIndex(int unitId)
        {
            foreach (Resource resource in this.scheduler.Resources)
            {
                if (resource.Tag != null)
                {
                    if (resource.Tag is Unit)
                    {
                        Unit unit = (Unit)resource.Tag;
                        if (!string.IsNullOrEmpty(resource.Text) &&
                            unit.UnitNumber == unitId)
                        {
                            return resource.Index;
                        }
                    }
                    else//Used for caster review tag (is an int)
                    {
                        int tag = -1;
                        if (int.TryParse(resource.Tag.ToString(), out tag))
                        {
                            if (tag == unitId)
                            {
                                return resource.Index;
                            }
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Method to Add a Blank Resource to the Scheduler
        /// </summary>
        public void AddBlankResource(Unit unit)
        {
            Resource resourceSpacer = new Resource();
            resourceSpacer.Tag = unit;
            resourceSpacer.BackColor = Color.Transparent;
            scheduler.Resources.Add(resourceSpacer);
        }
        #endregion

        #region Get/Load Data
        /// <summary>
        /// Load the units into the heat scheduler.
        /// </summary>
        /// <param name="unitsToInclude">A list of units to include in the scheduler.</param>
        public void LoadUnits(List<Unit> unitsToInclude)
        {
            scheduler.LeftResourceColumns.Clear();
            scheduler.Resources.Clear();

            // Add a column to the resources (left)
            scheduler.LeftResourceWidth = 100;
            ResourceColumn unitColumn = new ResourceColumn("Units", 0);
            unitColumn.Width = 75;
            scheduler.LeftResourceColumns.Add(unitColumn);

            string group = "";
            Color backColour = Settings.Default.ColourHeatScheduler2;

            if (unitsToInclude != null)
            {
                foreach (Unit unit in unitsToInclude)
                {
                    //Add Blank after each group (group CAS and degasser as one)
                    if (group != unit.UnitGroupText && unit.UnitGroupText != "Degassers")
                    {
                        backColour = Colours.AlternateBackColour(backColour);
                        AddBlankResource(unit);
                    }

                    //Create new resource
                    Resource resource = new Resource();
                    resource.Text = unit.UnitShort;
                    resource.Tag = unit;
                    resource.BackColor = backColour;

                    scheduler.Resources.Add(resource);
                    group = unit.UnitGroupText;
                }
            }
        }

        /// <summary>
        /// Gets the filtered units depending on scheduler.
        /// </summary>
        /// <param name="scheduler">The Scheduler Type.</param>
        /// <returns>A list of units ready for the schdeuler.</returns>
        public List<Unit> GetUnitsForScheduler(Forms.MainForm.Scheduler scheduler,
            List<Unit> units)
        {
            if (units != null)
            {
                if (scheduler == Forms.MainForm.Scheduler.Tib)
                {
                    return units
                        .Where(u =>
                            u.UnitGroupNumber.HasValue &&
                            u.UnitGroupNumber.Value < 9)
                        .ToList();
                }
                else if (scheduler == Forms.MainForm.Scheduler.Heat)
                {
                    return units
                        .Where(u => u.UnitNumber < 14)
                        .ToList();
                }
                else if (scheduler == Forms.MainForm.Scheduler.Caster)
                {
                    return units
                        .Where(u => u.UnitNumber >= 11 && u.UnitNumber <= 13)
                        .ToList();
                }
            }
            return units;
        }
        #endregion

        #region Printing
        /// <summary>
        /// Prints current schedueler
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        public void Print(Graphics g, Rectangle r)
        {
            this.scheduler.Print(g, r);
        }
        #endregion

        #endregion
    }
}
