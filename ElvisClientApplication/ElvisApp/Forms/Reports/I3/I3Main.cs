using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;


namespace Elvis.Forms.Reports.I3
{
    /// <summary>
    /// Created as a solution for Elvis Release 4 WRS: 007360.
    /// </summary>
    public partial class I3Main : Form
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public I3Main()
        {
            InitializeComponent();
            SetupDateSelector();
            InitialDateSetup();
            SetupForm();
            PresentData();
            CustomiseColours();
        }

        #region presentaion
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                dgvReports.BackgroundColor =
                grpFilter.BackColor =
                grpFormat.BackColor =
                grpDateSelector.BackColor =
                grpReports.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                dgvReports.ForeColor =
                grpFilter.ForeColor =
                grpFormat.ForeColor =
                grpDateSelector.ForeColor =
                grpReports.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Enables or disables the date filters depending on the 
        /// radio button selected.
        /// </summary>
        private void SetupDateSelector()
        {
            lblFrom.Enabled = dpFrom.Enabled =
            lblTo.Enabled = dpTo.Enabled =
                rdoDate.Checked;

            lblDay.Enabled = nudDay.Enabled =
            lblWeek.Enabled = nudWeek.Enabled =
            lblYear.Enabled = nudYear.Enabled =
                !rdoDate.Checked;

            lblDay.Enabled = nudDay.Enabled =
                rdoDaily.Checked;
        }

        /// <summary>
        /// Sets the number picker for the year.
        /// </summary>
        private void InitialDateSetup()
        {
            DateTime dt = DateTime.Now.AddDays(-1);

            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            nudDay.Value = (int)dt.DayOfWeek + 1;
            nudWeek.Value = dt.WeekOfYear();
            nudYear.Maximum = nudYear.Value = dt.Year;
            nudYear.Minimum = dt.Year - 5;
            SetupWeekNo();
        }

        /// <summary>
        /// Checks for a week 53 in the currently selected year and 
        /// sets the number picker accordingly.
        /// </summary>
        private void SetupWeekNo()
        {
            if (DateTimeExtensions.IsWeek53Valid(Convert.ToInt16(nudYear.Value)))
                nudWeek.Maximum = 53;
            else
                nudWeek.Maximum = 52;
        }

        /// <summary>
        /// Updates the date text on the form for the group boxes.
        /// </summary>
        private void UpdateDateLabel()
        {
            if (rdoDate.Checked)
            {
                grpDateSelector.Text = "Date Selector";
            }
            else
            {
                DateTime from, to;
                GetTimeRange(out from, out to);
                grpDateSelector.Text = string.Format("Date Selector - {0}", from);
            }
        }

