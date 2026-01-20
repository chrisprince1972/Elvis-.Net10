using BusinessLogic.Constants;
using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.TrendingShifts;
using BusinessLogic.Models.ViewModels;
using BusinessLogic.Models.ViewModels.TrendingShifts;
using Elvis.Common;
using Elvis.Forms.Reports.CasterMachineCondition;
using Elvis.Forms.Reports.Miscasts;
using Elvis.Model;
using Elvis.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elvis.Forms.TrendingShifts.UserControls
{
    public partial class DashboardUserControl : UserControl
    {
        #region Variables and Properties

        private static readonly int SINGLE_BOX_WIDTH =
            Settings.Default.DashboardSingleBoxWidth;
        private const int WEEKLY_COLUMN_WIDTH = 60;
        private const int LEVEL_COLUM_WIDTH = 30;
        private const int DESC_MIN_SIZE = 142;
        private static readonly Font HEADER_FONT =
            new Font("Tahoma", 10, FontStyle.Bold);
        private static readonly Font COLUMN_HEADER_FONT =
            new Font("Tahoma", 8F, FontStyle.Bold);
        private static readonly Font DESCRIPTION_FONT =
            new Font("Tahoma", 8F, FontStyle.Regular);

        private Padding DATA_BOX_PADDING =
            Settings.Default.DashboardBoxPadding;
        private Font kpiValueFont = Settings.Default.DashboardBoxFont;

        private bool DataLoaded = false;
        private int WidestDescriptionLength { get; set; }
        private int WidestLevelLength { get; set; }
        private Panel pnlMonthly = new Panel();
        private Panel pnlCentreKPIData = new Panel();
        private BackgroundWorker workDashData = new BackgroundWorker();


        private TrendShift Trend;
        private ElvisSettings ElvisSettings;


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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowMonthly { get; set; }
        public bool MiscastAdmin { get; private set; }
        public int RowHeight { get; private set; }
        public int RowCount { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DashboardType Type { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rota Rota { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DashboardDayView DashboardDayView { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate { get; set; }

        private Panel PanelKpiLevel { get; set; }
        private Panel PanelKpiDescription { get; set; }
        private bool FormBuilt { get; set; }
        private Splitter SplitDescription { get; set; }
        private Label StatusBar { get; set; }


        #endregion Variables and Properties
        public delegate void KpiLabelClickEventHandler(KpiConfigShiftWrapper sender);
        public event KpiLabelClickEventHandler KpiLabelClick;
        public delegate void KpiLabelMouseEnterEventHandler(string sender);
        public event KpiLabelMouseEnterEventHandler KpiLabel_MouseEnter;
        public delegate void KpiLabelMouseLeaveEventHandler();
        public event KpiLabelMouseLeaveEventHandler KpiLabel_MouseLeave;

        /// <summary>
        /// Fires when a TIB Delay KPI is Clicked on the Dashboard.
        /// </summary>
        /// <param name="dateTime">The Date Time that was clicked.</param>
        public delegate void DashboardTIBClickEventHandler(DateTime dateTime);

        public event DashboardTIBClickEventHandler DashboardTIBClickEvent;

        /// <summary>
        /// Creates a new instance of the
        /// Elvis Dashboard User Control.
        /// </summary>
        public DashboardUserControl()
        {
            InitializeComponent();
            SetupBackgroundWorker();
            ShowLoading();

            SplitDescription = new Splitter();

            StartDate = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, 1, 0, 0, 0);

            RowHeight = Settings.Default.DashboardRowHeight;
            RowCount = 0;
            Rota = Rota.A;
            FormBuilt = false;
            ElvisSettings = HelperFunctions.GetElvisSettings();

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

            Dispose(pnlMain);
            pnlMain.Controls.Add(picBox);
            picBox.Dock = DockStyle.Fill;
            picBox.BringToFront();
            picBox.Refresh();
        }

        public void Reload()
        {
            try
            {
                WidestDescriptionLength = WidestLevelLength = 0;
                ShowLoading();
                LoadData();
            }
            catch (Exception e)
            {
                HandleException("Error loading kpis. ", e);
            }
        }


        public void SetupUserControl(bool miscastAdmin, Label statusBar)
        {
            try
            {
                MiscastAdmin = miscastAdmin;
                StatusBar = statusBar;
                Reload();
            }
            catch (Exception e)
            {
                HandleException("Error loading kpis. ", e);
            }
        }


        /// <summary>
        /// Sets up the splitter to display all of the data value boxes.
        /// </summary>
        public void SetSplitter()
        {
            PanelKpiDescription.Width = DESC_MIN_SIZE;
        }


        /// <summary>
        /// Exposes an event for when the form has finished building.
        /// </summary>
        protected virtual void OnFormBuilt()
        {
            if (FormHasBuilt != null) FormHasBuilt(this, EventArgs.Empty);
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
            if (!workDashData.IsBusy && this.DataLoaded)
            {
                List<Tuple<DateTime, Shift>> shiftsToView =
                        Trend.GetShiftsWithData(Rota);

                RowCount = 0;
                AddStructuralLayoutControls(shiftsToView.Count);
                AddFixedContent(shiftsToView);
                AddDatabaseContent(shiftsToView);
            }
        }

        /// <summary>
        /// Adds the Main Structural Controls to the Dashboard.
        /// </summary>
        private void AddStructuralLayoutControls(int numberOfColumns)
        {

            Dispose(PanelKpiLevel);
            Dispose(PanelKpiDescription);
            Dispose(pnlMonthly);
            Dispose(pnlCentreKPIData);

            if (ShowMonthly)
            {
                pnlMonthly = SetupPanel(
                    Settings.Default.ColourDashHeaderBack,
                    DockStyle.Right,
                    WEEKLY_COLUMN_WIDTH,
                    0, BorderStyle.FixedSingle);
            }

            PanelKpiLevel = SetupPanel(
                Settings.Default.ColourDashHeaderBack, DockStyle.Left,
                LEVEL_COLUM_WIDTH, 0, BorderStyle.FixedSingle);

            PanelKpiDescription = SetupPanel(
                Settings.Default.ColourDashHeaderBack,
                DockStyle.Left, WidestDescriptionLength, 0, 
                BorderStyle.FixedSingle);
            PanelKpiDescription.AutoScroll = true;
            SplitDescription.Dispose();
            SplitDescription = new Splitter();
            SplitDescription.BackColor = SystemColors.ControlLightLight;
            pnlMain.Controls.Add(SplitDescription);
            SplitDescription.Dock = DockStyle.Left;
            SplitDescription.Width = 4;
            SplitDescription.BringToFront();
            SplitDescription.MouseDoubleClick +=
                new MouseEventHandler(splitKPIDesc_MouseDoubleClick);

            pnlCentreKPIData = SetupPanel(
                Settings.Default.ColourDashHeaderBack,
                DockStyle.Fill,
                numberOfColumns * SINGLE_BOX_WIDTH, 0, 
                BorderStyle.FixedSingle);
            pnlCentreKPIData.AutoScroll = true;
        }

        /// <summary>
        /// Adds any fixed content to the page that is
        /// not generated from the database.
        /// </summary>
        private void AddFixedContent(List<Tuple<DateTime, Shift>> shiftsToView)
        {
            AddDates(shiftsToView);
            if (ShowMonthly)
            {
                AddMonthlyTitle();
            }
            RowCount++;
        }

        /// <summary>
        /// Adds the Database content.
        /// </summary>
        private void AddDatabaseContent(
            List<Tuple<DateTime, Shift>> shiftsToShow)
        {
            AddGenericSpacer(PanelKpiLevel, Color.Transparent);
            AddGenericSpacer(PanelKpiDescription, Color.Transparent);
            
            foreach (KpiConfigShiftDataWrapper config in Trend.KpiConfigs)
            {
                if (config.Content())
                {
                    AddRowContent(config, shiftsToShow);
                    RowCount++;
                }
                else if (config.Spacer())
                {
                    if (AddFullSpacerRow(config, shiftsToShow.Count))
                    {
                        RowCount++;
                    }
                }
            }
            //Adds scroll bar if the width is too large for the screen.
            PanelKpiDescription.AutoScrollMinSize =
                new Size(WidestDescriptionLength, 0);

            PanelKpiLevel.Width = WidestLevelLength;
            PanelKpiDescription.Visible = true;
        }

        /// <summary>
        /// Adds a full row spacer to the dashboard.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private bool AddFullSpacerRow(KpiConfigShiftDataWrapper config, 
            int columnCount)
        {
            bool spaceAdded = false;
            spaceAdded = AddSpacerToPanel(config, PanelKpiLevel);
            spaceAdded = AddSpacerToPanel(config, PanelKpiDescription);

            if (ShowMonthly)
            {
                spaceAdded = AddSpacerToPanel(config, pnlMonthly);
            }

            if (spaceAdded)
            {
                AddSpacerToCentreKPIData(config, columnCount);
            }

            return spaceAdded;
        }
        
        private void WidenLevelLength(Control c)
        {
            WidestLevelLength = GetWidthIfLarger(c, WidestLevelLength, 
                DESCRIPTION_FONT);
        }

        private void WidenDescriptionLength(Control c)
        {
            WidestDescriptionLength = GetWidthIfLarger(c, 
                WidestDescriptionLength, DESCRIPTION_FONT);
        }

        private void AddRowContent(KpiConfigShiftDataWrapper config,
            List<Tuple<DateTime, Shift>> shiftsToShow)
        {
            KpiRow row = new KpiRow(ElvisSettings, config, Rota, StartDate,
                shiftsToShow);

            AddKpiLevel(row.RowLevel);
            AddKpiDescription(row.RowDescription);
            AddKpiData(row, shiftsToShow.Count);
            if (ShowMonthly && row.KpiDataMonth != null)
            {
                Panel singleDataBox = GetDataBox(pnlMonthly, row.KpiDataMonth);
                singleDataBox.Dock = DockStyle.Top;
                singleDataBox.BringToFront();
            }
        }

        private void AddKpiLevel(KpiLabel label)
        {
            Panel kpiLevel = AddKpiTitle(label, ContentAlignment.MiddleRight);
            WidenLevelLength(kpiLevel.Controls[0]);
            PanelKpiLevel.Controls.Add(kpiLevel);
            kpiLevel.BringToFront();

        }
        private void AddKpiDescription(KpiLabel label)
        {
            Panel kpiDesc = AddKpiTitle(label, ContentAlignment.MiddleLeft);
            WidenDescriptionLength(kpiDesc.Controls[0]);
            PanelKpiDescription.Controls.Add(kpiDesc);
            kpiDesc.Cursor = Cursors.Hand;
            kpiDesc.BringToFront();

            kpiDesc.Controls[0].MouseClick +=
                new MouseEventHandler(kpiDescriptionPanel_MouseClick);
            kpiDesc.Controls[0].MouseEnter +=
                new EventHandler(kpiDescriptionPanel_MouseEnter);
            kpiDesc.Controls[0].MouseLeave +=
                new EventHandler(kpiDescriptionPanel_MouseLeave);
        }
        private void AddKpiData(KpiRow row, int columnCount)
        {
            int width = SINGLE_BOX_WIDTH * columnCount;

            Panel dataHolder = new Panel()
            {
                Height = RowHeight,
                Width = width,
                BackColor = row.BackColor
            };

            if (row.Action)
            {
                dataHolder.Cursor = Cursors.Hand;
            }

            int locationCounter = 0;
            foreach (KpiLabel l in row.KpiData)
            {
                Panel singleDataBox =
                    GetDataBox(dataHolder, l);
                singleDataBox.Location =
                    new Point(locationCounter++ * SINGLE_BOX_WIDTH, 0);
            }


            pnlCentreKPIData.Controls.Add(dataHolder);
            dataHolder.Location = new Point(0, RowHeight * RowCount);
        }

        private Panel GetDataBox(Panel dataHolder, KpiLabel config)
        {
            Panel singleDataBox = new Panel()
            {
                Height = RowHeight,
                Width = SINGLE_BOX_WIDTH,
                Padding = DATA_BOX_PADDING,
                Controls = { GetDataLabel(config) }
            };

            dataHolder.Controls.Add(singleDataBox);
            return singleDataBox;
        }
        private Label GetDataLabel(KpiLabel config)
        {
            Label returnValue = new Label()
            {
                Font = kpiValueFont,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = config.BackColor,
                ForeColor = config.ForeColor,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = config.Tag,
                Text = config.Text,
                Dock = DockStyle.Fill

            };

            //tt.SetToolTip(returnValue, config.ToolTip);

            returnValue.MouseEnter += new EventHandler(lbl_MouseEnter);
            returnValue.MouseLeave += new EventHandler(lbl_MouseLeave);
            returnValue.MouseClick += new MouseEventHandler(lbl_MouseClick);

            return returnValue;
        }


        private Panel AddKpiTitle(KpiLabel label, ContentAlignment align)
        {
            Label lblkpiRowTitle = new Label()
            {
                Text = label.Text,
                Font = DESCRIPTION_FONT,
                TextAlign = align,
                ForeColor = label.ForeColor,
                Dock = DockStyle.Fill,
                Tag = label.Tag
            };

            //if (label.ToolTip != string.Empty)
            //{
            //    toolTip1.SetToolTip(lblkpiRowTitle, label.ToolTip);
            //}

            Panel returnValue = new Panel()
            {
                Height = RowHeight,
                BackColor = label.BackColor,
                Dock = DockStyle.Top,
                Controls =
                {
                    lblkpiRowTitle,
                }
            };


            return returnValue;
        }
        
        private int GetWidthIfLarger(Control control, 
            int widestWidthSoFar, Font font)
        {
            int newWidth = 
                HelperFunctions.GetFontSizeInPixels(control, font).Width;
            if (newWidth > widestWidthSoFar)
                return newWidth;
            return widestWidthSoFar;
        }


        /// <summary>
        /// Adds a spacer to the Centre Data to add colour.
        /// </summary>
        /// <param name="config">The KPIConfig</param>
        private void AddSpacerToCentreKPIData(KpiConfigShiftDataWrapper config,
            int columnCount)
        {
            Panel dataHolder = new Panel()
            {
                Height = RowHeight,
                Width = (int)(SINGLE_BOX_WIDTH * columnCount * 0.75),
                Location = new Point(0, RowHeight * RowCount),
                BackColor = config.GetKpiBackgroundColour()
            };

            this.pnlCentreKPIData.Controls.Add(dataHolder);
        }

        /// <summary>
        /// Decides what to do when a Value Box is clicked,
        /// based on the KPIConfig.KPIActionIndex value.
        /// </summary>
        /// <param name="config">The KPIConfig to interrogate.</param>
        private void TakeKPIAction(KpiConfigShiftSingleDataWrapper config)
        {
            if (config != null &&
                config.Action != null)
            {
                switch (config.Action.Index)
                {
                    case DashboardActionType.Trending:
                        LoadTrendingForm(config);
                        break;

                    case DashboardActionType.Miscast:
                        LoadMiscastReports(config);
                        break;

                    case DashboardActionType.Rft:
                        LoadRFTSummary(config);
                        break;

                    case DashboardActionType.SlabStock:
                        LoadSlabStockSummary(config);
                        break;

                    case DashboardActionType.Tib:
                        LoadTIBDisplay(config);
                        break;

                    case DashboardActionType.CasterMachineConditioning:
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
        private void LoadTrendingForm(KpiConfigShiftSingleDataWrapper config)
        {
            this.Cursor = Cursors.WaitCursor;

            Trending.TrendingForm trendingForm = 
                new Trending.TrendingForm(MiscastAdmin);
            if (config.Action != null && config.Action.Group != null)
            {
                DateTime trendStartDate = StartDate;
                DateTime trendEndDate = StartDate.AddDays(7);
                
                trendStartDate = config.Data.Date;
                trendEndDate = trendStartDate.AddDays(1);

                trendingForm.LoadSpecificDateAndGroup(
                    trendStartDate,
                    trendEndDate,
                    config.Action.Group.GroupIndex);
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
        private void LoadMiscastReports(KpiConfigShiftSingleDataWrapper config)
        {
            this.Cursor = Cursors.WaitCursor;

            Tuple<string, string> areaTuple = GetAreaTuple();

            MiscastFilterHolder miscastFilterValues = new MiscastFilterHolder()
            {
                ComboFilterList = new List<Tuple<string, string>>()
            };

            miscastFilterValues.AddFunctionArea(config.GetMiscastFunctionArea());

            if (areaTuple != null)
            {
                miscastFilterValues.ComboFilterList.Add(areaTuple);
            }


            if (config.Data == null)
            {//If month has been clicked default to the start date.
                miscastFilterValues.DateFrom = StartDate;
                miscastFilterValues.DateTo = StartDate.AddMonths(1).AddMilliseconds(-1);
            }
            else
            {
                miscastFilterValues.DateFrom = config.Data.Date;
                miscastFilterValues.DateTo = config.Data.Date.AddHours(7);
            }

            MiscastMainNew miscastMain = new MiscastMainNew(
                miscastFilterValues, MiscastAdmin);
            miscastMain.Show();

            Cursor = Cursors.Default;
        }

        private Tuple<string, string> GetAreaTuple()
        {
            string primaryFilter = Enum.GetName(typeof(DashboardType), Type);

            if (!string.IsNullOrWhiteSpace(primaryFilter) && primaryFilter != "CMM")
            {
                return new Tuple<string, string>(
                     "Area", primaryFilter);
            }
            return null;
        }

        /// <summary>
        /// Loads the RFT Summary Form for
        /// that specific date range.
        /// </summary>
        /// <param name="config">The KPIConfig object associated
        /// with the clicked Label Tag.</param>
        private void LoadRFTSummary(KpiConfigShiftSingleDataWrapper config)
        {
            this.Cursor = Cursors.WaitCursor;
            //Remove Time values.
            DateTime date = StartDate.Date;

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
        private void LoadSlabStockSummary(KpiConfigShiftSingleDataWrapper config)
        {
            this.Cursor = Cursors.WaitCursor;
            //Remove Time values.
            DateTime date = StartDate.Date;

            SlabStockSummary slabStockSummary = new SlabStockSummary();
            slabStockSummary.SetupForm(date);
            slabStockSummary.Show();

            this.Cursor = Cursors.Default;
        }

        private void LoadTIBDisplay(KpiConfigShiftSingleDataWrapper config)
        {
            if (this.DashboardTIBClickEvent != null)
            {
                this.DashboardTIBClickEvent(config.Data.Date);
            }
        }

        private bool AddSpacerToPanel(KpiConfigShiftDataWrapper config, Panel pnlToAddSpacerTo)
        {
            if (config.SubLevel == 0 && Trend.OneConfig(config.Level))
            {
                AddGenericSpacer(pnlToAddSpacerTo, config.GetKpiBackgroundColour());
                return true;
            }
            else if (config.SubLevel > 1)
            {
                AddGenericSpacer(pnlToAddSpacerTo, config.GetKpiBackgroundColour());
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a spacer to the given panel.
        /// </summary>
        /// <param name="pnlToAddSpacerTo">The Panel to add to.</param>
        private void AddGenericSpacer(Panel pnlToAddSpacerTo, Color backColor)
        {

            Panel pnlSpacer = new Panel()
            {
                Height = RowHeight,
                BackColor = backColor
            };

            pnlToAddSpacerTo.Controls.Add(pnlSpacer);
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.BringToFront();
        }


        /// <summary>
        /// Adds the Dates fixed line to the dashboard.
        /// </summary>
        private void AddDates(List<Tuple<DateTime, Shift>> shiftsToView)
        {
            Dispose(pnlCentreKPIData);
            
            Panel datesHolder = new Panel()
            {
                Height = RowHeight,
                Width = (SINGLE_BOX_WIDTH * shiftsToView.Count),
                Location = new Point(0, RowHeight * RowCount),
                BackColor = Settings.Default.ColourDashHeaderBack
            };

            pnlCentreKPIData.Controls.Add(datesHolder);


            int location = 0;


            foreach (var shiftToView in shiftsToView)
            {
                string dayNightAbreviation =
                    shiftToView.Item2 == Shift.Day ? "D" : "N";



                Label lblDate = new Label()
                {
                    Text = shiftToView.Item1.ToString("dd/MM") +
                            dayNightAbreviation,
                    Font = COLUMN_HEADER_FONT,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Settings.Default.ColourDashHeaderText,
                    Dock = DockStyle.Fill
                };


                Panel singleDateBox = new Panel()
                {
                    Height = RowHeight,
                    Width = SINGLE_BOX_WIDTH,
                    Controls = { lblDate }
                };

                singleDateBox.Controls.Add(lblDate);

                datesHolder.Controls.Add(singleDateBox);
                singleDateBox.Location = new Point(location++ * SINGLE_BOX_WIDTH, 0);
            }
        }

        private void AddMonthlyTitle()
        {
            Dispose(pnlMonthly);

            Panel singleBox = new Panel()
            {
                Height = RowHeight,
                BackColor = Settings.Default.ColourDashHeaderBack
            };

            Label Monthly = new Label()
            {
                Text = "Month " + StartDate.Month.ToString(),
                Font = COLUMN_HEADER_FONT,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Settings.Default.ColourDashHeaderText
            };

            singleBox.Controls.Add(Monthly);
            Monthly.Dock = DockStyle.Fill;

            pnlMonthly.Controls.Add(singleBox);
            singleBox.Dock = DockStyle.Top;
            singleBox.BringToFront();
        }

        private Panel SetupPanel(Color backColour, DockStyle dockStyle,
            int width, int height, BorderStyle border)
        {
            Panel returnValue = new Panel();
            returnValue.BackColor = backColour;
            pnlMain.Controls.Add(returnValue);
            returnValue.Dock = dockStyle;
            returnValue.BorderStyle = border;

            if (width > 0)
                returnValue.Width = width;
            if (height > 0)
                returnValue.Height = height;

            returnValue.BringToFront();

            return returnValue;
        }


        private void HandleException(string message, Exception ex)
        {
            MessageBox.Show(message + "Report this incident to Process Control through the helpdesk #6212 with time and username.");
            NLog.LogManager.GetCurrentClassLogger().FatalException("DashboardUserControl workDashData_RunWorkerCompleted trend shift data exception. ", ex);
            Form parent = TopLevelControl as Form;
            if (parent != null)
            {
                parent.Close();
            }
        }

        private static void Dispose(Panel panelToDispose)
        {
            if (panelToDispose != null && !panelToDispose.IsDisposed)
            {
                for (int i = panelToDispose.Controls.Count - 1; i >= 0; i--)

                {
                    Control controlToDispose = panelToDispose.Controls[i];
                    Panel controlAsPanel = controlToDispose as Panel;
                    if (controlAsPanel == null)
                    {
                        controlToDispose.Dispose();
                        controlToDispose = null;
                    }
                    else
                    {
                        //if control is a panel then dispose all of the 
                        //controls under that panel before disposing it.
                        Dispose(controlAsPanel);
                        controlAsPanel.Dispose();
                    }
                }
            }
        }


        private void splitKPIDesc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetSplitter();
        }

        private void workDashData_DoWork(object sender, DoWorkEventArgs e)
        {
            DataLoaded = true;
            try
            {
                Trend = new TrendShift(ElvisSettings, Type, StartDate.Year, StartDate.Month);

            }
            catch (Exception ex)
            {
                workDashData.CancelAsync();
                HandleException("Error loading trend shift data. ", ex);
            }
        }

        private void workDashData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataLoaded = true;
                BuildForm();
                OnFormBuilt();
                FormBuilt = true;
            }
            catch (Exception ex)
            {
                HandleException("Error displaying trend shift data. ", ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                var lbl = sender as Label;
                if (lbl != null)
                {
                    lbl.BackColor = Color.FromArgb(100, lbl.BackColor);

                    var kpiConfig =
                            lbl.Tag
                            as KpiConfigShiftSingleDataWrapper;

                    if (kpiConfig != null)
                    {
                        if (KpiLabel_MouseEnter != null)
                        {
                            KpiLabel_MouseEnter(kpiConfig.GetToolTip(false));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                HandleException("Error loading trend shift data. ", ex);
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.Default;

                var lbl = sender as Label;
                if (lbl != null)
                {
                    lbl.BackColor = Color.FromArgb(255, lbl.BackColor);
                    if (KpiLabel_MouseLeave != null)
                    {
                        KpiLabel_MouseLeave();
                    }
                }

            }
            catch (Exception ex)
            {
                HandleException("Error loading trend shift data. ", ex);
            }
        }

        private void lbl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    var lblClicked = sender as Label;
                    if (sender != null)
                    {
                        var config = lblClicked.Tag as KpiConfigShiftSingleDataWrapper;
                        if (config != null)
                        {
                            TakeKPIAction(config);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException("Error loading trend shift data. ", ex);
            }
        }


        private void kpiDescriptionPanel_MouseClick(object sender, 
            MouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    var panelClicked = sender as Label;

                    if (panelClicked != null && panelClicked.Tag != null)
                    {
                        var kpiClicked = panelClicked.Tag as KpiConfigShiftWrapper;
                        if (KpiLabelClick != null)
                        {
                            KpiLabelClick(kpiClicked);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HandleException("Error loading trend shift data. ", ex);
            }
            Cursor = Cursors.Default;
        }
        private void kpiDescriptionPanel_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                var labelEntered = sender as Label;
                if (labelEntered != null)
                {
                    labelEntered.BackColor =
                        Color.FromArgb(100,
                            ColorTranslator.FromHtml("#3399FF"));

                    var kpiConfig =
                            labelEntered.Tag
                            as KpiConfigShiftDataWrapper;

                    if (kpiConfig != null)
                    {
                        if (KpiLabel_MouseEnter != null)
                        {
                            KpiLabel_MouseEnter(kpiConfig.Description);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                HandleException("Error loading trend shift data. ", ex);
            }
        }

        private void kpiDescriptionPanel_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                var labelEntered = sender as Label;
                if (labelEntered != null)
                {
                    var kpiConfig =
                            labelEntered.Tag 
                            as KpiConfigShiftDataWrapper;

                    if (kpiConfig != null)
                    {
                        labelEntered.BackColor = 
                            kpiConfig.GetKpiBackgroundColour();
                    }

                    if (KpiLabel_MouseLeave!= null)
                    {
                        KpiLabel_MouseLeave();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException("Error showing trend shift data. ", ex);
            }
        }
    }
}
