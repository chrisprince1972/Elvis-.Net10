namespace Elvis.Forms
{
    partial class DelayAnalysisReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelayAnalysisReport));
            this.OEEDelayDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oEEDelayData = new Elvis.OEEDelayData();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.pnlButtons2 = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlGroupBy = new System.Windows.Forms.Panel();
            this.grpGroupBy = new System.Windows.Forms.GroupBox();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.pnlUnnamed = new System.Windows.Forms.Panel();
            this.grpUnnamed = new System.Windows.Forms.GroupBox();
            this.rbUnnamedOnly = new System.Windows.Forms.RadioButton();
            this.rbIUnnamedInclude = new System.Windows.Forms.RadioButton();
            this.rbUnnamedExclude = new System.Windows.Forms.RadioButton();
            this.pnlUnits = new System.Windows.Forms.Panel();
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.chbCaster3 = new System.Windows.Forms.CheckBox();
            this.chbCAS1 = new System.Windows.Forms.CheckBox();
            this.chbCAS2 = new System.Windows.Forms.CheckBox();
            this.chbCaster1 = new System.Windows.Forms.CheckBox();
            this.chbCaster2 = new System.Windows.Forms.CheckBox();
            this.chbVessel1 = new System.Windows.Forms.CheckBox();
            this.chbVessel2 = new System.Windows.Forms.CheckBox();
            this.chbRHDegas = new System.Windows.Forms.CheckBox();
            this.chbHMDesulphS = new System.Windows.Forms.CheckBox();
            this.chbRDDegas = new System.Windows.Forms.CheckBox();
            this.chbHMDesulphN = new System.Windows.Forms.CheckBox();
            this.chbHMSouth = new System.Windows.Forms.CheckBox();
            this.chbHMNorth = new System.Windows.Forms.CheckBox();
            this.pnlDateSelector = new System.Windows.Forms.Panel();
            this.grpDateSelector = new System.Windows.Forms.GroupBox();
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
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTibMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tibAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delaysToEnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tibReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tibTimeInProductionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TibReportsViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TibOEEReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OEEDelayDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oEEDelayData)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.grpReport.SuspendLayout();
            this.pnlButtons2.SuspendLayout();
            this.pnlGroupBy.SuspendLayout();
            this.grpGroupBy.SuspendLayout();
            this.pnlUnnamed.SuspendLayout();
            this.grpUnnamed.SuspendLayout();
            this.pnlUnits.SuspendLayout();
            this.grpUnits.SuspendLayout();
            this.pnlDateSelector.SuspendLayout();
            this.grpDateSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.pnlFormat.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TibReportsViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TibOEEReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OEEDelayDataBindingSource
            // 
            this.OEEDelayDataBindingSource.DataSource = this.oEEDelayData;
            this.OEEDelayDataBindingSource.Position = 0;
            // 
            // oEEDelayData
            // 
            this.oEEDelayData.DataSetName = "OEEDelayData";
            this.oEEDelayData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OEEDelayData";
            reportDataSource1.Value = this.OEEDelayDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.DelayAnalysisReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 6);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1004, 562);
            this.reportViewer1.TabIndex = 16;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpReport);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 24);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Size = new System.Drawing.Size(1016, 136);
            this.pnlFilter.TabIndex = 37;
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.pnlButtons2);
            this.grpReport.Controls.Add(this.pnlGroupBy);
            this.grpReport.Controls.Add(this.pnlUnnamed);
            this.grpReport.Controls.Add(this.pnlUnits);
            this.grpReport.Controls.Add(this.pnlDateSelector);
            this.grpReport.Controls.Add(this.pnlFormat);
            this.grpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpReport.Location = new System.Drawing.Point(6, 6);
            this.grpReport.Name = "grpReport";
            this.grpReport.Padding = new System.Windows.Forms.Padding(6);
            this.grpReport.Size = new System.Drawing.Size(1004, 124);
            this.grpReport.TabIndex = 39;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report Generator";
            // 
            // pnlButtons2
            // 
            this.pnlButtons2.Controls.Add(this.btnGenerate);
            this.pnlButtons2.Controls.Add(this.btnReset);
            this.pnlButtons2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons2.Location = new System.Drawing.Point(852, 72);
            this.pnlButtons2.Name = "pnlButtons2";
            this.pnlButtons2.Size = new System.Drawing.Size(146, 46);
            this.pnlButtons2.TabIndex = 63;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGenerate.Location = new System.Drawing.Point(0, 23);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(146, 23);
            this.btnGenerate.TabIndex = 60;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(0, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(146, 23);
            this.btnReset.TabIndex = 59;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlGroupBy
            // 
            this.pnlGroupBy.Controls.Add(this.grpGroupBy);
            this.pnlGroupBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroupBy.Location = new System.Drawing.Point(852, 19);
            this.pnlGroupBy.Name = "pnlGroupBy";
            this.pnlGroupBy.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlGroupBy.Size = new System.Drawing.Size(146, 53);
            this.pnlGroupBy.TabIndex = 62;
            // 
            // grpGroupBy
            // 
            this.grpGroupBy.Controls.Add(this.cmbGroupBy);
            this.grpGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroupBy.Location = new System.Drawing.Point(0, 0);
            this.grpGroupBy.Name = "grpGroupBy";
            this.grpGroupBy.Padding = new System.Windows.Forms.Padding(8);
            this.grpGroupBy.Size = new System.Drawing.Size(146, 50);
            this.grpGroupBy.TabIndex = 56;
            this.grpGroupBy.TabStop = false;
            this.grpGroupBy.Text = "Group By";
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Items.AddRange(new object[] {
            "Area",
            "Class",
            "Discipline",
            "Category",
            "OEE Loss Category",
            "Loss Type",
            "Owner",
            "Report Level 1",
            "Report Level 2"});
            this.cmbGroupBy.Location = new System.Drawing.Point(8, 21);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(130, 21);
            this.cmbGroupBy.TabIndex = 33;
            // 
            // pnlUnnamed
            // 
            this.pnlUnnamed.Controls.Add(this.grpUnnamed);
            this.pnlUnnamed.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnnamed.Location = new System.Drawing.Point(755, 19);
            this.pnlUnnamed.Name = "pnlUnnamed";
            this.pnlUnnamed.Size = new System.Drawing.Size(97, 99);
            this.pnlUnnamed.TabIndex = 61;
            // 
            // grpUnnamed
            // 
            this.grpUnnamed.Controls.Add(this.rbUnnamedOnly);
            this.grpUnnamed.Controls.Add(this.rbIUnnamedInclude);
            this.grpUnnamed.Controls.Add(this.rbUnnamedExclude);
            this.grpUnnamed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnnamed.Location = new System.Drawing.Point(0, 0);
            this.grpUnnamed.Name = "grpUnnamed";
            this.grpUnnamed.Padding = new System.Windows.Forms.Padding(10);
            this.grpUnnamed.Size = new System.Drawing.Size(97, 99);
            this.grpUnnamed.TabIndex = 0;
            this.grpUnnamed.TabStop = false;
            this.grpUnnamed.Text = "Unnamed";
            // 
            // rbUnnamedOnly
            // 
            this.rbUnnamedOnly.AutoSize = true;
            this.rbUnnamedOnly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbUnnamedOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnnamedOnly.Location = new System.Drawing.Point(10, 67);
            this.rbUnnamedOnly.Name = "rbUnnamedOnly";
            this.rbUnnamedOnly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbUnnamedOnly.Size = new System.Drawing.Size(77, 22);
            this.rbUnnamedOnly.TabIndex = 2;
            this.rbUnnamedOnly.TabStop = true;
            this.rbUnnamedOnly.Text = "Only";
            this.rbUnnamedOnly.UseVisualStyleBackColor = true;
            // 
            // rbIUnnamedInclude
            // 
            this.rbIUnnamedInclude.AutoSize = true;
            this.rbIUnnamedInclude.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbIUnnamedInclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIUnnamedInclude.Location = new System.Drawing.Point(10, 45);
            this.rbIUnnamedInclude.Name = "rbIUnnamedInclude";
            this.rbIUnnamedInclude.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbIUnnamedInclude.Size = new System.Drawing.Size(77, 22);
            this.rbIUnnamedInclude.TabIndex = 1;
            this.rbIUnnamedInclude.TabStop = true;
            this.rbIUnnamedInclude.Text = "Include";
            this.rbIUnnamedInclude.UseVisualStyleBackColor = true;
            // 
            // rbUnnamedExclude
            // 
            this.rbUnnamedExclude.AutoSize = true;
            this.rbUnnamedExclude.Checked = true;
            this.rbUnnamedExclude.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbUnnamedExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnnamedExclude.Location = new System.Drawing.Point(10, 23);
            this.rbUnnamedExclude.Name = "rbUnnamedExclude";
            this.rbUnnamedExclude.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbUnnamedExclude.Size = new System.Drawing.Size(77, 22);
            this.rbUnnamedExclude.TabIndex = 0;
            this.rbUnnamedExclude.TabStop = true;
            this.rbUnnamedExclude.Text = "Exclude";
            this.rbUnnamedExclude.UseVisualStyleBackColor = true;
            // 
            // pnlUnits
            // 
            this.pnlUnits.Controls.Add(this.grpUnits);
            this.pnlUnits.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnits.Location = new System.Drawing.Point(392, 19);
            this.pnlUnits.Name = "pnlUnits";
            this.pnlUnits.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlUnits.Size = new System.Drawing.Size(363, 99);
            this.pnlUnits.TabIndex = 37;
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.chbCaster3);
            this.grpUnits.Controls.Add(this.chbCAS1);
            this.grpUnits.Controls.Add(this.chbCAS2);
            this.grpUnits.Controls.Add(this.chbCaster1);
            this.grpUnits.Controls.Add(this.chbCaster2);
            this.grpUnits.Controls.Add(this.chbVessel1);
            this.grpUnits.Controls.Add(this.chbVessel2);
            this.grpUnits.Controls.Add(this.chbRHDegas);
            this.grpUnits.Controls.Add(this.chbHMDesulphS);
            this.grpUnits.Controls.Add(this.chbRDDegas);
            this.grpUnits.Controls.Add(this.chbHMDesulphN);
            this.grpUnits.Controls.Add(this.chbHMSouth);
            this.grpUnits.Controls.Add(this.chbHMNorth);
            this.grpUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpUnits.Location = new System.Drawing.Point(0, 0);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpUnits.Size = new System.Drawing.Size(357, 99);
            this.grpUnits.TabIndex = 24;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            // 
            // chbCaster3
            // 
            this.chbCaster3.AutoSize = true;
            this.chbCaster3.Checked = true;
            this.chbCaster3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCaster3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCaster3.Location = new System.Drawing.Point(285, 57);
            this.chbCaster3.Name = "chbCaster3";
            this.chbCaster3.Size = new System.Drawing.Size(65, 17);
            this.chbCaster3.TabIndex = 30;
            this.chbCaster3.Tag = "13";
            this.chbCaster3.Text = "Caster 3";
            this.chbCaster3.UseVisualStyleBackColor = true;
            // 
            // chbCAS1
            // 
            this.chbCAS1.AutoSize = true;
            this.chbCAS1.Checked = true;
            this.chbCAS1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCAS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCAS1.Location = new System.Drawing.Point(187, 57);
            this.chbCAS1.Name = "chbCAS1";
            this.chbCAS1.Size = new System.Drawing.Size(56, 17);
            this.chbCAS1.TabIndex = 29;
            this.chbCAS1.Tag = "9";
            this.chbCAS1.Text = "CAS 1";
            this.chbCAS1.UseVisualStyleBackColor = true;
            // 
            // chbCAS2
            // 
            this.chbCAS2.AutoSize = true;
            this.chbCAS2.Checked = true;
            this.chbCAS2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCAS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCAS2.Location = new System.Drawing.Point(187, 75);
            this.chbCAS2.Name = "chbCAS2";
            this.chbCAS2.Size = new System.Drawing.Size(56, 17);
            this.chbCAS2.TabIndex = 28;
            this.chbCAS2.Tag = "10";
            this.chbCAS2.Text = "CAS 2";
            this.chbCAS2.UseVisualStyleBackColor = true;
            // 
            // chbCaster1
            // 
            this.chbCaster1.AutoSize = true;
            this.chbCaster1.Checked = true;
            this.chbCaster1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCaster1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCaster1.Location = new System.Drawing.Point(285, 21);
            this.chbCaster1.Name = "chbCaster1";
            this.chbCaster1.Size = new System.Drawing.Size(65, 17);
            this.chbCaster1.TabIndex = 27;
            this.chbCaster1.Tag = "11";
            this.chbCaster1.Text = "Caster 1";
            this.chbCaster1.UseVisualStyleBackColor = true;
            // 
            // chbCaster2
            // 
            this.chbCaster2.AutoSize = true;
            this.chbCaster2.Checked = true;
            this.chbCaster2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCaster2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCaster2.Location = new System.Drawing.Point(285, 39);
            this.chbCaster2.Name = "chbCaster2";
            this.chbCaster2.Size = new System.Drawing.Size(65, 17);
            this.chbCaster2.TabIndex = 26;
            this.chbCaster2.Tag = "12";
            this.chbCaster2.Text = "Caster 2";
            this.chbCaster2.UseVisualStyleBackColor = true;
            // 
            // chbVessel1
            // 
            this.chbVessel1.AutoSize = true;
            this.chbVessel1.Checked = true;
            this.chbVessel1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVessel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbVessel1.Location = new System.Drawing.Point(113, 21);
            this.chbVessel1.Name = "chbVessel1";
            this.chbVessel1.Size = new System.Drawing.Size(66, 17);
            this.chbVessel1.TabIndex = 25;
            this.chbVessel1.Tag = "5";
            this.chbVessel1.Text = "Vessel 1";
            this.chbVessel1.UseVisualStyleBackColor = true;
            // 
            // chbVessel2
            // 
            this.chbVessel2.AutoSize = true;
            this.chbVessel2.Checked = true;
            this.chbVessel2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVessel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbVessel2.Location = new System.Drawing.Point(113, 39);
            this.chbVessel2.Name = "chbVessel2";
            this.chbVessel2.Size = new System.Drawing.Size(66, 17);
            this.chbVessel2.TabIndex = 24;
            this.chbVessel2.Tag = "6";
            this.chbVessel2.Text = "Vessel 2";
            this.chbVessel2.UseVisualStyleBackColor = true;
            // 
            // chbRHDegas
            // 
            this.chbRHDegas.AutoSize = true;
            this.chbRHDegas.Checked = true;
            this.chbRHDegas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRHDegas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRHDegas.Location = new System.Drawing.Point(187, 21);
            this.chbRHDegas.Name = "chbRHDegas";
            this.chbRHDegas.Size = new System.Drawing.Size(90, 17);
            this.chbRHDegas.TabIndex = 23;
            this.chbRHDegas.Tag = "7";
            this.chbRHDegas.Text = "RH Degasser";
            this.chbRHDegas.UseVisualStyleBackColor = true;
            // 
            // chbHMDesulphS
            // 
            this.chbHMDesulphS.AutoSize = true;
            this.chbHMDesulphS.Checked = true;
            this.chbHMDesulphS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMDesulphS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMDesulphS.Location = new System.Drawing.Point(10, 75);
            this.chbHMDesulphS.Name = "chbHMDesulphS";
            this.chbHMDesulphS.Size = new System.Drawing.Size(95, 17);
            this.chbHMDesulphS.TabIndex = 22;
            this.chbHMDesulphS.Tag = "4";
            this.chbHMDesulphS.Text = "HM Desulph S";
            this.chbHMDesulphS.UseVisualStyleBackColor = true;
            // 
            // chbRDDegas
            // 
            this.chbRDDegas.AutoSize = true;
            this.chbRDDegas.Checked = true;
            this.chbRDDegas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRDDegas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRDDegas.Location = new System.Drawing.Point(187, 39);
            this.chbRDDegas.Name = "chbRDDegas";
            this.chbRDDegas.Size = new System.Drawing.Size(90, 17);
            this.chbRDDegas.TabIndex = 20;
            this.chbRDDegas.Tag = "8";
            this.chbRDDegas.Text = "RD Degasser";
            this.chbRDDegas.UseVisualStyleBackColor = true;
            // 
            // chbHMDesulphN
            // 
            this.chbHMDesulphN.AutoSize = true;
            this.chbHMDesulphN.Checked = true;
            this.chbHMDesulphN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMDesulphN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMDesulphN.Location = new System.Drawing.Point(10, 57);
            this.chbHMDesulphN.Name = "chbHMDesulphN";
            this.chbHMDesulphN.Size = new System.Drawing.Size(96, 17);
            this.chbHMDesulphN.TabIndex = 19;
            this.chbHMDesulphN.Tag = "3";
            this.chbHMDesulphN.Text = "HM Desulph N";
            this.chbHMDesulphN.UseVisualStyleBackColor = true;
            // 
            // chbHMSouth
            // 
            this.chbHMSouth.AutoSize = true;
            this.chbHMSouth.Checked = true;
            this.chbHMSouth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMSouth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMSouth.Location = new System.Drawing.Point(10, 39);
            this.chbHMSouth.Name = "chbHMSouth";
            this.chbHMSouth.Size = new System.Drawing.Size(74, 17);
            this.chbHMSouth.TabIndex = 18;
            this.chbHMSouth.Tag = "2";
            this.chbHMSouth.Text = "HM South";
            this.chbHMSouth.UseVisualStyleBackColor = true;
            // 
            // chbHMNorth
            // 
            this.chbHMNorth.AutoSize = true;
            this.chbHMNorth.Checked = true;
            this.chbHMNorth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMNorth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMNorth.Location = new System.Drawing.Point(10, 21);
            this.chbHMNorth.Name = "chbHMNorth";
            this.chbHMNorth.Size = new System.Drawing.Size(72, 17);
            this.chbHMNorth.TabIndex = 17;
            this.chbHMNorth.Tag = "1";
            this.chbHMNorth.Text = "HM North";
            this.chbHMNorth.UseVisualStyleBackColor = true;
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.grpDateSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateSelector.Location = new System.Drawing.Point(105, 19);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(287, 99);
            this.pnlDateSelector.TabIndex = 60;
            // 
            // grpDateSelector
            // 
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
            this.grpDateSelector.Size = new System.Drawing.Size(281, 99);
            this.grpDateSelector.TabIndex = 34;
            this.grpDateSelector.TabStop = false;
            this.grpDateSelector.Text = "Date Selector";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTo.Location = new System.Drawing.Point(148, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To";
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
            this.numYear.TabIndex = 31;
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
            this.dpTo.Location = new System.Drawing.Point(174, 26);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(93, 20);
            this.dpTo.TabIndex = 11;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Enabled = false;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblYear.Location = new System.Drawing.Point(179, 65);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 30;
            this.lblYear.Text = "Year";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Enabled = false;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFrom.Location = new System.Drawing.Point(13, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Enabled = false;
            this.lblWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblWeek.Location = new System.Drawing.Point(93, 65);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 29;
            this.lblWeek.Text = "Week";
            // 
            // dpFrom
            // 
            this.dpFrom.Enabled = false;
            this.dpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(49, 26);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(93, 20);
            this.dpFrom.TabIndex = 1;
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
            this.numWeek.TabIndex = 28;
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
            this.numDay.TabIndex = 18;
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
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDay.Location = new System.Drawing.Point(17, 65);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 19;
            this.lblDay.Text = "Day";
            // 
            // pnlFormat
            // 
            this.pnlFormat.Controls.Add(this.grpFormat);
            this.pnlFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormat.Location = new System.Drawing.Point(6, 19);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlFormat.Size = new System.Drawing.Size(99, 99);
            this.pnlFormat.TabIndex = 59;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rbWeekly);
            this.grpFormat.Controls.Add(this.rbDaily);
            this.grpFormat.Controls.Add(this.rbDate);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFormat.Location = new System.Drawing.Point(0, 0);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Padding = new System.Windows.Forms.Padding(10);
            this.grpFormat.Size = new System.Drawing.Size(93, 99);
            this.grpFormat.TabIndex = 33;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Date Format";
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWeekly.Location = new System.Drawing.Point(10, 67);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbWeekly.Size = new System.Drawing.Size(73, 22);
            this.rbWeekly.TabIndex = 17;
            this.rbWeekly.Text = "&Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDaily.Location = new System.Drawing.Point(10, 45);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbDaily.Size = new System.Drawing.Size(73, 22);
            this.rbDaily.TabIndex = 16;
            this.rbDaily.Text = "&Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Checked = true;
            this.rbDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDate.Location = new System.Drawing.Point(10, 23);
            this.rbDate.Name = "rbDate";
            this.rbDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbDate.Size = new System.Drawing.Size(73, 22);
            this.rbDate.TabIndex = 27;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "&Pick Date";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.reportViewer1);
            this.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReport.Location = new System.Drawing.Point(0, 160);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Padding = new System.Windows.Forms.Padding(6);
            this.pnlReport.Size = new System.Drawing.Size(1016, 574);
            this.pnlReport.TabIndex = 38;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 39;
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
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTibMain});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // toolStripMenuItemTibMain
            // 
            this.toolStripMenuItemTibMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tibAnalysisToolStripMenuItem,
            this.delaysToEnterToolStripMenuItem,
            this.tibReportToolStripMenuItem,
            this.tibTimeInProductionReportToolStripMenuItem});
            this.toolStripMenuItemTibMain.Name = "toolStripMenuItemTibMain";
            this.toolStripMenuItemTibMain.Size = new System.Drawing.Size(91, 22);
            this.toolStripMenuItemTibMain.Text = "&Tib";
            // 
            // tibAnalysisToolStripMenuItem
            // 
            this.tibAnalysisToolStripMenuItem.Name = "tibAnalysisToolStripMenuItem";
            this.tibAnalysisToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tibAnalysisToolStripMenuItem.Text = "&Analysis";
            this.tibAnalysisToolStripMenuItem.Visible = false;
            this.tibAnalysisToolStripMenuItem.Click += new System.EventHandler(this.tibAnalysisToolStripMenuItem_Click);
            // 
            // delaysToEnterToolStripMenuItem
            // 
            this.delaysToEnterToolStripMenuItem.Name = "delaysToEnterToolStripMenuItem";
            this.delaysToEnterToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.delaysToEnterToolStripMenuItem.Text = "&Delays To Enter";
            this.delaysToEnterToolStripMenuItem.Click += new System.EventHandler(this.delaysToEnterToolStripMenuItem_Click);
            // 
            // tibReportToolStripMenuItem
            // 
            this.tibReportToolStripMenuItem.Name = "tibReportToolStripMenuItem";
            this.tibReportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tibReportToolStripMenuItem.Text = "&Reports";
            this.tibReportToolStripMenuItem.Click += new System.EventHandler(this.tibReportToolStripMenuItem_Click);
            // 
            // tibTimeInProductionReportToolStripMenuItem
            // 
            this.tibTimeInProductionReportToolStripMenuItem.Name = "tibTimeInProductionReportToolStripMenuItem";
            this.tibTimeInProductionReportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tibTimeInProductionReportToolStripMenuItem.Text = "&Time In Production";
            this.tibTimeInProductionReportToolStripMenuItem.Click += new System.EventHandler(this.tibTimeInProductionReportToolStripMenuItem_Click);
            // 
            // TibReportsViewBindingSource
            // 
            this.TibReportsViewBindingSource.DataSource = this.oEEDelayData;
            this.TibReportsViewBindingSource.Position = 0;
            // 
            // TibOEEReportBindingSource
            // 
            this.TibOEEReportBindingSource.DataMember = "TibOEEReport";
            this.TibOEEReportBindingSource.DataSource = this.oEEDelayData;
            // 
            // DelayAnalysisReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DelayAnalysisReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delay Analysis Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DelayAnalysisReport_FormClosing);
            this.Load += new System.EventHandler(this.DelayAnalysisReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelayAnalysisReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.OEEDelayDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oEEDelayData)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.grpReport.ResumeLayout(false);
            this.pnlButtons2.ResumeLayout(false);
            this.pnlGroupBy.ResumeLayout(false);
            this.grpGroupBy.ResumeLayout(false);
            this.pnlUnnamed.ResumeLayout(false);
            this.grpUnnamed.ResumeLayout(false);
            this.grpUnnamed.PerformLayout();
            this.pnlUnits.ResumeLayout(false);
            this.grpUnits.ResumeLayout(false);
            this.grpUnits.PerformLayout();
            this.pnlDateSelector.ResumeLayout(false);
            this.grpDateSelector.ResumeLayout(false);
            this.grpDateSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.pnlFormat.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.pnlReport.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TibReportsViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TibOEEReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TibReportsViewBindingSource;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Panel pnlUnits;
        private System.Windows.Forms.GroupBox grpUnits;
        private System.Windows.Forms.CheckBox chbHMDesulphS;
        private System.Windows.Forms.CheckBox chbRDDegas;
        private System.Windows.Forms.CheckBox chbHMDesulphN;
        private System.Windows.Forms.CheckBox chbHMSouth;
        private System.Windows.Forms.CheckBox chbHMNorth;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.CheckBox chbRHDegas;
        private System.Windows.Forms.CheckBox chbVessel1;
        private System.Windows.Forms.CheckBox chbVessel2;
        private System.Windows.Forms.CheckBox chbCAS1;
        private System.Windows.Forms.CheckBox chbCAS2;
        private System.Windows.Forms.CheckBox chbCaster1;
        private System.Windows.Forms.CheckBox chbCaster2;
        private System.Windows.Forms.CheckBox chbCaster3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTibMain;
        private System.Windows.Forms.ToolStripMenuItem delaysToEnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tibAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tibReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tibTimeInProductionReportToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Panel pnlDateSelector;
        private System.Windows.Forms.GroupBox grpDateSelector;
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
        private System.Windows.Forms.Panel pnlUnnamed;
        private OEEDelayData oEEDelayData;
        private System.Windows.Forms.BindingSource OEEDelayDataBindingSource;
        private System.Windows.Forms.BindingSource TibOEEReportBindingSource;
        private System.Windows.Forms.Panel pnlGroupBy;
        private System.Windows.Forms.GroupBox grpGroupBy;
        private System.Windows.Forms.Panel pnlButtons2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.GroupBox grpUnnamed;
        private System.Windows.Forms.RadioButton rbUnnamedExclude;
        private System.Windows.Forms.RadioButton rbUnnamedOnly;
        private System.Windows.Forms.RadioButton rbIUnnamedInclude;
    }
}