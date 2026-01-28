using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using NLog;

namespace Elvis.Forms.Reports.NearMiss
{
    public partial class NearMissMain : Form
    {
        #region Variables
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private PictureBox loadingGif;

        private List<string> locations;
        private List<string> rotas;
        private List<string> types;
        private List<string> initiatorsName;
        private List<string> priority;
        private List<string> statuses;
        #endregion

        #region Constructor + Load Event
        /// <summary>
        /// Constructor to initialise an instance of the
        /// NearMiss Main Form.
        /// </summary>
        public NearMissMain()
        {
            InitializeComponent();
            LoadLoadingGif();
            SetupBackgroundWorker();
        }

        /// <summary>
        /// Sets up the loading gif in the filter groupbox.
        /// </summary>
        private void LoadLoadingGif()
        {
            this.loadingGif = new PictureBox();
            this.loadingGif.Image = Resources.loading;
            this.loadingGif.SizeMode = PictureBoxSizeMode.CenterImage;
            grpFilters.Controls.Add(loadingGif);
            loadingGif.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Sets up the background worker with events.
        /// and runs to get the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Form Load event builds up form and gets data.
        /// </summary>
        private void NearMissMain_Load(object sender, EventArgs e)
        {
            SetupForm();
            ShowReportData();
            CustomiseColours();
            this.rptPrintExport.RefreshReport();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                dgvNearMiss.BackgroundColor =
                grpFilter.BackColor =
                grpFilters.BackColor =
                grpNearMiss.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                dgvNearMiss.ForeColor =
                grpFilter.ForeColor =
                grpFilters.ForeColor =
                grpNearMiss.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the form.
        /// </summary>
        private void SetupForm()
        {
            elvisDateTimeRangeSelector.SetupUserControl(MyDateTime.Now.AddDays(-14), MyDateTime.Now);
            elvisDateTimeRangeSelector.SelectPickDate();

            dgvNearMiss.AutoGenerateColumns = false;
            dgvNearMiss.Visible = true;
            rptPrintExport.Visible = false;
        }

        /// <summary>
        /// Build filter for the form.
        /// </summary>
        /// <returns>A filter in type string to be used for the getting of the data.</returns>
        private string GetFilter()
        {
            StringBuilder sbFilter = new StringBuilder();
            
            if (cmboLocation.Items.Count > 0 &&
                cmboLocation.Text != "All")
            {
                sbFilter.AppendFormat("it.Location == \"{0}\"", cmboLocation.Text);
            }
            if (cmboRota.Items.Count > 0 &&
                cmboRota.Text != "All")
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");
                sbFilter.AppendFormat("it.ROTA == \"{0}\"", cmboRota.Text);
            }
            if (cmboType.Items.Count > 0 &&
                cmboType.Text != "All")
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");
                sbFilter.AppendFormat("it.Nearmiss_type  == \"{0}\"", cmboType.Text);
            }
            if (cmboInitiatorsName.Items.Count > 0 &&
                cmboInitiatorsName.Text != "All")
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");
                sbFilter.AppendFormat("it.InitiatorsName == \"{0}\"", cmboInitiatorsName.Text);
            }
            if (cmboPriority.Items.Count > 0 &&
                cmboPriority.Text != "All")
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");
                sbFilter.AppendFormat
                    (
                        "it.Priority == {0}",
                        (int)ElvisDataModel
                        .EntityHelper
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .GetPriorityFromString(cmboPriority.Text));
            }
            if (cmboStatus.Items.Count > 0 &&
                cmboStatus.Text != "All")
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");
                sbFilter.AppendFormat
                    (
                        "it.status == {0}",
                        (int)ElvisDataModel
                        .EntityHelper
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .GetStatusFromString(cmboStatus.Text));
            }

            return sbFilter.ToString();
        }

        /// <summary>
        /// Adds details about the set of records.
        /// </summary>
        private void AddDataDetails()
        {
            lblFromDate.Text = "From - " + elvisDateTimeRangeSelector.From.ToString("dd/MM/yyyy HH:mm");
            lblToDate.Text = "To - " + elvisDateTimeRangeSelector.To.ToString("dd/MM/yyyy HH:mm");
            lblRecordsReturned.Text = dgvNearMiss.Rows.Count + " Records Returned";
        }


        /// <summary>
        /// Gets the nearmiss data and applies a filter to it.
        /// </summary>
        private void ShowReportData()
        {

            List<NearMissRecord> listNearMiss 
                = Model.NearMiss
                .GetNearMiss(elvisDateTimeRangeSelector.From, elvisDateTimeRangeSelector.To, GetFilter())
                .OrderByDescending(m => m.Date)
                .ToList();

            nearmissBindingSource.DataSource = listNearMiss;

            dgvNearMiss.DataSource = listNearMiss;

            AddDataDetails();

            this.rptPrintExport.RefreshReport();
        }

        /// <summary>
        /// Gets the drop down data and populates the combo boxes.
        /// Each has it's own try catch for error handling.
        /// </summary>
        private void GetDropDownData()
        {
            try
            {
                this.locations = EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetAllLocations();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting all locations from nearmiss data table -- ", ex);
            }

            try
            {
                this.rotas = EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetAllRotas();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting all rotas from nearmiss data table -- ", ex);
            }

            try
            {
                this.types = EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetAllTypes();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting all types from nearmiss data table -- ", ex);
            }

            try
            {
                this.priority = EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetAllPriority();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting all priority from nearmiss data table -- ", ex);
            }

            try
            {
                this.initiatorsName = EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetAllInitiatorsName();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting all initiatiors name from nearmiss data table -- ", ex);
            }

            try
            {
                this.statuses = EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetAllStatus();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting all status' from nearmiss data table -- ", ex);
            }
        }

        /// <summary>
        /// Populates the drop down lists safely after the data has been got.
        /// </summary>
        private void PopulateDropDownList()
        {
            CheckInvokeAndPopulate(cmboLocation, this.locations);
            CheckInvokeAndPopulate(cmboRota, this.rotas);
            CheckInvokeAndPopulate(cmboType, this.types);
            CheckInvokeAndPopulate(cmboInitiatorsName, this.initiatorsName);
            CheckInvokeAndPopulate(cmboPriority, this.priority);
            CheckInvokeAndPopulate(cmboStatus, this.statuses);
            pnlDropDowns.Visible = true;
            this.loadingGif.Dispose();
        }

        /// <summary>
        /// Checks to see if the control requires an invoke before populating.
        /// </summary>
        /// <param name="cmbo">The combobox you wish to check.</param>
        /// <param name="listData">The data you wish to populate it with.</param>
        private void CheckInvokeAndPopulate(ComboBox cmbo, List<string> listData)
        {
            try
            {
                if (cmbo.InvokeRequired)
                {
                    cmbo.BeginInvoke((MethodInvoker)delegate()
                    {
                        cmbo.DataSource = listData;
                    });
                }
                else
                {
                    cmbo.DataSource = listData;
                }
            }
            catch (InvalidOperationException iOEx)
            {
                // This can throw if the user cancels the Window display before the thread as
                // called back. 
                // We can quietly ignore this. 
            }
        }

        /// <summary>
        /// Opens the selected nearmiss report.
        /// </summary>
        private void ViewNearMissReport()
        {
            int id = GetSelectedReport();

            if (id > 0)
            {
                using (NearMissSingle nearmissReport = new NearMissSingle(id))
                {
                    nearmissReport.ShowDialog();
                }
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
        private void NearMissMain_KeyDown(object sender, KeyEventArgs e)
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
            ShowReportData();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Button reset event. Sets up the form back to original settings.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ResetFilter();
            ShowReportData();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Button reset event. Sets up the form back to original settings.
        /// </summary>
        private void ResetFilter()
        {
            this.Cursor = Cursors.WaitCursor;

            SetupForm();
            foreach (Control ctrl in pnlDropDowns.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox cmboBox = ctrl as ComboBox;
                    if (cmboBox.Items.Count > 0)
                    {
                        cmboBox.SelectedItem = "All";
                    }
                }
            }
        }

        /// <summary>
        /// Find the row clicked and the index of that row and then
        /// display the edit report popup.
        /// </summary>
        private void dgvNearMiss_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                ViewNearMissReport();
            }
            this.Cursor = Cursors.Default;
        }


        /// <summary>
        /// Key down event for gridview
        /// </summary>
        private void dgvNearMiss_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                ViewNearMissReport();
            }
            this.Cursor = Cursors.Default;
        }

        private int GetSelectedReport()
        {
            int id = 0;
            if (dgvNearMiss.SelectedRows.Count > 0 && dgvNearMiss.CurrentRow != null)
            {
                NearMissRecord report = dgvNearMiss.CurrentRow.DataBoundItem as NearMissRecord;
                if (report != null)
                {
                    editSelectedToolStripMenuItem.Enabled = true;
                    btnViewReport.Enabled = true;

                    id = report.No;
                }
            }

            return id;
        }

        /// <summary>
        /// Selection changed on the DataGridView event handler.
        /// </summary>
        private void dgvNearMiss_SelectionChanged(object sender, EventArgs e)
        {
            if (GetSelectedReport() == 0)
            {
                editSelectedToolStripMenuItem.Enabled = false;
                btnViewReport.Enabled = false;
            }
        }

        /// <summary>
        /// View the selected NearMiss report.
        /// </summary>
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ViewNearMissReport();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetDropDownData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateDropDownList();
        }

        /// <summary>
        /// Swaps out the gridview for a report viewer and vice versa, 
        /// depending on the selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportExportViewToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvNearMiss.Visible = !reportExportViewMenuItem.Checked;
            rptPrintExport.Visible = reportExportViewMenuItem.Checked;
            this.Cursor = Cursors.Default;
        }

        #endregion
        #endregion
    }
}
