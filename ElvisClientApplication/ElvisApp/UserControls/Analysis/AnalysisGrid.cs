using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elvis.UserControls.Analysis
{
    public partial class AnalysisGrid : UserControl
    {
        #region Variables
        private int heatNumber;
        private int heatNumberSet;
        private int unitNumber = 0;
        private int extendUnitNumber = 0;
        private int aimsRowIndexMax = 0;
        private int aimsRowIndexMin = 0;
        private int extendAimsRowIndexMax = 0;
        private int extendAimsRowIndexMin = 0;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region 
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HeatNumber
        {
            get { return this.heatNumber; }
            set
            {
                this.heatNumber = value;
                GetAnalysisAimData();
                GetAnalysisData();
                GetExtendedAimsData();
                GetExtendedAnalysisData();
                ClearGridviewSelections();
                FormatDataGridViews();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates the Analysis Grid User Control for a specific heat.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        /// <param name="isFullAnalysis">Gives you the full analysis page (true) or only half (false) for a smaller control</param>
        public AnalysisGrid(int heatNumber, int heatNumberSet)
        {
            InitializeComponent();
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;

            dgvAimAnalysis.AutoGenerateColumns = false;
            dgvAnalysis.AutoGenerateColumns = false;
            dgvExtendedAims.AutoGenerateColumns = false;
            dgvExtendedAnalysis.AutoGenerateColumns = false;

            BindDropDowns();
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
                dgvAimAnalysis.BackgroundColor =
                dgvAnalysis.BackgroundColor =
                dgvExtendedAims.BackgroundColor =
                dgvExtendedAnalysis.BackgroundColor =
                grpAimsAnal.BackColor =
                grpAnalysis.BackColor =
                grpAimsExtAnal.BackColor =
                grpExtAnal.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                grpAimsAnal.ForeColor =
                grpAnalysis.ForeColor =
                grpAimsExtAnal.ForeColor =
                grpExtAnal.ForeColor =
                    Settings.Default.ColourText;
        }

        #region Events
        //Clears the default selected row on form load
        private void AnalysisGrid_Load(object sender, EventArgs e)
        {
            ClearGridviewSelections();
        }
        //Refreshes the data on List Item Change
        private void ddlAims_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ddlAims.Items.Count > 0)
            {
                int.TryParse(ddlAims.SelectedValue.ToString(), out this.unitNumber);
                GetAnalysisAimData();
                GetAnalysisData();
                ClearGridviewSelections();
                FormatDataGridViews();
            }
        }
        //Refreshes the data on List Item Change
        private void ddlExtAims_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ddlExtAims.Items.Count > 0)
            {
                int.TryParse(ddlExtAims.SelectedValue.ToString(), out this.extendUnitNumber);
                GetExtendedAimsData();
                GetExtendedAnalysisData();
                ClearGridviewSelections();
                FormatDataGridViews();
            }
        }
        #endregion

        #region Get Data
        private void GetAnalysisAimData()
        {
            try
            {
                dgvAimAnalysis.DataSource =
                    EntityHelper.AimsAnalysisGridData.GetByHeatAndUnit(
                        this.heatNumber, this.heatNumberSet, this.unitNumber);
                dgvAimAnalysis.Refresh();

                this.aimsRowIndexMax = GetRowIndex("Max", dgvAimAnalysis);
                this.aimsRowIndexMin = GetRowIndex("Min", dgvAimAnalysis);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetAnalysisAimData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet +
                    ", unitNumber = " + this.unitNumber + ")", ex);
            }
        }

        private void GetAnalysisData()
        {
            try
            {
                dgvAnalysis.DataSource =
                    EntityHelper.AnalysisGridData.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
                dgvAnalysis.Refresh();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetAnalysisData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
            }
        }

        private void GetExtendedAimsData()
        {
            try
            {
                dgvExtendedAims.DataSource =
                    EntityHelper.AimsExtendAnalysisGridData.GetByHeatAndUnit(
                        this.heatNumber, this.heatNumberSet, this.extendUnitNumber);
                dgvExtendedAims.Refresh();

                this.extendAimsRowIndexMax = GetRowIndex("Max", dgvExtendedAims);
                this.extendAimsRowIndexMin = GetRowIndex("Min", dgvExtendedAims);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetExtendedAimsData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet +
                    ", unitNumber = " + this.unitNumber + ")", ex);
            }
        }

        private void GetExtendedAnalysisData()
        {
            try
            {
                dgvExtendedAnalysis.DataSource =
                    EntityHelper.ExtendAnalysisGridData.GetByHeat(
                        this.heatNumber, this.heatNumberSet);
                dgvExtendedAnalysis.Refresh();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetExtendedAnalysisData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
            }
        }

        private void BindDropDowns()
        {
            List<AimUnit> aimUnits = new List<AimUnit>();
            List<AimUnit> extAimUnits = new List<AimUnit>();
            try
            {
                aimUnits = EntityHelper.AimUnits.GetAll();
                extAimUnits = EntityHelper.AimUnits.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetExtendedAnalysisData(heatNumber = " + this.heatNumber +
                    ", heatNumberSet = " + this.heatNumberSet + ")", ex);
            }

            if (aimUnits != null && aimUnits.Count > 0)
            {
                ddlAims.DataSource = aimUnits;
                ddlAims.DisplayMember = "UnitText";
                ddlAims.ValueMember = "UnitNumber";

                //Sets the ddl to default of Caster
                if (ddlAims.SelectedText != "Caster")
                    ddlAims.SelectedIndex = ddlAims.FindStringExact("Caster");

                ddlExtAims.DataSource = extAimUnits;
                ddlExtAims.DisplayMember = "UnitText";
                ddlExtAims.ValueMember = "UnitNumber";

                //Sets the ddl to default of Caster
                if (ddlExtAims.SelectedText != "Caster")
                    ddlExtAims.SelectedIndex = ddlExtAims.FindStringExact("Caster");
            }
        }
        #endregion

        #region DataGridview Methods and Events
        //Sets the height and visibility of the Data Grid Views
        private void FormatDataGridViews()
        {
            Colours.FormatGridview(dgvAimAnalysis);
            Colours.FormatGridview(dgvAnalysis);
            Colours.FormatGridview(dgvExtendedAims);
            Colours.FormatGridview(dgvExtendedAnalysis);
        }

        //Event that occurs when data is added to DGV. Formats the cells accordingly
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;//Get Gridview
                double cellValue = 0;
                if (dgv.Columns[e.ColumnIndex].HeaderText != "Sample No." &&
                    e.Value != null &&
                    double.TryParse(e.Value.ToString(), out cellValue))
                {
                    string columnName = dgv.Columns[e.ColumnIndex].Name;
                    string type = "";//Default Colour Scheme

                    if (cellValue == 0)//Remove Value if zero
                    {
                        dgv.Rows[e.RowIndex].Cells[columnName].Value = "";
                        return;
                    }
                    if (dgv.Name.Contains("Aim"))//Aim Gridviews
                    {
                        if (dgv.Name.Contains("Extend"))//Extended Aims
                        {
                            if (e.RowIndex == this.extendAimsRowIndexMax ||
                                e.RowIndex == this.extendAimsRowIndexMin)//Max Min
                                type = "MaxMin";
                            else//Aim
                                type = "Aim";
                        }
                        else//Normal Aims
                        {
                            if (e.RowIndex == this.aimsRowIndexMax ||
                                e.RowIndex == this.aimsRowIndexMin)//Max Min
                                type = "MaxMin";
                            else//Aim
                                type = "Aim";
                        }
                    }
                    else//Normal Gridviews
                    {
                        double maxValue = 0;
                        double minValue = 0;

                        if (dgv.Name.Contains("Extend"))
                        {//Extended Aims Analysis
                            maxValue = GetTargetValue(
                                columnName,
                                this.extendAimsRowIndexMax,
                                dgvExtendedAims);

                            minValue = GetTargetValue(
                                columnName,
                                this.extendAimsRowIndexMin,
                                dgvExtendedAims);
                        }
                        else
                        {//Aims Analysis
                            maxValue = GetTargetValue(
                                        columnName,
                                        this.aimsRowIndexMax,
                                        dgvAimAnalysis);

                            minValue = GetTargetValue(
                                        columnName,
                                        this.aimsRowIndexMin,
                                        dgvAimAnalysis);
                        }

                        if (maxValue != 0 && cellValue > maxValue) //AboveMax
                            type = "AboveMax";
                        else if (minValue != 0 && cellValue < minValue) //BelowMin
                            type = "BelowMin";
                    }
                    e.CellStyle.ForeColor =
                        Colours.GetAnalysisCellColour(type, true);
                    e.CellStyle.BackColor =
                        Colours.GetAnalysisCellColour(type, false);
                }
                else
                {
                    e.CellStyle.ForeColor =
                        Colours.GetAnalysisCellColour("Text", true);
                    e.CellStyle.BackColor =
                        Colours.GetAnalysisCellColour("", false);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR -- AnalysisGrid -- dgv_CellFormatting() -- ", ex);
            }
        }

        //Gets the Target Value 
        private double GetTargetValue(string columnName, int rowIndex, DataGridView dgv)
        {
            double targetValue = 0;

            if (dgv.Columns.Count > 0 && dgv.Rows.Count > 0)
            {
                try
                {
                    if (dgv.Rows[rowIndex].Cells[columnName + "Target"].Value != null &&
                        double.TryParse(
                        dgv.Rows[rowIndex].Cells[columnName + "Target"].Value.ToString(),
                        out targetValue))
                    {
                        return targetValue;
                    }
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }

        //Clears the Gridviews Selections
        private void ClearGridviewSelections()
        {
            dgvAnalysis.ClearSelection();
            dgvAimAnalysis.ClearSelection();
            dgvExtendedAnalysis.ClearSelection();
            dgvExtendedAims.ClearSelection();
        }

        /// <summary>
        /// Used to find the row index of Max or Min Rows
        /// </summary>
        /// <param name="type">The Row of Index of either "Max" or "Min"</param>
        /// <param name="dgv">The Data Gridview</param>
        /// <returns>Row Index as int</returns>
        private int GetRowIndex(string type, DataGridView dgv)
        {
            try
            {
                if (dgv.Name.Contains("Extend"))
                {
                    DataGridViewRow row =
                        dgv.Rows.Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Cells["TypeTarget"].Value.ToString() == type);
                    return row.Index;
                }
                else
                {
                    DataGridViewRow row =
                        dgv.Rows.Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Cells["Type"].Value.ToString() == type);
                    return row.Index;
                }
            }
            catch
            {
                return -1;//No Value in Type
            }
        }

        /// <summary>
        /// Sets up the column header font after binding is complete.
        /// </summary>
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CommonMethods.FormatColumnFont(
                sender as DataGridView,
                new Font("Microsoft Sans Serif", 8, FontStyle.Regular));
        }
        #endregion

        #endregion

        #region Support Classes
        /// <summary>
        /// Used to Create an Item that can be added to a 
        /// windows forms combo box
        /// </summary>
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public ComboboxItem(string text, string value)
            {
                this.Text = text;
                this.Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
        #endregion
    }
}
