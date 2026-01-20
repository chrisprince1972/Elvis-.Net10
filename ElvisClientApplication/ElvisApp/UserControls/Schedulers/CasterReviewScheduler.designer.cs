namespace Elvis.UserControls
{
    partial class CasterReviewScheduler
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartHMBuffer = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllTrendsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHMBufferLinesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCastingRateLinesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showHideTargetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.chartHMBuffer)).BeginInit();
            this.chartContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduler
            // 
            this.scheduler.AppointmentBoxStyle = MLJSystems.Calendars.AppointmentBoxStyle.Individual;
            this.scheduler.ConnectorStyle = MLJSystems.Calendars.ConnectorStyle.DashLine;
            this.scheduler.HeaderStyle = MLJSystems.Calendars.ResourceSchedulerHeaderStyle.Ruler;
            this.scheduler.ImageAlign = MLJSystems.Calendars.ImageHAlign.Left;
            this.scheduler.Location = new System.Drawing.Point(0, 220);
            this.scheduler.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.scheduler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.scheduler.Size = new System.Drawing.Size(875, 386);
            this.scheduler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduler.WeekRule = System.Globalization.CalendarWeekRule.FirstDay;
            this.scheduler.AppointmentClick += new System.EventHandler<MLJSystems.Calendars.AppointmentClickEventArgs>(this.scheduler_AppointmentClick);
            this.scheduler.PaintAppointment += new MLJSystems.Calendars.PaintAppointmentEventHandler(this.scheduler_PaintAppointment);
            this.scheduler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseDoubleClick);
            this.scheduler.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseMove);
            this.scheduler.Resize += new System.EventHandler(this.scheduler_Resize);
            // 
            // chartHMBuffer
            // 
            this.chartHMBuffer.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisY.Interval = 500D;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsMarksNextToAxis = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            chartArea1.AxisY.LabelStyle.Interval = 500D;
            chartArea1.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 4000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.Title = "HM Stock";
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.AxisY2.Title = "Tonnes / Minute";
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 85F;
            chartArea1.Position.Width = 97F;
            chartArea1.Position.Y = 14F;
            this.chartHMBuffer.ChartAreas.Add(chartArea1);
            this.chartHMBuffer.ContextMenuStrip = this.chartContextMenuStrip;
            this.chartHMBuffer.Cursor = System.Windows.Forms.Cursors.Default;
            this.chartHMBuffer.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend1.Name = "hmLegend";
            legend1.Position.Auto = false;
            legend1.Position.Height = 10F;
            legend1.Position.Width = 40F;
            legend1.Position.X = 2F;
            legend1.Position.Y = 1F;
            legend1.ShadowOffset = 2;
            legend2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend2.Name = "castingRateLegend";
            legend2.Position.Auto = false;
            legend2.Position.Height = 10F;
            legend2.Position.Width = 25F;
            legend2.Position.X = 73F;
            legend2.Position.Y = 1F;
            legend2.ShadowOffset = 2;
            this.chartHMBuffer.Legends.Add(legend1);
            this.chartHMBuffer.Legends.Add(legend2);
            this.chartHMBuffer.Location = new System.Drawing.Point(0, 0);
            this.chartHMBuffer.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.chartHMBuffer.Name = "chartHMBuffer";
            this.chartHMBuffer.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "hmLegend";
            series1.Name = "HM Stock";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "hmLegend";
            series2.Name = "BF Output";
            this.chartHMBuffer.Series.Add(series1);
            this.chartHMBuffer.Series.Add(series2);
            this.chartHMBuffer.Size = new System.Drawing.Size(875, 216);
            this.chartHMBuffer.TabIndex = 5;
            this.chartHMBuffer.Text = "Hot Metal Buffer";
            title1.Name = "Title1";
            title1.Text = "Hot Metal Buffer & Tonnes per Minute Trend";
            this.chartHMBuffer.Titles.Add(title1);
            // 
            // chartContextMenuStrip
            // 
            this.chartContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllTrendsToolStripMenuItem,
            this.showHMBufferLinesOnlyToolStripMenuItem,
            this.showCastingRateLinesOnlyToolStripMenuItem,
            this.toolStripSeparator2,
            this.showHideTargetMenuItem});
            this.chartContextMenuStrip.Name = "chartContextMenuStrip";
            this.chartContextMenuStrip.Size = new System.Drawing.Size(231, 98);
            // 
            // showAllTrendsToolStripMenuItem
            // 
            this.showAllTrendsToolStripMenuItem.Name = "showAllTrendsToolStripMenuItem";
            this.showAllTrendsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.showAllTrendsToolStripMenuItem.Text = "Show All Trends";
            this.showAllTrendsToolStripMenuItem.Click += new System.EventHandler(this.showAllTrendsToolStripMenuItem_Click);
            // 
            // showHMBufferLinesOnlyToolStripMenuItem
            // 
            this.showHMBufferLinesOnlyToolStripMenuItem.Name = "showHMBufferLinesOnlyToolStripMenuItem";
            this.showHMBufferLinesOnlyToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.showHMBufferLinesOnlyToolStripMenuItem.Text = "Show HM Buffer Lines Only";
            this.showHMBufferLinesOnlyToolStripMenuItem.Click += new System.EventHandler(this.showHMBufferLinesOnlyToolStripMenuItem_Click);
            // 
            // showCastingRateLinesOnlyToolStripMenuItem
            // 
            this.showCastingRateLinesOnlyToolStripMenuItem.Name = "showCastingRateLinesOnlyToolStripMenuItem";
            this.showCastingRateLinesOnlyToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.showCastingRateLinesOnlyToolStripMenuItem.Text = "Show Casting Rate Lines Only";
            this.showCastingRateLinesOnlyToolStripMenuItem.Click += new System.EventHandler(this.showCastingRateLinesOnlyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // showHideTargetMenuItem
            // 
            this.showHideTargetMenuItem.Name = "showHideTargetMenuItem";
            this.showHideTargetMenuItem.ShowShortcutKeys = false;
            this.showHideTargetMenuItem.Size = new System.Drawing.Size(230, 22);
            this.showHideTargetMenuItem.Text = "Hide Target Line";
            this.showHideTargetMenuItem.Click += new System.EventHandler(this.showHideTargetMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 216);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(875, 4);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // CasterReviewScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.chartHMBuffer);
            this.Name = "CasterReviewScheduler";
            this.Controls.SetChildIndex(this.chartHMBuffer, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.scheduler, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chartHMBuffer)).EndInit();
            this.chartContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHMBuffer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip chartContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showHideTargetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllTrendsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHMBufferLinesOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCastingRateLinesOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
