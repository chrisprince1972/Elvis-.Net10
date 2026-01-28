using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using Data = ElvisDataModel.EDMX;
using MCRootCause = ElvisDataModel.EntityHelper.MiscastRootCause;

namespace Elvis.Forms.Reports.Miscasts.UserControls
{

    public partial class MiscastReportNew : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private BackgroundWorker worker = new BackgroundWorker();
        private MiscastLookups miscastLookups;
        private Data.MiscastMain miscast;
        private Data.MiscastAction selectedAction;
        private bool dataLoaded;
        private bool dataValid;
        private bool isAdmin;

        /// <summary>
        /// Form Requires Save if True.
        /// False reqpresents no unsaved changes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDirty { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DataValid
        {
            get { return this.dataValid; }
            set
            {
                this.dataValid =
                btnSaveMainSection.Enabled =
                btnSaveTechSection.Enabled = value;
            }
        }

        public MiscastReportNew(bool isAdmin)
        {
            InitializeComponent();
            this.dataLoaded = false;
            this.dataValid = true;
            this.isAdmin = isAdmin;
            dgvActions.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Sets up the background worker control to load data
        /// asynchronously
        /// </summary>
        private void SetupBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }

        private void GetData()
        {
            this.miscastLookups = new MiscastLookups("Please Select");
        }

        public void SetupUserControl(ElvisDataModel.EDMX.MiscastMain miscast)
        {
            this.miscast = miscast;
        }

        private void PopulateForm()
        {
            if (this.miscast != null)
            {
                this.dataLoaded = false;
                PopulateMiscastReportTab();
                PopulateTechnicalTab();
                PopulateActionTab();
                PopulateStatusTab();
                SetupReportByStatus();
                this.dataLoaded = true;
            }
        }

        private void PopulateMiscastReportTab()
        {
            txtHeatNo.Text = this.miscast.HeatNumber.ToString();
            txtOrderedGrade.Text = HelperFunctions.GetStringFromObjectSafely(this.miscast.OrderedGrade);
            txtMadeGrade.Text = HelperFunctions.GetStringFromObjectSafely(this.miscast.MadeGrade);
            cmboFunction.SelectedValue = HelperFunctions.GetIntSafely(this.miscast.MiscastFunctionID);
            txtRota.Text = GetRota();
            chbHotConnect.Checked = this.miscast.HotConnect;
            cmboType.SelectedValue = HelperFunctions.GetIntSafely(this.miscast.MiscastTypeID);
            cmboFailureMode.SelectedValue = HelperFunctions.GetIntSafely(this.miscast.MiscastFailureModeID);
            cmboArea.SelectedValue = HelperFunctions.GetIntSafely(this.miscast.MiscastAreaResponsibleID);
            BindUnitDropDown();//Need to update the Unit Drop Down Items after selecting an Area.
            cmboUnit.SelectedValue = HelperFunctions.GetIntSafely(this.miscast.MiscastUnitID);
            txtProblemStatementName.Text = this.miscast.ProblemStatementName;
            chkInstallationGoodCond.Checked = this.miscast.InstallationGoodCondition;
            cmboAreaStandardPracticeFollowed.SelectedValue = this.miscast.StandardPracticeFollowedID;
            txtProblemStatement.Text = this.miscast.ProblemStatement;
            txtContainmentAction.Text = this.miscast.ContainmentAction;
            txtShiftName.Text = this.miscast.ShiftName;
            txtShiftComments.Text = this.miscast.ShiftComments;
            pnlMainSectionComplete.Visible = this.miscast.ShiftComplete;
            btnCompleteMainSection.Visible = !this.miscast.ShiftComplete;
            PopulateRootCauseAnalysis(this.miscast.MiscastStatusID, 1);
        }

        private void PopulateRootCauseAnalysis(int statusID, int selectedInvestigationNo)
        {
            tabsRCA.TabPages.Clear();
            if (this.miscast.MiscastInvestigations != null)
            {
                bool readOnly = statusID > 1;
                int i = 1;
                foreach (MiscastInvestigation investigation in
                    this.miscast.MiscastInvestigations.OrderBy(m => m.InvestigationNumber))
                {
                    AddInvestigationToTabControl(investigation, i, readOnly, selectedInvestigationNo);
                    i++;
                }
            }
        }

