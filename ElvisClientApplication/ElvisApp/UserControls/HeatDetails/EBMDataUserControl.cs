using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;
using ElvisDataModel.EDMX;
using Elvis.Common;
using Elvis.Properties;
using Elvis.Model;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class EBMDataUserControl : UserControl
    {
        #region Variables and Properties
        private int heatNumber;
        private int heatNumberSet;
        private int vesselNo;
        private bool pageError = false;
        private EbmDisplay ebmData = new EbmDisplay();
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ColourScheme
        {
            get { return Settings.Default.EBMColourScheme; }
            set
            {
                Colours.FormatEBMGridview(dgvBlowData);
                Colours.FormatEBMGridview(dgvEndBlowData);
                Colours.FormatEBMGridview(dgvChemData);
            }
        }
        #endregion

        #region Constructor and Form Setup
        /// <summary>
        /// Initializes a new instance of the CBM User Control class.
        /// </summary>
        public EBMDataUserControl()
        {
            InitializeComponent();
            dgvBlowData.AutoGenerateColumns = false;
            dgvEndBlowData.AutoGenerateColumns = false;
            dgvChemData.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Form load method, included to allow clearing of selections in dgvBlowData and dgvChemData. Rows are manually
        /// added to the grid so DataBindingComplete method is not suitable for this task.
        /// </summary>
        private void EBMDataUserControl_Load(object sender, EventArgs e)
        {
            dgvBlowData.ClearSelection();
            dgvEndBlowData.ClearSelection();
            dgvChemData.ClearSelection();
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

        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            CommonMethods.LoadImageIntoChildPanel(
                Resources.loadingBlack, grpEBMData, pnlEBMData);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
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
                grpEBMData.BackColor =
                dgvChemData.BackgroundColor =
                dgvBlowData.BackgroundColor =
                dgvEndBlowData.BackgroundColor = 
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                grpEBMData.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If any get datas fail then true, otherwise false.</returns>
        private bool GetData()
        {
            bool hasErrors = false;
            this.ebmData = new EbmDisplay();

            try
            {
                this.ebmData = EntityHelper.EbmDisplay.GetByHeat(this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- EBM TABLE USER CONTROL -- GetData() -- EBM Data -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }
            return hasErrors;
        }

        /// <summary>
        /// Populates the form with the data from the database.
        /// Hides the Loading Screen.
        /// </summary>
        private void PopulateForm()
        {
            //Clear DataGridViews
            if (dgvBlowData.Rows.Count > 0)
                dgvBlowData.Rows.Clear();
            if (dgvEndBlowData.Rows.Count > 0)
                dgvEndBlowData.Rows.Clear();
            if (dgvChemData.Rows.Count > 0)
                dgvChemData.Rows.Clear();

            grpEBMData.Text = "EBM Data - No Data";

            grpEBMData.Controls.Clear();
            grpEBMData.Controls.Add(pnlEBMData);
            pnlEBMData.Visible = true;
            pnlEBMData.Dock = DockStyle.Fill;
            pnlEBMData.BringToFront();

            if (this.ebmData != null)
            {
                BuildBlowData();
                BuildEndBlowData();
                BuildChemData();
                this.vesselNo = GetVesselNumber(this.ebmData);
                if (this.vesselNo > 0)
                    grpEBMData.Text = "EBM Data - Vessel " + this.vesselNo;
                else
                    grpEBMData.Text = "EBM Data - No Vessel Number";
            }

            Colours.FormatEBMGridview(dgvBlowData);
            Colours.FormatEBMGridview(dgvEndBlowData);
            Colours.FormatEBMGridview(dgvChemData);
            dgvBlowData.ClearSelection();
            dgvEndBlowData.ClearSelection();
            dgvChemData.ClearSelection();
        }

        /// <summary>
        /// Converts the Unit Number into a Vessel Number from 
        /// a EBMDisplay object.
        /// </summary>
        /// <param name="ebm">The EBM Display Object to interrogate.</param>
        /// <returns>An int representing the Vessel Number (1 or 2).</returns>
        private int GetVesselNumber(EbmDisplay ebm)
        {
            int unitNumber = ebm.UnitID;
            if (unitNumber == 5) //Vessel 1
                return 1;
            else if (unitNumber == 6) //Vessel 2
                return 2;
            return 0;//Default Value
        }

        /// <summary>
        /// Builds the Blow Data view from the respective heat EBM data.
        /// </summary>
        private void BuildBlowData()
        {
            if (dgvBlowData.Rows.Count > 0)
                dgvBlowData.Rows.Clear();

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvBlowData.Rows.Add(
                            "CBM", this.ebmData.OxygenCbModel,
                            this.ebmData.OreCbModel, this.ebmData.AimTemperature,
                            string.Empty, this.ebmData.AimCarbon,
                            string.Empty);
                        break;
                    case 1:
                        dgvBlowData.Rows.Add(
                            "In Blow", this.ebmData.OxygenAtInBlow,
                            this.ebmData.OreAtInBlow, this.ebmData.InblowTemperature,
                            this.ebmData.InblowTemperatureQC, this.ebmData.InblowCarbon,
                            this.ebmData.InblowCarbonQC);
                        break;
                    case 2:
                        dgvBlowData.Rows.Add(
                            "EBM", this.ebmData.OxygenEbModel,
                            this.ebmData.OreEbModel, this.ebmData.OxygenVolumeToCharge,
                            string.Empty, string.Empty,
                            string.Empty);
                        break;
                    case 3:
                        dgvBlowData.Rows.Add(
                            "Post Blow", this.ebmData.OxygenAtPostBlow,
                            this.ebmData.OreAtPostBlow, string.Empty,
                            this.ebmData.RunoutTimeMins, string.Empty,
                            string.Empty);
                        break;
                    case 4:
                        dgvBlowData.Rows.Add(
                            "Ladle Aim", string.Empty,
                            string.Empty, this.ebmData.LadleAimTemperature,
                            string.Empty, this.ebmData.LadleAimCarbon,
                            string.Empty);
                        break;
                }
            }
        }

        /// <summary>
        /// Builds the End Blow Sublance Data view from the respective heat EBM data.
        /// </summary>
        private void BuildEndBlowData()
        {
            if (dgvEndBlowData.Rows.Count > 0)
                dgvEndBlowData.Rows.Clear();

            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvEndBlowData.Rows.Add(
                            "Temperature",
                            this.ebmData.Pb1Temperature, this.ebmData.Pb1TemperatureQC,
                            this.ebmData.Pb2Temperature, this.ebmData.Pb2TemperatureQC);
                        break;
                    case 1:
                        dgvEndBlowData.Rows.Add(
                            "Oxy Calc",
                            this.ebmData.Pb1OxyActivity, this.ebmData.Pb1OxyActivityQC,
                            this.ebmData.Pb2OxyActivity, this.ebmData.Pb2OxyActivityQC);
                        break;
                    case 2:
                        dgvEndBlowData.Rows.Add(
                            "Calc Carbon",
                            FormatGridviewValue(this.ebmData.Pb1CalculatedCarbon, 3), string.Empty,
                            FormatGridviewValue(this.ebmData.Pb2CalculatedCarbon, 3), string.Empty);
                        break;
                    case 3:
                        dgvEndBlowData.Rows.Add(
                            "Imm Depth",
                            this.ebmData.Pb1ImmersionDepth, this.ebmData.Pb1ImmersionDepthQC,
                            this.ebmData.Pb2ImmersionDepth, this.ebmData.Pb2ImmersionDepthQC);
                        break;
                    case 4:
                        dgvEndBlowData.Rows.Add(
                            "Bath Height",
                            this.ebmData.Pb1BathHeight, string.Empty,
                            this.ebmData.Pb2BathHeight, string.Empty);
                        break;
                }
            }
        }

        /// <summary>
        /// Builds the Chemical Data view from the respective heat EBM data.
        /// </summary>
        private void BuildChemData()
        {
            if (dgvChemData.Rows.Count > 0)
                dgvChemData.Rows.Clear();

            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvChemData.Rows.Add(
                            "Charged HM", this.ebmData.HmCarbon,
                            this.ebmData.HmSilicon, this.ebmData.HmSulphur,
                            this.ebmData.HmPhosphorus, this.ebmData.HmManganese,
                            this.ebmData.HmNitrogen);
                        break;
                    case 1:
                        dgvChemData.Rows.Add(
                            "In Blow Dip", this.ebmData.IbCarbon,
                            this.ebmData.IbSilicon, this.ebmData.IbSulphur,
                            this.ebmData.IbPhosphorus, this.ebmData.IbManganese,
                            this.ebmData.IbNitrogen);
                        break;
                    case 2:
                        dgvChemData.Rows.Add(
                            "1st Post Blow", this.ebmData.Pb1Carbon,
                            this.ebmData.Pb1Silicon, this.ebmData.Pb1Sulphur,
                            this.ebmData.Pb1Phosphorus, this.ebmData.Pb1Manganese,
                            this.ebmData.Pb1Nitrogen);
                        break;
                    case 3:
                        dgvChemData.Rows.Add(
                            "Quick Tap Prediction", this.ebmData.QtCarbon,
                            this.ebmData.QtSilicon, this.ebmData.QtSulphur,
                            this.ebmData.QtPhosphorus, this.ebmData.QtManganese,
                            this.ebmData.QtNitrogen);
                        break;
                    case 4:
                        dgvChemData.Rows.Add(
                            "Tundish Max Spec", this.ebmData.TundishCarbon,
                            this.ebmData.TundishSilicon, this.ebmData.TundishSulphur,
                            this.ebmData.TundishPhosphorus, this.ebmData.TundishManganese,
                            this.ebmData.TundishNitrogen);
                        break;
                }
            }
        }

        /// <summary>
        /// Formats a DataGridview Value from a 
        /// number to x decimal places and returns as a string.
        /// </summary>
        /// <param name="value">The Value you wish to convert.</param>
        /// <param name="decimalPoints">The amount of decimal places to round the number to.</param>
        /// <returns>A formatted value as a string depending on the parameters.</returns>
        private string FormatGridviewValue(object value, int decimalPoints)
        {
            if (value != null)
            {
                double dblValue = 0;
                if (double.TryParse(value.ToString(), out dblValue))
                {
                    return Math.Round(dblValue, decimalPoints).ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoChildPanel(Resources.error, grpEBMData, pnlEBMData);
        }
        #endregion

        #region Events
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
        /// Event that helps with the formatting of the cells.
        /// DataGridviews do not format correctly without this event.
        /// </summary>
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Common.DefaultSettings.DefaultEBMTableCellBackground;
                e.CellStyle.ForeColor = Common.DefaultSettings.DefaultEBMTableCellForeColor;
            }
        }
        #endregion
    }
}
