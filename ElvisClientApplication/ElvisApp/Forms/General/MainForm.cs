using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.Reports.Incident;
using Elvis.Common;
using Elvis.Forms.Coordination;
using Elvis.Forms.General;
using Elvis.Forms.Ladles;
using Elvis.Forms.Reports;
using Elvis.Forms.Reports.CasterMachineCondition;
using Elvis.Forms.Reports.DRF;
using Elvis.Forms.Reports.I3;
using Elvis.Forms.Reports.Miscasts;
using Elvis.Forms.Reports.OEE;
using Elvis.Forms.Trending;
using Elvis.Forms.UserConfiguration;
using Elvis.Forms.Users;
using Elvis.Model;
using Elvis.Properties;
using Elvis.UserControls;
using Elvis.UserControls.Caster;
using Elvis.UserControls.HeatDetails;
using Elvis.UserControls.Tib;
using ElvisDataModel;
using ElvisDataModel.EDMX;

using MLJSystems.Calendars;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UiUnit = Elvis.Model.Unit;
using DbUnit = ElvisDataModel.EDMX.Unit;
namespace Elvis.Forms
{
    public partial class MainForm : Form
    {
        #region Variables + Properties

        #region Variables
        private bool quickOptionsVisible;
        private bool hasLoaded;
        public enum Scheduler { Heat, Tib, Caster };
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private QuickTibCustoms tibCustoms;
        private QuickHeatCustoms heatCustoms;
        private QuickCasterCustoms casterCustoms;
        private SplashScreen splash;
        private DateTimePicker picker;
        private QuickHeatDetails ucHeatDetails;
        private QuickTibDetails ucTibDetails;
        private List<DbUnit> units;
        #endregion