        private void PopulateTechnicalTab()
        {
            MCRootCause.MiscastRootCauseTypes cmboRootCauseVal = MCRootCause.MiscastRootCauseTypes.NotSet;
            if (this.miscast.RootCauseID.HasValue == true && this.miscast.RootCauseID.Value > 0)
            {
                cmboRootCauseVal = (MCRootCause.MiscastRootCauseTypes)this.miscast.RootCauseID.Value;
            }

            cmboRootCause.SelectedValue = (int)cmboRootCauseVal;
            cmboTechName.SelectedValue = HelperFunctions.GetIntSafely(this.miscast.TechNameID);
            txtTechComments.Text = this.miscast.TechComments;
            pnlTechSectionComplete.Visible = this.miscast.TechComplete;
            btnCompleteTechSection.Visible = !this.miscast.TechComplete;
        }

        private void PopulateActionTab()
        {
            if (this.miscast.MiscastActions != null)
            {
                dgvActions.DataSource = this.miscast.MiscastActions;
                dgvActions.Refresh();
            }
        }

        private void PopulateStatusTab()
        {
            SetupReportStatus();
            txtRaisedBy.Text = this.miscast.ProblemStatementName;
            txtTapTime.Text = this.miscast.TapTime.ToString("dd/MM/yy HH:mm:ss");
            txtDateRaised.Text = this.miscast.DateRaised.ToString("dd/MM/yy HH:mm:ss");
            txtLastEdit.Text = this.miscast.LastEdit.ToString("dd/MM/yy HH:mm:ss");
        }

        private string SetupReportStatus()
        {
            try
            {
                MiscastStatu status = this.miscastLookups.Statuses.FirstOrDefault(s =>
                    s.MiscastStatusID == this.miscast.MiscastStatusID
                    );
                if (status != null)
                {
                    txtStatus.Text = status.Status;
                    txtStatus.Tag = status.MiscastStatusID;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error setting up report status for miscast -- SetupReportStatus() -- ",
                    ex);
            }
            return "";
        }

        private void SetupReportByStatus()
        {
            int miscastStatusID = HelperFunctions.GetIntSafely(txtStatus.Tag);

            MiscastReportEditable(false);
            TechnicalEditable(false, miscastStatusID);
            ActionsEditable(false);

            switch (miscastStatusID)
            {
                case 1://Shift Investigation Open
                    MiscastReportEditable(true);
                    TechnicalEditable(true, miscastStatusID);
                    ActionsEditable(true);
                    break;
                case 2://Technical Review Open
                    TechnicalEditable(true, miscastStatusID);
                    ActionsEditable(true);
                    break;
                case 3://Actions Outstanding
                    ActionsEditable(true);
                    break;
            }
        }

        private void MiscastReportEditable(bool state)
        {
            //txtHeatNo.ReadOnly = !state; //HeatNumber is never editable
            txtOrderedGrade.ReadOnly = !state;
            txtMadeGrade.ReadOnly = !state;
            cmboFunction.Enabled = state;
            //Rota is never editable.
            chbHotConnect.Enabled = state;
            chkInstallationGoodCond.Enabled = state;

            cmboType.Enabled = state;
            cmboFailureMode.Enabled = state;
            cmboArea.Enabled = state;
            cmboUnit.Enabled = state;

            txtProblemStatementName.ReadOnly = !state;
            chkInstallationGoodCond.Enabled = state;
            cmboAreaStandardPracticeFollowed.Enabled = state;
            txtProblemStatement.ReadOnly = !state;
            txtContainmentAction.ReadOnly = !state;

            pnlAddInvestigation.Visible = state;
            btnAddInvestigation.Enabled = state;
            btnAddInvestigation.Visible = state;

            txtShiftName.ReadOnly = !state;
            txtShiftComments.ReadOnly = !state;

            pnlMainSectionComplete.Visible = !state;

            if (this.isAdmin)
            {
                btnUnlockMainSection.Visible = !state;
                btnUnlockMainSection.Enabled = !state;
            }

            btnCompleteMainSection.Visible = state;
            btnCompleteMainSection.Enabled = state;

            btnSaveMainSection.Visible = state;
        }

