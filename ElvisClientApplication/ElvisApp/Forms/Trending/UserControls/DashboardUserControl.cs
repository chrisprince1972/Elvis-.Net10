using BusinessLogic.Constants.Trending.Dashboards;
using Elvis.Common;
using Elvis.Forms.Reports.CasterMachineCondition;
using Elvis.Forms.Reports.Miscasts;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elvis.Forms.Trending.UserControls
{
    public partial class DashboardUserControl : UserControl
    {
        #region Variables and Properties

        //Default Styling
        private int rowHeight = Settings.Default.DashboardRowHeight;

        private int singleBoxWidth = Settings.Default.DashboardSingleBoxWidth;
        private int rightWeeklyColWidth = 60;
        private int leftKPILevelWidth = 30;
        private Padding dataBoxPadding = Settings.Default.DashboardBoxPadding;
        private Font headerFont = new Font("Tahoma", 10, FontStyle.Bold);
        private Font colHeaderFont = new Font("Tahoma", 8F, FontStyle.Bold);
        private Font kpiDescFont = new Font("Tahoma", 8F, FontStyle.Regular);
        private Font kpiValueFont = Settings.Default.DashboardBoxFont;

        private bool showWeekly;
        private bool dataLoaded = false;
        private bool formBuilt = false;
        private bool isMiscastAdmin;
        private int rowCount = 0;
        private double widestKPIDesc = double.MinValue;
        private double widestKPILevel = double.MinValue;
        private DashboardType dashType;
        private DashboardLevel dashLevel;
        private DashboardDayView dashDayView;
        private DateTime startDate;
        private Panel pnlTopLevel = new Panel();
        private Panel pnlRightWeekly = new Panel();
        private Panel pnlLeftKPILevel = new Panel();
        private Panel pnlLeftKPIDesc = new Panel();
        private Panel pnlCentreKPIData = new Panel();
        private Splitter splitKPIDesc = new Splitter();
        private BackgroundWorker workDashData = new BackgroundWorker();

        private List<KPIData> kpiDatas;
        private List<KPIConfig> kpiConfigs;
        private List<GroupConfig> groupConfigs;
        private List<KPIDataWeek> kpiWeeklyData;
        private List<KPIActionRule> kpiActionRules;

        //Event used for when the form has finished building.
        public event System.EventHandler FormHasBuilt;

        /// <summary>
        /// Stops the flickers of the form when generating it.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;// Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        /// Exposes the Row Count of the Dashboard.
        /// </summary>
        public int RowCount
        {
            get { return this.rowCount; }
        }

        /// <summary>
        /// Exposes the Row Height of the Dashboard.
        /// </summary>
        public int RowHeight
        {
            get { return rowHeight; }
        }

        /// <summary>
        /// FormBuilt Public Property
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FormBuilt
        {
            get { return this.formBuilt; }
            set
            {
                this.formBuilt = value;
                if (this.formBuilt && RowCount > 0)
                    OnFormBuilt();
            }
        }

        /// <summary>
        /// Governs how many days to show on the Dashboard.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DashboardDayView DashDayView
        {
            get { return this.dashDayView; }
            set
            {
                this.dashDayView = value;
                if (this.dataLoaded)
                    LoadData();
                BuildForm();
            }
        }

        /// <summary>
        /// Governs whether or not the dashboard should show
        /// the weekly KPI Value option.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowWeekly
        {
            get { return this.showWeekly; }
            set
            {
                this.showWeekly = value;
                if (this.dataLoaded)
                    LoadData();
                BuildForm();
            }
        }

        /// <summary>
        /// Governs the StartDate of the Dashboard.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                this.startDate = value;
                if (this.dataLoaded)
                    LoadData();
                BuildForm();
            }
        }

        #endregion Variables and Properties

        #region Delegates And Events

        /// <summary>
        /// Fires when a KPI Label is clicked.
        /// </summary>
        /// <param name="sender">The KPI Config.</param>
        public delegate void KPILabelClickEventHandler(KPIConfig sender);

        public event KPILabelClickEventHandler KPILabelClick;

        /// <summary>
        /// Fires when a TIB Delay KPI is Clicked on the Dashboard.
        /// </summary>
        /// <param name="dateTime">The Date Time that was clicked.</param>
        public delegate void DashboardTIBClickEventHandler(DateTime dateTime);

        public event DashboardTIBClickEventHandler DashboardTIBClickEvent;

        #endregion Delegates And Events

        /// <summary>
        /// Creates a new instance of the
        /// Elvis Dashboard User Control.
        /// </summary>
        public DashboardUserControl()
        {
            InitializeComponent();
            SetupBackgroundWorker();
            ShowLoading();
            DashDayView = DashboardDayView.SevenDayView;
        }

        /// <summary>
        /// Method that shows the Loading Box on the
        /// screen for the user.
        /// </summary>
        private void ShowLoading()
        {
            this.Cursor = Cursors.WaitCursor;
            PictureBox picBox = new PictureBox();
            picBox.Image = Resources.loadingBlack;
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(picBox);
            picBox.Dock = DockStyle.Fill;
            picBox.BringToFront();
            picBox.Refresh();
        }

        /// <summary>
        /// Sets up the User Control.
        /// </summary>
        /// <param name="dashType">The Type of Dashboard.</param>
        /// <param name="dashLevel">The Level of Dashboard.</param>
        /// <param name="dashDayView">The Day View for the Dashboard.</param>
        /// <param name="startDate">The Starting Date for the Dashboard.</param>
        /// <param name="showWeekly">True to show weekly column, false for not.</param>
        /// <param name="isMiscastAdmin">Is Admin for the Miscast System.</param>
        public void SetupUserControl(DashboardType dashType, DashboardLevel dashLevel,
            DashboardDayView dashDayView, DateTime startDate, bool showWeekly, bool isMiscastAdmin)
        {
            this.dashType = dashType;
            this.dashLevel = dashLevel;
            this.dashDayView = dashDayView;
            this.startDate = startDate;
            this.showWeekly = showWeekly;
            this.isMiscastAdmin = isMiscastAdmin;
            LoadData();
        }

        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            workDashData.DoWork += new DoWorkEventHandler(workDashData_DoWork);
            workDashData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workDashData_RunWorkerCompleted);
            workDashData.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Loads the Forms Data
        /// </summary>
        private void LoadData()
        {
            if (!workDashData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workDashData.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Builds the Dashboard.
        /// </summary>
        private void BuildForm()
        {
            if (!workDashData.IsBusy && this.dataLoaded)
            {
                rowCount = 0;
                pnlMain.Controls.Clear();
                AddStructuralLayoutControls();
                AddFixedContent();
                AddDatabaseContent();
            }
        }

        /// <summary>
        /// Adds the Main Structural Controls to the Dashboard.
        /// </summary>
        private void AddStructuralLayoutControls()
        {
            this.pnlTopLevel.Controls.Clear();
            this.pnlLeftKPILevel.Controls.Clear();
            this.pnlLeftKPIDesc.Controls.Clear();
            this.pnlRightWeekly.Controls.Clear();
            this.pnlCentreKPIData.Controls.Clear();

            SetupPanel(this.pnlTopLevel,
                Settings.Default.ColourDashHeaderBack,
                DockStyle.Top, 0, 22,
                BorderStyle.FixedSingle);

            if (this.showWeekly)
            {
                SetupPanel(this.pnlRightWeekly,
                    Settings.Default.ColourDashHeaderBack,
                    DockStyle.Right,
                    rightWeeklyColWidth,
                    0, BorderStyle.FixedSingle);
            }

            SetupPanel(this.pnlLeftKPILevel,
                Settings.Default.ColourDashHeaderBack,
                DockStyle.Left,
                leftKPILevelWidth,
                0, BorderStyle.FixedSingle);

            SetupPanel(this.pnlLeftKPIDesc,
                Settings.Default.ColourDashHeaderBack,
                DockStyle.Left,
                GetKPIDescWidth(), 0, BorderStyle.FixedSingle);
            this.pnlLeftKPIDesc.AutoScroll = true;

            splitKPIDesc = new Splitter();
            splitKPIDesc.BackColor = SystemColors.ControlLightLight;
            pnlMain.Controls.Add(splitKPIDesc);
            splitKPIDesc.Dock = DockStyle.Left;
            splitKPIDesc.Width = 4;
            splitKPIDesc.BringToFront();
            splitKPIDesc.MouseDoubleClick += new MouseEventHandler(splitKPIDesc_MouseDoubleClick);

            SetupPanel(this.pnlCentreKPIData,
                Settings.Default.ColourDashHeaderBack,
                DockStyle.Fill,
                0, 0, BorderStyle.FixedSingle);
            this.pnlCentreKPIData.AutoScroll = true;
        }

        /// <summary>
        /// Adds any fixed content to the page that is
        /// not generated from the database.
        /// </summary>
        private void AddFixedContent()
        {
            AddHeader();
            AddDates();
            if (this.ShowWeekly)
            {
                AddWeeklyBox();
            }
            rowCount++;
        }

        /// <summary>
        /// Adds the Database content.
        /// </summary>
        private void AddDatabaseContent()
        {
            foreach (KPIConfig config in this.kpiConfigs)
            {
                if (this.dashLevel == DashboardLevel.Level1 &&
                    config.KPISubLevel == 0 ||
                    this.dashLevel == DashboardLevel.Level2 &&
                    config.KPISubLevel > 0)
                {
                    AddRowContent(config);
                    rowCount++;
                }
                else if (this.dashLevel == DashboardLevel.Level1 &&
                    config.KPISubLevel > 0 ||
                    this.dashLevel == DashboardLevel.Level2 &&
                    config.KPISubLevel == 0)
                {
                    if (AddFullSpacerRow(config))
                        rowCount++;
                }
            }

            if (this.widestKPIDesc == double.MinValue)
                this.widestKPIDesc = 100;
            if (this.widestKPILevel == double.MinValue)
                this.widestKPILevel = leftKPILevelWidth;

            if (this.widestKPILevel < 15)//Add an offset so it's not too thin.
                this.widestKPILevel += 9;

            //Adds scroll bar if the width is too large for the screen.
            this.pnlLeftKPIDesc.AutoScrollMinSize = new Size(
                Convert.ToInt32(this.widestKPIDesc) + 5, 0);

            this.pnlLeftKPILevel.Width = Convert.ToInt32(this.widestKPILevel) + 9;
        }

        /// <summary>
        /// Adds a full row spacer to the dashboard.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private bool AddFullSpacerRow(KPIConfig config)
        {
            bool spaceAdded = false;
            spaceAdded = AddSpacerToPanel(config, pnlLeftKPILevel);
            spaceAdded = AddSpacerToPanel(config, pnlLeftKPIDesc);

            if (this.showWeekly)
            {
                spaceAdded = AddSpacerToPanel(config, pnlRightWeekly);
            }

            if (spaceAdded)
                AddSpacerToCentreKPIData(config);

            return spaceAdded;
        }

        /// <summary>
        /// Adds a full row of content.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        private void AddRowContent(KPIConfig config)
        {
            AddLeftKPILevel(config);
            AddLeftKPIDesc(config);
            AddCentreKPIData(config);

            if (this.showWeekly)
            {
                AddRightWeekly(config);
            }
        }

        /// <summary>
        /// Adds the left KPI Levels (left most column content)
        /// </summary>
        /// <param name="config">The KPI config to use.</param>
        private void AddLeftKPILevel(KPIConfig config)
        {
            Label lblLeftKPILevelRow = new Label()
            {
                Text = GetKPILevelText(config),
                Font = kpiDescFont,
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Colours.GetKPITextColour(config)
            };

            this.widestKPILevel = GetWidthIfLarger(
                lblLeftKPILevelRow.Text,
                this.widestKPILevel,
                kpiDescFont
                );

            Panel pnlLeftKPILevelRow = new Panel()
            {
                Height = rowHeight,
                BackColor = Colours.GetKPIBackColour(config)
            };

            pnlLeftKPILevelRow.Controls.Add(lblLeftKPILevelRow);
            lblLeftKPILevelRow.Dock = DockStyle.Fill;

            this.pnlLeftKPILevel.Controls.Add(pnlLeftKPILevelRow);
            pnlLeftKPILevelRow.Dock = DockStyle.Top;
            pnlLeftKPILevelRow.BringToFront();
        }

        /// <summary>
        /// Adds the KPI Descriptions to the KPI Desc Column.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        private void AddLeftKPIDesc(KPIConfig config)
        {
            Label lblLeftKPIDescRow = new Label()
            {
                Text = config.KPIDescription,
                Font = kpiDescFont,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Colours.GetKPITextColour(config),
                Cursor = Cursors.Hand
            };

            this.widestKPIDesc = GetWidthIfLarger(
                lblLeftKPIDescRow.Text,
                this.widestKPIDesc,
                kpiDescFont
                );

            Panel pnlLeftKPIDescRow = new Panel()
            {
                Height = rowHeight,
                BackColor = Colours.GetKPIBackColour(config)
            };

            pnlLeftKPIDescRow.Controls.Add(lblLeftKPIDescRow);
            lblLeftKPIDescRow.Dock = DockStyle.Fill;

            this.pnlLeftKPIDesc.Controls.Add(pnlLeftKPIDescRow);
            pnlLeftKPIDescRow.Dock = DockStyle.Top;
            pnlLeftKPIDescRow.BringToFront();

            lblLeftKPIDescRow.Tag = config;
            lblLeftKPIDescRow.MouseClick += new MouseEventHandler(lblLeftKPIDescRow_MouseClick);
            lblLeftKPIDescRow.MouseEnter += new EventHandler(lblLeftKPIDescRow_MouseEnter);
            lblLeftKPIDescRow.MouseLeave += new EventHandler(lblLeftKPIDescRow_MouseLeave);
        }

        /// <summary>
        /// Finds out the widest width generated by the Text passed in.
        /// </summary>
        /// <param name="text">The Text to Measure.</param>
        /// <param name="widestWidthSoFar">The widest width for that panel so far.</param>
        /// <param name="font">The Font.</param>
        /// <returns>The width as a double.</returns>
        private double GetWidthIfLarger(string text, double widestWidthSoFar, System.Drawing.Font font)
        {
            double newWidth = HelperFunctions.GetFontSizeInPixels(text, font).Width;
            if (newWidth > widestWidthSoFar)
                return newWidth;
            return widestWidthSoFar;
        }

        /// <summary>
        /// Adds the KPI Data to the main part of the dashboard.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        private void AddCentreKPIData(KPIConfig config)
        {
            int noOfDays = Convert.ToInt16(this.dashDayView);
            Panel dataHolder = new Panel()
            {
                Height = rowHeight,
                Width = (singleBoxWidth * noOfDays),
                BackColor = Colours.GetKPIBackColour(config)
            };

            if (config.KPIActionIndex.HasValue &&
                config.KPIActionIndex.Value > 0)
            {
                dataHolder.Cursor = Cursors.Hand;
            }

            this.pnlCentreKPIData.Controls.Add(dataHolder);
            dataHolder.Location = new Point(0, rowHeight * rowCount);

            for (int i = 0; i < noOfDays; i++)
            {
                Panel singleDataBox = new Panel()
                {
                    Height = rowHeight,
                    Width = singleBoxWidth,
                    Padding = dataBoxPadding
                };

                Label lblData = GetDataLabel(config, i);

                singleDataBox.Controls.Add(lblData);
                lblData.Dock = DockStyle.Fill;

                dataHolder.Controls.Add(singleDataBox);
                singleDataBox.Location = new Point(i * singleBoxWidth, 0);
            }
        }

        /// <summary>
        /// Builds the KPI Data Label ready to adding to the form.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        /// <param name="dayNo">The Day No.</param>
        /// <returns>A Label containing all the data required.</returns>
        private Label GetDataLabel(KPIConfig config, int dayNo)
        {
            string kpiDataValue = "#";
            int? kpiStatus = null;

            Elvis.Model.KPIConfigWithDayNo configWithDay = Dashboards.GetConfigWithDayNo(config, dayNo);
            KPIData kpiData = GetKPIData(config.KPIINdex, dayNo);
            if (kpiData != null)
            {
                if (kpiData.KPIValue.HasValue)
                {
                    string format = "0"; //Default formatting

                    if (!string.IsNullOrWhiteSpace(config.StringFormat))
                        format = config.StringFormat;

                    kpiDataValue = kpiData.KPIValue.Value.ToString(format);
                }
                kpiStatus = kpiData.KPIStatus;
            }

            Label lbl = new Label()
            {
                Font = kpiValueFont,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Colours.GetKPIDataBackground(CheckWithinLimit(kpiStatus)),
                ForeColor = Colours.GetKPIDataForeColour(CheckWithinLimit(kpiStatus)),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = configWithDay
            };

            if (config.ShowValue)
                lbl.Text = kpiDataValue;

            lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
            lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
            lbl.MouseClick += new MouseEventHandler(lbl_MouseClick);

            return lbl;
        }

        /// <summary>
        /// Builds the KPI Data Weekly Label ready to adding to the form.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        /// <returns>A Label containing all the data required.</returns>
        private Label GetWeeklyDataLabel(KPIConfig config)
        {
            string kpiDataValue = "#";
            int? kpiStatus = null;

            KPIConfigWithDayNo configWithDay = Dashboards.GetConfigWithDayNo(config, -1);//-1 is a week
            KPIDataWeek kpiDataWeek = GetKPIDataWeek(config.KPIINdex);
            if (kpiDataWeek != null)
            {
                if (kpiDataWeek.KPIValue.HasValue)
                {
                    string format = "0"; //Default formatting

                    if (!string.IsNullOrWhiteSpace(config.StringFormat))
                        format = config.StringFormat;

                    kpiDataValue = kpiDataWeek.KPIValue.Value.ToString(format);
                }
                kpiStatus = kpiDataWeek.KPIStatus;
            }

            Label lbl = new Label()
            {
                Font = kpiValueFont,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Colours.GetKPIDataBackground(CheckWithinLimit(kpiStatus)),
                ForeColor = Colours.GetKPIDataForeColour(CheckWithinLimit(kpiStatus)),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = configWithDay
            };

            if (config.ShowValue)
                lbl.Text = kpiDataValue;

            lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
            lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
            lbl.MouseClick += new MouseEventHandler(lbl_MouseClick);

            return lbl;
        }

        /// <summary>
        /// Checks the status value of the KPI data and
        /// returns true of false.
        /// </summary>
        /// <param name="status">The status of the KPI Data.</param>
        /// <returns>True if within tolerance, false if not, null if no value.</returns>
        private bool? CheckWithinLimit(int? status)
        {
            if (status.HasValue)
            {
                if (status == 1)
                    return true;
                return false;
            }
            return null;
        }

        /// <summary>
        /// Gets the KPI Data from the KPIData list
        /// using an index value and Date.
        /// </summary>
        /// <param name="kpiIndex">The index of the KPI Value.</param>
        /// <param name="dayNo">The day number to return, 1, 2 or 3.</param>
        /// <returns>A KPI Data object.</returns>
        private KPIData GetKPIData(int kpiIndex, int dayNo)
        {
            if (this.kpiDatas != null &&
                this.kpiDatas.Count > 0)
            {
                DateTime date = new DateTime(
                    this.startDate.Year,
                    this.startDate.Month,
                    this.startDate.Day,
                    0, 0, 0);
                date = date.AddDays(dayNo);

                return this.kpiDatas.FirstOrDefault(k =>
                    k.KPIIndex == kpiIndex &&
                    k.KPIDate == date);
            }
            return null;
        }

        /// <summary>
        /// Gets the KPI Data for a specific Index.
        /// </summary>
        /// <param name="kpiIndex">The KPI Index.</param>
        /// <returns>A KPIDataWeek data object.</returns>
        private KPIDataWeek GetKPIDataWeek(int kpiIndex)
        {
            if (this.kpiWeeklyData != null &&
                this.kpiWeeklyData.Count > 0)
            {
                return this.kpiWeeklyData.FirstOrDefault(k =>
                    k.KPIIndex == kpiIndex);
            }
            return null;
        }

        /// <summary>
        /// Adds a spacer to the Centre Data to add colour.
        /// </summary>
        /// <param name="config">The KPIConfig</param>
        private void AddSpacerToCentreKPIData(KPIConfig config)
        {
            int noOfDays = Convert.ToInt16(this.dashDayView);
            Panel dataHolder = new Panel()
            {
                Height = rowHeight,
                Width = (singleBoxWidth * noOfDays),
                Location = new Point(0, rowHeight * rowCount),
                BackColor = Colours.GetKPIBackColour(config)
            };

            this.pnlCentreKPIData.Controls.Add(dataHolder);
        }

        /// <summary>
        /// Decides what to do when a Value Box is clicked,
        /// based on the KPIConfig.KPIActionIndex value.
        /// </summary>
        /// <param name="config">The KPIConfig to interrogate.</param>
        private void TakeKPIAction(KPIConfigWithDayNo config)
        {
            if (config != null &&
                config.KPIActionIndex.HasValue)
            {
                switch (config.KPIActionIndex.Value)
                {
                    case 1://Load Trending
                        LoadTrendingForm(config);
                        break;

                    case 2://Display Daily Miscast Report
                        LoadMiscastReports(config);
                        break;

                    case 3://Display Daily RFT Report
                        LoadRFTSummary(config);
                        break;

                    case 4://Display Slab Stock Report
                        LoadSlabStockSummary(config);
                        break;

                    case 5://Display TIB
                        LoadTIBDisplay(config);
                        break;

                    case 6://Caster Machine Condtioning
                        LoadCasterMachineConditioning();
                        break;
                }
            }
        }

        /// <summary>
        /// Loads caster machine conditioning window.
        /// </summary>
        private void LoadCasterMachineConditioning()
        {
            this.Cursor = Cursors.WaitCursor;

            CasterMachineConditionForm casterMachineForm = new CasterMachineConditionForm();
            casterMachineForm.Show();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Loads the trending form with specific
        /// parameters.
        /// </summary>
        /// <param name="config">The KPIConfig object associated
        /// with the clicked Label Tag.</param>
        private void LoadTrendingForm(KPIConfigWithDayNo config)
        {
            this.Cursor = Cursors.WaitCursor;

            TrendingForm trendingForm = new TrendingForm(this.isMiscastAdmin);
            if (config.KPIActionGroup.HasValue)
            {
                DateTime trendStartDate = this.startDate;
                DateTime trendEndDate = this.startDate.AddDays(7);

                if (config.DayNo >= 0)
                {
                    trendStartDate = this.startDate.AddDays(config.DayNo);
                    trendEndDate = trendStartDate.AddDays(1);
                }

                trendingForm.LoadSpecificDateAndGroup(
                    trendStartDate,
                    trendEndDate,
                    config.KPIActionGroup.Value);
            }
            trendingForm.Show();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Loads the Miscast Reports for
        /// that specific date range.
        /// </summary>
        /// <param name="config">The KPIConfig object associated
        /// with the clicked Label Tag.</param>
        private void LoadMiscastReports(KPIConfigWithDayNo config)
        {
            this.Cursor = Cursors.WaitCursor;

            Tuple<string, string> areaTuple = GetAreaTuple();
            Tuple<string, string> trioFunctionTuple = GetTrioFunctionTuple(config);

            MiscastFilterHolder miscastFilterValues = new MiscastFilterHolder()
            {
                ComboFilterList = new List<Tuple<string, string>>()
            };

            if (areaTuple != null)
            {
                miscastFilterValues.ComboFilterList.Add(areaTuple);
            }

            if (trioFunctionTuple != null)
            {
                miscastFilterValues.ComboFilterList.Add(trioFunctionTuple);
            }

            if (config.DayNo == -1)
            {//If weekly has been clicked default to the start date.
                miscastFilterValues.DateFrom = this.startDate;
                miscastFilterValues.DateTo = miscastFilterValues.DateFrom.Value.AddDays(7);
            }
            else
            {
                miscastFilterValues.DateFrom = this.startDate.AddDays(config.DayNo);
                miscastFilterValues.DateTo = miscastFilterValues.DateFrom.Value.AddDays(1);
            }

            MiscastMainNew miscastMain = new MiscastMainNew(
                miscastFilterValues, this.isMiscastAdmin);
            miscastMain.Show();

            this.Cursor = Cursors.Default;
        }

        private Tuple<string, string> GetTrioFunctionTuple(KPIConfigWithDayNo config)
        {
            //We don't filter if sub level is the main KPI
            if (config.KPISubLevel > 0)
            {
                string trioFilter = "";

                if (config.KPIDescription.Contains("Manufacturing"))
                {
                    trioFilter = "Manufacturing";
                }
                else if (config.KPIDescription.Contains("Technical"))
                {
                    trioFilter = "Technical";
                }
                else if (config.KPIDescription.Contains("Engineering"))
                {
                    trioFilter = "Engineering";
                }

                if (!string.IsNullOrWhiteSpace(trioFilter))
                {
                    return new Tuple<string, string>(
                        "Function", trioFilter);
                }
            }
            return null;
        }

        private Tuple<string, string> GetAreaTuple()
        {
            string primaryFilter = GetPrimaryFilter();

            if (!string.IsNullOrWhiteSpace(primaryFilter))
            {
                return new Tuple<string, string>(
                     "Area", primaryFilter);
            }
            return null;
        }

        private string GetPrimaryFilter()
        {
            switch (this.dashType)
            {
                case DashboardType.Primary:
                    return "Primary";
                case DashboardType.Secondary:
                    return "Secondary";
                case DashboardType.Casting:
                    return "Casting";
                case DashboardType.CMM:
                default:
                    return "";
            }
        }

        /// <summary>
        /// TO DO: maybe filter further if they select 
        /// a box from the right hand dashboard e.g. TrioFunction
        /// </summary>
        /// <returns></returns>
        private string GetSecondaryFilter()
        {
            return "";
        }

        /// <summary>
        /// Loads the RFT Summary Form for
        /// that specific date range.
        /// </summary>
        /// <param name="config">The KPIConfig object associated
        /// with the clicked Label Tag.</param>
        private void LoadRFTSummary(KPIConfigWithDayNo config)
        {
            this.Cursor = Cursors.WaitCursor;

            if (config.DayNo == -1)//Weekly
            {
                config.DayNo = 0;//Default to first day in week.
            }

            //Remove Time values.
            DateTime date = new DateTime(
                   this.startDate.AddDays(config.DayNo).Year,
                   this.startDate.AddDays(config.DayNo).Month,
                   this.startDate.AddDays(config.DayNo).Day,
                   0, 0, 0, 0);

            RFTSummary rftSummary = new RFTSummary();
            rftSummary.SetupForm(date);
            rftSummary.Show();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Loads the Slab Stock Summary Form for
        /// that specific date range.
        /// </summary>
        /// <param name="config">The KPIConfig object associated
        /// with the clicked Label Tag.</param>
        private void LoadSlabStockSummary(KPIConfigWithDayNo config)
        {
            this.Cursor = Cursors.WaitCursor;

            if (config.DayNo == -1)//Weekly
            {
                config.DayNo = 0;//Default to first day in week.
            }

            //Remove Time values.
            DateTime date = new DateTime(
                   this.startDate.AddDays(config.DayNo).Year,
                   this.startDate.AddDays(config.DayNo).Month,
                   this.startDate.AddDays(config.DayNo).Day,
                   0, 0, 0, 0);

            SlabStockSummary slabStockSummary = new SlabStockSummary();
            slabStockSummary.SetupForm(date);
            slabStockSummary.Show();

            this.Cursor = Cursors.Default;
        }

        private void LoadTIBDisplay(KPIConfigWithDayNo config)
        {
            DateTime tibDate = this.startDate.AddDays(config.DayNo);
            if (this.DashboardTIBClickEvent != null)
            {
                this.DashboardTIBClickEvent(tibDate);
            }
        }

        /// <summary>
        /// Adds the Weekly KPI Data to the dashboard.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        private void AddRightWeekly(KPIConfig config)
        {
            Panel singleDataBox = new Panel()
            {
                Height = rowHeight,
                Padding = dataBoxPadding,
                BackColor = Colours.GetKPIBackColour(config)
            };

            Label lblData = GetWeeklyDataLabel(config);

            if (config.KPIActionIndex.HasValue &&
                config.KPIActionIndex.Value > 0)
            {
                lblData.Cursor = Cursors.Hand;
            }

            singleDataBox.Controls.Add(lblData);
            lblData.Dock = DockStyle.Fill;

            this.pnlRightWeekly.Controls.Add(singleDataBox);
            singleDataBox.Dock = DockStyle.Top;
            singleDataBox.BringToFront();
        }

        /// <summary>
        /// Gets the KPI Level Text using the config
        /// and dashboard configuration.
        /// </summary>
        /// <param name="config">The KPI Config to use.</param>
        /// <returns>The KPI Level Text as a string.</returns>
        private string GetKPILevelText(KPIConfig config)
        {
            if (this.dashLevel == DashboardLevel.Level1 &&
                config.KPILevel.HasValue)
            {
                return config.KPILevel.Value.ToString();
            }
            else if (this.dashLevel == DashboardLevel.Level2 &&
                config.KPILevel.HasValue && config.KPISubLevel.HasValue)
            {
                return string.Format("{0}.{1}",
                    config.KPILevel.Value.ToString(),
                    config.KPISubLevel.Value.ToString());
            }
            return "";
        }

        /// <summary>
        /// Adds a blank row in for correct spacing if needed.
        /// </summary>
        /// <param name="config">The KPI Config to check.</param>
        /// <returns>True if row added.</returns>
        private bool AddSpacerToPanel(KPIConfig config, Panel pnlToAddSpacerTo)
        {
            if (this.kpiConfigs != null)
            {
                List<KPIConfig> associatedKPIs = this.kpiConfigs
                    .Where(c => c.KPILevel == config.KPILevel)
                    .ToList();

                if (config.KPISubLevel.HasValue &&
                    config.KPISubLevel.Value == 0 &&
                    associatedKPIs.Count == 1)
                {
                    AddGenericSpacer(pnlToAddSpacerTo, config);
                    return true;
                }
                else if (config.KPISubLevel.HasValue &&
                    config.KPISubLevel.Value > 1)
                {
                    AddGenericSpacer(pnlToAddSpacerTo, config);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a spacer to the given panel.
        /// </summary>
        /// <param name="pnlToAddSpacerTo">The Panel to add to.</param>
        private void AddGenericSpacer(Panel pnlToAddSpacerTo, KPIConfig config)
        {
            Panel pnlSpacer = new Panel()
            {
                Height = rowHeight,
                BackColor = Colours.GetKPIBackColour(config)
            };

            pnlToAddSpacerTo.Controls.Add(pnlSpacer);
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.BringToFront();
        }

        /// <summary>
        /// Adds the header to the dashboard.
        /// </summary>
        private void AddHeader()
        {
            pnlTopLevel.Controls.Clear();
            Label lblHeader = new Label()
            {
                Font = headerFont,
                ForeColor = Settings.Default.ColourDashHeaderText,
                Text = GetHeaderText(),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlTopLevel.Controls.Add(lblHeader);
            lblHeader.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Adds the Dates fixed line to the dashboard.
        /// </summary>
        private void AddDates()
        {
            this.pnlCentreKPIData.Controls.Clear();

            int noOfDays = Convert.ToInt16(this.dashDayView);
            AddGenericSpacer(pnlLeftKPILevel, null);
            AddGenericSpacer(pnlLeftKPIDesc, null);

            Panel datesHolder = new Panel()
            {
                Height = rowHeight,
                Width = (singleBoxWidth * noOfDays),
                Location = new Point(0, rowHeight * rowCount),
                BackColor = Settings.Default.ColourDashHeaderBack
            };

            this.pnlCentreKPIData.Controls.Add(datesHolder);

            for (int i = 0; i < noOfDays; i++)
            {
                Panel singleDateBox = new Panel()
                {
                    Height = rowHeight,
                    Width = singleBoxWidth
                };

                Label lblDate = new Label()
                {
                    Text = GetDateBoxDate(i),
                    Font = colHeaderFont,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Settings.Default.ColourDashHeaderText
                };

                singleDateBox.Controls.Add(lblDate);
                lblDate.Dock = DockStyle.Fill;

                datesHolder.Controls.Add(singleDateBox);
                singleDateBox.Location = new Point(i * singleBoxWidth, 0);
            }
        }

        /// <summary>
        /// Adds the weekly box text to the weekly column.
        /// </summary>
        private void AddWeeklyBox()
        {
            pnlRightWeekly.Controls.Clear();

            Panel singleBox = new Panel()
            {
                Height = rowHeight,
                BackColor = Settings.Default.ColourDashHeaderBack
            };

            Label lblWeekly = new Label()
            {
                Text = "Week " + TimeFunctions.GetWeekNumber(this.startDate).ToString(),
                Font = colHeaderFont,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Settings.Default.ColourDashHeaderText
            };

            singleBox.Controls.Add(lblWeekly);
            lblWeekly.Dock = DockStyle.Fill;

            pnlRightWeekly.Controls.Add(singleBox);
            singleBox.Dock = DockStyle.Top;
            singleBox.BringToFront();
        }

        /// <summary>
        /// Gets the correct date to place in to the date boxes.
        /// </summary>
        /// <param name="i">The amount of days to add onto the start date.</param>
        /// <returns>The date in string format dd/MM.</returns>
        private string GetDateBoxDate(int i)
        {
            return this.startDate.AddDays(i).ToString("dd/MM");
        }

        /// <summary>
        /// Gets the width of the KPI desc panel by
        /// calculation.
        /// </summary>
        /// <returns>The width as an int.</returns>
        private int GetKPIDescWidth()
        {
            double wholeWidth = this.Width;
            wholeWidth -= this.pnlLeftKPILevel.Width;

            if (this.showWeekly)
                wholeWidth -= rightWeeklyColWidth;

            wholeWidth -= singleBoxWidth * Convert.ToInt16(dashDayView);

            return Convert.ToInt32(Math.Round(wholeWidth)) - 6;
        }

        /// <summary>
        /// Gets the Header text for a dashboard depending on
        /// the level set.
        /// </summary>
        /// <returns>Header text as string.</returns>
        private string GetHeaderText()
        {
            switch (this.dashLevel)
            {
                case DashboardLevel.Level1:
                    return "Level 1";
                case DashboardLevel.Level2:
                    return "Level 2";
                default:
                    return "Error";
            }
        }

        /// <summary>
        /// Places a panel into the pnlMain with the
        /// given properties.
        /// </summary>
        /// <param name="pnl">The Panel to setup.</param>
        /// <param name="backColour">The Back Colour of the panel.</param>
        /// <param name="dockStyle">The DockStyle.</param>
        /// <param name="width">The Width of the panel, set at 0 for no change.</param>
        /// <param name="height">The Height of the panel, set at 0 for no change.</param>
        private void SetupPanel(Panel pnl, Color backColour,
            DockStyle dockStyle, int width, int height, BorderStyle border)
        {
            pnl.BackColor = backColour;
            pnlMain.Controls.Add(pnl);
            pnl.Dock = dockStyle;
            pnl.BorderStyle = border;

            if (width > 0)
                pnl.Width = width;
            if (height > 0)
                pnl.Height = height;

            pnl.BringToFront();
        }

        /// <summary>
        /// Gets any additional info for the tooltips.
        /// </summary>
        /// <param name="config">The KPI config to use.</param>
        /// <returns>Additional text as a string or empty.</returns>
        private string GetAdditionalToolTipInfo(KPIConfigWithDayNo config)
        {
            if (config != null &&
                config.KPIActionGroup.HasValue)
            {
                //Trending
                if (config.KPIActionIndex.HasValue &&
                    config.KPIActionIndex.Value == 1)
                {
                    GroupConfig groupConfig = this.groupConfigs.FirstOrDefault(g => g.GroupIndex == config.KPIActionGroup.Value);
                    if (groupConfig != null)
                    {
                        return " for " + groupConfig.GroupDesc;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Sets up the splitter to display all of the data value boxes.
        /// </summary>
        public void SetSplitter()
        {
            pnlLeftKPIDesc.Width = GetKPIDescWidth();
        }

        /// <summary>
        /// Resets the splitter distance on double click.
        /// </summary>
        private void splitKPIDesc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetSplitter();
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        private void workDashData_DoWork(object sender, DoWorkEventArgs e)
        {
            FormBuilt = false;
            this.dataLoaded = false;
            this.kpiConfigs = Dashboards.GetKPIConfigs(Convert.ToInt16(this.dashType));
            this.kpiActionRules = Dashboards.GetKPIActionRules();
            this.kpiDatas = Dashboards.GetKPIData(this.startDate, Convert.ToInt16(this.dashDayView));
            this.groupConfigs = Dashboards.GetGroupConfigs();
            this.kpiWeeklyData = Dashboards.GetWeeklyKPIData(
                TimeFunctions.GetWeekNumber(this.startDate),
                this.startDate.Year);
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        private void workDashData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.dataLoaded = true;
            BuildForm();
            FormBuilt = true;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mouse Leave event handler for Value Box Labels.
        /// </summary>
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (sender is Label)
            {
                Label lbl = (Label)sender;
                lbl.BackColor = Color.FromArgb(255, lbl.BackColor);
            }
        }

        /// <summary>
        /// Mouse Enter event handler for Value Box Labels.
        /// </summary>
        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            //Solves unwanted behaviour issues with tooltips.
            toolTip1.Active = false;
            toolTip1.Active = true;
            if (sender is Label)
            {
                Label lbl = (Label)sender;
                lbl.BackColor = Color.FromArgb(100, lbl.BackColor);

                if (lbl.Tag != null &&
                    lbl.Tag is Elvis.Model.KPIConfigWithDayNo)
                {
                    KPIConfigWithDayNo config = (KPIConfigWithDayNo)lbl.Tag;
                    string toolTip = "";
                    if (!string.IsNullOrWhiteSpace(config.ToolTip)) //Add new line space
                        toolTip = Environment.NewLine + config.ToolTip;

                    //Need to enable the tooltips here otherwise we get strange
                    //tooltip behavior.
                    if (config.DayNo == -1)
                    {//Weekly Box
                        toolTip1.SetToolTip(lbl,
                            "Week " + TimeFunctions.GetWeekNumber(this.startDate).ToString()
                            );
                    }
                    else
                    {
                        toolTip1.SetToolTip(lbl,
                            this.startDate.AddDays(config.DayNo).ToString("dddd, dd MMM yyyy") +
                            toolTip + GetAdditionalToolTipInfo(config)
                            );
                    }
                }
            }
        }

        /// <summary>
        /// Mouse Click event handler for the Value Box Labels.
        /// </summary>
        private void lbl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender is Label)
                {
                    Label lblClicked = (Label)sender;
                    if (lblClicked.Tag != null &&
                        lblClicked.Tag is Elvis.Model.KPIConfigWithDayNo)
                    {
                        Elvis.Model.KPIConfigWithDayNo config = (Elvis.Model.KPIConfigWithDayNo)lblClicked.Tag;
                        TakeKPIAction(config);
                    }
                }
            }
        }

        /// <summary>
        /// KPI Label Click Event Handler.
        /// Gets the KPI Config Clicked and passes event to
        /// Main Dashboard to Handle.
        /// </summary>
        private void lblLeftKPIDescRow_MouseClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                sender is Label)
            {
                Label lblClicked = (Label)sender;
                if (lblClicked.Tag != null && lblClicked.Tag is KPIConfig)
                {
                    KPIConfig kpiClicked = (KPIConfig)lblClicked.Tag;

                    if (this.KPILabelClick != null)
                    {
                        this.KPILabelClick(kpiClicked);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// KPI Label Enter Event Handler.
        /// </summary>
        private void lblLeftKPIDescRow_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label lbl = (Label)sender;
                lbl.BackColor = Color.FromArgb(100, ColorTranslator.FromHtml("#3399FF"));
            }
        }

        /// <summary>
        /// KPI Label Leave Event Handler.
        /// </summary>
        private void lblLeftKPIDescRow_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label lbl = (Label)sender;
                if (lbl.Tag != null && lbl.Tag is KPIConfig)
                {
                    KPIConfig config = (KPIConfig)lbl.Tag;
                    lbl.BackColor = Colours.GetKPIBackColour(config);
                }
            }
        }

        /// <summary>
        /// Exposes an event for when the form has finished building.
        /// </summary>
        protected virtual void OnFormBuilt()
        {
            if (FormHasBuilt != null) FormHasBuilt(this, EventArgs.Empty);
        }
    }
}
