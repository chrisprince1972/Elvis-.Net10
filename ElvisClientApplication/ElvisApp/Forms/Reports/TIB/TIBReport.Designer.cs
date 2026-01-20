namespace Elvis.Forms
{
    partial class TIBReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIBReport));
            this.TIBDelayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTo = new System.Windows.Forms.Label();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.pnlPlantArea = new System.Windows.Forms.Panel();
            this.grpPlantAreas = new System.Windows.Forms.GroupBox();
            this.chbCranes = new System.Windows.Forms.CheckBox();
            this.chbCastersArea = new System.Windows.Forms.CheckBox();
            this.chbSecSteelArea = new System.Windows.Forms.CheckBox();
            this.chbPlan = new System.Windows.Forms.CheckBox();
            this.chbVesselsArea = new System.Windows.Forms.CheckBox();
            this.chbHMScrap = new System.Windows.Forms.CheckBox();
            this.chbMultiserv = new System.Windows.Forms.CheckBox();
            this.chbExternal = new System.Windows.Forms.CheckBox();
            this.pnlUnits = new System.Windows.Forms.Panel();
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.pnlUnitList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbUnitGroups = new System.Windows.Forms.RadioButton();
            this.rbUnits = new System.Windows.Forms.RadioButton();
            this.pnlDateSelector = new System.Windows.Forms.Panel();
            this.grpDateSelector = new System.Windows.Forms.GroupBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            this.pnlFormat = new System.Windows.Forms.Panel();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTibMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tibAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delaysToEnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tibReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tibTimeInProductionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.grpUnnamed = new System.Windows.Forms.GroupBox();
            this.rbExcludeUnnamed = new System.Windows.Forms.RadioButton();
            this.rbIncludeUnnamed = new System.Windows.Forms.RadioButton();
            this.rbOnlyUnnamed = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TIBDelayBindingSource)).BeginInit();
            this.pnlReport.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlPlantArea.SuspendLayout();
            this.grpPlantAreas.SuspendLayout();
            this.pnlUnits.SuspendLayout();
            this.grpUnits.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDateSelector.SuspendLayout();
            this.grpDateSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.pnlFormat.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.grpUnnamed.SuspendLayout();
            this.SuspendLayout();
            // 
            // TIBDelayBindingSource
            // 
            this.TIBDelayBindingSource.DataSource = typeof(ElvisDataModel.EDMX.TIBDelay);
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
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.reportViewer1);
            this.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReport.Location = new System.Drawing.Point(0, 170);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Padding = new System.Windows.Forms.Padding(6);
            this.pnlReport.Size = new System.Drawing.Size(1016, 564);
            this.pnlReport.TabIndex = 16;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "TIBDelayData";
            reportDataSource1.Value = this.TIBDelayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.TIBReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 6);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1004, 552);
            this.reportViewer1.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 24);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Size = new System.Drawing.Size(1016, 146);
            this.pnlFilter.TabIndex = 17;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.pnlButtons);
            this.grpFilter.Controls.Add(this.pnlPlantArea);
            this.grpFilter.Controls.Add(this.pnlUnits);
            this.grpFilter.Controls.Add(this.pnlDateSelector);
            this.grpFilter.Controls.Add(this.pnlFormat);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpFilter.Location = new System.Drawing.Point(6, 6);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(6);
            this.grpFilter.Size = new System.Drawing.Size(1004, 134);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Report Generator";
            // 
            // pnlPlantArea
            // 
            this.pnlPlantArea.Controls.Add(this.grpPlantAreas);
            this.pnlPlantArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPlantArea.Location = new System.Drawing.Point(710, 19);
            this.pnlPlantArea.Name = "pnlPlantArea";
            this.pnlPlantArea.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlPlantArea.Size = new System.Drawing.Size(182, 109);
            this.pnlPlantArea.TabIndex = 26;
            // 
            // grpPlantAreas
            // 
            this.grpPlantAreas.Controls.Add(this.chbCranes);
            this.grpPlantAreas.Controls.Add(this.chbCastersArea);
            this.grpPlantAreas.Controls.Add(this.chbSecSteelArea);
            this.grpPlantAreas.Controls.Add(this.chbPlan);
            this.grpPlantAreas.Controls.Add(this.chbVesselsArea);
            this.grpPlantAreas.Controls.Add(this.chbHMScrap);
            this.grpPlantAreas.Controls.Add(this.chbMultiserv);
            this.grpPlantAreas.Controls.Add(this.chbExternal);
            this.grpPlantAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlantAreas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpPlantAreas.Location = new System.Drawing.Point(0, 0);
            this.grpPlantAreas.Name = "grpPlantAreas";
            this.grpPlantAreas.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpPlantAreas.Size = new System.Drawing.Size(176, 109);
            this.grpPlantAreas.TabIndex = 24;
            this.grpPlantAreas.TabStop = false;
            this.grpPlantAreas.Text = "Plant Areas";
            // 
            // chbCranes
            // 
            this.chbCranes.AutoSize = true;
            this.chbCranes.Checked = true;
            this.chbCranes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCranes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCranes.Location = new System.Drawing.Point(99, 75);
            this.chbCranes.Name = "chbCranes";
            this.chbCranes.Size = new System.Drawing.Size(59, 17);
            this.chbCranes.TabIndex = 25;
            this.chbCranes.Tag = "CRANES";
            this.chbCranes.Text = "Cranes";
            this.chbCranes.UseVisualStyleBackColor = true;
            // 
            // chbCastersArea
            // 
            this.chbCastersArea.AutoSize = true;
            this.chbCastersArea.Checked = true;
            this.chbCastersArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCastersArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCastersArea.Location = new System.Drawing.Point(99, 57);
            this.chbCastersArea.Name = "chbCastersArea";
            this.chbCastersArea.Size = new System.Drawing.Size(61, 17);
            this.chbCastersArea.TabIndex = 24;
            this.chbCastersArea.Tag = "CASTERS";
            this.chbCastersArea.Text = "Casters";
            this.chbCastersArea.UseVisualStyleBackColor = true;
            // 
            // chbSecSteelArea
            // 
            this.chbSecSteelArea.AutoSize = true;
            this.chbSecSteelArea.Checked = true;
            this.chbSecSteelArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSecSteelArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSecSteelArea.Location = new System.Drawing.Point(99, 39);
            this.chbSecSteelArea.Name = "chbSecSteelArea";
            this.chbSecSteelArea.Size = new System.Drawing.Size(72, 17);
            this.chbSecSteelArea.TabIndex = 23;
            this.chbSecSteelArea.Tag = "SEC-STEEL";
            this.chbSecSteelArea.Text = "Sec-Steel";
            this.chbSecSteelArea.UseVisualStyleBackColor = true;
            // 
            // chbPlan
            // 
            this.chbPlan.AutoSize = true;
            this.chbPlan.Checked = true;
            this.chbPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPlan.Location = new System.Drawing.Point(99, 21);
            this.chbPlan.Name = "chbPlan";
            this.chbPlan.Size = new System.Drawing.Size(47, 17);
            this.chbPlan.TabIndex = 22;
            this.chbPlan.Tag = "PLAN";
            this.chbPlan.Text = "Plan";
            this.chbPlan.UseVisualStyleBackColor = true;
            // 
            // chbVesselsArea
            // 
            this.chbVesselsArea.AutoSize = true;
            this.chbVesselsArea.Checked = true;
            this.chbVesselsArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVesselsArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbVesselsArea.Location = new System.Drawing.Point(10, 75);
            this.chbVesselsArea.Name = "chbVesselsArea";
            this.chbVesselsArea.Size = new System.Drawing.Size(62, 17);
            this.chbVesselsArea.TabIndex = 20;
            this.chbVesselsArea.Tag = "VESSELS";
            this.chbVesselsArea.Text = "Vessels";
            this.chbVesselsArea.UseVisualStyleBackColor = true;
            // 
            // chbHMScrap
            // 
            this.chbHMScrap.AutoSize = true;
            this.chbHMScrap.Checked = true;
            this.chbHMScrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMScrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMScrap.Location = new System.Drawing.Point(10, 57);
            this.chbHMScrap.Name = "chbHMScrap";
            this.chbHMScrap.Size = new System.Drawing.Size(83, 17);
            this.chbHMScrap.TabIndex = 19;
            this.chbHMScrap.Tag = "HM & SCRAP";
            this.chbHMScrap.Text = "HM && Scrap";
            this.chbHMScrap.UseVisualStyleBackColor = true;
            // 
            // chbMultiserv
            // 
            this.chbMultiserv.AutoSize = true;
            this.chbMultiserv.Checked = true;
            this.chbMultiserv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMultiserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMultiserv.Location = new System.Drawing.Point(10, 39);
            this.chbMultiserv.Name = "chbMultiserv";
            this.chbMultiserv.Size = new System.Drawing.Size(68, 17);
            this.chbMultiserv.TabIndex = 18;
            this.chbMultiserv.Tag = "MULTISERV";
            this.chbMultiserv.Text = "Multiserv";
            this.chbMultiserv.UseVisualStyleBackColor = true;
            // 
            // chbExternal
            // 
            this.chbExternal.AutoSize = true;
            this.chbExternal.Checked = true;
            this.chbExternal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbExternal.Location = new System.Drawing.Point(10, 21);
            this.chbExternal.Name = "chbExternal";
            this.chbExternal.Size = new System.Drawing.Size(64, 17);
            this.chbExternal.TabIndex = 17;
            this.chbExternal.Tag = "EXTERNAL";
            this.chbExternal.Text = "External";
            this.chbExternal.UseVisualStyleBackColor = true;
            // 
            // pnlUnits
            // 
            this.pnlUnits.Controls.Add(this.grpUnits);
            this.pnlUnits.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnits.Location = new System.Drawing.Point(392, 19);
            this.pnlUnits.Name = "pnlUnits";
            this.pnlUnits.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlUnits.Size = new System.Drawing.Size(318, 109);
            this.pnlUnits.TabIndex = 25;
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.pnlUnitList);
            this.grpUnits.Controls.Add(this.panel1);
            this.grpUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpUnits.Location = new System.Drawing.Point(0, 0);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.grpUnits.Size = new System.Drawing.Size(312, 109);
            this.grpUnits.TabIndex = 24;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            // 
            // pnlUnitList
            // 
            this.pnlUnitList.AutoScroll = true;
            this.pnlUnitList.BackColor = System.Drawing.Color.White;
            this.pnlUnitList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUnitList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitList.Location = new System.Drawing.Point(96, 13);
            this.pnlUnitList.Name = "pnlUnitList";
            this.pnlUnitList.Size = new System.Drawing.Size(210, 90);
            this.pnlUnitList.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbUnitGroups);
            this.panel1.Controls.Add(this.rbUnits);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(6, 13);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Size = new System.Drawing.Size(90, 90);
            this.panel1.TabIndex = 3;
            // 
            // rbUnitGroups
            // 
            this.rbUnitGroups.AutoSize = true;
            this.rbUnitGroups.Checked = true;
            this.rbUnitGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbUnitGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnitGroups.Location = new System.Drawing.Point(3, 17);
            this.rbUnitGroups.Name = "rbUnitGroups";
            this.rbUnitGroups.Size = new System.Drawing.Size(84, 17);
            this.rbUnitGroups.TabIndex = 2;
            this.rbUnitGroups.TabStop = true;
            this.rbUnitGroups.Text = "Unit Groups";
            this.rbUnitGroups.UseVisualStyleBackColor = true;
            this.rbUnitGroups.CheckedChanged += new System.EventHandler(this.rbUnitSelection_CheckedChanged);
            // 
            // rbUnits
            // 
            this.rbUnits.AutoSize = true;
            this.rbUnits.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnits.Location = new System.Drawing.Point(3, 0);
            this.rbUnits.Name = "rbUnits";
            this.rbUnits.Size = new System.Drawing.Size(84, 17);
            this.rbUnits.TabIndex = 1;
            this.rbUnits.Text = "Units";
            this.rbUnits.UseVisualStyleBackColor = true;
            this.rbUnits.CheckedChanged += new System.EventHandler(this.rbUnitSelection_CheckedChanged);
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.grpDateSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateSelector.Location = new System.Drawing.Point(105, 19);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(287, 109);
            this.pnlDateSelector.TabIndex = 34;
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
            this.grpDateSelector.Size = new System.Drawing.Size(281, 109);
            this.grpDateSelector.TabIndex = 34;
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
            this.numYear.TabIndex = 31;
            this.numYear.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
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
            this.pnlFormat.Size = new System.Drawing.Size(99, 109);
            this.pnlFormat.TabIndex = 33;
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
            this.grpFormat.Size = new System.Drawing.Size(93, 109);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 18;
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
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
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
            this.tibReportToolStripMenuItem.Visible = false;
            this.tibReportToolStripMenuItem.Click += new System.EventHandler(this.tibReportToolStripMenuItem_Click);
            // 
            // tibTimeInProductionReportToolStripMenuItem
            // 
            this.tibTimeInProductionReportToolStripMenuItem.Name = "tibTimeInProductionReportToolStripMenuItem";
            this.tibTimeInProductionReportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tibTimeInProductionReportToolStripMenuItem.Text = "&Time In Production";
            this.tibTimeInProductionReportToolStripMenuItem.Click += new System.EventHandler(this.tibTimeInProductionReportToolStripMenuItem_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnGenerate);
            this.pnlButtons.Controls.Add(this.btnReset);
            this.pnlButtons.Controls.Add(this.grpUnnamed);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(892, 19);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(106, 109);
            this.pnlButtons.TabIndex = 36;
            // 
            // grpUnnamed
            // 
            this.grpUnnamed.Controls.Add(this.rbOnlyUnnamed);
            this.grpUnnamed.Controls.Add(this.rbIncludeUnnamed);
            this.grpUnnamed.Controls.Add(this.rbExcludeUnnamed);
            this.grpUnnamed.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUnnamed.Location = new System.Drawing.Point(0, 0);
            this.grpUnnamed.Name = "grpUnnamed";
            this.grpUnnamed.Size = new System.Drawing.Size(106, 67);
            this.grpUnnamed.TabIndex = 0;
            this.grpUnnamed.TabStop = false;
            this.grpUnnamed.Text = "Unnamed";
            // 
            // rbExcludeUnnamed
            // 
            this.rbExcludeUnnamed.AutoSize = true;
            this.rbExcludeUnnamed.Checked = true;
            this.rbExcludeUnnamed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExcludeUnnamed.Location = new System.Drawing.Point(7, 13);
            this.rbExcludeUnnamed.Name = "rbExcludeUnnamed";
            this.rbExcludeUnnamed.Size = new System.Drawing.Size(63, 17);
            this.rbExcludeUnnamed.TabIndex = 0;
            this.rbExcludeUnnamed.TabStop = true;
            this.rbExcludeUnnamed.Text = "Exclude";
            this.rbExcludeUnnamed.UseVisualStyleBackColor = true;
            // 
            // rbIncludeUnnamed
            // 
            this.rbIncludeUnnamed.AutoSize = true;
            this.rbIncludeUnnamed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIncludeUnnamed.Location = new System.Drawing.Point(7, 30);
            this.rbIncludeUnnamed.Name = "rbIncludeUnnamed";
            this.rbIncludeUnnamed.Size = new System.Drawing.Size(60, 17);
            this.rbIncludeUnnamed.TabIndex = 1;
            this.rbIncludeUnnamed.Text = "Include";
            this.rbIncludeUnnamed.UseVisualStyleBackColor = true;
            // 
            // rbOnlyUnnamed
            // 
            this.rbOnlyUnnamed.AutoSize = true;
            this.rbOnlyUnnamed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOnlyUnnamed.Location = new System.Drawing.Point(7, 47);
            this.rbOnlyUnnamed.Name = "rbOnlyUnnamed";
            this.rbOnlyUnnamed.Size = new System.Drawing.Size(46, 17);
            this.rbOnlyUnnamed.TabIndex = 2;
            this.rbOnlyUnnamed.Text = "Only";
            this.rbOnlyUnnamed.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(0, 67);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Location = new System.Drawing.Point(0, 86);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(106, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // TIBReport
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
            this.Name = "TIBReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIB Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TIBReport_FormClosing);
            this.Load += new System.EventHandler(this.TIBReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TIBReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TIBDelayBindingSource)).EndInit();
            this.pnlReport.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.pnlPlantArea.ResumeLayout(false);
            this.grpPlantAreas.ResumeLayout(false);
            this.grpPlantAreas.PerformLayout();
            this.pnlUnits.ResumeLayout(false);
            this.grpUnits.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDateSelector.ResumeLayout(false);
            this.grpDateSelector.ResumeLayout(false);
            this.grpDateSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.pnlFormat.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.grpUnnamed.ResumeLayout(false);
            this.grpUnnamed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource TIBDelayBindingSource;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Panel pnlPlantArea;
        private System.Windows.Forms.GroupBox grpPlantAreas;
        private System.Windows.Forms.CheckBox chbPlan;
        private System.Windows.Forms.CheckBox chbVesselsArea;
        private System.Windows.Forms.CheckBox chbHMScrap;
        private System.Windows.Forms.CheckBox chbMultiserv;
        private System.Windows.Forms.CheckBox chbExternal;
        private System.Windows.Forms.Panel pnlUnits;
        private System.Windows.Forms.GroupBox grpUnits;
        private System.Windows.Forms.CheckBox chbSecSteelArea;
        private System.Windows.Forms.CheckBox chbCranes;
        private System.Windows.Forms.CheckBox chbCastersArea;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.NumericUpDown numWeek;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Panel pnlDateSelector;
        private System.Windows.Forms.GroupBox grpDateSelector;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTibMain;
        private System.Windows.Forms.ToolStripMenuItem delaysToEnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tibAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tibReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tibTimeInProductionReportToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbUnits;
        private System.Windows.Forms.RadioButton rbUnitGroups;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlUnitList;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpUnnamed;
        private System.Windows.Forms.RadioButton rbOnlyUnnamed;
        private System.Windows.Forms.RadioButton rbIncludeUnnamed;
        private System.Windows.Forms.RadioButton rbExcludeUnnamed;
    }
}