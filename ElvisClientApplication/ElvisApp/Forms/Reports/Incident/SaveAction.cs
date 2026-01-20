using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Models.Reports.Incident;

namespace Elvis.Forms.Reports.Incident
{
    
    public partial class SaveAction : Form
    {
        private const string INCIDENT_OPEN_TEXT = "Open";
        private const string INCIDENT_CLOSED_TEXT = "Closed";
        private IncidentAction Action = null;
        private IncidentReport Incident = null;
        private Boolean bHasBeenChanged = false;
        private Boolean bSaveChanges = false;

        /// <summary>
        /// Constructor for new action
        /// </summary>
        public SaveAction(IncidentReport incident)
        {
            InitializeComponent();
            Incident = incident;
            Action = new IncidentAction();
        }

        /// <summary>
        /// Constructor for existing action
        /// </summary>
        public SaveAction(IncidentReport incident, IncidentAction actionToPopulate)
        {
            InitializeComponent();
            Incident = incident;
            Action = actionToPopulate;
        }

        /// <summary>
        /// Handles form load event, calls setup
        /// </summary>
        private void AddAction_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        /// <summary>
        /// Sets up form
        /// </summary>
        private void SetupForm()
        {
            txtIncidentDescription.Text = Incident.Description;
            txtIncidentArea.Text = Incident.ReportArea.Description;
            txtIncidentFunction.Text = Incident.ReportFunction.Description;
            txtIncidentOwner.Text = Incident.ReportOwner.OwnerDescription;
            txtIncidentCreated.Text = Incident.TimeCreated == DateTime.MinValue ? "<New Incident>" : Incident.TimeCreated.ToString();

            cboOwner.DataSource = IncidentOwner.GetAllIncidentOwnersPlusOther("Please Select Owner");
            cboOwner.DisplayMember = "OwnerDescription";
            cboOwner.ValueMember = "OwnerId";

            txtDescription.Text = Action.ActionDesc;
            cboOwner.SelectedValue = Action.ActionOwner.OwnerId;
            dtpTargetDate.Value = Action.TargetDate == DateTime.MinValue ? DateTime.Now.Date : Action.TargetDate;
            txtActionCreated.Text = ((Action.TimeCreated == DateTime.MinValue) || (Action.TimeCreated.HasValue==false)) ? "<New Action>" : Action.TimeCreated.ToString();

            SetupActionStatus(Action.TimeClosed);
            SetupIncidentStatus(Incident.ReportStatus.StatusId.Value);

            btnSave.Enabled = false;
            bHasBeenChanged = false;
        }

        /// <summary>
        /// Track that a change has occurred
        /// </summary>
        private void IncidentChanged()
        {
            btnSave.Enabled = true;
            bHasBeenChanged = true;
        }

        /// <summary>
        /// Sets up form - actions
        /// </summary>
        private void SetupActionStatus(DateTime? closed)
        {
            if (closed.HasValue)
            {
                txtStatus.Text = Action.TimeClosed.Value.ToString();
                txtClosedBy.Text = Action.ClosedBy;
                btnCloseAction.Enabled = false;
                btnOpenAction.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtStatus.Text = INCIDENT_OPEN_TEXT;
                txtClosedBy.Text = INCIDENT_OPEN_TEXT;
                btnCloseAction.Enabled = true;
                btnOpenAction.Enabled = false;
                btnSave.Enabled = true;
            }
        }
         
        /// <summary>
        /// Sets up form - incident
        /// </summary>
        private void SetupIncidentStatus(int incidentStatus)
        {
            if (incidentStatus == (int)Status.IncidentStatus.Close)
            {
                grpClosedWarning.Visible = true;
                cboOwner.Enabled = false;
                btnCloseAction.Enabled = false;
                btnOpenAction.Enabled = false;
                dtpTargetDate.Enabled = false;
                txtDescription.ReadOnly = true;
                txtDescription.BackColor = Color.FromArgb(239, 235, 222);
                btnSave.Enabled = false;
            }
            else
            {
                grpClosedWarning.Visible = false;
            }
        }


        
        /// <summary>
        /// Set action state to closed
        /// </summary>
        private void btnCloseAction_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Action.TimeClosed = DateTime.Now;
            txtStatus.Text = Action.TimeClosed.ToString();
            Action.ClosedBy = Environment.UserName.ToString();
            txtClosedBy.Text = Action.ClosedBy;
            btnCloseAction.Enabled = false;
            btnOpenAction.Enabled = true;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Set action state to open
        /// </summary>
        private void btnOpenAction_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Action.TimeClosed = null;
            txtStatus.Text = INCIDENT_OPEN_TEXT;
            Action.ClosedBy = "";
            txtClosedBy.Text = INCIDENT_OPEN_TEXT;
            btnCloseAction.Enabled = true;
            btnOpenAction.Enabled = false;
            btnSave.Enabled = true;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form interaction forv arious content changes.
        /// </summary>
        private void cboOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }
        private void dtpTargetDate_ValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }



        /// <summary>
        /// Handle form interaction to save action and close.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bSaveChanges = true;
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Save action information.
        /// </summary>
        private Boolean SaveActionRecord()
        {
            Boolean bSuccess = false;

            if ((int)cboOwner.SelectedValue == 0)
            {
                MessageBox.Show("All actions must be assigned an owner", "Cannot Save action", MessageBoxButtons.OK, MessageBoxIcon.Error);

                bSuccess = false;
            }
            else
            {
                Action.TimeCreated= Action.NewAction ? DateTime.Now : Action.TimeCreated;
                Action.ActionDesc = txtDescription.Text;
                Action.ActionOwner = (IncidentOwner)cboOwner.SelectedItem;
                Action.TargetDate = dtpTargetDate.Value;
                if (txtStatus.Text == INCIDENT_OPEN_TEXT)
                {
                    Action.State = new Status(Status.IncidentStatus.Open);
                }
                else
                {
                    Action.State = new Status(Status.IncidentStatus.Close);
                    // fix so created time never later than closed time
                    Action.TimeCreated = Action.TimeCreated > Action.TimeClosed ? Action.TimeClosed : Action.TimeCreated;
                }

                bSuccess = true;
            }

            return bSuccess;
        }

        /// <summary>
        /// Handle form interaction to close WITHOUT saving.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bSaveChanges = false;
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form closing and actual saving.
        /// </summary>
        private void SaveAction_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (bHasBeenChanged & !bSaveChanges)
            {
                switch (MessageBox.Show("Warning Exiting without saving will revert any changes made to this incident or it's actions.  Do you want to save your changes?",
                                    "Save Changes?",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        bSaveChanges = true;
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        bSaveChanges = false;
                        break;

                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

            if (bSaveChanges)
            {
                if (SaveActionRecord())
                {
                    this.DialogResult = DialogResult.OK;
                    bHasBeenChanged = false;
                    bSaveChanges = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
