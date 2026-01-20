using BusinessLogic.Constants.Trending.Dashboards;
using Elvis.Common;
using Elvis.Forms.Trending.UserControls;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Elvis.Forms.Trending
{
    public partial class MainDashboard : Form
    {
        private int noOfDays = 0;
        private bool isAdmin = false;
        private bool isKPIAdmin = false;
        private bool isMiscastAdmin;
        private Bitmap memoryScreenShot;
        private DateTimePicker picker;
        private MainForm mainForm;

        #region Delegates And Events

        /// <summary>
        /// Fires when a TIB Delay KPI is Clicked on the Dashboard.
        /// </summary>
        /// <param name="dateTime">The Date Time that was clicked.</param>
        public delegate void DashboardTIBClickEventHandler(DateTime dateTime);

        public event Elvis.Forms.Trending.MainDashboard.DashboardTIBClickEventHandler DashboardTIBClickEvent;

        #endregion Delegates And Events

        /// <summary>
        /// Creates a new instance of the Dashboard Form.
        /// </summary>
        /// <param name="dashType">The type of Dashboard -- 
        ///     1 - Central Morning Meeting -- 
        ///     2 - Primary -- 
        ///     3 - Casting -- 
        ///     99 - Test</param>
        /// <param name="isAdmin">Is the user an Admin.</param>
        /// <param name="isKPIAdmin">Is the user a KPIAdmin.</param>
        public MainDashboard(MainForm mainForm, DashboardType dashType, 
            bool isAdmin, bool isKPIAdmin, bool isMiscastAdmin)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.isAdmin = isAdmin;
            this.isKPIAdmin = isKPIAdmin;
            this.isMiscastAdmin = isMiscastAdmin;

            testToolStripMenuItem.Visible =
                testToolStripMenuItem.Enabled = true;

            AddDateTimePickerToToolbar();
            menuItem1Day.PerformClick();
            this.Text = GetDashboardText(dashType);
            CheckCorrectMenuItem(dashType);

            if (ucDashboard1 != null)
            {
                ucDashboard1.SetupUserControl(
                    dashType,
                    DashboardLevel.Level1,
                    DashboardDayView.SevenDayView,
                    picker.Value, showWeeklyKPIToolStripMenuItem.Checked,
                    this.isMiscastAdmin);
                ucDashboard1.KPILabelClick +=
                    new DashboardUserControl.KPILabelClickEventHandler(ucDashboard_KPILabelClick);
                ucDashboard1.DashboardTIBClickEvent +=
                    new DashboardUserControl.DashboardTIBClickEventHandler(ucDashboard_DashboardTIBClickEvent);
            }
            if (ucDashboard2 != null)
            {
                ucDashboard2.SetupUserControl(
                    dashType,
                    DashboardLevel.Level2,
                    DashboardDayView.SevenDayView,
                    picker.Value, showWeeklyKPIToolStripMenuItem.Checked,
                    this.isMiscastAdmin);
                ucDashboard2.KPILabelClick +=
                    new DashboardUserControl.KPILabelClickEventHandler(ucDashboard_KPILabelClick);
                ucDashboard2.DashboardTIBClickEvent +=
                    new DashboardUserControl.DashboardTIBClickEventHandler(ucDashboard_DashboardTIBClickEvent);
            }
        }

        /// <summary>
        /// Checks the menu item in the Dashboard menu to represent
        /// which dashboard is currently displayed.
        /// </summary>
        /// <param name="dashType">The Type of Dashboard.</param>
        private void CheckCorrectMenuItem(DashboardType dashType)
        {
            cMMToolStripMenuItem.Checked =
            primaryToolStripMenuItem.Checked =
            castingToolStripMenuItem.Checked = 
            secondaryToolStripMenuItem.Checked = 
            testToolStripMenuItem.Checked =
                false;

            switch (dashType)
            {
                case DashboardType.CMM:
                    cMMToolStripMenuItem.Checked = true;
                    break;

                case DashboardType.Primary:
                    primaryToolStripMenuItem.Checked = true;
                    break;

                case DashboardType.Casting:
                    castingToolStripMenuItem.Checked = true;
                    break;

                case DashboardType.Secondary:
                    secondaryToolStripMenuItem.Checked = true;
                    break;

                case DashboardType.Test:
                    testToolStripMenuItem.Checked = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the Dashboard header text depending on the type.
        /// </summary>
        /// <param name="dashType">The Dashboard Type.</param>
        /// <returns>The Text as a string.</returns>
        private string GetDashboardText(DashboardType dashType)
        {
            switch (dashType)
            {
                case DashboardType.CMM:
                    return "Central Morning Meeting Dashboard";
                case DashboardType.Primary:
                    return "Primary Dashboard";
                case DashboardType.Casting:
                    return "Casting Dashboard";
                case DashboardType.Secondary:
                    return "Secondary Dashboard";
                case DashboardType.Test:
                    return "Test Dashboard";
                default:
                    return "Dashboard";
            }
        }

        /// <summary>
        /// Sets the scroll height for the main dash panel.
        /// </summary>
        private void SetScrollHeight()
        {
            pnlDashboards.AutoScrollMinSize = new Size(0, 650);//default size

            double dash1AutoScroll = CalculateHeight(ucDashboard1.RowCount, ucDashboard1.RowHeight);
            double dash2AutoScroll = CalculateHeight(ucDashboard2.RowCount, ucDashboard2.RowHeight);

            if (dash1AutoScroll >= dash2AutoScroll)
                pnlDashboards.AutoScrollMinSize = new Size(0, Convert.ToInt32(dash1AutoScroll));
            else if (dash2AutoScroll > dash1AutoScroll)
                pnlDashboards.AutoScrollMinSize = new Size(0, Convert.ToInt32(dash2AutoScroll));
        }

        /// <summary>
        /// Calculates the Height of the Dashboards
        /// adding an offset.
        /// </summary>
        /// <param name="rowCount">The amount of rows on the dashboard.</param>
        /// <param name="rowHeight">They Height of each row.</param>
        /// <returns>The total height with an added offset.</returns>
        private double CalculateHeight(int rowCount, int rowHeight)
        {
            return (rowCount * rowHeight) + 42;
        }

        /// <summary>
        /// Datetime picker must be added to toolbar in code
        /// (cannot be done through designer).
        /// </summary>
        private void AddDateTimePickerToToolbar()
        {
            picker = new DateTimePicker();
            picker.Width = 90;
            picker.ValueChanged += new EventHandler(DatePickerValueChanged);
            picker.Format = DateTimePickerFormat.Short;
            toolStripTimeControls.Items.Insert(3, new ToolStripControlHost(picker));
            SetDatePicker();
        }

        /// <summary>
        /// Sets the value and the MaxDate values of the
        /// Date Time Picker to a default value depending on
        /// the No of days selected option.
        /// </summary>
        private void SetDatePicker()
        {
            if (picker != null)
            {
                DateTime weekStart = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);

                picker.Value = new DateTime(
                    weekStart.Year,
                    weekStart.Month,
                    weekStart.Day,
                    7, 0, 0);//Default to start of week shift.
            }
        }

        /// <summary>
        /// Updates the Date Label on the form.
        /// </summary>
        private void UpdateDateLabels()
        {
            lblDate.Text = string.Format(
                "From {0} to {1}",
                this.picker.Value.ToString("dd/MM/yy HH:mm"),
                this.picker.Value.AddDays(noOfDays).ToString("dd/MM/yy HH:mm"));

            DateTime weekStart = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);

            toolStripThisWeek.ToolTipText = "Go to " +
                weekStart.ToString("dd/MM/yy 07:00");
        }

        /// <summary>
        /// Updates the Dashboard dates to display different data.
        /// </summary>
        private void UpdateDashboardDates()
        {
            if (ucDashboard1 != null)
            {
                ucDashboard1.StartDate = picker.Value;
            }
            if (ucDashboard2 != null)
            {
                ucDashboard2.StartDate = picker.Value;
            }
        }

        /// <summary>
        /// Updates the Dashboard views to display different amount of days.
        /// </summary>
        private void UpdateDashboardView()
        {
            if (ucDashboard1 != null)
            {
                ucDashboard1.DashDayView = (DashboardDayView)this.noOfDays;
            }
            if (ucDashboard2 != null)
            {
                ucDashboard2.DashDayView = (DashboardDayView)this.noOfDays;
            }
        }

        /// <summary>
        /// Sets the splitter to centre of the form.
        /// </summary>
        private void SetSplitter()
        {
            ucDashboard1.Width = this.Width / 2;
        }

        /// <summary>
        /// Displays the weekly column on the KPI Dashboard.
        /// </summary>
        /// <param name="state">True for visible, false for not.</param>
        private void ShowWeeklyKPIOnDashboards(bool state)
        {
            if (ucDashboard1 != null)
            {
                ucDashboard1.ShowWeekly = state;
            }
            if (ucDashboard2 != null)
            {
                ucDashboard2.ShowWeekly = state;
            }
        }

        /// <summary>
        /// Event for handling the View menu
        /// </summary>
        private void viewMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Finds the menu item
            foreach (var item in ((ToolStripMenuItem)sender).GetCurrentParent().Items)
            {
                if (item is ToolStripMenuItem)
                {//Checks its a tool strip menu item
                    ToolStripMenuItem toolStripItem = (ToolStripMenuItem)item;
                    if (toolStripItem.Tag != null)//Checks it's one we want to check/uncheck
                    {
                        //Checks or unchecks it
                        if (toolStripItem == sender)
                        {
                            toolStripItem.Checked = true;
                            this.noOfDays = Convert.ToInt16(toolStripItem.Tag);
                        }
                        if ((toolStripItem != null) && (toolStripItem != sender))
                        {
                            toolStripItem.Checked = false;
                        }
                    }
                }
            }

            UpdateDateLabels();
            UpdateDashboardView();
            SetDatePicker();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Select Specific day using the date picker
        /// </summary>
        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            UpdateDateLabels();
            UpdateDashboardDates();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Back button event handler.
        /// </summary>
        private void toolStripPrevious_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            picker.Value = picker.Value.AddDays(-this.noOfDays);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Forward button event handler.
        /// </summary>
        private void toolStripNext_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            picker.Value = picker.Value.AddDays(this.noOfDays);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// This Week button event handler.
        /// </summary>
        private void toolStripThisWeek_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            picker.Value = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).AddHours(7);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Click event handler for the One day toolbar item.
        /// </summary>
        private void toolStripOneDay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            menuItem1Day.PerformClick();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Click event handler for the Two day toolbar item.
        /// </summary>
        private void toolStripThreeDays_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            menuItem3Day.PerformClick();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Click event handler for the Three day toolbar item.
        /// </summary>
        private void toolStripSevenDays_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            menuItem7Day.PerformClick();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void MainDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Click event for the show weekly menu item.
        /// </summary>
        private void showWeeklyKPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ShowWeeklyKPIOnDashboards(showWeeklyKPIToolStripMenuItem.Checked);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Resets the splitter position on double click event.
        /// </summary>
        private void splitter1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetSplitter();
        }

        /// <summary>
        /// Defaults the Dashboard to display the 7 Day view.
        /// </summary>
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            menuItem7Day.PerformClick();
        }

        /// <summary>
        /// Event handler for the FormHasBuilt event on the Dashboards.
        /// </summary>
        private void ucDashboard_FormHasBuilt(object sender, EventArgs e)
        {
            SetScrollHeight();
            SetSplitter();
            if (ucDashboard1 != null)
                ucDashboard1.SetSplitter();
            if (ucDashboard2 != null)
                ucDashboard2.SetSplitter();
        }

        /// <summary>
        /// Central Morning Meeting Dashboard Click Event Handler.
        /// </summary>
        private void cMMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this.mainForm, DashboardType.CMM, 
                this.isAdmin, this.isKPIAdmin, this.isMiscastAdmin);

            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(mainForm.dashboard_DashboardTIBClickEvent);

            dashboard.Show();
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Primary Dashboard Click Event Handler.
        /// </summary>
        private void primaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this.mainForm, DashboardType.Primary, 
                this.isAdmin, this.isKPIAdmin, this.isMiscastAdmin);

            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(mainForm.dashboard_DashboardTIBClickEvent);

            dashboard.Show();
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Casting Dashboard Click Event Handler.
        /// </summary>
        private void castingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this.mainForm, DashboardType.Casting, 
                this.isAdmin, this.isKPIAdmin, this.isMiscastAdmin);

            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(mainForm.dashboard_DashboardTIBClickEvent);

            dashboard.Show();
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Casting Dashboard Click Event Handler.
        /// </summary>
        private void safetyStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this.mainForm, DashboardType.Safety,
                this.isAdmin, this.isKPIAdmin, this.isMiscastAdmin);

            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(mainForm.dashboard_DashboardTIBClickEvent);

            dashboard.Show();
            this.Close();
            this.Cursor = Cursors.Default;
        }
 
        /// <summary>
        /// Secondary Dashboard Click Event Handler.
        /// </summary>
        private void secondaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this.mainForm, DashboardType.Secondary, 
                this.isAdmin, this.isKPIAdmin, this.isMiscastAdmin);

            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(mainForm.dashboard_DashboardTIBClickEvent);

            dashboard.Show();
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Test Dashboard Click Event Handler.
        /// </summary>
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainDashboard dashboard = new
                MainDashboard(this.mainForm, DashboardType.Test,
                this.isAdmin, this.isKPIAdmin, this.isMiscastAdmin);

            dashboard.DashboardTIBClickEvent +=
                new MainDashboard.DashboardTIBClickEventHandler(mainForm.dashboard_DashboardTIBClickEvent);

            dashboard.Show();
            this.Close();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Dashboard Configuration Menu Item Click Event Handler.
        /// </summary>
        private void dashboardConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucDashboard_KPILabelClick(null);//Pass null to not pre-select a KPI.
        }

        /// <summary>
        /// KPI Label Desc Click Event Handler.
        /// </summary>
        /// <param name="kpiConfig">The KPI Config Clicked.</param>
        private void ucDashboard_KPILabelClick(ElvisDataModel.EDMX.KPIConfig kpiConfig)
        {
            this.Cursor = Cursors.WaitCursor;
            using (DashboardConfig dashboardConfig = new DashboardConfig(
                this.isAdmin,
                this.isKPIAdmin,
                kpiConfig))
            {
                DialogResult result = dashboardConfig.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdateDashboardDates();
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Passing the event up to the main form.
        /// </summary>
        /// <param name="dateTime"></param>
        private void ucDashboard_DashboardTIBClickEvent(DateTime dateTime)
        {
            if (this.DashboardTIBClickEvent != null)
            {
                this.WindowState = FormWindowState.Minimized;
                this.DashboardTIBClickEvent(dateTime);
            }
        }

        #region Printing

        /// <summary>
        /// Print Page event handler.
        /// </summary>
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(
                memoryScreenShot,
                HelperFunctions.ResizeAndMaintainAspectRatio(e.MarginBounds, memoryScreenShot)
            );
        }

        /// <summary>
        /// Print Menu Item event handler.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                CaptureScreen();
                printDocument1.Print();
            }
        }

        /// <summary>
        /// Print Preview Menu Item event handler.
        /// </summary>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// Method for capturing the form and storing in a variable
        /// for future use.
        /// </summary>
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryScreenShot = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryScreenShot);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        #endregion Printing

    }
}
