using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class Temperatures : UserControl
    {
        #region Variables
        private int heatNumber;
        private int heatNumberSet;
        private bool pageError = false;
        private List<TempAimsData> aimsData;
        private List<TempDipData> dipData;
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public Temperatures()
        {
            InitializeComponent();
            dgvTempAims.AutoGenerateColumns = false;
            dgvTempData.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            CommonMethods.LoadImageIntoPanel(Resources.loading, this, pnlMain);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlTempsAims.BackColor =
                pnlTemps.BackColor =
                grpTemps.BackColor =
                grpAims.BackColor =
                dgvTempAims.BackgroundColor =
                dgvTempData.BackgroundColor =
                        Settings.Default.ColourBackground;
            this.ForeColor =
                pnlMain.ForeColor =
                pnlTempsAims.ForeColor =
                pnlTemps.ForeColor =
                grpTemps.ForeColor =
                grpAims.ForeColor =
                grpAims.ForeColor =
                grpTemps.ForeColor =
                        Settings.Default.ColourText;
        }

        //Get Temperature Data for gridviews
        private bool GetData()
        {
            this.aimsData = new List<TempAimsData>();
            this.dipData = new List<TempDipData>();

            try
            {
                this.aimsData =
                    EntityHelper.TempAimsData.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetTemperatureData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
                return true;
            }

            try
            {
                this.dipData =
                    EntityHelper.TempDipData.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetTemperatureData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
                return true;
            }
            return false;
        }

        //Populate the Temperature Chart with data
        private void PopulateForm()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();

            try
            {
                if (this.aimsData != null &&
                    this.aimsData.Count > 0)
                {
                    dgvTempAims.DataSource = this.aimsData;
                }

                if (this.dipData != null &&
                    this.dipData.Count > 0)
                {
                    dgvTempData.DataSource = this.dipData;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "TEMP DATA ERROR -- Temperature Data -- PopulateForm() -- ", ex);
            }
            dgvTempAims.ClearSelection();
            dgvTempData.ClearSelection();
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
        }

        #region Events
        //User Control Load Event
        private void TemperatureAims_Load(object sender, EventArgs e)
        {
            dgvTempData.ClearSelection();
            dgvTempAims.ClearSelection();
        }

        //Event that occurs when data is added to DGV. Formats the cells accordingly
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;//Get Gridview
                double cellValue = 0;
                if (e.Value != null &&
                    double.TryParse(e.Value.ToString(), out cellValue))
                {
                    string columnName = dgv.Columns[e.ColumnIndex].Name;

                    if (cellValue == 0)//Remove Value if zero
                    {
                        dgv.Rows[e.RowIndex].Cells[columnName].Value = "";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR -- Temperatures -- dgv_CellFormatting() -- ", ex);
            }
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.pageError = GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.pageError)
            {//No Error
                PopulateForm();
            }
            else
            {
                ShowErrorForm();
            }
        }

        /// <summary>
        /// Clears selection once binding is complete.
        /// </summary>
        private void dgvTempData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTempData.ClearSelection();
        }

        /// <summary>
        /// Clears selection once binding is complete.
        /// </summary>
        private void dgvTempAims_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTempAims.ClearSelection();
        }
        #endregion

        #endregion
    }
}
