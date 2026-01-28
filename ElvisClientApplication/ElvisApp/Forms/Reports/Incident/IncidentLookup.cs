using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Models.Reports.Incident;
using BusinessLogic.Models.Reports.Incident;
using Elvis.Common;

namespace Elvis.Forms.Reports.Incident
{
    public partial class IncidentLookup : Form
    {
        private Area.AreaCode defaultAreaID;

        /// <summary>
        /// Constructor
        /// </summary>
        public IncidentLookup(Area.AreaCode areaID)
        {
            InitializeComponent();
            defaultAreaID = areaID;
        }

        /// <summary>
        /// Loader, calls routines to set up form
        /// </summary>
        private void IncidentLookup_Load(object sender, EventArgs e)
        {
            dgvIncidents.AutoGenerateColumns = false;
            dgvIncidents.AllowUserToAddRows = false;

            SetupForm();
            if (defaultAreaID != Area.AreaCode.All)
            {
                cmboArea.SelectedValue = (int)defaultAreaID;
            }
            SearchIncidents();

        }

        /// <summary>
        /// Sets up drop down lists.
        /// </summary>
        private void SetupForm()
        {
            cmboArea.DataSource = Area.GetAllAreasPlusAll()
                .Select(a => new { a.AreaId, a.DescriptionFull })
                .ToList();
            cmboArea.ValueMember = "AreaId";
            cmboArea.DisplayMember = "DescriptionFull";

            cmboFunction.DataSource = Function.GetAllFunctionsPlusAll()
               .Select(a => new { a.FunctionId, a.DescriptionFull })
               .ToList();
            cmboFunction.ValueMember = "FunctionId";
            cmboFunction.DisplayMember = "DescriptionFull";

            cmboOwner.DataSource = IncidentOwner.GetAllIncidentOwnersPlusOther("All")
               .Select(a => new { a.OwnerId, a.OwnerDescription })
               .ToList();
            cmboOwner.ValueMember = "OwnerId";
            cmboOwner.DisplayMember = "OwnerDescription";

            InitialDateSetup();

            rbIncidentStatusOpen.Checked = true;
            rbActionStatusOpen.Checked = true;
        }

        /// <summary>
        /// Sets up Dates, default date range to include all open
        /// </summary>
        private void InitialDateSetup()
        {
            DateTime dateNow = new DateTime(MyDateTime.Now.Year,
                                            MyDateTime.Now.Month,
                                            MyDateTime.Now.Day,
                                            0, 0, 0);
            DateTime earliestTimeStampCreated;

            DateTime? from = null, to = null;
            int? areaId = null, functionId = null, ownerId = null;

            earliestTimeStampCreated = IncidentReport.GetEarliestTimeStampCreated(from,
                                                                                 to,
                                                                                 areaId,
                                                                                 functionId,
                                                                                 ownerId,
                                                                                 Status.IncidentStatus.Open);

            edsReportRange.DateFrom = earliestTimeStampCreated == DateTime.MinValue ? dateNow.AddDays(-6) : earliestTimeStampCreated;
            
            edsReportRange.DateTo = dateNow.AddDays(1);
        }