        /// <summary>
        /// Gets the date and time range based on the dates and date type selected.
        /// </summary>
        /// <param name="from">Retruns the start of the time range.</param>
        /// <param name="to">Retruns the end of the time range.</param>
        private void GetTimeRange(out DateTime from, out DateTime to)
        {
            if (rdoDaily.Checked)
            {
                from = ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(nudYear.Value),
                    Convert.ToInt16(nudWeek.Value),
                    Convert.ToInt16(nudDay.Value),
                    07, 00, 00, 00);
                to = from.AddDays(1);
            }
            else if (rdoWeekly.Checked)
            {

                from = ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(nudYear.Value),
                    Convert.ToInt16(nudWeek.Value),
                    1,
                    07, 00, 00, 00);
                to = from.AddDays(7);
            }
            else
            {
                from = Convert.ToDateTime(dpFrom.Value.ToString("yyyy-MM-dd 07:00"));
                to = Convert.ToDateTime(dpTo.Value.ToString("yyyy-MM-dd 07:00"));
            }
        }

        /// <summary>
        /// Method to get the time range and fetch the data within the 
        /// time range and present it to the user.
        /// </summary>
        private void PresentData()
        {
            DateTime from, to;
            GetTimeRange(out from, out to);
            List<I3s> data = GetReportData(from, to);

            lblFromDate.Text = "From - " + from.ToString("dd/MM/yyyy HH:mm");
            lblToDate.Text = "To - " + to.ToString("dd/MM/yyyy HH:mm");

            BindDataGridView(data);
        }

        /// <summary>
        /// Binds the Data Griview and shows the user the dates they selected
        /// using two labels.
        /// </summary>
        private void BindDataGridView(List<I3s> i3Reports)
        {
            dgvReports.DataSource = i3Reports;
            lblRecordsReturned.Text = dgvReports.Rows.Count + " Records Returned";
        }

        /// <summary>
        /// Gets the list of I3 reports based on the time range in the parameters.
        /// </summary>
        /// <param name="from">Start of the time range.</param>
        /// <param name="to">Retruns the end of the time range.</param>
        /// <returns>Returns the list of I3 reports based on the time range 
        /// in the parameters.</returns>
        private List<I3s> GetReportData(DateTime from, DateTime to)
        {
            if (rbBoth.Checked)
            {
                return EntityHelper.I3Report.GetByDateRange(from, to);
            }
            else
            {
                return EntityHelper.I3Report.GetByDateRangeAndCompleted(from, to, rbCompleted.Checked);
            }

        }

        /// <summary>
        /// Sets up the form. Set all the initial values
        /// </summary>
        private void SetupForm()
        {
            dpFrom.MaxDate = DateTime.Now;
            dpTo.MaxDate = DateTime.Now.AddDays(2);
            dpFrom.Value = DateTime.Now.AddMonths(-1).AddDays(1);
            dpTo.Value = DateTime.Now.AddDays(1);
            rdoDaily.Checked = true;
            dgvReports.AutoGenerateColumns = false;
            dgvReports.Visible = true;
        }

        #endregion

        /// <summary>
        /// Opens the selected report when id > 0 for editing. 
        /// <param name="id">Id of the report to open for editing.</param>
        /// </summary>
        private void OpenEditReport(int id)
        {
            if (id > 0 && CommonMethods.AddEditI3(id))
            {
                PresentData();
            }
        }

        /// <summary>
        /// Gets the Id of the report that is selected on the grid view.
        /// </summary>
        /// <returns>Report Id.</returns>
        private int GetSelectedReportId()
        {
            int selectedId = 0;
            if (dgvReports.SelectedRows.Count == 1)
            {
                string selectedIdAsString =
                    dgvReports
                        .SelectedRows[0] // Only one row selected.
                        .Cells[0] // I3 report Id.
                        .Value
                        .ToString();

                if (!int.TryParse(selectedIdAsString, out selectedId))
                {
                    MessageBox.Show(
                        "Failed to identify selected row. This has been logged.",
                        "Edit Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.Error("Failed to identify selected row.");
                }
            }
            else
            {
                MessageBox.Show(
                    "Only one row can be edited at a time.",
                    "Edit Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            return selectedId;
        }

        #region Events
        /// <summary>
        /// Adds a I3 newReport in a new window.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (CommonMethods.AddEditI3(0))
            {
                PresentData();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Edits the selected I3 newReport in a new window.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenEditReport(GetSelectedReportId());
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Button reset event. Sets up the form back to original settings.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            rdoDate.Checked = true;

            InitialDateSetup();
            SetupForm();

            PresentData();
        }

        /// <summary>
        /// Search for reports using the user defined filters.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PresentData();
        }

        /// <summary>
        /// Closes window on click.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Double click on the DataGridView, event handler.
        /// </summary>
        private void dgvReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenEditReport(GetSelectedReportId());
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Key down event for gridview.
        /// </summary>
        private void dgvReports_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                OpenEditReport(GetSelectedReportId());
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Selection changed on the DataGridView event handler.
        /// </summary>
        private void dgvReports_SelectionChanged(object sender, EventArgs e)
        {
            editSelectedToolStripMenuItem.Enabled = false;
            btnEdit.Enabled = false;
            if (dgvReports.SelectedRows.Count > 0 && dgvReports.CurrentRow != null)
            {
                I3s report = dgvReports.CurrentRow.DataBoundItem as I3s;
                if (report != null)
                {
                    editSelectedToolStripMenuItem.Enabled = true;
                    btnEdit.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void I3Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Updates the visual date label in group box on value change.
        /// </summary>
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
        }

        /// <summary>
        /// Sets up week no everytime the year is changed to check for week 53.
        /// </summary>
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            SetupWeekNo();
            UpdateDateLabel();
        }

        /// <summary>
        /// Enables or disables date pickers when changing the 
        /// format radio buttons
        /// </summary>
        private void rbFormat_CheckedChanged(object sender, EventArgs e)
        {
            SetupDateSelector();
            UpdateDateLabel();
        }
        #endregion

    }
}
