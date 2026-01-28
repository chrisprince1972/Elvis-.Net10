using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;

namespace Elvis.UserControls.Generic
{
    /// <summary>
    /// Adapted from the version in the TrendingForm.cs.
    /// Defaults to the DateTime Min and Max values.
    /// </summary>
    public partial class ElvisDateTimeRangeSelector : UserControl
    {
        public event EventHandler OnChange;

        private DateTime from = DateTime.MinValue;
        private DateTime to = DateTime.MaxValue;
        private bool Loaded { get; set; }
        public DateTime From 
        { 
            get { return GetFromDate(); }
        }

        public DateTime To
        {
            get { return GetToDate(); }
        }


        public ElvisDateTimeRangeSelector()
        {
            InitializeComponent();

            lblFrom.Enabled = dpFrom.Enabled =
            lblTo.Enabled = dpTo.Enabled =
                rbDate.Checked;

            lblWeek.Enabled = numWeek.Enabled =
            lblYear.Enabled = numYear.Enabled =
                rbWeekly.Checked;

            lblDay.Enabled = numDay.Enabled =
                rbDaily.Checked;

            if (rbDaily.Checked)
            {
                lblDay.Enabled = numDay.Enabled =
                lblWeek.Enabled = numWeek.Enabled =
                lblYear.Enabled = numYear.Enabled =
                    rbDaily.Checked;
            }

            rbLastShift.Enabled = rbLastDay.Enabled =
            rbCurrentShift.Enabled =
                rbFixed.Checked;
            this.Loaded = false;
        }


        public void SetupUserControl(DateTime fromDateTime, DateTime toDateTime)
        {
            this.from = fromDateTime;
            this.to = toDateTime;

            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)fromDateTime.DayOfWeek + 1;
            numWeek.Value = fromDateTime.WeekOfYear();
            numYear.Maximum = numYear.Value = fromDateTime.Year;
            numYear.Minimum = fromDateTime.Year - 5;

            rbCurrentShift.Checked = true;
            rbFixed.Checked = true;

            dpFrom.Value = fromDateTime;
            dpTo.Value = toDateTime;

            SetupDateSelector();

        }

        /// <summary>
        /// Gets the Date To using the date selectors.
        /// </summary>
        /// <returns>Date To for filter as DateTime</returns>
        private DateTime GetToDate()
        {
            if (rbDaily.Checked)
            {
                return this.From.AddDays(1);
            }
            else if (rbWeekly.Checked)
            {
                return this.From.AddDays(7);
            }
            else if (rbFixed.Checked)
            {
                if (rbLastShift.Checked)
                {//Last Shift
                    return this.From.AddHours(12);
                }
                else if (rbLastDay.Checked)
                {//Last Day
                    return this.From.AddHours(24);
                }
                else
                {//Current Shift
                    return MyDateTime.Now;
                }
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpTo.Value.ToString("yyyy-MM-dd 07:00"));
        }

