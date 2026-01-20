using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Reports.Miscasts;
using Elvis.Forms.Reports.Miscasts.UserControls;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using Data = ElvisDataModel.EDMX;
using System.ComponentModel;

namespace Elvis
{
    public partial class HeatDetails : Form
    {
        #region Variables
        private int heatNumber;
        private int heatNumberSet;
        private bool casterEventClicked;
        private bool planEventClicked;
        private bool isMiscastAdmin;
        private List<HeatAimGrade> heatProgramAndGrades;
        private Bitmap memoryImage;
        private Boolean pagePrint;
        private MiscastReportNew ucMiscastReport;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HeatNumber
        {
            get { return this.heatNumber; }
            set
            {
                this.heatNumber = value;
                LoadNewHeat();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAllEvents
        {
            get { return menuShowAllEvents.Checked; }
            set { menuShowAllEvents.Checked = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the HeatDetails class.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="casterEventClicked">Has a caster event been clicked, true or false.</param>
        /// <param name="planEventClicked">Has a planning event been clicked, true or false.</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public HeatDetails(int heatNumber, bool casterEventClicked, 
            bool planEventClicked, bool isMiscastAdmin, 
            int heatNumberSet = 0)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            this.isMiscastAdmin = isMiscastAdmin;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            this.casterEventClicked = casterEventClicked;
            this.planEventClicked = planEventClicked;

            if (heatNumberSet > 0)
                this.heatNumberSet = heatNumberSet;
            else
                this.heatNumberSet = EntityHelper.Tracking.GetHNSFromHeatNumber(heatNumber);

            this.heatProgramAndGrades = new List<HeatAimGrade>();
            CustomiseColours();
            this.HeatNumber = heatNumber;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the additional data required for viewing purposes.
        /// </summary>
        /// <param name="heatNumber">The Heat Number.</param>
        /// <param name="hns">The Heat Number Set.</param>
        private void GetData(int heatNumber)
        {
            this.heatProgramAndGrades = new List<HeatAimGrade>();
            this.heatProgramAndGrades = EntityHelper.HeatAimGrades
                .GetByHeat(heatNumber, this.heatNumberSet)
                .OrderBy(h => h.AimGradeIndex)
                .ToList();
        }

        /// <summary>
        /// Adds all the necessary controls to the page for a new heat.
        /// </summary>
        private void LoadNewHeat()
        {
            this.Cursor = Cursors.WaitCursor;
            GetData(this.heatNumber);
            if (this.heatProgramAndGrades != null &&
                this.heatProgramAndGrades.Count > 0)
            {
                SetupHeatInfoDisplays();
                LoadOverviewTab();
                //LoadHotMetalTab();
                LoadScrapTab();
                LoadCBMTab();
                LoadBlowingTab();
                LoadBOSQATab();
                //LoadSecondaryTab();
                LoadCastingTab();
                LoadSlabsTab();
                LoadTemperatureTab();
                LoadAnalysisData();
                //LoadHeatLog();
                LoadPlanTab();
                LoadMiscast();
                LoadHotMetalTab();
                LoadTibTab();
                LoadTapWatchTab();
                CheckTabSelection();

                if (menuShowAllEvents.Enabled)
                    menuShowAllEvents.Checked = true;
            }
            else if (this.heatNumberSet > 1)
            {
                this.heatNumberSet--;
                LoadNewHeat();
            }
            else
            {
                this.heatNumberSet = EntityHelper.Tracking.GetLatestHNS();
                MessageBox.Show(
                    string.Format("Heat Number {0} not found!",
                        this.HeatNumber),
                    "Heat Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.heatNumber = GetHeatNumberFromFormText();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Generates the Heat Number from the Form Text
        /// </summary>
        /// <returns>The Current Heat Number of the form text
        /// or the current heat number of the form if conversion fails.</returns>
        private int GetHeatNumberFromFormText()
        {
            int heatNumberFromText = 0;
            if (int.TryParse(this.Text.Replace("Heat Details - ", ""), out heatNumberFromText))
            {
                return heatNumberFromText;
            }
            else return this.heatNumber;
        }

        private void CheckTabSelection()
        {
            if (this.planEventClicked)//Default to plan tag if planning event clicked.
            {
                tabCtrlHeatDetails.SelectedTab = tabCtrlHeatDetails.TabPages["tabPlan"];
                ShowPlanNavi(true);
            }
            else if (tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabOverview"])
            {
                menuShowAllEvents.Enabled = true;
            }
        }

        /// <summary>
        /// Sets up HeatDetailsOverview User Control on Overview Tab.
        /// </summary>
        private void LoadOverviewTab()
        {
            if (ucOverview != null)
            {
                ucOverview.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Sets up the ScrapUserControl User Control on the Scrap Tab.
        /// </summary>
        private void LoadScrapTab()
        {
            if (ucScrap != null)
            {
                ucScrap.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Sets up ChargeBalanceControl User Control on CBM Tab.
        /// </summary>
        private void LoadCBMTab()
        {
            if (ucCBM != null)
            {
                ucCBM.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Sets up EBMGraphUserControl User Control on Blowing Tab.
        /// </summary>
        private void LoadBlowingTab()
        {
            if (ucEBM != null)
            {
                ucEBM.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Sets up EBMGraphUserControl User Control on Blowing Tab.
        /// </summary>
        private void LoadTibTab()
        {
            if (ucTib != null)
            {
                ucTib.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }

        }

        /// <summary>
        /// Sets up EBMGraphUserControl User Control on Blowing Tab.
        /// </summary>
        private void LoadTapWatchTab()
        {
            if (tapWatchControl1 != null)
            {
                tapWatchControl1.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }

        }

        /// <summary>
        /// Sets up BosGradeViewerControl User Control on BOS QA Tab.
        /// Additional code placed here to try and fix the random 
        /// accessing disposed object error. 
        /// </summary>
        private void LoadBOSQATab()
        {
            if (ucBOSQA != null && !ucBOSQA.IsDisposed)
            {
                if (ucBOSQA.InvokeRequired)
                {
                    logger.Info("LoadBOSQATab() -- BosGradeViewerControl uc required invoke before calling SetupUserControl()!");
                    ucBOSQA.BeginInvoke((MethodInvoker)delegate
                    {
                        ucBOSQA.SetupUserControl(this.heatProgramAndGrades);
                    });
                }
                else
                {
                    ucBOSQA.SetupUserControl(this.heatProgramAndGrades);
                }
            }
        }

        /// <summary>
        /// Sets up CasterTrend on the Casting Tab.
        /// </summary>
        private void LoadCastingTab()
        {
            if (ucCasterTrendUserControl != null)
            {
                ucCasterTrendUserControl.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Sets up SlabsUserControl on the Slabs Tab.
        /// </summary>
        private void LoadSlabsTab()
        {
            if (ucSlabs != null)
            {
                ucSlabs.SetupUserControl(
                    this.heatNumber,
                    this.heatNumberSet
                    );
            }
        }

        /// <summary>
        /// Sets up Temperature Tab, loading two User controls into
        /// the tab.
        /// </summary>
        private void LoadTemperatureTab()
        {
            if (ucTempGraphs != null)
            {
                ucTempGraphs.SetupUserControl(
                    this.heatNumber,
                    this.heatNumberSet,
                    menuShowTemp.Checked
                    );
            }
            if (ucTemperatures != null)
            {
                ucTemperatures.SetupUserControl(
                    this.heatNumber,
                    this.heatNumberSet
                    );
            }
        }

        /// <summary>
        /// Sets up the Planning details user control.
        /// </summary>
        private void LoadPlanTab()
        {
            if (ucPlanDetails != null)
            {
                ucPlanDetails.PreviousBtnEnableStateChange += new EventHandler(previousPlanStateChange);
                ucPlanDetails.NextBtnEnableStateChange += new EventHandler(nextPlanStateChange);
                ucPlanDetails.SetupUserControl(this.heatNumber, this.heatNumberSet);
            }
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                tabOverview.BackColor =
                //tabHotMetal.BackColor = 
                tabScrap.BackColor =
                tabCBM.BackColor =
                tabEBM.BackColor =
                tabBOSQA.BackColor =
                //tabSecondary.BackColor = 
                tabCasting.BackColor =
                tabSlabs.BackColor =
                tabTemp.BackColor =
                tabAnalysis.BackColor =
                tabMiscast.BackColor =
                //tabHeatLog.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                tabOverview.ForeColor =
                //tabHotMetal.ForeColor =
                tabScrap.ForeColor =
                tabCBM.ForeColor =
                tabEBM.ForeColor =
                tabBOSQA.ForeColor =
                //tabSecondary.ForeColor =
                tabCasting.ForeColor =
                tabSlabs.ForeColor =
                tabTemp.ForeColor =
                tabAnalysis.ForeColor =
                tabMiscast.ForeColor =
                //tabHeatLog.ForeColor =
                Settings.Default.ColourText;

        }

        //Sets up heatnumber text on the form
        private void SetupHeatInfoDisplays()
        {
            //Hide Data.
            ShowTapTime(false);

            this.Text = "Heat Details - " + this.heatNumber;

            //Load the Heat Toolbar
            string grades = "";
            foreach (HeatAimGrade grade in this.heatProgramAndGrades)
            {
                grades += grade.Grade + " ";
            }
            lblHeatNumber.Text = this.heatNumber.ToString();
            lblProgram.Text = GetProgramNumber();
            lblGrades.Text = grades;
            DateTime? tapTime = EntityHelper.HeatLog.GetTapTimeByHeat(this.heatNumber, this.heatNumberSet);
            if (tapTime.HasValue)
            {
                lblDate.Text = tapTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
                lblDay.Text = (TimeFunctions.DayOfWeek_PT(tapTime.Value) + 1).ToString();
                lblWeek.Text = TimeFunctions.GetWeekNumber(tapTime.Value).ToString();
                lblYear.Text = tapTime.Value.ToString("yyyy");
                ShowTapTime(true);
            }

            toolStripStatusLabelCurrentHeat.Text = "Current Heat - " + this.heatNumber;
        }

        /// <summary>
        /// Shows Tap Time if true,
        /// Hides if false.
        /// </summary>
        /// <param name="state">True shows Tap Time, False Hides tap time.</param>
        private void ShowTapTime(bool state)
        {
            lblDayLabel.Visible = state;
            lblDayLabel.SendToBack();
            lblDay.Visible = state;
            lblDay.SendToBack();

            lblWeekLabel.Visible = state;
            lblWeekLabel.SendToBack();
            lblWeek.Visible = state;
            lblWeek.SendToBack();

            lblYearLabel.Visible = state;
            lblYearLabel.SendToBack();
            lblYear.Visible = state;
            lblYear.SendToBack();

            lblDate.Visible = state;
            lblDate.SendToBack();
        }

        /// <summary>
        /// Gets the program number from the heat details data.
        /// </summary>
        /// <returns>The Program Number as a string (# if no program number present).</returns>
        private string GetProgramNumber()
        {
            if (this.heatProgramAndGrades != null &&
                this.heatProgramAndGrades.Count > 0 &&
                this.heatProgramAndGrades.First() != null &&
                this.heatProgramAndGrades.First().ProgramNumber.HasValue)
            {
                return this.heatProgramAndGrades.First().ProgramNumber.Value.ToString();
            }
            return "#";
        }

        //Searches for the HeatNumber inserted into the search box
        private void Search()
        {
            if (toolStripSearchBox.Text.Length == 5)
            {
                int heatNumberSearch = 0;
                if (int.TryParse(toolStripSearchBox.Text, out heatNumberSearch))
                {
                    if (heatNumberSearch >= Settings.Default.MinHeatNumber &&
                        heatNumberSearch <= Settings.Default.MaxHeatNumber)
                    {
                        this.heatNumberSet = EntityHelper.Tracking.GetLatestHNS();
                        this.HeatNumber = heatNumberSearch;
                        return;
                    }
                }
            }
            MessageBox.Show(
                string.Format("Heat Number must be between {0} and {1}.",
                    Settings.Default.MinHeatNumber, Settings.Default.MaxHeatNumber),
                "Invalid Heat Number",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
            );
        }

        #region Get Data
        /// <summary>
        /// Get Analysis Data User Control and place into tabControl1.
        /// </summary>
        private void LoadAnalysisData()
        {
            UserControls.Analysis.AnalysisGrid analysis =
                new UserControls.Analysis.AnalysisGrid(
                    this.heatNumber, this.heatNumberSet);

            tabCtrlHeatDetails.TabPages["tabAnalysis"].Controls.Clear();
            tabCtrlHeatDetails.TabPages["tabAnalysis"].Controls.Add(analysis);
            analysis.Dock = DockStyle.Fill;
        }

        ///// <summary>
        ///// Adds Miscast data to page if any or removes the 
        ///// unused tab otherwise.
        ///// </summary>
        //private void LoadMiscast()
        //{
        //    MISCAST_DATA miscast = EntityHelper.Miscast_Data
        //        .GetByHeatNumber(
        //            this.heatNumber,
        //            this.heatNumberSet
        //            );
        //    if (miscast != null)
        //    {
        //        MiscastReport miscastReport =
        //            new MiscastReport(miscast.MiscastID);
        //        if (tabCtrlHeatDetails.TabPages["tabMiscast"] == null)
        //            tabCtrlHeatDetails.TabPages.Add(new TabPage("Miscast") { Name = "tabMiscast" });
        //        tabCtrlHeatDetails.TabPages["tabMiscast"].Controls.Clear();
        //        tabCtrlHeatDetails.TabPages["tabMiscast"].Controls.Add(miscastReport);
        //        miscastReport.Dock = DockStyle.Fill;
        //        if (this.casterEventClicked)//default to miscast page if caster event clicked.
        //            tabCtrlHeatDetails.SelectedTab = tabCtrlHeatDetails.TabPages["tabMiscast"];
        //    }
        //    else if (tabCtrlHeatDetails.TabPages["tabMiscast"] != null)
        //    {
        //        tabCtrlHeatDetails.TabPages.Remove(tabCtrlHeatDetails.TabPages["tabMiscast"]);
        //    }
        //}

        /// <summary>
        /// Adds Miscast data to page if any or removes the 
        /// unused tab otherwise.
        /// </summary>
        private void LoadMiscast()
        {
            ucMiscastReport = new MiscastReportNew(this.isMiscastAdmin);
            Data.MiscastMain miscast = EntityHelper.MiscastMain
                .GetByHeatNumber(
                    this.heatNumber,
                    this.heatNumberSet
                    );
            if (miscast != null)
            {
                ucMiscastReport.SetupUserControl(miscast);

                if (tabCtrlHeatDetails.TabPages["tabMiscast"] == null)
                    tabCtrlHeatDetails.TabPages.Add(new TabPage("Miscast") { Name = "tabMiscast" });
                tabCtrlHeatDetails.TabPages["tabMiscast"].Controls.Clear();
                tabCtrlHeatDetails.TabPages["tabMiscast"].Controls.Add(ucMiscastReport);
                ucMiscastReport.Dock = DockStyle.Left;

                Splitter splitter = new Splitter();
                tabCtrlHeatDetails.TabPages["tabMiscast"].Controls.Add(splitter);
                splitter.BringToFront();

                if (this.casterEventClicked)//default to miscast page if caster event clicked.
                    tabCtrlHeatDetails.SelectedTab = tabCtrlHeatDetails.TabPages["tabMiscast"];

                addEditMiscastToolStripMenuItem.Text = "&Edit Miscast Report...";
            }
            else if (tabCtrlHeatDetails.TabPages["tabMiscast"] != null)
            {
                tabCtrlHeatDetails.TabPages.Remove(tabCtrlHeatDetails.TabPages["tabMiscast"]);
                addEditMiscastToolStripMenuItem.Text = "&Add Miscast Report...";
            }
        }

        /// <summary>
        /// Sets up CasterTrend on the Casting Tab.
        /// </summary>
        private void LoadHotMetalTab()
        {
            if (ucHotMetal != null)
            {
                ucHotMetal.SetupUserControl(this.heatNumber, this.heatNumberSet);
                ucHotMetal.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Checks if there is any temperature graph data and 
        /// displays a message box if not.
        /// </summary>
        private void CheckTempGraphData()
        {
            if (ucTempGraphs.NoData)
            {
                MessageBox.Show(
                    "Temperature graph data not yet available.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

        /// <summary>
        /// Adds a new Miscast Report.
        /// </summary>
        private void AddMiscastReport()
        {
            using (MiscastAddNew addNew = new MiscastAddNew(
                this.heatNumber, this.heatNumberSet, this.isMiscastAdmin))
            {
                DialogResult result = addNew.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    HeatDetails heatDetails = new HeatDetails(
                        this.heatNumber,
                        this.casterEventClicked,
                        this.planEventClicked,
                        this.isMiscastAdmin,
                        this.heatNumberSet);
                    heatDetails.Show();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Opens the selected miscast report.
        /// </summary>
        private void EditMiscastReport()
        {
            if (this.heatNumber > 0 && this.heatNumberSet > 0)
            {
                using (MiscastReportHolder miscastReport = new MiscastReportHolder(
                    this.heatNumber, heatNumberSet, this.isMiscastAdmin))
                {
                    miscastReport.ShowDialog();
                }
            }
            else
            {
                logger.Error(
                    "DATA ERROR -- Error loading miscast report -- ViewMiscastReport() -- ");
                MessageBox.Show(
                    "Error opening Miscast Report",
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        #region ToolStrip
        //Close Form on Click
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Goes to Previous Heat Number (HeatNumber - 1)
        private void toolStripButtonPreviousHeat_Click(object sender, EventArgs e)
        {
            if (ucMiscastReport != null && ucMiscastReport.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "There are unsaved changes on the Miscast Report. Would you like to Save your changes?",
                    "Please Confirm", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    ucMiscastReport.SaveReport();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (this.heatNumber > Settings.Default.MinHeatNumber)
            {
                this.HeatNumber--;
                if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabTemp"))//Temperature
                {
                    CheckTempGraphData();
                }
            }
            else
            {
                MessageBox.Show(
                    string.Format("Heat Number must be between {0} and {1}.",
                        Settings.Default.MinHeatNumber, Settings.Default.MaxHeatNumber),
                    "Invalid Heat Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        //Goes to Next Heat Number (HeatNumber + 1)
        private void toolStripButtonNextHeat_Click(object sender, EventArgs e)
        {
            if (ucMiscastReport != null && ucMiscastReport.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "There are unsaved changes on the Miscast Report. Would you like to Save your changes?",
                    "Please Confirm", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    ucMiscastReport.SaveReport();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (this.heatNumber <= Settings.Default.MaxHeatNumber)
            {
                this.HeatNumber++;
                if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabTemp"))//Temperature
                {
                    CheckTempGraphData();
                }
            }
            else
                MessageBox.Show(
                    string.Format("Heat Number must be between {0} and {1}.",
                        Settings.Default.MinHeatNumber, Settings.Default.MaxHeatNumber),
                    "Invalid Heat Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
        }

        //Click Event for the Find Button
        private void toolStripFindButton_Click(object sender, EventArgs e)
        {
            Search();
            if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabTemp"))//Temperature
            {
                CheckTempGraphData();
            }
        }

        //Searches if enter hit. Only allows the entering of numbers into the text box.
        private void toolStripSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Enter Key
            {
                Search();
                if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabTemp"))//Temperature
                {
                    CheckTempGraphData();
                }
            }

            //Checks input for numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        //Clears text box and return font to normal when textbox is entered.
        private void toolStripSearchBox_Enter(object sender, EventArgs e)
        {
            if (toolStripSearchBox.Text == "[Heat Number]")
            {
                toolStripSearchBox.Text = "";
                toolStripSearchBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            }
        }
        //Adds text to text box and returns font to italic when textbox is left.
        private void toolStripSearchBox_Leave(object sender, EventArgs e)
        {
            if (toolStripSearchBox.Text == "")
            {
                toolStripSearchBox.Text = "[Heat Number]";
                toolStripSearchBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
        }
        #endregion

        #region Print

        private void heatLogToolStripPrintLog_Click(object sender, EventArgs e)
        {
            //Not used due to menu been displayed on printed page.
        }
        private void heatLogToolStripPrintPreview_Click(object sender, EventArgs e)
        {
            //Not used due to menu been displayed on print preview.
        }
        /// <summary>
        /// Store form data for print form.
        /// </summary>
        private void toolStripPrintButton_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = printDocument1;
            // Display the dialog. This returns true if the user presses the Print button.
            DialogResult print = pDialog.ShowDialog();
            if (print == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.Print();
                pagePrint = false;
            }
        }
        /// <summary>
        /// Print preview of form maximized.
        /// </summary>
        private void toolStripPrintPreviewButton_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.DefaultPageSettings.Landscape = true;
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            ((ToolStripButton)((ToolStrip)dlg.Controls[1]).Items[0]).Visible = false;
            dlg.Document = printDocument1;
            ((Form)dlg).WindowState = FormWindowState.Maximized;
            dlg.ShowDialog();
            pagePrint = false;
        }
        /// <summary>
        /// Store form data for print form.
        /// </summary>
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        /// <summary>
        /// Called from printDocument1.Print();
        /// </summary>
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // pagePrint added due to control firing twice, one image
            // and then a smaller one on top which is reduced again.
            if (pagePrint == false)
            {
                e.Graphics.ScaleTransform(0.87F, 0.9F);
                e.Graphics.DrawImage(memoryImage, 0, 0);
                pagePrint = true;
            }
        }

        #endregion

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void HeatDetails_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Left && ucCasterTrendUserControl != null &&
                        tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabCasting"])
            {
                ucCasterTrendUserControl.MoveAnnotatedLine(-1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right && ucCasterTrendUserControl != null &&
                        tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabCasting"])
            {
                ucCasterTrendUserControl.MoveAnnotatedLine(1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left && ucEBM != null &&
                        tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabEBM"])
            {
                ucEBM.MoveAnnotatedLine(-1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right && ucEBM != null &&
                        tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabEBM"])
            {
                ucEBM.MoveAnnotatedLine(1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5 && ucEBM != null &&
                tabCtrlHeatDetails.SelectedTab.Name.Equals("tabEBM"))
            {
                ucEBM.btnRefresh.PerformClick();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Resets the cursor to default
        /// </summary>
        private void HeatDetails_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows or hides the checkboxes depending on what tab is selected
        /// </summary>
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            menuShowAllEvents.Enabled = false;
            menuShowAllEvents.Checked = false;
            menuShowTemp.Enabled = false;
            menuShowTemp.Checked = false;
            //planToolStripSeparator.Visible = false;
            //nextPlanToolStripMenuItem.Enabled = false;
            //nextPlanToolStripMenuItem.Visible = false;
            //previousPlanToolStripMenuItem.Enabled = false;
            //previousPlanToolStripMenuItem.Visible = false;
            ShowPlanNavi(false);

            if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabOverview"))//Heat Details
            {
                menuShowAllEvents.Enabled = true;
                menuShowAllEvents.Checked = true;
            }
            else if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabBOSQA") && ucBOSQA != null)//BOS QA
            {
                if (ucBOSQA != null)
                {
                    ucBOSQA.SelectGrade();
                }
            }
            else if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabTemp"))//Temperature
            {
                menuShowTemp.Enabled = true;
                CheckTempGraphData();
            }
            else if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabCBM"))//CBM
            {
                if (ucCBM != null)
                {
                    ucCBM.SetRowSelection();
                }
            }
            else if (tabCtrlHeatDetails.SelectedTab.Name.Equals("tabPlan"))
            {
                if (ucPlanDetails != null)
                {
                    ShowPlanNavi(true);
                }
            }
        }

        /// <summary>
        /// Shows or hides the planning navigation menu items.
        /// </summary>
        /// <param name="state">True for show, false for hide.</param>
        private void ShowPlanNavi(bool state)
        {
            planToolStripSeparator.Visible = state;
            nextPlanToolStripMenuItem.Enabled = ucPlanDetails.NextEnabled;
            nextPlanToolStripMenuItem.Visible = state;
            previousPlanToolStripMenuItem.Enabled = ucPlanDetails.PreviousEnabled;
            previousPlanToolStripMenuItem.Visible = state;
        }

        /// <summary>
        /// Show/Hide Temp before vessels menu item click event
        /// </summary>
        private void menuShowTemp_Click(object sender, EventArgs e)
        {
            if (ucTempGraphs != null)
            {
                ucTempGraphs.SetupUserControl(
                        this.heatNumber,
                        this.heatNumberSet,
                        menuShowTemp.Checked
                    );
            }
        }

        /// <summary>
        /// Show all events menu click event
        /// </summary>
        private void menuShowAllEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (ucOverview != null)
            {
                ucOverview.ShowForAllUnits = menuShowAllEvents.Checked;
            }
        }

        /// <summary>
        /// Gives the heat details toolbar some style.
        /// </summary>
        private void pnlHeatDetailsToolBar_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel && e.ClipRectangle.Height > 0 &&
                e.ClipRectangle.Width > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    e.ClipRectangle,
                    ColorTranslator.FromHtml("#BAD2FC"),
                    ColorTranslator.FromHtml("#D2E2FD"),
                    //SystemColors.GradientInactiveCaption,
                    //SystemColors.InactiveCaptionText,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, e.ClipRectangle);
                }
            }
        }

        /// <summary>
        /// Helps with the re-painting of the heat banner
        /// </summary>
        private void HeatDetails_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Refresh EBM Tab Page
        /// </summary>
        private void btnRefreshEBM_Click(object sender, EventArgs e)
        {
            LoadBlowingTab();
        }


        /// <summary>
        /// Event to fix loss of focus when using the left and right
        /// arrow keys to change the position of the annotation line.
        /// Fires when a radio button is clicked on ucCasterTrend.
        /// </summary>
        public void setFocusOnTabControl(object sender, EventArgs e)
        {
            tabCtrlHeatDetails.Focus();
        }

        /// <summary>
        /// Controls the state of the enabled property of the previous 
        /// plan menu item.
        /// </summary>
        public void previousPlanStateChange(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                previousPlanToolStripMenuItem.Enabled = btn.Enabled;
            }
        }

        /// <summary>
        /// Controls the state of the enabled property of the next 
        /// plan menu item.
        /// </summary>
        public void nextPlanStateChange(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                nextPlanToolStripMenuItem.Enabled = btn.Enabled;
            }
        }

        private void HeatDetails_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left &&
                        tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabCasting"])
            {
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Right &&
                        tabCtrlHeatDetails.SelectedTab == tabCtrlHeatDetails.TabPages["tabCasting"])
            {
                e.IsInputKey = true;
            }
        }

        /// <summary>
        /// Navigate to the next plan on the plan tab.
        /// </summary>
        private void toolStripButtonNextPlan_Click(object sender, EventArgs e)
        {
            if (ucPlanDetails != null)
            {
                ucPlanDetails.GoToNextPlan();
            }
        }

        /// <summary>
        /// Navigate to the previous plan on the plan tab.
        /// </summary>
        private void toolStripButtonPrevPlan_Click(object sender, EventArgs e)
        {
            if (ucPlanDetails != null)
            {
                ucPlanDetails.GoToPreviousPlan();
            }
        }

        private void addEditMiscastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (addEditMiscastToolStripMenuItem.Text.Contains("Add"))
            {
                AddMiscastReport();
            }
            else
            {
                EditMiscastReport();
            }
            this.Cursor = Cursors.Default;
        }

        private void HeatDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucMiscastReport != null && ucMiscastReport.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "There are unsaved changes on the Miscast Report. Would you like to Save your changes?",
                    "Please Confirm", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    ucMiscastReport.SaveReport();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #endregion
    }
}