        #region Properties
        //Used for skipping the splash screen for development
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SkipSplash { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFullScreen { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan CountDown { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAdmin { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerUser { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTIBAdmin { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOperator { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsKPIAdmin { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMiscastAdmin { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Scheduler CurrentScheduler { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TibScheduler SchedulerTib { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HeatScheduler SchedulerHeat { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CasterReviewScheduler SchedulerCaster { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool QuickOptionsVisible
        {
            get
            {
                return quickOptionsVisible;
            }
            set
            {
                quickOptionsVisible = value;
                splitContainer1.IsSplitterFixed = !value;

                if (value)//Show
                {
                    btnShowHide.Image = Resources.HideButtonSmall;
                    splitContainer1.Panel2MinSize = 147;
                    splitContainer1.SplitterDistance =
                        splitContainer1.Panel1.ClientSize.Height -
                        147;
                    btnShowHide.Tag = "Hide";
                }
                else//Hide
                {
                    btnShowHide.Image = Resources.ShowButtonSmall;
                    splitContainer1.Panel2MinSize = 8;
                    splitContainer1.SplitterDistance =
                        splitContainer1.Panel1.ClientSize.Height +
                        splitContainer1.Panel2.ClientSize.Height;
                    btnShowHide.Tag = "Show";
                }
            }
        }

        /// <summary>
        /// Indicates whether the Scheduler instance pointed to by the
        /// CurrentScheduler property is null or not.
        /// </summary>
        public bool CurrentSchedulerIsNotNull
        {
            get
            {
                bool schedulerIsNotNull = false;
                switch (CurrentScheduler)
                {
                    case Scheduler.Caster:
                        schedulerIsNotNull = SchedulerCaster != null;
                        break;
                    case Scheduler.Heat:
                        schedulerIsNotNull = SchedulerHeat != null;
                        break;
                    case Scheduler.Tib:
                        schedulerIsNotNull = SchedulerTib != null;
                        break;
                    default:
                        break;
                }
                return schedulerIsNotNull;
            }
        }

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Main Form, which by default adds in the heat
        /// scheduler on start up.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.splash = new SplashScreen(this);
            GetUnits();
            this.quickOptionsVisible = true;
        }
        #endregion

        #region Main Form
        /// <summary>
        /// Datetime picker must be added to toolbar in code (cannot be done through designer).
        /// </summary>
        private void AddDateTimePickerToToolbar()
        {
            picker = new DateTimePicker();
            picker.Width = 90;
            picker.ValueChanged += new EventHandler(DatePickerValueChanged);
            picker.Format = DateTimePickerFormat.Short;
            toolStripTimeControls.Items.Insert(10, new ToolStripControlHost(picker));
        }

        /// <summary>
        /// Sets the IPrincipal for the UI thread, and sets up menu options according to
        /// the current User's roles in Elvis.
        /// </summary>
        private void ConfigureUserAuthorisation()
        {
            try
            {
                SecurityLayer.SetCurrentPrincipal();

                IsAdmin = Thread.CurrentPrincipal.IsInRole("Administrators");
                IsPowerUser = Thread.CurrentPrincipal.IsInRole("PowerUsers");
                IsTIBAdmin = Thread.CurrentPrincipal.IsInRole("TIBAdmin");
                IsOperator = Thread.CurrentPrincipal.IsInRole("Operator");
                IsKPIAdmin = Thread.CurrentPrincipal.IsInRole("KPIAdmin");
                IsMiscastAdmin = Thread.CurrentPrincipal.IsInRole("MiscastAdmin");

                if (IsAdmin)
                {
                    //Set all to true
                    toolsMenuAuthorisationSeparator.Visible =
                    configurationEditorToolStripMenuItem.Visible =
                    trendingConfigurationToolStripMenuItem.Visible =
                    steelmakingDailyInputsToolStripMenuItem.Visible =
                    toolStripSeparatorSteelmakingTools.Visible =
                    tIBAdminToolStripMenuItem.Visible =
                    configurationEditorToolStripMenuItem.Enabled =
                    trendingConfigurationToolStripMenuItem.Enabled =
                    steelmakingDailyInputsToolStripMenuItem.Enabled =
                    tIBAdminToolStripMenuItem.Enabled =
                    userManagementToolStripMenuItem.Visible =
                    userManagementToolStripMenuItem.Enabled =
                        true;
                }

                if (IsPowerUser)
                {
                    //Set all to true
                    toolsMenuAuthorisationSeparator.Visible =
                    configurationEditorToolStripMenuItem.Visible =
                    trendingConfigurationToolStripMenuItem.Visible =
                    tIBAdminToolStripMenuItem.Visible =
                    configurationEditorToolStripMenuItem.Enabled =
                    trendingConfigurationToolStripMenuItem.Enabled =
                    tIBAdminToolStripMenuItem.Enabled =
                        true;
                }

                if (IsTIBAdmin)
                {
                    //Set all to true
                    toolsMenuAuthorisationSeparator.Visible =
                    tIBAdminToolStripMenuItem.Visible =
                    tIBAdminToolStripMenuItem.Enabled =
                        true;
                }

                if (IsOperator)
                {
                    steelmakingDailyInputsToolStripMenuItem.Visible =
                    steelmakingDailyInputsToolStripMenuItem.Enabled =
                    toolStripSeparatorSteelmakingTools.Visible =
                        true;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(string.Format(
                    "Authorisation Configuration Error. Data - {0}: InnerException - {1}: "
                    + " Message - {2}: Source - {3}: TargetSite - {4}",
                    ex.Data, ex.InnerException, ex.Message,
                    ex.Source, ex.TargetSite), ex);
            }
        }

        /// <summary>
        /// Method that checks if the version running is the standalone version
        /// on a terminal server.  If so apply certain settings.
        /// </summary>
        private void ConfigureStandaloneVersion()
        {
            if (this.Text.ToUpper().Contains("STANDALONE"))
            {
                //Permanent Full Screen Mode!
                IsFullScreen = !IsFullScreen;
                HelperFunctions.GoFullscreen(IsFullScreen, this);
                fullScreenToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Checks Memory Usage of the Application. Logs any abnormalities
        /// and Exits App if memory usage above the users set option.
        /// </summary>
        private void CheckMemoryUsage()
        {
            Process currentProc = Process.GetCurrentProcess();
            long memory = currentProc.PrivateMemorySize64;
            memory = memory / 1000000;//Change to MB

            //Memory exceeds safe value so restart the app and log
            if (memory > Settings.Default.MemoryLimit)
            {
                timerCountDown.Stop();
                logger.Error(
                    "Memory usage exceeded safe value - Memory Usage: " + memory);
                MessageBox.Show(
                    "Memory usage exceeded safe value. Application will now exit. This has been logged. If error persists, please see Options to modify limit.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }

            //If running development in Visual Studio show mem usage
            toolStripMemUsage.Text = "Memory Usage: " + memory + "MB";
            toolStripMemUsage.Visible = Debugger.IsAttached;
        }

        /// <summary>
        /// Sets the username label to display the user.
        /// </summary>
        private void SetUsernameLabel()
        {
            this.usernameStatusLabel.Text = "User: " + Environment.UserName;
        }

        /// <summary>
        /// Sets the session time label to display an up to date session time.
        /// </summary>
        private void SetSessionTimeLabel()
        {
            this.sessionStatusLabel.Text = "Session: " + ProcessHelper.GetProcessDuraton.ToString("hh\\:mm\\:ss");
        }

        /// <summary>
        /// Sets the countdown label
        /// </summary>
        private void SetCountdownLabel()
        {
            this.statusLabel.Text = "Ready - Refresh in " + CountDown.ToString("mm\\:ss");
        }

        /// <summary>
        /// Sets up the screen depending on what scheduler is selected.
        /// </summary>
        private void SetupScreenForNewScheduler()
        {
            picker.Visible = true;
            toolStripButtonForward.Enabled = true;
            toolStripLblSearch.Visible = true;
            toolStripSearchBox.Visible = true;
            toolStripFindButton.Visible = true;
            toolStripFindByGradeButton.Visible = true;
            toolStripLblGoToDate.Visible = true;
            toolStripLastDayButton.Visible = true;
            toolStripLastShiftButton.Visible = true;
            toolStripTimescale.Visible = true;
            toolStripSep1.Visible = true;
            toolStripSep2.Visible = true;
            toolStripSep3.Visible = true;
            toolStripButtonBackDay.Visible = true;
            toolStripButtonFwdDay.Visible = true;

            switch (this.CurrentScheduler)
            {
                case Scheduler.Caster:
                    SetupCasterCustoms();
                    picker.Visible = false;
                    toolStripButtonBackDay.Visible = false;
                    toolStripButtonFwdDay.Visible = false;
                    toolStripTimescale.Visible = false;
                    toolStripLblSearch.Visible = false;
                    toolStripSearchBox.Visible = false;
                    toolStripFindButton.Visible = false;
                    toolStripFindByGradeButton.Visible = false;
                    toolStripLastDayButton.Visible = false;
                    toolStripLastShiftButton.Visible = false;
                    toolStripLblGoToDate.Visible = false;
                    toolStripSep1.Visible = false;
                    toolStripSep2.Visible = false;
                    toolStripSep3.Visible = false;
                    break;
                case Scheduler.Tib:
                    SetupTibCustoms();
                    toolStripLblSearch.Visible = false;
                    toolStripSearchBox.Visible = false;
                    toolStripFindButton.Visible = false;
                    toolStripFindByGradeButton.Visible = false;
                    toolStripSep3.Visible = false;
                    break;
                case Scheduler.Heat:
                    SetupHeatCustoms();
                    break;
            }
        }

        private void SetupHeatCustoms()
        {
            heatCustoms = new QuickHeatCustoms(this);
            AddCustomsToPanel(heatCustoms);
        }

        private void SetupCasterCustoms()
        {
            casterCustoms = new QuickCasterCustoms(this);
            AddCustomsToPanel(casterCustoms);
        }

        private void SetupTibCustoms()
        {
            tibCustoms = new QuickTibCustoms(this);
            AddCustomsToPanel(tibCustoms);
        }

        private void AddCustomsToPanel(Control userControl)
        {
            pnlCustoms.Controls.Clear();
            pnlCustoms.Controls.Add(userControl);
            pnlCustoms.Width = userControl.Width;
            userControl.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Checks to see if additional datetime mods need to be made 
        /// for daily review menu item clicks.
        /// </summary>
        /// <param name="sender">the object that has been clicked.</param>
        /// <returns>True if the daily review menu was clicked, false otherwise.</returns>
        private bool DailyReviewClicked(object sender)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                if (menuItem.Tag != null &&
                    menuItem.Tag.ToString() == "Daily Review")
                    return true;
            }
            return false;
        }

        #region Main Form Events
        /// <summary>
        /// Occurs when this form is loaded.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigureUserAuthorisation();
            AddDateTimePickerToToolbar();
            SetupScreenForNewScheduler();
            ConfigureHeatScheduler();
            SetTimescaleMenu();
            ShowScheduler(SchedulerHeat);
            ConfigurePrintOptions();
            CustomiseColours();
            SetupAutoUpdates();

            if (!SkipSplash)
            {
                this.Hide();
                if (this.splash != null)
                    splash.Show();
            }
            if (!backgroundWorker1.IsBusy)
            {
                statusLabel.Text = "Loading Data...";
                loadingBar.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }

            LoadData();
            SetUsernameLabel();
            SetSessionTimeLabel();
            ConfigureStandaloneVersion();
            hasLoaded = true;
        }

        /// <summary>
        /// Key down event catcher.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.KeyCode == Keys.PageDown);
            if (e.KeyCode == Keys.Escape && IsFullScreen &&
                !this.Text.ToUpper().Contains("STANDALONE"))
            {
                IsFullScreen = !IsFullScreen;
                fullScreenToolStripMenuItem.Checked = IsFullScreen;
                HelperFunctions.GoFullscreen(IsFullScreen, this);
            }
        }

        /// <summary>
        /// Resizes the heatscheduler depending on size of main window
        /// </summary>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                if (this.CurrentScheduler == Scheduler.Heat)
                {
                    if (CurrentSchedulerIsNotNull)
                    {
                        this.SchedulerHeat.AutoSizeResourceHeights();
                    }
                    else
                    {
                        logger.Info("Heat Scheduler is null in MainForm_Resize");
                    }
                }
                else if (this.CurrentScheduler == Scheduler.Tib)
                {
                    if (CurrentSchedulerIsNotNull)
                    {
                        this.SchedulerTib.AutoSizeResourceHeights();
                    }
                    else
                    {
                        logger.Info("TIB Scheduler is null in MainForm_Resize");
                    }
                }
                else if (this.CurrentScheduler == Scheduler.Caster)
                {
                    if (CurrentSchedulerIsNotNull)
                    {
                        this.SchedulerCaster.AutoSizeResourceHeights();
                    }
                    else
                    {
                        logger.Info("Caster Scheduler is null in MainForm_Resize");
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when this form is closed. 
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommonMethods.SaveElvisSettings();
        }

        /// <summary>
        /// Update label on every tick.
        /// </summary>
        private void MainFormTimer_Tick(object sender, EventArgs e)
        {
            SetSessionTimeLabel();
        }

        /// <summary>
        /// Loads Tib Scheduler into Main Form
        /// </summary>
        private void btnTIB_Click(object sender, EventArgs e)
        {
            ShowTIBScreen(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void ShowTIBScreen(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            CommonMethods.SaveElvisSettings();
            this.CurrentScheduler = Scheduler.Tib;
            SetupScreenForNewScheduler();
            ConfigureTibScheduler();
            ShowScheduler(SchedulerTib);
            SchedulerTib.ShowHideLegend();
            SetTimescaleMenu();
            LoadData();

            if (DailyReviewClicked(sender))
            {
                toolStripLastDayButton.PerformClick();
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Loads Heat Scheduler into Main Form
        /// </summary>
        private void btnShowHeatScheduler_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CommonMethods.SaveElvisSettings();
            this.CurrentScheduler = Scheduler.Heat;
            SetupScreenForNewScheduler();
            ConfigureHeatScheduler();
            ShowScheduler(SchedulerHeat);
            SetTimescaleMenu();
            LoadData();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Loads Caster Review Scheduler into Main Form
        /// </summary>
        private void btnCasterReview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CommonMethods.SaveElvisSettings();
            this.CurrentScheduler = Scheduler.Caster;
            SetupScreenForNewScheduler();
            ConfigureCasterReviewScheduler();
            ShowScheduler(SchedulerCaster);
            LoadData();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Event handler for the Trending button on the Main Form
        /// </summary>
        private void btnTrending_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TrendingForm trending = new TrendingForm(IsMiscastAdmin);
            trending.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows/Hides the customisation quick bar at the bottom
        /// </summary>
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (btnShowHide.Tag.ToString() == "Hide")
            {
                QuickOptionsVisible = false;
            }
            else
            {
                QuickOptionsVisible = true;
            }
        }
        #endregion

        #region Tool Strip
        /// <summary>
        /// Checks if the number is in the min max range to partially 
        /// identify if the value is a heat.
        /// </summary>
        /// <param name="number">Number to check.</param>
        /// <returns>If the number is between Settings.Default.MinHeatNumber 
        /// and MaxHeatNumber that is set in the app.config.</returns>
        private bool IsHeatNumber(int number)
        {
            return number >= Settings.Default.MinHeatNumber &&
                    number <= Settings.Default.MaxHeatNumber;
        }

        /// <summary>
        /// Checks if the number is in the min max range to partially 
        /// identify if the value is a slab.
        /// </summary>
        /// <param name="number">Number to check.</param>
        /// <returns>If the number is between Settings.Default.MinSlabNumber
        /// and MaxSlabNumber that is set in the app.config.</returns>
        private bool IsSlabNumber(int number)
        {
            return number >= Settings.Default.MinSlabNumber &&
                    number <= Settings.Default.MaxSlabNumber;
        }

        /// <summary>
        /// Searches the data for the heatnumber or slab number suggested by user.
        /// Opens up the result in a heat details window.
        /// </summary>
        private void Search()
        {
            int number = 0;
            if (toolStripSearchBox.Text != "[Heat or Slab #]" &&
                int.TryParse(toolStripSearchBox.Text, out number))
            {
                if (IsHeatNumber(number))
                {
                    HeatDetails heatDetails = new HeatDetails(number, false, false, IsMiscastAdmin);
                    heatDetails.Show();
                }
                else if (IsSlabNumber(number))
                {
                    Tuple<int, int> heatNumberAndSet
                        = ElvisDataModel
                        .EntityHelper
                        .cast_slab
                        .GetHeatNumberAndSetBySlab(number);

                    if (heatNumberAndSet != null)
                    {
                        HeatDetails heatDetails = new HeatDetails(heatNumberAndSet.Item2,
                            false, false, IsMiscastAdmin, heatNumberAndSet.Item1);
                        heatDetails.Show();
                    }
                    else
                    {

                        MessageBox.Show(
                            string.Format("Could not find slab {0}.", number),
                            "Invalid Heat or Number",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        string.Format(
                        "Heat Number must be between {0} and {1}.  Slab Numbers should be between {2} and {3}.",
                            Settings.Default.MinHeatNumber, Settings.Default.MaxHeatNumber,
                            Settings.Default.MinSlabNumber, Settings.Default.MaxSlabNumber),
                        "Invalid Heat or Slab Number",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                }
            }
        }

        /// <summary>
        /// Select Specific day using the date picker
        /// </summary>
        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            // Show the day in the scheduler - a 24 hour view. 
            DateTimePicker picker = (DateTimePicker)sender;
            if (this.CurrentScheduler == Scheduler.Heat)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                    picker.MinDate = this.SchedulerHeat.scheduler.MinDate;//Stops errors when high or low dates are selected
                    picker.MaxDate = this.SchedulerHeat.scheduler.MaxDate;
                    SchedulerHeat.DisplayDay(picker.Value);
                }
                else
                {
                    logger.Info("Heat Scheduler is null in DatePickerValueChanged");
                }
            }
            else if (this.CurrentScheduler == Scheduler.Tib)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                    picker.MinDate = this.SchedulerTib.scheduler.MinDate;//Stops errors when high or low dates are selected
                    picker.MaxDate = this.SchedulerTib.scheduler.MaxDate;
                    SchedulerTib.DisplayDay(picker.Value);
                }
                else
                {
                    logger.Info("TIB Scheduler is null in DatePickerValueChanged");
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the release notes for the user.
        /// </summary>
        private void OpenReleaseNotes()
        {
            using (ReleaseNotes releaseNotes = new ReleaseNotes())
            {
                releaseNotes.ShowDialog();
            }
        }

        /// <summary>
        /// Determines how much time to step by depending on scheduler settings.
        /// </summary>
        /// <returns></returns>
        private double GetStepAmount()
        {
            if (CurrentScheduler == Scheduler.Heat)
            {
                //Finds the checked menu item
                foreach (ToolStripMenuItem item in toolStripTimescale.DropDownItems)
                {
                    if (item.Checked)
                    {
                        switch (Convert.ToInt16(item.Tag))
                        {
                            case 10:
                            case 15:
                                return 0.5;
                            case 30:
                                return 1;
                            case 1:
                                return 2;
                            case 2:
                                return 6;
                            default:
                                return 1;
                        }
                    }
                }
            }
            else if (CurrentScheduler == Scheduler.Tib)
            {
                //Finds the checked menu item
                foreach (ToolStripMenuItem item in toolStripTimescale.DropDownItems)
                {
                    if (item.Checked)
                    {
                        switch (Convert.ToInt16(item.Tag))
                        {
                            case 24:
                                return 2;
                            case 12:
                                return 1;
                            case 6:
                                return 0.5;
                            case 2:
                            case 1:
                                return 0.25;
                            default:
                                return 1;
                        }
                    }
                }
            }
            return 1;
        }

        private void OpenMiscasts()
        {
            MiscastMainNew miscastMain = new MiscastMainNew(IsMiscastAdmin);
            miscastMain.Show();
        }

        private void OpenMiscastsWithFilter(List<Tuple<string, string>> filterValues)
        {
            MiscastMainNew miscastMain = new MiscastMainNew(filterValues, IsMiscastAdmin);
            miscastMain.Show();
        }

        private void ShowTibAnalysis(DelayAnalysisReport.GroupBy groupBy)
        {
            this.Cursor = Cursors.WaitCursor;
            DelayAnalysisReport delayAnalysis = new DelayAnalysisReport(this, groupBy);
            delayAnalysis.Show(this);
            this.Cursor = Cursors.Default;
        }
        private void ShowTibAnalysis(List<BusinessLogic.Constants.UnitGroup> unitGroupSelection)
        {
            this.Cursor = Cursors.WaitCursor;
            DelayAnalysisReport delayAnalysis = new DelayAnalysisReport(this, unitGroupSelection);
            delayAnalysis.Show(this);
            this.Cursor = Cursors.Default;
        }



        #region Form Navigation
        /// <summary>
        /// Opens up the Heats per day by caster form
        /// </summary>
        private void heatsByCasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            HeatsPerDayByCasterForm heatsPerDayForm = new HeatsPerDayByCasterForm();
            heatsPerDayForm.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the Current Plan Form
        /// </summary>
        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CurrentPlanForm currentPlan = new CurrentPlanForm();
            currentPlan.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        //Opens the Hot Metal Buffer Screen
        /// </summary>
        private void hMBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            HotMetalBufferForm formHotMetal = new HotMetalBufferForm();
            formHotMetal.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Tundish Schedule Screen
        /// </summary>
        private void tundishScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TundishSchedule tundishSchedule = new TundishSchedule();
            tundishSchedule.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Safety Form
        /// </summary>
        private void safetyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this, DashboardType.Safety, IsAdmin, IsKPIAdmin, IsMiscastAdmin);
            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(dashboard_DashboardTIBClickEvent);

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Engineering Maintenance Plan Form
        /// </summary>
        private void engMaintPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            EngineeringMaintenancePlan engMaintPlan = new EngineeringMaintenancePlan();
            engMaintPlan.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the TIB Report Form
        /// </summary>
        private void tibReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TIBReport tibReport = new TIBReport(this);
            tibReport.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the TIB Delay Analysis Form
        /// </summary>
        private void tibAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DelayAnalysisReport delayAnalysis = new DelayAnalysisReport(this);
            delayAnalysis.Show(this);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Add Incident
        /// </summary>
        private void addIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Reports.Incident.SaveIncident incident = new Reports.Incident.SaveIncident();
            incident.Show();
            this.Cursor = Cursors.Default;
        }

        private void incidentLookupReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Reports.Incident.IncidentLookup incidentLU = new Reports.Incident.IncidentLookup(Area.AreaCode.All);
            incidentLU.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Show the Time in Production Form
        /// </summary>
        private void tibTimeInProductionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TIBTimeInProduction timeInProdReport = new TIBTimeInProduction(this);
            timeInProdReport.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Show the Delays To Enter Form
        /// </summary>
        private void delaysToEnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TIBDelaysToEnterReport delaysToEnterReport = new TIBDelaysToEnterReport(this);
            delaysToEnterReport.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Show the Miscasts Analysis Form
        /// </summary>
        private void miscastAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MiscastAnalysisGraph miscastAnalysis = new MiscastAnalysisGraph(IsMiscastAdmin);
            miscastAnalysis.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Show the Miscasts Main Form
        /// </summary>
        private void miscastReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                if (menuItem != null)
                {
                    if (menuItem.Tag != null && !string.IsNullOrWhiteSpace(menuItem.Tag.ToString()))
                    {
                        OpenMiscastsWithFilter(
                            new List<Tuple<string, string>>()
                                {
                                    new Tuple<string, string>(
                                        "Area", menuItem.Tag.ToString())
                                }
                        );
                    }
                    else
                    {
                        OpenMiscasts();
                    };
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void addNewMiscastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (MiscastAddNew addNew = new MiscastAddNew(IsMiscastAdmin))
            {
                DialogResult result = addNew.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MiscastReportHolder miscastReport = new MiscastReportHolder(
                        addNew.HeatNumber, addNew.HeatNumberSet,
                        IsMiscastAdmin);
                    miscastReport.Show();
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Show the near miss Main Form
        /// </summary>
        private void nearMissToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Elvis.Forms.Reports.NearMiss.NearMissMain nearMissMain = new Elvis.Forms.Reports.NearMiss.NearMissMain();
            nearMissMain.Show();
            this.Cursor = Cursors.Default;

        }

        /// <summary>
        /// Display the ladle overview form.
        /// </summary>
        private void overviewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SteelLadleOverview ladleForm = new SteelLadleOverview();
            ladleForm.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Display the hot metal ladles overview form.
        /// </summary>
        private void hmLadlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            HMLadleOverview ladleForm = new HMLadleOverview();
            ladleForm.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the Overview Screen with a 7-7 24 hour view.
        /// </summary>
        private void reviewOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler != Scheduler.Heat)
            {
                btnOverview.PerformClick();
            }
            if (this.CurrentScheduler == Scheduler.Heat)
            {
                SchedulerHeat.Display7Til7View(MyDateTime.Now);
            }
            this.Cursor = Cursors.Default;
        }
        
        /// <summary>
        /// Checks the server for updates manually.
        /// </summary>
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonMethods.CheckForUpdates(false, timerUpdates);
        }

        /// <summary>
        /// Open release notes menu item event handler.
        /// </summary>
        private void releaseNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenReleaseNotes();
        }
        #endregion

        #region Events
        /// <summary>
        /// Event for handling the Timescale menu
        /// </summary>
        private void toolMenuTimescale_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int timeScaleDisplay = 0;
            //Finds the menu item
            foreach (ToolStripMenuItem item in ((ToolStripMenuItem)sender).GetCurrentParent().Items)
            {
                //Checks or unchecks it
                if (item == sender)
                {
                    item.Checked = true;
                    timeScaleDisplay = int.Parse(item.Tag.ToString());
                }
                if ((item != null) && (item != sender))
                    item.Checked = false;
            }
            SetDisplayView(timeScaleDisplay);
            this.Cursor = Cursors.Default;
        }

        //Searches if enter hit. Only allows the entering of numbers into the text box.
        private void ToolStripSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Enter Key
            {
                Search();
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
            if (toolStripSearchBox.Text == "[Heat or Slab #]")
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
                toolStripSearchBox.Text = "[Heat or Slab #]";
                toolStripSearchBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
        }

        private void toolStripButtonNow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat)
                SchedulerHeat.DisplayDateTime(MyDateTime.Now.AddHours(-6));
            else if (this.CurrentScheduler == Scheduler.Tib)
                SchedulerTib.DisplayDateTime(MyDateTime.Now);
            else if (this.CurrentScheduler == Scheduler.Caster)
            {
                SchedulerCaster.SelectedDate = MyDateTime.Now;
                LoadCasterData();
                toolStripButtonForward.Enabled = SchedulerCaster.SelectedDate.Date <= MyDateTime.Now.Date;
            }
            this.Cursor = Cursors.Default;
        }

        private void toolStripLastShiftButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat)
                SchedulerHeat.DisplayLastShift();
            else if (this.CurrentScheduler == Scheduler.Tib)
                SchedulerTib.DisplayLastShift();
            this.Cursor = Cursors.Default;
        }

        private void toolStripLastDayButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat)
                SchedulerHeat.DisplayLastDay();
            else if (this.CurrentScheduler == Scheduler.Tib)
                SchedulerTib.DisplayLastDay();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Steps Forward on the scheduler
        /// </summary>
        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat)
                SchedulerHeat.StepForward(GetStepAmount());
            else if (this.CurrentScheduler == Scheduler.Tib)
                SchedulerTib.StepForward(GetStepAmount());
            else if (this.CurrentScheduler == Scheduler.Caster)
            {
                SchedulerCaster.SelectedDate = SchedulerCaster.SelectedDate.AddDays(1);
                LoadCasterData();
                toolStripButtonForward.Enabled = SchedulerCaster.SelectedDate.Date <= MyDateTime.Now.Date;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Steps back on the scheduler
        /// </summary>
        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat)
                SchedulerHeat.StepBack(GetStepAmount());
            else if (this.CurrentScheduler == Scheduler.Tib)
            {
                SchedulerTib.StepBack(GetStepAmount());
            }
            else if (this.CurrentScheduler == Scheduler.Caster)
            {
                SchedulerCaster.SelectedDate = SchedulerCaster.SelectedDate.AddDays(-1);
                LoadCasterData();
                toolStripButtonForward.Enabled = SchedulerCaster.SelectedDate.Date <= MyDateTime.Now.Date;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Performs a search 
        /// </summary>
        private void toolStripFindButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentScheduler == Scheduler.Heat)
                Search();
        }

        /// <summary>
        /// Finds heat by Grade
        /// </summary>
        private void toolStripFindByGradeButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentScheduler == Scheduler.Heat)
            {
                this.Cursor = Cursors.WaitCursor;
                FindHeatByGrade findHeatByGrade = new FindHeatByGrade(IsMiscastAdmin);
                findHeatByGrade.Show();
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Clears Search
        /// </summary>
        private void toolStripClearSearchButton_Click(object sender, EventArgs e)
        {
            toolStripSearchBox.Text = "[Heat or Slab #]";
            toolStripSearchBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            Search();
        }

        /// <summary>
        /// Moves to the Previous day
        /// </summary>
        private void toolStripButtonBackDay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat &&
                this.SchedulerHeat != null)
            {
                if (this.SchedulerHeat.scheduler.FirstDateTime.AddDays(-1) < picker.MinDate)
                {
                    SchedulerHeat.DisplayDateTime(this.SchedulerHeat.scheduler.MinDate);
                }
                else
                {
                    SchedulerHeat.StepBack(24);
                }

                picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                picker.MinDate = this.SchedulerHeat.scheduler.MinDate;//Stops errors when high or low dates are selected
                picker.MaxDate = this.SchedulerHeat.scheduler.MaxDate;
                picker.Value = this.SchedulerHeat.scheduler.FirstDateTime;
            }
            else if (this.CurrentScheduler == Scheduler.Tib &&
                     this.SchedulerTib != null)
            {
                if (this.SchedulerTib.scheduler.FirstDateTime.AddDays(-1) < picker.MinDate)
                {
                    SchedulerTib.DisplayDateTime(this.SchedulerTib.scheduler.MinDate);
                }
                else
                {
                    SchedulerTib.StepBack(24);
                }

                picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                picker.MinDate = this.SchedulerTib.scheduler.MinDate;//Stops errors when high or low dates are selected
                picker.MaxDate = this.SchedulerTib.scheduler.MaxDate;
                picker.Value = this.SchedulerTib.scheduler.FirstDateTime;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Moves to the Next day
        /// </summary>
        private void toolStripButtonFwdDay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.CurrentScheduler == Scheduler.Heat &&
                this.SchedulerHeat != null)
            {
                if (this.SchedulerHeat.scheduler.FirstDateTime.AddDays(1) >= picker.MaxDate)
                {
                    SchedulerHeat.DisplayDateTime(this.SchedulerHeat.scheduler.MaxDate.AddHours(-1));
                }
                else
                {
                    SchedulerHeat.StepForward(24);
                }

                picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                picker.Value = this.SchedulerHeat.scheduler.FirstDateTime;
                picker.MinDate = this.SchedulerHeat.scheduler.MinDate;//Stops errors when high or low dates are selected
                picker.MaxDate = this.SchedulerHeat.scheduler.MaxDate;
            }
            else if (this.CurrentScheduler == Scheduler.Tib &&
                     this.SchedulerTib != null)
            {
                if (this.SchedulerTib.scheduler.FirstDateTime.AddDays(1) >= picker.MaxDate)
                {
                    SchedulerTib.DisplayDateTime(this.SchedulerTib.scheduler.MaxDate.AddHours(-1));
                }
                else
                {
                    SchedulerTib.StepForward(24);
                }

                picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                picker.Value = this.SchedulerTib.scheduler.FirstDateTime;
                picker.MinDate = this.SchedulerTib.scheduler.MinDate;//Stops errors when high or low dates are selected
                picker.MaxDate = this.SchedulerTib.scheduler.MaxDate;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Loads Options Dialog
        /// </summary>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Options optionsForm = new Options())
            {
                DialogResult result = optionsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CommonMethods.SaveElvisSettings();

                    SetTimescaleMenu();
                    if (this.CurrentScheduler == Scheduler.Heat)
                    {
                        ConfigureHeatScheduler();
                        ShowScheduler(SchedulerHeat);
                    }
                    else if (this.CurrentScheduler == Scheduler.Tib)
                    {
                        ConfigureTibScheduler();
                        ShowScheduler(SchedulerTib);
                        this.SchedulerTib.ShowLegend = this.tibCustoms.ShowLegend;
                    }
                    else if (this.CurrentScheduler == Scheduler.Caster)
                    {
                        ConfigureCasterReviewScheduler();
                        ShowScheduler(SchedulerCaster);
                    }

                    if (optionsForm.RefreshData)
                    {
                        CountDown = TimeSpan.Zero;
                    }
                    else
                    {
                        LoadData();
                    }
                    CustomiseColours();
                    SetupAutoUpdates();
                }
            }
        }

        /// <summary>
        /// Full Screen
        /// </summary>
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFullScreen = !IsFullScreen;
            HelperFunctions.GoFullscreen(IsFullScreen, this);
        }

        /// <summary>
        /// Find Heat
        /// </summary>
        private void findHeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindHeat findHeat = new FindHeat();
            DialogResult result = findHeat.ShowDialog();
            if (result == DialogResult.OK)
            {
                HeatDetails heatDetails = new HeatDetails(
                    findHeat.HeatNumber,
                    false,
                    false,
                    IsMiscastAdmin,
                    findHeat.HeatNumberSet);
                heatDetails.Show();
            }
        }

        /// <summary>
        /// Opens a dialog allowing the user to add a new DRF Report.
        /// </summary>
        private void addNewDRFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonMethods.AddEditDRF(0, 0);
        }

