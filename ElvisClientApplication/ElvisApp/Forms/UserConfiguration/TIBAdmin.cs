using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.UserConfiguration
{
    public partial class TIBAdmin : Form
    {
        #region Variables
        private int indexNo; 
        private List<TIBReasonsView> rawTIBReasons;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the form TIBAdmin
        /// </summary>
        public TIBAdmin()
        {
            InitializeComponent();
            BuildDropDowns();
            dgvTIBAdmin.AutoGenerateColumns = false;
            BindDataGridView();
            CustomiseColours();
        }
        #endregion

        #region Events
        /// <summary>
        /// Resets the filters.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtReasonIndex.Text = string.Empty;
            SetDefaultDropDownIndex();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void TIBAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Search for reports using the user defined filters.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnExportToExcel.Enabled = false;
            GetReportData(GetFilter());
            BindDataGridView();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Displays AddReason.cs form as a dialog, with all fields 
        /// empty so a new TIB config reason can be added. 
        /// On return from the form, the grid view
        /// dgvTibAdmin will be updated with the new 
        /// record if the save was sucessful.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditTIBReason addNewTIBForm = new AddEditTIBReason())
            {
                if (addNewTIBForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    GetReportData(GetFilter());
                    BindDataGridView();
                };
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Excle export options dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            UserConfiguration.ExcelExport exportDialog = new UserConfiguration.ExcelExport();
            exportDialog.DataToExport = new List<TIBReasonsView>();
            exportDialog.DataToExport = rawTIBReasons;
            exportDialog.ShowDialog();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Upon navigating to a new row in dgvTIBAdmin, 
        /// the IndexNo variable is updated with the index of the 
        /// record in the respective row.
        /// </summary>
        private void dgvTIBAdmin_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            if (dgvTIBAdmin.SelectedRows.Count > 0 && dgvTIBAdmin.CurrentRow != null)
            {
                TIBReasonsView reason = dgvTIBAdmin.CurrentRow.DataBoundItem as TIBReasonsView;
                if (reason != null)
                {
                    btnEdit.Enabled = true;
                    this.indexNo = reason.ReasonIndex;
                }
            }
        }

        /// <summary>
        /// Calls the SHowEditForm() method when a cell in dgvTIBAdmin is double clicked.
        /// </summary>
        private void dgvTIBAdmin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowEditForm();
        }

        /// <summary>
        /// TIB Admin Data Gridview Key Down event handler. Opens the Edit form.
        /// </summary>
        private void dgvTIBAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                ShowEditForm();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Edit button event handler. Opens the Edit TIB reason form.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlFilter.BackColor =
                grpFilter.BackColor = 
                pnlSearchCriteria.BackColor =
                grpSearchCriteria.BackColor =
                pnlAdmin.BackColor =
                grpAdmin.BackColor = 
                pnlGridviewButtons.BackColor = 
                dgvTIBAdmin.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlFilter.ForeColor =
                grpFilter.ForeColor =
                pnlSearchCriteria.ForeColor =
                grpSearchCriteria.ForeColor =
                pnlAdmin.ForeColor =
                grpAdmin.ForeColor =
                pnlGridviewButtons.ForeColor =
                    Settings.Default.ColourText;
        }
        
        /// <summary>
        /// Controlling method for building the form search drop downs.
        /// </summary>
        private void BuildDropDowns()
        {
            BuildDelayDropDowns();
            BuildOtherDropDowns();
            SetDefaultDropDownIndex();
        }

        /// <summary>
        /// Builds the 4 DelayReporting field dropdowns in the Advanced Search group box.
        /// </summary>
        private void BuildDelayDropDowns()
        {
            string filter = string.Empty;
            cboDelayReason1.Items.Add("All");
            cboDelayReason1.Items.AddRange(EntityHelper.TIBReasons.GetColumnData("it.DelayReason1")
               .DistinctBy(d => d.DelayReason1)
               .Where(a => a.DelayReason1 != null)
               .OrderBy(o => o.DelayReason1)
               .Select(p => p.DelayReason1)
               .ToList().ToArray());
            cboDelayReason1.SelectedIndex = -1;

            cboDelayReason2.Items.Add("All");
            cboDelayReason2.Items.AddRange(EntityHelper.TIBReasons.GetColumnData("it.DelayReason2")
                .DistinctBy(d => d.DelayReason2)
                .Where(a => a.DelayReason2 != null)
                .OrderBy(o => o.DelayReason2)
                .Select(p => p.DelayReason2)
                .ToList().ToArray());
            cboDelayReason2.SelectedIndex = -1;

            cboDelayReason3.Items.Add("All");
            cboDelayReason3.Items.AddRange(EntityHelper.TIBReasons.GetColumnData("it.DelayReason3")
                .DistinctBy(d => d.DelayReason3)
                .Where(a => a.DelayReason3 != null)
                .OrderBy(o => o.DelayReason3)
                .Select(p => p.DelayReason3)
                .ToList().ToArray());
            cboDelayReason3.SelectedIndex = -1;

            cboDelayReason4.Items.Add("All");
            cboDelayReason4.Items.AddRange(EntityHelper.TIBReasons.GetColumnData("it.DelayReason4")
                .DistinctBy(d => d.DelayReason4)
                .Where(a => a.DelayReason4 != null)
                .OrderBy(o => o.DelayReason4)
                .Select(p => p.DelayReason4)
                .ToList().ToArray());
            cboDelayReason4.SelectedIndex = -1;
        }

        /// <summary>
        /// Builds al other drop downs in the Advanced Search group box.
        /// </summary>
        private void BuildOtherDropDowns()
        {
            List<Unit> unitData = new List<Unit>();
            List<TibClassLookUp> classData = new List<TibClassLookUp>();
            List<TibCategoryLookUp> categoryData = new List<TibCategoryLookUp>();
            List<TibDisciplineLookUp> disciplineData = new List<TibDisciplineLookUp>();
            cboPlantArea.Items.Add("All");
            cboPlantArea.Items.AddRange(EntityHelper.TIBReasons.GetColumnData("it.PlantArea")
              .DistinctBy(r => r.PlantArea)
              .Where(r => r.PlantArea != null)
              .OrderBy(r => r.PlantArea)
              .Select(r => r.PlantArea)
              .ToList().ToArray());

            unitData.Add(new Unit { UnitGroupNumber = -1, UnitGroupText = "All"});
            unitData.AddRange(EntityHelper.Units.GetAll().DistinctBy(u => u.UnitGroupNumber)
                .OrderBy(u => u.UnitGroupText).ToList());
            cboUnit.DataSource = unitData;
            cboUnit.DisplayMember = "UnitGroupText";
            cboUnit.ValueMember = "UnitGroupNumber";
            
            classData.Add(new TibClassLookUp { TIBClassIndex = 0, TIBClassText = "All" });
            classData.AddRange(EntityHelper.TibClassLookUp.GetAll().OrderBy(c => c.TIBClassText).ToList());
            cboDelayClass.DataSource = classData;
            cboDelayClass.DisplayMember = "TIBClassText";
            cboDelayClass.ValueMember = "TIBClassIndex";
            
            categoryData.Add(new TibCategoryLookUp { TIBCategoryIndex = 0, TIBCategoryText = "All" });
            categoryData.AddRange(EntityHelper.TibCategoryLookUp.GetAll().OrderBy(c => c.TIBCategoryText).ToList());
            cboDelayCategory.DataSource = categoryData;
            cboDelayCategory.DisplayMember = "TIBCategoryText";
            cboDelayCategory.ValueMember = "TIBCategoryIndex";
            
            disciplineData.Add(new TibDisciplineLookUp { TIBDisIndex = 0, TIBDisText = "All" });
            disciplineData.AddRange(EntityHelper.TibDisciplineLookUp.GetAll().OrderBy(d => d.TIBDisText).ToList());
            cboDiscipline.DataSource = disciplineData;
            cboDiscipline.DisplayMember = "TIBDisText";
            cboDiscipline.ValueMember = "TIBDisIndex";
        }

        /// <summary>
        /// Sets the selected index of each dropdown in the Advanced Search group box to 0 (displays the value "All").
        /// </summary>
        private void SetDefaultDropDownIndex()
        {
            ComboBox cbo = new ComboBox();
            foreach (Control ctrl in tblSearchOptions.Controls)
            {
                if (ctrl is ComboBox)
                {
                    cbo = (ComboBox)ctrl;
                    cbo.SelectedIndex = 0;
                }
            }
        }
        
        /// <summary>
        /// Binds the Data Griview.
        /// </summary>
        private void BindDataGridView()
        {
            if (this.rawTIBReasons != null)
            {
                dgvTIBAdmin.DataSource = null;
                dgvTIBAdmin.DataSource = this.rawTIBReasons;
                lblRecordsReturned.Text = dgvTIBAdmin.Rows.Count + " Records Returned";
                btnExportToExcel.Enabled = true;
            }
        }

        /// <summary>
        /// Gets the report data for the form.
        /// </summary>
        /// <param name="filter">The filter you wish to apply to the data.</param>
        private void GetReportData(string filter)
        {
            try
            {
                this.rawTIBReasons = EntityHelper.TIBReasonsView.GetByFilter(filter).OrderBy(t => t.DelayIndex).ToList();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetReportData() -- Error getting tib reasons on TIBAdmin form -- ", 
                    ex);
            }
        }

        /// <summary>
        /// Build filter for the form.
        /// </summary>
        /// <returns>A filter in string to be used on the getting of the data.</returns>
        private string GetFilter()
        {
            StringBuilder sbFilter = new StringBuilder();

            if (txtReasonIndex.Text != string.Empty)
            {
                sbFilter.AppendFormat("it.ReasonIndex == {0}", Convert.ToInt16(txtReasonIndex.Text));
            }

            if (cboDelayReason1.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");
                sbFilter.AppendFormat("it.DelayReason1  == \"{0}\"", cboDelayReason1.Text);
            }

            if (cboDelayReason2.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.DelayReason2  == \"{0}\"", cboDelayReason2.Text);
            }

            if (cboDelayReason3.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.DelayReason3  == \"{0}\"", cboDelayReason3.Text);
            }

            if (cboDelayReason4.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.DelayReason4  == \"{0}\"", cboDelayReason4.Text);
            }

            if (cboPlantArea.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.PlantArea == \"{0}\"", cboPlantArea.Text);
            }

            if (cboUnit.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.UnitGroup == {0}", Convert.ToInt16(cboUnit.SelectedValue));
            }

            if (cboDiscipline.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.Discipline == {0}", Convert.ToInt16(cboDiscipline.SelectedValue));
            }

            if (cboDelayClass.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.DelayClass == {0}", Convert.ToInt16(cboDelayClass.SelectedValue));
            }

            if (cboDelayCategory.SelectedIndex > 0)
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.Category == {0}", Convert.ToInt16(cboDelayCategory.SelectedValue));
            }

            if (string.IsNullOrEmpty(sbFilter.ToString()))
                sbFilter.Append("1 = 1");//Errors if no string input into filter.

            return sbFilter.ToString();
        }

        /// <summary>
        /// Displays AddReason.cs as a dialog, complete with the data from the TIBReason record identified by the IndexNo variable. If the data
        /// is changed on the form successfully the gridview dgvTIBAdmin will be updated with the changes.
        /// </summary>
        private void ShowEditForm()
        {
            using (AddEditTIBReason form = new AddEditTIBReason(indexNo))
            {
                this.Cursor = Cursors.WaitCursor;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    GetReportData(GetFilter());
                    BindDataGridView();
                };
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Key Press event handler for the index field.
        /// Stops users entering anything but a number.
        /// </summary>
        private void txtReasonIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks input for numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        //private void ShowAddEditConfigItem(string itemType)
        //{
        //    AddEditTIBConfigItem configItemDialog = new AddEditTIBConfigItem();
        //    configItemDialog.Text = "Edit " + itemType;
        //    configItemDialog.ShowDialog();
        //}

        //private void tIBCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowAddEditConfigItem("TIB Categories");
        //}
        #endregion       
    }
}
