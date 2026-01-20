namespace Elvis.Forms.Trending
{
    partial class MainDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            this.toolStripTimeControls = new System.Windows.Forms.ToolStrip();
            this.toolStripThisWeek = new System.Windows.Forms.ToolStripButton();
            this.toolStripSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOneDay = new System.Windows.Forms.ToolStripButton();
            this.toolStripThreeDays = new System.Windows.Forms.ToolStripButton();
            this.toolStripSevenDays = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1Day = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3Day = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem7Day = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.thisWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showWeeklyKPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.castingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlDashboards = new System.Windows.Forms.Panel();
            this.ucDashboard2 = new Elvis.Forms.Trending.UserControls.DashboardUserControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ucDashboard1 = new Elvis.Forms.Trending.UserControls.DashboardUserControl();
            this.safetyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTimeControls.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlDashboards.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTimeControls
            // 
            this.toolStripTimeControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripThisWeek,
            this.toolStripSep2,
            this.toolStripPrevious,
            this.toolStripNext,
            this.toolStripSep3,
            this.toolStripOneDay,
            this.toolStripThreeDays,
            this.toolStripSevenDays,
            this.toolStripSeparator4});
            this.toolStripTimeControls.Location = new System.Drawing.Point(0, 24);
            this.toolStripTimeControls.Name = "toolStripTimeControls";
            this.toolStripTimeControls.Size = new System.Drawing.Size(1016, 25);
            this.toolStripTimeControls.TabIndex = 13;
            this.toolStripTimeControls.Text = "Time Controls";
            // 
            // toolStripThisWeek
            // 
            this.toolStripThisWeek.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripThisWeek.Image = ((System.Drawing.Image)(resources.GetObject("toolStripThisWeek.Image")));
            this.toolStripThisWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThisWeek.Name = "toolStripThisWeek";
            this.toolStripThisWeek.Size = new System.Drawing.Size(76, 22);
            this.toolStripThisWeek.Text = "This Week";
            this.toolStripThisWeek.ToolTipText = "This Week (Ctrl+T)";
            this.toolStripThisWeek.Click += new System.EventHandler(this.toolStripThisWeek_Click);
            // 
            // toolStripSep2
            // 
            this.toolStripSep2.Name = "toolStripSep2";
            this.toolStripSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripPrevious
            // 
            this.toolStripPrevious.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPrevious.Image")));
            this.toolStripPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrevious.Name = "toolStripPrevious";
            this.toolStripPrevious.Size = new System.Drawing.Size(23, 22);
            this.toolStripPrevious.ToolTipText = "Previous (Ctrl+R)";
            this.toolStripPrevious.Click += new System.EventHandler(this.toolStripPrevious_Click);
            // 
            // toolStripNext
            // 
            this.toolStripNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNext.Image")));
            this.toolStripNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripNext.ToolTipText = "Next (Ctrl+N)";
            this.toolStripNext.Click += new System.EventHandler(this.toolStripNext_Click);
            // 
            // toolStripSep3
            // 
            this.toolStripSep3.Name = "toolStripSep3";
            this.toolStripSep3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripOneDay
            // 
            this.toolStripOneDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripOneDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOneDay.Name = "toolStripOneDay";
            this.toolStripOneDay.Size = new System.Drawing.Size(53, 22);
            this.toolStripOneDay.Text = "One Day";
            this.toolStripOneDay.ToolTipText = "Show one days data";
            this.toolStripOneDay.Click += new System.EventHandler(this.toolStripOneDay_Click);
            // 
            // toolStripThreeDays
            // 
            this.toolStripThreeDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripThreeDays.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThreeDays.Name = "toolStripThreeDays";
            this.toolStripThreeDays.Size = new System.Drawing.Size(66, 22);
            this.toolStripThreeDays.Text = "Three Days";
            this.toolStripThreeDays.ToolTipText = "Show three days data";
            this.toolStripThreeDays.Click += new System.EventHandler(this.toolStripThreeDays_Click);
            // 
            // toolStripSevenDays
            // 
            this.toolStripSevenDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSevenDays.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSevenDays.Name = "toolStripSevenDays";
            this.toolStripSevenDays.Size = new System.Drawing.Size(68, 22);
            this.toolStripSevenDays.Text = "Seven Days";
            this.toolStripSevenDays.ToolTipText = "Show seven days data";
            this.toolStripSevenDays.Click += new System.EventHandler(this.toolStripSevenDays_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.dashboardToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuItemClose});
            this.menuFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // menuItemClose
            // 
            this.menuItemClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuItemClose.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(157, 22);
            this.menuItemClose.Text = "&Close";
            this.menuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1Day,
            this.menuItem3Day,
            this.menuItem7Day,
            this.toolStripSeparator2,
            this.thisWeekToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.backToolStripMenuItem,
            this.toolStripSeparator3,
            this.showWeeklyKPIToolStripMenuItem});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(41, 20);
            this.menuView.Text = "&View";
            // 
            // menuItem1Day
            // 
            this.menuItem1Day.Checked = true;
            this.menuItem1Day.CheckOnClick = true;
            this.menuItem1Day.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItem1Day.Name = "menuItem1Day";
            this.menuItem1Day.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.menuItem1Day.Size = new System.Drawing.Size(210, 22);
            this.menuItem1Day.Tag = "1";
            this.menuItem1Day.Text = "&One Day";
            this.menuItem1Day.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // menuItem3Day
            // 
            this.menuItem3Day.CheckOnClick = true;
            this.menuItem3Day.Name = "menuItem3Day";
            this.menuItem3Day.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.menuItem3Day.Size = new System.Drawing.Size(210, 22);
            this.menuItem3Day.Tag = "3";
            this.menuItem3Day.Text = "Thr&ee Days";
            this.menuItem3Day.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // menuItem7Day
            // 
            this.menuItem7Day.CheckOnClick = true;
            this.menuItem7Day.Name = "menuItem7Day";
            this.menuItem7Day.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.menuItem7Day.Size = new System.Drawing.Size(210, 22);
            this.menuItem7Day.Tag = "7";
            this.menuItem7Day.Text = "&Seven Days";
            this.menuItem7Day.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // thisWeekToolStripMenuItem
            // 
            this.thisWeekToolStripMenuItem.Name = "thisWeekToolStripMenuItem";
            this.thisWeekToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.thisWeekToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.thisWeekToolStripMenuItem.Text = "&This Week";
            this.thisWeekToolStripMenuItem.Click += new System.EventHandler(this.toolStripThisWeek_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.forwardToolStripMenuItem.Text = "&Next";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.toolStripNext_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.backToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.backToolStripMenuItem.Text = "P&revious";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.toolStripPrevious_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // showWeeklyKPIToolStripMenuItem
            // 
            this.showWeeklyKPIToolStripMenuItem.Checked = true;
            this.showWeeklyKPIToolStripMenuItem.CheckOnClick = true;
            this.showWeeklyKPIToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showWeeklyKPIToolStripMenuItem.Name = "showWeeklyKPIToolStripMenuItem";
            this.showWeeklyKPIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.showWeeklyKPIToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.showWeeklyKPIToolStripMenuItem.Text = "Show &Weekly KPI";
            this.showWeeklyKPIToolStripMenuItem.Click += new System.EventHandler(this.showWeeklyKPIToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMMToolStripMenuItem,
            this.primaryToolStripMenuItem,
            this.secondaryToolStripMenuItem,
            this.castingToolStripMenuItem,
            this.safetyStripMenuItem,
            this.testToolStripMenuItem});
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.dashboardToolStripMenuItem.Text = "&Dashboard";
            // 
            // cMMToolStripMenuItem
            // 
            this.cMMToolStripMenuItem.CheckOnClick = true;
            this.cMMToolStripMenuItem.Name = "cMMToolStripMenuItem";
            this.cMMToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cMMToolStripMenuItem.Text = "1. C&MM";
            this.cMMToolStripMenuItem.Click += new System.EventHandler(this.cMMToolStripMenuItem_Click);
            // 
            // primaryToolStripMenuItem
            // 
            this.primaryToolStripMenuItem.CheckOnClick = true;
            this.primaryToolStripMenuItem.Name = "primaryToolStripMenuItem";
            this.primaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.primaryToolStripMenuItem.Text = "2. &Primary";
            this.primaryToolStripMenuItem.Click += new System.EventHandler(this.primaryToolStripMenuItem_Click);
            // 
            // secondaryToolStripMenuItem
            // 
            this.secondaryToolStripMenuItem.Name = "secondaryToolStripMenuItem";
            this.secondaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.secondaryToolStripMenuItem.Text = "3. &Secondary";
            this.secondaryToolStripMenuItem.Click += new System.EventHandler(this.secondaryToolStripMenuItem_Click);
            // 
            // castingToolStripMenuItem
            // 
            this.castingToolStripMenuItem.CheckOnClick = true;
            this.castingToolStripMenuItem.Name = "castingToolStripMenuItem";
            this.castingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.castingToolStripMenuItem.Text = "4. &Casting";
            this.castingToolStripMenuItem.Click += new System.EventHandler(this.castingToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.CheckOnClick = true;
            this.testToolStripMenuItem.Enabled = false;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testToolStripMenuItem.Text = "6. &Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardConfigurationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // dashboardConfigurationToolStripMenuItem
            // 
            this.dashboardConfigurationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardConfigurationToolStripMenuItem.Image")));
            this.dashboardConfigurationToolStripMenuItem.Name = "dashboardConfigurationToolStripMenuItem";
            this.dashboardConfigurationToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.dashboardConfigurationToolStripMenuItem.Text = "Dashboard &Configuration...";
            this.dashboardConfigurationToolStripMenuItem.Click += new System.EventHandler(this.dashboardConfigurationToolStripMenuItem_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblDate);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 704);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.pnlFooter.Size = new System.Drawing.Size(1016, 30);
            this.pnlFooter.TabIndex = 16;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(6, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(239, 24);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "From 01/01/99 07:00 to 02/01/99 07:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(938, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "Elvis CMM Dashboard";
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 3000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ShowAlways = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pnlDashboards
            // 
            this.pnlDashboards.AutoScroll = true;
            this.pnlDashboards.AutoScrollMinSize = new System.Drawing.Size(0, 650);
            this.pnlDashboards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDashboards.Controls.Add(this.ucDashboard2);
            this.pnlDashboards.Controls.Add(this.splitter1);
            this.pnlDashboards.Controls.Add(this.ucDashboard1);
            this.pnlDashboards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboards.Location = new System.Drawing.Point(0, 49);
            this.pnlDashboards.Name = "pnlDashboards";
            this.pnlDashboards.Size = new System.Drawing.Size(1016, 655);
            this.pnlDashboards.TabIndex = 18;
            // 
            // ucDashboard2
            // 
            this.ucDashboard2.AutoScroll = true;
            this.ucDashboard2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ucDashboard2.DashDayView = BusinessLogic.Constants.Trending.Dashboards.DashboardDayView.OneDayView;
            this.ucDashboard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDashboard2.FormBuilt = false;
            this.ucDashboard2.Location = new System.Drawing.Point(510, 0);
            this.ucDashboard2.Name = "ucDashboard2";
            this.ucDashboard2.ShowWeekly = false;
            this.ucDashboard2.Size = new System.Drawing.Size(502, 651);
            this.ucDashboard2.StartDate = new System.DateTime(((long)(0)));
            this.ucDashboard2.TabIndex = 16;
            this.ucDashboard2.FormHasBuilt += new System.EventHandler(this.ucDashboard_FormHasBuilt);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitter1.Location = new System.Drawing.Point(506, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 651);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            this.splitter1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseDoubleClick);
            // 
            // ucDashboard1
            // 
            this.ucDashboard1.AutoScroll = true;
            this.ucDashboard1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ucDashboard1.DashDayView = BusinessLogic.Constants.Trending.Dashboards.DashboardDayView.OneDayView;
            this.ucDashboard1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucDashboard1.FormBuilt = false;
            this.ucDashboard1.Location = new System.Drawing.Point(0, 0);
            this.ucDashboard1.Name = "ucDashboard1";
            this.ucDashboard1.ShowWeekly = false;
            this.ucDashboard1.Size = new System.Drawing.Size(506, 651);
            this.ucDashboard1.StartDate = new System.DateTime(((long)(0)));
            this.ucDashboard1.TabIndex = 15;
            this.ucDashboard1.FormHasBuilt += new System.EventHandler(this.ucDashboard_FormHasBuilt);
            // 
            // safetyStripMenuItem
            // 
            this.safetyStripMenuItem.Name = "safetyStripMenuItem";
            this.safetyStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.safetyStripMenuItem.Text = "5. Safety";
            this.safetyStripMenuItem.Click += new System.EventHandler(this.safetyStripMenuItem_Click);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.pnlDashboards);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.toolStripTimeControls);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainDashboard_KeyDown);
            this.toolStripTimeControls.ResumeLayout(false);
            this.toolStripTimeControls.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlDashboards.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTimeControls;
        private System.Windows.Forms.ToolStripButton toolStripThisWeek;
        private System.Windows.Forms.ToolStripSeparator toolStripSep2;
        private System.Windows.Forms.ToolStripButton toolStripPrevious;
        private System.Windows.Forms.ToolStripButton toolStripNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSep3;
        private System.Windows.Forms.ToolStripButton toolStripOneDay;
        private System.Windows.Forms.ToolStripButton toolStripThreeDays;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuItem1Day;
        private System.Windows.Forms.ToolStripMenuItem menuItem3Day;
        private System.Windows.Forms.ToolStripMenuItem menuItem7Day;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem thisWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripSevenDays;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showWeeklyKPIToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel pnlDashboards;
        private UserControls.DashboardUserControl ucDashboard2;
        private System.Windows.Forms.Splitter splitter1;
        private UserControls.DashboardUserControl ucDashboard1;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem castingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safetyStripMenuItem;
    }
}