        /// <summary>
        /// Opens the Main DRF Reports viewer.
        /// </summary>
        private void dRFReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DRFMain drfMain = new DRFMain();
            drfMain.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Main DRF Reports viewer with the primary works area selected.
        /// </summary>
        private void dRFReportsPrimaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DRFMain drfMain = new DRFMain(BusinessLogic.Constants.DrfWorksArea.Primary);
            drfMain.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Main DRF Reports viewer with the secondary works area selected.
        /// </summary>
        private void dRFReportsSecondaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DRFMain drfMain = new DRFMain(BusinessLogic.Constants.DrfWorksArea.Secondary);
            drfMain.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens the Main DRF Reports viewer with the concast works area selected.
        /// </summary>
        private void dRFReportsConcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DRFMain drfMain = new DRFMain(BusinessLogic.Constants.DrfWorksArea.Concast);
            drfMain.Show();
            this.Cursor = Cursors.Default;
        }


        private void tIBScreenToolStripMenuItemDailyReview_Click(object sender, EventArgs e)
        {
            ShowTibAnalysis(groupBy: DelayAnalysisReport.GroupBy.ReportLevel1);
        }

        private void tibScreenToolStripMenuItemPrimary_Click(object sender, EventArgs e)
        {
            ShowTibAnalysis(new List<BusinessLogic.Constants.UnitGroup>() 
            { 
                BusinessLogic.Constants.UnitGroup.Vessles
            });

        }

