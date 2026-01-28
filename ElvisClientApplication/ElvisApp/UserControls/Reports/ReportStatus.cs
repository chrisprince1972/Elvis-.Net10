using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Forms;
using Elvis.Common;

namespace Elvis.UserControls
{
    public partial class ReportStatus : UserControl
    {
        #region Variables
        private string reportNo;
        private string area;
        private bool selected;
        private DateTime completedDateTime;
        private bool isDirty;
        #endregion

        #region Constructors
        public ReportStatus(string reportNo, string area)
        {
            InitializeComponent();
            this.reportNo = reportNo;
            this.area = area;
            GetReportStatusInfo();
            SetupControl();
        }
        #endregion

        #region Methods

        #region Setup
        private void SetupControl()
        {
            chbArea.Text = this.area;
            chbArea.Checked = this.selected;
            if (this.selected)
            {
                if (this.completedDateTime != DateTime.MinValue)
                {//Has been completed
                    datePicker.Value = this.completedDateTime.Date;
                    timePicker.Value = new DateTime(this.completedDateTime.Year,
                                                    this.completedDateTime.Month,
                                                    this.completedDateTime.Day,
                                                    this.completedDateTime.Hour,
                                                    this.completedDateTime.Minute,
                                                    this.completedDateTime.Second);
                    btnComplete.Visible = false;
                    datePicker.Enabled = false;
                    timePicker.Enabled = false;
                    chbArea.Enabled = false;
                }
            }
            else
            {//Status has not been selected so blank out the values
                Disable(false);
            }
        }
        private void Enable(DateTime datePickerNew, DateTime timePickerNew)
        {
            btnComplete.Visible = true;
            datePicker.Enabled = true;
            datePicker.Value = datePickerNew;
            datePicker.Format = DateTimePickerFormat.Short;
            timePicker.Enabled = true;
            timePicker.Value = timePickerNew;
            timePicker.Format = DateTimePickerFormat.Time;
        }
        private void Disable(bool complete)
        {
            btnComplete.Visible = false;
            datePicker.Enabled = false;
            timePicker.Enabled = false;

            if (complete)
            {
                chbArea.Enabled = false;
            }
            else
            {
                datePicker.Format = DateTimePickerFormat.Custom;
                datePicker.CustomFormat = " ";
                timePicker.Format = DateTimePickerFormat.Custom;
                timePicker.CustomFormat = " ";
            }
        }
        private void SetDirty()
        {
            ReportSingular reportSingleForm = FormControl.FindParentForm(this.Parent) as ReportSingular;
            if (reportSingleForm != null)
            {
                reportSingleForm.ReportStatusIsDirty = true;
                isDirty = true;
            }
        }
        #endregion

        #region Get Data
        private void GetReportStatusInfo()
        {
            //Populate dtReportStatusInfo with reportID and area
            //if (dtReportStatusInfo != null && dtReportStatusInfo.Rows.Count > 0)
            //{
            //  _selected = true;
            //  if the report status is complete (completed date time has a value?)
            //  then copy the datetime into the completedDateTime
            //      _completedDateTime = column in dtReportStatusInfo
            //
            //}
            //else
            //{
            //  set _completedDateTime to datetime.minvalue
            //  _selected = false;
            //}
        }
        #endregion

        #endregion

        #region Events
        private void btnComplete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you wish to complete this meeting?", 
                "Please Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //TO DO: Store data off in database
                Disable(true);
                if (!isDirty)
                    SetDirty();
            }
        }
        private void chbArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chbArea.Checked)
                Enable(MyDateTime.Now.Date, MyDateTime.Now);
            else
                Disable(false);
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!isDirty)
                SetDirty();
        }
        #endregion
    }
}
