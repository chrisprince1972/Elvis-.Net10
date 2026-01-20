using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Data = ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Reports.Miscasts
{
    public partial class MiscastAction : Form
    {
        #region Variables
        private bool hasErrors = false;
        private bool emailNewOwner = true;
        private bool dataLoaded = false;
        private Data.MiscastMain miscastReport;
        private Data.MiscastAction miscastAction;
        private List<MiscastOwner> owners;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public MiscastAction(Data.MiscastMain miscastReport, List<MiscastOwner> owners, Data.MiscastAction miscastAction = null)
        {
            InitializeComponent();
            this.miscastReport = miscastReport;
            this.miscastAction = miscastAction;
            this.owners = owners;
            BindDropDown();
            if (this.miscastAction != null)
            {//Edit Mode
                this.Text = "Edit Action";
                this.emailNewOwner = false;
                grpAction.Text = "Existing Miscast Action";
                btnDelete.Visible = true;
                btnDelete.Enabled = true;
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
        /// Populates the form with the data.
        /// </summary>
        private void PopulateForm()
        {
            txtAction.Text = this.miscastAction.ActionText;
            cmboOwner.SelectedValue = this.miscastAction.ActionOwnerID;
            dpTarget.Value = this.miscastAction.TargetDate;
            chbState.Checked = this.miscastAction.ActionState;
        }

        /// <summary>
        /// Binds the drop down list with the Owner Data.
        /// </summary>
        private void BindDropDown()
        {
            if (this.owners != null)
            {
                cmboOwner.DataSource = this.owners;
                cmboOwner.DisplayMember = "OwnerName";
                cmboOwner.ValueMember = "MiscastOwnerID";
            }
        }

        /// <summary>
        /// Performs the add or update on the record.
        /// </summary>
        private bool SaveAction()
        {
            if (FormValidated() && this.miscastReport != null)
            {
                try
                {
                    if (this.miscastAction != null)//Edit
                    {
                        this.miscastAction.ActionText = txtAction.Text;
                        this.miscastAction.ActionOwnerID = HelperFunctions.GetIntSafely(
                            cmboOwner.SelectedValue);
                        this.miscastAction.TargetDate = dpTarget.Value;
                        this.miscastAction.ActionState = chbState.Checked;

                        EntityHelper.MiscastActions.Update(this.miscastAction);
                    }
                    else//Add
                    {
                        this.miscastAction = new Data.MiscastAction()
                        {
                            MiscastID = this.miscastReport.MiscastID,
                            ActionText = txtAction.Text,
                            ActionOwnerID = HelperFunctions.GetIntSafely(
                                cmboOwner.SelectedValue),
                            TargetDate = dpTarget.Value,
                            ActionState = chbState.Checked
                        };

                        EntityHelper.MiscastActions.AddNew(this.miscastAction);
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException("MISCAST ACTION ERROR -- SaveAction() -- " +
                        "Miscast Action Failed to Save -- ", ex);
                    MessageBox.Show(
                        "Miscast Action failed to save. This has been logged.",
                        "Save Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return false;
                }

                if (this.emailNewOwner)
                {//Email Owner
                    string recipient = GetRecipient();
                    if (recipient != "Error")
                    {
                        var task = ThreadPool.QueueUserWorkItem(s =>
                            CommonMethods.EmailMiscastOwner(
                                 "New Miscast Action",
                                 this.miscastReport.HeatNumber,
                                 this.miscastAction.ActionText,
                                 recipient)
                            );

                        if (!task)
                        {//if Email Fails, alert the user.
                            MessageBox.Show(
                                "Miscast Action E-Mail notification failed to send.",
                                "E-Mail Notification Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                        }
                    }
                    else
                    {//Record missing e-mail from system.
                        logger.Info(string.Format(
                                "MISCAST ACTION E-MAIL -- The Recipients E-mail was not found -- Owner: {1}",
                                cmboOwner.Text));
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the recipient email.
        /// </summary>
        /// <returns>The Recipients E-Mail Address.</returns>
        private string GetRecipient()
        {
            //return "gerwyn.jakeway@tatasteel.com";//Uncomment for Test email
            int ownerID = HelperFunctions.GetIntSafely(cmboOwner.SelectedValue);
            MiscastOwner owner = this.owners.FirstOrDefault(o => o.MiscastOwnerID == ownerID);
            if (owner != null)
            {
                return owner.OwnerEmail;
            }
            return "Error";//Cannot find
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
            lblOwnerInvalid.Visible = false;

            if (HelperFunctions.GetIntSafely(cmboOwner.SelectedValue) == 0)
            {
                CommonMethods.HighlightControl(cmboOwner, true);
                lblOwnerInvalid.Visible = true;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAction.Text))
            {
                CommonMethods.HighlightControl(txtAction, true);
                valid = false;
            }
            btnSave.Enabled = valid;
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
                    if (this.miscastAction != null)
                    {
                        EntityHelper.MiscastActions.Delete(this.miscastAction);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    int actionIndex = 0;
                    if (this.miscastAction != null)
                        actionIndex = this.miscastAction.MiscastActionID;

                    MessageBox.Show(
                        "Failed to delete the Miscast Action. This has been logged.",
                        "Delete Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.ErrorException("MISCAST ACTION DATA ERROR -- DeleteAction() -- " +
                        "Failed to delete the Miscast Action -- Miscast Action ID: " +
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
        /// Validates the form on text change of the action textbox.
        /// </summary>
        private void txtAction_TextChanged(object sender, EventArgs e)
        {
            if (this.dataLoaded)
            {
                FormValidated();
            }
        }

        /// <summary>
        /// Delete action button event handler
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteAction())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return;
            }
            this.hasErrors = true;
        }

        private void cmboOwner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.dataLoaded)
            {
                FormValidated();
                this.emailNewOwner = true;
            }
        }

        private void MiscastAction_Load(object sender, EventArgs e)
        {
            //FormValidated();
            this.dataLoaded = true;
        }
        #endregion

        #endregion
    }
}
