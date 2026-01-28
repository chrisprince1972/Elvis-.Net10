using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Models.Reports.Incident;
using Elvis.Common;

namespace Elvis.Forms.Reports.Incident
{
    public partial class SaveIncident : Form
    {
        private const string INCIDENT_OPEN_TEXT = "Open";
        private IncidentReport Incident = null;
        private Boolean bHasBeenChanged = false;
        private Boolean bSaveChanges = false;

        /// <summary>
        /// Constructor for new incident
        /// </summary>
        public SaveIncident()
        {
            Incident = new IncidentReport();
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for existing incident
        /// </summary>
        public SaveIncident(IncidentReport ir)
        {
            Incident = ir;
            InitializeComponent();
        }

        /// <summary>
        /// Handles form load event, calls setup
        /// </summary>
        private void AddIncident_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        /// <summary>
        /// Sets up form
        /// </summary>
        private void SetupForm()
        {
            cboArea.DataSource = Area.GetAllAreas();
            cboArea.DisplayMember = "Description";
            cboArea.ValueMember = "AreaId";

            cboFunction.DataSource = Function.GetAllFunctions();
            cboFunction.DisplayMember = "Description";
            cboFunction.ValueMember = "FunctionId";

            cboOwner.DataSource = IncidentOwner.GetAllIncidentOwnersPlusOther("None");
            cboOwner.DisplayMember = "OwnerDescription";
            cboOwner.ValueMember = "OwnerId";

            foreach (IncidentAction ia in Incident.Actions)
            {
                AddActionsGridRow(ia);
            }
            dgvActions.Sort(dgvActions.Columns["colTargetDate"], ListSortDirection.Ascending);
            dgvActions.ClearSelection();

            txtDescription.Text = Incident.Description;
            cboArea.SelectedValue = Incident.ReportArea.AreaId.Value;
            cboFunction.SelectedValue = Incident.ReportFunction.FunctionId.Value;
            cboOwner.SelectedValue = Incident.ReportOwner.OwnerId.Value;
            txtCreated.Text = Incident.TimeCreated == DateTime.MinValue ? "<New Incident>" : Incident.TimeCreated.ToString();
            SetupIncidentStatus(Incident.TimeClosed);

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
        /// Creates new row in gdvActions and calls to populate.
        /// </summary>
        private void AddActionsGridRow(IncidentAction actionToPopulate)
        {
            PopulateActionsGridRowValues(actionToPopulate, dgvActions.Rows.Add());
        }

        /// <summary>
        /// Populates values in specificed gdvActions row.
        /// </summary>
        private void PopulateActionsGridRowValues(IncidentAction actionToPopulate, int index)
        {
            dgvActions.Rows[index].Cells["colTargetDate"].Value = actionToPopulate.TargetDate;

            //if action overdue
            if (actionToPopulate.State.StatusId.Value != 2 && actionToPopulate.TargetDate < MyDateTime.Now.Date)
            {
                DataGridViewCellStyle bold = new DataGridViewCellStyle();
                bold.Font = new Font(dgvActions.Font, FontStyle.Bold);

                dgvActions.Rows[index].Cells["colStatus"].Style = bold;
                dgvActions.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                dgvActions.Rows[index].Cells["colStatus"].Value = "OVERDUE";
            }
            else
            {
                dgvActions.Rows[index].Cells["colStatus"].Style.Font = dgvActions.RowsDefaultCellStyle.Font;
                dgvActions.Rows[index].DefaultCellStyle.ForeColor = dgvActions.RowsDefaultCellStyle.ForeColor;
                dgvActions.Rows[index].Cells["colStatus"].Value = actionToPopulate.State.Description;
            }

            dgvActions.Rows[index].Cells["colOwner"].Value = actionToPopulate.ActionOwner.OwnerDescription;
            dgvActions.Rows[index].Cells["colDescription"].Value = actionToPopulate.ActionDesc;
            dgvActions.Rows[index].Cells["colIncidentAction"].Value = actionToPopulate;
        }

        /// <summary>
        /// Sets up form - Incident
        /// </summary>
        private void SetupIncidentStatus(DateTime? closed)
        {
            btnClose.Enabled = !closed.HasValue;
            btnOpen.Enabled = closed.HasValue;
            btnSave.Enabled = !closed.HasValue;
            if (closed.HasValue)
            {
                Incident.ReportStatus.StatusId = (int)Status.IncidentStatus.Close;
                txtClosed.Text = Incident.TimeClosed.Value.ToString();
                setupClosedIncident();
            }
            else
            {
                Incident.ReportStatus.StatusId = (int)Status.IncidentStatus.Open;
                Incident.TimeClosed = null;
                txtClosed.Text = INCIDENT_OPEN_TEXT;
                setupOpenIncident();
            }
        }

        /// <summary>
        /// Sets up form - Closed Incident
        /// </summary>
        private void setupClosedIncident()
        {
            txtClosed.Text = Incident.TimeClosed.ToString();
            btnClose.Enabled = false;
            btnOpen.Enabled = true;
            btnAdd.Enabled = false;
            cboArea.Enabled = false;
            cboFunction.Enabled = false;
            cboOwner.Enabled = false;
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.FromArgb(239, 235, 222);
        }

        /// <summary>
        /// Sets up form - Open Incident
        /// </summary>
        private void setupOpenIncident()
        {
            txtClosed.Text = INCIDENT_OPEN_TEXT;
            btnClose.Enabled = true;
            btnOpen.Enabled = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = true;
            cboArea.Enabled = true;
            cboFunction.Enabled = true;
            cboOwner.Enabled = true;
            txtDescription.ReadOnly = false;
            txtDescription.BackColor = Color.White;
        }



        /// <summary>
        /// Set incident state to closed
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (checkAllActionsClosed())
            {
                Incident.ReportStatus.StatusId = (int)Status.IncidentStatus.Close;
                Incident.TimeClosed = MyDateTime.Now;
                setupClosedIncident();
                IncidentChanged();
            }
            else
            {
                MessageBox.Show("All actions must be closed before an incident can be closed", "Cannot Close Incident", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Check is all actions are closed.
        /// </summary>
        private Boolean checkAllActionsClosed()
        {
            Boolean asd = dgvActions.Rows
                         .Cast<DataGridViewRow>()
                         .Where(r => ((IncidentAction)r.Cells["colIncidentAction"].Value).State.StatusId.Value == (int)Status.IncidentStatus.Open)
                         .Count() == 0;

            return asd;

        }

        /// <summary>
        /// Set incident state to open
        /// </summary>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Incident.ReportStatus.StatusId = (int)Status.IncidentStatus.Open;
            Incident.TimeClosed = null;
            setupOpenIncident();
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form interaction forv arious content changes.
        /// </summary>
        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }
        private void cboFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IncidentChanged();
            this.Cursor = Cursors.Default;
        }
        private void cboOwner_SelectedIndexChanged(object sender, EventArgs e)
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
        /// Handle form interaction to open selected action for editing.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenSelectedActionForEditing();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form interaction to open selected action for editing.
        /// </summary>
        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenSelectedActionForEditing();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form interaction to open selected action for editing.
        /// </summary>
        private void dgvActions_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                OpenSelectedActionForEditing();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Open selected action for editing (SaveAction.cs) and refresh data if updated.
        /// </summary>
        private void OpenSelectedActionForEditing()
        {
            if (dgvActions.CurrentRow != null)
            {
                int currentRowIndex = -1;
                IncidentAction ia
                    = (IncidentAction)dgvActions
                    .CurrentRow
                    .Cells["colIncidentAction"]
                    .Value;

                SaveAction sa = new SaveAction(Incident, ia);
                if (sa.ShowDialog() == DialogResult.OK)
                {
                    currentRowIndex = dgvActions.CurrentRow.Index;
                    PopulateActionsGridRowValues(ia, currentRowIndex);
                    IncidentChanged();
                }
            }
        }

        /// <summary>
        /// Handle form interaction to open new action for editing.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenNewActionForEditing();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Open new action for editing (SaveAction.cs) and refresh data if updated.
        /// </summary>
        private void OpenNewActionForEditing()
        {
            IncidentAction ia = new IncidentAction();
            SaveAction sa = new SaveAction(Incident, ia);
            if (sa.ShowDialog() == DialogResult.OK)
            {
                ia.IncidentId = Incident.NewIncident ? ia.IncidentId : Incident.IncidentId.Value;
                AddActionsGridRow(ia);
                IncidentChanged();
            }
        }

        /// <summary>
        /// Handle form interaction to select action.
        /// </summary>
        private void dgvActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnEdit.Enabled = dgvActions.CurrentRow != null;
            this.Cursor = Cursors.Default;
        }



        /// <summary>
        /// Handle form interaction to save incident and close.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bSaveChanges = true;
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Save incident information.
        /// </summary>
        private void SaveIncidentRecord()
        {
            Boolean bClose = false;
            Incident.Description = txtDescription.Text;
            if (IncidentOpen())
            {
                Incident.ReportStatus = new Status(Status.IncidentStatus.Open);
            }
            else
            {
                Incident.ReportStatus = new Status(Status.IncidentStatus.Close);
                bClose = true;
            }

            Incident.ReportArea = (Area)cboArea.SelectedItem;
            Incident.ReportFunction = (Function)cboFunction.SelectedItem;
            Incident.ReportOwner = (IncidentOwner)cboOwner.SelectedItem;
            Incident.Actions = new List<IncidentAction>();
            foreach (DataGridViewRow row in dgvActions.Rows)
            {
                Incident.Actions.Add((IncidentAction)row.Cells["colIncidentAction"].Value);
            }

            //close incident if all ctions closed
            if(Incident.Actions.Count > 0 && Incident.CheckAllActionsClosed())
            {
                Incident.ReportStatus = new Status(Status.IncidentStatus.Close);
                Incident.TimeClosed = MyDateTime.Now;
                bClose = true;
            }
            Incident.Save(bClose);
        }

        /// <summary>
        /// Check if Incident is open.
        /// </summary>
        private bool IncidentOpen()
        {
            return txtClosed.Text == INCIDENT_OPEN_TEXT;
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
        private void SaveIncident_FormClosing(object sender, FormClosingEventArgs e)
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
                SaveIncidentRecord();
                this.DialogResult = DialogResult.OK;
                    bHasBeenChanged = false;
                    bSaveChanges = false;
            }
 
        }

    }
}
