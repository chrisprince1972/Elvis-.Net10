namespace Elvis.Forms.TrendingShifts.UserControls
{
    partial class TrendingChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.tblCodeAndPractices = new System.Windows.Forms.TableLayoutPanel();
            this.txtAVG = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblAVG = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblStandardDev = new System.Windows.Forms.Label();
            this.lblCPK = new System.Windows.Forms.Label();
            this.txtStandardDev = new System.Windows.Forms.TextBox();
            this.txtCPK = new System.Windows.Forms.TextBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.chbDistribution = new System.Windows.Forms.CheckBox();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDist)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.tblCodeAndPractices.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.pnlMain);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMain.Location = new System.Drawing.Point(3, 1);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(782, 193);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Name";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 17);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlMain.Size = new System.Drawing.Size(776, 173);
            this.pnlMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartTrend);
            this.splitContainer1.Panel1.Controls.Add(this.chartDist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlStats);
            this.splitContainer1.Panel2.Controls.Add(this.btnShowHide);
            this.splitContainer1.Size = new System.Drawing.Size(770, 170);
            this.splitContainer1.SplitterDistance = 668;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // chartTrend
            // 
            this.chartTrend.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX2.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Format = "0.####";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 80F;
            chartArea1.InnerPlotPosition.Width = 93.5F;
            chartArea1.InnerPlotPosition.X = 4.5F;
            chartArea1.InnerPlotPosition.Y = 3F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartTrend.ChartAreas.Add(chartArea1);
            this.chartTrend.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartTrend.Location = new System.Drawing.Point(0, 0);
            this.chartTrend.Name = "chartTrend";
            series1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Percent90;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series1.Color = System.Drawing.Color.Lime;
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.Name = "Range";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValuesPerPoint = 2;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsXValueIndexed = true;
            series2.MarkerSize = 4;
            series2.Name = "DataCore";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Purple;
            series3.IsVisibleInLegend = false;
            series3.IsXValueIndexed = true;
            series3.Name = "Aim";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.IsXValueIndexed = true;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "Data1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.IsXValueIndexed = true;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "Data2";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.IsXValueIndexed = true;
            series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series6.Name = "Data3";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.IsXValueIndexed = true;
            series7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series7.Name = "Data4";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartTrend.Series.Add(series1);
            this.chartTrend.Series.Add(series2);
            this.chartTrend.Series.Add(series3);
            this.chartTrend.Series.Add(series4);
            this.chartTrend.Series.Add(series5);
            this.chartTrend.Series.Add(series6);
            this.chartTrend.Series.Add(series7);
            this.chartTrend.Size = new System.Drawing.Size(365, 170);
            this.chartTrend.TabIndex = 1;
            this.chartTrend.Text = "chart1";
            this.chartTrend.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartTrend_MouseClick);
            this.chartTrend.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartTrend_MouseMove);
            // 
            // chartDist
            // 
            this.chartDist.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LabelStyle.Interval = 1D;
            chartArea2.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.MajorTickMark.Interval = 1D;
            chartArea2.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea2.AxisX2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea2.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 80F;
            chartArea2.InnerPlotPosition.Width = 93.5F;
            chartArea2.InnerPlotPosition.X = 4.5F;
            chartArea2.InnerPlotPosition.Y = 3F;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chartDist.ChartAreas.Add(chartArea2);
            this.chartDist.Dock = System.Windows.Forms.DockStyle.Right;
            this.chartDist.Location = new System.Drawing.Point(380, 0);
            this.chartDist.Name = "chartDist";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series8.Name = "Data1";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series9.Name = "Data2";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series10.Name = "Data3";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series11.Name = "Data4";
            this.chartDist.Series.Add(series8);
            this.chartDist.Series.Add(series9);
            this.chartDist.Series.Add(series10);
            this.chartDist.Series.Add(series11);
            this.chartDist.Size = new System.Drawing.Size(288, 170);
            this.chartDist.TabIndex = 2;
            this.chartDist.Text = "chart1";
            this.chartDist.Customize += new System.EventHandler(this.chartDist_Customize);
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.grpStats);
            this.pnlStats.Controls.Add(this.pnlOptions);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStats.Location = new System.Drawing.Point(8, 0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.pnlStats.Size = new System.Drawing.Size(93, 170);
            this.pnlStats.TabIndex = 5;
            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.tblCodeAndPractices);
            this.grpStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStats.Location = new System.Drawing.Point(3, 25);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(90, 142);
            this.grpStats.TabIndex = 2;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Statistics";
            // 
            // tblCodeAndPractices
            // 
            this.tblCodeAndPractices.AutoScroll = true;
            this.tblCodeAndPractices.ColumnCount = 2;
            this.tblCodeAndPractices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblCodeAndPractices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCodeAndPractices.Controls.Add(this.txtAVG, 1, 2);
            this.tblCodeAndPractices.Controls.Add(this.txtMax, 1, 1);
            this.tblCodeAndPractices.Controls.Add(this.lblAVG, 0, 2);
            this.tblCodeAndPractices.Controls.Add(this.lblMax, 0, 1);
            this.tblCodeAndPractices.Controls.Add(this.txtMin, 1, 0);
            this.tblCodeAndPractices.Controls.Add(this.lblMin, 0, 0);
            this.tblCodeAndPractices.Controls.Add(this.lblStandardDev, 0, 3);
            this.tblCodeAndPractices.Controls.Add(this.lblCPK, 0, 4);
            this.tblCodeAndPractices.Controls.Add(this.txtStandardDev, 1, 3);
            this.tblCodeAndPractices.Controls.Add(this.txtCPK, 1, 4);
            this.tblCodeAndPractices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCodeAndPractices.Location = new System.Drawing.Point(3, 17);
            this.tblCodeAndPractices.Name = "tblCodeAndPractices";
            this.tblCodeAndPractices.Padding = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.tblCodeAndPractices.RowCount = 6;
            this.tblCodeAndPractices.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCodeAndPractices.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCodeAndPractices.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCodeAndPractices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCodeAndPractices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCodeAndPractices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tblCodeAndPractices.Size = new System.Drawing.Size(84, 122);
            this.tblCodeAndPractices.TabIndex = 1;
            // 
            // txtAVG
            // 
            this.txtAVG.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtAVG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAVG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAVG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAVG.Location = new System.Drawing.Point(37, 46);
            this.txtAVG.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.txtAVG.Multiline = true;
            this.txtAVG.Name = "txtAVG";
            this.txtAVG.ReadOnly = true;
            this.txtAVG.Size = new System.Drawing.Size(45, 15);
            this.txtAVG.TabIndex = 23;
            this.txtAVG.Tag = "ColourMe";
            this.txtAVG.Text = "#";
            this.txtAVG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.Location = new System.Drawing.Point(37, 25);
            this.txtMax.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.txtMax.Multiline = true;
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(45, 15);
            this.txtMax.TabIndex = 22;
            this.txtMax.Tag = "ColourMe";
            this.txtMax.Text = "#";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAVG
            // 
            this.lblAVG.AutoSize = true;
            this.lblAVG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAVG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAVG.Location = new System.Drawing.Point(1, 43);
            this.lblAVG.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblAVG.Name = "lblAVG";
            this.lblAVG.Size = new System.Drawing.Size(36, 21);
            this.lblAVG.TabIndex = 12;
            this.lblAVG.Text = "AVG";
            this.lblAVG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(1, 22);
            this.lblMax.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(36, 21);
            this.lblMax.TabIndex = 10;
            this.lblMax.Text = "Max";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.Location = new System.Drawing.Point(37, 4);
            this.txtMin.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.txtMin.Multiline = true;
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(45, 15);
            this.txtMin.TabIndex = 9;
            this.txtMin.Tag = "ColourMe";
            this.txtMin.Text = "#";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(1, 1);
            this.lblMin.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(36, 21);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStandardDev
            // 
            this.lblStandardDev.AutoSize = true;
            this.lblStandardDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStandardDev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardDev.Location = new System.Drawing.Point(1, 64);
            this.lblStandardDev.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblStandardDev.Name = "lblStandardDev";
            this.lblStandardDev.Size = new System.Drawing.Size(36, 20);
            this.lblStandardDev.TabIndex = 25;
            this.lblStandardDev.Text = "SrDev";
            this.lblStandardDev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCPK
            // 
            this.lblCPK.AutoSize = true;
            this.lblCPK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCPK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPK.Location = new System.Drawing.Point(1, 84);
            this.lblCPK.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblCPK.Name = "lblCPK";
            this.lblCPK.Size = new System.Drawing.Size(36, 20);
            this.lblCPK.TabIndex = 26;
            this.lblCPK.Text = "CPK";
            this.lblCPK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStandardDev
            // 
            this.txtStandardDev.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStandardDev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStandardDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStandardDev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStandardDev.Location = new System.Drawing.Point(37, 67);
            this.txtStandardDev.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.txtStandardDev.Multiline = true;
            this.txtStandardDev.Name = "txtStandardDev";
            this.txtStandardDev.ReadOnly = true;
            this.txtStandardDev.Size = new System.Drawing.Size(45, 14);
            this.txtStandardDev.TabIndex = 27;
            this.txtStandardDev.Tag = "ColourMe";
            this.txtStandardDev.Text = "#";
            this.txtStandardDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCPK
            // 
            this.txtCPK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCPK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCPK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCPK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPK.Location = new System.Drawing.Point(37, 87);
            this.txtCPK.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.txtCPK.Multiline = true;
            this.txtCPK.Name = "txtCPK";
            this.txtCPK.ReadOnly = true;
            this.txtCPK.Size = new System.Drawing.Size(45, 14);
            this.txtCPK.TabIndex = 28;
            this.txtCPK.Tag = "ColourMe";
            this.txtCPK.Text = "#";
            this.txtCPK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chbDistribution);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(3, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlOptions.Size = new System.Drawing.Size(90, 25);
            this.pnlOptions.TabIndex = 3;
            // 
            // chbDistribution
            // 
            this.chbDistribution.AutoSize = true;
            this.chbDistribution.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbDistribution.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDistribution.Location = new System.Drawing.Point(3, 3);
            this.chbDistribution.Name = "chbDistribution";
            this.chbDistribution.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.chbDistribution.Size = new System.Drawing.Size(87, 17);
            this.chbDistribution.TabIndex = 0;
            this.chbDistribution.Text = "Distribution";
            this.chbDistribution.UseVisualStyleBackColor = true;
            this.chbDistribution.CheckedChanged += new System.EventHandler(this.chbDistribution_CheckedChanged);
            // 
            // btnShowHide
            // 
            this.btnShowHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHide.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowHide.FlatAppearance.BorderSize = 0;
            this.btnShowHide.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnShowHide.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHide.Image = global::Elvis.Properties.Resources.HideButtonSmallVert;
            this.btnShowHide.Location = new System.Drawing.Point(0, 0);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(8, 170);
            this.btnShowHide.TabIndex = 4;
            this.btnShowHide.Tag = "Hide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            // 
            // TrendingChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.grpMain);
            this.Name = "TrendingChart";
            this.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Size = new System.Drawing.Size(788, 195);
            this.grpMain.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDist)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.grpStats.ResumeLayout(false);
            this.tblCodeAndPractices.ResumeLayout(false);
            this.tblCodeAndPractices.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.TableLayoutPanel tblCodeAndPractices;
        private System.Windows.Forms.TextBox txtAVG;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblAVG;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblStandardDev;
        private System.Windows.Forms.Label lblCPK;
        private System.Windows.Forms.TextBox txtStandardDev;
        private System.Windows.Forms.TextBox txtCPK;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox chbDistribution;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDist;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
