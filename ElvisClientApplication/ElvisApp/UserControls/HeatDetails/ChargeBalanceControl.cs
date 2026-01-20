using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.UserControls.HeatDetails
{
    public partial class ChargeBalanceControl : UserControl
    {
        #region Variables and Properties
        private int heatNumber;
        private int heatNumberSet;
        private bool pageError = false;
        private List<string> materialColumns;
        private List<CBMOverviewRow> overviewData;
        private List<CBMAnalysis1Row> analysis1Data;
        private List<CBMAnalysis2Row> analysis2Data;
        private List<CBMAnalysis3Row> analysis3Data;
        private List<CbmDisplayMaterial> displayMaterialData;
        private List<CbmDisplayAnalysis> displayAnalysisData;
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor and Form Setup
        /// <summary>
        /// Initializes a new instance of the CBM User Control class.
        /// </summary>
        public ChargeBalanceControl()
        {
            InitializeComponent();
            dgvCBMOverview.AutoGenerateColumns = false;
            dgvAnalysis1.AutoGenerateColumns = false;
            dgvAnalysis2.AutoGenerateColumns = false;
            dgvAnalysis3.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            CommonMethods.LoadImageIntoPanel(Resources.loadingBlack, this, pnlMain);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }

            ColourKey();
        }
        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
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
                pnlTop.BackColor =
                pnlBottom.BackColor =
                pnlKey.BackColor =
                grpKey.BackColor =
                grpOverview.BackColor =
                grpRunData.BackColor =
                pnlColourScheme.BackColor =
                grpColourScheme.BackColor =
                pnlAnalysis1.BackColor =
                pnlAnalysis2.BackColor =
                splitCentre.Panel2.BackColor =
                dgvCBMOverview.BackgroundColor =
                dgvAnalysis1.BackgroundColor =
                dgvAnalysis2.BackgroundColor =
                dgvAnalysis3.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlMain.ForeColor =
                pnlTop.ForeColor =
                pnlBottom.ForeColor =
                grpOverview.ForeColor =
                grpRunData.ForeColor =
                pnlKey.ForeColor =
                grpKey.ForeColor =
                pnlColourScheme.ForeColor =
                grpColourScheme.ForeColor =
                pnlAnalysis1.ForeColor =
                pnlAnalysis2.ForeColor =
                splitCentre.Panel2.ForeColor =
                    Settings.Default.ColourText;

            if (Settings.Default.CBMColourScheme.Equals("High Contrast"))
            {
                rbHighContrastColour.Checked = true;
            }
        }

        /// <summary>
        /// Colours the Key to match the Colour Settings.
        /// </summary>
        private void ColourKey()
        {
            pnlKeyLabels.BackColor = Colours.GetCBMOverviewCellColour(CBMType.Calculated, false);
            pnlKeyLabels.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.Calculated, true);

            lblCalculated.BackColor = Colours.GetCBMOverviewCellColour(CBMType.Calculated, false);
            lblCalculated.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.Calculated, true);

            lblConstrained.BackColor = Colours.GetCBMOverviewCellColour(CBMType.Constrained, false);
            lblConstrained.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.Constrained, true);

            lblPrepared.BackColor = Colours.GetCBMOverviewCellColour(CBMType.Prepared, false);
            lblPrepared.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.Prepared, true);
            lblPouredHM.BackColor = Colours.GetCBMOverviewCellColour(CBMType.PouredHM, false);
            lblPouredHM.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.PouredHM, true);

            lblActual.BackColor = Colours.GetCBMOverviewCellColour(CBMType.Actual, false);
            lblActual.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.Actual, true);
            lblDesulphHM.BackColor = Colours.GetCBMOverviewCellColour(CBMType.DesulphHM, false);
            lblDesulphHM.ForeColor = Colours.GetCBMOverviewCellColour(CBMType.DesulphHM, true);

            //Sets it to default colour.
            if (lblActual.BackColor == Color.White)
            {
                pnlKeyLabels.BackColor =
                    lblActual.BackColor =
                    lblConstrained.BackColor =
                    lblDesulphHM.BackColor =
                    lblPouredHM.BackColor =
                    lblPrepared.BackColor =
                    lblCalculated.BackColor =
                    Settings.Default.ColourBackground;
            }
        }

        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If all get datas fail then true, otherwise false.</returns>
        private bool GetData()
        {
            this.materialColumns = new List<string>();
            try
            {
                //Gets the Display Analysis Data
                this.displayAnalysisData = EntityHelper.CbmDisplayAnalysis.GetByHeat(
                    this.heatNumber,
                    this.heatNumberSet
                    );

                //Gets the Display Material Data
                this.displayMaterialData = EntityHelper.CbmDisplayMaterial.GetByHeat(
                    this.heatNumber,
                    this.heatNumberSet
                    );

                //Gets the Overview Data
                this.overviewData = ChargeBalance.GetCBMOverviewData(
                    this.heatNumber, this.heatNumberSet,
                    this.displayMaterialData, this.displayAnalysisData);

                //Builds a Material List to be used for Column Construction Later on.
                if (overviewData != null && materialColumns != null)
                {
                    //Loops each row of the data
                    foreach (CBMOverviewRow row in overviewData)
                    {
                        //Loops each material in each row
                        foreach (CBMMaterial material in row.MaterialList)
                        {
                            //if the material already exists, don't bother adding it
                            //This creates a distinct list of materials to be used as columns
                            if (!this.materialColumns.Contains(material.Name))
                            {
                                this.materialColumns.Add(material.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- CBM DATA -- GetData() -- ", ex);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the analysis data for that run.
        /// </summary>
        /// <param name="runNumber">The Run Number.</param>
        private void GetAnalysisData(int runNumber)
        {
            this.analysis1Data = new List<CBMAnalysis1Row>();
            this.analysis2Data = new List<CBMAnalysis2Row>();
            this.analysis3Data = new List<CBMAnalysis3Row>();

            try
            {
                this.analysis1Data = ChargeBalance.GetAnalysis1TableData(
                    this.displayAnalysisData.FirstOrDefault(d => d.CbmRunNumber == runNumber)
                    );
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- CBM ANALYSIS 1 -- GetAnalysisData() -- ", ex);
            }

            try
            {
                this.analysis2Data = ChargeBalance.GetAnalysis2TableData(
                    this.displayAnalysisData.FirstOrDefault(d => d.CbmRunNumber == runNumber)
                    );
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- CBM ANALYSIS 2 -- GetAnalysisData() -- ", ex);
            }

            try
            {
                this.analysis3Data = ChargeBalance.GetAnalysis3TableData(
                    this.displayMaterialData.FirstOrDefault(d => d.CbmRunNumber == runNumber)
                    );
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- CBM ANALYSIS 3 -- GetAnalysisData() -- ", ex);
            }
        }

        /// <summary>
        /// Populates the form with the data from the database.
        /// Hides the Loading Screen.
        /// </summary>
        private void PopulateForm()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();

            BuildOverviewGrid();
            Colours.FormatCBMGridview(dgvCBMOverview);
            SetRowSelection();
        }

        /// <summary>
        /// Populates the Analysis Tables on the Form.
        /// </summary>
        private void PopulateAnalysisDataGrids()
        {
            if (this.analysis1Data != null)
            {
                dgvAnalysis1.DataSource = this.analysis1Data;
                dgvAnalysis1.ClearSelection();
            }

            if (this.analysis2Data != null)
            {
                dgvAnalysis2.DataSource = this.analysis2Data;
                dgvAnalysis2.ClearSelection();
            }

            if (this.analysis3Data != null)
            {
                //Filter list to hide null rows (rows with no data)
                dgvAnalysis3.DataSource = this.analysis3Data
                    .Where(a => !string.IsNullOrWhiteSpace(a.Name))
                    .Where(d => d.Actual != null || d.Calculated != null ||
                                d.Constraint != null || d.Prepared != null)
                    .ToList();
                dgvAnalysis3.ClearSelection();
            }
        }

        /// <summary>
        /// Clears the Data Gridview then adds all of the data.
        /// </summary>
        private void BuildOverviewGrid()
        {
            dgvCBMOverview.Rows.Clear();
            dgvCBMOverview.Columns.Clear();
            AddOverviewDataGridColumns();
            AddOverviewDataGridRows();
        }

        /// <summary>
        /// Adds the data rows to the data gridview.
        /// </summary>
        private void AddOverviewDataGridRows()
        {
            if (this.overviewData != null)
            {
                int i = 0;//Keeps track of the row.
                foreach (CBMOverviewRow row in this.overviewData)
                {
                    dgvCBMOverview.Rows.Add();
                    dgvCBMOverview.Rows[i].Cells["colTime"].Value = row.Time;
                    dgvCBMOverview.Rows[i].Cells["colVessel"].Value = row.VesselNo.ToString();

                    foreach (CBMMaterial material in row.MaterialList)
                    {
                        string prefix = "";
                        switch (material.Type)
                        {
                            case CBMType.Actual:
                                prefix = "A ";
                                break;
                            case CBMType.Constrained:
                                prefix = "C ";
                                break;
                            case CBMType.DesulphHM:
                                prefix = "D ";
                                break;
                            case CBMType.PouredHM:
                            case CBMType.Prepared:
                                prefix = "P ";
                                break;
                            default:
                                prefix = "";
                                break;
                        }
                        //Add prefix, round and format the value.
                        dgvCBMOverview.Rows[i].Cells["col" + material.Name].Value = prefix +
                            Math.Round(material.Value, ChargeBalance.GetDPForMaterial(material.Name))
                                .ToString(ChargeBalance.FormatValueFromName(material.Name));
                    }

                    dgvCBMOverview.Rows[i].Cells["colSlagMgO"].Value = Math.Round(row.SlagMgO, 2).ToString(
                        ChargeBalance.FormatValueFromName("Slag MgO"));

                    dgvCBMOverview.Rows[i].Cells["colSlagVR"].Value = Math.Round(row.SlagVR, 2).ToString(
                        ChargeBalance.FormatValueFromName("Slag VR"));

                    dgvCBMOverview.Rows[i].Cells["colRunNumber"].Value = row.RunNumber.ToString();

                    i++;
                }
            }
        }

        /// <summary>
        /// Adds the DataGridview Columns to the Overview Gridview
        /// </summary>
        private void AddOverviewDataGridColumns()
        {
            AddColumnToDatagridview("colTime", "Time", "T", true);
            AddColumnToDatagridview("colVessel", "Vessel", "N0", true);

            if (this.materialColumns != null)
            {
                foreach (string material in this.materialColumns)
                {
                    AddColumnToDatagridview(
                        "col" + material,
                        material,
                        ChargeBalance.FormatValueFromName(material),
                        true);
                }
            }

            AddColumnToDatagridview(
                "colSlagMgO",
                "Slag MgO",
                ChargeBalance.FormatValueFromName("Slag MgO"),
                true
                );

            AddColumnToDatagridview(
                "colSlagVR",
                "Slag VR",
                ChargeBalance.FormatValueFromName("Slag VR"),
                true
                );

            AddColumnToDatagridview("colRunNumber", "RunNumber", "N0", false);
        }

        /// <summary>
        /// Adds a column to the data gridview.
        /// </summary>
        /// <param name="name">The Name of the Column.</param>
        /// <param name="headerText">The Header Text of the Column.</param>
        /// <param name="format">The cell formatting to be applied to that column e.g. N1 is 1 decimal place.</param>
        private void AddColumnToDatagridview(string name, string headerText, string format, bool visible)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.HeaderText = headerText;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Format = format;
            column.Visible = visible;
            column.ToolTipText = headerText;
            dgvCBMOverview.Columns.Add(column);
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
        }

        /// <summary>
        /// Defaults Overview gridview to select the newest run.
        /// </summary>
        public void SetRowSelection()
        {
            if (dgvCBMOverview.Rows.Count > 0)
            {
                dgvCBMOverview.CurrentCell = dgvCBMOverview.Rows[dgvCBMOverview.Rows.Count - 1].Cells[0];
                dgvCBMOverview.Rows[dgvCBMOverview.Rows.Count - 1].Selected = true;
            }
        }

        #region Events
        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.pageError = GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.pageError)
            {
                PopulateForm();
            }
            else
            {
                ShowErrorForm();
            }
        }

        /// <summary>
        /// Event to track the colour scheme changes using the radio buttons.
        /// </summary>
        private void rbColour_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDefaultColour.Checked)
            {
                Settings.Default.CBMColourScheme = "Default";
            }
            else if (rbHighContrastColour.Checked)
            {
                Settings.Default.CBMColourScheme = "High Contrast";
            }
            CommonMethods.SaveElvisSettings();
            Colours.FormatCBMGridview(dgvAnalysis1);
            Colours.FormatCBMGridview(dgvAnalysis2);
            Colours.FormatCBMGridview(dgvAnalysis3);
            if (this.heatNumber > 0)
            {
                SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Event that occurs when data is added to DGV. Formats the cells accordingly
        /// </summary>
        private void dgvCBMOverview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                double cellValue = 0;
                CBMType type = CBMType.Calculated;
                string columnName = dgvCBMOverview.Columns[e.ColumnIndex].Name;

                if (e.Value == null)
                {
                    e.CellStyle.BackColor =
                        Colours.GetCBMOverviewCellColour(CBMType.None, false);
                    return;
                }
                else if (e.Value != null &&
                    double.TryParse(e.Value.ToString(), out cellValue) &&
                    cellValue == 0)
                {//Remove Zeros
                    dgvCBMOverview.Rows[e.RowIndex].Cells[columnName].Value = "";
                    e.CellStyle.ForeColor =
                        Colours.GetCBMOverviewCellColour(CBMType.Calculated, true);
                    e.CellStyle.BackColor =
                        Colours.GetCBMOverviewCellColour(CBMType.Calculated, false);
                    return;
                }
                else if (e.Value != null)
                {
                    if (columnName == "colTime" || columnName == "colVessel" ||
                        columnName == "colSlagMgO" || columnName == "colSlagVR")
                    {
                        type = CBMType.None;
                    }
                    else
                    {
                        type = ChargeBalance.GetCBMTypeFromValue(e.Value.ToString());
                    }
                    e.CellStyle.ForeColor =
                        Colours.GetCBMOverviewCellColour(type, true);
                    e.CellStyle.BackColor =
                        Colours.GetCBMOverviewCellColour(type, false);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR -- CBM Overview Formatting -- dgvCBMOverview_CellFormatting() -- ", ex);
            }
        }

        /// <summary>
        /// Event that occurs when data is added to DGV. Formats the cells accordingly
        /// </summary>
        private void dgvAnalysis_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                double cellValue = 0;
                string type = "Value";
                DataGridView dgv = (DataGridView)sender;
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                if (dgv.Name == "dgvAnalysis3" &&
                    dgv.Rows[e.RowIndex].Cells["colName3"].Value != null)
                {
                    string materialName = dgv.Rows[e.RowIndex].Cells["colName3"].Value.ToString();
                    dgv.Rows[e.RowIndex].DefaultCellStyle.Format =
                        ChargeBalance.FormatValueFromName(materialName);
                }

                //Remove Zeros
                if (e.Value != null &&
                    double.TryParse(e.Value.ToString(), out cellValue) &&
                    cellValue == 0)
                {
                    dgv.Rows[e.RowIndex].Cells[columnName].Value = "";
                    e.CellStyle.ForeColor =
                        Colours.GetCBMAnalysisCellColour(type, true);
                    e.CellStyle.BackColor =
                        Colours.GetCBMAnalysisCellColour(type, false);
                    return;
                }
                else if (e.Value != null)
                {
                    if (columnName == "colName1" || columnName == "colName2" ||
                        columnName == "colName3")
                    {
                        type = "Title";
                    }
                    e.CellStyle.ForeColor =
                        Colours.GetCBMAnalysisCellColour(type, true);
                    e.CellStyle.BackColor =
                        Colours.GetCBMAnalysisCellColour(type, false);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR -- CBM Analysis Formatting -- dgvAnalysis_CellFormatting() -- ", ex);
            }
        }

        /// <summary>
        /// Event occurs when the CBM Overview Selected row changes.
        /// Refreshes the other tables with new data.
        /// </summary>
        private void dgvCBMOverview_SelectionChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            dgvAnalysis1.DataSource = null;
            dgvAnalysis2.DataSource = null;
            dgvAnalysis3.DataSource = null;
            grpRunData.Text = "CBM Run Data";

            if (dgvCBMOverview.Rows != null &&
                dgvCBMOverview.Rows.Count > 0 &&
                dgvCBMOverview.SelectedRows.Count > 0)
            {
                int runNumber = 0;
                if (dgvCBMOverview.SelectedRows[0].Cells["colRunNumber"].Value != null &&
                    int.TryParse(dgvCBMOverview.SelectedRows[0].Cells["colRunNumber"].Value.ToString(), out runNumber))
                {
                    GetAnalysisData(runNumber);
                    PopulateAnalysisDataGrids();
                    grpRunData.Text = "CBM Run #" + runNumber + " Data";
                }
            }

            Colours.FormatCBMGridview(dgvAnalysis1);
            Colours.FormatCBMGridview(dgvAnalysis2);
            Colours.FormatCBMGridview(dgvAnalysis3);

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Runs when the Datagridviews binding has finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAnalysis_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv != null)
            {
                dgv.ClearSelection();
            }
        }
        #endregion

        #endregion
    }
}
