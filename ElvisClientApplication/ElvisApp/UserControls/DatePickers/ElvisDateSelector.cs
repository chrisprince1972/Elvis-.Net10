using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Elvis.UserControls.DatePickers
{
    public partial class ElvisDateSelector : UserControl
    {
        private DateFormat dateFormat = DateFormat.DateSpan;
        private DPFromToCalender dpFromToCalender;
        private DPFromToWeekYear dpFromToWeekYear;
        private DPDayWeekYear dpDayWeekYear;

        public enum DateFormat { DateSpan, WeekSpan, Daily, Weekly };

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateFormat SelectedDateFormat
        {
            get { return this.dateFormat; }
            set
            {
                this.dateFormat = value;
                switch (value)
                {
                    case DateFormat.DateSpan:
                        rbDateSpan.Checked = true;
                        break;
                    case DateFormat.WeekSpan:
                        rbWeekSpan.Checked = true;
                        break;
                    case DateFormat.Weekly:
                        rbWeekly.Checked = true;
                        break;
                    case DateFormat.Daily:
                        rbDaily.Checked = true;
                        break;
                }
                SetupDateFormat(value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateFrom
        {
            get { return GetDateFrom(); }
            set { SetDateFrom(value); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateTo
        {
            get { return GetDateTo(); }
            set { SetDateTo(value); }
        }

        public bool Ready
        {
            get { return GetIsReady(); }
        }

        #region Delegates And Events
        /// <summary>
        /// Date Changed Event for the User Control
        /// </summary>
        public delegate void DateChanged(object sender);

        public event DateChanged DateChangedEvent;

        #endregion Delegates And Events

        public ElvisDateSelector()
        {
            InitializeComponent();

            dpFromToCalender = new DPFromToCalender();
            dpFromToWeekYear = new DPFromToWeekYear();
            dpDayWeekYear = new DPDayWeekYear();
        }

        private void ElvisDateSelector_Load(object sender, EventArgs e)
        {
            rbDateSpan.Tag = DateFormat.DateSpan;
            rbWeekSpan.Tag = DateFormat.WeekSpan;
            rbWeekly.Tag = DateFormat.Weekly;
            rbDaily.Tag = DateFormat.Daily;

            dpFromToCalender.Font = new Font("Tahoma", 8, FontStyle.Regular);
            dpFromToWeekYear.Font = new Font("Tahoma", 8, FontStyle.Regular);
            dpDayWeekYear.Font = new Font("Tahoma", 8, FontStyle.Regular);

            dpFromToCalender.FromToDateChanged +=
                new DPFromToCalender.DPFromToCalenderDateChanged(dpFromToCalender_DateChanged);

            dpFromToWeekYear.FromToWeekYearDateChanged +=
                new DPFromToWeekYear.DPFromToWeekYearDateChanged(dpFromToWeekYear_DateChanged);

            dpDayWeekYear.DayWeekYearDateChanged +=
                new DPDayWeekYear.DPDayWeekYearDateChanged(dpDayWeekYear_DayWeekYearDateChanged);
        }

        private void dpFromToCalender_DateChanged()
        {
            if (this.DateChangedEvent != null)
            {
                this.DateChangedEvent(this);
            }
        }

        private void dpFromToWeekYear_DateChanged()
        {
            if (this.DateChangedEvent != null)
            {
                this.DateChangedEvent(this);
            }
        }

        private void dpDayWeekYear_DayWeekYearDateChanged(DateTime dateTime)
        {
            if (this.dateFormat.Equals(DateFormat.Daily) ||
                this.dateFormat.Equals(DateFormat.Weekly))
            {
                SetDateSelectorGroupText("Date Selector - " + dateTime.ToString("dd/MM/yy HH:mm"));
            }
            if (this.DateChangedEvent != null)
            {
                this.DateChangedEvent(this);
            }
        }

        private void SetupDateFormat(DateFormat dateFormatToSetup)
        {
            this.dateFormat = dateFormatToSetup;
            switch (dateFormatToSetup)
            {
                case DateFormat.DateSpan:
                    CommonFunctions.AddUserControlToGroupBox(
                        grpDateSelector,
                        dpFromToCalender,
                        new Padding(8, 6, 10, 10));
                    SetDateSelectorGroupText("Date Selector");
                    break;

                case DateFormat.WeekSpan:
                    CommonFunctions.AddUserControlToGroupBox(
                        grpDateSelector,
                        dpFromToWeekYear,
                        new Padding(6, 2, 6, 6));
                    SetDateSelectorGroupText("Date Selector");
                    break;

                case DateFormat.Weekly:
                    dpDayWeekYear.DayEnabled = false;
                    CommonFunctions.AddUserControlToGroupBox(
                        grpDateSelector,
                        dpDayWeekYear,
                        new Padding(8, 6, 10, 10));
                    SetDateSelectorGroupText(
                        "Date Selector - " + GetDateFrom().ToString("dd/MM/yy HH:mm")
                        );
                    break;

                case DateFormat.Daily:
                    dpDayWeekYear.DayEnabled = true;
                    CommonFunctions.AddUserControlToGroupBox(
                        grpDateSelector,
                        dpDayWeekYear,
                        new Padding(8, 6, 10, 10));
                    SetDateSelectorGroupText(
                        "Date Selector - " + GetDateFrom().ToString("dd/MM/yy HH:mm")
                        );
                    break;
            }
        }

        private DateTime GetDateFrom()
        {
            switch (this.dateFormat)
            {
                case DateFormat.DateSpan:
                    return dpFromToCalender.DateFrom;

                case DateFormat.WeekSpan:
                    return dpFromToWeekYear.DateFrom;

                case DateFormat.Weekly:
                case DateFormat.Daily:
                    return dpDayWeekYear.DateFrom;

                default:
                    return DateTime.Now;
            }
        }

        private DateTime GetDateTo()
        {
            switch (this.dateFormat)
            {
                case DateFormat.DateSpan:
                    return dpFromToCalender.DateTo;

                case DateFormat.WeekSpan:
                    return dpFromToWeekYear.DateTo;

                case DateFormat.Weekly:
                case DateFormat.Daily:
                    return dpDayWeekYear.DateTo;

                default:
                    return DateTime.Now;
            }
        }

        private bool GetIsReady()
        {
            switch (this.dateFormat)
            {
                case DateFormat.DateSpan:
                    return dpFromToCalender.FormLoaded;

                case DateFormat.WeekSpan:
                    return dpFromToWeekYear.FormLoaded;

                case DateFormat.Weekly:
                case DateFormat.Daily:
                    return dpDayWeekYear.FormLoaded;

                default:
                    return false;
            }
        }

        private void SetDateFrom(DateTime value)
        {
            dpFromToCalender.DateFrom = value;
            dpFromToWeekYear.DateFrom = value.AddMonths(1).AddDays(-7);
            dpDayWeekYear.SelectedDate = value;
        }

        private void SetDateTo(DateTime value)
        {
            dpFromToCalender.DateTo = value;
            dpFromToWeekYear.DateTo = value;
            dpDayWeekYear.SelectedDate = value;
        }

        private void SetDateSelectorGroupText(string text)
        {
            grpDateSelector.Text = text;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked && rb.Tag != null &&
                    rb.Tag is DateFormat)
                {
                    SetupDateFormat((DateFormat)rb.Tag);
                    if (this.DateChangedEvent != null)
                    {
                        this.DateChangedEvent(this);
                    }
                }
            }
        }
    }
}