        private void TechnicalEditable(bool state, int statusID)
        {
            cmboRootCause.Enabled = state;
            cmboTechName.Enabled = state;
            txtTechComments.ReadOnly = !state;

            pnlTechSectionComplete.Visible = !state;

            if (this.isAdmin)
            {
                btnUnlockTechSection.Visible = !state;
                btnUnlockTechSection.Enabled = !state;
            }

            btnCompleteTechSection.Visible = state;
            btnCompleteTechSection.Enabled = state;

            btnSaveTechSection.Visible = state;

            if (statusID == 1)//Shift Investigation Open
            {
                btnCompleteTechSection.Visible = false;
                btnCompleteTechSection.Enabled = false;
            }
        }

        private void ActionsEditable(bool state)
        {
            pnlActionsBtns.Visible = state;
            btnAddAction.Enabled = state;
            btnEditAction.Enabled = state;
            dgvActions_SelectionChanged(null, null);
        }

        private string GetRota()
        {
            if (this.miscastLookups.Rotas != null)
            {
                try
                {
                    return this.miscastLookups.Rotas.FirstOrDefault(r => r.RotaID == this.miscast.MiscastRotaID).Rota;
                }
                catch
                {
                    return "#";
                }
            }
            return "";
        }

        private void PopulateDropDowns()
        {
            if (this.miscastLookups != null)
            {
                cmboFunction.DataSource = this.miscastLookups.Functions;
                cmboFunction.DisplayMember = "TrioFunction";
                cmboFunction.ValueMember = "FunctionID";

                cmboType.DataSource = this.miscastLookups.Types;
                cmboType.DisplayMember = "Type";
                cmboType.ValueMember = "MiscastTypeID";

                cmboFailureMode.DataSource = this.miscastLookups.FailureModes;
                cmboFailureMode.DisplayMember = "FailureMode";
                cmboFailureMode.ValueMember = "FailureModeID";

                cmboArea.DataSource = this.miscastLookups.Areas;
                cmboArea.DisplayMember = "AreaResponsible";
                cmboArea.ValueMember = "AreaResponsibleID";

                BindUnitDropDown();

                cmboRootCause.DataSource = this.miscastLookups.RootCauses;
                cmboRootCause.DisplayMember = "RootCause";
                cmboRootCause.ValueMember = "RootCauseID";

                cmboTechName.DataSource = this.miscastLookups.Owners
                    .Where(o => o.IsTechnical)
                    .ToList();
                cmboTechName.DisplayMember = "OwnerName";
                cmboTechName.ValueMember = "MiscastOwnerID";


                cmboAreaStandardPracticeFollowed.DataSource = this.miscastLookups.StandardPracticeFollowed;
                cmboAreaStandardPracticeFollowed.DisplayMember = "Name";
                cmboAreaStandardPracticeFollowed.ValueMember = "Id";
            }
        }

        private void BindUnitDropDown()
        {
            int areaID = HelperFunctions.GetIntSafely(cmboArea.SelectedValue);
            if (areaID != 0 && areaID != 2)//0 is 'Please Select', 2 is 'Not Set'
            {
                cmboUnit.DataSource = this.miscastLookups.Units
                    .Where(u => u.MiscastAreaResponsibleID == areaID)
                    .ToList();
            }
            else
            {
                cmboUnit.DataSource = this.miscastLookups.Units;
            }

            cmboUnit.DisplayMember = "MiscastUnit1";
            cmboUnit.ValueMember = "MiscastUnitID";
        }

        private void AddInvestigation()
        {
            try
            {
                SaveReport();
                MiscastInvestigation investigation = new MiscastInvestigation()
                {
                    MiscastID = this.miscast.MiscastID,
                    InvestigationNumber = GetInvestigationNumber(),
                    AreaResponsibleID = 2
                };

                EntityHelper.MiscastInvestigation.AddNew(investigation);
                this.miscast = EntityHelper.MiscastMain.GetByID(this.miscast.MiscastID);
                if (this.miscast != null)
                {
                    PopulateRootCauseAnalysis(this.miscast.MiscastStatusID, tabsRCA.SelectedIndex + 1);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error adding Investigation to Miscast -- AddInvestiation() -- ",
                    ex);
            }
        }

        /// <summary>
        /// Gets the Investigation No for the new Investigation.
        /// Picks the highest value from the current investigations.
        /// </summary>
        /// <returns></returns>
        private int GetInvestigationNumber()
        {
            TabPage tabPage = tabsRCA.TabPages[tabsRCA.TabCount - 1];
            foreach (Control ctrl in tabPage.Controls)
            {
                if (ctrl is RCAInvestigation)
                {
                    RCAInvestigation ucRCAInvestigation = (RCAInvestigation)ctrl;
                    if (ucRCAInvestigation != null)
                    {
                        return ucRCAInvestigation.InvestigationNumber + 1;
                    }
                }
            }
            return 999;//High number that will order them correctly regardless.
        }

