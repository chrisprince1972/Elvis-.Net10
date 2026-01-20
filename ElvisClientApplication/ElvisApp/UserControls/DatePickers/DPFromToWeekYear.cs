using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;

namespace Elvis.UserControls.DatePickers
{
    public partial class DPFromToWeekYear : UserControl
    {
        private bool formLoaded = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateFrom
        {
            get { return GetDate(numWeekFrom, numYearFrom); }
            set { SetDate(numWeekFrom, numYearFrom, value); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateTo
        {
            get { return GetDate(numWeekTo, numYearTo).AddDays(7); }//The function returns a date that's a week too early.
            set { SetDate(numWeekTo, numYearTo, value); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FormLoaded
        {
            get { return this.formLoaded; }
            set { this.formLoaded = value; }
        }

        #region Delegates And Events
        /// <summary>
        /// Date Changed Event Handler.
        /// </summary>
        public delegate void DPFromToWeekYearDateChanged();

        public event DPFromToWeekYearDateChanged FromToWeekYearDateChanged;

        #endregion Delegates And Events

        public DPFromToWeekYear()
        {
            InitializeComponent();
        }

        private void DPFromToWeekYear_Load(object sender, EventArgs e)
        {
            CommonFunctions.SetupYearControl(numYearFrom);
            CommonFunctions.SetupYearControl(numYearTo);
            CommonFunctions.SetupWeekNoControl(numWeekFrom, Convert.ToInt16(numYearFrom.Value));
            CommonFunctions.SetupWeekNoControl(numWeekTo, Convert.ToInt16(numYearTo.Value));
            InitialDateSetup();
            this.formLoaded = true;
            numWeek_ValueChanged(null, new EventArgs());
        }

        private void InitialDateSetup()
        {
            int weekNo = TimeFunctions.GetWeekNumber(DateTime.Now);
            int yearNo = DateTime.Now.Year;

            numWeekTo.Value = weekNo;
            numYearTo.Value = yearNo;

            numWeekFrom.Value = weekNo - 1;
            numYearFrom.Value = yearNo;

            if (weekNo == 1)
            {
                if (DateTimeExtensions.IsWeek53Valid(yearNo - 1))
                    numWeekFrom.Value = 53;
                else
                    numWeekFrom.Value = 52;

                numYearFrom.Value = yearNo - 1;
            }
        }

        private DateTime GetDate(NumericUpDown numWeek, NumericUpDown numYear)
        {
            return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                Convert.ToInt16(numYear.Value),
                Convert.ToInt16(numWeek.Value),
                1,//1 is Sunday
                07, 00, 00, 00);
        }

        private void SetDate(NumericUpDown numWeek, NumericUpDown numYear, DateTime value)
        {
            numWeek.Value = value.WeekOfYear();
            numYear.Value = value.Year;
        }

        private void UpdateDateLabels()
        {
            lblDateFrom.Text = DateFrom.ToString("dd/MM/yy");
            lblDateTo.Text = DateTo.ToString("dd/MM/yy");
        }

        /// <summary>
        /// Updates the visual date label on value change.
        /// </summary>
        private void numWeek_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabels();
            if (this.formLoaded && this.FromToWeekYearDateChanged != null)
            {
                this.FromToWeekYearDateChanged();
            }
        }

        /// <summary>
        /// Sets up week no everytime the year is changed to check for week 53.
        /// </summary>
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            CommonFunctions.SetupWeekNoControl(numWeekFrom, Convert.ToInt16(numYearFrom.Value));
            CommonFunctions.SetupWeekNoControl(numWeekTo, Convert.ToInt16(numYearTo.Value));
            UpdateDateLabels();
            if (this.formLoaded && this.FromToWeekYearDateChanged != null)
            {
                this.FromToWeekYearDateChanged();
            }
        }
    }
}
