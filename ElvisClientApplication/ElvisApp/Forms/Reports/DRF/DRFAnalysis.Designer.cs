namespace Elvis.Forms.Reports.DRF
{
    partial class DRFAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRFAnalysis));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReportGen = new System.Windows.Forms.Panel();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.pnlLocation = new System.Windows.Forms.Panel();
            this.grpLocationSelect = new System.Windows.Forms.GroupBox();
            this.cmboLocation = new System.Windows.Forms.ComboBox();
            this.pnlReportSelector = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbxReport = new System.Windows.Forms.GroupBox();
            this.cmboReport = new System.Windows.Forms.ComboBox();
            this.pnlAreaSelector = new System.Windows.Forms.Panel();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoConcast = new System.Windows.Forms.RadioButton();
            this.rdoSteelmaking = new System.Windows.Forms.RadioButton();
            this.pnlDateSelector = new System.Windows.Forms.Panel();
            this.grpDateSelector = new System.Windows.Forms.GroupBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.lblWeek = new System.Windows.Forms.Label();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlFormat = new System.Windows.Forms.Panel();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnlReportGen.SuspendLayout();
            this.grpReport.SuspendLayout();
            this.pnlLocation.SuspendLayout();
            this.grpLocationSelect.SuspendLayout();
            this.pnlReportSelector.SuspendLayout();
            this.gbxReport.SuspendLayout();
            this.pnlAreaSelector.SuspendLayout();
            this.grpArea.SuspendLayout();
            this.pnlDateSelector.SuspendLayout();
            this.grpDateSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.pnlFormat.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnlReportGen
            // 
            this.pnlReportGen.Controls.Add(this.grpReport);
            this.pnlReportGen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportGen.Location = new System.Drawing.Point(0, 24);
            this.pnlReportGen.Name = "pnlReportGen";
            this.pnlReportGen.Padding = new System.Windows.Forms.Padding(6);
            this.pnlReportGen.Size = new System.Drawing.Size(1016, 136);
            this.pnlReportGen.TabIndex = 1;
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.pnlLocation);
            this.grpReport.Controls.Add(this.pnlReportSelector);
            this.grpReport.Controls.Add(this.pnlAreaSelector);
            this.grpReport.Controls.Add(this.pnlDateSelector);
            this.grpReport.Controls.Add(this.pnlFormat);
            this.grpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReport.Location = new System.Drawing.Point(6, 6);
            this.grpReport.Name = "grpReport";
            this.grpReport.Padding = new System.Windows.Forms.Padding(6);
            this.grpReport.Size = new System.Drawing.Size(1004, 124);
            this.grpReport.TabIndex = 0;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report Generator";
            // 
            // pnlLocation
            // 
            this.pnlLocation.Controls.Add(this.grpLocationSelect);
            this.pnlLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLocation.Location = new System.Drawing.Point(723, 20);
            this.pnlLocation.Name = "pnlLocation";
            this.pnlLocation.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlLocation.Size = new System.Drawing.Size(197, 98);
            this.pnlLocation.TabIndex = 4;
            this.pnlLocation.Visible = false;
            // 
            // grpLocationSelect
            // 
            this.grpLocationSelect.Controls.Add(this.cmboLocation);
            this.grpLocationSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLocationSelect.Location = new System.Drawing.Point(0, 0);
            this.grpLocationSelect.Name = "grpLocationSelect";
            this.grpLocationSelect.Padding = new System.Windows.Forms.Padding(6);
            this.grpLocationSelect.Size = new System.Drawing.Size(191, 46);
            this.grpLocationSelect.TabIndex = 0;
            this.grpLocationSelect.TabStop = false;
            this.grpLocationSelect.Text = "Select Location";
            // 
            // cmboLocation
            // 
            this.cmboLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboLocation.FormattingEnabled = true;
            this.cmboLocation.Location = new System.Drawing.Point(6, 20);
            this.cmboLocation.Name = "cmboLocation";
            this.cmboLocation.Size = new System.Drawing.Size(179, 21);
            this.cmboLocation.TabIndex = 0;
            // 
            // pnlReportSelector
            // 
            this.pnlReportSelector.Controls.Add(this.btnReset);
            this.pnlReportSelector.Controls.Add(this.btnGenerate);
            this.pnlReportSelector.Controls.Add(this.gbxReport);
            this.pnlReportSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlReportSelector.Location = new System.Drawing.Point(503, 20);
            this.pnlReportSelector.Name = "pnlReportSelector";
            this.pnlReportSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlReportSelector.Size = new System.Drawing.Size(220, 98);
            this.pnlReportSelector.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(0, 52);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(214, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGenerate.Location = new System.Drawing.Point(0, 75);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(214, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gbxReport
            // 
            this.gbxReport.Controls.Add(this.cmboReport);
            this.gbxReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxReport.Location = new System.Drawing.Point(0, 0);
            this.gbxReport.Name = "gbxReport";
            this.gbxReport.Padding = new System.Windows.Forms.Padding(6);
            this.gbxReport.Size = new System.Drawing.Size(214, 46);
            this.gbxReport.TabIndex = 0;
            this.gbxReport.TabStop = false;
            this.gbxReport.Text = "Analysis Report";
            // 
            // cmboReport
            // 
            this.cmboReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboReport.FormattingEnabled = true;
            this.cmboReport.Items.AddRange(new object[] {
            "Area Chart",
            "Function Chart",
            "Delay Type Frequency Chart",
            "Delay Type Total Time Chart",
            "Delay Frequency By Location Chart",
            "Delay Time By Location Chart",
            "Open Reports By Owner",
            "Open Reports By Rota",
            "Closed Reports By Owner",
            "Close Out Rate"});
            this.cmboReport.Location = new System.Drawing.Point(6, 20);
            this.cmboReport.Name = "cmboReport";
            this.cmboReport.Size = new System.Drawing.Size(202, 21);
            this.cmboReport.TabIndex = 0;
            this.cmboReport.SelectedIndexChanged += new System.EventHandler(this.cmboReport_SelectedIndexChanged);
            // 
            // pnlAreaSelector
            // 
            this.pnlAreaSelector.Controls.Add(this.grpArea);
            this.pnlAreaSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAreaSelector.Location = new System.Drawing.Point(391, 20);
            this.pnlAreaSelector.Name = "pnlAreaSelector";
            this.pnlAreaSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlAreaSelector.Size = new System.Drawing.Size(112, 98);
            this.pnlAreaSelector.TabIndex = 2;
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.rdoAll);
            this.grpArea.Controls.Add(this.rdoConcast);
            this.grpArea.Controls.Add(this.rdoSteelmaking);
            this.grpArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpArea.Location = new System.Drawing.Point(0, 0);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(106, 98);
            this.grpArea.TabIndex = 0;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "Area";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.Location = new System.Drawing.Point(10, 67);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rdoAll.Size = new System.Drawing.Size(36, 22);
            this.rdoAll.TabIndex = 2;
            this.rdoAll.Tag = "All";
            this.rdoAll.Text = "&All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoArea_CheckedChanged);
            // 
            // rdoConcast
            // 
            this.rdoConcast.AutoSize = true;
            this.rdoConcast.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoConcast.Location = new System.Drawing.Point(10, 45);
            this.rdoConcast.Name = "rdoConcast";
            this.rdoConcast.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rdoConcast.Size = new System.Drawing.Size(64, 22);
            this.rdoConcast.TabIndex = 1;
            this.rdoConcast.Tag = "Concast";
            this.rdoConcast.Text = "&Concast";
            this.rdoConcast.UseVisualStyleBackColor = true;
            this.rdoConcast.CheckedChanged += new System.EventHandler(this.rdoArea_CheckedChanged);
            // 
            // rdoSteelmaking
            // 
            this.rdoSteelmaking.AutoSize = true;
            this.rdoSteelmaking.Checked = true;
            this.rdoSteelmaking.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSteelmaking.Location = new System.Drawing.Point(10, 23);
            this.rdoSteelmaking.Name = "rdoSteelmaking";
            this.rdoSteelmaking.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rdoSteelmaking.Size = new System.Drawing.Size(82, 22);
            this.rdoSteelmaking.TabIndex = 0;
            this.rdoSteelmaking.TabStop = true;
            this.rdoSteelmaking.Tag = "Steelmaking";
            this.rdoSteelmaking.Text = "&Steelmaking";
            this.rdoSteelmaking.UseVisualStyleBackColor = true;
            this.rdoSteelmaking.CheckedChanged += new System.EventHandler(this.rdoArea_CheckedChanged);
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.grpDateSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateSelector.Location = new System.Drawing.Point(104, 20);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(287, 98);
            this.pnlDateSelector.TabIndex = 1;
            // 
            // grpDateSelector
            // 
            this.grpDateSelector.Controls.Add(this.numYear);
            this.grpDateSelector.Controls.Add(this.lblYear);
            this.grpDateSelector.Controls.Add(this.numWeek);
            this.grpDateSelector.Controls.Add(this.lblWeek);
            this.grpDateSelector.Controls.Add(this.numDay);
            this.grpDateSelector.Controls.Add(this.lblDay);
            this.grpDateSelector.Controls.Add(this.dpTo);
            this.grpDateSelector.Controls.Add(this.lblTo);
            this.grpDateSelector.Controls.Add(this.dpFrom);
            this.grpDateSelector.Controls.Add(this.lblFrom);
            this.grpDateSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDateSelector.Location = new System.Drawing.Point(0, 0);
            this.grpDateSelector.Name = "grpDateSelector";
            this.grpDateSelector.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.grpDateSelector.Size = new System.Drawing.Size(281, 98);
            this.grpDateSelector.TabIndex = 0;
            this.grpDateSelector.TabStop = false;
            this.grpDateSelector.Text = "Date Selector";
            // 
            // numYear
            // 
            this.numYear.Enabled = false;
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(214, 61);
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
            this.numYear.TabIndex = 3;
            this.numYear.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Enabled = false;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(179, 65);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 8;
            this.lblYear.Text = "Year";
            // 
            // numWeek
            // 
            this.numWeek.Enabled = false;
            this.numWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeek.Location = new System.Drawing.Point(135, 61);
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
            this.numWeek.TabIndex = 7;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Enabled = false;
            this.lblWeek.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(95, 65);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(34, 13);
            this.lblWeek.TabIndex = 6;
            this.lblWeek.Text = "Week";
            // 
            // numDay
            // 
            this.numDay.Enabled = false;
            this.numDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDay.Location = new System.Drawing.Point(49, 61);
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
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Enabled = false;
            this.lblDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(17, 65);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 4;
            this.lblDay.Text = "Day";
            // 
            // dpTo
            // 
            this.dpTo.Enabled = false;
            this.dpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(174, 26);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(93, 20);
            this.dpTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(149, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // dpFrom
            // 
            this.dpFrom.Enabled = false;
            this.dpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(49, 26);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(93, 20);
            this.dpFrom.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Enabled = false;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(12, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "From";
            // 
            // pnlFormat
            // 
            this.pnlFormat.Controls.Add(this.grpFormat);
            this.pnlFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormat.Location = new System.Drawing.Point(6, 20);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlFormat.Size = new System.Drawing.Size(98, 98);
            this.pnlFormat.TabIndex = 0;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rbWeekly);
            this.grpFormat.Controls.Add(this.rbDaily);
            this.grpFormat.Controls.Add(this.rbDate);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFormat.Location = new System.Drawing.Point(0, 0);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Padding = new System.Windows.Forms.Padding(10, 10, 6, 10);
            this.grpFormat.Size = new System.Drawing.Size(92, 98);
            this.grpFormat.TabIndex = 0;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Date Format";
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWeekly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWeekly.Location = new System.Drawing.Point(10, 68);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbWeekly.Size = new System.Drawing.Size(76, 22);
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
            this.rbDaily.Location = new System.Drawing.Point(10, 46);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbDaily.Size = new System.Drawing.Size(76, 22);
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
            this.rbDate.Location = new System.Drawing.Point(10, 24);
            this.rbDate.Name = "rbDate";
            this.rbDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbDate.Size = new System.Drawing.Size(76, 22);
            this.rbDate.TabIndex = 0;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "&Pick Date";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // pnlReport
            // 
            this.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReport.Location = new System.Drawing.Point(0, 160);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Padding = new System.Windows.Forms.Padding(6);
            this.pnlReport.Size = new System.Drawing.Size(1016, 574);
            this.pnlReport.TabIndex = 0;
            // 
            // DRFAnalysis
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.pnlReportGen);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DRFAnalysis";
            this.Text = "DRF Analysis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DRFAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.DRFAnalysis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DRFAnalysis_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlReportGen.ResumeLayout(false);
            this.grpReport.ResumeLayout(false);
            this.pnlLocation.ResumeLayout(false);
            this.grpLocationSelect.ResumeLayout(false);
            this.pnlReportSelector.ResumeLayout(false);
            this.gbxReport.ResumeLayout(false);
            this.pnlAreaSelector.ResumeLayout(false);
            this.grpArea.ResumeLayout(false);
            this.grpArea.PerformLayout();
            this.pnlDateSelector.ResumeLayout(false);
            this.grpDateSelector.ResumeLayout(false);
            this.grpDateSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.pnlFormat.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnlReportGen;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Panel pnlDateSelector;
        private System.Windows.Forms.GroupBox grpDateSelector;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlAreaSelector;
        private System.Windows.Forms.GroupBox grpArea;
        private System.Windows.Forms.RadioButton rdoSteelmaking;
        private System.Windows.Forms.Panel pnlReportSelector;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoConcast;
        private System.Windows.Forms.GroupBox gbxReport;
        private System.Windows.Forms.ComboBox cmboReport;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Panel pnlLocation;
        private System.Windows.Forms.GroupBox grpLocationSelect;
        private System.Windows.Forms.ComboBox cmboLocation;
    }
}
