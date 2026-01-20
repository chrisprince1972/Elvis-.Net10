using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System.Drawing;
using Elvis.Common;

namespace Elvis.Forms.UserConfiguration
{
    public partial class AddEditTIBReason : Form
    {
        #region Variables
        public TIBReason newTIBReason;
        private bool hasErrors = false;
        private TIBReason tibReport;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private enum Mode { Edit, New };
        private int incomingIndexNo;
        private Mode formMode;
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor called when the form is displayed without any TIBReason data. Sets the formMode value to New, so later
        /// methods execute the correct EntityHelper methods.
        /// </summary>
        public AddEditTIBReason()
        {
            InitializeComponent();
            formMode = Mode.New;
            CustomiseColours();
        }

        /// <summary>
        /// Overloaded form load
        /// </summary>
        /// <param name=IndexNo>The DelayIndex you wish to apply to the data.</param>
        public AddEditTIBReason(int indexNo)
        {
            InitializeComponent();
            this.Text = "Edit TIB Reason";
            incomingIndexNo = indexNo;
            formMode = Mode.Edit;
            CustomiseColours();
        }
        #endregion

        #region Events
        /// <summary>
        /// Methods called when form loads.
        /// </summary>
        private void AddReason_Load(object sender, EventArgs e)
        {
            BuildDropDowns();
            GetReportData(incomingIndexNo);
            BindDataToForm();
            SetUpButtons();
        }

        /// <summary>
        /// Save button click event handler.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!string.IsNullOrWhiteSpace(txtDelayIndex.Text))
            {
                MakeChanges();
            }
            else
            {
                this.hasErrors = true;
                MessageBox.Show(
                    "Please enter a valid delay index.",
                    "Delay Index Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Cancel button click event handler.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Delete button click event handler.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTIBReason();
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
                grpTIBReason.BackColor =
                pnlReason.BackColor =
                grpReason.BackColor =
                pnlGeneral.BackColor =
                grpGeneral.BackColor =
                pnlFloc.BackColor =
                grpFloc.BackColor =
                pnlButtons.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                grpTIBReason.ForeColor =
                pnlReason.ForeColor =
                grpReason.ForeColor =
                pnlGeneral.ForeColor =
                grpGeneral.ForeColor =
                pnlFloc.ForeColor =
                grpFloc.ForeColor =
                pnlButtons.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Controlling method which calls the split out methods for building each form drop down. Put in place to try
        /// and neaten up the code as there are lots of dropddowns on the form.
        /// </summary>
        private void BuildDropDowns()
        {
            BuildReasonDropDowns();
            BuildDelayReasonsDropDowns();
            BuildReportingDropDowns();
            BuildObjectDropDowns();
            BuildMiscDropDowns();
            BuildDamageDropDowns();
        }

        /// <summary>
        /// Builds drop downs in the Reason group box, where a data source is used not a list of strings.
        /// </summary>
        private void BuildReasonDropDowns()
        {
            cboUnitGroup.DataSource = System.Linq.Enumerable.DistinctBy(EntityHelper.Units.GetAll(), u => u.UnitGroupNumber)
                .OrderBy(u => u.UnitGroupText)
                .ToList();
            cboUnitGroup.DisplayMember = "UnitGroupText";
            cboUnitGroup.ValueMember = "UnitGroupNumber";

            cboDelayClass.DataSource = EntityHelper.TibClassLookUp.GetAll().OrderBy(c => c.TIBClassText).ToList();
            cboDelayClass.DisplayMember = "TIBClassText";
            cboDelayClass.ValueMember = "TIBClassIndex";

            cboCategory.DataSource = EntityHelper.TibCategoryLookUp.GetAll().OrderBy(c => c.TIBCategoryText).ToList();
            cboCategory.DisplayMember = "TIBCategoryText";
            cboCategory.ValueMember = "TIBCategoryIndex";

            cboDiscipline.DataSource = EntityHelper.TibDisciplineLookUp.GetAll().OrderBy(d => d.TIBDisText).ToList();
            cboDiscipline.DisplayMember = "TIBDisText";
            cboDiscipline.ValueMember = "TIBDisIndex";
        }

        /// <summary>
        /// Builds DelayReason drop downs, using a list of strings derived from getting Distinct values from each DelayReason field.
        /// </summary>
        private void BuildDelayReasonsDropDowns()
        {
            cboDelayReason1.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DelayReason1").Where(a => a.DelayReason1 != null),
                        d => d.DelayReason1)
                    .OrderBy(o => o.DelayReason1)
                    .Select(p => p.DelayReason1)
                    .ToList()
                    .ToArray());

            cboDelayReason2.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DelayReason2").Where(a => a.DelayReason2 != null),
                        d => d.DelayReason2)
                    .OrderBy(o => o.DelayReason2)
                    .Select(p => p.DelayReason2)
                    .ToList()
                    .ToArray());

