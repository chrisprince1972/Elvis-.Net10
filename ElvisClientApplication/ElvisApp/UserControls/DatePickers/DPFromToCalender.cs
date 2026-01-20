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
    public partial class DPFromToCalender : UserControl
    {
        private bool formLoaded = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateFrom
        {
            get { return dpFrom.Value; }
            set 
            {
                if (value > dpFrom.MaxDate)
                    dpFrom.Value = dpFrom.MaxDate;
                else if (value < dpFrom.MinDate)
                    dpFrom.Value = dpFrom.MinDate;
                else
                    dpFrom.Value = value; 
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateFromMax
        {
            get { return dpFrom.MaxDate; }
            set { dpFrom.MaxDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateFromMin
        {
            get { return dpFrom.MinDate; }
            set { dpFrom.MinDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateTo
        {
            get { return dpTo.Value; }
            set 
            { 
                if (value > dpTo.MaxDate)
                    dpTo.Value = dpTo.MaxDate;
                else if (value < dpTo.MinDate)
                    dpTo.Value = dpTo.MinDate;
                else
                    dpTo.Value = value; 
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateToMax
        {
            get { return dpTo.MaxDate; }
            set { dpTo.MaxDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateToMin
        {
            get { return dpTo.MinDate; }
            set { dpTo.MinDate = value; }
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
        public delegate void DPFromToCalenderDateChanged();

        public event DPFromToCalenderDateChanged FromToDateChanged;

        #endregion Delegates And Events

        public DPFromToCalender()
        {
            InitializeComponent();
        }

        private void SetupDatePicker(DateTimePicker dp,
            DateTime valueDate, DateTime maxDate, DateTime minDate)
        {
            dp.MaxDate = maxDate;
            dp.MinDate = minDate;

            if (valueDate >= minDate && valueDate <= maxDate)
                dp.Value = valueDate;
        }

        private void DPFromToCalender_Load(object sender, EventArgs e)
        {
            DateTime dateNow = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                7, 0, 0
            );

            SetupDatePicker(dpFrom,
                dateNow.AddDays(-1),
                dateNow,
                DateTime.MinValue
            );

            SetupDatePicker(dpTo,
                dateNow,
                dateNow.AddDays(1),
                DateTime.MinValue
            );

            this.formLoaded = true;
            dp_ValueChanged(null, new EventArgs());
        }

        private void dp_ValueChanged(object sender, EventArgs e)
        {
            if (this.formLoaded && this.FromToDateChanged != null)
            {
                this.FromToDateChanged();
            }
        }
    }
}
