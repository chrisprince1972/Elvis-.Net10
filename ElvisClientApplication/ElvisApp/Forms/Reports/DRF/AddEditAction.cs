using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Reports.DRF
{
    public partial class AddEditAction : Form
    {
        #region Variables
        private bool hasErrors = false;
        private bool emailNewOwner = true;
        private DRFReport drfReport;
        private DRFAction drfAction;
        private List<DRFOwner> owners;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public AddEditAction(DRFReport drfReport, DRFAction action = null)
        {
            InitializeComponent();
            this.drfAction = action;
            this.drfReport = drfReport;
            GetData();
            BindDropDown();
            if (this.drfAction != null)
            {//Edit Mode
                this.Text = "Edit Action";
                this.emailNewOwner = false;
                grpAction.Text = "Existing DRF Action";
                btnDelete.Visible = true;
                PopulateForm();
            }
            CustomiseColours();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
            grpAction.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            grpAction.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the forms data
        /// </summary>
        private void GetData()
        {
            this.owners = EntityHelper.DRFOwners.GetAll();
            this.owners.Insert(0,
                    new DRFOwner()
                    {
                        Works = "Please Select",
                        Owner = "Please Select"
                    }
                );
        }

        /// <summary>
        /// Populates the form with the data.
        /// </summary>
        private void PopulateForm()
        {
            txtAction.Text = this.drfAction.Action;

            if (!string.IsNullOrEmpty(this.drfAction.ActionOwner))
                cmboOwner.SelectedItem = new { Owner = this.drfAction.ActionOwner };

            if (this.drfAction.TargetDate.HasValue)
                dpTarget.Value = this.drfAction.TargetDate.Value;

            chbState.Checked = this.drfAction.ActionState;
        }

        /// <summary>
        /// Binds the drop down list with the Owner Data.
        /// </summary>
        private void BindDropDown()
        {
            if (!string.IsNullOrEmpty(this.drfReport.Works))
            {
                cmboOwner.DataSource = this.owners
                    .Where(o =>
                        o.Works == this.drfReport.Works ||
                        o.Works == "Please Select")
                    .Select(s => new { s.Owner })
                    .ToList();
                cmboOwner.DisplayMember = "Owner";
            }
        }

        /// <summary>
        /// Performs the add or update on the record.
        /// </summary>
        private bool SaveAction()
        {
            if (FormValidated() && this.drfReport != null)
            {
                try
                {
                    if (this.drfAction != null)//Edit
                    {
                        this.drfAction = BuildAction(this.drfAction.ActionIndex);
                        EntityHelper.DRFActions.Update(this.drfAction);
                    }
                    else//Add
                    {
                        this.drfAction = BuildAction();
                        EntityHelper.DRFActions.AddNew(this.drfAction);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "DRF Action failed to save. This has been logged.",
                        "Save Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.ErrorException("DRF ACTION ERROR -- SaveAction() -- " +
                        "DRF Action Failed to Save -- ", ex);
                }

                if (this.emailNewOwner)
                {//Email Owner
                    string recipient = GetRecipient();
                    if (recipient != "Error")
                    {
                        var task = ThreadPool.QueueUserWorkItem(s =>
                            CommonMethods.EmailDRFOwner(
                                 "New DRF Action",
                                 this.drfReport.DRFIndex,
                                 this.drfAction.Action,
                                 recipient)
                            );

                        if (!task)
                        {//if Email Fails, alert the user.
                            MessageBox.Show(
                                "DRF Action E-Mail notification failed to send.",
                                "E-Mail Notification Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                        }
                    }
                    else
                    {//Record missing e-mail from system.
                        logger.Info(string.Format(
                                "DRF ACTION E-MAIL -- The Recipients E-mail was not found -- Works: {0} -- Owner: {1}",
                                this.drfReport.Works, cmboOwner.Text));
                    }
                }
                return true;
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
        /// Builds the action ready for an update or add.
        /// </summary>
        /// <param name="actionIndex">The index of the action if it already exists.</param>
        /// <returns>A DRF Action ready to save.</returns>
        private DRFAction BuildAction(int actionIndex = 0)
        {
            return new DRFAction()
            {
                ActionIndex = actionIndex,
                DRFIndex = this.drfReport.DRFIndex,
                Action = txtAction.Text,
                ActionOwner = cmboOwner.Text,
                TargetDate = dpTarget.Value,
                ActionState = chbState.Checked
            };
        }

        /// <summary>
        /// Validates the user input on the form.
        /// </summary>
        /// <returns>True for Passed Validation, False for failed.</returns>
        private bool FormValidated()
        {
            bool valid = true;
            CommonMethods.HighlightControl(cmboOwner, false);
            CommonMethods.HighlightControl(txtAction, false);
            if (cmboOwner.Text == "Please Select")
            {
                CommonMethods.HighlightControl(cmboOwner, true);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAction.Text))
            {
                CommonMethods.HighlightControl(txtAction, true);
                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// Deletes the Currently Opened Action from the system.
        /// </summary>
        /// <returns>True for success, false for failure.</returns>
        private bool DeleteAction()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you wish to delete this Action? This process cannot be undone.",
                "Confirmation Required",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (this.drfAction != null)
                    {
                        EntityHelper.DRFActions.Delete(this.drfAction.ActionIndex);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    int actionIndex = 0;
                    if (this.drfAction != null)
                        actionIndex = this.drfAction.ActionIndex;

                    MessageBox.Show(
                        "Failed to delete the DRF Action. This has been logged.",
                        "Deletion Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.ErrorException("DRF ACTION ERROR -- DeleteAction() -- " +
                        "Failed to update the Reviewed date -- DRF Action Index: " +
                        actionIndex + " -- ", ex);

                    this.hasErrors = true;
                }
            }
            return false;
        }

        #region Events
        /// <summary>
        /// Modifies the State Textbox to reflect the users choice with the
        /// checkbox.
        /// </summary>
        private void chbState_CheckedChanged(object sender, EventArgs e)
        {
            if (chbState.Checked)
            {
                txtState.Text = "Closed";
            }
            else
            {
                txtState.Text = "Open";
            }
        }

        /// <summary>
        /// Button Save click event.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SaveAction())
                this.hasErrors = true;
        }

        /// <summary>
        /// Stops the form closing if there are errors.
        /// </summary>
        private void AddEditAction_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.hasErrors;
            this.hasErrors = false;
        }

        /// <summary>
        /// Validates the form on combobox selection changed.
        /// </summary>
        private void cmboOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboOwner.SelectedIndex > 0)
            {
                FormValidated();
                this.emailNewOwner = true;
            }
        }

        /// <summary>
        /// Validates the form on text change of the action textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAction_TextChanged(object sender, EventArgs e)
        {
            FormValidated();
        }

        /// <summary>
        /// Delete action button event handler
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!DeleteAction())
                this.hasErrors = true;
        }
        #endregion

        #endregion
    }
}