            cboDelayReason3.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DelayReason3").Where(a => a.DelayReason3 != null),
                        d => d.DelayReason3)
                    .OrderBy(o => o.DelayReason3)
                    .Select(p => p.DelayReason3)
                    .ToList()
                    .ToArray());

            cboDelayReason4.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DelayReason4").Where(a => a.DelayReason4 != null),
                        d => d.DelayReason4)
                    .OrderBy(o => o.DelayReason4)
                    .Select(p => p.DelayReason4)
                    .ToList()
                    .ToArray());
        }

        /// <summary>
        /// Builds ReportingText reason drop downs, using a list of strings derived from getting Distinct values from each ReportingText field.
        /// </summary>
        private void BuildReportingDropDowns()
        {
            cboReportingTextLevel1.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.ReportingTextLevel1").Where(r => r.ReportingTextLevel1 != null),
                        r => r.ReportingTextLevel1)
                    .OrderBy(r => r.ReportingTextLevel1)
                    .Select(r => r.ReportingTextLevel1)
                    .ToList()
                    .ToArray());

            cboReportingTextLevel2.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.ReportingTextLevel2").Where(r => r.ReportingTextLevel2 != null),
                        r => r.ReportingTextLevel2)
                    .OrderBy(r => r.ReportingTextLevel2)
                    .Select(r => r.ReportingTextLevel2)
                    .ToList()
                    .ToArray());
        }

        /// <summary>
        /// Builds Object related drop downs, using a list of strings derived from getting Distinct values from each Object related field.
        /// </summary>
        private void BuildObjectDropDowns()
        {
            cboObjectDescription.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.ObjectDescription").Where(r => r.ObjectDescription != null),
                        r => r.ObjectDescription)
                    .OrderBy(r => r.ObjectDescription)
                    .Select(r => r.ObjectDescription)
                    .ToList()
                    .ToArray());

            cboObjectCode.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.ObjectCode").Where(r => r.ObjectCode != null),
                        r => r.ObjectCode)
                    .OrderBy(r => r.ObjectCode)
                    .Select(r => r.ObjectCode)
                    .ToList()
                    .ToArray());
        }

        /// <summary>
        /// Builds Damage related drop downs, using a list of strings derived from getting Distinct values from each Damage related field.
        /// </summary>
        private void BuildDamageDropDowns()
        {
            cboDamageDescription.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DamageDescription").Where(r => r.DamageDescription != null),
                        r => r.DamageDescription)
                    .OrderBy(r => r.DamageDescription)
                    .Select(r => r.DamageDescription)
                    .ToList()
                    .ToArray());

            cboDamageCode.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DamageCode").Where(r => r.DamageCode != null),
                        r => r.DamageCode)
                    .OrderBy(r => r.DamageCode)
                    .Select(r => r.DamageCode)
                    .ToList()
                    .ToArray());
        }

        /// <summary>
        /// Builds the rest of the drop downs, using a list of strings derived from getting Distinct values from each respective field.
        /// </summary>
        private void BuildMiscDropDowns()
        {
            cboOEECategory.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.OEECategory").Where(r => r.OEECategory != null),
                        r => r.OEECategory)
                    .OrderBy(r => r.OEECategory)
                    .Select(r => r.OEECategory)
                    .ToList()
                    .ToArray());

            cboLossType.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.LossType").Where(r => r.LossType != null),
                        r => r.LossType)
                    .OrderBy(r => r.LossType)
                    .Select(r => r.LossType)
                    .ToList()
                    .ToArray());

            cboOwner.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.Owner").Where(r => r.Owner != null),
                        r => r.Owner)
                    .OrderBy(r => r.Owner)
                    .Select(r => r.Owner)
                    .ToList()
                    .ToArray());

            cboDeviationType.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.DeviationType").Where(r => r.DeviationType != null),
                        r => r.DeviationType)
                    .OrderBy(r => r.DeviationType)
                    .Select(r => r.DeviationType)
                    .ToList()
                    .ToArray());

            cboCauseText.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.CauseText").Where(r => r.CauseText != null),
                        r => r.CauseText)
                    .OrderBy(r => r.CauseText)
                    .Select(r => r.CauseText)
                    .ToList()
                    .ToArray());

            cboSection.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.Section").Where(r => r.Section != null),
                        r => r.Section)
                    .OrderBy(r => r.Section)
                    .Select(r => r.Section)
                    .ToList()
                    .ToArray());

            cboExternalInternal.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.ExternalInternal").Where(r => r.ExternalInternal != null),
                        r => r.ExternalInternal)
                    .OrderBy(r => r.ExternalInternal)
                    .Select(r => r.ExternalInternal)
                    .ToList()
                    .ToArray());

            cboSupplierDownStream.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.SupplierDownStream").Where(r => r.SupplierDownStream != null),
                        r => r.SupplierDownStream)
                    .OrderBy(r => r.SupplierDownStream)
                    .Select(r => r.SupplierDownStream)
                    .ToList()
                    .ToArray());

            cboNoExtraWork.Items.AddRange(
                System.Linq.Enumerable.DistinctBy(
                        EntityHelper.TIBReasons.GetColumnData("it.NoExtraWork").Where(r => r.NoExtraWork != null),
                        r => r.NoExtraWork)
                    .OrderBy(r => r.NoExtraWork)
                    .Select(r => r.NoExtraWork)
                    .ToList()
                    .ToArray());
        }

        /// <summary>
        /// Sets the status of buttons on the form dependent on the value in the variable formMode.
        /// </summary>
        private void SetUpButtons()
        {
            if (formMode == Mode.New)
            {
                btnDelete.Enabled = false;
            }
        }

        /// <summary>
        /// Gets the report data for the form.
        /// </summary>
        /// <param name="filter">The TIB ReasonIndex value passed in from a calling form.</param>
        private void GetReportData(int index)
        {
            try
            {
                this.tibReport = EntityHelper.TIBReasons.GetByIndex(index);
            }
            catch (Exception ex)
            {
                logger.ErrorException("TIB REASON ERROR -- GetReportData() -- " +
                        "TIB Report Failed to Save -- ReasonIndex: " + index + " -- ", ex);
            }
        }

        /// <summary>
        /// Binds the properties of a TIBReason object to the matching controls on the form.
        /// </summary>
        private void BindDataToForm()
        {
            if (tibReport != null)
            {
                //Delay reason items
                txtDelayIndex.Text = this.tibReport.DelayIndex.ToString();
                txtPlantArea.Text = this.tibReport.PlantArea;
                cboUnitGroup.SelectedValue = this.tibReport.UnitGroup;
                cboDelayReason1.SelectedText = this.tibReport.DelayReason1;
                cboDelayReason2.SelectedText = this.tibReport.DelayReason2;
                cboDelayReason3.SelectedText = this.tibReport.DelayReason3;
                cboDelayReason4.SelectedText = this.tibReport.DelayReason4;
                cboDelayClass.SelectedValue = this.tibReport.DelayClass;
                cboCategory.SelectedValue = this.tibReport.Category;
                cboDiscipline.SelectedValue = this.tibReport.Discipline;

                //General items
                cboOEECategory.SelectedText = this.tibReport.OEECategory;
                cboLossType.SelectedText = this.tibReport.LossType;
                cboOwner.SelectedText = this.tibReport.Owner;
                cboReportingTextLevel1.SelectedText = this.tibReport.ReportingTextLevel1;
                cboReportingTextLevel2.SelectedText = this.tibReport.ReportingTextLevel2;
                cboObjectCode.SelectedText = this.tibReport.ObjectCode;
                cboObjectDescription.SelectedText = this.tibReport.ObjectDescription;
                cboDamageCode.SelectedText = this.tibReport.DamageCode;
                cboDamageDescription.SelectedText = this.tibReport.DamageDescription;
                cboDeviationType.SelectedText = this.tibReport.DeviationType;
                cboCauseText.SelectedText = this.tibReport.CauseText;
                cboSection.SelectedText = this.tibReport.Section;
                cboExternalInternal.SelectedText = this.tibReport.ExternalInternal;
                cboSupplierDownStream.SelectedText = this.tibReport.SupplierDownStream;
                cboNoExtraWork.SelectedText = this.tibReport.NoExtraWork;

                //Floc items
                txtFlocDescriptionL3.Text = this.tibReport.FlocDescriptionL3;
                txtFlocDescriptionL4.Text = this.tibReport.FlocDescriptionL4;
                txtFlocDescriptionL5.Text = this.tibReport.FlocDescriptionL5;
                txtFlocNumberL3.Text = this.tibReport.FlocNumberL3;
                txtFlocNumberL4.Text = this.tibReport.FlocNumberL4;
                txtFlocNumberL5.Text = this.tibReport.FlocNumberL5;
            }
        }

        /// <summary>
        /// Main method for controlling changes to data in the Elvis db based on form values. Builds a TIBReason object from respective form controls.
        /// Calls Save or Update function based on the value of formMode.
        /// </summary>
        private void MakeChanges()
        {
            TIBReason formData = BuildObject();
            if (formMode == Mode.Edit)
                UpdateTIBReason(formData);
            else
                SaveNewTIBReason(formData);
        }

        /// <summary>
        /// Builds a TIBReason object from respective form controls.
        /// </summary>
        private TIBReason BuildObject()
        {
            TIBReason formData = new TIBReason();
            formData.ReasonIndex = incomingIndexNo;
            formData.DelayIndex = Convert.ToInt32(txtDelayIndex.Text);
            formData.UnitGroup = Convert.ToInt16(cboUnitGroup.SelectedValue);
            formData.PlantArea = txtPlantArea.Text;
            formData.DelayReason1 = cboDelayReason1.Text;
            formData.DelayReason2 = cboDelayReason2.Text;
            formData.DelayReason3 = cboDelayReason3.Text;
            formData.DelayReason4 = cboDelayReason4.Text;
            formData.DelayClass = Convert.ToInt16(cboDelayClass.SelectedValue);
            formData.Category = Convert.ToInt16(cboCategory.SelectedValue);
            formData.Discipline = Convert.ToInt16(cboDiscipline.SelectedValue);
            formData.OEECategory = cboOEECategory.Text;
            formData.LossType = cboLossType.Text;
            formData.Owner = cboOwner.Text;
            formData.ReportingTextLevel1 = cboReportingTextLevel1.Text;
            formData.ReportingTextLevel2 = cboReportingTextLevel2.Text;
            formData.ExternalInternal = cboExternalInternal.Text;
            formData.SupplierDownStream = cboSupplierDownStream.Text;
            formData.DamageDescription = cboDamageDescription.Text;
            formData.DamageCode = cboDamageCode.Text;
            formData.DeviationType = cboDeviationType.Text;
            formData.CauseText = cboCauseText.Text;
            formData.Section = cboSection.Text;
            formData.ObjectDescription = cboObjectDescription.Text;
            formData.ObjectCode = cboObjectCode.Text;
            formData.NoExtraWork = cboNoExtraWork.Text;
            formData.FlocDescriptionL3 = txtFlocDescriptionL3.Text;
            formData.FlocNumberL3 = txtFlocNumberL3.Text;
            formData.FlocDescriptionL4 = txtFlocDescriptionL4.Text;
            formData.FlocNumberL4 = txtFlocNumberL4.Text;
            formData.FlocDescriptionL5 = txtFlocDescriptionL5.Text;
            formData.FlocNumberL5 = txtFlocNumberL5.Text;
            return formData;
        }

        /// <summary>
        /// Uses the EntityHelper.TIBReasons AddNew method to add a new TIBReason record to the database. Displays a message box to inform the user
        /// of success or failure. Form is closed on closing the message box.
        /// </summary>
        /// <param name="newReason">The TIBReason object to be created</param>
        private void SaveNewTIBReason(TIBReason newReason)
        {
            try
            {
                EntityHelper.TIBReasons.AddNew(newReason);
                newTIBReason = new TIBReason();
                newTIBReason = newReason;
                MessageBox.Show(
                       "New TIB Reason saved.",
                       "Save Successful",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                       );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        "New TIB Reason failed to save. This has been logged.",
                        "Error Saving New TIB Reason",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                logger.ErrorException("TIB REASON ERROR -- SaveNewTIBReason() -- " +
                    "TIB Reason Failed to Sabe -- ReasonIndex: " + this.incomingIndexNo + " -- ", ex);
            }
        }

        /// <summary>
        /// Uses the EntityHelper.TIBReasons Update method to update an existing TIBReason record. Displays a message box to inform the user
        /// of success or failure. Form is closed on closing the message box.
        /// </summary>
        /// <param name="newReason">The TIBReason object to be updated</param>
        private void UpdateTIBReason(TIBReason changedReason)
        {
            try
            {
                EntityHelper.TIBReasons.Update(changedReason);
                MessageBox.Show(
                       "TIB Reason updated.",
                       "Save Successful",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                       );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        "TIB Reason failed to update. This has been logged.",
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                logger.ErrorException("TIB REASON ERROR -- UpdateTIBReason() -- " +
                    "TIB Reason Failed to Update -- ReasonIndex: " + this.incomingIndexNo + " -- ", ex);
            }
        }

        /// <summary>
        /// Uses the EntityHelper.TIBReasons Delete method to delete an existing TIBReason record. The deletion is confirmed before the Entity is changed.
        /// Uses the value of the variable Index to identify the record to delete. This value is passed into the form in the constructor when in Edit mode.
        /// Displays a message box to inform the user of success or failure. Form is closed on closing the message box. 
        /// </summary>
        private void DeleteTIBReason()
        {
            if (incomingIndexNo > 0)
            {
                if (ConfirmDeletion())
                {
                    try
                    {
                        EntityHelper.TIBReasons.Delete(incomingIndexNo);
                        MessageBox.Show(
                            "TIB Reason deleted successfully.",
                            "TIB Reason Deleted",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "TIB Reason deletion failed. This has been logged.",
                            "Error Deleting TIB Reason",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        logger.ErrorException("TIB REASON ERROR -- DeleteTIBReason() -- " +
                            "TIB Reason Failed to Delete -- ReasonIndex: " + this.incomingIndexNo + " -- ", ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                        "No record to delete.",
                        "TIB Reason Deletion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
            }
        }

        /// <summary>
        /// Displays a message box to enable the user to confirm the deletion. Returns a bool to indicate yes/no.
        /// </summary>
        /// <returns>Returns a bool to indicate delete confirmed or not.</returns>
        private bool ConfirmDeletion()
        {
            DialogResult confirmDelete = MessageBox.Show(
                    "Are you sure you want to delete this TIB Reason? This cannot be undone.",
                    "TIB Reason Deletion",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);
            if (confirmDelete == System.Windows.Forms.DialogResult.OK)
                return true;
            return false;
        }

        /// <summary>
        /// Key Press event handler for the index field.
        /// Stops users entering anything but a number.
        /// </summary>
        private void txtDelayIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks input for numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDelayIndex_Leave(object sender, EventArgs e)
        {
            CommonMethods.HighlightControl(txtDelayIndex, false);
            if (string.IsNullOrWhiteSpace(txtDelayIndex.Text))
                CommonMethods.HighlightControl(txtDelayIndex, true);
        }

        private void AddEditTIBReason_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.hasErrors;
            this.hasErrors = false;
        }
        #endregion
    }
}