        private void tIBScreenToolStripMenuItemSecondary_Click(object sender, EventArgs e)
        {
            ShowTibAnalysis(new List<BusinessLogic.Constants.UnitGroup>() 
            { 
                BusinessLogic.Constants.UnitGroup.Cas,
                BusinessLogic.Constants.UnitGroup.Degassers,

            });
        }

        private void tibScreenToolStripMenuItemCasters_Click(object sender, EventArgs e)
        {
            ShowTibAnalysis(new List<BusinessLogic.Constants.UnitGroup>() 
            { 
                BusinessLogic.Constants.UnitGroup.Casters
            });
        }


        /// <summary>
        /// Close Application
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Show the About dialog box.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        /// <summary>
        /// Shows the Diagnostics Form.
        /// </summary>
        private void diagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diagnostics diagnostics = new Diagnostics();
            diagnostics.ShowDialog();
        }

        /// <summary>
        /// Shows the OEE Level 2 Report Form.
        /// </summary>
        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OEELevel2Report oeeReport = new OEELevel2Report();
            oeeReport.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the OEE report selection form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the DRF Analysis Form.
        /// </summary>
        private void dRFAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DRFAnalysis analysis = new DRFAnalysis();
            analysis.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows the I3 Form.
        /// </summary>
        private void i3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            I3Main i3 = new I3Main();
            i3.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens and shows the Central Morning Meeting Dashboard
        /// </summary>
        private void cMMDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this, DashboardType.CMM, IsAdmin, IsKPIAdmin, IsMiscastAdmin);
            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(dashboard_DashboardTIBClickEvent);

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens and shows the Primary Dashboard
        /// </summary>
        private void primaryDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this, DashboardType.Primary, IsAdmin, IsKPIAdmin, IsMiscastAdmin);
            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(dashboard_DashboardTIBClickEvent);

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
            }
            this.Cursor = Cursors.Default;
        }



        private void ForToolStripMenuItemDashboardsShiftsClick(DashboardType type)
        {
            this.Cursor = Cursors.WaitCursor;
            TrendingShifts.
            MainDashboard dashboard = new
                TrendingShifts.MainDashboard(this, type, IsAdmin, IsKPIAdmin, IsMiscastAdmin);
            dashboard.DashboardTIBClickEvent +=
                new TrendingShifts.MainDashboard.DashboardTIBClickEventHandler(dashboard_DashboardTIBClickEvent);

            //dashboard.Owner = this;
            //dashboard.pare
            Screen screen = Screen.FromPoint(Cursor.Position);
            dashboard.Location = screen.Bounds.Location;

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
            }
            this.Cursor = Cursors.Default;
        }
        private void toolStripMenuItemCmmDashboardsShifts_Click(object sender, EventArgs e)
        {
            ForToolStripMenuItemDashboardsShiftsClick(DashboardType.CMM);
        }
        private void toolStripMenuItemPrimaryDashboardsShifts_Click(object sender, EventArgs e)
        {
            ForToolStripMenuItemDashboardsShiftsClick(DashboardType.Primary);
        }
        private void toolStripMenuItemSecondaryDashboardsShifts_Click(object sender, EventArgs e)
        {
            ForToolStripMenuItemDashboardsShiftsClick(DashboardType.Secondary);
        }
        private void toolStripMenuItemCastingDashboardsShifts_Click(object sender, EventArgs e)
        {
            ForToolStripMenuItemDashboardsShiftsClick(DashboardType.Casting);
        }


        /// <summary>
        /// Opens and Shows the Secondary Dashboard.
        /// </summary>
        private void ssDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this, DashboardType.Secondary, IsAdmin, IsKPIAdmin, IsMiscastAdmin);
            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(dashboard_DashboardTIBClickEvent);

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Opens and Shows the Casting Dashboard.
        /// </summary>
        private void castingDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this, DashboardType.Casting,
                IsAdmin, IsKPIAdmin, IsMiscastAdmin);
            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(dashboard_DashboardTIBClickEvent);

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Dashboard click event that handles the TIB Displays.
        /// </summary>
        /// <param name="dateTime">The DateTime to set the TIB delay screen to.</param>
        public void dashboard_DashboardTIBClickEvent(DateTime dateTime)
        {
            btnTIB.PerformClick();
            if (picker != null)
            {
                if (dateTime >= picker.MinDate &&
                    dateTime < picker.MaxDate)
                {
                    picker.Value = dateTime;
                }
                else
                {
                    MessageBox.Show(
                        string.Format(
                            "The TIB Scheduler cannot display the date: {0}.  " +
                            "Try increasing the amount of days the TIB Scheduler displays " +
                            "(Tools -> Options -> Options -> Historical Data).",
                            dateTime.ToString("dd/MM/yy")),
                        "TIB Scheduler",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Displays the add new I3 Dialog Box.
        /// </summary>
        private void addNewI3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CommonMethods.AddEditI3(0);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handles the event for the User management menu item click.
        /// </summary>
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserManagementForm userManageForm = new UserManagementForm())
            {
                this.Cursor = Cursors.WaitCursor;
                userManageForm.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the event for the configuration editor menu item click.
        /// </summary>
        private void configurationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ParameterEditorForm parameterEditForm = new ParameterEditorForm())
            {
                this.Cursor = Cursors.WaitCursor;
                parameterEditForm.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the event for trending configuration menu item click.
        /// </summary>
        private void trendingConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TrendingConfiguration trendConfig = new TrendingConfiguration(IsAdmin))
            {
                this.Cursor = Cursors.WaitCursor;
                trendConfig.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the event for the Steelmaking Daily Inputs Menu item click.
        /// </summary>
        private void steelmakingDailyInputsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SteelDailyInputSummary dailyInputSummary = new SteelDailyInputSummary();
            dailyInputSummary.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handles the event for the Steelmaking Daily Inputs Add New Menu item click.
        /// </summary>
        private void steelmakingDailyInputsAddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SteelDailyInput dailyInput = new SteelDailyInput())
            {
                this.Cursor = Cursors.WaitCursor;
                dailyInput.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the event for Tib Admin menu item click.
        /// </summary>
        private void tIBAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TIBAdmin tibAdmin = new TIBAdmin())
            {
                this.Cursor = Cursors.WaitCursor;
                tibAdmin.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the event for "Daily Review - Next Steps" menu item.
        /// </summary>
        private void nextStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Reports.Incident.IncidentLookup incidentLU = new Reports.Incident.IncidentLookup(Area.AreaCode.CMM);
            incidentLU.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handles the event for "Primary - Next Steps" menu item.
        /// </summary>
        private void primaryNextStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Reports.Incident.IncidentLookup incidentLU = new Reports.Incident.IncidentLookup(Area.AreaCode.Primary);
            incidentLU.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handles the event for "Secondary - Next Steps" menu item.
        /// </summary>
        private void ssNextStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Reports.Incident.IncidentLookup incidentLU = new Reports.Incident.IncidentLookup(Area.AreaCode.Secondary);
            incidentLU.Show();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handles the event for "Casting - Next Steps2 menu item.
        /// </summary>
        private void castingNextStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Reports.Incident.IncidentLookup incidentLU = new Reports.Incident.IncidentLookup(Area.AreaCode.Casting);
            incidentLU.Show();
            this.Cursor = Cursors.Default;
        }

        #endregion

        #endregion

        #region Customise
        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
            splitContainer1.BackColor =
            splitContainer1.Panel2.BackColor =
            pnlQuickDetails.BackColor =
            pnlCustoms.BackColor =
            grpView.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            splitContainer1.ForeColor =
            splitContainer1.Panel2.ForeColor =
            pnlQuickDetails.ForeColor =
            pnlCustoms.ForeColor =
            grpView.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the auto updates on the page to be turned on or off
        /// dependig on user settings and deployment.
        /// </summary>
        private void SetupAutoUpdates()
        {
            checkForUpdatesToolStripMenuItem.Enabled = false;
            timerUpdates.Stop();
            timerUpdates.Enabled = false;
        }
        #endregion

        #region Printing

        #region Events
        /// <summary>
        /// Calls the PrintScreenImage method with a parameter of false to indicate a preview is required not a printout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.ShowDialog();
            PrintScreenImage(true);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageScale = 0.9F;
            e.Graphics.DrawString(
                "Elvis Screenshot - " + MyDateTime.Now.ToString("dd MMM yyyy HH:mm"),
                new Font("Arial", 16),
                SystemBrushes.WindowText,
                60, 30);

            e.Graphics.DrawRectangle(
                SystemPens.ControlText,
                60, 60,
                e.PageBounds.Width, e.PageBounds.Height - 50);

            if (this.CurrentScheduler == Scheduler.Heat)
            {
                this.SchedulerHeat.Print(
                    e.Graphics,
                    new Rectangle(61, 61,
                                  e.PageBounds.Width - 1, e.PageBounds.Height - 51));
            }
            else if (this.CurrentScheduler == Scheduler.Tib)
            {
                this.SchedulerTib.Print(
                    e.Graphics,
                    new Rectangle(61, 61,
                                  e.PageBounds.Width - 1, e.PageBounds.Height - 51));
            }
            else if (this.CurrentScheduler == Scheduler.Caster)
            {
                this.SchedulerCaster.Print(
                    e.Graphics,
                    new Rectangle(61, 61,
                                  e.PageBounds.Width - 1, e.PageBounds.Height - 51));
            }
        }

        /// <summary>
        /// Calls the PrintScreenImage method with a parameter of false to indicate a printout is required not a preview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PrintScreenImage(false);
        }

        /// <summary>
        /// Takes a screen shot of the application at the point the method is called from Print or Print Preview on the File menu.
        /// Dependent on the isPrintPreview value will either print the image out directly or display a preview window.
        /// PrintScreen is a custom class inheriting from PrintDocument, overriding the Print method.
        /// When the user requests a printout or printpreview the application display will change to full screen with 
        /// quick options hidden, to enable the maximum size screen shot to the taken. Once the print or preview has completed
        /// the screen will return ot normal view / quick options shown.
        /// </summary>
        private void PrintScreenImage(bool isPrintPreview)
        {
            PrintScreen printScheduler = new PrintScreen();
            PrintPreviewDialog previewScreen = new PrintPreviewDialog();

            QuickOptionsVisible = false;
            SendKeys.SendWait("{F11}");
            printScheduler.ScreenImage = FormControl.CopyScreen();
            printScheduler.DefaultPageSettings.Landscape = true;
            SendKeys.SendWait("{F11}");
            QuickOptionsVisible = true;
            if (isPrintPreview == true)
            {
                ((ToolStripButton)((ToolStrip)previewScreen.Controls[1]).Items[0]).Visible = false;
                previewScreen.Document = printScheduler;
                previewScreen.ShowDialog();
            }
            else
            {
                // Create the print dialog object and set options
                PrintDialog pDialog = new PrintDialog();
                pDialog.Document = printScheduler;
                // Display the dialog. This returns true if the user presses the Print button.
                DialogResult print = pDialog.ShowDialog();
                if (print == DialogResult.OK)
                {
                    printScheduler.Print();
                }
            }
        }
        #endregion

        #region Methods
        private void ConfigurePrintOptions()
        {
            printDocument1.DefaultPageSettings.Landscape = true;
        }
        #endregion

        #endregion

        #endregion

        #region Scheduler

        #region Setup
        /// <summary>
        /// Initial settings for the heat scheduler.
        /// </summary>
        private void ConfigureHeatScheduler()
        {
            this.SchedulerHeat = new HeatScheduler();
            this.SchedulerHeat.CellWidth = this.heatCustoms.CellWidth;
            this.SchedulerHeat.CurrentColourSetting = this.heatCustoms.ColourSetting;
            this.SchedulerHeat.CurrentDataSetting = this.heatCustoms.ExtraData;
            this.SchedulerHeat.ShowShadows = this.heatCustoms.ShowShadows;
            this.SchedulerHeat.ShowTimeline = this.heatCustoms.ShowTimeline;
            this.SchedulerHeat.ShowMiscasts = this.heatCustoms.ShowMiscasts;

            this.SchedulerHeat.HeatSchedulerAppointmentClick += new
                HeatScheduler.HeatSchedulerAppointmentClickEventHandler(
                    schedulerHeat_HeatSchedulerAppointmentClick);

            this.SchedulerHeat.HeatSchedulerMouseDoubleClick += new
                HeatScheduler.HeatSchedulerMouseDoubleClickEventHandler(
                    schedulerHeat_HeatSchedulerMouseDoubleClick);

            this.SchedulerHeat.HeatSchedulerFirstDateTimeChanged += new
                HeatScheduler.HeatSchedulerFirstDateTimeEventHandler(
                    schedulerHeat_HeatSchedulerFirstDateTimeChanged);

            this.SchedulerHeat.LoadUnits(
                SchedulerHeat.GetUnitsForScheduler(Scheduler.Heat, this.units));

            SetupHeatQuickViewUC();
            SetupHeatCustoms();

            picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
            picker.MinDate = this.SchedulerHeat.scheduler.MinDate;//Stops errors when high or low dates are selected
            picker.MaxDate = this.SchedulerHeat.scheduler.MaxDate;
        }

        /// <summary>
        /// Initial settings for the caster review scheduler.
        /// </summary>
        private void ConfigureCasterReviewScheduler()
        {
            this.SchedulerCaster = new CasterReviewScheduler(IsMiscastAdmin);
            this.SchedulerCaster.ShowShadows = this.casterCustoms.ShowShadows;
            this.SchedulerCaster.ShowTimeline = this.casterCustoms.ShowTimeline;
            this.SchedulerCaster.Show7PMPlan = this.casterCustoms.Show7pmPlan;
            this.SchedulerCaster.ShowChart = this.casterCustoms.ShowChart;
            this.SchedulerCaster.CurrentDataSetting = this.casterCustoms.ExtraData;
            this.SchedulerCaster.Show7amHMStock = this.casterCustoms.ShowHMStock7am;

            //Load only the caster units into the scheduler
            //TODO: fix this commented on conversion
            //this.SchedulerCaster.LoadCasterReviewUnits(
            //    SchedulerCaster.GetUnitsForScheduler(Scheduler.Caster,
            //        this.units));

            this.SchedulerCaster.CasterSchedulerAppointmentClick += new
                CasterReviewScheduler.CasterSchedulerAppointmentClickEventHandler(
                    schedulerHeat_CasterReviewAppointmentClick);

            this.SchedulerCaster.Fix24HourPeriod();
            SetupHeatQuickViewUC();
            SetupCasterCustoms();
        }

        /// <summary>
        /// Initial settings for the tib scheduler.
        /// </summary>
        private void ConfigureTibScheduler()
        {
            this.SchedulerTib = new TibScheduler(IsMiscastAdmin);

            this.SchedulerTib.TibSchedulerAppointmentClick += new
                TibScheduler.TibSchedulerAppointmentClickEventHandler(
                    schedulerTib_TibSchedulerAppointmentClick);

            this.SchedulerTib.TibSchedulerFirstDateTimeChanged += new
                TibScheduler.TibSchedulerFirstDateTimeEventHandler(
                    schedulerTib_TibSchedulerFirstDateTimeChanged);

            this.SchedulerTib.LoadUnits(
                SchedulerTib.GetUnitsForScheduler(Scheduler.Tib, this.units));

            this.SchedulerTib.CellWidth = this.tibCustoms.CellWidth;
            this.SchedulerTib.ShowShadows = this.tibCustoms.ShowShadows;
            this.SchedulerTib.ShowTimeline = this.tibCustoms.ShowTimeline;
            this.SchedulerTib.ShowLegend = this.tibCustoms.ShowLegend;

            SetupTibQuickViewUC();
            SetupTibCustoms();

            picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
            this.SchedulerTib.DisplayDateTime(TimeFunctions.StartOfShift_PT(MyDateTime.Now));
            picker.MinDate = this.SchedulerTib.scheduler.MinDate;//Stops errors when high or low dates are selected
            picker.MaxDate = this.SchedulerTib.scheduler.MaxDate;
        }

        /// <summary>
        /// Sets the visibility of the resources depending on the 
        /// user settings.
        /// </summary>
        public void ShowHideUnits(BaseScheduler scheduler, List<int> unitsToHide)
        {
            string group = "";

            if (scheduler != null)
            {
                foreach (Resource resource in scheduler.scheduler.Resources)
                {
                    if (resource.Tag != null && resource.Tag is DbUnit)
                    {
                        DbUnit unit = (DbUnit)resource.Tag;
                        resource.Visible = true;

                        //Hide Resource if on hideList or if blank and old group equals new group
                        if ((unitsToHide.Count > 0 &&
                             unitsToHide.Contains(unit.UnitNumber)) ||
                            (string.IsNullOrEmpty(resource.Text) &&
                             unit.UnitGroupText == group))
                        {
                            resource.Visible = false;
                        }

                        group = unit.UnitGroupText;//Store group for next record
                    }
                }
                scheduler.AutoSizeResourceHeights();
            }
        }

        /// <summary>
        /// Sets up the Heat Quick View User Control
        /// </summary>
        private void SetupHeatQuickViewUC()
        {
            ucHeatDetails = new QuickHeatDetails();
            pnlQuickDetails.Controls.Clear();
            pnlQuickDetails.Controls.Add(ucHeatDetails);
            ucHeatDetails.Dock = DockStyle.Fill;
            if (CurrentScheduler == Scheduler.Caster)
                ucHeatDetails.VesselVisible = false;
        }

        /// <summary>
        /// Sets up the Tib Quick View User Control
        /// </summary>
        private void SetupTibQuickViewUC()
        {
            this.ucTibDetails = new QuickTibDetails();
            pnlQuickDetails.Controls.Clear();
            pnlQuickDetails.Controls.Add(this.ucTibDetails);
            this.ucTibDetails.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Clears the container and adds in the specified scheduler 
        /// </summary>
        /// <param name="scheduler">The scheduler to display.</param>
        private void ShowScheduler(BaseScheduler scheduler)
        {
            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel1.Controls.Add(scheduler);
            if (scheduler != null)
            {
                scheduler.Dock = DockStyle.Fill;
                scheduler.AutoSizeResourceHeights();
            }
        }

        /// <summary>
        /// Sets up the Timescale Menu depending on scheduler
        /// </summary>
        private void SetTimescaleMenu()
        {
            if (this.CurrentScheduler == Scheduler.Heat)
            {
                SetToolMenuItem(toolMenu1, "10 Minute", 10);
                SetToolMenuItem(toolMenu2, "15 Minute", 15);
                SetToolMenuItem(toolMenu3, "30 Minute", 30);
                SetToolMenuItem(toolMenu4, "1 Hour", 1);
                SetToolMenuItem(toolMenu5, "2 Hour", 2);
                toolMenu4.PerformClick();//Default to 1 Hour
            }
            else if (this.CurrentScheduler == Scheduler.Tib)
            {
                SetToolMenuItem(toolMenu1, "24 Hour", 24);
                SetToolMenuItem(toolMenu2, "12 Hour", 12);
                SetToolMenuItem(toolMenu3, "6 Hour", 6);
                SetToolMenuItem(toolMenu4, "2 Hour", 2);
                SetToolMenuItem(toolMenu5, "1 Hour", 1);
                toolMenu2.PerformClick();//Default to 12 Hour
            }
        }

        /// <summary>
        /// Sets up the tool menu's text and tag properties.
        /// </summary>
        /// <param name="toolMenu">The Tool Menu to change.</param>
        /// <param name="text">The Text.</param>
        /// <param name="tag">The Tag.</param>
        private void SetToolMenuItem(ToolStripMenuItem toolMenu, string text, int tag)
        {
            toolMenu.Text = text;
            toolMenu.Tag = tag;
        }

        /// <summary>
        /// Sets up the scheduler to display different timescales
        /// </summary>
        /// <param name="timeScaleDisplay">Used to determine the view.</param>
        private void SetDisplayView(int timeScaleDisplay)
        {
            if (this.CurrentScheduler == Scheduler.Tib)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    this.SchedulerTib.DisplayTimeScale(timeScaleDisplay);
                }
                else
                {
                    logger.Info("TIB Scheduler is null in SetDisplayView");
                }
            }
            else if (CurrentScheduler == Scheduler.Heat)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    switch (timeScaleDisplay)
                    {
                        case 10:
                            this.SchedulerHeat.DisplayTenMinuteView();
                            break;
                        case 15:
                            this.SchedulerHeat.DisplayFifteenMinuteView();
                            break;
                        case 30:
                            this.SchedulerHeat.DisplayThirtyMinuteView();
                            break;
                        case 1:
                            this.SchedulerHeat.DisplayOneHourView();
                            break;
                        case 2:
                            this.SchedulerHeat.DisplayTwoHourView();
                            break;
                    }
                }
                else
                {
                    logger.Info("Heat Scheduler is null in SetDisplayView");
                }
            }
        }

        /// <summary>
        /// Sets up the quick heat details for the selected event
        /// </summary>
        /// <param name="selectedEvent">The Selected Event</param>
        /// <param name="app">The Selected Appointment</param>
        private void SetQuickHeatDetails(ProductionEvent selectedEvent, Appointment app)
        {
            this.ucHeatDetails.HeatNumber = string.Format(
                "Heat Number: {0}", selectedEvent.HeatNumber);
            this.ucHeatDetails.ProgramNo = string.Format(
                "Program Number: {0}", selectedEvent.ProgramNumber);

            if (selectedEvent.Grade == 0)
                this.ucHeatDetails.Grade = "Grade: Unknown";
            else
            {
                this.ucHeatDetails.Grade = string.Format(
                    "Grade: {0}", selectedEvent.Grade);
            }

            if (selectedEvent.LadleNumber == 0)
                this.ucHeatDetails.LadleNo = "Ladle Number: Unknown";
            else
            {
                this.ucHeatDetails.LadleNo = string.Format(
                    "Ladle Number: {0}", selectedEvent.LadleNumber);
            }

            this.ucHeatDetails.Caster = string.Format(
                "Caster: {0}", selectedEvent.CasterName);

            if (selectedEvent.VesselNumber == 0)
                this.ucHeatDetails.Vessel = "Vessel: Unknown";
            else
            {
                this.ucHeatDetails.Vessel = string.Format(
                    "Vessel: {0}", selectedEvent.VesselNumber);
            }

            if (CurrentScheduler == Scheduler.Caster)
            {
                this.ucHeatDetails.VesselVisible = false;
                this.ucHeatDetails.LadleNoVisible = false;
            }

            this.ucHeatDetails.EndTimeForeColour = Settings.Default.ColourText;
            this.ucHeatDetails.EndTimeBackColour = Settings.Default.ColourBackground;

            if (selectedEvent.IsPlanningBlock)
            {
                this.ucHeatDetails.Start =
                    string.Format("Planned Start: {0}",
                    app.Start.ToString("HH:mm"));
                this.ucHeatDetails.End =
                    string.Format("Planned End: {0}",
                    app.End.ToString("HH:mm"));
                this.ucHeatDetails.Duration =
                    string.Format("Planned Duration: {0} mins",
                    (app.End - app.Start)
                    .TotalMinutes
                    .ToString("#0"));
            }
            else
            {
                this.ucHeatDetails.Duration =
                    string.Format("Activity Duration: {0} mins",
                    app.Duration.TotalMinutes.ToString("#0"));
                this.ucHeatDetails.Start =
                    string.Format("Activity Start: {0}",
                    app.Start.ToString("HH:mm"));

                if (selectedEvent.IsInProgress)
                {
                    this.ucHeatDetails.End = "Activity End: In Progress";
                }
                else if (selectedEvent.IsFalseEndTime)
                {
                    this.ucHeatDetails.End = "Activity End: No End Time!";
                    this.ucHeatDetails.EndTimeForeColour = Color.Red;
                    this.ucHeatDetails.EndTimeBackColour = Color.White;
                    this.ucHeatDetails.Duration = "Activity Duration: Unknown";
                }
                else
                {
                    this.ucHeatDetails.End =
                        string.Format("Activity End: {0}",
                        app.End.ToString("HH:mm"));
                }
            }
        }

        /// <summary>
        /// Sets up the quick heat details for the selected event
        /// </summary>
        /// <param name="selectedEvent">The Selected Tib Event</param>
        /// <param name="app">The Selected Appointment</param>
        private void SetQuickHeatDetails(TibEvent tibEvent, Appointment app)
        {
            this.ucHeatDetails.LadleNoVisible = true;

            this.ucHeatDetails.HeatNumber = "Heat Number: Unknown";
            if (tibEvent.HeatNumber.HasValue)
            {
                this.ucHeatDetails.HeatNumber = string.Format(
                    "Heat Number: {0}", tibEvent.HeatNumber.Value);
            }

            this.ucHeatDetails.ProgramNo = "Program Number: Unknown";
            if (tibEvent.ProgramNumber.HasValue)
            {
                this.ucHeatDetails.ProgramNo = string.Format(
                    "Program Number: {0}", tibEvent.ProgramNumber.Value);
            }

            this.ucHeatDetails.Grade = "Grade: Unknown";
            if (tibEvent.Grade.HasValue)
            {
                this.ucHeatDetails.Grade = string.Format(
                    "Grade: {0}", tibEvent.Grade.Value);
            }

            this.ucHeatDetails.LadleNo = "Ladle Number: Unknown";
            if (tibEvent.LadleNumber.HasValue)
            {
                this.ucHeatDetails.LadleNo = string.Format(
                    "Ladle Number: {0}", tibEvent.LadleNumber.Value);
            }

            this.ucHeatDetails.Caster = "Caster: Unknown";
            if (!string.IsNullOrEmpty(tibEvent.PlantArea))
            {
                this.ucHeatDetails.Caster = string.Format(
                    "Caster: {0}", tibEvent.PlantArea);
            }

            this.ucHeatDetails.Vessel = "Vessel: Unavailable";

            if (CurrentScheduler == Scheduler.Caster)
                this.ucHeatDetails.VesselVisible = false;

            this.ucHeatDetails.EndTimeForeColour = Settings.Default.ColourText;
            this.ucHeatDetails.EndTimeBackColour = Settings.Default.ColourBackground;

            this.ucHeatDetails.Duration =
                string.Format("Activity Duration: {0} mins",
                app.Duration.TotalMinutes.ToString("#0"));

            this.ucHeatDetails.Start =
                string.Format("Activity Start: {0}",
                app.Start.ToString("HH:mm"));

            this.ucHeatDetails.End =
                string.Format("Activity End: {0}",
                app.End.ToString("HH:mm"));
        }

        /// <summary>
        /// Sets up the quick tib details for the selected event
        /// </summary>
        /// <param name="selectedTibEvent">The Selected Tib Event</param>
        /// <param name="app">The Selected Appointment</param>
        private void SetQuickTibDetails(TibEvent selectedTibEvent, Appointment app)
        {
            this.ucTibDetails.HeatNumberVisible = false;

            this.ucTibDetails.Type = string.Format(
                "Type: {0}",
                GetTibStatusText(selectedTibEvent.TibStatus));

            if (selectedTibEvent.TibStatus != 2)
            {
                this.ucTibDetails.ReasonsVisible = true;
            }

            if (selectedTibEvent.HeatNumber != null &&
                selectedTibEvent.HeatNumber >= Settings.Default.MinHeatNumber &&
                selectedTibEvent.HeatNumber <= Settings.Default.MaxHeatNumber &&
                selectedTibEvent.TibStatus == 2)
            {
                this.ucTibDetails.HeatNumberVisible = true;
                this.ucTibDetails.HeatNumber = string.Format(
                    "Heat Number: {0}", selectedTibEvent.HeatNumber);
                this.ucTibDetails.ReasonsVisible = false;
            }
            else if (selectedTibEvent.TibStatus == 2)
            {
                this.ucTibDetails.ReasonsVisible = false;

                if (selectedTibEvent.UnitNumber == 14)
                {//Lime Plant
                    this.ucTibDetails.HeatNumberVisible = true;
                    this.ucTibDetails.HeatNumber = string.Format(
                        "Bunker No: {0}", selectedTibEvent.HeatNumber);
                }
            }

            this.ucTibDetails.Duration =
                string.Format("Duration: {0} mins",
                app.Duration.TotalMinutes.ToString("#0"));
            this.ucTibDetails.Start =
                string.Format("Start: {0}",
                app.Start.ToString("HH:mm"));
            this.ucTibDetails.End =
                string.Format("End: {0}",
                app.End.ToString("HH:mm"));

            //Displays the ongoing status if the end time is close to the now time
            //and the event is ongoing
            if (selectedTibEvent.Ongoing &&
                (MyDateTime.Now - app.End).TotalMinutes <= 5)
            {
                this.ucTibDetails.End = "End: Ongoing";
            }

            if (selectedTibEvent.TibStatus != 2)
            {
                int delayNo = 0;//Get Selected Delay From Appointment
                if (int.TryParse(app.Text, out delayNo))
                {
                    TIBDelay delay = selectedTibEvent.Delays.FirstOrDefault(t =>
                        t.DelayNumber == delayNo);
                    if (delay != null)
                    {
                        //Place reason data into array to pass to UC
                        this.ucTibDetails.Reasons = new string[4] { 
                            delay.DelayReason1,
                            delay.DelayReason2,
                            delay.DelayReason3,
                            delay.DelayReason4
                        };
                    }
                    else
                    {
                        if (selectedTibEvent.UnitNumber == 14)
                        {//Lime Plant
                            this.ucTibDetails.Type = "Type: Changeover";
                            this.ucTibDetails.ReasonsVisible = false;
                        }

                        this.ucTibDetails.Reasons = new string[1] { 
                            "No Reason"
                        };
                    }
                }
                else
                {
                    this.ucTibDetails.Reasons = new string[1] { 
                            "No Reason"
                        };
                }
            }
        }

        /// <summary>
        /// Sets up the quick tib details for the planned selected event
        /// </summary>
        /// <param name="selectedTibEvent">The Selected Tib Event</param>
        /// <param name="app">The Selected Appointment</param>
        private void SetQuickTibPlanDetails(ProductionEvent selectedTibEvent, Appointment app)
        {
            this.ucTibDetails.ReasonsVisible = false;
            this.ucTibDetails.HeatNumberVisible = true;
            this.ucTibDetails.Type = "Type: Planned";
            this.ucTibDetails.Duration =
                string.Format("Duration: {0} mins",
                app.Duration.TotalMinutes.ToString("#0"));
            this.ucTibDetails.Start =
                string.Format("Start: {0}",
                app.Start.ToString("HH:mm"));
            this.ucTibDetails.End =
                string.Format("End: {0}",
                app.End.ToString("HH:mm"));
            this.ucTibDetails.HeatNumber = string.Format(
                "Heat Number: {0}", selectedTibEvent.HeatNumber);
        }

        /// <summary>
        /// Gets the status as a User Friendly version.
        /// </summary>
        /// <param name="status">The ID of the status.</param>
        /// <returns>A string to display to the user.</returns>
        private string GetTibStatusText(int? status)
        {
            switch (status)
            {
                case 1:
                    return "Not Producing";
                case 2:
                    return "Producing";
                case 3:
                    return "In Process";
                case 4:
                    return "Out of Process";
                case 5:
                    return "Unproductive";
                default:
                    return "Unknown";
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Updates the quick view for a heat 
        /// </summary>
        protected void schedulerHeat_HeatSchedulerAppointmentClick(object sender, SchedulerEventArgs e)
        {
            //Display Quick View Data
            ProductionEvent selectedEvent = e.Appointment.GetHeatData();//Gets Appointment Data

            if (this.CurrentScheduler == Scheduler.Heat ||
                this.CurrentScheduler == Scheduler.Caster)
            {
                SetQuickHeatDetails(selectedEvent, e.Appointment);
            }
        }

        /// <summary>
        /// Updates the quick view for a heat 
        /// </summary>
        protected void schedulerHeat_CasterReviewAppointmentClick(object sender, SchedulerEventArgs e)
        {
            TibEvent selectedTibEvent = e.Appointment.GetTibData();//Gets Appointment Data
            if (selectedTibEvent.HeatNumber == null &&
                selectedTibEvent.TibStatus == null)
            {
                ProductionEvent selectedTibPlanEvent = e.Appointment.GetHeatData();
                SetupHeatQuickViewUC();
                SetQuickHeatDetails(selectedTibPlanEvent, e.Appointment);
            }
            else
            {
                SetupTibQuickViewUC();
                SetQuickTibDetails(selectedTibEvent, e.Appointment);
            }
        }

        /// <summary>
        /// Auto sizes the schedulers when the splitter is moved.
        /// </summary>
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (this.hasLoaded)
            {
                if (this.CurrentScheduler == Scheduler.Heat)
                {
                    if (CurrentSchedulerIsNotNull)
                    {
                        this.SchedulerHeat.AutoSizeResourceHeights();
                    }
                    else
                    {
                        logger.Info("Heat Scheduler is null in splitContainer1_SplitterMoved");
                    }
                }
                else if (this.CurrentScheduler == Scheduler.Caster)
                {
                    if (CurrentSchedulerIsNotNull)
                    {
                        this.SchedulerCaster.AutoSizeResourceHeights();
                    }
                    else
                    {
                        logger.Info("Caster Scheduler is null in splitContainer1_SplitterMoved");
                    }
                }
            }
        }

        /// <summary>
        /// Updates the quick view for a Tib Event
        /// </summary>
        protected void schedulerTib_TibSchedulerAppointmentClick(object sender, SchedulerEventArgs e)
        {
            TibEvent selectedTibEvent = e.Appointment.GetTibData();//Gets Appointment Data
            if (selectedTibEvent.HeatNumber == null &&
                selectedTibEvent.TibStatus == null)
            {
                ProductionEvent selectedTibPlanEvent = e.Appointment.GetHeatData();
                SetQuickTibPlanDetails(selectedTibPlanEvent, e.Appointment);
            }
            else
            {
                SetQuickTibDetails(selectedTibEvent, e.Appointment);
            }
        }

        /// <summary>
        /// Updates the date picker when the date is changed on the tib scheduler.
        /// </summary>
        protected void schedulerTib_TibSchedulerFirstDateTimeChanged(object sender, EventArgs e)
        {
            if (picker != null && SchedulerTib != null)
            {
                picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                picker.MinDate = this.SchedulerTib.scheduler.MinDate;//Stops errors when high or low dates are selected
                picker.MaxDate = this.SchedulerTib.scheduler.MaxDate;

                if (SchedulerTib.scheduler != null &&
                    SchedulerTib.scheduler.FirstDateTime >= picker.MinDate &&
                    SchedulerTib.scheduler.FirstDateTime <= picker.MaxDate)
                {
                    //Need to stop the event firing to stop unwanted scheduler movement.
                    picker.ValueChanged -= new EventHandler(DatePickerValueChanged);
                    picker.Value = SchedulerTib.scheduler.FirstDateTime;
                    picker.ValueChanged += new EventHandler(DatePickerValueChanged);
                }
            }
        }

        /// <summary>
        /// Updates the date picker when the date is changed on the heat scheduler.
        /// </summary>
        protected void schedulerHeat_HeatSchedulerFirstDateTimeChanged(object sender, EventArgs e)
        {
            if (picker != null && SchedulerHeat != null)
            {
                picker.MaxDate = DateTimePicker.MaximumDateTime;//Stops an error when max date is less than min date.
                picker.MinDate = this.SchedulerHeat.scheduler.MinDate;//Stops errors when high or low dates are selected
                picker.MaxDate = this.SchedulerHeat.scheduler.MaxDate;

                if (SchedulerHeat.scheduler != null &&
                    SchedulerHeat.scheduler.FirstDateTime >= picker.MinDate &&
                    SchedulerHeat.scheduler.FirstDateTime <= picker.MaxDate)
                {
                    //Need to stop the event firing to stop unwanted scheduler movement.
                    picker.ValueChanged -= new EventHandler(DatePickerValueChanged);
                    picker.Value = SchedulerHeat.scheduler.FirstDateTime;
                    picker.ValueChanged += new EventHandler(DatePickerValueChanged);
                }
            }
        }

        /// <summary>
        /// Double click event for the heat scheduler that opens up the correct form
        /// depending on whether or not it is a planning block or not.
        /// </summary>
        protected void schedulerHeat_HeatSchedulerMouseDoubleClick(object sender, SchedulerEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.Appointment != null)
            {
                ProductionEvent heatData = (ProductionEvent)e.Appointment.Tag;
                if (heatData != null)
                {
                    HeatDetails heatDetails = new HeatDetails(
                        heatData.HeatNumber,
                        CommonMethods.IsCasterUnit(heatData.UnitId),
                        heatData.IsPlanningBlock,
                        IsMiscastAdmin,
                        heatData.HeatNumberSet);
                    heatDetails.Show();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void OpenDailyManagementAgendaThreats()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Elvis.Forms.Reports.ManagementAgendaThreats.DMAThreatIndex threat = new Reports.ManagementAgendaThreats.DMAThreatIndex();
                threat.Show();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to load Daily Management Agenda Threats.", ex);
            }
        }

        private void threatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDailyManagementAgendaThreats();
        }


        private void primaryThreatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDailyManagementAgendaThreats();
        }

        private void ssThreatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDailyManagementAgendaThreats();
        }

        private void castingThreatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDailyManagementAgendaThreats();
        }
        #endregion

        #endregion

        #region Data
        /// <summary>
        /// Loads the data from file into the heat scheduler
        /// </summary>
        private void LoadData()
        {
            if (this.CurrentScheduler == Scheduler.Heat)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    this.SchedulerHeat.LoadEvents(Model.MainForm.LoadEvents(), false);
                    this.SchedulerHeat.LoadEvents(Model.MainForm.GetPlannedHeats(), true);
                }
                else
                {
                    logger.Info("Heat Scheduler is null in LoadData");
                }
            }
            else if (this.CurrentScheduler == Scheduler.Tib)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    this.SchedulerTib.LoadTibEvents(Model.Tib.LoadTibEvents());
                    this.SchedulerTib.LoadPlanningEvents(Model.MainForm.GetPlannedHeats());
                }
                else
                {
                    logger.Info("TIB Scheduler is null in LoadData");
                }
            }
            else if (this.CurrentScheduler == Scheduler.Caster)
            {
                LoadCasterData();
            }

            planPublishedTimeLabel.Text =
                string.Format("Plan Last Updated - {0}",
                Model.MainForm.PlanPublishTime.ToString("dd MMM HH:mm"));
        }

        /// <summary>
        /// Loads an up to date caster data
        /// </summary>
        public void LoadCasterData()
        {
            // Check the Caster Scheduler is initialised. Bail out if it isn't.
            if (SchedulerCaster == null)
            {
                logger.Info("Caster Scheduler is null in LoadCasterData");
                MessageBox.Show(this, "Unable to load Caster Review data.",
                    "Elvis Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Use 10 as the hour if they want the 10AM plan
            // Otherwise use the default of 7AM.
            int hour = SchedulerCaster.Show10AMPlan ? 10 : 7;

            this.SchedulerCaster.LoadXamPlan(
                CasterReviewData.GetPlanCasterSchedule(
                    SchedulerCaster.SelectedDate, hour), hour
                    );

            if (SchedulerCaster.Show7PMPlan)
            {
                this.SchedulerCaster.Load7PMPlan(
                    CasterReviewData.GetPlanCasterSchedule(
                    SchedulerCaster.SelectedDate, 19)
                    );
            }

            this.SchedulerCaster.LoadActualHeats(
                CasterReviewData.GetActualCasterTib(
                    SchedulerCaster.SelectedDate, hour));

            if (this.SchedulerCaster.SelectedDate.Date >= MyDateTime.Now.Date)
            {
                this.SchedulerCaster.LoadCurrentPlannedHeats(Model.MainForm.GetCasterPlannedHeats());
            }
            this.SchedulerCaster.SetMinMaxDate(SchedulerCaster.SelectedDate);
            this.SchedulerCaster.ConfigureChart();
            this.SchedulerCaster.DrawChart();
            this.SchedulerCaster.DisplayDateTime(SchedulerCaster.scheduler.MinDate);
            this.SchedulerCaster.ColourHeats();
            toolStripButtonForward.Enabled = SchedulerCaster.SelectedDate.Date <= MyDateTime.Now.Date;
        }

        /// <summary>
        /// Gets the units for the form and catches any errors.
        /// </summary>
        private void GetUnits()
        {
            try
            {
                this.units = EntityHelper.Units.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetUnits() -- " +
                    "Getting Unit data from database -- ", ex);
            }
        }

        #region Timer and Background Worker
        //Sets the countdown label or gets data if countdown has reached 0
        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            CountDown = CountDown.Subtract(new TimeSpan(0, 0, 1));
            if (CountDown >= TimeSpan.Zero && statusLabel.Text != "Loading Data...")
            {
                SetCountdownLabel();
            }
            else
            {
                if (!backgroundWorker1.IsBusy)
                {
                    statusLabel.Text = "Loading Data...";
                    loadingBar.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            CheckMemoryUsage();
        }

        //Event that runs once background worker complete.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadData();
            loadingBar.Visible = false;
            CountDown = Settings.Default.RefreshRate;

            //Increases the Max/Min Date after every load so 
            //that the screen doesn't get stuck!
            if (this.CurrentScheduler == Scheduler.Heat)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    this.SchedulerHeat.SetMaxDate(MyDateTime.Now.AddDays(2));
                    this.SchedulerHeat.SetMinDate(MyDateTime.Now.AddDays(-Settings.Default.OverviewDaysToShow));
                }
                else
                {
                    logger.Info("Heat Scheduler is null in backgroundWorker1_RunWorkerCompleted");
                }
            }
            else if (this.CurrentScheduler == Scheduler.Tib)
            {
                if (CurrentSchedulerIsNotNull)
                {
                    this.SchedulerTib.SetMaxDate(MyDateTime.Now.AddDays(2));
                    this.SchedulerTib.SetMinDate(MyDateTime.Now.AddDays(-Settings.Default.TibDaysToShow));
                }
                else
                {
                    logger.Info("TIB Scheduler is null in backgroundWorker1_RunWorkerCompleted");
                }
            }

            SetCountdownLabel();

            if (!SkipSplash)
            {
                this.Show();
                if (this.splash != null)
                    this.splash.Close();
            }
        }

        //Get up to date data from database and save to bin file in directory.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Model.MainForm.SaveEvents(Model.MainForm.GetData());
            Model.Tib.SaveTibEvents(Model.Tib.GetTibEvents());
        }

        //Make sure the software is up to date every hour.
        private void timerUpdates_Tick(object sender, EventArgs e)
        {
            CommonMethods.CheckForUpdates(true, timerUpdates);
        }
        #endregion

        private void machineConditionMenuItem_Click(object sender, EventArgs e)
        {
            CasterMachineConditionForm casterMachineform = new CasterMachineConditionForm();
            casterMachineform.Show();
        }

        #endregion
    }
}
