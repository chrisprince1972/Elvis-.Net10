using System;
using System.Windows.Forms;
using Elvis.Common;
using System.ComponentModel;

namespace Elvis.UserControls.DatePickers
{
    public partial class DPDayWeekYear : UserControl
    {
        private bool formLoaded = false;
        private bool dayEnabled;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate
        {
            get { return GetDate(); }
            set { SetDate(value); }
        }

        public DateTime DateFrom
        {
            get { return GetDate(); }
        }

        public DateTime DateTo
        {
            get { return GetToDate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DayEnabled
        {
            get { return this.dayEnabled; }
            set
            {
                lblDay.Enabled = numDay.Enabled = this.dayEnabled = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FormLoaded
        {
            get { return this.formLoaded; }
            set { this.formLoaded = value; }
        }

        #region Delegates And Events
        /// <summary>
        /// Day Week Year date changed event handler.
        /// </summary>
        /// <param name="dateTime">The Date Time that was it was changed to.</param>
        public delegate void DPDayWeekYearDateChanged(DateTime dateTime);

        public event DPDayWeekYearDateChanged DayWeekYearDateChanged;

        #endregion Delegates And Events

        public DPDayWeekYear()
        {
            InitializeComponent();
        }

        private void DPDayWeekYear_Load(object sender, EventArgs e)
        {
            CommonFunctions.SetupYearControl(numYear);
            CommonFunctions.SetupWeekNoControl(numWeek, Convert.ToInt16(numYear.Value));
            InitialDateSetup();
            this.formLoaded = true;
            numYear_ValueChanged(null, new EventArgs());
        }

        private void InitialDateSetup()
        {
            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)DateTime.Now.DayOfWeek + 1;
            numWeek.Value = TimeFunctions.GetWeekNumber(DateTime.Now);//it was giving the wrong week number with dt.WeekOfYear();
            numYear.Value = DateTime.Now.Year;
        }

        private void SetDate(DateTime value)
        {
            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)value.DayOfWeek + 1;
            numWeek.Value = value.WeekOfYear();
            numYear.Value = value.Year;
        }

        private DateTime GetDate()
        {
            if (DayEnabled)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00);
            }
            else
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,//1 is Sunday
                    07, 00, 00, 00);
            }
        }

        private DateTime GetToDate()
        {
            if (DayEnabled)
            {
                return DateFrom.AddDays(1);
            }
            else
            {
                return DateFrom.AddDays(7);
            }
        }

        /// <summary>
        /// Updates the visual date label on value change.
        /// </summary>
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (this.formLoaded && this.DayWeekYearDateChanged != null)
            {
                this.DayWeekYearDateChanged(GetDate());
            }
        }

        /// <summary>
        /// Sets up week no everytime the year is changed to check for week 53.
        /// </summary>
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            CommonFunctions.SetupWeekNoControl(numWeek, Convert.ToInt16(numYear.Value));
            if (this.formLoaded && this.DayWeekYearDateChanged != null)
            {
                this.DayWeekYearDateChanged(GetDate());
            }
        }
    }
}
