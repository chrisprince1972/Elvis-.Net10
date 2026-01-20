using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.UserControls.HeatDetails
{
    public partial class SlabsUserControl : UserControl
    {
        #region Varaiables
        private int heatNumber;
        private int heatNumberSet;
        private bool pageError = false;
        private BackgroundWorker worker = new BackgroundWorker();
        private List<cast_slab_view> slabData = new List<cast_slab_view>();
        private List<SlabFailure> failures = new List<SlabFailure>();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor and Setup
        /// <summary>
        /// Initializes a new instance of the SlabsUserControl User Control class.
        /// </summary>
        public SlabsUserControl()
        {
            InitializeComponent();
            dgvSlabs.AutoGenerateColumns = false;
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
            CommonMethods.LoadImageIntoPanel(Resources.loadingBlack, this, pnlMain);
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
                pnlSlabs.BackColor =
                grpSlabs.BackColor =
                dgvSlabs.BackgroundColor =
                pnlFailures.BackColor =
                grpFailures.BackColor =
                dgvFailures.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlSlabs.ForeColor =
                grpSlabs.ForeColor =
                pnlFailures.ForeColor =
                grpFailures.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If get data fails then true, otherwise false.</returns>
        private bool GetData()
        {
            bool hasErrors = false;

            try
            {
                this.slabData = EntityHelper.CCT_Cast_Slab_View.GetByHeat(this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- SLABS USER CONTROL -- GetData() -- Slab Data -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }

            try
            {
                this.failures = Model.SlabFailures.GetSlabFailures(this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- SLABS USER CONTROL -- GetData() -- Slab Failures -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }

            return hasErrors;
        }

        /// <summary>
        /// Populates the form with the data from the database.
        /// </summary>
        private void PopulateForm()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();

            if (this.slabData != null)
            {
                dgvSlabs.DataSource = this.slabData;
            }

            if (this.failures != null)
            {
                dgvFailures.DataSource = this.failures;
            }
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
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
            {
                PopulateForm();
            }
            else
            {
                ShowErrorForm();
            }
        }

        /// <summary>
        /// Formats the cells of the Data Grid to the correct colours.
        /// </summary>
        private void dgvSlabs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSlabs.Rows != null && dgvSlabs.Rows.Count > 0 &&
                dgvSlabs.ColumnCount > 0 &&
                e.ColumnIndex == 9 &&
                dgvSlabs.Rows[e.RowIndex].Cells["MadeToGrade"] != null)
            {
                var madeToGrade = dgvSlabs.Rows[e.RowIndex].Cells["MadeToGrade"].Value;
                switch (madeToGrade.ToString())
                {
                    case "0":
                        dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.BackColor = Color.Red;
                        dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.ForeColor = Color.White;
                        break;
                    case "2":
                        dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.BackColor = Color.Green;
                        dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.ForeColor = Color.White;
                        break;
                    default:
                        dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.ForeColor = Color.Black;
                        //Need to check which type of row, odd or even because of the alternating row style.
                        if (e.RowIndex % 2 == 0)
                            dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.BackColor = Color.White;
                        else
                            dgvSlabs.Rows[e.RowIndex].Cells["GradeMade"].Style.BackColor = Color.WhiteSmoke;
                        return;
                }
            }
        }

        /// <summary>
        /// Clears selection once binding is complete.
        /// </summary>
        private void dgvSlabs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSlabs.ClearSelection();
        }

        /// <summary>
        /// Clears selection once binding is complete.
        /// </summary>
        private void dgvFailures_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFailures.ClearSelection();
        }
        #endregion
    }
}

