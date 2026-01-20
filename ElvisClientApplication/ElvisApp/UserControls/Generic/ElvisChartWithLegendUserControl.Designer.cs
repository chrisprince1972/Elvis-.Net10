namespace Elvis.UserControls.Generic
{
    partial class ElvisChartWithLegendUserControl
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.pnlRest = new System.Windows.Forms.Panel();
            this.splitContainerLegend = new System.Windows.Forms.SplitContainer();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.grpValues = new System.Windows.Forms.GroupBox();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.lstSelection = new System.Windows.Forms.ListView();
            this.tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart = new Elvis.UserControls.Generic.ElvisChartUserControl();
            this.legendForChart = new Elvis.UserControls.Generic.LegendForChart();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlRest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLegend)).BeginInit();
            this.splitContainerLegend.Panel1.SuspendLayout();
            this.splitContainerLegend.Panel2.SuspendLayout();
            this.splitContainerLegend.SuspendLayout();
            this.grpLegend.SuspendLayout();
            this.grpValues.SuspendLayout();
            this.pnlSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.splitContainerMain);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChart.Location = new System.Drawing.Point(6, 6);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(800, 660);
            this.grpChart.TabIndex = 2;
            this.grpChart.TabStop = false;
            this.grpChart.Text = "Chart";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 16);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.pnlChart);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.pnlRest);
            this.splitContainerMain.Size = new System.Drawing.Size(794, 641);
            this.splitContainerMain.SplitterDistance = 611;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 2;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.pnlChart.Size = new System.Drawing.Size(611, 641);
            this.pnlChart.TabIndex = 7;
            // 
            // pnlRest
            // 
            this.pnlRest.AccessibleDescription = "";
            this.pnlRest.Controls.Add(this.splitContainerLegend);
            this.pnlRest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRest.Location = new System.Drawing.Point(0, 0);
            this.pnlRest.Name = "pnlRest";
            this.pnlRest.Padding = new System.Windows.Forms.Padding(1, 0, 3, 3);
            this.pnlRest.Size = new System.Drawing.Size(178, 641);
            this.pnlRest.TabIndex = 2;
            // 
            // splitContainerLegend
            // 
            this.splitContainerLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLegend.Location = new System.Drawing.Point(1, 0);
            this.splitContainerLegend.Name = "splitContainerLegend";
            this.splitContainerLegend.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLegend.Panel1
            // 
            this.splitContainerLegend.Panel1.Controls.Add(this.grpLegend);
            // 
            // splitContainerLegend.Panel2
            // 
            this.splitContainerLegend.Panel2.Controls.Add(this.grpValues);
            this.splitContainerLegend.Size = new System.Drawing.Size(174, 638);
            this.splitContainerLegend.SplitterDistance = 408;
            this.splitContainerLegend.TabIndex = 9;
            // 
            // grpLegend
            // 
            this.grpLegend.Controls.Add(this.legendForChart);
            this.grpLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpLegend.Location = new System.Drawing.Point(0, 0);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Padding = new System.Windows.Forms.Padding(12, 7, 6, 6);
            this.grpLegend.Size = new System.Drawing.Size(174, 408);
            this.grpLegend.TabIndex = 11;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Legend";
            // 
            // grpValues
            // 
            this.grpValues.Controls.Add(this.pnlSelection);
            this.grpValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpValues.Location = new System.Drawing.Point(0, 0);
            this.grpValues.Name = "grpValues";
            this.grpValues.Size = new System.Drawing.Size(174, 226);
            this.grpValues.TabIndex = 10;
            this.grpValues.TabStop = false;
            this.grpValues.Text = "Time Selected - ";
            // 
            // pnlSelection
            // 
            this.pnlSelection.AutoScroll = true;
            this.pnlSelection.Controls.Add(this.lstSelection);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelection.Location = new System.Drawing.Point(3, 16);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlSelection.Size = new System.Drawing.Size(168, 207);
            this.pnlSelection.TabIndex = 0;
            // 
            // lstSelection
            // 
            this.lstSelection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tag,
            this.value});
            this.lstSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelection.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelection.FullRowSelect = true;
            this.lstSelection.GridLines = true;
            this.lstSelection.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSelection.Location = new System.Drawing.Point(0, 1);
            this.lstSelection.MultiSelect = false;
            this.lstSelection.Name = "lstSelection";
            this.lstSelection.Size = new System.Drawing.Size(168, 206);
            this.lstSelection.TabIndex = 2;
            this.lstSelection.UseCompatibleStateImageBehavior = false;
            this.lstSelection.View = System.Windows.Forms.View.Details;
            // 
            // tag
            // 
            this.tag.Text = "";
            this.tag.Width = 113;
            // 
            // value
            // 
            this.value.Text = "";
            this.value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.value.Width = 67;
            // 
            // chart
            // 
            this.chart.BorderlineColor = System.Drawing.Color.DimGray;
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.IsHighContrast = false;
            legend1.BackColor = System.Drawing.Color.WhiteSmoke;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.ReversedSeriesOrder;
            legend1.Name = "Legend";
            legend1.Position.Auto = false;
            legend1.Position.Height = 5F;
            legend1.Position.Width = 99.5F;
            legend1.Position.X = 0.5F;
            legend1.Position.Y = 94.8F;
            this.chart.Legends.Add(legend1);
            this.chart.Loaded = false;
            this.chart.Location = new System.Drawing.Point(3, 3);
            this.chart.Name = "chart";
            this.chart.Padding = new System.Windows.Forms.Padding(3);
            this.chart.Size = new System.Drawing.Size(607, 635);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            // 
            // legendForChart
            // 
            this.legendForChart.BackColor = System.Drawing.SystemColors.Control;
            this.legendForChart.Cursor = System.Windows.Forms.Cursors.Default;
            this.legendForChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legendForChart.HighContrast = false;
            this.legendForChart.Location = new System.Drawing.Point(12, 20);
            this.legendForChart.Name = "legendForChart";
            this.legendForChart.Size = new System.Drawing.Size(156, 382);
            this.legendForChart.TabIndex = 0;
            // 
            // ElvisChartWithLegendUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpChart);
            this.Name = "ElvisChartWithLegendUserControl";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(812, 672);
            this.Load += new System.EventHandler(this.ElvisChartWithLegendUserControl_Load);
            this.grpChart.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlRest.ResumeLayout(false);
            this.splitContainerLegend.Panel1.ResumeLayout(false);
            this.splitContainerLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLegend)).EndInit();
            this.splitContainerLegend.ResumeLayout(false);
            this.grpLegend.ResumeLayout(false);
            this.grpValues.ResumeLayout(false);
            this.pnlSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        public ElvisChartUserControl chart;
        private System.Windows.Forms.Panel pnlRest;
        private System.Windows.Forms.SplitContainer splitContainerLegend;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.GroupBox grpValues;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.ListView lstSelection;
        private System.Windows.Forms.ColumnHeader tag;
        private System.Windows.Forms.ColumnHeader value;
        public System.Windows.Forms.GroupBox grpChart;
        public System.Windows.Forms.Panel pnlChart;
        private LegendForChart legendForChart;
    }
}
