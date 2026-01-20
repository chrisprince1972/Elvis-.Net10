using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Tib;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System.Drawing;
using System.ComponentModel;

namespace Elvis.Forms.Reports.DRF
{
    public partial class DRFMain : Form
    {
        #region Variables
        private int selectedDRFIndex;
        private DateTime dateFrom;
        private DateTime dateTo;
        private List<DRFLocationLookUp> locationsFull;
        private List<DRFDropDownLookUp> lookUpFull;
        private List<DRFOwner> ownersFull;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public DRFMain(BusinessLogic.Constants.DrfWorksArea autoWorksArea = BusinessLogic.Constants.DrfWorksArea.All)
        {
            InitializeComponent();
            SetupDateSelector();
            InitialDateSetup(DateTime.Now);
            SetupWeekNo();
            GetDropDownData();
            BindDropDowns();
            SetupForm(autoWorksArea);
            List<DRFReport> drfReports = GetReportData(GetFilter());
            List<DRFActionDisplay> drfActions = GetDrfActionsData(drfReports);
            BindDataGridView(drfReports, drfActions);
            BindReportView(drfReports);
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
                dgvReports.BackgroundColor =
                grpFilter.BackColor =
                grpFormat.BackColor =
                grpDateSelector.BackColor =
                grpStatus.BackColor =
                grpAdvancedSearch.BackColor =
                chbAdvanced.BackColor =
                grpReports.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                dgvReports.ForeColor =
                grpFilter.ForeColor =
                grpFormat.ForeColor =
                grpDateSelector.ForeColor =
                grpStatus.ForeColor =
                grpAdvancedSearch.ForeColor =
                chbAdvanced.ForeColor =
                grpReports.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Enables or disables the date filters depending on the 
        /// radio button selected.
        /// </summary>
        private void SetupDateSelector()
        {
            lblFrom.Enabled = dpFrom.Enabled =
            lblTo.Enabled = dpTo.Enabled =
                rbDate.Checked;

            lblDay.Enabled = numDay.Enabled =
            lblWeek.Enabled = numWeek.Enabled =
            lblYear.Enabled = numYear.Enabled =
                !rbDate.Checked;

            lblDay.Enabled = numDay.Enabled =
                rbDaily.Checked;
        }

        /// <summary>
        /// Sets the number picker for the year.
        /// </summary>
        private void InitialDateSetup(DateTime dt)
        {
            dt = dt.AddDays(-1);

            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)dt.DayOfWeek + 1;
            numWeek.Value = dt.WeekOfYear();
            numYear.Maximum = numYear.Value = dt.Year;
            numYear.Minimum = dt.Year - 5;
        }

        /// <summary>
        /// Checks for a week 53 in the currently selected year and 
        /// sets the number picker accordingly.
        /// </summary>
        private void SetupWeekNo()
        {
            if (DateTimeExtensions.IsWeek53Valid(Convert.ToInt16(numYear.Value)))
                numWeek.Maximum = 53;
            else
                numWeek.Maximum = 52;
        }