        /// <summary>
        /// Uses search criteria from form to find and display incidents and actions in appropriate grids.
        /// </summary>
        private void SearchIncidents()
        {
            lblFromDate.Text = "From - " + edsReportRange.DateFrom.ToString("dd/MM/yyyy HH:mm");
            lblToDate.Text = "To - " + edsReportRange.DateTo.ToString("dd/MM/yyyy HH:mm");

            int? areaId = null, functionId = null, ownerId = null;

            if (int.Parse(cmboArea.SelectedValue.ToString()) != 0) areaId = int.Parse(cmboArea.SelectedValue.ToString());
            if (int.Parse(cmboFunction.SelectedValue.ToString()) != 0) functionId = int.Parse(cmboFunction.SelectedValue.ToString());
            if (int.Parse(cmboOwner.SelectedValue.ToString()) != 0) ownerId = int.Parse(cmboOwner.SelectedValue.ToString());

            try
            {
                List<IncidentReport> incidents = IncidentReport.GetByDateRangeAndFilter(edsReportRange.DateFrom,
                                                                                      edsReportRange.DateTo,
                                                                                      areaId,
                                                                                      functionId,
                                                                                      ownerId,
                                                                                      GetIncidentStatusFromForm());
                PopulateIncidentsGrid(incidents);
                SearchActions(incidents, GetActionStatusFromForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            dgvIncidents.ClearSelection();
            SetupButtonStatus();
        }

        /// <summary>
        /// Returns typed incident status based on form selection.
        /// </summary>
        private Status.IncidentStatus? GetIncidentStatusFromForm()
        {
            Status.IncidentStatus? retVal = null;
            retVal = (rbIncidentStatusOpen.Checked == true) ? Status.IncidentStatus.Open : retVal;
            retVal = (rbIncidentStatusClosed.Checked == true) ? Status.IncidentStatus.Close : retVal;

            return retVal;
        }

        /// <summary>
        /// Populates gdvIncidents and resets button statuses.
        /// </summary>
        private void PopulateIncidentsGrid(List<IncidentReport> incidents)
        {
            dgvIncidents.DataSource
                = incidents
                .Select(r => new IncidentReportLookUpGridView(r)).OrderByDescending(r => r.TimeCreated).ToList();
       }

        /// <summary>
        /// Returns typed action status based on form selection.
        /// </summary>
        private Status.IncidentStatus? GetActionStatusFromForm()
        {
            Status.IncidentStatus? retVal = null;
            retVal = (rbActionStatusOpen.Checked == true) ? Status.IncidentStatus.Open : retVal;
            retVal = (rbActionStatusClosed.Checked == true) ? Status.IncidentStatus.Close : retVal;

            return retVal;
        }

        /// <summary>
        /// Uses search criteria from form to find and display actions.
        /// </summary>
        private void SearchActions(List<IncidentReport> incidents, Status.IncidentStatus? status = null)
        {
            ClearActionsGrid();

            lblIncident.Text = incidents.Count == dgvIncidents.Rows.Count ? "For All Listed Incidents" : "For Incident - " + incidents[0].IncidentId.Value;
            btnShowallOpenActions.Enabled = incidents.Count != dgvIncidents.Rows.Count;

            foreach (IncidentReport ir in incidents)
            {
                foreach (IncidentAction ia in ir.Actions)
                {
                    if ((!status.HasValue) || ((int)status.Value == ia.State.StatusId.Value)) AddActionsGridRow(ia);
                }
            }

            dgvActions.Sort(dgvActions.Columns["colActionTargetDate"], ListSortDirection.Ascending);
            dgvActions.ClearSelection();
            SetupButtonStatus();
        }

        /// <summary>
        /// Clears gdvActions.
        /// </summary>
        private void ClearActionsGrid()
        {
            dgvActions.Rows.Clear();
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
            dgvActions.Rows[index].Cells["colIncidentId"].Value = actionToPopulate.IncidentId;
            dgvActions.Rows[index].Cells["colActionTargetDate"].Value = actionToPopulate.TargetDate;

            //if action overdue
            if (actionToPopulate.State.StatusId.Value != 2 && actionToPopulate.TargetDate < MyDateTime.Now.Date)
            {
                DataGridViewCellStyle bold = new DataGridViewCellStyle();
                bold.Font = new Font(dgvActions.Font, FontStyle.Bold);

                dgvActions.Rows[index].Cells["colActionStatus"].Style = bold;
                dgvActions.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                dgvActions.Rows[index].Cells["colActionStatus"].Value = "OVERDUE";
            }
            else
            {
                dgvActions.Rows[index].Cells["colActionStatus"].Style.Font = dgvActions.RowsDefaultCellStyle.Font;
                dgvActions.Rows[index].DefaultCellStyle.ForeColor = dgvActions.RowsDefaultCellStyle.ForeColor;
                dgvActions.Rows[index].Cells["colActionStatus"].Value = actionToPopulate.State.Description;
            }

            dgvActions.Rows[index].Cells["colActionOwner"].Value = actionToPopulate.ActionOwner.OwnerDescription;
            dgvActions.Rows[index].Cells["colActionDescription"].Value = actionToPopulate.ActionDesc;
            dgvActions.Rows[index].Cells["colIncidentAction"].Value = actionToPopulate;
        }



        /// <summary>
        /// Sets enabled state for various control buttons based on grid selection states.
        /// </summary>
        private void SetupButtonStatus()
        {
            btnEditIncident.Enabled = (dgvIncidents.SelectedRows.Count != 0) ? true : false;
            btnAddIncident.Enabled  = true;
            btnEditAction.Enabled   = (dgvActions.SelectedRows.Count != 0) ? true : false;

            if (dgvIncidents.SelectedRows.Count != 0)
            {
                IncidentReport ir
                        = (IncidentReport)dgvIncidents
                        .CurrentRow
                        .Cells["colIncidentReport"]
                        .Value;
                btnAddAction.Enabled = (ir.ReportStatus.StatusId.Value == (int)Status.IncidentStatus.Open) ? true : false;
            }
            else
            {
                btnAddAction.Enabled = false;
            }
        }
        


        /// <summary>
        /// Handle for interaction.
        /// </summary>
        private void btnSearchIncident_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SearchIncidents();
            this.Cursor = Cursors.Default;
        }



        /// <summary>
        /// Handle form interaction to open selected incident for editing.
        /// </summary>
        private void btnEditIncident_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenSelectedIncidentForEditing();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form interaction to open selected incident for editing.
        /// </summary>
        private void dgvIncidents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenSelectedIncidentForEditing();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handle form interaction to open selected incident for editing.
        /// </summary>
        private void dgvIncidents_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                OpenSelectedIncidentForEditing();
            }
            this.Cursor = Cursors.Default;
        }
        
