using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.UserControls.HeatDetails
{
    public partial class PlanningDetails : UserControl
    {
        #region Variables
        private int heatNo;
        private int heatNoSet;
        private bool pageError = false;
        private List<CoordLinkFull> allPlans;
        private CoordLinkFull selectedPlan;
        private HeatAimGeneral heatAimGen;

        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public event EventHandler PreviousBtnEnableStateChange;
        public event EventHandler NextBtnEnableStateChange;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NextEnabled { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PreviousEnabled { get; set; }
        #endregion

        #region Constructor
        public PlanningDetails()
        {
            InitializeComponent();
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
            this.heatNo = heatNumber;
            this.heatNoSet = heatNumberSet;

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
                dgvComments.BackgroundColor =
                dgvEvents.BackgroundColor =
                grpPlan.BackColor =
                grpPlanning.BackColor =
                grpHeatDetails.BackColor =
                grpTimes.BackColor =
                        Settings.Default.ColourBackground;

            this.ForeColor =
                grpPlanning.ForeColor =
                grpHeatDetails.ForeColor =
                grpPlan.ForeColor =
                grpPlanning.ForeColor =
                grpHeatDetails.ForeColor =
                grpTimes.ForeColor =
                            Settings.Default.ColourText;
        }

        //Load event of the User Control
        private void PlanningDetails_Load(object sender, EventArgs e)
        {
            dgvComments.ClearSelection();
            dgvEvents.ClearSelection();
        }

        /// <summary>
        /// Get the planning data for a specific heat
        /// </summary>
        /// <returns>True if errored, false otherwise.</returns>
        private bool GetPlanningData()
        {
            this.allPlans = new List<CoordLinkFull>();
            this.selectedPlan = new CoordLinkFull();
            this.heatAimGen = new HeatAimGeneral();
            try
            {
                this.allPlans = EntityHelper.CoordLinkFull.GetByHeat(this.heatNo, this.heatNoSet);
                this.heatAimGen = EntityHelper.HeatAimGeneral.GetByHeat(this.heatNo, this.heatNoSet);
                return false;
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Planning Details -- " +
                    "GetPlanningData(heatNumber = " +
                    heatNo + ")", ex);
            }
            return true;
        }

        /// <summary>
        /// Populate the form with the data gathered.
        /// </summary>
        private void PopulateForm()
        {
            cmboPlanDTs.Enabled = true;
            //Clear Data first.
            ClearTextboxData(tlpHeatDetails);
            ClearTextboxData(tlpPlanTimes);
            dgvComments.Rows.Clear();
            dgvEvents.Rows.Clear();

            if (this.selectedPlan != null && this.selectedPlan.HEAT_NUMBER > 0)
            {
                txtHeatNumber.Text = this.selectedPlan.HEAT_NUMBER.ToString();
                txtProgramNo.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.PROGRAM_NUMBER);
                txtSSUnit.Text = this.selectedPlan.SS_UNIT;
                txtVesselNo.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.VESSEL_NUMBER);
                txtSteelLadleNo.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.STEEL_LADLE_NUMBER);
                txtGrade1.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.GRADE_1);
                txtGrade2.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.GRADE_2);
                txtCasterNo.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.CASTER_NUMBER);
                txtWidth.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.COMBINED_WIDTH);
                if (this.heatAimGen != null)
                {
                    txtIdealCastDuration.Text = HelperFunctions.GetStringFromObjectSafely(
                        this.heatAimGen.CastingTime);
                }
                txtCastDuration.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.CAST_DURATION);
                txtCastTon.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.CASTING_RATE);
                txtCastSpeed.Text = HelperFunctions.GetStringFromObjectSafely(
                    this.selectedPlan.CASTING_SPEED);
                txtPourStart.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_POUR_TIME, -18);
                txtPourEnd.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_POUR_TIME, 0);
                txtDesulphStart.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_END_DESULPH_TIME, -25);
                txtDesulphEnd.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_END_DESULPH_TIME, 0);
                txtVesselStart.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_CHARGE_TIME, 0);
                txtVesselEnd.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_TAP_TIME, 0);
                txtSSStart.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_TAP_TIME, 10);
                txtSSEnd.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_END_SS_TIME, 0);
                txtCasterStart.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_START_CAST_TIME, 0);
                txtCasterEnd.Text = DateTimeExtensions.FormatAndGetDateTime(
                    this.selectedPlan.PLANNED_END_CAST_TIME, 0);

                if (!string.IsNullOrEmpty(this.selectedPlan.COMMENTS))
                    dgvComments.Rows.Add(this.selectedPlan.COMMENTS);

                FillEventDataGrid();
            }
            else
            {
                btnNextPlan.Enabled = false;
                btnPreviousPlan.Enabled = false;
                cmboPlanDTs.Enabled = false;
            }
            dgvComments.ClearSelection();
            dgvEvents.ClearSelection();
        }

        /// <summary>
        /// Public function that controls the forms next plan action.
        /// </summary>
        public void GoToNextPlan()
        {
            if (cmboPlanDTs.SelectedIndex - 1 >= 0)
            {
                cmboPlanDTs.SelectedIndex = cmboPlanDTs.SelectedIndex - 1;
                CheckNavButtons();
            }
        }

        /// <summary>
        /// Public function that controls the forms previous plan action.
        /// </summary>
        public void GoToPreviousPlan()
        {
            if (cmboPlanDTs.SelectedIndex + 1 < cmboPlanDTs.Items.Count)
            {
                cmboPlanDTs.SelectedIndex = cmboPlanDTs.SelectedIndex + 1;
                CheckNavButtons();
            }
        }

        /// <summary>
        /// Method that clears the textboxes within a groupbox.
        /// </summary>
        /// <param name="grpBox">The Group Box to Clear.</param>
        private void ClearTextboxData(TableLayoutPanel table)
        {
            foreach (Control ctrl in table.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Text = "";
                }
            }
        }

        /// <summary>
        /// Populates the Update Time Drop Down List
        /// </summary>
        private void PopulateDropDownList()
        {
            cmboPlanDTs.DataSource = null;
            if (this.allPlans != null && this.allPlans.Count > 0)
            {
                cmboPlanDTs.DataSource = this.allPlans;
                cmboPlanDTs.DisplayMember = "UPDATE_TIME";
                cmboPlanDTs.FormatString = "dd/MM/yyyy HH:mm";
            }
        }

        /// <summary>
        /// Fills the Event Data Grid with data.
        /// </summary>
        private void FillEventDataGrid()
        {
            try
            {
                //Hot Metal
                if (this.selectedPlan.PLANNED_POUR_TIME.HasValue)
                {
                    string duration =
                        ((DateTime)this.selectedPlan.PLANNED_POUR_TIME.Value -
                                   this.selectedPlan.PLANNED_POUR_TIME.Value.AddMinutes(-18))
                            .TotalMinutes.ToString("#0");

                    dgvEvents.Rows.Add("Hot Metal", txtPourStart.Text,
                                        txtPourEnd.Text, duration);
                }
                //Desulph
                if (this.selectedPlan.PLANNED_POUR_TIME.HasValue &&
                    this.selectedPlan.PLANNED_END_DESULPH_TIME.HasValue)
                {
                    string duration =
                        ((DateTime)this.selectedPlan.PLANNED_END_DESULPH_TIME.Value -
                                   this.selectedPlan.PLANNED_END_DESULPH_TIME.Value.AddMinutes(-25))
                            .TotalMinutes.ToString("#0");

                    dgvEvents.Rows.Add("Desulph", txtDesulphStart.Text,
                                        txtDesulphEnd.Text, duration);
                }
                //Vessels
                if (this.selectedPlan.PLANNED_CHARGE_TIME.HasValue &&
                    this.selectedPlan.PLANNED_TAP_TIME.HasValue)
                {
                    string duration =
                        ((DateTime)this.selectedPlan.PLANNED_TAP_TIME.Value -
                                   this.selectedPlan.PLANNED_CHARGE_TIME.Value)
                            .TotalMinutes.ToString("#0");

                    dgvEvents.Rows.Add("Vessel " + this.selectedPlan.VESSEL_NUMBER,
                                        txtVesselStart.Text,
                                        txtVesselEnd.Text, duration);
                }
                //SS
                if (this.selectedPlan.PLANNED_TAP_TIME.HasValue &&
                    this.selectedPlan.PLANNED_END_SS_TIME.HasValue)
                {
                    string duration =
                        ((DateTime)this.selectedPlan.PLANNED_END_SS_TIME.Value -
                                   this.selectedPlan.PLANNED_TAP_TIME.Value.AddMinutes(10))
                            .TotalMinutes.ToString("#0");

                    dgvEvents.Rows.Add(this.selectedPlan.SS_UNIT,
                                        txtSSStart.Text,
                                        txtSSEnd.Text, duration);
                }
                //Caster
                if (this.selectedPlan.PLANNED_START_CAST_TIME.HasValue &&
                    this.selectedPlan.PLANNED_END_CAST_TIME.HasValue)
                {
                    string duration =
                        ((DateTime)this.selectedPlan.PLANNED_END_CAST_TIME.Value -
                                   this.selectedPlan.PLANNED_START_CAST_TIME.Value)
                            .TotalMinutes.ToString("#0");

                    dgvEvents.Rows.Add("Caster " + this.selectedPlan.CASTER_NUMBER,
                                        txtCasterStart.Text,
                                        txtCasterEnd.Text, duration);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR -- PlanningDetails -- FillEventDataGrid() -- ", ex);
            }
        }

        #region Events
        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.pageError = GetPlanningData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.pageError)
            {
                PopulateDropDownList();
                PopulateForm();
            }
            else
            {
                txtHeatNumber.Text = "Error!";
            }
        }

        /// <summary>
        /// Button click event for the next plan button
        /// </summary>
        private void btnNextPlan_Click(object sender, EventArgs e)
        {
            GoToNextPlan();
        }

        /// <summary>
        /// Button click event for the previous plan button
        /// </summary>
        private void btnPreviousPlan_Click(object sender, EventArgs e)
        {
            GoToPreviousPlan();
        }

        /// <summary>
        /// Changes the form to display a different plan.
        /// </summary>
        private void cmboPlanDTs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboPlanDTs.SelectedValue != null)
            {
                this.selectedPlan = (CoordLinkFull)cmboPlanDTs.SelectedValue;
                PopulateForm();
            }
            CheckNavButtons();
        }

        /// <summary>
        /// Checks to see if navigation buttons should be enabled.
        /// </summary>
        private void CheckNavButtons()
        {
            NextEnabled = btnNextPlan.Enabled = false;
            PreviousEnabled = btnPreviousPlan.Enabled = false;

            if (this.allPlans != null && this.allPlans.Count > 0)
            {
                if (this.allPlans.First() != (CoordLinkFull)cmboPlanDTs.SelectedValue)
                {
                    NextEnabled = btnNextPlan.Enabled = true;
                }
                if (this.allPlans.Last() != (CoordLinkFull)cmboPlanDTs.SelectedValue)
                {
                    PreviousEnabled = btnPreviousPlan.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Raises an event every time the enabled state changes 
        /// on the next button.
        /// </summary>
        private void btnNextPlan_EnabledChanged(object sender, EventArgs e)
        {
            if (this.NextBtnEnableStateChange != null)
                this.NextBtnEnableStateChange(btnNextPlan, new EventArgs());
        }

        /// <summary>
        /// Raises an event every time the enabled state changes 
        /// on the previous button.
        /// </summary>
        private void btnPreviousPlan_EnabledChanged(object sender, EventArgs e)
        {
            if (this.PreviousBtnEnableStateChange != null)
                this.PreviousBtnEnableStateChange(btnPreviousPlan, new EventArgs());
        }

        #endregion

        #endregion
    }
}
