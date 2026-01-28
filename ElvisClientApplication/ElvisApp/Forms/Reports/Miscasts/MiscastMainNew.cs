using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using Elvis.UserControls.DatePickers;
using ElvisDataModel;
using NLog;
using Data = ElvisDataModel.EDMX;
using Elvis.Forms.Reports.Miscasts.UserControls;
using Elvis.Model;

namespace Elvis.Forms.Reports.Miscasts
{
    public partial class MiscastMainNew : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private BackgroundWorker worker = new BackgroundWorker();

        private bool isAdmin;
        private DateTime? initialDate;
        private DateTime? dateTo;
        private List<Tuple<string, string>> comboFilterList;
        private Data.MiscastReportView selectedMiscast;
        private Data.MiscastActionsReportView selectedAction;
        private List<Data.MiscastReportView> miscastReports =
            new List<Data.MiscastReportView>();
        private List<Data.MiscastActionsReportView> miscastActionReports =
            new List<Data.MiscastActionsReportView>();

        public MiscastMainNew(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            SetupBackgroundWorker();
        }

        /// <summary>
        /// Ctor that filters initially on the Miscast Filter Comboboxes.
        /// </summary>
        public MiscastMainNew(List<Tuple<string, string>> comboFilterList, bool isAdmin)
        {
            InitializeComponent();
            this.comboFilterList = comboFilterList;
            this.isAdmin = isAdmin;

            SetupBackgroundWorker();

            if (ucFilters != null)
            {
                ucFilters.MiscastFilterLoadedEvent += new
                    MiscastFilter.MiscastFilterLoaded(ucFilters_MiscastFilterLoadedEvent);
            }
        }

        /// <summary>
        /// Ctor that filters initially on the Miscast Filter Comboboxes
        /// and also the Date Range.
        /// </summary>
        public MiscastMainNew(MiscastFilterHolder filterValues, bool isAdmin)
        {
            InitializeComponent();
            this.initialDate = filterValues.DateFrom;
            this.dateTo = filterValues.DateTo;
            this.comboFilterList = filterValues.ComboFilterList;
            this.isAdmin = isAdmin;

            SetupBackgroundWorker();

            if (ucFilters != null)
            {
                ucFilters.MiscastFilterLoadedEvent += new
                    MiscastFilter.MiscastFilterLoaded(ucFilters_MiscastFilterLoadedEvent);
            }
        }

