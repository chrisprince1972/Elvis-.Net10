namespace Elvis.UserControls.HeatDetails
{
    partial class TempGraphs
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grpProcessDetails = new System.Windows.Forms.GroupBox();
            this.pnlTempGraph = new System.Windows.Forms.Panel();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpProcessDetails.SuspendLayout();
            this.pnlTempGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProcessDetails
            // 
            this.grpProcessDetails.Controls.Add(this.pnlTempGraph);
            this.grpProcessDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcessDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProcessDetails.Location = new System.Drawing.Point(6, 6);
            this.grpProcessDetails.Margin = new System.Windows.Forms.Padding(0);
            this.grpProcessDetails.Name = "grpProcessDetails";
            this.grpProcessDetails.Padding = new System.Windows.Forms.Padding(6);
            this.grpProcessDetails.Size = new System.Drawing.Size(958, 318);
            this.grpProcessDetails.TabIndex = 8;
            this.grpProcessDetails.TabStop = false;
            this.grpProcessDetails.Text = "Temperature Details";
            // 
            // pnlTempGraph
            // 
            this.pnlTempGraph.Controls.Add(this.chartTemperature);
            this.pnlTempGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTempGraph.Location = new System.Drawing.Point(6, 20);
            this.pnlTempGraph.Name = "pnlTempGraph";
            this.pnlTempGraph.Size = new System.Drawing.Size(946, 292);
            this.pnlTempGraph.TabIndex = 1;
            // 
            // chartTemperature
            // 
            this.chartTemperature.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.Title = "Temperature (°C)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 88F;
            chartArea1.Position.Width = 95F;
            chartArea1.Position.Y = 10F;
            this.chartTemperature.ChartAreas.Add(chartArea1);
            this.chartTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 27F;
            legend1.Position.Width = 10.5F;
            legend1.Position.X = 89F;
            legend1.Position.Y = 1F;
            legend1.ShadowOffset = 2;
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(0, 0);
            this.chartTemperature.Name = "chartTemperature";
            this.chartTemperature.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Percent30;
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            series1.EmptyPointStyle.BorderWidth = 0;
            series1.EmptyPointStyle.MarkerBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.LegendText = "Caster Max Min";
            series1.LegendToolTip = "Maximum and Minimum Caster Temperature Values";
            series1.Name = "MaxMin";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 2;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendToolTip = "Actual Temperature Reading";
            series2.MarkerSize = 6;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Actual";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Green;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.LegendToolTip = "Planned Temperature Reading";
            series3.MarkerSize = 6;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series3.Name = "Planned";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartTemperature.Series.Add(series1);
            this.chartTemperature.Series.Add(series2);
            this.chartTemperature.Series.Add(series3);
            this.chartTemperature.Size = new System.Drawing.Size(946, 292);
            this.chartTemperature.TabIndex = 0;
            this.chartTemperature.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.DockedToChartArea = "ChartArea1";
            title1.DockingOffset = -2;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.IsDockedInsideChartArea = false;
            title1.Name = "tempTitle";
            title1.ShadowColor = System.Drawing.Color.Black;
            title1.ShadowOffset = 1;
            title1.Text = "Temperature Graph for Heat - ";
            title1.ToolTip = "Temperature Graph";
            this.chartTemperature.Titles.Add(title1);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpProcessDetails);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6, 6, 6, 2);
            this.pnlMain.Size = new System.Drawing.Size(970, 326);
            this.pnlMain.TabIndex = 1;
            // 
            // TempGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "TempGraphs";
            this.Size = new System.Drawing.Size(970, 326);
            this.grpProcessDetails.ResumeLayout(false);
            this.pnlTempGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProcessDetails;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.Panel pnlTempGraph;
        private System.Windows.Forms.Panel pnlMain;

    }
}
