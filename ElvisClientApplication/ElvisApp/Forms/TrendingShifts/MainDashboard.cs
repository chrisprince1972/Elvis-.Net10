using BusinessLogic.Constants;
using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.TrendingShifts;
using Elvis.Common;
using Elvis.Forms.TrendingShifts.UserControls;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Elvis.Forms.TrendingShifts
{
    public partial class MainDashboard : Form
    {
        private const string DATE_MONTH_FORMAT = "MMMM yyyy";
        private const string DATE_LONG_FORMAT = "dd/MM/yy HH:mm";

        private Bitmap MemoryScreenShot { get; set; }
        private MainForm MainForm { get; set; }
        private bool Printing { get; set; }
        private bool PrintPreview { get; set; }
        private FormWindowState PreviousWindowState { get; set; }
        private bool Admin { get; set; }
        private bool KpiAdmin { get; set; }
        #region Delegates And Events

        /// <summary>
        /// Fires when a TIB Delay KPI is Clicked on the Dashboard.
        /// </summary>
        /// <param name="dateTime">The Date Time that was clicked.</param>
        public delegate void DashboardTIBClickEventHandler(DateTime dateTime);

        public event DashboardTIBClickEventHandler DashboardTIBClickEvent;

        #endregion Delegates And Events

        public MainDashboard(MainForm mainForm, DashboardType dashType, 
            bool admin, bool kpiAdmin, bool miscastAdmin)
        {
            InitializeComponent();
            Printing = false;
            PrintPreview = false;
            PreviousWindowState = WindowState;
            MainForm = mainForm;

            Admin = admin;
            KpiAdmin = kpiAdmin;

            DashboardUserControl.DashboardDayView = DashboardDayView.MonthView;
            DashboardUserControl.Type = dashType;
            DashboardUserControl.ShowMonthly = true;

            SetToday();

            DashboardUserControl.SetupUserControl(miscastAdmin, labelSatus);
            DashboardUserControl.KpiLabelClick +=
                new DashboardUserControl.KpiLabelClickEventHandler(
                    ucDashboard_KpiLabelClick);

            DashboardUserControl.KpiLabel_MouseEnter +=
                new DashboardUserControl.KpiLabelMouseEnterEventHandler(
                    ucDashboardKpiLabel_MouseEnter);

            DashboardUserControl.KpiLabel_MouseLeave +=
                new DashboardUserControl.KpiLabelMouseLeaveEventHandler(
                    ucDashboardKpiLabel_MouseLeave);

            DashboardUserControl.DashboardTIBClickEvent +=
                new DashboardUserControl.DashboardTIBClickEventHandler(
                    ucDashboard_DashboardTIBClickEvent);

            CheckCorrectMenuItem(dashType);
            CheckCorrectMenuItem(DashboardUserControl.Rota);

            testToolStripMenuItem.Visible =
                testToolStripMenuItem.Enabled = true;
        }
        
        private void SetScrollHeight()
        {
            panelDashboardHolderForScrollBar.AutoScrollMinSize = 
                new Size(0, 650);
            double dash2AutoScroll = CalculateHeight(
                DashboardUserControl.RowCount, DashboardUserControl.RowHeight);
            panelDashboardHolderForScrollBar.AutoScrollMinSize = 
                new Size(0, Convert.ToInt32(dash2AutoScroll));
        }

        private void UpdateDateDisplay(DateTime dt)
        {
            toolStripLabelDateTimeDisplay.Text = dt.ToString(DATE_MONTH_FORMAT);
        }

        private void CheckCorrectMenuItem(DashboardType dashType)
        {
            cMMToolStripMenuItem.Checked = dashType == DashboardType.CMM;
            cMMToolStripMenuItem.Enabled = dashType != DashboardType.CMM;

            primaryToolStripMenuItem.Checked =
                dashType == DashboardType.Primary;
            primaryToolStripMenuItem.Enabled = 
                dashType != DashboardType.Primary;

            secondaryToolStripMenuItem.Checked =
                dashType == DashboardType.Secondary;
            secondaryToolStripMenuItem.Enabled =
                dashType != DashboardType.Secondary;

            castingToolStripMenuItem.Checked =
                dashType == DashboardType.Casting;
            castingToolStripMenuItem.Enabled =
                dashType != DashboardType.Casting;

            safetyStripMenuItem.Checked = dashType == DashboardType.Safety;
            safetyStripMenuItem.Enabled = dashType != DashboardType.Safety;
            testToolStripMenuItem.Checked = dashType == DashboardType.Test;
            testToolStripMenuItem.Enabled = dashType != DashboardType.Test;
        }
        private void CheckCorrectMenuItem(Rota rota)
        {
            toolStripMenuItemARota.Checked = rota == Rota.A;
            toolStripMenuItemARota.Enabled = rota != Rota.A;
            toolStripButtonARota.Enabled = rota != Rota.A;

            toolStripMenuItemBRota.Checked = rota == Rota.B;
            toolStripMenuItemBRota.Enabled = rota != Rota.B;
            toolStripButtonBRota.Enabled = rota != Rota.B;

            toolStripMenuItemCRota.Checked = rota == Rota.C;
            toolStripMenuItemCRota.Enabled = rota != Rota.C;
            toolStripButtonCRota.Enabled = rota != Rota.C;

            toolStripMenuItemDRota.Checked = rota == Rota.D;
            toolStripMenuItemDRota.Enabled = rota != Rota.D;
            toolStripButtonDRota.Enabled = rota != Rota.D;
        }

        private string GetDashboardText(DashboardType dashType)
        {
            return 
                string.Format("{0} dashboard", 
                    Enum.GetName(typeof(DashboardType), dashType));
        }

        private DateTime GetMonthStart(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1, 7, 0, 0);
        }

        private void SetToday()
        {
            SetDate(GetMonthStart(MyDateTime.Now));
        }
        
        /// <returns>The total height with an added offset.</returns>
        private double CalculateHeight(int rowCount, int rowHeight)
        {
            return (rowCount * rowHeight) + 42;
        }

        private void UpdateTitleStatus()
        {
            Text = labelSatus.Text = GetStatusText();
        }
        private string GetStatusText()
        {
            DateTime startDate = 
                DashboardUserControl.StartDate;
            DateTime endDate =
                startDate
                .AddMonths(1)
                .AddSeconds(-1);

            return string.Format(
                "{0} dashboard for {1} rota between {2} to {3}",
                DashboardUserControl.Type,
                DashboardUserControl.Rota,
                startDate.ToString(DATE_LONG_FORMAT),
                endDate.ToString(DATE_LONG_FORMAT));
        }
        

        private void SetDate(DateTime dt)
        {
            DashboardUserControl.StartDate = dt;
            UpdateDateDisplay(dt);
            UpdateTitleStatus();
            DateTime weekStart = GetMonthStart(MyDateTime.Now);

            toolStripThisMonth.ToolTipText = "Go to " +
                weekStart.ToString(DATE_MONTH_FORMAT);
        }

        private void ChangeUserControl(Rota newRota)
        {
            Cursor = Cursors.WaitCursor;
            CheckCorrectMenuItem(newRota);
            DashboardUserControl.Rota = newRota;
            DashboardUserControl.Reload();
            UpdateTitleStatus();
            Cursor = Cursors.Default;
        }
        private void ChangeUserControl(DashboardType newType)
        {
            Cursor = Cursors.WaitCursor;
            CheckCorrectMenuItem(newType);
            DashboardUserControl.Type = newType;
            DashboardUserControl.Reload();
            UpdateTitleStatus();
            Cursor = Cursors.Default;

        }
        
        private void ShowSummedKpi(bool state)
        {
            DashboardUserControl.ShowMonthly = state;
            DashboardUserControl.Reload();
        }


        private void CaptureScreen()
        {
            Graphics myGraphics = CreateGraphics();
            Size s = Size;
            MemoryScreenShot = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(MemoryScreenShot);
            memoryGraphics.CopyFromScreen(Location.X, Location.Y, 0, 0, s);
        }
        

        private void toolStripMenuItemPrevMonth_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SetDate(DashboardUserControl.StartDate.AddMonths(-1));
            DashboardUserControl.Reload();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItemNextMonth_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SetDate(DashboardUserControl.StartDate.AddMonths(1));
            DashboardUserControl.Reload();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItemThisMonth_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SetToday();
            DashboardUserControl.Reload();
            Cursor = Cursors.Default;
        }
        

        private void toolStripButtonARota_Click(object sender, EventArgs e)
        {
            ChangeUserControl(Rota.A);
        }
        
        private void toolStripButtonBRota_Click(object sender, EventArgs e)
        {
            ChangeUserControl(Rota.B);
        }

        private void toolStripButtonCRota_Click(object sender, EventArgs e)
        {
            ChangeUserControl(Rota.C);
        }
        private void toolStripButtonDRota_Click(object sender, EventArgs e)
        {
            ChangeUserControl(Rota.D);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Close();
            Cursor = Cursors.Default;
        }
        
        private void MainDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        
        private void toolStripMenuItemShowSummedKpi_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ShowSummedKpi(toolStripMenuItemShowSummedKpi.Checked);
            Cursor = Cursors.Default;
        }
        private void ucDashboard_FormHasBuilt(object sender, EventArgs e)
        {
            SetScrollHeight();
            DashboardUserControl.SetSplitter();
        }
        private void cMMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(DashboardType.CMM);
        }
        private void primaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(DashboardType.Primary);
        }
        private void castingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(DashboardType.Casting);
        }
        private void safetyStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(DashboardType.Safety);
        }
        private void secondaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(DashboardType.Secondary);
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(DashboardType.Test);
        }

        /// <summary>
        /// Dashboard Configuration Menu Item Click Event Handler.
        /// </summary>
        private void dashboardConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucDashboard_KpiLabelClick(null);//Pass null to not pre-select a KPI.
        }

        /// <summary>
        /// KPI Label Desc Click Event Handler.
        /// </summary>
        /// <param name="kpiConfig">The KPI Config Clicked.</param>
        private void ucDashboard_KpiLabelClick(KpiConfigShiftWrapper kpiConfig)
        {
            Cursor = Cursors.WaitCursor;
            using (DashboardConfig dashboardConfig =
                new DashboardConfig(Admin, KpiAdmin, kpiConfig))
            {
                DialogResult result = dashboardConfig.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DashboardUserControl.Reload();
                }
            }
            Cursor = Cursors.Default;
        }

        private void ucDashboardKpiLabel_MouseEnter(string text)
        {
            labelSatus.Text += " | " + text;
            labelSatus.Refresh();
        }
        private void ucDashboardKpiLabel_MouseLeave()
        {
            labelSatus.Text = Text;
        }

        /// <summary>
        /// Passing the event up to the main form.
        /// </summary>
        /// <param name="dateTime"></param>
        private void ucDashboard_DashboardTIBClickEvent(DateTime dateTime)
        {
            if (DashboardTIBClickEvent != null)
            {
                WindowState = FormWindowState.Minimized;
                DashboardTIBClickEvent(dateTime);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(
                MemoryScreenShot,
                HelperFunctions.ResizeAndMaintainAspectRatio(e.MarginBounds, MemoryScreenShot)
            );
        }
        
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                CaptureScreen();
                printDocument1.Print();
            }
            this.Cursor = Cursors.Default;
        }
        
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            CaptureScreen();
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        
    }
}
