using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Tib;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Reports.DRF
{
    public partial class AddEditDRF : Form
    {
        //to get around the unnormalised system.  Hacky but less hacky
        public class EnumValue
        { 
            public int Value {get; private set;}
            public string Name {get; private set;}
            public EnumValue(int val, string name)
            {
                Value = val;
                Name = name;
            }
        }
        public enum DRFWorks
        {
            Primary,
            Secondary,
            Concast
        }
        #region Variables

        private int drfIndex;
        private int tibDelayIndex;
        private bool isEdit;
        private bool emailNewOwner = true;
        private bool hasLoaded = false;
        private bool isDirty = false;
        private bool attemptedSave = false;
        private bool hasErrors = false;
        //private DRFWorks works;
        private string shift;
        private DRFReport drfReport;
        private TIBDelay tibDelay;
        private TIBEvent tibEvent;
        private TodayDate todayInfo;
        private List<DRFLocationLookUp> locationsFull;
        private List<DRFDropDownLookUp> lookUpFull;
        private List<DRFOwner> ownersFull;
        private List<DRFAction> actions;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion Variables

        #region Constructors

        /// <summary>
        /// Constructor for creating a new instance of the AddEditDRF
        /// form for editing/adding a drf report.
        /// </summary>
        /// <param name="drfIndex">The DRF index to edit (Set to
        /// zero to add a new DRF Report).</param>
        /// <param name="tibDelayIndex">The Delay Index that the Report is associated with (set to zero if no delay).</param>
        public AddEditDRF(int drfIndex, int tibDelayIndex)
        {
            InitializeComponent();
            this.drfIndex = drfIndex;
            this.tibDelayIndex = tibDelayIndex;
            dgvActions.AutoGenerateColumns = false;
            if (this.drfIndex > 0)
                this.isEdit = true;
            GetData();
            BindDropDowns();

            if (this.isEdit)
            {
                this.emailNewOwner = false;
                PopulateForm();
            }

            if (this.tibDelay != null && !this.isEdit)//Add New
                PrePopulateFields();

            SetupForm();
            CustomiseColours();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            //Gets a list of all the relevant controls on the form.
            List<Control> controlList = HelperFunctions.GetControlList(this, typeof(GroupBox));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(Panel)));
            controlList.Add(splitter1);
            controlList.Add(splitter2);
            controlList.Add(dgvActions);

            //Loops through all of the controls painting the back
            //and fore colours to the selected user options.
            foreach (Control ctrl in controlList)
            {
                if (ctrl is GroupBox || ctrl is Panel)
                {
                    ctrl.BackColor = Settings.Default.ColourBackground;
                    ctrl.ForeColor = Settings.Default.ColourText;
                }
                if (ctrl is DataGridView)
                {
                    DataGridView dgv = (DataGridView)ctrl;
                    dgv.BackgroundColor = Settings.Default.ColourBackground;
                }
                if (ctrl is Splitter)
                {
                    ctrl.BackColor = Settings.Default.ColourBackground;
                }
            }
        }

        /// <summary>
        /// Sets up the forms variables.
        /// </summary>
        private void SetupForm()
        {
            reportExportViewMenuItem.Enabled = true;
            if (!this.isEdit)//Add
            {
                rbDay.Checked = true;
                this.shift = "DAY";
                if (this.todayInfo.CurrentShift.Trim().ToUpper() == "NIGHT")//Check if it's a night shift
                {
                    rbNight.Checked = true;
                    this.shift = "NIGHT";
                }

                if (cmboRota.Items.Count > 0)
                {
                    cmboRota.SelectedItem = this.todayInfo.CurrentRota.Trim().ToUpper();
                }
                reportExportViewMenuItem.Enabled = false;
            }

            if (this.drfReport != null &&
                this.drfReport.ReportStatus.HasValue &&
                this.drfReport.ReportStatus == 1)//Closed
                OpenCloseReportSetup(false);
            else//Open
                OpenCloseReportSetup(true);

            if (this.isEdit)
            {
                if (this.drfReport != null &&
                    this.drfReport.ReportStatus.HasValue &&
                    this.drfReport.ReportStatus == 0)//Open
                {
                    saveToolStripMenuItem.Visible = true;
                    saveToolStripMenuItem.Enabled = true;
                    saveCloseToolStripMenuItem.Enabled = true;
                }
                else
                {
                    saveCloseToolStripMenuItem.Enabled = false;
                }
                this.Text = "Edit DRF Report";
                pnlAttachActions.Visible = true;
                actionsToolStripMenuItem.Visible = true;
                if (this.drfReport != null)
                {
                    lblLastReview.Visible = true;
                    lblReportStatus.Text = "Report Status - " + GetReportStatus(this.drfReport.ReportStatus);
                    lblLastReview.Text = "Last Review - Not Reviewed";
                    if (this.drfReport.ReviewDate.HasValue)
                    {
                        lblLastReview.Text = "Last Review - " +
                            this.drfReport.ReviewDate.Value.ToString("dd MMM yyyy HH:mm");
                    }
                }
            }

            HideGridviewIfEmpty();

            dtDate.MaxDate = MyDateTime.Now;
            dtTime.MaxDate = MyDateTime.Now;
        }

        /// <summary>
        /// Sets up the report as read only or open depending on status.
        /// </summary>
        /// <param name="open">True for open report, False for closed.</param>
        private void OpenCloseReportSetup(bool open)
        {
            openReportToolStripMenuItem.Enabled = !open;
            closeReportToolStripMenuItem.Enabled = open;
            setAsReviewedToolStripMenuItem.Enabled = open;
            addAttachmentToolStripMenuItem.Enabled = open;
            addActionToolStripMenuItem.Enabled = open;
            if (this.tibDelay != null)
                viewAssociatedTIBDelayToolStripMenuItem.Enabled = true;

            List<Control> controlList = HelperFunctions.GetControlList(this, typeof(TextBox));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(ComboBox)));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(RadioButton)));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(Button)));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(DateTimePicker)));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(NumericUpDown)));

            //Loops through each control stated above, setting up the form
            //depending on certain conditions.
            foreach (Control ctrl in controlList)
            {
                if (ctrl is TextBox)
                {
                    TextBox txtBox = ctrl as TextBox;
                    if (txtBox.Tag != null &&
                        txtBox.Tag.ToString() == "HideMe")
                    {
                        txtBox.Parent.Controls.Remove(txtBox);
                        txtBox.Dispose();
                    }
                    else
                    {
                        txtBox.ReadOnly = !open;
                    }
                }
                else if (ctrl is RadioButton)
                {
                    RadioButton rb = ctrl as RadioButton;
                    if (!open && !rb.Checked)
                        rb.Enabled = false;
                    else
                        rb.Enabled = true;
                }
                else if (ctrl is NumericUpDown)
                {
                    NumericUpDown num = ctrl as NumericUpDown;
                    if (!open)
                    {
                        HideAndReplaceWithTextBox(num);
                    }
                    else
                    {
                        ctrl.Visible = true;
                    }
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cmbo = ctrl as ComboBox;
                    if (!open)
                    {
                        HideAndReplaceWithTextBox(cmbo);
                    }
                    else
                    {
                        ctrl.Visible = true;
                    }
                }
                else if (ctrl is DateTimePicker)
                {
                    DateTimePicker dtPicker = ctrl as DateTimePicker;
                    if (!open)
                    {
                        HideAndReplaceWithTextBox(dtPicker);
                    }
                    else
                    {
                        ctrl.Visible = true;
                    }
                }
                else if (ctrl is Button)
                {
                    ctrl.Enabled = open;
                }
            }
            CheckDeleteAttachmentStatus();
        }

        /// <summary>
        /// Hides the Control and then replace with a read only textbox
        /// </summary>
        /// <param name="ctrl">The control you wish to hide.</param>
        private void HideAndReplaceWithTextBox(Control ctrl)
        {
            TextBox txt = new TextBox();
            txt.Text = ctrl.Text;
            if (ctrl is DateTimePicker)
            {
                DateTimePicker dtPicker = ctrl as DateTimePicker;
                txt.Text = dtPicker.Value.ToString(dtPicker.CustomFormat);
            }

            ctrl.Parent.Controls.Add(txt);
            txt.Location = ctrl.Location;
            txt.Size = ctrl.Size;
            txt.Font = txtInitiator.Font;
            txt.Tag = "HideMe";
            txt.ReadOnly = true;
            ctrl.Visible = false;
        }

        /// <summary>
        /// Gets the text version of the report status.
        /// </summary>
        /// <param name="nullable">The Report Status as a byte.</param>
        /// <returns>The report status as text.</returns>
        private string GetReportStatus(byte? reportStatus)
        {
            if (reportStatus.HasValue)
            {
                if (reportStatus.Value == 0)
                    return "Open";
                else
                    return "Closed";
            }
            return "No Status";
        }

        /// <summary>
        /// Gets all of the data for the form.
        /// </summary>
        private void GetData()
        {
            this.locationsFull = EntityHelper.DRFLocationLookUp.GetAll();
            this.locationsFull.Insert(0,
                    new DRFLocationLookUp()
                    {
                        Works = "Please Select",
                        Location = "Please Select",
                        PlantItem = "Please Select"
                    }
                );

            this.lookUpFull = EntityHelper.DRFDropDownLookUp.GetAll();
            this.lookUpFull.Insert(0,
                    new DRFDropDownLookUp()
                    {
                        DelayType = "Please Select",
                        Discipline = "Please Select",
                        Rota = "Please Select",
                        Shift = "Please Select"
                    }
                );


            if (this.isEdit)
            {
                GetReport();
                GetActions();
            }

            if (drfReport == null)
            {
                this.ownersFull = EntityHelper.DRFOwners.GetAllValidIncluding(string.Empty);
            }
            else
            {
                this.ownersFull = EntityHelper.DRFOwners.GetAllValidIncluding(drfReport.OwnerName);
            }

            this.ownersFull.Insert(0,
                    new DRFOwner()
                    {
                        Works = "Please Select",
                        Owner = "Please Select"
                    }
                );

            if (this.tibDelayIndex > 0)
            {
                this.tibDelay = EntityHelper.TIBDelays.GetSingle(this.tibDelayIndex);
                if (this.tibDelay != null && this.tibDelay.TibIndex > 0)
                {
                    this.tibEvent = EntityHelper.TIBEvents.GetSingle(this.tibDelay.TibIndex);
                }
            }

            this.todayInfo = EntityHelper.GetTodayDate.GetSingle();
        }

        /// <summary>
        /// Gets the Actions seperately from the other Data Function.
        /// </summary>
        private void GetActions()
        {
            this.actions = EntityHelper.DRFActions.GetByIndex(this.drfIndex);
        }

        /// <summary>
        /// Gets the Report seperately from the other Data Function.
        /// </summary>
        private void GetReport()
        {
            this.drfReport = EntityHelper.DRFReport.GetSingle(this.drfIndex);
        }

        /// <summary>
        /// Bind all of the drop downs on the form. Used for initial load.
        /// </summary>
        private void BindDropDowns()
        {
            List<EnumValue> worksDrf = GetEnumAsList(typeof(DRFWorks));
            cmboArea.DataSource = worksDrf.ToList();
            cmboArea.DisplayMember = "Name";
            cmboArea.ValueMember = "Value";

            BindDynamicDropDowns();

            cmboDelayType.DataSource = 
                Enumerable.DistinctBy(this.lookUpFull ,l => l.DelayType)
                .Where(l => l.DelayType != null)
                .Select(s => new { s.DelayType })
                .ToList();
            cmboDelayType.DisplayMember = "DelayType";

            cmboDeptResp.DataSource =
                Enumerable.DistinctBy(this.lookUpFull,l => l.Discipline)
                .Where(l => l.Discipline != null)
                .Select(s => new { s.Discipline })
                .ToList();
            cmboDeptResp.DisplayMember = "Discipline";

            cmboRota.DataSource = 
                Enumerable.DistinctBy(this.lookUpFull,l => l.Rota)
                .Where(l => l.Rota != null && l.Rota != "Please Select")
                .Select(s => new { s.Rota })
                .ToList();
            cmboRota.DisplayMember = "Rota";
        }

        private string GetSelectedWorksArea()
        {
            return Enum.Parse(typeof(DRFWorks), cmboArea.SelectedValue.ToString()).ToString();
        }
        /// <summary>
        /// Binds the area drop down lists to the database values.
        /// </summary>
        private void BindDynamicDropDowns()
        {
            string selectedWorks = GetSelectedWorksArea();

            cmboLocation.DataSource = 
                Enumerable.DistinctBy(this.locationsFull,l => l.Location)
                .Where(l => l.Works == selectedWorks || l.Works == "Please Select")
                .Select(s => new { s.Location })
                .ToList();
            cmboLocation.DisplayMember = "Location";

            cmboOwner.DataSource = this.ownersFull
                .Where(o => o.Works == selectedWorks || o.Works == "Please Select")
                .Select(s => new { s.Owner })
                .ToList();
            cmboOwner.DisplayMember = "Owner";

            BindPlantItems();
        }

        /// <summary>
        /// Specifically bind the plant items drop down list.
        /// Used for updating and filtering of lists.
        /// </summary>
        private void BindPlantItems()
        {
            cmboPlantItem.DataSource = this.locationsFull
                .Where(l => (l.Works == GetSelectedWorksArea() ||
                             l.Works == "Please Select") &&
                            (l.Location == cmboLocation.Text ||
                             l.Location == "Please Select"))
                .Select(s => new { s.PlantItem })
                .ToList();
            cmboPlantItem.DisplayMember = "PlantItem";
        }

        /// <summary>
        /// Fills the form with data if in edit mode.
        /// </summary>
        private void PopulateForm()
        {
            if (this.drfReport != null)
            {
                if (this.drfReport.Shift != null &&
                    this.drfReport.Shift.ToUpper() == "NIGHT")
                    rbNight.Checked = true;

                cmboArea.SelectedIndex = (int)Enum.Parse(typeof(DRFWorks), this.drfReport.Works);
                cmboLocation.SelectedItem = new { this.drfReport.Location };
                cmboPlantItem.SelectedItem = new { this.drfReport.PlantItem };
                cmboDelayType.SelectedItem = new { this.drfReport.DelayType };
                cmboDeptResp.SelectedItem = new { this.drfReport.Discipline };
                cmboOwner.SelectedItem = new { Owner = this.drfReport.OwnerName };
                cmboRota.SelectedItem = new { this.drfReport.Rota };
                txtShortDesc.Text = this.drfReport.ShortDescription;
                txtInitiator.Text = this.drfReport.InitiatorName;
                txtDesc.Text = this.drfReport.Description;
                txtRepair.Text = this.drfReport.ImmediateActions;
                txtRootCause.Text = this.drfReport.RootCause;
                txtCorrective.Text = this.drfReport.CorrectiveMeasure;

                if (this.drfReport.StartDateTime.HasValue)
                {
                    dtDate.Value = this.drfReport.StartDateTime.Value;
                    dtTime.Value = this.drfReport.StartDateTime.Value;
                }
                if (this.drfReport.DelayDuration.HasValue)
                    numDuration.Value = this.drfReport.DelayDuration.Value;

                PopulateAttachments();
                PopulateActions();
            }
        }

        /// <summary>
        /// Sets up the form for adding a DRF Report associated with a TIB Delay.
        /// Adds any values it finds to the form to help with form submission.
        /// </summary>
        private void PrePopulateFields()
        {
            if (this.tibEvent != null)
            {
                if (this.tibEvent.UnitNumber > 10 && this.tibEvent.UnitNumber < 14)
                {
                    cmboArea.SelectedIndex = (int)DRFWorks.Concast;
                }
                cmboLocation.SelectedItem = new { Location =
                    HelperFunctions.GetLocationFromUnitNo(this.tibEvent.UnitNumber)};
                if (this.tibDelay.DelayStart.HasValue)
                {
                    dtDate.Value = this.tibDelay.DelayStart.Value;
                    dtTime.Value = this.tibDelay.DelayStart.Value;
                }
                if (this.tibDelay.DelayDuration.HasValue)
                    numDuration.Value = this.tibDelay.DelayDuration.Value;
            }
        }

        /// <summary>
        /// Fills the Actions Gridview with records if
        /// they exist.
        /// </summary>
        private void PopulateActions()
        {
            if (this.actions != null)
            {
                dgvActions.DataSource = this.actions;
                dgvActions.Refresh();
            }
        }

        /// <summary>
        /// Save existing or add new report.
        /// </summary>
        private bool SaveReport()
        {
            this.attemptedSave = true;
            if (FormValidated())
            {
                this.hasErrors = false;
                this.drfReport = BuildReport();
                try
                {
                    if (this.isEdit)//Save existing report
                    {
                        this.drfReport.DRFIndex = this.drfIndex;
                        EntityHelper.DRFReport.Update(this.drfReport);
                    }
                    else//Add new Report
                    {
                        EntityHelper.DRFReport.AddNew(this.drfReport);
                    }
                }
                catch (Exception ex)
                {
                    string drfIndex = "New Report";
                    if (this.isEdit)
                        drfIndex = drfReport.DRFIndex.ToString();

                    MessageBox.Show(
                        "DRF Report failed to save. This has been logged.",
                        "Save Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.ErrorException("DRF REPORT ERROR -- SaveReport() -- " +
                        "DRF Report Failed to Save -- DRF Index: " + drfIndex + " -- ", ex);
                }

                this.isDirty = false;

                if (this.emailNewOwner)
                {//Email Owner
                    string recipient = GetRecipient();
                    if (recipient != "Error")
                    {
                        var task = ThreadPool.QueueUserWorkItem(s =>
                            CommonMethods.EmailDRFOwner(
                                 "New DRF Report",
                                 this.drfReport.DRFIndex,
                                 this.drfReport.ShortDescription,
                                 recipient)
                            );

                        if (!task)
                        {//if Email Fails, alert the user.
                            MessageBox.Show(
                                "DRF E-Mail notification failed to send.",
                                "E-Mail Notification Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                        }
                    }
                    else
                    {//Record missing e-mail from system.
                        logger.Info(string.Format(
                                "DRF E-MAIL -- The Recipients E-mail was not found -- Works: {0} -- Owner: {1}",
                                this.drfReport.Works, cmboOwner.Text));
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Report failed to save due to validation errors. Please check your input is valid.",
                    "Validation Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            return false;
        }

        /// <summary>
        /// Gets the recipient email from the database.
        /// </summary>
        /// <returns>The Recipients E-Mail Address.</returns>
        private string GetRecipient()
        {
            if (this.drfReport != null)
            {
                DRFOwner owner = EntityHelper.DRFOwners.GetSingle(
                    this.drfReport.Works, cmboOwner.Text);
                if (owner.Email != null)
                {
                    return owner.Email;
                }
            }
            return "Error";//Cannot find
        }

        /// <summary>
        /// Validate user input and flag any bad inputs.
        /// </summary>
        private bool FormValidated()
        {
            bool valid = true;

            List<Control> controlList = HelperFunctions.GetControlList(this, typeof(ComboBox));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(TextBox)));

            foreach (Control ctrl in controlList)
            {
                if (ctrl.Tag != null &&
                    ctrl.Tag.ToString().Contains("Required"))
                {
                    CommonMethods.HighlightControl(ctrl, false);
                    if (ctrl.Text == "Please Select" ||
                        string.IsNullOrWhiteSpace(ctrl.Text))
                    {
                        CommonMethods.HighlightControl(ctrl, true);
                        valid = false;
                    }
                }
            }
            return valid;
        }

        /// <summary>
        /// Builds and returns a new DRF Report from the form.
        /// </summary>
        private DRFReport BuildReport()
        {
            return new DRFReport()
            {
                DateCreated = MyDateTime.Now,
                Works =  GetSelectedWorksArea(),
                Location = cmboLocation.Text,
                PlantItem = cmboPlantItem.Text,
                StartDateTime = GetStartDateTime(),
                DelayDuration = Convert.ToInt16(numDuration.Value),
                InitiatorName = txtInitiator.Text,
                ShortDescription = txtShortDesc.Text,
                Description = txtDesc.Text,
                ImmediateActions = txtRepair.Text,
                RootCause = txtRootCause.Text,
                CorrectiveMeasure = txtCorrective.Text,
                ReportStatus = 0,
                OwnerName = cmboOwner.Text,
                Discipline = cmboDeptResp.Text,
                DelayType = cmboDelayType.Text,
                Year = this.todayInfo.CurrentYear,
                Week = this.todayInfo.CurrentWeek,
                Day = this.todayInfo.CurrentDay,
                Rota = cmboRota.Text,
                Shift = this.shift,
                TIBDelayIndex = this.tibDelayIndex,
                TIBIndex = GetTibIndex()
            };
        }

        /// <summary>
        /// Gets the tib index if one exists. Returns null if
        /// one does not exist.
        /// </summary>
        /// <returns>The Tib Index as a nullable int.</returns>
        private int? GetTibIndex()
        {
            if (this.tibDelay != null && this.tibDelay.TibIndex > 0)
            {
                return this.tibDelay.TibIndex;
            }
            return null;
        }

        /// <summary>
        /// Gets the start date time from the date time pickers
        /// on the form.
        /// </summary>
        /// <returns></returns>
        private DateTime GetStartDateTime()
        {
            return new DateTime(
                dtDate.Value.Year,
                dtDate.Value.Month,
                dtDate.Value.Day,
                dtTime.Value.Hour,
                dtTime.Value.Minute,
                dtTime.Value.Second
                );
        }

        /// <summary>
        /// Opens or Closes a DRF Report.
        /// </summary>
        /// <param name="Open">Open is true, close is false</param>
        private void OpenCloseReport(bool open)
        {
            bool valid = true;
            string status = "Closed";
            if (open)
                status = "Open";
            else
                valid = NoOutstandingActions();

            if (valid)
            {
                DialogResult result = MessageBox.Show(
                    string.Format("Are you sure you wish to change the status of this report to {0}?", status),
                    "Confirmation Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EntityHelper.DRFReport.OpenClose(this.drfReport, open);
                        if (status == "Closed")
                        {//Close window if Closing Report
                            this.DialogResult = DialogResult.OK;
                        }
                        GetReport();
                        SetupForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Failed to change status of the DRF Report. This has been logged.",
                            "Status Change Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                        logger.ErrorException("DRF REPORT ERROR -- OpenCloseReport(" + open + ") -- " +
                            "Failed to change status of the DRF Report -- DRF Index: " +
                            this.drfReport.DRFIndex + " -- ", ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Please complete all outstanding actions before closing the DRF Report.",
                    "Status Change Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            CheckDeleteAttachmentStatus();
        }

        /// <summary>
        /// Method that checks the Actions data gridview to ensure all are
        /// closed off.  Returns true if all actions are closed or false otherwise.
        /// </summary>
        /// <returns>True if all actions are closed or false if any outstanding actions remain.</returns>
        private bool NoOutstandingActions()
        {
            if (dgvActions.Rows != null)
            {
                foreach (DataGridViewRow row in dgvActions.Rows)
                {
                    if (row.DataBoundItem is DRFAction)
                    {
                        DRFAction action = row.DataBoundItem as DRFAction;
                        if (!action.ActionState)
                            return false;//Actions outstanding
                    }
                }
            }
            return true;//No Actions Outstanding
        }

        /// <summary>
        /// Method to get the selected action from the data gridview.
        /// </summary>
        /// <param name="isAdd">If add then return null.</param>
        /// <returns>Action from selected row on data gridview or null if adding a new.</returns>
        private DRFAction GetAction(bool isAdd)
        {
            if (isAdd)
                return null;
            try
            {
                if (dgvActions.SelectedRows.Count > 0 && dgvActions.CurrentRow != null)
                {
                    return dgvActions.CurrentRow.DataBoundItem as DRFAction;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DRF ACTION EDIT ERROR -- GetAction(" + isAdd + ") -- " +
                    "An error occurred when loading the edit DRF Action popup -- ", ex);
            }
            return null;
        }

        /// <summary>
        /// Open the Add/Edit Action form.
        /// </summary>
        /// <param name="isAdd">If true then open the add form, if false open the edit form.</param>
        private void AddEditActionToReport(bool isAdd)
        {
            if (this.drfReport != null && this.drfReport.ReportStatus == 0)
            {
                AddEditAction addAction = new AddEditAction(this.drfReport, GetAction(isAdd));
                DialogResult result = addAction.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GetActions();
                    PopulateActions();
                    SetupForm();
                }
            }
        }

        /// <summary>
        /// Opens the associated tib delay screen.
        /// </summary>
        private void OpenTIBDelay()
        {
            if (this.tibDelay != null)
            {
                using (DelayPopup delayPopup = new DelayPopup(
                    this.tibDelay.TibIndex,
                    this.tibDelay.TibDelayIndex,
                    0,
                    MyDateTime.Now))
                {
                    delayPopup.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the Report Reviewed column to the date time now with
        /// confirmation from user.
        /// </summary>
        private void SetReportAsReviewed()
        {
            DialogResult result = MessageBox.Show(
                string.Format("Are you sure you wish to set this report as reviewed on {0}?",
                    MyDateTime.Now.ToString("dd MMM yyyy HH:mm")),
                "Confirmation Required",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                try
                {
                    EntityHelper.DRFReport.Review(this.drfReport);
                    GetReport();
                    SetupForm();
                    this.isDirty = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Failed to update the Reviewed date. This has been logged.",
                        "Reviewed Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.ErrorException("DRF REPORT ERROR -- SetReportAsReviewed() -- " +
                        "Failed to update the Reviewed date -- DRF Index: " +
                        this.drfReport.DRFIndex + " -- ", ex);
                }
            }
        }

        /// <summary>
        /// Gets all if the files attached to the DRF and displays them in the list view.
        /// </summary>
        private void PopulateAttachments()
        {
            try
            {
                DRFFileOperations io = new DRFFileOperations(drfReport.HasAttachments, drfReport.DRFIndex);
                List<string> fileList = io.GetFileList();
                foreach (string file in fileList)
                {
                    string fileNameOnly = Path.GetFileName(file);
                    ListViewItem fileForList = new ListViewItem(fileNameOnly);
                    lstAttachments.Items.Add(fileForList);
                    lstAttachments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DRF REPORT ERROR -- PopulateAttachments -- Error getting attachments -- ", ex);
            }
        }

        /// <summary>
        /// Gets the String used in the Delete Attachments confirmation
        /// </summary>
        /// <returns>Attachment or Attachments depending on number selected.</returns>
        private string GetAttachmentDeleteText()
        {
            if (lstAttachments.SelectedItems != null &&
                lstAttachments.SelectedItems.Count > 1)
            {
                return "Attachments";
            }
            return "Attachment";
        }

        /// <summary>
        /// Adds an Attachment to the File Server.
        /// </summary>
        /// <param name="fileName">The Filename of the File.</param>
        private void AddAttachment(string fileName)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DRFFileOperations io = new DRFFileOperations(drfReport.HasAttachments, drfReport.DRFIndex);
                if (io.Add(fileName))
                {
                    string pureFileName = Path.GetFileName(fileName);
                    ListViewItem listViewItem = new ListViewItem(pureFileName);
                    lstAttachments.Items.Add(listViewItem);
                    lstAttachments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lstAttachments.Refresh();

                    drfReport.HasAttachments = true;

                    HideGridviewIfEmpty();
                    CheckDeleteAttachmentStatus();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DRF REPORT ERROR -- AddAttachment() -- Error adding attachment -- ", ex);
                MessageBox.Show(
                    string.Format("DRF Report failed to add the attachment '{0}'. This has been logged.", fileName),
                    "Add Attachment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Deletes all the attachments in the lstAttachments list.
        /// </summary>
        private void DeleteAttachments()
        {
            foreach (ListViewItem attachment in lstAttachments.SelectedItems)
            {
                string fileName = attachment.Text;
                try
                {
                    DRFFileOperations drfFileOp = new DRFFileOperations(
                        this.drfReport.HasAttachments,
                        this.drfReport.DRFIndex
                        );
                    drfFileOp.Delete(fileName);

                    lstAttachments.Items.Remove(attachment);
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DRF REPORT ERROR -- DeleteAttachments() -- Error Deleting Attachment -- ", ex);
                    MessageBox.Show(
                        string.Format("DRF Report failed to delete attachment '{0}'. This has been logged.", attachment),
                        "Delete Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }

            if (lstAttachments.Items.Count < 0)
            {
                btnDeleteAttachment.Enabled = false;
                drfReport.HasAttachments = false;
            }
            HideGridviewIfEmpty();
        }

        /// <summary>
        /// Opens an Attachment.
        /// </summary>
        /// <param name="attachmentToView">The attachment name.</param>
        private void ViewAttachment(string attachmentToView)
        {
            try
            {
                DRFFileOperations drfFileOp = new DRFFileOperations(
                    this.drfReport.HasAttachments,
                    this.drfReport.DRFIndex
                    );
                drfFileOp.Open(attachmentToView);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DRF REPORT ERROR -- ViewAttachment() -- Error Viewing Attachment -- ", ex);
                MessageBox.Show(
                    string.Format("DRF Report failed to open attachment '{0}'. This has been logged.", attachmentToView),
                    "Open Attachment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Hides the Bottom Grid and List if they are empty.
        /// </summary>
        private void HideGridviewIfEmpty()
        {
            if (lstAttachments.Items.Count < 1 && dgvActions.Rows.Count < 1)
            {//Hides the Gridview and Listview if they are empty
                pnlAttachActions.Height = 56;
            }
            else
            {
                pnlAttachActions.Height = 142;
            }
        }

        /// <summary>
        /// Enables or disables the delete attachment
        /// button depending on conditions.
        /// </summary>
        private void CheckDeleteAttachmentStatus()
        {
            btnDeleteAttachment.Enabled = false;
            if (lstAttachments.SelectedItems != null &&
                lstAttachments.SelectedItems.Count > 0 &&
                this.drfReport != null && this.drfReport.ReportStatus == 0)
            {
                btnDeleteAttachment.Enabled = true;
            }
        }

        private List<EnumValue> GetEnumAsList(Type t)
        {
            List<EnumValue> returnValue = new List<EnumValue>();
            Array values = Enum.GetValues(t);

            foreach (int value in values)
            {
                string name = Enum.GetName(t, value);
                EnumValue enumVal = new EnumValue(value, name);
                returnValue.Add(enumVal);
            }
            
            return returnValue;
        }

        #region Events
        /// <summary>
        /// Location drop down list event.
        /// </summary>
        private void cmboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPlantItem.Enabled = false;
            cmboPlantItem.Enabled = false;
            if (cmboPlantItem.Items.Count > 0)
                cmboPlantItem.SelectedIndex = 0;

            if (cmboLocation.SelectedIndex > 0)
            {
                lblPlantItem.Enabled = true;
                cmboPlantItem.Enabled = true;
                BindPlantItems();
                if (this.hasLoaded)
                {
                    this.isDirty = true;
                    if (this.attemptedSave)
                    {
                        FormValidated();
                    }
                }
            }
        }

        /// <summary>
        /// Sets up the day/night shift variable.
        /// </summary>
        private void rbShift_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDay.Checked)
                this.shift = "DAY";
            else
                this.shift = "NIGHT";
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void AddEditDRF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Closes window on click.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Save and Close the report event.
        /// </summary>
        private void saveCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        /// <summary>
        /// Save the Report event.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SaveReport();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Textbox text change event.
        /// </summary>
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
                if (this.attemptedSave)
                {
                    FormValidated();
                }
            }
        }

        /// <summary>
        /// Form loaded event. Sets a boolean for use in other parts of the code.
        /// </summary>
        private void AddEditDRF_Load(object sender, EventArgs e)
        {
            this.hasLoaded = true;
        }

        /// <summary>
        /// Combobox index changed event handler.
        /// </summary>
        private void cmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
                this.emailNewOwner = true;
                if (this.attemptedSave)
                {
                    FormValidated();
                }
            }
        }

        /// <summary>
        /// Generic Control event handler.
        /// </summary>
        private void ctrl_ValueChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
        }

        /// <summary>
        /// Save the report, set the status to closed and close the dialog.
        /// </summary>
        private void closeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveReport())
            {
                OpenCloseReport(false);
            }
        }

        /// <summary>
        /// Set Report status to open button click event.
        /// </summary>
        private void openReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCloseReport(true);
        }

        /// <summary>
        /// Set report as reviewed button click event.
        /// </summary>
        private void setAsReviewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetReportAsReviewed();
        }

        /// <summary>
        /// Button click event for adding actions.
        /// </summary>
        private void btnAddAction_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddEditActionToReport(true);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Editing actions through double click on Data gridview
        /// </summary>
        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                AddEditActionToReport(false);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Editing actions through pressing enter on selected row.
        /// </summary>
        private void dgvActions_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                AddEditActionToReport(false);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// If nothing selected then disable the edit button.
        /// Enable if report open and row selected.
        /// </summary>
        private void dgvActions_SelectionChanged(object sender, EventArgs e)
        {
            btnEditAction.Enabled = false;
            if (dgvActions.SelectedRows.Count > 0 && dgvActions.CurrentRow != null &&
                this.drfReport != null && this.drfReport.ReportStatus == 0)
            {
                btnEditAction.Enabled = true;
            }
        }

        /// <summary>
        /// Cancel the form closing event if errors present on form.
        /// </summary>
        private void AddEditDRF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isDirty && !this.hasErrors)
            {
                DialogResult result = MessageBox.Show(
                    "All unsaved changes will be lost. Continue?",
                    "Please Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
            else
            {
                e.Cancel = this.hasErrors;
                this.hasErrors = false;
            }
        }

        /// <summary>
        /// Button edit action click event.
        /// </summary>
        private void btnEditAction_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddEditActionToReport(false);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Resizes the columns and rows on binding.
        /// </summary>
        private void dgvActions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvActions.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dgvActions.AutoResizeColumns();
            dgvActions.AutoResizeRows();
            dgvActions.ClearSelection();

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
            }
        }

        /// <summary>
        /// View associated tib delay menu item event handler
        /// </summary>
        private void viewAssociatedTIBDelayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTIBDelay();
        }

        /// <summary>
        /// Save button click event handler.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (SaveReport())
                this.DialogResult = DialogResult.OK;
            else
                this.hasErrors = true;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the exportable view for the DRF Report.
        /// </summary>
        private void reportExportViewMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DRFReportExport drfExport = new DRFReportExport(this.drfIndex);
            drfExport.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Add a file as an attachment by copying it to the DRF folder and updating the list.
        /// </summary>
        private void btnAddAttach_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                AddAttachment(openFileDialog1.FileName);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens file in default application when double clicked.
        /// </summary>
        private void lstAttachments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (lstAttachments.SelectedItems != null &&
                lstAttachments.SelectedItems.Count == 1)
            {
                ViewAttachment(lstAttachments.SelectedItems[0].Text);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Deletes the selected attachments in the attachment list view.
        /// </summary>
        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (lstAttachments.SelectedItems != null &&
                lstAttachments.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    string.Format("Are you sure you wish to delete the selected {0}?", GetAttachmentDeleteText()),
                    "Delete Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    DeleteAttachments();
                }
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Enables or Disables the Delete button
        /// depending on selection.
        /// </summary>
        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDeleteAttachmentStatus();
        }
        private void cmboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
            
            BindDynamicDropDowns();
        }

        #endregion Events

        #endregion Methods
    }
}