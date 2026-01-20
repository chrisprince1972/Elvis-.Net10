using System;
using System.ComponentModel;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    public partial class KeyDetails : UserControl
    {
        private int heatNumber;
        private int heatNumberSet;
        private HMKeyDetails keyDetails;
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public KeyDetails()
        {
            InitializeComponent();
            SetupBackgroundWorker();
            CustomiseColours();
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

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                txtAimSteelS.BackColor =
                txtHMSDirect.BackColor =
                txtHMSTreated.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                txtAimSteelS.ForeColor =
                txtHMSDirect.ForeColor =
                txtHMSTreated.ForeColor =
                    Settings.Default.ColourText;
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
        /// Gets the data for the form.
        /// </summary>
        private void GetData()
        {
            try
            {
                HeatAimAnalysi analysis = EntityHelper.HeatAimAnalysis.GetByHeat(
                    this.heatNumber,
                    this.heatNumberSet
                    );

                HeatAimGeneral general = EntityHelper.HeatAimGeneral.GetByHeat(
                    this.heatNumber,
                    this.heatNumberSet
                    );

                PopulateKeyDetails(analysis, general);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetData() -- KeyDetails.cs -- Error getting data for KeyDetails UC -- ",
                    ex);
            }
        }

        /// <summary>
        /// Populates the HMKeyDetails Class
        /// </summary>
        /// <param name="analysis">The HeatAimAnalysis object.</param>
        /// <param name="general">The HeatAimGeneral Object.</param>
        private void PopulateKeyDetails(HeatAimAnalysi analysis, HeatAimGeneral general)
        {
            this.keyDetails = new HMKeyDetails();

            if (analysis != null)
            {
                this.keyDetails.AimSteelS = analysis.S;
            }
            if (general != null)
            {
                this.keyDetails.MaxHMSDirectCharge = general.MaxHMSNotTreated;
                this.keyDetails.AimHMSTreated = general.MaxHMSTreated;
            }
        }

        /// <summary>
        /// Populates the Form.
        /// </summary>
        private void PopulateForm()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();
            txtAimSteelS.Text = "#";
            txtHMSDirect.Text = "#";
            txtHMSTreated.Text = "#";

            if (this.keyDetails != null)
            {
                PopulateTextBox(this.keyDetails.AimSteelS, txtAimSteelS);
                PopulateTextBox(this.keyDetails.MaxHMSDirectCharge, txtHMSDirect);
                PopulateTextBox(this.keyDetails.AimHMSTreated, txtHMSTreated);
            }
        }

        /// <summary>
        /// Safely populatess the textboxes on the form.
        /// Uses # if data is missing.
        /// </summary>
        /// <param name="value">The nullable float value.</param>
        /// <param name="txtBoxToPopulate">The Textbox to populate.</param>
        private void PopulateTextBox(float? value, TextBox txtBoxToPopulate)
        {
            if (value.HasValue)
            {
                txtBoxToPopulate.Text = value.Value.ToString("0.000");
            }
        }

        #region Events
        /// <summary>
        /// Populates the form once the getting of the data
        /// is complete.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateForm();
        }

        /// <summary>
        /// Get Data run on Seperate Thread.
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }
        #endregion

        #region Supporting Classes
        /// <summary>
        /// Class used to populate this UserControl.
        /// </summary>
        private class HMKeyDetails
        {
            public float? AimSteelS { get; set; }
            public float? MaxHMSDirectCharge { get; set; }
            public float? AimHMSTreated { get; set; }
        }
        #endregion
    }
}
