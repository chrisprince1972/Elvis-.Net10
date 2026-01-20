namespace Elvis.Forms.Reports
{
    partial class TIBDelaysToEnterReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIBDelaysToEnterReport));
            this.TibReportDelaysViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UncompletedReportSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DelayByShiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DelayByRotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FiguresByPlantUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AggregatedFiguresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpMinDuration = new System.Windows.Forms.GroupBox();
            this.numMinDuration = new System.Windows.Forms.NumericUpDown();
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTibMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tibAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delaysToEnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tibReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tibTimeInProductionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlantUnitReportSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TibReportDelaysViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UncompletedReportSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayByShiftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayByRotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiguresByPlantUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggregatedFiguresBindingSource)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.grpMinDuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDuration)).BeginInit();
            this.pnlDateSelector.SuspendLayout();
            this.grpDateSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.pnlFormat.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlantUnitReportSummaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TibReportDelaysViewBindingSource
            // 
            this.TibReportDelaysViewBindingSource.DataSource = typeof(ElvisDataModel.EDMX.TibReportDelaysView);
            // 
            // UncompletedReportSummaryBindingSource
            // 
            this.UncompletedReportSummaryBindingSource.DataSource = typeof(Elvis.Forms.Reports.UncompletedReportSummary);
            // 
            // DelayByShiftBindingSource
            // 
            this.DelayByShiftBindingSource.DataSource = typeof(Elvis.Forms.Reports.UncompletedReportSummary);
            // 
            // DelayByRotaBindingSource
            // 
            this.DelayByRotaBindingSource.DataSource = typeof(Elvis.Forms.Reports.UncompletedReportSummary);
            // 
            // AggregatedFiguresBindingSource
            // 
            this.AggregatedFiguresBindingSource.DataSource = typeof(Elvis.Forms.Reports.PlantUnitReportSummary);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 24);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Size = new System.Drawing.Size(1122, 136);
            this.pnlFilter.TabIndex = 18;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.pnlButtons);
            this.grpFilter.Controls.Add(this.pnlDateSelector);
            this.grpFilter.Controls.Add(this.pnlFormat);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpFilter.Location = new System.Drawing.Point(6, 6);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(6);
            this.grpFilter.Size = new System.Drawing.Size(1110, 124);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Report Generator";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnReset);
            this.pnlButtons.Controls.Add(this.btnGenerate);
            this.pnlButtons.Controls.Add(this.grpMinDuration);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(392, 19);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(107, 99);
            this.pnlButtons.TabIndex = 42;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(0, 53);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 23);
            this.btnReset.TabIndex = 39;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGenerate.Location = new System.Drawing.Point(0, 76);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(107, 23);
            this.btnGenerate.TabIndex = 38;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpMinDuration
            // 
            this.grpMinDuration.Controls.Add(this.numMinDuration);
            this.grpMinDuration.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMinDuration.Location = new System.Drawing.Point(0, 0);
            this.grpMinDuration.Name = "grpMinDuration";
            this.grpMinDuration.Size = new System.Drawing.Size(107, 50);
            this.grpMinDuration.TabIndex = 36;
            this.grpMinDuration.TabStop = false;
            this.grpMinDuration.Text = "Min Duration";
            // 
            // numMinDuration
            // 
            this.numMinDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinDuration.Location = new System.Drawing.Point(6, 25);
            this.numMinDuration.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numMinDuration.Name = "numMinDuration";
            this.numMinDuration.Size = new System.Drawing.Size(95, 20);
            this.numMinDuration.TabIndex = 38;
            this.numMinDuration.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.grpDateSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateSelector.Location = new System.Drawing.Point(105, 19);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(287, 99);
            this.pnlDateSelector.TabIndex = 39;
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
            this.numWeek.ValueChanged += new System.EventHandler(this.numPickers_ValueChanged);
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
            this.numDay.ValueChanged += new System.EventHandler(this.numPickers_ValueChanged);
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
            this.pnlFormat.TabIndex = 38;
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
            this.pnlReport.Size = new System.Drawing.Size(1122, 574);
            this.pnlReport.TabIndex = 19;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DelaysDataSet";
            reportDataSource1.Value = this.TibReportDelaysViewBindingSource;
            reportDataSource2.Name = "UncompletedReportsData";
            reportDataSource2.Value = this.UncompletedReportSummaryBindingSource;
            reportDataSource3.Name = "BreakDownByShift";
            reportDataSource3.Value = this.DelayByShiftBindingSource;
            reportDataSource4.Name = "BreakDownByRota";
            reportDataSource4.Value = this.DelayByRotaBindingSource;
            reportDataSource5.Name = "FiguresByPlantUnitData";
            reportDataSource5.Value = this.FiguresByPlantUnitBindingSource;
            reportDataSource6.Name = "AggregatedPlantUnitFiguresDataSet";
            reportDataSource6.Value = this.AggregatedFiguresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.EnableHyperlinks = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.TIBDelaysToEnterReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 6);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1110, 562);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Hyperlink += new Microsoft.Reporting.WinForms.HyperlinkEventHandler(this.reportViewer_Hyperlink);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1122, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTibMain});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
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
            this.toolStripMenuItemTibMain.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemTibMain.Text = "&Tib";
            // 
            // tibAnalysisToolStripMenuItem
            // 
            this.tibAnalysisToolStripMenuItem.Name = "tibAnalysisToolStripMenuItem";
            this.tibAnalysisToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tibAnalysisToolStripMenuItem.Text = "&Analysis";
            this.tibAnalysisToolStripMenuItem.Click += new System.EventHandler(this.tibAnalysisToolStripMenuItem_Click);
            // 
            // delaysToEnterToolStripMenuItem
            // 
            this.delaysToEnterToolStripMenuItem.Name = "delaysToEnterToolStripMenuItem";
            this.delaysToEnterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.delaysToEnterToolStripMenuItem.Text = "&Delays To Enter";
            this.delaysToEnterToolStripMenuItem.Visible = false;
            this.delaysToEnterToolStripMenuItem.Click += new System.EventHandler(this.delaysToEnterToolStripMenuItem_Click);
            // 
            // tibReportToolStripMenuItem
            // 
            this.tibReportToolStripMenuItem.Name = "tibReportToolStripMenuItem";
            this.tibReportToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tibReportToolStripMenuItem.Text = "&Reports";
            this.tibReportToolStripMenuItem.Click += new System.EventHandler(this.tibReportToolStripMenuItem_Click);
            // 
            // tibTimeInProductionReportToolStripMenuItem
            // 
            this.tibTimeInProductionReportToolStripMenuItem.Name = "tibTimeInProductionReportToolStripMenuItem";
            this.tibTimeInProductionReportToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tibTimeInProductionReportToolStripMenuItem.Text = "&Time In Production";
            this.tibTimeInProductionReportToolStripMenuItem.Click += new System.EventHandler(this.tibTimeInProductionReportToolStripMenuItem_Click);
            // 
            // PlantUnitReportSummaryBindingSource
            // 
            this.PlantUnitReportSummaryBindingSource.DataSource = typeof(Elvis.Forms.Reports.PlantUnitReportSummary);
            // 
            // TIBDelaysToEnterReport
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1122, 734);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TIBDelaysToEnterReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIB Delays to Enter Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TIBDelaysToEnterReport_FormClosing);
            this.Load += new System.EventHandler(this.TIBDelaysToEnterReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TIBDelaysToEnterReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TibReportDelaysViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UncompletedReportSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayByShiftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayByRotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiguresByPlantUnitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggregatedFiguresBindingSource)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.grpMinDuration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMinDuration)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.PlantUnitReportSummaryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource UncompletedReportSummaryBindingSource;
        private System.Windows.Forms.BindingSource TibReportDelaysViewBindingSource;
        private System.Windows.Forms.BindingSource DelayByShiftBindingSource;
        private System.Windows.Forms.BindingSource DelayByRotaBindingSource;
        private System.Windows.Forms.BindingSource FiguresByPlantUnitBindingSource;
        private System.Windows.Forms.BindingSource PlantUnitReportSummaryBindingSource;
        private System.Windows.Forms.BindingSource AggregatedFiguresBindingSource;
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
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.GroupBox grpMinDuration;
        private System.Windows.Forms.NumericUpDown numMinDuration;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
    }
}