        /// <summary>
        /// Open selected incident for editing (SaveIncident.cs) and refresh data if updated.
        /// </summary>
        private void OpenSelectedIncidentForEditing()
        {
            if (dgvIncidents.CurrentRow != null)
            {
                IncidentReport ir
                    = (IncidentReport)dgvIncidents
                    .CurrentRow
                    .Cells["colIncidentReport"]
                    .Value;

                SaveIncident si = new SaveIncident(ir);
                if (si.ShowDialog() == DialogResult.OK)
                {
                    SearchIncidents();
                }
 
            }
        }



        /// <summary>
        /// Handle form interaction to open new incident for editing.
        /// </summary>
        private void btnAddIncident_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenNewIncidentForEditing();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Open new incident for editing (SaveIncident.cs) and refresh data if updated.
        /// </summary>
        private void OpenNewIncidentForEditing()
        {
            SaveIncident si = new SaveIncident();
            if (si.ShowDialog() == DialogResult.OK)
            {
                SearchIncidents();
            }
        }



        /// <summary>
        /// Handle form interaction to show actions for only selected incident.
        /// </summary>
        private void dgvIncidents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Check for header row click
            if (e.RowIndex != -1)
            {
                SearchActionsForSelectedIncident();
                SetupButtonStatus();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Filter gdvActions to show actiosn for only selected incident.
        /// </summary>
        private void SearchActionsForSelectedIncident()
        {
            List<IncidentReport> incidents = new List<IncidentReport>();
            IncidentReport ir
                = (IncidentReport)dgvIncidents
                .CurrentRow
                .Cells["colIncidentReport"]
                .Value;
            incidents.Add(ir);
            SearchActions(incidents);
            SetupButtonStatus();
        }



        /// <summary>
        /// Handle form interaction to open show all actions
        /// </summary>
        private void btnShowallActions_Click(object sender, EventArgs e)
        {
            rbActionStatusBoth.Select();
            SearchIncidents();
        }

        /// <summary>
        /// Handle form interaction to open show all open actions
        /// </summary>
        private void btnShowallOpenActions_Click(object sender, EventArgs e)
        {
            rbActionStatusOpen.Select();
            SearchIncidents();
        }

        /// <summary>
        /// Handle form interaction to open selected action for editing.
        /// </summary>
        private void btnEditAction_Click(object sender, EventArgs e)
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
                this.Cursor = Cursors.Default;
            }
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