        /// <summary>
        /// Updates the date text on the form for the group boxes.
        /// </summary>
        private void UpdateDateLabel()
        {
            if (rbDate.Checked)
            {
                grpDateSelector.Text = "Date Selector";
            }
            else if (rbWeekly.Checked)
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,
                    07, 00, 00, 00));
            }
            else
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00));
            }
        }

        /// <summary>
        /// Binds the Drop Downs on the Form to the Data
        /// </summary>
        private void BindDropDowns()
        {
            cmboArea.DataSource = 
                Enumerable.DistinctBy(this.locationsFull,l => l.Works)
                .Select(s => s.Works)
                .ToList();
            cmboArea.DisplayMember = "Works";

            BindDynamicDropDowns();

            cmboDelayType.DataSource = 
                Enumerable.DistinctBy(this.lookUpFull,l => l.DelayType)
                .Where(l => l.DelayType != null)
                .Select(s => s.DelayType)
                .ToList();
            cmboDelayType.DisplayMember = "DelayType";

            cmboDiscipline.DataSource = 
                Enumerable.DistinctBy(this.lookUpFull,l => l.Discipline)
                .Where(l => l.Discipline != null)
                .Select(s => s.Discipline)
                .ToList();
            cmboDiscipline.DisplayMember = "Discipline";
        }

        /// <summary>
        /// Binds the dynamic drop downs
        /// </summary>
        private void BindDynamicDropDowns()
        {
            cmboUnits.DataSource = null;
            if (chbGroupUnits.Checked)
            {//Grouped Units
                if (cmboArea.Text == "All")
                {
                    cmboUnits.DataSource = 
                        Enumerable.DistinctBy(this.locationsFull,l => l.UnitGroup)
                        .Where(l => l.UnitGroup != null)
                        .Select(s => s.UnitGroup)
                        .ToList();
                }
                else
                {
                    cmboUnits.DataSource = 
                        Enumerable.DistinctBy(this.locationsFull,l => l.UnitGroup)
                        .Where(l => l.UnitGroup != null)
                        .Where(l => l.Works == cmboArea.Text ||
                                    l.Works == "All")
                        .Select(s => s.UnitGroup)
                        .ToList();
                }
                cmboUnits.DisplayMember = "UnitGroup";
            }
            else
            {//Ungrouped Units
                if (cmboArea.Text == "All")
                {
                    cmboUnits.DataSource = 
                        Enumerable.DistinctBy(this.locationsFull,l => l.Location)
                        .Select(s => s.Location)
                        .ToList();
                }
                else
                {
                    cmboUnits.DataSource = 
                        Enumerable.DistinctBy(this.locationsFull,l => l.Location)
                        .Where(l => l.Works == cmboArea.Text ||
                                    l.Works == "All")
                        .Select(s => s.Location )
                        .ToList();
                }
                cmboUnits.DisplayMember = "Location";
            }

            if (cmboArea.Text == "All")
            {
                cmboOwner.DataSource = this.ownersFull
                    .Select(s => s.Owner)
                    .ToList();
            }
            else
            {
                cmboOwner.DataSource = this.ownersFull
                    .Where(o => o.Works == cmboArea.Text ||
                                o.Works == "All")
                    .Select(s => s.Owner)
                    .ToList();
            }
            cmboOwner.DisplayMember = "Owner";

            BindPlantItems();
        }

        /// <summary>
        /// Binds the Plant Items depending on the other selections made 
        /// by the user.
        /// </summary>
        private void BindPlantItems()
        {
            if (cmboArea.Text == "All" &&
                cmboUnits.Text == "All")
            {//No Filter
                cmboPlant.DataSource = this.locationsFull
                    .Select(s => s.PlantItem)
                    .ToList();
            }
            else if (cmboArea.Text == "All")
            {//Filter only on works location (unit)
                if (chbGroupUnits.Checked)
                {//Grouped
                    cmboPlant.DataSource = this.locationsFull
                        .Where(l => (l.UnitGroup == cmboUnits.Text ||
                                     l.UnitGroup == "All"))
                        .Select(s => s.PlantItem)
                        .ToList();
                }
                else
                {//Ungrouped
                    cmboPlant.DataSource = this.locationsFull
                        .Where(l => (l.Location == cmboUnits.Text ||
                                     l.Location == "All"))
                        .Select(s => s.PlantItem)
                        .ToList();
                }
            }
            else if (cmboUnits.Text == "All")
            {//Filter on only area
                cmboPlant.DataSource = this.locationsFull
                    .Where(l => (l.Works == cmboArea.Text ||
                                 l.Works == "All"))
                    .Select(s => s.PlantItem)
                    .ToList();
            }
            else
            {//Filter on both
                if (chbGroupUnits.Checked)
                {//Grouped
                    cmboPlant.DataSource = this.locationsFull
                        .Where(l => (l.Works == cmboArea.Text ||
                                     l.Works == "All") &&
                                    (l.UnitGroup == cmboUnits.Text ||
                                     l.UnitGroup == "All"))
                        .Select(s => s.PlantItem)
                        .ToList();
                }
                else
                {//Ungrouped
                    cmboPlant.DataSource = this.locationsFull
                        .Where(l => (l.Works == cmboArea.Text ||
                                     l.Works == "All") &&
                                    (l.Location == cmboUnits.Text ||
                                     l.Location == "All"))
                        .Select(s => s.PlantItem)
                        .ToList();
                }
            } 
            cmboPlant.DisplayMember = "PlantItem";
        }

        /// <summary>
        /// Gets all of the drop down data from the database.
        /// </summary>
        private void GetDropDownData()
        {
            this.locationsFull = EntityHelper.DRFLocationLookUp.GetAll();
            this.locationsFull.Insert(0,
                    new DRFLocationLookUp()
                    {
                        Works = "All",
                        Location = "All",
                        PlantItem = "All",
                        UnitGroup = "All"
                    }
                );

            this.lookUpFull = EntityHelper.DRFDropDownLookUp.GetAll();
            this.lookUpFull.Insert(0,
                    new DRFDropDownLookUp()
                    {
                        DelayType = "All",
                        Discipline = "All",
                        Rota = "All",
                        Shift = "All"
                    }
                );

            this.ownersFull = EntityHelper.DRFOwners.GetAll();
            this.ownersFull.Insert(0,
                    new DRFOwner()
                    {
                        Works = "All",
                        Owner = "All"
                    }
                );
        }

        /// <summary>
        /// Build filter for the form.
        /// </summary>
        /// <returns>A filter in string to be used on the getting of the data.</returns>
        /// 
        private string GetFilter()
        {
            StringBuilder sbFilter = new StringBuilder();
            this.dateFrom = GetFromDate();
            this.dateTo = GetToDate();

            if (rbOpen.Checked)
            {//Only Opened
                sbFilter.Append("it.ReportStatus = 0");
            }
            else if (rbClosed.Checked)
            {//Only Closed
                sbFilter.Append("it.ReportStatus = 1");
            }

            if (chbAdvanced.Checked)
            {
                string advancedFilter = BuildAdvancedFilter();
                if (!string.IsNullOrEmpty(advancedFilter))
                {
                    if (sbFilter.Length > 0 && advancedFilter.Length > 0)
                        sbFilter.Append(" AND ");
                    sbFilter.Append(advancedFilter);
                }
            }

            if (string.IsNullOrEmpty(sbFilter.ToString()))
                sbFilter.Append("1 = 1");//Errors if no string input into filter.

            return sbFilter.ToString();
        }

        /// <summary>
        /// Build filter for searching by DRF Index
        /// </summary>
        /// <param name="drfIndex">The DRF Index to search for.</param>
        /// <returns>A filter in string to be used on the getting of the data.</returns>
        private string GetFilterByDRFIndex(int drfIndex)
        {
            StringBuilder sbFilter = new StringBuilder();
            this.dateFrom = GetFromDate();
            this.dateTo = GetToDate();

            sbFilter.AppendFormat("it.DRFIndex = {0}", drfIndex);

            return sbFilter.ToString();
        }

        private string AppendComboBoxToFilter(StringBuilder filter, string filterName, ComboBox cmbo)
        {
            string returnValue = string.Empty;
            if (cmbo.Items.Count > 0 &&
                cmbo.Text != "All")
            {
                filter.AppendFormat("{0} it.{1} == \"{2}\"", 
                    filter.Length > 0 ? " AND " : string.Empty,
                    filterName, cmbo.Text);
            }
            return returnValue;
        }

        /// <summary>
        /// Generates the filter needed for the advanced filtering options.
        /// </summary>
        /// <returns>A string containing the advanced filter.</returns>
        private string BuildAdvancedFilter()
        {
            StringBuilder sbFilter = new StringBuilder();

            AppendComboBoxToFilter(sbFilter, "Works", cmboArea);

            if (cmboUnits.Items.Count > 0 &&
                cmboUnits.Text != "All")
            {
                if (sbFilter.Length > 0)
                {
                    sbFilter.Append(" AND ");
                }

                if (chbGroupUnits.Checked)
                {//Grouped units
                    sbFilter.Append(GetGroupedUnitFilter());
                }
                else
                {//Ungrouped units
                    sbFilter.AppendFormat("it.Location == \"{0}\"", cmboUnits.Text);
                }
            }

            AppendComboBoxToFilter(sbFilter, "PlantItem", cmboPlant);
            AppendComboBoxToFilter(sbFilter, "OwnerName", cmboOwner);
            AppendComboBoxToFilter(sbFilter, "Discipline", cmboDiscipline);
            AppendComboBoxToFilter(sbFilter, "DelayType", cmboDelayType);

            return sbFilter.ToString();
        }

        /// <summary>
        /// Generates the filtering data for grouped filtering.
        /// </summary>
        /// <returns>A string for filtering group data.</returns>
        private string GetGroupedUnitFilter()
        {
            StringBuilder filter = new StringBuilder();
            List<string> ungroupedList = GetUngroupedUnits(cmboUnits.Text);
            string lastUnit = ungroupedList.Last();

            filter.Append("(");//Open bracket for Nested OR Statements

            foreach (string unit in ungroupedList)
            {
                if (unit.Equals(lastUnit))
                {
                    filter.AppendFormat("it.Location == \"{0}\")", unit);
                }
                else
                {
                    filter.AppendFormat("it.Location == \"{0}\" OR ", unit);
                }
            }

            if (filter.Length > 1)
            {
                return filter.ToString();
            }
            return "";
        }

        /// <summary>
        /// Gets the locations associated with each group.
        /// </summary>
        /// <param name="group">The groupe selected.</param>
        /// <returns>A string list that contains the individual location items.</returns>
        private List<string> GetUngroupedUnits(string group)
        {
            if (this.locationsFull != null &&
                this.locationsFull.Count > 0)
            {
                return 
                    Enumerable.DistinctBy(this.locationsFull,l => l.Location)
                    .Where(l => l.UnitGroup == group)
                    .Select(l => l.Location)
                    .ToList();
            }
            return new List<string>();
        }

        /// <summary>
        /// Gets the Date From using the date selectors.
        /// </summary>
        /// <returns>Date from for filter as DateTime</returns>
        private DateTime GetFromDate()
        {
            if (rbDaily.Checked)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00);
            }
            else if (rbWeekly.Checked)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,
                    07, 00, 00, 00);
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpFrom.Value.ToString("yyyy-MM-dd 07:00"));
        }

        /// <summary>
        /// Gets the Date To using the date selectors.
        /// </summary>
        /// <returns>Date To for filter as DateTime</returns>
        private DateTime GetToDate()
        {
            if (rbDaily.Checked)
            {
                return this.dateFrom.AddDays(1);
            }
            else if (rbWeekly.Checked)
            {
                return this.dateFrom.AddDays(7);
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpTo.Value.ToString("yyyy-MM-dd 07:00"));
        }

        /// <summary>
        /// Binds the Data Griview and shows the user the dates they selected
        /// using two labels.
        /// </summary>
        private void BindDataGridView(List<DRFReport> reports, List<DRFActionDisplay> drfActions)
        {
            lblFromDate.Text = "From - " + this.dateFrom.ToString("dd/MM/yyyy HH:mm");
            lblToDate.Text = "To - " + this.dateTo.ToString("dd/MM/yyyy HH:mm");
            dgvReports.DataSource = reports;
            dgvDrfActions.AutoGenerateColumns = false;
            dgvDrfActions.DataSource = drfActions;
            lblRecordsReturned.Text = string.Format("{0} DRF records returned.  {1} Actions records returned.",
                 dgvReports.Rows.Count, dgvDrfActions.Rows.Count);
        }

        /// <summary>
        /// Binds the Data ReportView 
        /// </summary>
        private void BindReportView(List<DRFReport> reports)
        {
            if (reports != null && reports.Count > 0)
            {
                DRFReportBindingSource.DataSource = reports;
                this.rptPrintExport.RefreshReport();
            }
        }

        /// <summary>
        /// Gets the report data for the form.
        /// </summary>
        /// <param name="filter">The filter you wish to apply to the data.</param>
        private List<DRFReport> GetReportData(string filter)
        {
            return EntityHelper.DRFReport
                .GetAllWithFilter(this.dateFrom, this.dateTo, filter);
        }

        /// <summary>
        /// Gets the action data for the form.
        /// </summary>
        private List<DRFActionDisplay> GetDrfActionsData(List<DRFReport> reports)
        {
            bool showAll = chbDrfShowAllActions.Checked;

            List<DRFActionDisplay> returnValue = new List<DRFActionDisplay>();
            if (reports != null)
            {
                foreach (DRFReport report in reports)
                {
                    returnValue.AddRange(
                        EntityHelper
                        .DRFActions
                        .GetByIndex(report.DRFIndex)
                        .Where(r => showAll || !r.ActionState)
                        .Select
                        (
                            ra => new DRFActionDisplay(ra, report.TIBDelayIndex)
                        ));
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Sets up the form.
        /// </summary>
        private void SetupForm(
            BusinessLogic.Constants.DrfWorksArea autoWorksArea = 
            BusinessLogic.Constants.DrfWorksArea.All)
        {

            dpFrom.MaxDate = DateTime.Now;
            dpTo.MaxDate = DateTime.Now.AddDays(2);
            dateFrom = dpFrom.Value = DateTime.Now.AddMonths(-1).AddDays(1);
            dateTo = dpTo.Value = DateTime.Now.AddDays(1);
            rbDaily.Checked = true;
            dgvReports.AutoGenerateColumns = false;
            dgvReports.Visible = true;
            rptPrintExport.Visible = false;

            if (autoWorksArea != BusinessLogic.Constants.DrfWorksArea.All)
            {
                chbAdvanced.Checked = true;
                cmboArea.SelectedIndex = (int)autoWorksArea;
            }
        }

        /// <summary>
        /// Edit the selected report in the gridview
        /// </summary>
        private void EditReportFromGridview()
        {
            try
            {
                if (dgvReports.SelectedRows.Count > 0 && dgvReports.CurrentRow != null)
                {
                    DRFReport report = dgvReports.CurrentRow.DataBoundItem as DRFReport;
                    if (report != null)
                    {
                        this.selectedDRFIndex = report.DRFIndex;

                        int tibDelayIndex = 0;//Get Tib Delay Index if one exists.
                        if (report.TIBDelayIndex.HasValue)
                            tibDelayIndex = report.TIBDelayIndex.Value;

                        if (this.selectedDRFIndex > 0 &&
                            CommonMethods.AddEditDRF(this.selectedDRFIndex, tibDelayIndex))
                        {
                            BindFromBasicFilter();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DRF EDIT ERROR -- dgvReports_CellDoubleClick() -- " +
                    "An error occurred when loading the edit DRF report popup -- ", ex);
            }
        }


        /// <summary>
        /// Edit the selected report in the action gridview
        /// </summary>
        private void EditReportFromActionGridview()
        {
            try
            {
                if (dgvDrfActions.SelectedRows.Count > 0 && dgvDrfActions.CurrentRow != null)
                {
                    DRFActionDisplay report = dgvDrfActions.CurrentRow.DataBoundItem as DRFActionDisplay;
                    if (report != null)
                    {
                        this.selectedDRFIndex = report.No;

                        int tibDelayIndex = 0;//Get Tib Delay Index if one exists.
                        if (report.TibDelayIndex.HasValue)
                            tibDelayIndex = report.TibDelayIndex.Value;

                        if (this.selectedDRFIndex > 0 &&
                            CommonMethods.AddEditDRF(this.selectedDRFIndex, tibDelayIndex))
                        {
                            BindFromBasicFilter();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DRF EDIT ERROR -- dgvReports_CellDoubleClick() -- " +
                    "An error occurred when loading the edit DRF report popup -- ", ex);
            }
        }

        private void BindFromBasicFilter()
        {
            List<DRFReport> drfReports = GetReportData(GetFilter());
            List<DRFActionDisplay> drfActions = GetDrfActionsData(drfReports);
            BindDataGridView(drfReports, drfActions);
        }

        #region Events
        /// <summary>
        /// Adds a DRF report in a new window.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (CommonMethods.AddEditDRF(0, 0))
            {
                BindFromBasicFilter();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Edits the selected DRF report in a new window.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.selectedDRFIndex > 0 &&
                CommonMethods.AddEditDRF(this.selectedDRFIndex, 0))
            {
                BindFromBasicFilter();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Enables or disables date pickers when changing the 
        /// format radio buttons
        /// </summary>
        private void rbFormat_CheckedChanged(object sender, EventArgs e)
        {
            SetupDateSelector();
            UpdateDateLabel();
        }

        /// <summary>
        /// Updates the visual date label in group box on value change.
        /// </summary>
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
        }

        /// <summary>
        /// Sets up week no everytime the year is changed to check for week 53.
        /// </summary>
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            SetupWeekNo();
            UpdateDateLabel();
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void DRFMain_KeyDown(object sender, KeyEventArgs e)
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
        /// Event for the Find Report Menu Item on the Form.
        /// Finds the report by DRF Index for quick reference.
        /// </summary>
        private void findReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FindReport findReport = new FindReport())
            {
                DialogResult result = findReport.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<DRFReport> drfReports = GetReportData(GetFilterByDRFIndex(findReport.DRFIndex));
                    List<DRFActionDisplay> drfActions = GetDrfActionsData(drfReports);
                    BindDataGridView(drfReports, drfActions);
                }
            }
        }

        /// <summary>
        /// Show/Hide the advanced search options
        /// </summary>
        private void chbAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            pnlAdvancedSearch.Visible = chbAdvanced.Checked;
            chbGroupUnits.Visible = chbAdvanced.Checked;
        }

        /// <summary>
        /// Find the row clicked and the index of that row and then
        /// display the edit report popup.
        /// </summary>
        private void dgvReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                EditReportFromGridview();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Key down event for gridview
        /// </summary>
        private void dgvReports_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                EditReportFromGridview();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Selection changed on the DataGridView event handler.
        /// </summary>
        private void dgvReports_SelectionChanged(object sender, EventArgs e)
        {
            editSelectedToolStripMenuItem.Enabled = false;
            btnEdit.Enabled = false;
            if (dgvReports.SelectedRows.Count > 0 && dgvReports.CurrentRow != null)
            {
                DRFReport report = dgvReports.CurrentRow.DataBoundItem as DRFReport;
                if (report != null)
                {
                    editSelectedToolStripMenuItem.Enabled = true;
                    btnEdit.Enabled = true;
                    this.selectedDRFIndex = report.DRFIndex;
                }
            }
        }

        /// <summary>
        /// Search for reports using the user defined filters.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<DRFReport> drfReports = GetReportData(GetFilter());
            List<DRFActionDisplay> drfActions = GetDrfActionsData(drfReports);
            BindDataGridView(drfReports, drfActions);
            BindReportView(drfReports);
        }

        /// <summary>
        /// Button reset event. Sets up the form back to original settings.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            rbDate.Checked = true;
            rbStatusBoth.Checked = true;

            InitialDateSetup(DateTime.Now);
            SetupWeekNo();
            SetupForm();

            foreach (Control ctrl in grpAdvancedSearch.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox cmboBox = ctrl as ComboBox;
                    if (cmboBox.Items.Count > 0)
                    {
                        cmboBox.SelectedItem = "All";
                    }
                }
            }

            List<DRFReport> drfReports = GetReportData(GetFilter());
            List<DRFActionDisplay> drfActions = GetDrfActionsData(drfReports);
            BindDataGridView(drfReports, drfActions);
            BindReportView(drfReports);
        }

        /// <summary>
        /// Filters the drop down lists when the area is changed.
        /// </summary>
        private void cmboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDynamicDropDowns();
        }

        /// <summary>
        /// Filters the drop down lists when the location is changed.
        /// </summary>
        private void cmboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPlantItems();
        }

        /// <summary>
        /// Changes the status of the records to text
        /// rather than 0 or 1.
        /// </summary>
        private void dgvReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvReports.Rows.Count > 0 &&
                dgvReports.Columns.Count > 0)
            {
                if (dgvReports.Rows[e.RowIndex].Cells["NoStatus"].Value != null)
                {
                    if (dgvReports.Rows[e.RowIndex].Cells["NoStatus"].Value.ToString() == "0")
                        dgvReports.Rows[e.RowIndex].Cells["Status"].Value = "Open";
                    else
                        dgvReports.Rows[e.RowIndex].Cells["Status"].Value = "Closed";
                }
                if (dgvReports.Rows[e.RowIndex].Cells["TIBDelayIndex"].Value != null)
                {
                    if (dgvReports.Rows[e.RowIndex].Cells["TIBDelayIndex"].Value.ToString() == "0")
                        dgvReports.Rows[e.RowIndex].Cells["TIBDelayIndex"].Value = "";
                }
            }
        }

        /// <summary>
        /// Content Click event for Data Gridview.
        /// Opens up the relevant tib delay for that DRF Report.
        /// </summary>
        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)//Tib Column
            {
                DRFReport report = dgvReports.CurrentRow.DataBoundItem as DRFReport;
                if (report != null && report.TIBDelayIndex.HasValue &&
                    report.TIBIndex.HasValue)
                {
                    using (DelayPopup delayPopup = new DelayPopup(
                        report.TIBIndex.Value,
                        report.TIBDelayIndex.Value,
                        0,
                        DateTime.Now))
                    {
                        DialogResult result = delayPopup.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            BindFromBasicFilter();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swaps out the gridview for a report viewer and vice versa, 
        /// depending on the selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportExportViewMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvReports.Visible = !reportExportViewMenuItem.Checked;
            rptPrintExport.Visible = reportExportViewMenuItem.Checked;
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void chbGroupUnits_CheckedChanged(object sender, EventArgs e)
        {
            BindDynamicDropDowns();
        }

        private void dgvDrfActions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvDrfActions != null)
            {
                dgvDrfActions.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                dgvDrfActions.AutoResizeColumns();
                dgvDrfActions.AutoResizeRows();

                foreach (DataGridViewRow row in dgvDrfActions.Rows)
                {
                    if (row.Cells["ActionState"].Value != null)
                    {
                        bool complete = Convert.ToBoolean(dgvDrfActions.Rows[row.Index].Cells["ActionState"].Value);
                        if (complete)
                        {
                            dgvDrfActions.Rows[row.Index].Cells["ActionComplete"].Value = Resources.GreenTickSmall;
                        }
                        else
                        {
                            dgvDrfActions.Rows[row.Index].Cells["ActionComplete"].Value = Resources.RedCrossSmall;
                        }
                    }
                }
            }
        }
        
        private void dgvDrfActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                EditReportFromActionGridview();
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvDrfActions_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EditReportFromActionGridview();
            }
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItemShowActions_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            pnlDrfActionResults.Visible = toolStripMenuItemShowActions.Checked;
            this.Cursor = Cursors.Default;
        }

        private void chbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            BindFromBasicFilter();
            this.Cursor = Cursors.Default;
        }


        #endregion
    }


    public class DRFActionDisplay
    {
        public int No { get; private set; }
        public string Name { get; private set; }
        public DateTime TargetDate { get; private set; }
        public string Owner { get; private set; }
        public bool State { get; private set; }
        public int? TibDelayIndex { get; private set; }

        public DRFActionDisplay(DRFAction action, int? tibDelayIndex)
        {
            No = 0;
            if (action.DRFIndex.HasValue)
            {
                No = action.DRFIndex.Value;
            }
            Name = action.Action;
            TargetDate = action.DRFIndex.HasValue ? action.TargetDate.Value : DateTime.MinValue;
            Owner = action.ActionOwner;
            State = action.ActionState;
            TibDelayIndex = tibDelayIndex;
        }
    }

}