        private void AddInvestigationToTabControl(MiscastInvestigation investigation,
            int investigationNumber, bool readOnly, int selectedInvestigationNo)
        {
            TabPage tabPage = new TabPage("Investigation " + investigationNumber);
            tabPage.AutoScroll = true;
            tabPage.BackColor = SystemColors.ControlLightLight;
            tabPage.Padding = new Padding(3, 3, 4, 3);

            RCAInvestigation rcaInvestigation = new RCAInvestigation(
                investigation,
                this.miscastLookups.Areas,
                readOnly,
                investigationNumber);

            rcaInvestigation.ForceLoad();

            tabPage.Controls.Add(rcaInvestigation);
            rcaInvestigation.Dock = DockStyle.Fill;
            rcaInvestigation.Font = new Font("Tahoma", 8, FontStyle.Regular);
            rcaInvestigation.MiscastInvestigationDeletedEvent += new
                RCAInvestigation.MiscastInvestigationDeletedEventHandler(
                rcaInvestigation_MiscastInvestigationDeletedEvent);
            rcaInvestigation.MiscastInvestigationChangedEvent += new
                RCAInvestigation.MiscastInvestigationChangedEventHandler(
                rcaInvestigation_MiscastInvestigationChangedEvent);
            rcaInvestigation.MiscastWhyAddedEvent += new
                RCAInvestigation.MiscastWhyAddedEventHandler(
                rcaInvestigation_MiscastWhyAddedEvent);

            tabsRCA.TabPages.Add(tabPage);

            if (selectedInvestigationNo == investigationNumber)
            {
                tabsRCA.SelectedTab = tabPage;
            }
        }

        public void SaveReport()
        {
            if (this.DataValid)
            {
                try
                {
                    byte standardPracticeFollowedTypeID = 0;
                    this.miscast.OrderedGrade = GetGrade(txtOrderedGrade.Text);
                    this.miscast.MadeGrade = GetGrade(txtMadeGrade.Text);
                    this.miscast.HotConnect = chbHotConnect.Checked;
                    this.miscast.MiscastTypeID = HelperFunctions.GetIntOrNullSafely(cmboType.SelectedValue);
                    this.miscast.MiscastFailureModeID = HelperFunctions.GetIntOrNullSafely(cmboFailureMode.SelectedValue);
                    this.miscast.MiscastAreaResponsibleID = HelperFunctions.GetIntOrNullSafely(cmboArea.SelectedValue);
                    this.miscast.MiscastUnitID = HelperFunctions.GetIntOrNullSafely(cmboUnit.SelectedValue);
                    this.miscast.MiscastFunctionID = HelperFunctions.GetIntOrNullSafely(cmboFunction.SelectedValue);
                    this.miscast.ProblemStatement = txtProblemStatement.Text;
                    this.miscast.ProblemStatementName = txtProblemStatementName.Text;
                    this.miscast.InstallationGoodCondition = chkInstallationGoodCond.Checked;
                    if (cmboAreaStandardPracticeFollowed.SelectedValue != null 
                        && byte.TryParse(cmboAreaStandardPracticeFollowed.SelectedValue.ToString(), out standardPracticeFollowedTypeID))
                    {
                        this.miscast.StandardPracticeFollowedID = standardPracticeFollowedTypeID;
                    }
                    this.miscast.ContainmentAction = txtContainmentAction.Text;
                    this.miscast.ShiftComments = txtShiftComments.Text;
                    this.miscast.ShiftName = txtShiftName.Text;
                    this.miscast.TechComments = txtTechComments.Text;
                    this.miscast.TechNameID = HelperFunctions.GetIntOrNullSafely(cmboTechName.SelectedValue);
                    this.miscast.RootCauseID = HelperFunctions.GetIntOrNullSafely(cmboRootCause.SelectedValue);
                    this.miscast.LastEdit = MyDateTime.Now;
                    GetMiscastInvestigations();

                    if (EntityHelper.MiscastMain.EditExisting(this.miscast))
                    {
                        UpdateInfoLabels("Save Successful!", true, Color.Green, true);
                        IsDirty = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error updating existing Miscast -- SaveReport() -- ",
                        ex);
                }
                UpdateInfoLabels("Save Failed!", true, Color.Red, false);
            }
        }