        /// <summary>
        /// Sets up the background worker with events.
        /// and runs to get the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Form Load event builds up form and gets data.
        /// </summary>
        private void MiscastMainNew_Load(object sender, EventArgs e)
        {
            SetupForm();
            this.rptActionsExport.RefreshReport();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                dgvMiscasts.BackgroundColor =
                grpFilter.BackColor =
                grpMiscasts.BackColor =
                ucDateSelector.BackColor = 
                ucFilters.BackColor = 
                pnlButtons.BackColor = 
                    Settings.Default.ColourBackground;

            this.ForeColor =
                dgvMiscasts.ForeColor =
                grpFilter.ForeColor =
                grpMiscasts.ForeColor =
                ucDateSelector.ForeColor =
                ucFilters.ForeColor =
                pnlButtons.ForeColor = 
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the form.
        /// </summary>
        private void SetupForm()
        {
            dgvMiscasts.AutoGenerateColumns = false;
            dgvActions.AutoGenerateColumns = false;

            btnEditReport.Enabled = 
            btnViewHeatDetails.Enabled =
            viewHeatDetailsStripMenuItem.Enabled =
            editSelectedToolStripMenuItem.Enabled = false;

            InitialDateSetup();
            CustomiseColours();

            if (this.comboFilterList == null)
            {
                if (!this.worker.IsBusy)
                {
                    EnableControls(false);
                    this.worker.RunWorkerAsync();
                }
            }
        }

        //Filter the Comboboxes
        private void InitialFilterSetup()
        {
            if (ucFilters != null &&
                this.comboFilterList != null && this.comboFilterList.Count > 0)
            {
                ucFilters.FilterResultsToGivenValues(this.comboFilterList);
            }
        }

        /// <summary>
        /// Initially sets up the date filters.
        /// </summary>
        private void InitialDateSetup()
        {
            if (this.initialDate != null && this.initialDate.HasValue)
            {
                ucDateSelector.DateFrom = this.initialDate.Value;

                if (this.dateTo != null && this.dateTo.HasValue)
                {
                    ucDateSelector.DateTo = this.dateTo.Value;
                }
            }
            else
            {
                DateTime dateNow = new DateTime(
                    MyDateTime.Now.Year,
                    MyDateTime.Now.Month,
                    MyDateTime.Now.Day,
                    7, 0, 0
                );

                ucDateSelector.DateFrom = dateNow.AddDays(-1);
                ucDateSelector.DateTo = dateNow;
            }
        }

        /// <summary>
        /// Binds the miscast data gridview.
        /// </summary>
        private void BindDataGridView()
        {
            dgvMiscasts.DataSource = null;
            if (this.miscastReports != null)
            {
                dgvMiscasts.DataSource = this.miscastReports;
            }
        }

        /// <summary>
        /// Binds the Actions data to the Actions gridview.
        /// </summary>
        private void BindActionsDataGridView()
        {
            dgvActions.DataSource = null;
            if (this.miscastActionReports != null)
            {
                dgvActions.DataSource = this.miscastActionReports;
            }
        }

        private void UpdateFormLabels(bool filteredByHeat, int heatNumber = 0)
        {
            if (filteredByHeat)
            {
                lblFromDate.Text = "Heat Number: " + heatNumber;
                lblToDate.Text = "";
            }
            else if (ucDateSelector != null)
            {
                lblFromDate.Text = "From - " + ucDateSelector.DateFrom.ToString("dd/MM/yyyy HH:mm");
                lblToDate.Text = "To - " + ucDateSelector.DateTo.ToString("dd/MM/yyyy HH:mm");
            }
            lblRecordsReturned.Text = dgvMiscasts.Rows.Count + " Miscast Records Returned";
        }

        /// <summary>
        /// Binds the Miscast Data ReportView 
        /// </summary>
        private void BindReportView()
        {
            miscastReportViewBindingSource.DataSource = null;
            if (this.miscastReports != null)
            {
                miscastReportViewBindingSource.DataSource = this.miscastReports;
                rptMiscastsExport.RefreshReport();
            }
        }

        /// <summary>
        /// Binds the Actions Data ReportView 
        /// </summary>
        private void BindActionsReportView()
        {
            miscastActionsReportBindingSource.DataSource = null;
            if (this.miscastActionReports != null)
            {
                miscastActionsReportBindingSource.DataSource = this.miscastActionReports;
                rptActionsExport.RefreshReport();
            }
        }

        /// <summary>
        /// Gets the miscast report view data and applies a filter to it.
        /// </summary>
        private List<Data.MiscastReportView> GetMiscastReportData()
        {
            if (ucDateSelector != null && ucFilters != null)
            {
                try
                {
                    return EntityHelper.MiscastReportView.GetByDateAndFilter(
                        ucDateSelector.DateFrom,
                        ucDateSelector.DateTo,
                        ucFilters.Filter);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error getting miscast report view records -- GetMiscastReportData() -- ", ex);
                }
            }
            return new List<Data.MiscastReportView>();
        }

        /// <summary>
        /// Gets the miscast report view data and applies a filter to it.
        /// </summary>
        private List<Data.MiscastActionsReportView> GetMiscastActionsReportData()
        {
            try
            {
                return EntityHelper.MiscastActionsReportView.GetByFilter(
                        ucFilters.Filter,
                        chbShowAll.Checked);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting miscast actions report view records -- GetMiscastActionsReportData() -- ", 
                    ex);
            }
            return new List<Data.MiscastActionsReportView>();
        }

