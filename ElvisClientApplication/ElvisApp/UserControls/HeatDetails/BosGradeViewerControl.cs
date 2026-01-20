using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using Elvis.UserControls.Misc;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class BosGradeViewerControl : UserControl
    {
        #region Variables
        private bool pageError = false;
        private bool gridScrollVisible = false;
        private int widthDeductor = 95;//Constant used for resizing the material column, the higher the value the smaller the column.
        private int unitCount = 0;
        private List<HeatAimGrade> heatGrades = new List<HeatAimGrade>();
        //Data from Database
        private List<GRADE> grades;
        private List<GRADE_UNIT> gradeUnitsLookup;
        private List<GRADE_ANALYSIS> analysis;
        private List<ELEMENT_TAG> elementLookup;
        private List<GRADE_ADDITION> additions;
        private List<TREATMENT> treatmentLookup;
        private List<GRADE_TREATMENT> treatments;
        private List<GRADE_TEMPERATURE> temperatures;
        private List<GRADE_INSTRUCTIONS> instructions;

        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor and Control Setup
        /// <summary>
        /// Initialises a new BosGradeViewerControl
        /// </summary>
        public BosGradeViewerControl()
        {
            InitializeComponent();
            dgvAnalysis.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the background worker control to load data
        /// asynchronously
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="grades">A list of grades for the form.</param>
        public void SetupUserControl(List<HeatAimGrade> grades)
        {
            CommonMethods.LoadImageIntoPanel(Resources.loadingBlack, this, pnlMain);
            this.heatGrades = grades;
            cmboGrades.DataSource = null;
            cmboGrades.Items.Clear();
            cmboGrades.DataSource = grades;
            cmboGrades.DisplayMember = "Grade";
            cmboGrades.ValueMember = "Grade";

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If all get datas fail then true, otherwise false.</returns>
        private bool GetData()
        {
            if (this.heatGrades != null &&
                this.heatGrades.Count > 0)
            {
                this.grades = new List<GRADE>();
                this.gradeUnitsLookup = new List<GRADE_UNIT>();
                this.analysis = new List<GRADE_ANALYSIS>();
                this.elementLookup = new List<ELEMENT_TAG>();
                this.additions = new List<GRADE_ADDITION>();
                this.treatments = new List<GRADE_TREATMENT>();
                this.treatmentLookup = new List<TREATMENT>();
                this.temperatures = new List<GRADE_TEMPERATURE>();
                this.instructions = new List<GRADE_INSTRUCTIONS>();

                try
                {
                    foreach (HeatAimGrade grade in this.heatGrades)
                    {
                        if (grade.Grade.HasValue)
                        {
                            this.grades.Add(
                                EntityHelper.GRADE.GetByID(grade.Grade.Value)
                                );

                            this.analysis.AddRange(
                                EntityHelper.GRADE_ANALYSIS.GetByGradeNo(grade.Grade.Value)
                                );

                            this.additions.AddRange(
                                EntityHelper.GRADE_ADDITION.GetByGradeNo(grade.Grade.Value)
                                );

                            this.treatments.AddRange(
                                EntityHelper.GRADE_TREATMENT.GetByGradeNo(grade.Grade.Value)
                                );

                            this.temperatures.AddRange(
                                EntityHelper.GRADE_TEMPERATURE.GetByGradeNo(grade.Grade.Value)
                                );

                            this.instructions.AddRange(
                                EntityHelper.GRADE_INSTRUCTIONS.GetByGradeNo(grade.Grade.Value)
                                );
                        }
                    }
                    this.gradeUnitsLookup = EntityHelper.GRADE_UNIT.GetAll();
                    this.elementLookup = EntityHelper.ELEMENT_TAG.GetAll();
                    this.treatmentLookup = EntityHelper.TREATMENT.GetAll();
                    return false;
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR -- BOS Grade Viewer -- GetData() -- ", ex);
                }
            }
            return true;
        }

        /// <summary>
        /// Shows the main panel of the user control.
        /// Used for after loading of data is complete.
        /// </summary>
        private void ShowMainPanel()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();
        }

        /// <summary>
        /// Prepares the User Control for it's initial loading.
        /// Run this method when you wish to view the User Control.
        /// </summary>
        public void SelectGrade()
        {
            if (cmboGrades.Items.Count > 0 &&
                cmboGrades.SelectedIndex < 0)
            {
                cmboGrades.SelectedIndex = 0;
            }
            PopulateForm(cmboGrades.SelectedValue);
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlTopHeader.BackColor =
                pnlBottom.BackColor =
                pnlMain.BackColor =
                pnlGradeInfo.BackColor =
                pnlInstructions.BackColor =
                grpGrade.BackColor =
                grpStandardAdditions.BackColor =
                grpCodesAndPrac.BackColor =
                grpDateInfo.BackColor =
                grpTemperatures.BackColor =
                grpTreatments.BackColor =
                grpInstructions.BackColor =
                dgvAnalysis.BackgroundColor = 
                Settings.Default.ColourBackground;

            this.ForeColor =
                pnlTopHeader.ForeColor =
                pnlBottom.ForeColor =
                pnlMain.ForeColor =
                pnlGradeInfo.ForeColor =
                pnlInstructions.ForeColor =
                grpGrade.ForeColor =
                grpStandardAdditions.ForeColor =
                grpCodesAndPrac.ForeColor =
                grpDateInfo.ForeColor =
                grpTemperatures.ForeColor =
                grpTreatments.ForeColor =
                grpInstructions.ForeColor =
                Settings.Default.ColourText;

            //Gets a list of all the relevant controls on the form.
            List<Control> controlList = HelperFunctions.GetControlList(this, typeof(TextBox));

            //Loops through all of the controls painting the back
            //and fore colours to the selected user options.
            foreach (Control ctrl in controlList)
            {
                if (ctrl is TextBox && ctrl.Tag != null &&
                    ctrl.Tag.ToString().Equals("ColourMe"))
                {
                    ctrl.BackColor = Settings.Default.ColourBackground;
                    ctrl.ForeColor = Settings.Default.ColourText;
                }
            }
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
        }

        /// <summary>
        /// Fills the form with a particular grade details.
        /// </summary>
        /// <param name="grade">The grade you wish to fill the form with.</param>
        private void PopulateForm(object grade)
        {
            int intGrade = 0;
            GRADE selectedGrade = new GRADE();
            List<GRADE_ADDITION> selectedAdditions = new List<GRADE_ADDITION>();
            List<GRADE_TREATMENT> selectedTreatments = new List<GRADE_TREATMENT>();
            List<GRADE_TEMPERATURE> selectedTemps = new List<GRADE_TEMPERATURE>();
            List<GRADE_INSTRUCTIONS> selectedInstructions = new List<GRADE_INSTRUCTIONS>();

            if (grade != null &&
                int.TryParse(grade.ToString(), out intGrade) &&
                intGrade > 0)
            {
                if (this.grades != null)
                    selectedGrade = this.grades.FirstOrDefault(g => g.GRADE_NUMBER == intGrade);
                if (this.additions != null)
                    selectedAdditions = this.additions.Where(a => a.GRADE_NUMBER == intGrade).ToList();
                if (this.treatments != null)
                    selectedTreatments = this.treatments.Where(t => t.GRADE_NUMBER == intGrade).ToList();
                if (this.temperatures != null)
                    selectedTemps = this.temperatures.Where(t => t.GRADE_NUMBER == intGrade).ToList();
                if (this.instructions != null)
                    selectedInstructions = this.instructions.Where(i => i.GRADE_NUMBER == intGrade).ToList();

                if (selectedGrade != null)
                {
                    txtDesc.Text = selectedGrade.GRADE_DESC.Trim();

                    if (selectedGrade.TIME_AND_DATE_CREATED.HasValue)
                        txtDateCreated.Text = selectedGrade.TIME_AND_DATE_CREATED.Value.ToString("dd MMMM yyyy");

                    if (selectedGrade.TIME_AND_DATE_UPDATED.HasValue)
                        txtDateUpdated.Text = selectedGrade.TIME_AND_DATE_UPDATED.Value.ToString("dd MMMM yyyy");

                    #region Codes and Practices
                    if (selectedGrade.SCRAP_MIX.HasValue)
                        txtScrapMix.Text = selectedGrade.SCRAP_MIX.Value.ToString();

                    if (selectedGrade.BAP_CODE.HasValue)
                        txtBAPCode.Text = selectedGrade.BAP_CODE.Value.ToString();

                    if (selectedGrade.LANCE_PRACTICE.HasValue)
                        txtLancePractice.Text = selectedGrade.LANCE_PRACTICE.Value.ToString();

                    if (selectedGrade.END_BLOW_PRACTICE.HasValue)
                        txtEndBlow.Text = selectedGrade.END_BLOW_PRACTICE.Value.ToString();

                    if (selectedGrade.HMDS_TREATMENT_CODE.HasValue)
                        txtTreatmentCode.Text = selectedGrade.HMDS_TREATMENT_CODE.Value.ToString();

                    if (selectedGrade.HMDS_SKIM_CODE.HasValue)
                        txtSkimCode.Text = selectedGrade.HMDS_SKIM_CODE.Value.ToString();

                    if (selectedGrade.FLUX_PRACTICE.HasValue)
                        txtFluxPractice.Text = selectedGrade.FLUX_PRACTICE.Value.ToString();

                    if (selectedGrade.PRECHARGE_PRACTICE.HasValue)
                        txtPrecharge.Text = selectedGrade.PRECHARGE_PRACTICE.Value.ToString();

                    txtUpOnMetal.Text = selectedGrade.UP_ON_METAL;
                    #endregion

                    #region Temperatures
                    if (selectedGrade.LIQUIDUS_TEMPERATURE.HasValue)
                        txtLiqTemp.Text = selectedGrade.LIQUIDUS_TEMPERATURE.Value.ToString();

                    if (selectedGrade.LIQUIDUS_CORRECTION.HasValue)
                        txtLiqCorr.Text = selectedGrade.LIQUIDUS_CORRECTION.Value.ToString();

                    if (selectedGrade.REQUIRED_SUPERHEAT.HasValue)
                        txtSuperheat.Text = selectedGrade.REQUIRED_SUPERHEAT.Value.ToString();
                    #endregion
                }

                #region Analysis Datagrid
                AddAnalysisData(FormatAnalysisData(intGrade), intGrade);
                #endregion

                #region Standard Additions
                lstStandardAdditions.Items.Clear();//Clean up list box before adding more items.
                grpStandardAdditions.Controls.Clear();//Clean the groupbox of items.

                if (selectedAdditions != null && selectedAdditions.Count > 0)
                {//Make sure we have additions then loop each one and add them to the listview
                    foreach (GRADE_ADDITION addition in selectedAdditions)
                    {
                        float materialCharge = 0;
                        if (addition.MATERIAL_CHARGE_REQUIRED.HasValue)
                            materialCharge = addition.MATERIAL_CHARGE_REQUIRED.Value;

                        if (materialCharge > 0)
                        {//Only add if there is an acceptable material charge
                            ListViewItem item = new ListViewItem(new[] { 
                                    GetUnitText(addition.UNIT), 
                                    addition.MATERIAL_REFERENCE_NUMBER, 
                                    materialCharge.ToString() 
                                });
                            lstStandardAdditions.Items.Add(item);
                        }
                    }

                    //Show the user the additions
                    grpStandardAdditions.Controls.Add(lstStandardAdditions);
                    lstStandardAdditions.Dock = DockStyle.Fill;
                    lstStandardAdditions.BringToFront();
                    lstStandardAdditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {//No additions so show label.
                    Label lblNoAdditions = new Label();
                    lblNoAdditions.Text = "No Standard Additions Required.";
                    lblNoAdditions.TextAlign = ContentAlignment.MiddleCenter;
                    lblNoAdditions.Padding = new Padding(0, 3, 0, 0);
                    lblNoAdditions.Font = new System.Drawing.Font("", 9, FontStyle.Regular);
                    grpStandardAdditions.Controls.Add(lblNoAdditions);
                    lblNoAdditions.Dock = DockStyle.Top;
                    lblNoAdditions.BringToFront();
                }
                #endregion

                #region Treatments
                lstTreatments.Items.Clear();//Clean up list box before adding more items.
                grpTreatments.Controls.Clear();//Clean the groupbox of items.

                if (selectedTreatments != null && selectedTreatments.Count > 0)
                {//Make sure we have Treatments then loop each one and add them to the listview
                    foreach (GRADE_TREATMENT treatment in selectedTreatments)
                    {
                        if (treatment.TREATMENT.HasValue)
                        {
                            ListViewItem item = new ListViewItem(new[] { 
                                GetUnitText(treatment.UNIT), 
                                GetTreatmentText(treatment.TREATMENT.Value)
                            });
                            lstTreatments.Items.Add(item);
                        }
                    }

                    //Show the user the treatments
                    grpTreatments.Controls.Add(lstTreatments);
                    lstTreatments.Dock = DockStyle.Fill;
                    lstTreatments.BringToFront();
                    lstTreatments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {//No treatments so show label.
                    Label lblNoTreatments = new Label();
                    lblNoTreatments.Text = "No Treatments Required.";
                    lblNoTreatments.TextAlign = ContentAlignment.MiddleCenter;
                    lblNoTreatments.Padding = new Padding(0, 3, 0, 0);
                    lblNoTreatments.Font = new System.Drawing.Font("", 9, FontStyle.Regular);
                    grpTreatments.Controls.Add(lblNoTreatments);
                    lblNoTreatments.Dock = DockStyle.Top;
                    lblNoTreatments.BringToFront();
                }
                #endregion

                #region Temperatures
                lstTemperatures.Items.Clear();//Clean up list box before adding more items.
                if (selectedTemps != null && selectedTemps.Count > 0)
                {//Make sure we have additions then loop each one and add them to the listview
                    foreach (GRADE_TEMPERATURE temp in selectedTemps)
                    {
                        string max = "";
                        string min = "";
                        float aim = 0;

                        if (temp.MAXIMUM.HasValue)
                            max = temp.MAXIMUM.Value.ToString();

                        if (temp.MINIMUM.HasValue)
                            min = temp.MINIMUM.Value.ToString();

                        if (temp.AIM.HasValue)
                            aim = temp.AIM.Value;

                        if (aim > 0)
                        {//Only add if there is an acceptable material charge
                            ListViewItem item = new ListViewItem(new[] { 
                                    GetUnitText(temp.UNIT), 
                                    max, 
                                    min,
                                    aim.ToString()
                                });
                            lstTemperatures.Items.Add(item);
                        }
                    }
                    lstTemperatures.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                #endregion

                #region Instructions
                pnlInstructionHolder.Controls.Clear();
                if (selectedInstructions != null && selectedInstructions.Count > 0)
                {
                    int previousUnitNo = 0;
                    InstructionBoxBOSQA boxToAdd = new InstructionBoxBOSQA();
                    foreach (GRADE_INSTRUCTIONS instruction in selectedInstructions
                                .OrderByDescending(i => i.UNIT)//Reverse ordering to make adding the controls easier.
                                .ThenBy(o => o.LINE_NUMBER))
                    {
                        int currentUnitNo = instruction.UNIT;

                        //If new unit then add another instruction box
                        if (previousUnitNo != currentUnitNo)
                        {
                            //Add a splitter inbetween each box to resize
                            Splitter splitter = new Splitter();
                            splitter.Height = 4;
                            pnlInstructionHolder.Controls.Add(splitter);
                            splitter.Dock = DockStyle.Top;
                            //Add the instruction box
                            boxToAdd = new InstructionBoxBOSQA();
                            boxToAdd.SetupUserControl(GetUnitText(instruction.UNIT), instruction.INSTRUCTION_TEXT);
                            pnlInstructionHolder.Controls.Add(boxToAdd);
                            boxToAdd.Dock = DockStyle.Top;

                            previousUnitNo = currentUnitNo;//Remember the last unit added
                            continue;
                        }
                        //Otherwise just add an instruction the existing box.
                        boxToAdd.AddInstruction(instruction.INSTRUCTION_TEXT);
                    }
                }
                #endregion
            }
        }

        #region Analysis Methods
        /// <summary>
        /// Adds both the header labels and the actual data to the analysis section.
        /// </summary>
        /// <param name="data">A List of the Analysis Data.</param>
        private void AddAnalysisData(List<AnalysisData> data, int grade)
        {
            AddAnalysisHeaderLabelsAndColumns(
                this.gradeUnitsLookup
                    .Where(g => this.analysis.Where(a => a.GRADE_NUMBER == grade)
                        .Any(a => a.UNIT.Equals(g.UNIT1)))
                .ToList());
            AddAnalysisDataToGridview(data);
        }

        /// <summary>
        /// Adds the formatted data to the Analysis Data Gridview.
        /// </summary>
        /// <param name="data">The formatted data as a List of AnalysisData data.</param>
        private void AddAnalysisDataToGridview(List<AnalysisData> data)
        {
            if (data != null && dgvAnalysis.Columns != null &&
                dgvAnalysis.Columns.Count > 0)
            {
                int i = 0;
                foreach (AnalysisData analysisRow in data)
                {
                    dgvAnalysis.Rows.Add(analysisRow.Material);

                    if (dgvAnalysis.Rows.Count > 0)
                    {
                        dgvAnalysis.Rows[i].Cells["Material"].ToolTipText = analysisRow.ElementDesc;
                        foreach (UnitAnalysis analysis in analysisRow.Analysis)
                        {
                            //Values
                            dgvAnalysis.Rows[i].Cells["colMax" + analysis.UnitDesc].Value = analysis.Max;
                            dgvAnalysis.Rows[i].Cells["colMin" + analysis.UnitDesc].Value = analysis.Min;
                            dgvAnalysis.Rows[i].Cells["colAim" + analysis.UnitDesc].Value = analysis.Aim;
                            //Tooltips
                            dgvAnalysis.Rows[i].Cells["colMax" + analysis.UnitDesc].ToolTipText = analysisRow.ElementDesc;
                            dgvAnalysis.Rows[i].Cells["colMin" + analysis.UnitDesc].ToolTipText = analysisRow.ElementDesc;
                            dgvAnalysis.Rows[i].Cells["colAim" + analysis.UnitDesc].ToolTipText = analysisRow.ElementDesc;
                        }
                    }
                    i++;
                }
                this.gridScrollVisible = ScrollBarVisible();
                RecalculateLabelAndColumnWidths();
            }
            dgvAnalysis.ClearSelection();
        }

        /// <summary>
        /// Method to determine if the scroll bar is visible on the 
        /// data gridview
        /// </summary>
        /// <returns>True for Visible, false for otherwise.</returns>
        private bool ScrollBarVisible()
        {
            //Find out if the gridview is showing a vertical scrollbar and store for later.
            try
            {
                return dgvAnalysis.Controls.OfType<VScrollBar>().First().Visible;
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR ANALYSIS GRIDIVEW ON BOS GRADE VIEWER -- AddAnalysisDataToGridview(List<AnalysisData> data) -- ",
                    ex);
            }
            return false;
        }

        /// <summary>
        /// Adds the header labels and columns to the analysis section.
        /// </summary>
        /// <param name="units">The units to be used as headers.</param>
        private void AddAnalysisHeaderLabelsAndColumns(List<GRADE_UNIT> units)
        {
            //Clear current panels and data grids.
            pnlColumnHeaders.Controls.Clear();
            dgvAnalysis.Rows.Clear();
            dgvAnalysis.Columns.Clear();

            //Used for resizing later on
            this.unitCount = units.Count;

            //Calculate width of panel depending on unit count.
            int width = pnlColumnHeaders.Width / (this.unitCount + 1);

            //Add blank Label and Column
            Label lbl = CreateHeaderLabel(width - widthDeductor, "", "Blank");

            pnlColumnHeaders.Controls.Add(lbl);
            lbl.Dock = DockStyle.Left;
            lbl.BringToFront();

            DataGridViewColumn column = CreateDataColumn(width - widthDeductor, "Material", " ");
            column.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvAnalysis.Columns.Add(column);

            //Calcualte new widths now that first label + column has been added.
            if (this.unitCount > 0)
                width = (pnlColumnHeaders.Width - lbl.Width) / this.unitCount;

            //Offset for padding calcuations.
            lbl.Width -= 3;
            column.Width -= 4;

            //Add remaining columns and labels
            foreach (GRADE_UNIT unit in units)
            {
                string unitText = unit.UNIT_DESC.Trim();

                lbl = CreateHeaderLabel(width, unitText, unitText);
                pnlColumnHeaders.Controls.Add(lbl);
                lbl.Dock = DockStyle.Left;
                lbl.BringToFront();

                DataGridViewColumn colMax = CreateDataColumn(width / 3, "colMax" + unitText, "Max");
                DataGridViewColumn colMin = CreateDataColumn(width / 3, "colMin" + unitText, "Min");
                DataGridViewColumn colAim = CreateDataColumn(width / 3, "colAim" + unitText, "Aim");

                TieUpWidths(lbl.Width, colMax, colMin, colAim, 1);

                dgvAnalysis.Columns.Add(colMax);
                dgvAnalysis.Columns.Add(colMin);
                dgvAnalysis.Columns.Add(colAim);
            }
        }

        /// <summary>
        /// Method that loops to increase or decrease the columns by 3 pixels
        /// to match up with the label headers.  These errors in pixel sizes
        /// come from dividing by 3 to get the width.
        /// </summary>
        /// <param name="lblWidth">The Width of the label above.</param>
        /// <param name="maxWidth">The maxWidth Column.</param>
        /// <param name="minWidth">The minWidth Column.</param>
        /// <param name="aimWidth">The aimWidth Column.</param>
        /// <param name="iterationNo">The number of times the method has looped.</param>
        private void TieUpWidths(int lblWidth, DataGridViewColumn maxWidth,
            DataGridViewColumn minWidth, DataGridViewColumn aimWidth, int iterationNo)
        {
            int columnTotal = maxWidth.Width + minWidth.Width + aimWidth.Width;
            if (columnTotal == lblWidth)
                return;//All good they line up.
            else if (columnTotal < lblWidth)
            {
                if (iterationNo == 1)
                {//First pass increase max column
                    maxWidth.Width++;
                    iterationNo++;
                    TieUpWidths(lblWidth, maxWidth, minWidth, aimWidth, iterationNo);
                }
                else if (iterationNo == 2)
                {//Second pass increase min column
                    minWidth.Width++;
                    iterationNo++;
                    TieUpWidths(lblWidth, maxWidth, minWidth, aimWidth, iterationNo);
                }
                else if (iterationNo == 3)
                {//Third pass increase aim column
                    aimWidth.Width++;
                    iterationNo++;
                    TieUpWidths(lblWidth, maxWidth, minWidth, aimWidth, iterationNo);
                }
            }
            else if (columnTotal > lblWidth)
            {
                if (iterationNo == 1)
                {//First pass decrease max column
                    maxWidth.Width--;
                    iterationNo++;
                    TieUpWidths(lblWidth, maxWidth, minWidth, aimWidth, iterationNo);
                }
                else if (iterationNo == 2)
                {//Second pass decrease min column
                    minWidth.Width--;
                    iterationNo++;
                    TieUpWidths(lblWidth, maxWidth, minWidth, aimWidth, iterationNo);
                }
                else if (iterationNo == 3)
                {//Third pass decrease aim column
                    aimWidth.Width--;
                    iterationNo++;
                    TieUpWidths(lblWidth, maxWidth, minWidth, aimWidth, iterationNo);
                }
            }
        }

        /// <summary>
        /// Create and format a Data Gridview Column
        /// ready to add to a gridview.
        /// </summary>
        /// <param name="width">The Width of the Column in int.</param>
        /// <param name="name">The Name (ID) of the Column.</param>
        /// <param name="headerText">The Header Text of the column.</param>
        /// <returns></returns>
        private DataGridViewColumn CreateDataColumn(int width, string name, string headerText)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.HeaderText = headerText;
            column.Width = width;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Format = "N3";
            return column;
        }

        /// <summary>
        /// Create and format a Header Label for the analysis table.
        /// </summary>
        /// <param name="width">The width of the label.</param>
        /// <param name="text">The text of the label.</param>
        /// <returns>The Label all formatted and ready to go.</returns>
        private Label CreateHeaderLabel(int width, string text, string tag)
        {
            Label lbl = new Label();
            lbl.Tag = tag;
            lbl.Width = width;
            lbl.AutoSize = false;
            lbl.Text = text;
            lbl.TextAlign = ContentAlignment.BottomCenter;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.BackColor = SystemColors.ControlDark;
            lbl.Padding = new Padding(0, 0, 0, 2);
            return lbl;
        }

        /// <summary>
        /// Resizes the Labels and Columns of the Analysis Section when Main User Control is resized.
        /// </summary>
        private void RecalculateLabelAndColumnWidths()
        {
            Label firstLabel = new Label();
            if (dgvAnalysis != null && dgvAnalysis.Columns != null &&
                dgvAnalysis.Columns.Count > 0)
            {
                //Compensation for scroll bar width if showing.
                int scrollBarWidth = 0;
                if (this.gridScrollVisible)
                    scrollBarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;

                dgvAnalysis.Columns["Material"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

                //First find the Blank Label
                foreach (Label lbl in pnlColumnHeaders.Controls)
                {
                    if (lbl.Tag != null &&
                        lbl.Tag.ToString().Equals("Blank"))
                    {
                        lbl.Width = dgvAnalysis.Columns["Material"].Width + 4;
                        firstLabel = lbl; //Save for later
                    }
                }

                //Then Format the rest of the labels.
                foreach (Label lbl in pnlColumnHeaders.Controls)
                {
                    if (lbl.Tag != null && !lbl.Tag.ToString().Equals("Blank"))
                    {
                        if (this.unitCount > 0)
                        {
                            lbl.Width = (pnlColumnHeaders.Width - firstLabel.Width - scrollBarWidth) / this.unitCount;
                        }

                        dgvAnalysis.Columns["colMax" + lbl.Tag].Width = lbl.Width / 3;
                        dgvAnalysis.Columns["colMin" + lbl.Tag].Width = lbl.Width / 3;
                        dgvAnalysis.Columns["colAim" + lbl.Tag].Width = lbl.Width / 3;

                        TieUpWidths(lbl.Width,
                            dgvAnalysis.Columns["colMax" + lbl.Tag],
                            dgvAnalysis.Columns["colMin" + lbl.Tag],
                            dgvAnalysis.Columns["colAim" + lbl.Tag],
                            1);
                    }
                }
                //Offset the padding.
                firstLabel.Width -= 3;
                dgvAnalysis.Columns["Material"].Width -= 4;
            }
        }

        /// <summary>
        /// Generates and formats the data for the analysis section.
        /// </summary>
        /// <param name="grade">The Selected Grade that is showing to the user.</param>
        /// <returns>A formatted list of analysis data ready to add to the form.</returns>
        private List<AnalysisData> FormatAnalysisData(int grade)
        {
            List<AnalysisData> formattedAnalysis = new List<AnalysisData>();//Whole Data
            AnalysisData analysisRow = new AnalysisData();//Data Row

            if (this.analysis != null && this.analysis.Count > 0)
            {
                try
                {
                    List<GRADE_ANALYSIS> filteredData = this.analysis
                        .Where(a => a.GRADE_NUMBER == grade)
                        .ToList();

                    //List of the distinct elements, which will act as the row titles (filtered by grade).
                    List<string> elements = 
                        Enumerable.DistinctBy(filteredData,e => e.ELEMENT_TAG.Trim())
                        .Select(e => e.ELEMENT_TAG.Trim())
                        .ToList();

                    foreach (string element in elements)
                    {//Create a row for each element
                        List<UnitAnalysis> analysisPerElement = new List<UnitAnalysis>();
                        ELEMENT_TAG elementTag = GetElementLookup(element);

                        foreach (GRADE_ANALYSIS anal in filteredData.Where(e => 
                            e.ELEMENT_TAG.Trim() == element))
                        {//Find the data for each element and add to the analysis list (filtered by grade).
                            UnitAnalysis unitAnalysis = new UnitAnalysis()
                            {
                                Unit = anal.UNIT,
                                UnitDesc = GetUnitText(anal.UNIT),
                                Max = anal.MAXIMUM,
                                Min = anal.MINIMUM,
                                Aim = anal.AIM
                            };

                            analysisPerElement.Add(unitAnalysis);
                        }

                        //Create the Element Row
                        analysisRow = new AnalysisData()
                        {
                            Material = element,
                            Analysis = analysisPerElement
                        };

                        if (elementTag != null)
                        {
                            analysisRow.SortIndex = elementTag.ELEMENT_INDEX;
                            analysisRow.ElementDesc = elementTag.ELEMENT_DESC.Trim();
                        }

                        //Add it to the overall Data Collector.
                        formattedAnalysis.Add(analysisRow);
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException("ERROR FORMATTING ANALYSIS DATA -- FormatAnalysisData() -- ", ex);
                }
            }
            return formattedAnalysis
                .OrderBy(e => e.SortIndex)
                .ToList();
        }
        #endregion

        #region Lookups
        /// <summary>
        /// Gets the treatment text from the list of treatments using
        /// the treatment number.
        /// </summary>
        /// <param name="treatmentNo">The Treatment Number.</param>
        /// <returns>The treatment text.</returns>
        private string GetTreatmentText(short treatmentNo)
        {
            if (this.treatmentLookup != null && this.treatmentLookup.Count > 0)
            {
                TREATMENT treatment = this.treatmentLookup.FirstOrDefault(g => g.TREATMENT1 == treatmentNo);
                if (treatment != null)
                {
                    return treatment.TREATMENT_DESC.Trim();
                }
            }
            return "Error";
        }

        /// <summary>
        /// Gets the unit text from the unit number.
        /// </summary>
        /// <param name="unitNo">The unit number of the unit.</param>
        /// <returns>The Unit Description as a string.</returns>
        private string GetUnitText(short unitNo)
        {
            if (this.gradeUnitsLookup != null && this.gradeUnitsLookup.Count > 0)
            {
                GRADE_UNIT unit = this.gradeUnitsLookup.FirstOrDefault(g => g.UNIT1 == unitNo);
                if (unit != null)
                {
                    return unit.UNIT_DESC.Trim();
                }
            }
            return "Error";
        }

        /// <summary>
        /// Gets the element tag object, which contains sort and description info.
        /// </summary>
        /// <param name="element">The Element you wish to search for.</param>
        /// <returns>An ELEMENT_TAG object.</returns>
        private ELEMENT_TAG GetElementLookup(string element)
        {
            if (this.elementLookup != null && this.elementLookup.Count > 0)
            {
                ELEMENT_TAG elementTag = this.elementLookup.FirstOrDefault(e => e.ELEMENT_TAG1.Trim() == element);
                if (elementTag != null)
                {
                    return elementTag;
                }
            }
            return null;
        }
        #endregion

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
                ShowMainPanel();
                PopulateForm(cmboGrades.SelectedValue);
            }
            else
            {
                ShowErrorForm();
            }
        }

        /// <summary>
        /// Changes the data on the screen depending on what grade is 
        /// selected by the combo box.
        /// </summary>
        private void cmboGrades_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmboGrades.SelectedIndex >= 0)
            {
                PopulateForm(cmboGrades.SelectedValue);
            }
        }

        /// <summary>
        /// Keeps the text in the up on metal textbox to
        /// either 'Yes' or 'No' rather than 'N' or 'Y'
        /// </summary>
        private void txtUpOnMetal_TextChanged(object sender, EventArgs e)
        {
            if (txtUpOnMetal.Text == "N")
            {
                txtUpOnMetal.Text = "No";
            }
            else if (txtUpOnMetal.Text == "Y")
            {
                txtUpOnMetal.Text = "Yes";
            }
        }

        /// <summary>
        /// Event handler for the resize of the User Control.
        /// </summary>
        private void BosGradeViewerControl_Resize(object sender, EventArgs e)
        {
            this.gridScrollVisible = ScrollBarVisible();
            RecalculateLabelAndColumnWidths();
        }

        /// <summary>
        /// Event handler for the moving of the main splitter.
        /// </summary>
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.gridScrollVisible = ScrollBarVisible();
            RecalculateLabelAndColumnWidths();
        }
        #endregion

        #endregion
    }

    #region Supporting Classes
    /// <summary>
    /// Used as a data row for the Data Gridview on the page
    /// </summary>
    public class AnalysisData
    {
        public string Material { get; set; }
        public List<UnitAnalysis> Analysis { get; set; }
        public int? SortIndex { get; set; }
        public string ElementDesc { get; set; }
    }

    /// <summary>
    /// Used to store the max min aim for a certain unit.
    /// This is then associated with a material (above).
    /// </summary>
    public class UnitAnalysis
    {
        public int Unit { get; set; }
        public string UnitDesc { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }
        public double? Aim { get; set; }
    }
    #endregion
}