        /// <summary>
        /// Gets the Date From using the date selectors.
        /// </summary>
        /// <returns>Date from for filter as DateTime</returns>
        private DateTime GetFromDate()
        {
            if (rbDaily.Checked)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00);
            }
            else if (rbWeekly.Checked)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,
                    07, 00, 00, 00);
            }
            else if (rbFixed.Checked)
            {
                DateTime startOfCurrentShift = Elvis.Common.TimeFunctions.StartOfShift_PT(MyDateTime.Now);

                if (rbLastShift.Checked)
                {//Last Shift
                    return startOfCurrentShift.AddHours(-12);
                }
                else if (rbLastDay.Checked)
                {//Last Day
                    return startOfCurrentShift.AddDays(-1);
                }
                else
                {//Current Shift
                    return startOfCurrentShift;
                }
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpFrom.Value.ToString("yyyy-MM-dd 07:00"));
        }



        /// <summary>
        /// Updates the date text on the form for the group boxes.
        /// </summary>
        private void UpdateDateLabel()
        {
            if (rbDate.Checked)
            {
                grpDateSelector.Text = "Date Selector";
            }
            else if (rbWeekly.Checked)
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,
                    07, 00, 00, 00));
            }
            else if (rbDaily.Checked)
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00));
            }
            else
            {
                DateTime startOfCurrentShift = Elvis.Common.TimeFunctions.StartOfShift_PT(MyDateTime.Now);

                if (rbLastShift.Checked)
                {//Last Shift
                    grpDateSelector.Text = string.Format("Date Selector - {0}",
                        startOfCurrentShift.AddHours(-12).ToString("dd/MM/yyyy HH:mm:ss"));
                }
                else if (rbLastDay.Checked)
                {//Last Day
                    grpDateSelector.Text = string.Format("Date Selector - {0}",
                        startOfCurrentShift.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss"));
                }
                else
                {//Current Shift
                    grpDateSelector.Text = string.Format("Date Selector - {0}",
                        startOfCurrentShift.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }
        }

        /// <summary>
        /// Checks for a week 53 in the currently selected year and 
        /// sets the number picker accordingly.
        /// </summary>
        private void SetupWeekNo()
        {
            if (Elvis.Common.DateTimeExtensions.IsWeek53Valid(Convert.ToInt16(numYear.Value)))
                numWeek.Maximum = 53;
            else
                numWeek.Maximum = 52;
        }



        /// <summary>
        /// Enables or disables the date filters depending on the 
        /// radio button selected.
        /// </summary>
        private void SetupDateSelector()
        {
            lblFrom.Enabled = dpFrom.Enabled =
            lblTo.Enabled = dpTo.Enabled =
                rbDate.Checked;

            lblWeek.Enabled = numWeek.Enabled =
            lblYear.Enabled = numYear.Enabled =
                rbWeekly.Checked;

            lblDay.Enabled = numDay.Enabled =
                rbDaily.Checked;

            if (rbDaily.Checked)
            {
                lblDay.Enabled = numDay.Enabled =
                lblWeek.Enabled = numWeek.Enabled =
                lblYear.Enabled = numYear.Enabled =
                    rbDaily.Checked;
            }

            rbLastShift.Enabled = rbLastDay.Enabled =
            rbCurrentShift.Enabled =
                rbFixed.Checked;
        }

        public void SelectPickDate()
        {
            rbDate.Select();
        }


        #region events


        private void ElvisDateTimeRangeSelector_Load(object sender, EventArgs e)
        {
            this.Loaded = true;
        }

        private void ChangeEvent(object sender, EventArgs e)
        {
            if (this.OnChange != null && this.Loaded)
            {
                this.OnChange(this, e);
            }
        }

        private void RadioButtonFormatChangeEvent(object sender, EventArgs e)
        {
            UpdateDateLabel();
            SetupDateSelector();
            ChangeEvent(sender, e);
        }

        private void DatePickerChangeEvent(object sender, EventArgs e)
        {
            ChangeEvent(sender, e);
        }
        private void NumericUpDownChangeEvent(object sender, EventArgs e)
        {
            UpdateDateLabel();
            ChangeEvent(sender, e);
        }

        /// <summary>
        /// Check changed event for the fixed radio buttons on the 
        /// date filters.
        /// </summary>
        private void RadioButtonLastChangeEvent(object sender, EventArgs e)
        {
            UpdateDateLabel();
            ChangeEvent(sender, e);
        }

        private void rbDate_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonFormatChangeEvent(sender, e);
        }
        
        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonFormatChangeEvent(sender, e);
        }

        private void rbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonFormatChangeEvent(sender, e);
        }

        private void rbFixed_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonFormatChangeEvent(sender, e);
        }

        private void dpFrom_ValueChanged(object sender, EventArgs e)
        {
            DatePickerChangeEvent(sender, e);
        }

        private void dpTo_ValueChanged(object sender, EventArgs e)
        {
            DatePickerChangeEvent(sender, e);
        }

        private void numDay_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownChangeEvent(sender, e);
        }

        private void numWeek_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownChangeEvent(sender, e);
        }

        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDownChangeEvent(sender, e);
        }

        private void rbLastDay_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonLastChangeEvent(sender, e);
        }

        private void rbLastShift_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonLastChangeEvent(sender, e);
        }

        private void rbCurrentShift_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonLastChangeEvent(sender, e);
        }
        #endregion 


    }
}