        private void GetMiscastInvestigations()
        {
            foreach (TabPage tab in tabsRCA.TabPages)
            {
                foreach (Control ctrl in tab.Controls)
                {
                    if (ctrl is RCAInvestigation)
                    {
                        RCAInvestigation ucRCAInvestigation = (RCAInvestigation)ctrl;
                        ucRCAInvestigation.UpdateValues();
                    }
                }
            }
        }

        private int? GetGrade(string gradeText)
        {
            int grade = 0;
            if (int.TryParse(gradeText, out grade))
            {
                if (grade > 0)
                    return grade;
            }
            return null;
        }

        private void UpdateInfoLabels(string text, bool visible, Color textColour, bool timedVisible)
        {
            lblInfoMain.Text = lblInfoTech.Text = text;
            lblInfoMain.Visible = lblInfoTech.Visible = visible;
            lblInfoMain.ForeColor = lblInfoTech.ForeColor = textColour;

            if (timedVisible)
            {
                timerInfoLabel.Start();
            }
            else
            {
                timerInfoLabel.Stop();
            }
        }

        private void InvalidData(Control ctrl, string nameOfInvalidItem)
        {
            UpdateInfoLabels("Invalid " + nameOfInvalidItem + "!", true, Color.Red, false);
            DataValid = false;
        }

        private void InvalidDataWithHighlight(Control ctrl, string nameOfInvalidItem)
        {
            ctrl.BackColor = Color.Red;
            ctrl.ForeColor = Color.White;
            UpdateInfoLabels("Invalid " + nameOfInvalidItem + "!", true, Color.Red, false);
            DataValid = false;
        }

        private bool ValidateGrade(TextBox tb)
        {
            int gradeValue = 0;
            if (int.TryParse(tb.Text, out gradeValue))
            {
                tb.BackColor = SystemColors.Window;
                tb.ForeColor = SystemColors.WindowText;
                return true;
            }
            else
            {
                InvalidDataWithHighlight(tb, "Grade");
            }
            return false;
        }

        private bool ValidateName(TextBox tb)
        {
            if (tb.Text != string.Empty)
            {
                tb.BackColor = SystemColors.Window;
                tb.ForeColor = SystemColors.WindowText;
                return true;
            }
            else
            {
                InvalidDataWithHighlight(tb, "Problem Statement Name");
            }
            return false;
        }

        private bool ValidateInvestigations()
        {

            string issue = string.Empty;
            foreach (TabPage tab in tabsRCA.TabPages)
            {
                foreach (Control ctrl in tab.Controls)
                {
                    if (ctrl is RCAInvestigation)
                    {
                        RCAInvestigation ucRCAInvestigation = (RCAInvestigation)ctrl;
                        issue += ucRCAInvestigation.ValidateInvestigation();
                    }
                }
            }

            UpdateInfoLabels(issue, true, Color.Red, false);

            return issue == string.Empty;
        }

        private void CheckAllRequiredDataPresentAndValid()
        {
            bool allDataPresentAndValid = true;
            foreach (Control ctrl in pnlMainDetails.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox cmbo = (ComboBox)ctrl;
                    if (cmbo.Text.Equals("Please Select") && cmbo.Tag != null)
                    {
                        InvalidData(cmbo, cmbo.Tag.ToString());
                        allDataPresentAndValid = false;
                    }
                }
            }
            
            if (!ValidateGrade(txtOrderedGrade))
            {
                allDataPresentAndValid = false;
            }

            if (!ValidateGrade(txtMadeGrade))
            {
                allDataPresentAndValid = false;
            }

            if (!ValidateName(txtProblemStatementName))
            {
                allDataPresentAndValid = false;
            }

            allDataPresentAndValid = allDataPresentAndValid && ValidateInvestigations();

