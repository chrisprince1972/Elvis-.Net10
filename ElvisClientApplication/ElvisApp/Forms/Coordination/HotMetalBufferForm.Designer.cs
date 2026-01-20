namespace Elvis.Forms.Coordination
{
    partial class HotMetalBufferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotMetalBufferForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lblCurrentBlastOutput = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrentHMStock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuNow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuForward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripDateFrom = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripDateTo = new System.Windows.Forms.ToolStripStatusLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideTargetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStripTimeControls = new System.Windows.Forms.ToolStrip();
            this.btnNow = new System.Windows.Forms.ToolStripButton();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTimescale = new System.Windows.Forms.ToolStripDropDownButton();
            this.btn48Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.btn24Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.btn12Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.chartContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStripTimeControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentBlastOutput
            // 
            this.lblCurrentBlastOutput.AutoSize = true;
            this.lblCurrentBlastOutput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBlastOutput.Location = new System.Drawing.Point(337, 11);
            this.lblCurrentBlastOutput.MaximumSize = new System.Drawing.Size(50, 0);
            this.lblCurrentBlastOutput.Name = "lblCurrentBlastOutput";
            this.lblCurrentBlastOutput.Size = new System.Drawing.Size(25, 13);
            this.lblCurrentBlastOutput.TabIndex = 6;
            this.lblCurrentBlastOutput.Text = "123";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(189, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Blast Output (T/Hour): ";
            // 
            // lblCurrentHMStock
            // 
            this.lblCurrentHMStock.AutoSize = true;
            this.lblCurrentHMStock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHMStock.Location = new System.Drawing.Point(124, 11);
            this.lblCurrentHMStock.MaximumSize = new System.Drawing.Size(50, 0);
            this.lblCurrentHMStock.Name = "lblCurrentHMStock";
            this.lblCurrentHMStock.Size = new System.Drawing.Size(25, 13);
            this.lblCurrentHMStock.TabIndex = 3;
            this.lblCurrentHMStock.Text = "123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hot Metal Stock (T): ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
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
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem1.Text = "&Close";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuNow,
            this.btnMenuBack,
            this.btnMenuForward,
            this.toolStripSeparator4,
            this.btnMenuRefresh});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // btnMenuNow
            // 
            this.btnMenuNow.Name = "btnMenuNow";
            this.btnMenuNow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.btnMenuNow.Size = new System.Drawing.Size(157, 22);
            this.btnMenuNow.Text = "&Now";
            this.btnMenuNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // btnMenuBack
            // 
            this.btnMenuBack.Name = "btnMenuBack";
            this.btnMenuBack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.btnMenuBack.Size = new System.Drawing.Size(157, 22);
            this.btnMenuBack.Text = "&Back";
            this.btnMenuBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMenuForward
            // 
            this.btnMenuForward.Enabled = false;
            this.btnMenuForward.Name = "btnMenuForward";
            this.btnMenuForward.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.btnMenuForward.Size = new System.Drawing.Size(157, 22);
            this.btnMenuForward.Text = "&Forward";
            this.btnMenuForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // btnMenuRefresh
            // 
            this.btnMenuRefresh.Name = "btnMenuRefresh";
            this.btnMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.btnMenuRefresh.Size = new System.Drawing.Size(157, 22);
            this.btnMenuRefresh.Text = "&Refresh";
            this.btnMenuRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripDateFrom,
            this.stripDateTo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 710);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stripDateFrom
            // 
            this.stripDateFrom.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stripDateFrom.Name = "stripDateFrom";
            this.stripDateFrom.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.stripDateFrom.Size = new System.Drawing.Size(158, 19);
            this.stripDateFrom.Text = "From - dd/MM/yy HH:mm";
            // 
            // stripDateTo
            // 
            this.stripDateTo.Name = "stripDateTo";
            this.stripDateTo.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.stripDateTo.Size = new System.Drawing.Size(142, 19);
            this.stripDateTo.Text = "To - dd/MM/yy HH:mm";
            // 
            // chart1
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX2.Title = "Date";
            chartArea1.AxisY.Interval = 500D;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.LabelStyle.Interval = 500D;
            chartArea1.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 4000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 250D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.Title = "HM Stock";
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 93F;
            chartArea1.Position.Width = 95F;
            chartArea1.Position.Y = 6F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ContextMenuStrip = this.chartContextMenuStrip;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 4F;
            legend1.Position.Width = 30F;
            legend1.Position.Y = 1F;
            legend1.ShadowOffset = 2;
            legend1.TextWrapThreshold = 100;
            legend2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "castingRateLegend";
            legend2.Position.Auto = false;
            legend2.Position.Height = 4F;
            legend2.Position.Width = 28F;
            legend2.Position.X = 70F;
            legend2.Position.Y = 1F;
            legend2.ShadowOffset = 2;
            this.chart1.Legends.Add(legend1);
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 59);
            this.chart1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "HM Stock";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Blast Furnace";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1016, 627);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Hot Metal Buffer & Tonnes per Minute Trend";
            this.chart1.Titles.Add(title1);
            // 
            // chartContextMenuStrip
            // 
            this.chartContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideTargetMenuItem});
            this.chartContextMenuStrip.Name = "chartContextMenuStrip";
            this.chartContextMenuStrip.Size = new System.Drawing.Size(162, 26);
            // 
            // showHideTargetMenuItem
            // 
            this.showHideTargetMenuItem.Name = "showHideTargetMenuItem";
            this.showHideTargetMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showHideTargetMenuItem.Text = "Hide Target Line";
            this.showHideTargetMenuItem.Click += new System.EventHandler(this.showHideTargetMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCurrentBlastOutput);
            this.panel1.Controls.Add(this.lblCurrentHMStock);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 34);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.toolStripTimeControls);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 686);
            this.panel3.TabIndex = 6;
            // 
            // toolStripTimeControls
            // 
            this.toolStripTimeControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNow,
            this.btnBack,
            this.btnForward,
            this.toolStripSeparator3,
            this.btnRefresh,
            this.toolStripSeparator6,
            this.toolStripTimescale});
            this.toolStripTimeControls.Location = new System.Drawing.Point(0, 0);
            this.toolStripTimeControls.Name = "toolStripTimeControls";
            this.toolStripTimeControls.Size = new System.Drawing.Size(1016, 25);
            this.toolStripTimeControls.TabIndex = 11;
            this.toolStripTimeControls.Text = "Time Controls";
            // 
            // btnNow
            // 
            this.btnNow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNow.Image = ((System.Drawing.Image)(resources.GetObject("btnNow.Image")));
            this.btnNow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(52, 22);
            this.btnNow.Text = "Now";
            this.btnNow.ToolTipText = "Now (Ctrl+N)";
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // btnBack
            // 
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 22);
            this.btnBack.Text = "Back";
            this.btnBack.ToolTipText = "Back (Ctrl+B)";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(70, 22);
            this.btnForward.Text = "Forward";
            this.btnForward.ToolTipText = "Forward (Ctrl+F)";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            this.btnForward.EnabledChanged += new System.EventHandler(this.btnForward_EnabledChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ToolTipText = "Refresh (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTimescale
            // 
            this.toolStripTimescale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTimescale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn48Hour,
            this.btn24Hour,
            this.btn12Hour});
            this.toolStripTimescale.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTimescale.Image")));
            this.toolStripTimescale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTimescale.Name = "toolStripTimescale";
            this.toolStripTimescale.Size = new System.Drawing.Size(29, 22);
            this.toolStripTimescale.Text = "Time Span Selector";
            // 
            // btn48Hour
            // 
            this.btn48Hour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn48Hour.Name = "btn48Hour";
            this.btn48Hour.Size = new System.Drawing.Size(116, 22);
            this.btn48Hour.Tag = "48";
            this.btn48Hour.Text = "48 Hour";
            this.btn48Hour.Click += new System.EventHandler(this.btnHour_Click);
            // 
            // btn24Hour
            // 
            this.btn24Hour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn24Hour.Name = "btn24Hour";
            this.btn24Hour.Size = new System.Drawing.Size(116, 22);
            this.btn24Hour.Tag = "24";
            this.btn24Hour.Text = "24 Hour";
            this.btn24Hour.Click += new System.EventHandler(this.btnHour_Click);
            // 
            // btn12Hour
            // 
            this.btn12Hour.Name = "btn12Hour";
            this.btn12Hour.Size = new System.Drawing.Size(116, 22);
            this.btn12Hour.Tag = "12";
            this.btn12Hour.Text = "12 Hour";
            this.btn12Hour.Click += new System.EventHandler(this.btnHour_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "Hot Metal Buffer Screenshot";
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
            // HotMetalBufferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HotMetalBufferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hot Metal Buffer";
            this.Load += new System.EventHandler(this.HotMetalBufferForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotMetalBufferForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.chartContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStripTimeControls.ResumeLayout(false);
            this.toolStripTimeControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblCurrentBlastOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCurrentHMStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ContextMenuStrip chartContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showHideTargetMenuItem;
        private System.Windows.Forms.ToolStrip toolStripTimeControls;
        private System.Windows.Forms.ToolStripButton btnNow;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnMenuNow;
        private System.Windows.Forms.ToolStripMenuItem btnMenuBack;
        private System.Windows.Forms.ToolStripMenuItem btnMenuForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripDropDownButton toolStripTimescale;
        private System.Windows.Forms.ToolStripMenuItem btn48Hour;
        private System.Windows.Forms.ToolStripMenuItem btn24Hour;
        private System.Windows.Forms.ToolStripMenuItem btn12Hour;
        private System.Windows.Forms.ToolStripStatusLabel stripDateFrom;
        private System.Windows.Forms.ToolStripStatusLabel stripDateTo;
    }
}