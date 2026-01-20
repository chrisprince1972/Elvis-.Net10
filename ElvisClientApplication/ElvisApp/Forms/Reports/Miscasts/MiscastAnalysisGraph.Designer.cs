namespace Elvis.Forms.Reports.Miscasts
{
    partial class MiscastAnalysisGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiscastAnalysisGraph));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGenerate = new System.Windows.Forms.Panel();
            this.grpGenerate = new System.Windows.Forms.GroupBox();
            this.pnlGenerateMain = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.ucMiscastFilter = new Elvis.Forms.Reports.Miscasts.UserControls.MiscastFilter();
            this.ucDateSelector = new Elvis.UserControls.DatePickers.ElvisDateSelector();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.chartMiscast = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.pnlLegendItemHolder = new System.Windows.Forms.Panel();
            this.pnlCheckAll = new System.Windows.Forms.Panel();
            this.chbCheckAll = new System.Windows.Forms.CheckBox();
            this.pnlSeries = new System.Windows.Forms.Panel();
            this.grpSeries = new System.Windows.Forms.GroupBox();
            this.cmboSeries = new System.Windows.Forms.ComboBox();
            this.pnlXAxis = new System.Windows.Forms.Panel();
            this.grpXAxis = new System.Windows.Forms.GroupBox();
            this.cmboXAxis = new System.Windows.Forms.ComboBox();
            this.pnlMiscastAnalysis = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRecordsReturned = new System.Windows.Forms.ToolStripStatusLabel();
            this.printChart = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1.SuspendLayout();
            this.pnlGenerate.SuspendLayout();
            this.grpGenerate.SuspendLayout();
            this.pnlGenerateMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMiscast)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.pnlLegend.SuspendLayout();
            this.grpLegend.SuspendLayout();
            this.pnlCheckAll.SuspendLayout();
            this.pnlSeries.SuspendLayout();
            this.grpSeries.SuspendLayout();
            this.pnlXAxis.SuspendLayout();
            this.grpXAxis.SuspendLayout();
            this.pnlMiscastAnalysis.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnlGenerate
            // 
            this.pnlGenerate.Controls.Add(this.grpGenerate);
            this.pnlGenerate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGenerate.Location = new System.Drawing.Point(0, 24);
            this.pnlGenerate.Name = "pnlGenerate";
            this.pnlGenerate.Padding = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.pnlGenerate.Size = new System.Drawing.Size(1008, 146);
            this.pnlGenerate.TabIndex = 20;
            // 
            // grpGenerate
            // 
            this.grpGenerate.Controls.Add(this.pnlGenerateMain);
            this.grpGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGenerate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGenerate.Location = new System.Drawing.Point(6, 6);
            this.grpGenerate.Name = "grpGenerate";
            this.grpGenerate.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.grpGenerate.Size = new System.Drawing.Size(996, 137);
            this.grpGenerate.TabIndex = 0;
            this.grpGenerate.TabStop = false;
            this.grpGenerate.Text = "Miscast Data Filters";
            // 
            // pnlGenerateMain
            // 
            this.pnlGenerateMain.Controls.Add(this.pnlButtons);
            this.pnlGenerateMain.Controls.Add(this.ucMiscastFilter);
            this.pnlGenerateMain.Controls.Add(this.ucDateSelector);
            this.pnlGenerateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGenerateMain.Location = new System.Drawing.Point(6, 18);
            this.pnlGenerateMain.Name = "pnlGenerateMain";
            this.pnlGenerateMain.Size = new System.Drawing.Size(984, 113);
            this.pnlGenerateMain.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnReset);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(885, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(99, 113);
            this.pnlButtons.TabIndex = 37;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(0, 90);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 23);
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ucMiscastFilter
            // 
            this.ucMiscastFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucMiscastFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucMiscastFilter.Location = new System.Drawing.Point(380, 0);
            this.ucMiscastFilter.Name = "ucMiscastFilter";
            this.ucMiscastFilter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ucMiscastFilter.Size = new System.Drawing.Size(505, 113);
            this.ucMiscastFilter.TabIndex = 42;
            // 
            // ucDateSelector
            // 
            this.ucDateSelector.DateFrom = new System.DateTime(2015, 11, 12, 7, 0, 0, 0);
            this.ucDateSelector.DateTo = new System.DateTime(2015, 11, 13, 7, 0, 0, 0);
            this.ucDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucDateSelector.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDateSelector.Location = new System.Drawing.Point(0, 0);
            this.ucDateSelector.Name = "ucDateSelector";
            this.ucDateSelector.SelectedDateFormat = Elvis.UserControls.DatePickers.ElvisDateSelector.DateFormat.DateSpan;
            this.ucDateSelector.Size = new System.Drawing.Size(380, 113);
            this.ucDateSelector.TabIndex = 41;
            this.ucDateSelector.DateChangedEvent += new Elvis.UserControls.DatePickers.ElvisDateSelector.DateChanged(this.ucDateSelector_DateChangedEvent);
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.grpChart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(6, 0, 0, 6);
            this.pnlChart.Size = new System.Drawing.Size(835, 538);
            this.pnlChart.TabIndex = 21;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.chartMiscast);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChart.Location = new System.Drawing.Point(6, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(829, 532);
            this.grpChart.TabIndex = 4;
            this.grpChart.TabStop = false;
            this.grpChart.Text = "Miscast Analysis - dd/MM/yy HH:mm to dd/MM/yy HH:mm";
            // 
            // chartMiscast
            // 
            this.chartMiscast.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked;
            chartArea1.AxisY.Title = "Miscast Count";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 85.5F;
            chartArea1.InnerPlotPosition.Width = 93.5F;
            chartArea1.InnerPlotPosition.X = 4.8F;
            chartArea1.InnerPlotPosition.Y = 3F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 97F;
            chartArea1.Position.X = 3F;
            this.chartMiscast.ChartAreas.Add(chartArea1);
            this.chartMiscast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMiscast.Location = new System.Drawing.Point(3, 17);
            this.chartMiscast.Name = "chartMiscast";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Name = "Data1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Name = "Data2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Name = "Data3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Name = "Data4";
            this.chartMiscast.Series.Add(series1);
            this.chartMiscast.Series.Add(series2);
            this.chartMiscast.Series.Add(series3);
            this.chartMiscast.Series.Add(series4);
            this.chartMiscast.Size = new System.Drawing.Size(823, 512);
            this.chartMiscast.TabIndex = 4;
            this.chartMiscast.Text = "chart1";
            this.chartMiscast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartMiscast_MouseClick);
            this.chartMiscast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartMiscast_MouseMove);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.pnlLegend);
            this.pnlOptions.Controls.Add(this.pnlSeries);
            this.pnlOptions.Controls.Add(this.pnlXAxis);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlOptions.Location = new System.Drawing.Point(838, 0);
            this.pnlOptions.MinimumSize = new System.Drawing.Size(100, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.pnlOptions.Size = new System.Drawing.Size(170, 538);
            this.pnlOptions.TabIndex = 22;
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.grpLegend);
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLegend.Location = new System.Drawing.Point(0, 106);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(164, 426);
            this.pnlLegend.TabIndex = 39;
            // 
            // grpLegend
            // 
            this.grpLegend.Controls.Add(this.pnlLegendItemHolder);
            this.grpLegend.Controls.Add(this.pnlCheckAll);
            this.grpLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLegend.Location = new System.Drawing.Point(0, 0);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.grpLegend.Size = new System.Drawing.Size(164, 426);
            this.grpLegend.TabIndex = 1;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Legend";
            // 
            // pnlLegendItemHolder
            // 
            this.pnlLegendItemHolder.AutoScroll = true;
            this.pnlLegendItemHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLegendItemHolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLegendItemHolder.Location = new System.Drawing.Point(3, 36);
            this.pnlLegendItemHolder.Name = "pnlLegendItemHolder";
            this.pnlLegendItemHolder.Size = new System.Drawing.Size(158, 387);
            this.pnlLegendItemHolder.TabIndex = 0;
            // 
            // pnlCheckAll
            // 
            this.pnlCheckAll.Controls.Add(this.chbCheckAll);
            this.pnlCheckAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCheckAll.Location = new System.Drawing.Point(3, 15);
            this.pnlCheckAll.Name = "pnlCheckAll";
            this.pnlCheckAll.Padding = new System.Windows.Forms.Padding(8, 0, 7, 2);
            this.pnlCheckAll.Size = new System.Drawing.Size(158, 21);
            this.pnlCheckAll.TabIndex = 1;
            // 
            // chbCheckAll
            // 
            this.chbCheckAll.AutoSize = true;
            this.chbCheckAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbCheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbCheckAll.Location = new System.Drawing.Point(8, 0);
            this.chbCheckAll.Name = "chbCheckAll";
            this.chbCheckAll.Size = new System.Drawing.Size(143, 19);
            this.chbCheckAll.TabIndex = 0;
            this.chbCheckAll.Text = "Check All";
            this.chbCheckAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbCheckAll.UseVisualStyleBackColor = true;
            this.chbCheckAll.CheckedChanged += new System.EventHandler(this.chbCheckAll_CheckedChanged);
            // 
            // pnlSeries
            // 
            this.pnlSeries.Controls.Add(this.grpSeries);
            this.pnlSeries.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeries.Location = new System.Drawing.Point(0, 53);
            this.pnlSeries.Name = "pnlSeries";
            this.pnlSeries.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlSeries.Size = new System.Drawing.Size(164, 53);
            this.pnlSeries.TabIndex = 38;
            // 
            // grpSeries
            // 
            this.grpSeries.Controls.Add(this.cmboSeries);
            this.grpSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSeries.Location = new System.Drawing.Point(0, 0);
            this.grpSeries.Name = "grpSeries";
            this.grpSeries.Padding = new System.Windows.Forms.Padding(8, 5, 8, 8);
            this.grpSeries.Size = new System.Drawing.Size(164, 50);
            this.grpSeries.TabIndex = 56;
            this.grpSeries.TabStop = false;
            this.grpSeries.Text = "Series";
            // 
            // cmboSeries
            // 
            this.cmboSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboSeries.FormattingEnabled = true;
            this.cmboSeries.Items.AddRange(new object[] {
            "Failure Mode",
            "Type",
            "Root Cause",
            "Unit",
            "Area",
            "Function",
            "Rota",
            "Status"});
            this.cmboSeries.Location = new System.Drawing.Point(8, 19);
            this.cmboSeries.Name = "cmboSeries";
            this.cmboSeries.Size = new System.Drawing.Size(148, 21);
            this.cmboSeries.TabIndex = 32;
            this.cmboSeries.SelectionChangeCommitted += new System.EventHandler(this.cmboSeries_SelectionChangeCommitted);
            // 
            // pnlXAxis
            // 
            this.pnlXAxis.Controls.Add(this.grpXAxis);
            this.pnlXAxis.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlXAxis.Location = new System.Drawing.Point(0, 0);
            this.pnlXAxis.Name = "pnlXAxis";
            this.pnlXAxis.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlXAxis.Size = new System.Drawing.Size(164, 53);
            this.pnlXAxis.TabIndex = 40;
            // 
            // grpXAxis
            // 
            this.grpXAxis.Controls.Add(this.cmboXAxis);
            this.grpXAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpXAxis.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpXAxis.Location = new System.Drawing.Point(0, 0);
            this.grpXAxis.Name = "grpXAxis";
            this.grpXAxis.Padding = new System.Windows.Forms.Padding(8, 5, 8, 8);
            this.grpXAxis.Size = new System.Drawing.Size(164, 50);
            this.grpXAxis.TabIndex = 56;
            this.grpXAxis.TabStop = false;
            this.grpXAxis.Text = "X Axis";
            // 
            // cmboXAxis
            // 
            this.cmboXAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmboXAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboXAxis.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboXAxis.FormattingEnabled = true;
            this.cmboXAxis.Items.AddRange(new object[] {
            "Failure Mode",
            "Type",
            "Root Cause",
            "Unit",
            "Area",
            "Function",
            "Rota",
            "Status",
            "Weekly",
            "Daily"});
            this.cmboXAxis.Location = new System.Drawing.Point(8, 19);
            this.cmboXAxis.Name = "cmboXAxis";
            this.cmboXAxis.Size = new System.Drawing.Size(148, 21);
            this.cmboXAxis.TabIndex = 32;
            this.cmboXAxis.SelectionChangeCommitted += new System.EventHandler(this.cmboXAxis_SelectionChangeCommitted);
            // 
            // pnlMiscastAnalysis
            // 
            this.pnlMiscastAnalysis.Controls.Add(this.pnlChart);
            this.pnlMiscastAnalysis.Controls.Add(this.splitter1);
            this.pnlMiscastAnalysis.Controls.Add(this.pnlOptions);
            this.pnlMiscastAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiscastAnalysis.Location = new System.Drawing.Point(0, 170);
            this.pnlMiscastAnalysis.Name = "pnlMiscastAnalysis";
            this.pnlMiscastAnalysis.Size = new System.Drawing.Size(1008, 538);
            this.pnlMiscastAnalysis.TabIndex = 23;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(835, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 538);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRecordsReturned});
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRecordsReturned
            // 
            this.lblRecordsReturned.BackColor = System.Drawing.SystemColors.Control;
            this.lblRecordsReturned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRecordsReturned.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.lblRecordsReturned.Name = "lblRecordsReturned";
            this.lblRecordsReturned.Size = new System.Drawing.Size(153, 17);
            this.lblRecordsReturned.Text = "# Miscast Records Returned";
            // 
            // printChart
            // 
            this.printChart.DocumentName = "Elvis Trending Form";
            this.printChart.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCharts_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printChart;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printChart;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // MiscastAnalysisGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.pnlMiscastAnalysis);
            this.Controls.Add(this.pnlGenerate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MiscastAnalysisGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miscast Analysis";
            this.Load += new System.EventHandler(this.MiscastAnalysis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MiscastAnalysis_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlGenerate.ResumeLayout(false);
            this.grpGenerate.ResumeLayout(false);
            this.pnlGenerateMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMiscast)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlLegend.ResumeLayout(false);
            this.grpLegend.ResumeLayout(false);
            this.pnlCheckAll.ResumeLayout(false);
            this.pnlCheckAll.PerformLayout();
            this.pnlSeries.ResumeLayout(false);
            this.grpSeries.ResumeLayout(false);
            this.pnlXAxis.ResumeLayout(false);
            this.grpXAxis.ResumeLayout(false);
            this.pnlMiscastAnalysis.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGenerate;
        private System.Windows.Forms.GroupBox grpGenerate;
        private System.Windows.Forms.Panel pnlGenerateMain;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlChart;
        private Elvis.UserControls.DatePickers.ElvisDateSelector ucDateSelector;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.GroupBox grpChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMiscast;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.Panel pnlSeries;
        private System.Windows.Forms.GroupBox grpSeries;
        private System.Windows.Forms.ComboBox cmboSeries;
        private System.Windows.Forms.Panel pnlMiscastAnalysis;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLegendItemHolder;
        private System.Windows.Forms.Panel pnlCheckAll;
        private System.Windows.Forms.CheckBox chbCheckAll;
        private System.Windows.Forms.Panel pnlXAxis;
        private System.Windows.Forms.GroupBox grpXAxis;
        private System.Windows.Forms.ComboBox cmboXAxis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordsReturned;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Drawing.Printing.PrintDocument printChart;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private UserControls.MiscastFilter ucMiscastFilter;
    }
}