            DataValid = allDataPresentAndValid;
        }

        private void UpdateActionsTab()
        {
            dgvActions.DataSource = null;
            try
            {
                dgvActions.DataSource = EntityHelper.MiscastActions
                    .GetByMiscastID(this.miscast.MiscastID);
                dgvActions.Refresh();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "MISCAST ACTION DATA ERROR -- UpdateActionsTab() -- ",
                    ex);
            }
        }

        private void AddAction()
        {
            if (this.miscast != null)
            {
                MiscastAction addAction = new MiscastAction(this.miscast,
                    this.miscastLookups.Owners);

                DialogResult result = addAction.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdateActionsTab();
                }
            }
        }

        private void EditAction()
        {
            if (this.miscast != null && this.selectedAction != null)
            {
                MiscastAction editAction = new MiscastAction(
                    this.miscast,
                    this.miscastLookups.Owners,
                    this.selectedAction
                    );

                DialogResult result = editAction.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdateActionsTab();
                    if (this.miscast.MiscastStatusID == 3 && !OutstandingActions())
                    {//If No Outstanding Actions set status to closed.
                        UpdateMiscastStatus(4);
                    }
                }
            }
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateDropDowns();
            PopulateForm();
        }

        /// <summary>
        /// If nothing selected then disable the edit button.
        /// Enable if report open and row selected.
        /// </summary>
        private void dgvActions_SelectionChanged(object sender, EventArgs e)
        {
            btnEditAction.Enabled = false;
            if (dgvActions.SelectedRows.Count > 0 && dgvActions.CurrentRow != null && this.miscast.MiscastStatusID != 4)
            {
                Data.MiscastAction action =
                    dgvActions.CurrentRow.DataBoundItem as Data.MiscastAction;
                if (action != null)
                {
                    btnEditAction.Enabled = true;
                    this.selectedAction = action;
                }
            }
        }

        /// <summary>
        /// Resizes the columns and rows on binding.
        /// </summary>
        private void dgvActions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvActions.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvActions.AutoResizeColumns();
            dgvActions.AutoResizeRows();
            dgvActions.ClearSelection();

            try
            {
                foreach (DataGridViewRow row in dgvActions.Rows)
                {
                    if (row.Cells["ActionState"].Value != null)
                    {
                        bool complete = Convert.ToBoolean(dgvActions.Rows[row.Index].Cells["ActionState"].Value);
                        if (complete)
                        {
                            dgvActions.Rows[row.Index].Cells["Complete"].Value = Resources.GreenTickSmall;
                        }
                        else
                        {
                            dgvActions.Rows[row.Index].Cells["Complete"].Value = Resources.RedCrossSmall;
                        }
                    }
                    if (row.Cells["OwnerID"].Value != null)
                    {
                        int ownerID = HelperFunctions.GetIntSafely(dgvActions.Rows[row.Index].Cells["OwnerID"].Value);
                        MiscastOwner owner = miscastLookups.Owners.FirstOrDefault(o => o.MiscastOwnerID == ownerID);

                        if (owner != null)
                        {
                            dgvActions.Rows[row.Index].Cells["ActionOwner"].Value = owner.OwnerName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error populating the Actions Gridview on Miscast Report -- ",
                    ex);
            }
            dgvActions_SelectionChanged(null, null);
        }

        /// <summary>
        /// Key down event for gridview
        /// </summary>
        private void dgvActions_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                EditAction();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Find the row clicked and the index of that row and then
        /// display the edit report popup.
        /// </summary>
        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                EditAction();
            }
            this.Cursor = Cursors.Default;
        }

        private void btnAddInvestigation_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddInvestigation();
            this.Cursor = Cursors.Default;
        }

        private void rcaInvestigation_MiscastInvestigationDeletedEvent(int deletedInvestigationID)
        {
            this.Cursor = Cursors.WaitCursor;

            TabPage tabToRemove = new TabPage();
            foreach (TabPage tab in tabsRCA.TabPages)
            {
                foreach (Control ctrl in tab.Controls)
                {
                    if (ctrl is RCAInvestigation)
                    {
                        RCAInvestigation ucRCAInvestigation = (RCAInvestigation)ctrl;
                        if (ucRCAInvestigation != null &&
                            ucRCAInvestigation.InvestigationID == deletedInvestigationID)
                        {
                            tabToRemove = tab;
                        }
                    }
                }
            }
            tabsRCA.TabPages.Remove(tabToRemove);
            UpdateInvestigationOrder();

            this.Cursor = Cursors.Default;
        }

        private void rcaInvestigation_MiscastWhyAddedEvent()
        {
            this.Cursor = Cursors.WaitCursor;
            AddWhy();
            this.Cursor = Cursors.Default;
        }

        private void AddWhy()
        {
            try
            {
                SaveReport();

                this.miscast = EntityHelper.MiscastMain.GetByID(this.miscast.MiscastID);
                if (this.miscast != null)
                {
                    PopulateRootCauseAnalysis(this.miscast.MiscastStatusID, tabsRCA.SelectedIndex + 1);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error adding Why to Miscast -- AddWhy() -- ",
                    ex);
            }
        }

        private void rcaInvestigation_MiscastInvestigationChangedEvent()
        {
            if (this.dataLoaded)
            {
                IsDirty = true;
                UpdateInfoLabels("Unsaved Changes on Report", true, Color.Blue, false);
                CheckAllRequiredDataPresentAndValid();
            }
        }

        private void UpdateInvestigationOrder()
        {
            int i = 1; //Counting the tabs.
            foreach (TabPage tab in tabsRCA.TabPages)
            {
                foreach (Control ctrl in tab.Controls)
                {
                    if (ctrl is RCAInvestigation)
                    {
                        RCAInvestigation ucRCAInvestigation = (RCAInvestigation)ctrl;
                        if (ucRCAInvestigation != null && i != ucRCAInvestigation.TabOrderNumber)
                        {
                            ucRCAInvestigation.TabOrderNumber = i;
                            tab.Text = "Investigation " + i;
                        }
                        i++;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CheckAllRequiredDataPresentAndValid();
            if (DataValid)
            {
                SaveReport();
            }
            this.Cursor = Cursors.Default;
        }

        //private void Grade_Modified(object sender, EventArgs e)
        //{
        //    if (this.dataLoaded && sender is TextBox)
        //    {
        //        IsDirty = true;
        //        UpdateInfoLabels("Unsaved Changes on Report", true, Color.Blue, false);
        //        CheckAllRequiredDataPresentAndValid();
        //    }
        //}

        private void Ctrl_Modified(object sender, EventArgs e)
        {
            if (this.dataLoaded)
            {
                IsDirty = true;
                UpdateInfoLabels("Unsaved Changes on Report", true, Color.Blue, false);
                CheckAllRequiredDataPresentAndValid();
            }
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddAction();
            this.Cursor = Cursors.Default;
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            EditAction();
            this.Cursor = Cursors.Default;
        }

        private void btnCompleteMainSection_Click(object sender, EventArgs e)
        {
            UpdatingMiscastStatus(2, //Technical Review Open
                "Are you sure you wish to complete the Shift Section of this Miscast Report?");
        }

        private void btnCompleteTechSection_Click(object sender, EventArgs e)
        {
            UpdatingMiscastStatus(3, //Actions Outstanding
                "Are you sure you wish to complete the Technical Section of this Miscast Report?");
        }

        private void btnUnlockMainSection_Click(object sender, EventArgs e)
        {
            UpdatingMiscastStatus(1, //Shift Investigation Open
               "Are you sure you wish to reopen the Shift Section of this Miscast Report?");
        }

        private void btnUnlockTechSection_Click(object sender, EventArgs e)
        {
            UpdatingMiscastStatus(2, //Technical Review Open
                "Are you sure you wish to reopen the Technical Section of this Miscast Report?");
        }

        private void UpdatingMiscastStatus(int newStatusID, string confirmText)
        {
            DialogResult result = MessageBox.Show(
                confirmText,
                "Please Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveReport();

                if (newStatusID == 3 && !OutstandingActions())//Actions Outstanding
                {//If No Outstanding Actions set status to closed.
                    newStatusID = 4;
                }

                UpdateMiscastStatus(newStatusID);
            }
        }

        private void UpdateMiscastStatus(int newStatusID)
        {
            try
            {
                if (EntityHelper.MiscastMain.UpdateStatus(this.miscast.MiscastID, newStatusID))
                {
                    this.miscast = EntityHelper.MiscastMain.GetByID(this.miscast.MiscastID);
                    if (this.miscast != null)
                    {
                        PopulateForm();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error updating Miscast Status -- UpdateMiscastStatus() -- ",
                    ex);
                UpdateInfoLabels("Error Updating Status", true, Color.Red, false);
            }
        }

        private bool OutstandingActions()
        {
            foreach (DataGridViewRow row in dgvActions.Rows)
            {
                if (row.Cells["ActionState"].Value != null)
                {
                    if (!(bool)row.Cells["ActionState"].Value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void timerInfoLabel_Tick(object sender, EventArgs e)
        {
            UpdateInfoLabels("", false, Color.Green, false);
            timerInfoLabel.Stop();
        }

        private void cmboArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindUnitDropDown();
        }
    }
}