                IncidentReport ir = GetIncidentFromGridByID(ia.IncidentId.Value);

                int selectedRow = dgvIncidents.CurrentCell.RowIndex;

                SaveAction sa = new SaveAction(ir, ia);
                if (sa.ShowDialog() == DialogResult.OK)
                {
                    ia.Save();
                    currentRowIndex = dgvActions.CurrentRow.Index;
                    PopulateActionsGridRowValues(ia, currentRowIndex);
                }
                UpdateIncidentsGridRow(selectedRow, ir);

            }
        }

        /// <summary>
        /// Finds and fetches an IncidentReport object from dgvIncidents.
        /// </summary>
        private IncidentReport GetIncidentFromGridByID(int incidentID)
        {
            DataGridViewRow row = dgvIncidents.Rows
                .Cast<DataGridViewRow>()
                .Where(r => (int)r.Cells["ColNo"].Value == incidentID)
                .First();

            IncidentReport ir
                = (IncidentReport)dgvIncidents
                .Rows[row.Index]
                .Cells["colIncidentReport"]
                .Value;

            return ir;
        }

        /// <summary>
        /// Handle form interaction to open new action for editing.
        /// </summary>
        private void btnAddAction_Click(object sender, EventArgs e)
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
            IncidentReport ir
                = (IncidentReport)dgvIncidents
                .CurrentRow
                .Cells["colIncidentReport"]
                .Value;
            int selectedRow = dgvIncidents.CurrentCell.RowIndex;

            IncidentAction ia = new IncidentAction();
            SaveAction sa = new SaveAction(ir, ia);
            if (sa.ShowDialog() == DialogResult.OK)
            {
                ia.IncidentId = ir.IncidentId.Value;
                ia.Save();
                AddActionsGridRow(ia);
                ir.Actions.Add(ia);
                UpdateIncidentsGridRow(selectedRow, ir);
            }
            dgvActions.ClearSelection();
            SetupButtonStatus();
        }

        /// <summary>
        /// Update incidents grid row.
        /// </summary>
        private void UpdateIncidentsGridRow(int selectedRow, IncidentReport ir)
        {
            dgvIncidents.Rows[selectedRow].Cells["colActions"].Value = ir.Actions.Count;
            dgvIncidents.Rows[selectedRow].Cells["colClosedActions"].Value = ir.Actions.Where(r => r.State.StatusId == (int)Status.IncidentStatus.Close).Count();

            Boolean bClose = false;
            //close incident if all ctions closed
            if (ir.Actions.Count > 0 && ir.CheckAllActionsClosed())
            {
                ir.ReportStatus = new Status(Status.IncidentStatus.Close);
                ir.TimeClosed = MyDateTime.Now;
                dgvIncidents.Rows[selectedRow].Cells["colClosed"].Value = ir.TimeClosed;
                bClose = true;
            }
            ir.Save(bClose);
        }


        /// <summary>
        /// Handle form interaction to select action.
        /// </summary>
        private void dgvActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Check for header row click
            if (e.RowIndex != -1)
            {
                SetupButtonStatus();
            }
            this.Cursor = Cursors.Default;
        }




    }
}