        /// <summary>
        /// Opens the selected miscast report.
        /// </summary>
        /// <param name="miscastID">The ID of the Miscast to Open</param>
        private void ViewMiscastReport(int miscastID)
        {
            if (miscastID > 0)
            {
                using (MiscastReportHolder miscastReport = new MiscastReportHolder(
                    miscastID, this.isAdmin))
                {
                    DialogResult result = miscastReport.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.worker.RunWorkerAsync();
                    }
                }
            }
            else
            {
                logger.Error(
                    "DATA ERROR -- Error loading miscast report -- ViewMiscastReport() -- ");
                MessageBox.Show(
                    "Error opening Miscast Report", 
                    "Report Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Opens the selected Heat Details.
        /// </summary>
        private void ViewHeatDetails()
        {
            if (this.selectedMiscast != null)
            {
                using (HeatDetails heatDetails = new HeatDetails(
                    this.selectedMiscast.HeatNumber, 
                    true, false,
                    this.isAdmin,
                    this.selectedMiscast.HeatNumberSet))
                {
                    heatDetails.ShowDialog();
                }
                this.worker.RunWorkerAsync();
            }
            else
            {
                logger.Error(
                    "DATA ERROR -- Error loading miscast report -- ViewMiscastReport() -- ");
                MessageBox.Show(
                    "Error opening Miscast Report",
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enables or Disables the controls,
        /// depending on the parameter.
        /// </summary>
        /// <param name="enableState">True for enabled, false for disabled.</param>
        private void EnableControls(bool enableState)
        {
            ucDateSelector.Enabled = 
            ucFilters.Enabled =
            btnReset.Enabled =
            btnSearch.Enabled =
            btnAdd.Enabled =
            dgvMiscasts.Enabled = 
            reportExportViewMenuItem.Enabled = 
            addNewReportToolStripMenuItem.Enabled =
            findReportToolStripMenuItem.Enabled = 
            chbShowAll.Enabled = 
            showActionsMenuItem.Enabled = 
            enableState;
        }

        private Data.MiscastReportView GetMiscastByHeat(int heatNumber, int heatNumberSet)
        {
            try
            {
                return EntityHelper.MiscastReportView.GetByHeatNumber(
                    heatNumber,
                    heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting miscast record by Heat -- GetMiscastByHeat() -- ", ex);
            }
            return new Data.MiscastReportView();
        }

        private void PopulateSingleMiscastByHeat(int heatNumber, int heatNumberSet)
        {
            this.miscastReports = new List<Data.MiscastReportView>();
            Data.MiscastReportView miscast = GetMiscastByHeat(heatNumber, heatNumberSet);
            if (miscast != null)
            {
                this.miscastReports.Add(miscast);
            }
            
            BindDataGridView();
            BindReportView();
            UpdateFormLabels(true, heatNumber);
        }

        private void DeleteMiscastReport(Data.MiscastReportView miscastToDelete)
        {
            try
            {
                if (miscastToDelete != null)
                {
                    EntityHelper.MiscastMain.Delete(miscastToDelete.MiscastID);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error deleting miscast report -- ", 
                    ex);
            }
        }

        #region Events
        /// <summary>
        /// Closes window on click.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void MiscastMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Search for reports using the user defined filters.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!this.worker.IsBusy)
            {
                EnableControls(false);
                this.worker.RunWorkerAsync();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Button reset event. Sets up the form back to original settings.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ucFilters.Reset();
            this.initialDate = null;
            this.dateTo = null;
            this.comboFilterList = null;
            SetupForm();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// View the selected Miscast report.
        /// </summary>
        private void btnEditReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.selectedMiscast != null)
            {
                ViewMiscastReport(this.selectedMiscast.MiscastID);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// View the heat details page associated with this report.
        /// </summary>
        private void btnViewHeatDetails_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ViewHeatDetails();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.miscastReports = GetMiscastReportData();
            if (showActionsMenuItem.Checked && this.miscastReports != null)
            {
                this.miscastActionReports = GetMiscastActionsReportData();
            }
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindDataGridView();
            BindReportView();
            BindActionsDataGridView();
            BindActionsReportView();
            UpdateFormLabels(false);
            EnableControls(true);
            dgvMiscasts.ClearSelection();
            dgvActions.ClearSelection();
        }

        /// <summary>
        /// Swaps out the gridview for a report viewer and vice versa, 
        /// depending on the selection.
        /// </summary>
        private void reportExportViewToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvMiscasts.Visible = !reportExportViewMenuItem.Checked;
            rptMiscastsExport.Visible = reportExportViewMenuItem.Checked;

            dgvActions.Visible = !reportExportViewMenuItem.Checked;
            rptActionsExport.Visible = reportExportViewMenuItem.Checked;
            this.Cursor = Cursors.Default;
        }

        private void addNewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (MiscastAddNew addNew = new MiscastAddNew(this.isAdmin))
            {
                DialogResult result = addNew.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    PopulateSingleMiscastByHeat(
                        addNew.HeatNumber,
                        addNew.HeatNumberSet);

                    MiscastReportHolder miscastReport = new MiscastReportHolder(
                        addNew.HeatNumber, addNew.HeatNumberSet, this.isAdmin);
                    miscastReport.Show();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void findReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (MiscastFindByHeat findMiscast = new MiscastFindByHeat())
            {
                DialogResult result = findMiscast.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    PopulateSingleMiscastByHeat(
                        findMiscast.HeatNumber,
                        findMiscast.HeatNumberSet);
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Content Click event for Data Gridview.
        /// Deletes the Row in the gridview + database.
        /// </summary>
        private void dgvMiscasts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.ColumnIndex == 18 && dgvMiscasts.CurrentRow != null)//Delete Column
            {
                Data.MiscastReportView miscast = dgvMiscasts.CurrentRow.DataBoundItem as Data.MiscastReportView;
                if (miscast != null)
                {
                    if (FormControl.ConfirmDeleteRecord("Miscast Report"))
                    {
                        DeleteMiscastReport(miscast);
                        worker.RunWorkerAsync();
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Find the row clicked and the index of that row and then
        /// display the edit report popup.
        /// </summary>
        private void dgvMiscasts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0 && this.selectedMiscast != null)
            {
                ViewMiscastReport(this.selectedMiscast.MiscastID);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Key down event for gridview
        /// </summary>
        private void dgvMiscasts_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (this.selectedMiscast != null)
                {
                    ViewMiscastReport(this.selectedMiscast.MiscastID);
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Selection changed on the DataGridView event handler.
        /// </summary>
        private void dgvMiscasts_SelectionChanged(object sender, EventArgs e)
        {
            editSelectedToolStripMenuItem.Enabled = false;
            btnViewHeatDetails.Enabled = false;
            viewHeatDetailsStripMenuItem.Enabled = false;
            btnEditReport.Enabled = false;

            if (dgvMiscasts.SelectedRows.Count > 0 && dgvMiscasts.CurrentRow != null)
            {
                Data.MiscastReportView report =
                    dgvMiscasts.CurrentRow.DataBoundItem as Data.MiscastReportView;
                if (report != null && btnAdd.Enabled)
                {
                    editSelectedToolStripMenuItem.Enabled = true;
                    btnViewHeatDetails.Enabled = true;
                    viewHeatDetailsStripMenuItem.Enabled = true;
                    btnEditReport.Enabled = true;
                    this.selectedMiscast = report;
                }
            }
        }

        /// <summary>
        /// Resizes the columns and rows on binding.
        /// </summary>
        private void dgvMiscasts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMiscasts != null && ucFilters != null)
            {
                dgvMiscasts.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                dgvMiscasts.AutoResizeColumns();
                dgvMiscasts.AutoResizeRows();
                dgvMiscasts.Columns["DeleteMiscast"].Visible = this.isAdmin;
            }
        }

        private void dgvActions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvActions != null)
            {
                dgvActions.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                dgvActions.AutoResizeColumns();
                dgvActions.AutoResizeRows();

                foreach (DataGridViewRow row in dgvActions.Rows)
                {
                    if (row.Cells["ActionState"].Value != null)
                    {
                        bool complete = Convert.ToBoolean(dgvActions.Rows[row.Index].Cells["ActionState"].Value);
                        if (complete)
                        {
                            dgvActions.Rows[row.Index].Cells["ActionComplete"].Value = Resources.GreenTickSmall;
                        }
                        else
                        {
                            dgvActions.Rows[row.Index].Cells["ActionComplete"].Value = Resources.RedCrossSmall;
                        }
                    }
                }
            }
        }

        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0 && this.selectedAction != null)
            {
                ViewMiscastReport(this.selectedAction.MiscastID);
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvActions_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (this.selectedAction != null)
                {
                    ViewMiscastReport(this.selectedAction.MiscastID);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvActions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActions.SelectedRows.Count > 0 && dgvActions.CurrentRow != null)
            {
                Data.MiscastActionsReportView action =
                    dgvActions.CurrentRow.DataBoundItem as Data.MiscastActionsReportView;
                if (action != null)
                {
                    this.selectedAction = action;
                }
            }
        }

        private void showActionsMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            pnlActionsResults.Visible = showActionsMenuItem.Checked;
            if (!this.worker.IsBusy)
            {
                EnableControls(false);
                this.worker.RunWorkerAsync();
            }
            this.Cursor = Cursors.Default;
        }

        private void chbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!this.worker.IsBusy)
            {
                EnableControls(false);
                this.worker.RunWorkerAsync();
            }
            this.Cursor = Cursors.Default;
        }

        private void ucFilters_MiscastFilterLoadedEvent()
        {
            InitialFilterSetup();
            if (!this.worker.IsBusy)
            {
                EnableControls(false);
                this.worker.RunWorkerAsync();
            }
        }
        #endregion
    }
}
