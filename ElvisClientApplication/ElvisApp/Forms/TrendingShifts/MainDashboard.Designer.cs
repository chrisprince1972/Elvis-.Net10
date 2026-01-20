namespace Elvis.Forms.TrendingShifts
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
            this.toolStripThisMonth = new System.Windows.Forms.ToolStripButton();
            this.toolStripSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelDateTimeDisplay = new System.Windows.Forms.ToolStripLabel();
            this.toolStripNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonARota = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBRota = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCRota = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDRota = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemARota = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBRota = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCRota = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDRota = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemThisMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNextMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPrevMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShowSummedKpi = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.castingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safetyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.labelSatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelDashboardHolderForScrollBar = new System.Windows.Forms.Panel();
            this.DashboardUserControl = new Elvis.Forms.TrendingShifts.UserControls.DashboardUserControl();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.toolStripTimeControls.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panelDashboardHolderForScrollBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTimeControls
            // 
            this.toolStripTimeControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripThisMonth,
            this.toolStripSep2,
            this.toolStripPrevious,
            this.toolStripLabelDateTimeDisplay,
            this.toolStripNext,
            this.toolStripSep3,
            this.toolStripButtonARota,
            this.toolStripButtonBRota,
            this.toolStripButtonCRota,
            this.toolStripButtonDRota,
            this.toolStripSeparator4});
            this.toolStripTimeControls.Location = new System.Drawing.Point(0, 24);
            this.toolStripTimeControls.Name = "toolStripTimeControls";
            this.toolStripTimeControls.Size = new System.Drawing.Size(1061, 25);
            this.toolStripTimeControls.TabIndex = 13;
            this.toolStripTimeControls.Text = "Time Controls";
            // 
            // toolStripThisMonth
            // 
            this.toolStripThisMonth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripThisMonth.Image = ((System.Drawing.Image)(resources.GetObject("toolStripThisMonth.Image")));
            this.toolStripThisMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThisMonth.Name = "toolStripThisMonth";
            this.toolStripThisMonth.Size = new System.Drawing.Size(88, 22);
            this.toolStripThisMonth.Text = "This Month";
            this.toolStripThisMonth.ToolTipText = "This Week (Ctrl+T)";
            this.toolStripThisMonth.Click += new System.EventHandler(this.toolStripMenuItemThisMonth_Click);
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
            this.toolStripPrevious.Click += new System.EventHandler(this.toolStripMenuItemPrevMonth_Click);
            // 
            // toolStripLabelDateTimeDisplay
            // 
            this.toolStripLabelDateTimeDisplay.Name = "toolStripLabelDateTimeDisplay";
            this.toolStripLabelDateTimeDisplay.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabelDateTimeDisplay.Text = "Error";
            // 
            // toolStripNext
            // 
            this.toolStripNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNext.Image")));
            this.toolStripNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripNext.ToolTipText = "Next (Ctrl+N)";
            this.toolStripNext.Click += new System.EventHandler(this.toolStripMenuItemNextMonth_Click);
            // 
            // toolStripSep3
            // 
            this.toolStripSep3.Name = "toolStripSep3";
            this.toolStripSep3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonARota
            // 
            this.toolStripButtonARota.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButtonARota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonARota.Name = "toolStripButtonARota";
            this.toolStripButtonARota.Size = new System.Drawing.Size(46, 22);
            this.toolStripButtonARota.Text = "A Rota";
            this.toolStripButtonARota.ToolTipText = "Show A rota\'s KPIs";
            this.toolStripButtonARota.Click += new System.EventHandler(this.toolStripButtonARota_Click);
            // 
            // toolStripButtonBRota
            // 
            this.toolStripButtonBRota.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButtonBRota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBRota.Name = "toolStripButtonBRota";
            this.toolStripButtonBRota.Size = new System.Drawing.Size(45, 22);
            this.toolStripButtonBRota.Text = "B Rota";
            this.toolStripButtonBRota.ToolTipText = "Show B rota\'s KPIs";
            this.toolStripButtonBRota.Click += new System.EventHandler(this.toolStripButtonBRota_Click);
            // 
            // toolStripButtonCRota
            // 
            this.toolStripButtonCRota.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButtonCRota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCRota.Name = "toolStripButtonCRota";
            this.toolStripButtonCRota.Size = new System.Drawing.Size(46, 22);
            this.toolStripButtonCRota.Text = "C Rota";
            this.toolStripButtonCRota.ToolTipText = "Show C rota\'s KPIs";
            this.toolStripButtonCRota.Click += new System.EventHandler(this.toolStripButtonCRota_Click);
            // 
            // toolStripButtonDRota
            // 
            this.toolStripButtonDRota.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButtonDRota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDRota.Name = "toolStripButtonDRota";
            this.toolStripButtonDRota.Size = new System.Drawing.Size(46, 22);
            this.toolStripButtonDRota.Text = "D Rota";
            this.toolStripButtonDRota.ToolTipText = "Show C rota\'s KPIs";
            this.toolStripButtonDRota.Click += new System.EventHandler(this.toolStripButtonDRota_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(1061, 24);
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
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // menuItemClose
            // 
            this.menuItemClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuItemClose.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(149, 22);
            this.menuItemClose.Text = "&Close";
            this.menuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemARota,
            this.toolStripMenuItemBRota,
            this.toolStripMenuItemCRota,
            this.toolStripMenuItemDRota,
            this.toolStripSeparator2,
            this.toolStripMenuItemThisMonth,
            this.toolStripMenuItemNextMonth,
            this.toolStripMenuItemPrevMonth,
            this.toolStripSeparator3,
            this.toolStripMenuItemShowSummedKpi});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // toolStripMenuItemARota
            // 
            this.toolStripMenuItemARota.Checked = true;
            this.toolStripMenuItemARota.CheckOnClick = true;
            this.toolStripMenuItemARota.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemARota.Name = "toolStripMenuItemARota";
            this.toolStripMenuItemARota.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItemARota.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemARota.Tag = "";
            this.toolStripMenuItemARota.Text = "&A Rota";
            this.toolStripMenuItemARota.Click += new System.EventHandler(this.toolStripButtonARota_Click);
            // 
            // toolStripMenuItemBRota
            // 
            this.toolStripMenuItemBRota.CheckOnClick = true;
            this.toolStripMenuItemBRota.Name = "toolStripMenuItemBRota";
            this.toolStripMenuItemBRota.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.toolStripMenuItemBRota.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemBRota.Tag = "";
            this.toolStripMenuItemBRota.Text = "&B Rota";
            this.toolStripMenuItemBRota.Click += new System.EventHandler(this.toolStripButtonBRota_Click);
            // 
            // toolStripMenuItemCRota
            // 
            this.toolStripMenuItemCRota.CheckOnClick = true;
            this.toolStripMenuItemCRota.Name = "toolStripMenuItemCRota";
            this.toolStripMenuItemCRota.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemCRota.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemCRota.Tag = "";
            this.toolStripMenuItemCRota.Text = "&C Rota";
            this.toolStripMenuItemCRota.Click += new System.EventHandler(this.toolStripButtonCRota_Click);
            // 
            // toolStripMenuItemDRota
            // 
            this.toolStripMenuItemDRota.CheckOnClick = true;
            this.toolStripMenuItemDRota.Name = "toolStripMenuItemDRota";
            this.toolStripMenuItemDRota.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItemDRota.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemDRota.Tag = "";
            this.toolStripMenuItemDRota.Text = "&D Rota";
            this.toolStripMenuItemDRota.Click += new System.EventHandler(this.toolStripButtonDRota_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItemThisMonth
            // 
            this.toolStripMenuItemThisMonth.Name = "toolStripMenuItemThisMonth";
            this.toolStripMenuItemThisMonth.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItemThisMonth.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemThisMonth.Text = "&This Month";
            this.toolStripMenuItemThisMonth.Click += new System.EventHandler(this.toolStripMenuItemThisMonth_Click);
            // 
            // toolStripMenuItemNextMonth
            // 
            this.toolStripMenuItemNextMonth.Name = "toolStripMenuItemNextMonth";
            this.toolStripMenuItemNextMonth.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemNextMonth.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemNextMonth.Text = "&Next";
            this.toolStripMenuItemNextMonth.Click += new System.EventHandler(this.toolStripMenuItemNextMonth_Click);
            // 
            // toolStripMenuItemPrevMonth
            // 
            this.toolStripMenuItemPrevMonth.Name = "toolStripMenuItemPrevMonth";
            this.toolStripMenuItemPrevMonth.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.toolStripMenuItemPrevMonth.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemPrevMonth.Text = "P&revious";
            this.toolStripMenuItemPrevMonth.Click += new System.EventHandler(this.toolStripMenuItemPrevMonth_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItemShowSummedKpi
            // 
            this.toolStripMenuItemShowSummedKpi.Checked = true;
            this.toolStripMenuItemShowSummedKpi.CheckOnClick = true;
            this.toolStripMenuItemShowSummedKpi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemShowSummedKpi.Name = "toolStripMenuItemShowSummedKpi";
            this.toolStripMenuItemShowSummedKpi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemShowSummedKpi.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemShowSummedKpi.Text = "Show &Sum KPI";
            this.toolStripMenuItemShowSummedKpi.Click += new System.EventHandler(this.toolStripMenuItemShowSummedKpi_Click);
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
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.dashboardToolStripMenuItem.Text = "&Dashboard";
            // 
            // cMMToolStripMenuItem
            // 
            this.cMMToolStripMenuItem.CheckOnClick = true;
            this.cMMToolStripMenuItem.Name = "cMMToolStripMenuItem";
            this.cMMToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.cMMToolStripMenuItem.Text = "1. C&MM";
            this.cMMToolStripMenuItem.Click += new System.EventHandler(this.cMMToolStripMenuItem_Click);
            // 
            // primaryToolStripMenuItem
            // 
            this.primaryToolStripMenuItem.CheckOnClick = true;
            this.primaryToolStripMenuItem.Name = "primaryToolStripMenuItem";
            this.primaryToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.primaryToolStripMenuItem.Text = "2. &Primary";
            this.primaryToolStripMenuItem.Click += new System.EventHandler(this.primaryToolStripMenuItem_Click);
            // 
            // secondaryToolStripMenuItem
            // 
            this.secondaryToolStripMenuItem.Name = "secondaryToolStripMenuItem";
            this.secondaryToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.secondaryToolStripMenuItem.Text = "3. &Secondary";
            this.secondaryToolStripMenuItem.Click += new System.EventHandler(this.secondaryToolStripMenuItem_Click);
            // 
            // castingToolStripMenuItem
            // 
            this.castingToolStripMenuItem.CheckOnClick = true;
            this.castingToolStripMenuItem.Name = "castingToolStripMenuItem";
            this.castingToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.castingToolStripMenuItem.Text = "4. &Casting";
            this.castingToolStripMenuItem.Click += new System.EventHandler(this.castingToolStripMenuItem_Click);
            // 
            // safetyStripMenuItem
            // 
            this.safetyStripMenuItem.Name = "safetyStripMenuItem";
            this.safetyStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.safetyStripMenuItem.Text = "5. Safety";
            this.safetyStripMenuItem.Click += new System.EventHandler(this.safetyStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.CheckOnClick = true;
            this.testToolStripMenuItem.Enabled = false;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.testToolStripMenuItem.Text = "6. &Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardConfigurationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
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
            this.pnlFooter.Controls.Add(this.labelSatus);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 704);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.pnlFooter.Size = new System.Drawing.Size(1061, 30);
            this.pnlFooter.TabIndex = 16;
            // 
            // labelSatus
            // 
            this.labelSatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSatus.Location = new System.Drawing.Point(6, 3);
            this.labelSatus.Name = "labelSatus";
            this.labelSatus.Size = new System.Drawing.Size(977, 24);
            this.labelSatus.TabIndex = 1;
            this.labelSatus.Text = "From 01/01/99 07:00 to 02/01/99 07:00";
            this.labelSatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(983, 3);
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
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
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
            // panelDashboardHolderForScrollBar
            // 
            this.panelDashboardHolderForScrollBar.Controls.Add(this.DashboardUserControl);
            this.panelDashboardHolderForScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboardHolderForScrollBar.Location = new System.Drawing.Point(0, 49);
            this.panelDashboardHolderForScrollBar.Name = "panelDashboardHolderForScrollBar";
            this.panelDashboardHolderForScrollBar.Size = new System.Drawing.Size(1061, 655);
            this.panelDashboardHolderForScrollBar.TabIndex = 19;
            // 
            // DashboardUserControl
            // 
            this.DashboardUserControl.AutoScroll = true;
            this.DashboardUserControl.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DashboardUserControl.DashboardDayView = BusinessLogic.Constants.Trending.Dashboards.DashboardDayView.OneDayView;
            this.DashboardUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DashboardUserControl.Location = new System.Drawing.Point(0, 0);
            this.DashboardUserControl.Name = "DashboardUserControl";
            this.DashboardUserControl.Rota = BusinessLogic.Constants.Rota.A;
            this.DashboardUserControl.ShowMonthly = false;
            this.DashboardUserControl.Size = new System.Drawing.Size(1061, 655);
            this.DashboardUserControl.StartDate = new System.DateTime(((long)(0)));
            this.DashboardUserControl.TabIndex = 19;
            this.DashboardUserControl.FormHasBuilt += new System.EventHandler(this.ucDashboard_FormHasBuilt);
            // 
            // labelStatusText
            // 
            this.labelStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatusText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusText.Location = new System.Drawing.Point(6, 3);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(977, 24);
            this.labelStatusText.TabIndex = 1;
            this.labelStatusText.Text = "From 01/01/99 07:00 to 02/01/99 07:00";
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 734);
            this.Controls.Add(this.panelDashboardHolderForScrollBar);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.toolStripTimeControls);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainDashboard_KeyDown);
            this.toolStripTimeControls.ResumeLayout(false);
            this.toolStripTimeControls.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.panelDashboardHolderForScrollBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTimeControls;
        private System.Windows.Forms.ToolStripButton toolStripThisMonth;
        private System.Windows.Forms.ToolStripSeparator toolStripSep2;
        private System.Windows.Forms.ToolStripButton toolStripPrevious;
        private System.Windows.Forms.ToolStripButton toolStripNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSep3;
        private System.Windows.Forms.ToolStripButton toolStripButtonARota;
        private System.Windows.Forms.ToolStripButton toolStripButtonBRota;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemARota;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBRota;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCRota;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemThisMonth;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNextMonth;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPrevMonth;
        private System.Windows.Forms.ToolStripButton toolStripButtonCRota;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowSummedKpi;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem castingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safetyStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabelDateTimeDisplay;
        private System.Windows.Forms.Panel panelDashboardHolderForScrollBar;
        private UserControls.DashboardUserControl DashboardUserControl;
        private System.Windows.Forms.ToolStripButton toolStripButtonDRota;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDRota;
        protected System.Windows.Forms.Label labelStatusText;
        public System.Windows.Forms.Label labelSatus;
    }
}