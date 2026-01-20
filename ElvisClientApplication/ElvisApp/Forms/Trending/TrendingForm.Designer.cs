namespace Elvis.Forms.Trending
{
    partial class TrendingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrendingForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cmboGroup = new System.Windows.Forms.ComboBox();
            this.pnlGradesXHeats = new System.Windows.Forms.Panel();
            this.grpXHeat = new System.Windows.Forms.GroupBox();
            this.ccbXHeats = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.chbAllXHeats = new System.Windows.Forms.CheckBox();
            this.grpGrade = new System.Windows.Forms.GroupBox();
            this.ccbGrades = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.chbAllGrades = new System.Windows.Forms.CheckBox();
            this.pnlHeats = new System.Windows.Forms.Panel();
            this.grpHeatRange = new System.Windows.Forms.GroupBox();
            this.chbAllHeats = new System.Windows.Forms.CheckBox();
            this.cmboHeatTo = new System.Windows.Forms.ComboBox();
            this.cmboHeatFrom = new System.Windows.Forms.ComboBox();
            this.lblHeatTo = new System.Windows.Forms.Label();
            this.lblHeatFrom = new System.Windows.Forms.Label();
            this.pnlDateSelector = new System.Windows.Forms.Panel();
            this.grpDateSelector = new System.Windows.Forms.GroupBox();
            this.rbCurrentShift = new System.Windows.Forms.RadioButton();
            this.rbLastShift = new System.Windows.Forms.RadioButton();
            this.rbLastDay = new System.Windows.Forms.RadioButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            this.pnlFormat = new System.Windows.Forms.Panel();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rbFixed = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.pnlShowHide = new System.Windows.Forms.Panel();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.splitContainerSub = new System.Windows.Forms.SplitContainer();
            this.pnlGraphs = new System.Windows.Forms.Panel();
            this.grpCharts = new System.Windows.Forms.GroupBox();
            this.pnlCharts = new System.Windows.Forms.Panel();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.pnlAdditionalFilter = new System.Windows.Forms.Panel();
            this.pnlUnits = new System.Windows.Forms.Panel();
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.pnlSubUnits = new System.Windows.Forms.Panel();
            this.ucUnits = new Elvis.Forms.Trending.UserControls.UnitsVertical();
            this.pnlRota = new System.Windows.Forms.Panel();
            this.grpRota = new System.Windows.Forms.GroupBox();
            this.cmboRota = new System.Windows.Forms.ComboBox();
            this.pnlHighlight = new System.Windows.Forms.Panel();
            this.grpHighlight = new System.Windows.Forms.GroupBox();
            this.cmboHighlight = new System.Windows.Forms.ComboBox();
            this.pnlShowHide2 = new System.Windows.Forms.Panel();
            this.btnShowHide2 = new System.Windows.Forms.Button();
            this.printCharts = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDateStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            this.pnlGradesXHeats.SuspendLayout();
            this.grpXHeat.SuspendLayout();
            this.grpGrade.SuspendLayout();
            this.pnlHeats.SuspendLayout();
            this.grpHeatRange.SuspendLayout();
            this.pnlDateSelector.SuspendLayout();
            this.grpDateSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.pnlFormat.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.pnlShowHide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).BeginInit();
            this.splitContainerSub.Panel1.SuspendLayout();
            this.splitContainerSub.Panel2.SuspendLayout();
            this.splitContainerSub.SuspendLayout();
            this.pnlGraphs.SuspendLayout();
            this.grpCharts.SuspendLayout();
            this.pnlLegend.SuspendLayout();
            this.pnlAdditionalFilter.SuspendLayout();
            this.pnlUnits.SuspendLayout();
            this.grpUnits.SuspendLayout();
            this.pnlSubUnits.SuspendLayout();
            this.pnlRota.SuspendLayout();
            this.grpRota.SuspendLayout();
            this.pnlHighlight.SuspendLayout();
            this.grpHighlight.SuspendLayout();
            this.pnlShowHide2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::Elvis.Properties.Resources.excel;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.exportToolStripMenuItem.Text = "Export Data to Excel...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.legendToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // legendToolStripMenuItem
            // 
            this.legendToolStripMenuItem.CheckOnClick = true;
            this.legendToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("legendToolStripMenuItem.Image")));
            this.legendToolStripMenuItem.Name = "legendToolStripMenuItem";
            this.legendToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.legendToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.legendToolStripMenuItem.Text = "Show &Legend";
            this.legendToolStripMenuItem.Click += new System.EventHandler(this.legendToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generateToolStripMenuItem.Image")));
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.generateToolStripMenuItem.Text = "&Generate Charts";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetToolStripMenuItem.Image")));
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.resetToolStripMenuItem.Text = "&Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.splitContainerMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(992, 610);
            this.pnlMain.TabIndex = 6;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.AutoScroll = true;
            this.splitContainerMain.Panel1.Controls.Add(this.pnlFilter);
            this.splitContainerMain.Panel1.Controls.Add(this.pnlShowHide);
            this.splitContainerMain.Panel1MinSize = 50;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerSub);
            this.splitContainerMain.Panel2MinSize = 150;
            this.splitContainerMain.Size = new System.Drawing.Size(992, 610);
            this.splitContainerMain.SplitterDistance = 153;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 7;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(6, 6, 6, 2);
            this.pnlFilter.Size = new System.Drawing.Size(992, 145);
            this.pnlFilter.TabIndex = 3;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.pnlGroup);
            this.grpFilter.Controls.Add(this.pnlGradesXHeats);
            this.grpFilter.Controls.Add(this.pnlHeats);
            this.grpFilter.Controls.Add(this.pnlDateSelector);
            this.grpFilter.Controls.Add(this.pnlFormat);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(6, 6);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(6);
            this.grpFilter.Size = new System.Drawing.Size(980, 137);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // pnlGroup
            // 
            this.pnlGroup.Controls.Add(this.btnReset);
            this.pnlGroup.Controls.Add(this.btnGenerate);
            this.pnlGroup.Controls.Add(this.grpGroup);
            this.pnlGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGroup.Location = new System.Drawing.Point(716, 20);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlGroup.Size = new System.Drawing.Size(231, 111);
            this.pnlGroup.TabIndex = 36;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(0, 63);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(225, 24);
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGenerate.Location = new System.Drawing.Point(0, 87);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(225, 24);
            this.btnGenerate.TabIndex = 36;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cmboGroup);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGroup.Location = new System.Drawing.Point(0, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Padding = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.grpGroup.Size = new System.Drawing.Size(225, 53);
            this.grpGroup.TabIndex = 34;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "Group Selector";
            // 
            // cmboGroup
            // 
            this.cmboGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboGroup.FormattingEnabled = true;
            this.cmboGroup.Location = new System.Drawing.Point(8, 24);
            this.cmboGroup.Name = "cmboGroup";
            this.cmboGroup.Size = new System.Drawing.Size(209, 21);
            this.cmboGroup.TabIndex = 11;
            this.cmboGroup.SelectedValueChanged += new System.EventHandler(this.cmboGroup_SelectedValueChanged);
            // 
            // pnlGradesXHeats
            // 
            this.pnlGradesXHeats.Controls.Add(this.grpXHeat);
            this.pnlGradesXHeats.Controls.Add(this.grpGrade);
            this.pnlGradesXHeats.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGradesXHeats.Location = new System.Drawing.Point(506, 20);
            this.pnlGradesXHeats.Name = "pnlGradesXHeats";
            this.pnlGradesXHeats.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlGradesXHeats.Size = new System.Drawing.Size(210, 111);
            this.pnlGradesXHeats.TabIndex = 37;
            // 
            // grpXHeat
            // 
            this.grpXHeat.Controls.Add(this.ccbXHeats);
            this.grpXHeat.Controls.Add(this.chbAllXHeats);
            this.grpXHeat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpXHeat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpXHeat.Location = new System.Drawing.Point(0, 58);
            this.grpXHeat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpXHeat.Name = "grpXHeat";
            this.grpXHeat.Padding = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.grpXHeat.Size = new System.Drawing.Size(204, 53);
            this.grpXHeat.TabIndex = 35;
            this.grpXHeat.TabStop = false;
            this.grpXHeat.Text = "XHeat";
            // 
            // ccbXHeats
            // 
            this.ccbXHeats.CheckOnClick = true;
            this.ccbXHeats.Dock = System.Windows.Forms.DockStyle.Left;
            this.ccbXHeats.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbXHeats.DropDownHeight = 1;
            this.ccbXHeats.Enabled = false;
            this.ccbXHeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbXHeats.FormattingEnabled = true;
            this.ccbXHeats.IntegralHeight = false;
            this.ccbXHeats.Location = new System.Drawing.Point(8, 24);
            this.ccbXHeats.Name = "ccbXHeats";
            this.ccbXHeats.Size = new System.Drawing.Size(110, 21);
            this.ccbXHeats.TabIndex = 16;
            this.ccbXHeats.ValueSeparator = ", ";
            // 
            // chbAllXHeats
            // 
            this.chbAllXHeats.AutoSize = true;
            this.chbAllXHeats.Checked = true;
            this.chbAllXHeats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAllXHeats.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbAllXHeats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllXHeats.Location = new System.Drawing.Point(124, 24);
            this.chbAllXHeats.Name = "chbAllXHeats";
            this.chbAllXHeats.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.chbAllXHeats.Size = new System.Drawing.Size(72, 21);
            this.chbAllXHeats.TabIndex = 15;
            this.chbAllXHeats.Text = "Show All";
            this.chbAllXHeats.UseVisualStyleBackColor = true;
            this.chbAllXHeats.CheckedChanged += new System.EventHandler(this.chbAllXHeats_CheckedChanged);
            // 
            // grpGrade
            // 
            this.grpGrade.Controls.Add(this.ccbGrades);
            this.grpGrade.Controls.Add(this.chbAllGrades);
            this.grpGrade.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGrade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGrade.Location = new System.Drawing.Point(0, 0);
            this.grpGrade.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpGrade.Name = "grpGrade";
            this.grpGrade.Padding = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.grpGrade.Size = new System.Drawing.Size(204, 53);
            this.grpGrade.TabIndex = 35;
            this.grpGrade.TabStop = false;
            this.grpGrade.Text = "Grades";
            // 
            // ccbGrades
            // 
            this.ccbGrades.CheckOnClick = true;
            this.ccbGrades.Dock = System.Windows.Forms.DockStyle.Left;
            this.ccbGrades.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbGrades.DropDownHeight = 1;
            this.ccbGrades.Enabled = false;
            this.ccbGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbGrades.FormattingEnabled = true;
            this.ccbGrades.IntegralHeight = false;
            this.ccbGrades.Location = new System.Drawing.Point(8, 24);
            this.ccbGrades.Name = "ccbGrades";
            this.ccbGrades.Size = new System.Drawing.Size(110, 21);
            this.ccbGrades.TabIndex = 15;
            this.ccbGrades.ValueSeparator = ", ";
            // 
            // chbAllGrades
            // 
            this.chbAllGrades.AutoSize = true;
            this.chbAllGrades.Checked = true;
            this.chbAllGrades.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAllGrades.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbAllGrades.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllGrades.Location = new System.Drawing.Point(124, 24);
            this.chbAllGrades.Name = "chbAllGrades";
            this.chbAllGrades.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.chbAllGrades.Size = new System.Drawing.Size(72, 21);
            this.chbAllGrades.TabIndex = 14;
            this.chbAllGrades.Text = "Show All";
            this.chbAllGrades.UseVisualStyleBackColor = true;
            this.chbAllGrades.CheckedChanged += new System.EventHandler(this.chbAllGrades_CheckedChanged);
            // 
            // pnlHeats
            // 
            this.pnlHeats.Controls.Add(this.grpHeatRange);
            this.pnlHeats.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHeats.Location = new System.Drawing.Point(386, 20);
            this.pnlHeats.Name = "pnlHeats";
            this.pnlHeats.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlHeats.Size = new System.Drawing.Size(120, 111);
            this.pnlHeats.TabIndex = 35;
            // 
            // grpHeatRange
            // 
            this.grpHeatRange.Controls.Add(this.chbAllHeats);
            this.grpHeatRange.Controls.Add(this.cmboHeatTo);
            this.grpHeatRange.Controls.Add(this.cmboHeatFrom);
            this.grpHeatRange.Controls.Add(this.lblHeatTo);
            this.grpHeatRange.Controls.Add(this.lblHeatFrom);
            this.grpHeatRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHeatRange.Location = new System.Drawing.Point(0, 0);
            this.grpHeatRange.Name = "grpHeatRange";
            this.grpHeatRange.Padding = new System.Windows.Forms.Padding(10, 6, 10, 8);
            this.grpHeatRange.Size = new System.Drawing.Size(114, 111);
            this.grpHeatRange.TabIndex = 34;
            this.grpHeatRange.TabStop = false;
            this.grpHeatRange.Text = "Heat Range";
            // 
            // chbAllHeats
            // 
            this.chbAllHeats.AutoSize = true;
            this.chbAllHeats.Checked = true;
            this.chbAllHeats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAllHeats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chbAllHeats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllHeats.Location = new System.Drawing.Point(10, 86);
            this.chbAllHeats.Name = "chbAllHeats";
            this.chbAllHeats.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chbAllHeats.Size = new System.Drawing.Size(94, 17);
            this.chbAllHeats.TabIndex = 13;
            this.chbAllHeats.Text = "Show All";
            this.chbAllHeats.UseVisualStyleBackColor = true;
            this.chbAllHeats.CheckedChanged += new System.EventHandler(this.chbShowAllHeats_CheckedChanged);
            // 
            // cmboHeatTo
            // 
            this.cmboHeatTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboHeatTo.Enabled = false;
            this.cmboHeatTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboHeatTo.FormattingEnabled = true;
            this.cmboHeatTo.Location = new System.Drawing.Point(43, 55);
            this.cmboHeatTo.Name = "cmboHeatTo";
            this.cmboHeatTo.Size = new System.Drawing.Size(61, 21);
            this.cmboHeatTo.TabIndex = 12;
            // 
            // cmboHeatFrom
            // 
            this.cmboHeatFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboHeatFrom.Enabled = false;
            this.cmboHeatFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboHeatFrom.FormattingEnabled = true;
            this.cmboHeatFrom.Location = new System.Drawing.Point(43, 23);
            this.cmboHeatFrom.Name = "cmboHeatFrom";
            this.cmboHeatFrom.Size = new System.Drawing.Size(61, 21);
            this.cmboHeatFrom.TabIndex = 11;
            // 
            // lblHeatTo
            // 
            this.lblHeatTo.AutoSize = true;
            this.lblHeatTo.Enabled = false;
            this.lblHeatTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatTo.Location = new System.Drawing.Point(18, 58);
            this.lblHeatTo.Name = "lblHeatTo";
            this.lblHeatTo.Size = new System.Drawing.Size(19, 13);
            this.lblHeatTo.TabIndex = 10;
            this.lblHeatTo.Text = "To";
            // 
            // lblHeatFrom
            // 
            this.lblHeatFrom.AutoSize = true;
            this.lblHeatFrom.Enabled = false;
            this.lblHeatFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatFrom.Location = new System.Drawing.Point(6, 27);
            this.lblHeatFrom.Name = "lblHeatFrom";
            this.lblHeatFrom.Size = new System.Drawing.Size(31, 13);
            this.lblHeatFrom.TabIndex = 2;
            this.lblHeatFrom.Text = "From";
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.grpDateSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateSelector.Location = new System.Drawing.Point(106, 20);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(280, 111);
            this.pnlDateSelector.TabIndex = 34;
            // 
            // grpDateSelector
            // 
            this.grpDateSelector.Controls.Add(this.rbCurrentShift);
            this.grpDateSelector.Controls.Add(this.rbLastShift);
            this.grpDateSelector.Controls.Add(this.rbLastDay);
            this.grpDateSelector.Controls.Add(this.lblTo);
            this.grpDateSelector.Controls.Add(this.numYear);
            this.grpDateSelector.Controls.Add(this.dpTo);
            this.grpDateSelector.Controls.Add(this.lblYear);
            this.grpDateSelector.Controls.Add(this.lblFrom);
            this.grpDateSelector.Controls.Add(this.lblWeek);
            this.grpDateSelector.Controls.Add(this.dpFrom);
            this.grpDateSelector.Controls.Add(this.numWeek);
            this.grpDateSelector.Controls.Add(this.numDay);
            this.grpDateSelector.Controls.Add(this.lblDay);
            this.grpDateSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDateSelector.Location = new System.Drawing.Point(0, 0);
            this.grpDateSelector.Name = "grpDateSelector";
            this.grpDateSelector.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.grpDateSelector.Size = new System.Drawing.Size(274, 111);
            this.grpDateSelector.TabIndex = 34;
            this.grpDateSelector.TabStop = false;
            this.grpDateSelector.Text = "Date Selector";
            // 
            // rbCurrentShift
            // 
            this.rbCurrentShift.AutoSize = true;
            this.rbCurrentShift.Checked = true;
            this.rbCurrentShift.Enabled = false;
            this.rbCurrentShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCurrentShift.Location = new System.Drawing.Point(163, 83);
            this.rbCurrentShift.Name = "rbCurrentShift";
            this.rbCurrentShift.Size = new System.Drawing.Size(87, 17);
            this.rbCurrentShift.TabIndex = 33;
            this.rbCurrentShift.TabStop = true;
            this.rbCurrentShift.Text = "Current Shift";
            this.rbCurrentShift.UseVisualStyleBackColor = true;
            this.rbCurrentShift.CheckedChanged += new System.EventHandler(this.rbLastX_CheckedChanged);
            // 
            // rbLastShift
            // 
            this.rbLastShift.AutoSize = true;
            this.rbLastShift.Enabled = false;
            this.rbLastShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastShift.Location = new System.Drawing.Point(88, 83);
            this.rbLastShift.Name = "rbLastShift";
            this.rbLastShift.Size = new System.Drawing.Size(70, 17);
            this.rbLastShift.TabIndex = 32;
            this.rbLastShift.Text = "Last Shift";
            this.rbLastShift.UseVisualStyleBackColor = true;
            this.rbLastShift.CheckedChanged += new System.EventHandler(this.rbLastX_CheckedChanged);
            // 
            // rbLastDay
            // 
            this.rbLastDay.AutoSize = true;
            this.rbLastDay.Enabled = false;
            this.rbLastDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLastDay.Location = new System.Drawing.Point(15, 83);
            this.rbLastDay.Name = "rbLastDay";
            this.rbLastDay.Size = new System.Drawing.Size(67, 17);
            this.rbLastDay.TabIndex = 31;
            this.rbLastDay.Text = "Last Day";
            this.rbLastDay.UseVisualStyleBackColor = true;
            this.rbLastDay.CheckedChanged += new System.EventHandler(this.rbLastX_CheckedChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTo.Location = new System.Drawing.Point(142, 27);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To";
            // 
            // numYear
            // 
            this.numYear.Enabled = false;
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(206, 55);
            this.numYear.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(53, 20);
            this.numYear.TabIndex = 4;
            this.numYear.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // dpTo
            // 
            this.dpTo.Enabled = false;
            this.dpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(168, 23);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(93, 20);
            this.dpTo.TabIndex = 1;
            this.dpTo.ValueChanged += new System.EventHandler(this.dp_ValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Enabled = false;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(171, 59);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 30;
            this.lblYear.Text = "Year";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Enabled = false;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(6, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Enabled = false;
            this.lblWeek.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(87, 59);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(34, 13);
            this.lblWeek.TabIndex = 29;
            this.lblWeek.Text = "Week";
            // 
            // dpFrom
            // 
            this.dpFrom.Enabled = false;
            this.dpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(43, 23);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(93, 20);
            this.dpFrom.TabIndex = 0;
            this.dpFrom.ValueChanged += new System.EventHandler(this.dp_ValueChanged);
            // 
            // numWeek
            // 
            this.numWeek.Enabled = false;
            this.numWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeek.Location = new System.Drawing.Point(127, 55);
            this.numWeek.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(38, 20);
            this.numWeek.TabIndex = 3;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            // 
            // numDay
            // 
            this.numDay.Enabled = false;
            this.numDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDay.Location = new System.Drawing.Point(43, 55);
            this.numDay.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(38, 20);
            this.numDay.TabIndex = 2;
            this.numDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Enabled = false;
            this.lblDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(11, 57);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 19;
            this.lblDay.Text = "Day";
            // 
            // pnlFormat
            // 
            this.pnlFormat.Controls.Add(this.grpFormat);
            this.pnlFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormat.Location = new System.Drawing.Point(6, 20);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlFormat.Size = new System.Drawing.Size(100, 111);
            this.pnlFormat.TabIndex = 33;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rbFixed);
            this.grpFormat.Controls.Add(this.rbWeekly);
            this.grpFormat.Controls.Add(this.rbDaily);
            this.grpFormat.Controls.Add(this.rbDate);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFormat.Location = new System.Drawing.Point(0, 0);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Padding = new System.Windows.Forms.Padding(10, 6, 6, 10);
            this.grpFormat.Size = new System.Drawing.Size(94, 111);
            this.grpFormat.TabIndex = 33;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Date Format";
            // 
            // rbFixed
            // 
            this.rbFixed.AutoSize = true;
            this.rbFixed.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbFixed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFixed.Location = new System.Drawing.Point(10, 83);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbFixed.Size = new System.Drawing.Size(78, 21);
            this.rbFixed.TabIndex = 4;
            this.rbFixed.Text = "&Fixed";
            this.rbFixed.UseVisualStyleBackColor = true;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWeekly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWeekly.Location = new System.Drawing.Point(10, 62);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbWeekly.Size = new System.Drawing.Size(78, 21);
            this.rbWeekly.TabIndex = 2;
            this.rbWeekly.Text = "&Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDaily.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDaily.Location = new System.Drawing.Point(10, 41);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbDaily.Size = new System.Drawing.Size(78, 21);
            this.rbDaily.TabIndex = 1;
            this.rbDaily.Text = "&Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Checked = true;
            this.rbDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDate.Location = new System.Drawing.Point(10, 20);
            this.rbDate.Name = "rbDate";
            this.rbDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbDate.Size = new System.Drawing.Size(78, 21);
            this.rbDate.TabIndex = 0;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "&Pick Date";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // pnlShowHide
            // 
            this.pnlShowHide.Controls.Add(this.btnShowHide);
            this.pnlShowHide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlShowHide.Location = new System.Drawing.Point(0, 145);
            this.pnlShowHide.Name = "pnlShowHide";
            this.pnlShowHide.Size = new System.Drawing.Size(992, 8);
            this.pnlShowHide.TabIndex = 2;
            // 
            // btnShowHide
            // 
            this.btnShowHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowHide.FlatAppearance.BorderSize = 0;
            this.btnShowHide.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnShowHide.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHide.Image = global::Elvis.Properties.Resources.ShowButtonSmall;
            this.btnShowHide.Location = new System.Drawing.Point(0, 0);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(992, 8);
            this.btnShowHide.TabIndex = 0;
            this.btnShowHide.Tag = "Hide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // splitContainerSub
            // 
            this.splitContainerSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSub.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerSub.IsSplitterFixed = true;
            this.splitContainerSub.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSub.Name = "splitContainerSub";
            // 
            // splitContainerSub.Panel1
            // 
            this.splitContainerSub.Panel1.Controls.Add(this.pnlGraphs);
            this.splitContainerSub.Panel1.Controls.Add(this.pnlLegend);
            this.splitContainerSub.Panel1.Padding = new System.Windows.Forms.Padding(6, 0, 1, 6);
            // 
            // splitContainerSub.Panel2
            // 
            this.splitContainerSub.Panel2.Controls.Add(this.pnlAdditionalFilter);
            this.splitContainerSub.Panel2.Controls.Add(this.pnlShowHide2);
            this.splitContainerSub.Size = new System.Drawing.Size(992, 456);
            this.splitContainerSub.SplitterDistance = 860;
            this.splitContainerSub.SplitterWidth = 1;
            this.splitContainerSub.TabIndex = 0;
            // 
            // pnlGraphs
            // 
            this.pnlGraphs.Controls.Add(this.grpCharts);
            this.pnlGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraphs.Location = new System.Drawing.Point(6, 0);
            this.pnlGraphs.Name = "pnlGraphs";
            this.pnlGraphs.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlGraphs.Size = new System.Drawing.Size(853, 450);
            this.pnlGraphs.TabIndex = 0;
            // 
            // grpCharts
            // 
            this.grpCharts.Controls.Add(this.pnlCharts);
            this.grpCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCharts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCharts.Location = new System.Drawing.Point(0, 1);
            this.grpCharts.Name = "grpCharts";
            this.grpCharts.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpCharts.Size = new System.Drawing.Size(853, 449);
            this.grpCharts.TabIndex = 0;
            this.grpCharts.TabStop = false;
            this.grpCharts.Text = "Charts";
            // 
            // pnlCharts
            // 
            this.pnlCharts.AutoScroll = true;
            this.pnlCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharts.Location = new System.Drawing.Point(3, 14);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlCharts.Size = new System.Drawing.Size(847, 432);
            this.pnlCharts.TabIndex = 2;
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.grpLegend);
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLegend.Location = new System.Drawing.Point(6, 0);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(853, 0);
            this.pnlLegend.TabIndex = 1;
            // 
            // grpLegend
            // 
            this.grpLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLegend.Location = new System.Drawing.Point(0, 0);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpLegend.Size = new System.Drawing.Size(853, 0);
            this.grpLegend.TabIndex = 0;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Legend";
            // 
            // pnlAdditionalFilter
            // 
            this.pnlAdditionalFilter.Controls.Add(this.pnlUnits);
            this.pnlAdditionalFilter.Controls.Add(this.pnlRota);
            this.pnlAdditionalFilter.Controls.Add(this.pnlHighlight);
            this.pnlAdditionalFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdditionalFilter.Location = new System.Drawing.Point(8, 0);
            this.pnlAdditionalFilter.Name = "pnlAdditionalFilter";
            this.pnlAdditionalFilter.Padding = new System.Windows.Forms.Padding(1, 0, 3, 6);
            this.pnlAdditionalFilter.Size = new System.Drawing.Size(123, 456);
            this.pnlAdditionalFilter.TabIndex = 4;
            // 
            // pnlUnits
            // 
            this.pnlUnits.Controls.Add(this.grpUnits);
            this.pnlUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnits.Location = new System.Drawing.Point(1, 104);
            this.pnlUnits.Name = "pnlUnits";
            this.pnlUnits.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlUnits.Size = new System.Drawing.Size(119, 346);
            this.pnlUnits.TabIndex = 37;
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.pnlSubUnits);
            this.grpUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnits.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUnits.Location = new System.Drawing.Point(0, 0);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpUnits.Size = new System.Drawing.Size(116, 346);
            this.grpUnits.TabIndex = 35;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            // 
            // pnlSubUnits
            // 
            this.pnlSubUnits.Controls.Add(this.ucUnits);
            this.pnlSubUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubUnits.Location = new System.Drawing.Point(4, 17);
            this.pnlSubUnits.Name = "pnlSubUnits";
            this.pnlSubUnits.Size = new System.Drawing.Size(108, 326);
            this.pnlSubUnits.TabIndex = 1;
            // 
            // ucUnits
            // 
            this.ucUnits.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUnits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucUnits.Location = new System.Drawing.Point(0, 0);
            this.ucUnits.Name = "ucUnits";
            this.ucUnits.Size = new System.Drawing.Size(108, 326);
            this.ucUnits.TabIndex = 0;
            // 
            // pnlRota
            // 
            this.pnlRota.Controls.Add(this.grpRota);
            this.pnlRota.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRota.Location = new System.Drawing.Point(1, 52);
            this.pnlRota.Name = "pnlRota";
            this.pnlRota.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.pnlRota.Size = new System.Drawing.Size(119, 52);
            this.pnlRota.TabIndex = 36;
            // 
            // grpRota
            // 
            this.grpRota.Controls.Add(this.cmboRota);
            this.grpRota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRota.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRota.Location = new System.Drawing.Point(0, 0);
            this.grpRota.Name = "grpRota";
            this.grpRota.Padding = new System.Windows.Forms.Padding(8, 7, 8, 8);
            this.grpRota.Size = new System.Drawing.Size(116, 50);
            this.grpRota.TabIndex = 35;
            this.grpRota.TabStop = false;
            this.grpRota.Text = "Rota";
            // 
            // cmboRota
            // 
            this.cmboRota.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmboRota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboRota.FormattingEnabled = true;
            this.cmboRota.Location = new System.Drawing.Point(8, 21);
            this.cmboRota.Name = "cmboRota";
            this.cmboRota.Size = new System.Drawing.Size(100, 21);
            this.cmboRota.TabIndex = 11;
            // 
            // pnlHighlight
            // 
            this.pnlHighlight.Controls.Add(this.grpHighlight);
            this.pnlHighlight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHighlight.Location = new System.Drawing.Point(1, 0);
            this.pnlHighlight.Name = "pnlHighlight";
            this.pnlHighlight.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.pnlHighlight.Size = new System.Drawing.Size(119, 52);
            this.pnlHighlight.TabIndex = 38;
            // 
            // grpHighlight
            // 
            this.grpHighlight.Controls.Add(this.cmboHighlight);
            this.grpHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHighlight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHighlight.Location = new System.Drawing.Point(0, 0);
            this.grpHighlight.Name = "grpHighlight";
            this.grpHighlight.Padding = new System.Windows.Forms.Padding(8, 7, 8, 8);
            this.grpHighlight.Size = new System.Drawing.Size(116, 50);
            this.grpHighlight.TabIndex = 35;
            this.grpHighlight.TabStop = false;
            this.grpHighlight.Text = "Highlight By";
            // 
            // cmboHighlight
            // 
            this.cmboHighlight.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmboHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboHighlight.FormattingEnabled = true;
            this.cmboHighlight.Location = new System.Drawing.Point(8, 21);
            this.cmboHighlight.Name = "cmboHighlight";
            this.cmboHighlight.Size = new System.Drawing.Size(100, 21);
            this.cmboHighlight.TabIndex = 11;
            this.cmboHighlight.SelectedValueChanged += new System.EventHandler(this.cmboHighlight_SelectedValueChanged);
            // 
            // pnlShowHide2
            // 
            this.pnlShowHide2.Controls.Add(this.btnShowHide2);
            this.pnlShowHide2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShowHide2.Location = new System.Drawing.Point(0, 0);
            this.pnlShowHide2.Name = "pnlShowHide2";
            this.pnlShowHide2.Size = new System.Drawing.Size(8, 456);
            this.pnlShowHide2.TabIndex = 3;
            // 
            // btnShowHide2
            // 
            this.btnShowHide2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHide2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowHide2.FlatAppearance.BorderSize = 0;
            this.btnShowHide2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnShowHide2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowHide2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHide2.Image = global::Elvis.Properties.Resources.HideButtonSmallVert;
            this.btnShowHide2.Location = new System.Drawing.Point(0, 0);
            this.btnShowHide2.Name = "btnShowHide2";
            this.btnShowHide2.Size = new System.Drawing.Size(8, 456);
            this.btnShowHide2.TabIndex = 0;
            this.btnShowHide2.Tag = "Hide";
            this.btnShowHide2.UseVisualStyleBackColor = true;
            this.btnShowHide2.Click += new System.EventHandler(this.btnShowHide2_Click);
            // 
            // printCharts
            // 
            this.printCharts.DocumentName = "Elvis Trending Form";
            this.printCharts.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCharts_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printCharts;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printCharts;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDateStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDateStatus
            // 
            this.lblDateStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblDateStatus.Name = "lblDateStatus";
            this.lblDateStatus.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDateStatus.Size = new System.Drawing.Size(122, 17);
            this.lblDateStatus.Text = "Date From - Date To";
            this.lblDateStatus.ToolTipText = "The selected date span";
            // 
            // TrendingForm
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(992, 656);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "TrendingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trending";
            this.Load += new System.EventHandler(this.TrendingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrendingForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.pnlGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            this.pnlGradesXHeats.ResumeLayout(false);
            this.grpXHeat.ResumeLayout(false);
            this.grpXHeat.PerformLayout();
            this.grpGrade.ResumeLayout(false);
            this.grpGrade.PerformLayout();
            this.pnlHeats.ResumeLayout(false);
            this.grpHeatRange.ResumeLayout(false);
            this.grpHeatRange.PerformLayout();
            this.pnlDateSelector.ResumeLayout(false);
            this.grpDateSelector.ResumeLayout(false);
            this.grpDateSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.pnlFormat.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.pnlShowHide.ResumeLayout(false);
            this.splitContainerSub.Panel1.ResumeLayout(false);
            this.splitContainerSub.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).EndInit();
            this.splitContainerSub.ResumeLayout(false);
            this.pnlGraphs.ResumeLayout(false);
            this.grpCharts.ResumeLayout(false);
            this.pnlLegend.ResumeLayout(false);
            this.pnlAdditionalFilter.ResumeLayout(false);
            this.pnlUnits.ResumeLayout(false);
            this.grpUnits.ResumeLayout(false);
            this.pnlSubUnits.ResumeLayout(false);
            this.pnlRota.ResumeLayout(false);
            this.grpRota.ResumeLayout(false);
            this.pnlHighlight.ResumeLayout(false);
            this.grpHighlight.ResumeLayout(false);
            this.pnlShowHide2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Panel pnlHeats;
        private System.Windows.Forms.GroupBox grpHeatRange;
        private System.Windows.Forms.ComboBox cmboHeatTo;
        private System.Windows.Forms.ComboBox cmboHeatFrom;
        private System.Windows.Forms.Label lblHeatTo;
        private System.Windows.Forms.Label lblHeatFrom;
        private System.Windows.Forms.Panel pnlDateSelector;
        private System.Windows.Forms.GroupBox grpDateSelector;
        private System.Windows.Forms.RadioButton rbLastShift;
        private System.Windows.Forms.RadioButton rbLastDay;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbFixed;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Panel pnlShowHide;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Panel pnlGroup;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.ComboBox cmboGroup;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.SplitContainer splitContainerSub;
        private System.Windows.Forms.Panel pnlShowHide2;
        private System.Windows.Forms.Button btnShowHide2;
        private System.Windows.Forms.Panel pnlAdditionalFilter;
        private System.Windows.Forms.Panel pnlRota;
        private System.Windows.Forms.GroupBox grpGrade;
        private System.Windows.Forms.Panel pnlUnits;
        private System.Windows.Forms.GroupBox grpCharts;
        private System.Windows.Forms.Panel pnlCharts;
        private System.Windows.Forms.CheckBox chbAllHeats;
        private System.Windows.Forms.GroupBox grpXHeat;
        private System.Windows.Forms.GroupBox grpUnits;
        private System.Windows.Forms.Panel pnlSubUnits;
        private UserControls.UnitsVertical ucUnits;
        private System.Windows.Forms.RadioButton rbCurrentShift;
        private System.Windows.Forms.CheckBox chbAllGrades;
        private System.Windows.Forms.CheckBox chbAllXHeats;
        private Common.ThirdPartyControls.CheckedComboBox ccbGrades;
        private Common.ThirdPartyControls.CheckedComboBox ccbXHeats;
        private System.Drawing.Printing.PrintDocument printCharts;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel pnlGradesXHeats;
        private System.Windows.Forms.GroupBox grpRota;
        private System.Windows.Forms.ComboBox cmboRota;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlHighlight;
        private System.Windows.Forms.GroupBox grpHighlight;
        private System.Windows.Forms.ComboBox cmboHighlight;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGraphs;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDateStatus;
    }
}
