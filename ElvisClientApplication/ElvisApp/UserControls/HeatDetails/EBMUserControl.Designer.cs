namespace Elvis.UserControls.HeatDetails
{
    partial class EBMUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EBMUserControl));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucEBMData = new Elvis.UserControls.HeatDetails.EBMDataUserControl();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chart = new Elvis.UserControls.Generic.ElvisChartUserControl();
            this.pnlEBMOptions = new System.Windows.Forms.Panel();
            this.grpRefresh = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpColourScheme = new System.Windows.Forms.GroupBox();
            this.rbEBMHighContrastColour = new System.Windows.Forms.RadioButton();
            this.rbEBMDefaultColour = new System.Windows.Forms.RadioButton();
            this.splitContainerLegend = new System.Windows.Forms.SplitContainer();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.legendForChart = new Elvis.UserControls.Generic.LegendForChart();
            this.grpValues = new System.Windows.Forms.GroupBox();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.lstSelection = new System.Windows.Forms.ListView();
            this.tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpChart.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.pnlEBMOptions.SuspendLayout();
            this.grpRefresh.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpColourScheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLegend)).BeginInit();
            this.splitContainerLegend.Panel1.SuspendLayout();
            this.splitContainerLegend.Panel2.SuspendLayout();
            this.splitContainerLegend.SuspendLayout();
            this.grpLegend.SuspendLayout();
            this.grpValues.SuspendLayout();
            this.pnlSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer2);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1212, 666);
            this.pnlMain.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainerLegend);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.splitContainer2.Size = new System.Drawing.Size(1212, 666);
            this.splitContainer2.SplitterDistance = 537;
            this.splitContainer2.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucEBMData);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 1, 0);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpChart);
            this.splitContainer1.Panel2.Controls.Add(this.pnlEBMOptions);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1212, 537);
            this.splitContainer1.SplitterDistance = 522;
            this.splitContainer1.TabIndex = 8;
            // 
            // ucEBMData
            // 
            this.ucEBMData.AutoSize = true;
            this.ucEBMData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucEBMData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucEBMData.ColourScheme = "Default";
            this.ucEBMData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEBMData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucEBMData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucEBMData.Location = new System.Drawing.Point(3, 3);
            this.ucEBMData.Name = "ucEBMData";
            this.ucEBMData.Size = new System.Drawing.Size(518, 534);
            this.ucEBMData.TabIndex = 0;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.pnlChart);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChart.Location = new System.Drawing.Point(0, 57);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(683, 480);
            this.grpChart.TabIndex = 10;
            this.grpChart.TabStop = false;
            this.grpChart.Text = "Chart";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 17);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(3);
            this.pnlChart.Size = new System.Drawing.Size(677, 460);
            this.pnlChart.TabIndex = 8;
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
            this.chart.Size = new System.Drawing.Size(671, 454);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            // 
            // pnlEBMOptions
            // 
            this.pnlEBMOptions.Controls.Add(this.grpRefresh);
            this.pnlEBMOptions.Controls.Add(this.panel3);
            this.pnlEBMOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEBMOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlEBMOptions.Name = "pnlEBMOptions";
            this.pnlEBMOptions.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.pnlEBMOptions.Size = new System.Drawing.Size(683, 57);
            this.pnlEBMOptions.TabIndex = 9;
            // 
            // grpRefresh
            // 
            this.grpRefresh.Controls.Add(this.btnRefresh);
            this.grpRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRefresh.Location = new System.Drawing.Point(177, 3);
            this.grpRefresh.Name = "grpRefresh";
            this.grpRefresh.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.grpRefresh.Size = new System.Drawing.Size(44, 51);
            this.grpRefresh.TabIndex = 2;
            this.grpRefresh.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(5, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 33);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefreshEBM_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpColourScheme);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.panel3.Size = new System.Drawing.Size(177, 51);
            this.panel3.TabIndex = 1;
            // 
            // grpColourScheme
            // 
            this.grpColourScheme.Controls.Add(this.rbEBMHighContrastColour);
            this.grpColourScheme.Controls.Add(this.rbEBMDefaultColour);
            this.grpColourScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColourScheme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpColourScheme.Location = new System.Drawing.Point(0, 0);
            this.grpColourScheme.Name = "grpColourScheme";
            this.grpColourScheme.Padding = new System.Windows.Forms.Padding(12, 2, 3, 3);
            this.grpColourScheme.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpColourScheme.Size = new System.Drawing.Size(171, 51);
            this.grpColourScheme.TabIndex = 0;
            this.grpColourScheme.TabStop = false;
            this.grpColourScheme.Text = "Colour Scheme";
            // 
            // rbEBMHighContrastColour
            // 
            this.rbEBMHighContrastColour.AutoSize = true;
            this.rbEBMHighContrastColour.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEBMHighContrastColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEBMHighContrastColour.Location = new System.Drawing.Point(75, 16);
            this.rbEBMHighContrastColour.Name = "rbEBMHighContrastColour";
            this.rbEBMHighContrastColour.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.rbEBMHighContrastColour.Size = new System.Drawing.Size(94, 32);
            this.rbEBMHighContrastColour.TabIndex = 1;
            this.rbEBMHighContrastColour.Tag = "High Contrast";
            this.rbEBMHighContrastColour.Text = "High Contrast";
            this.rbEBMHighContrastColour.UseVisualStyleBackColor = true;
            this.rbEBMHighContrastColour.CheckedChanged += new System.EventHandler(this.rbEBMColour_CheckedChanged);
            // 
            // rbEBMDefaultColour
            // 
            this.rbEBMDefaultColour.AutoSize = true;
            this.rbEBMDefaultColour.Checked = true;
            this.rbEBMDefaultColour.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEBMDefaultColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEBMDefaultColour.Location = new System.Drawing.Point(12, 16);
            this.rbEBMDefaultColour.Name = "rbEBMDefaultColour";
            this.rbEBMDefaultColour.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.rbEBMDefaultColour.Size = new System.Drawing.Size(63, 32);
            this.rbEBMDefaultColour.TabIndex = 0;
            this.rbEBMDefaultColour.TabStop = true;
            this.rbEBMDefaultColour.Tag = "Default";
            this.rbEBMDefaultColour.Text = "Default";
            this.rbEBMDefaultColour.UseVisualStyleBackColor = true;
            this.rbEBMDefaultColour.CheckedChanged += new System.EventHandler(this.rbEBMColour_CheckedChanged);
            // 
            // splitContainerLegend
            // 
            this.splitContainerLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLegend.Location = new System.Drawing.Point(3, 0);
            this.splitContainerLegend.Name = "splitContainerLegend";
            // 
            // splitContainerLegend.Panel1
            // 
            this.splitContainerLegend.Panel1.Controls.Add(this.grpLegend);
            // 
            // splitContainerLegend.Panel2
            // 
            this.splitContainerLegend.Panel2.Controls.Add(this.grpValues);
            this.splitContainerLegend.Size = new System.Drawing.Size(1206, 122);
            this.splitContainerLegend.SplitterDistance = 974;
            this.splitContainerLegend.SplitterWidth = 6;
            this.splitContainerLegend.TabIndex = 10;
            // 
            // grpLegend
            // 
            this.grpLegend.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpLegend.Controls.Add(this.legendForChart);
            this.grpLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLegend.Location = new System.Drawing.Point(0, 0);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Padding = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.grpLegend.Size = new System.Drawing.Size(974, 122);
            this.grpLegend.TabIndex = 14;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Legend";
            // 
            // legendForChart
            // 
            this.legendForChart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.legendForChart.Cursor = System.Windows.Forms.Cursors.Default;
            this.legendForChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legendForChart.HighContrast = false;
            this.legendForChart.Location = new System.Drawing.Point(10, 24);
            this.legendForChart.Name = "legendForChart";
            this.legendForChart.Size = new System.Drawing.Size(961, 95);
            this.legendForChart.TabIndex = 3;
            // 
            // grpValues
            // 
            this.grpValues.Controls.Add(this.pnlSelection);
            this.grpValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpValues.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpValues.Location = new System.Drawing.Point(0, 0);
            this.grpValues.Name = "grpValues";
            this.grpValues.Size = new System.Drawing.Size(226, 122);
            this.grpValues.TabIndex = 10;
            this.grpValues.TabStop = false;
            this.grpValues.Text = "Time Selected - ";
            // 
            // pnlSelection
            // 
            this.pnlSelection.AutoScroll = true;
            this.pnlSelection.Controls.Add(this.lstSelection);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelection.Location = new System.Drawing.Point(3, 17);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlSelection.Size = new System.Drawing.Size(220, 102);
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
            this.lstSelection.Size = new System.Drawing.Size(220, 101);
            this.lstSelection.TabIndex = 2;
            this.lstSelection.UseCompatibleStateImageBehavior = false;
            this.lstSelection.View = System.Windows.Forms.View.Details;
            // 
            // tag
            // 
            this.tag.Text = "";
            this.tag.Width = 130;
            // 
            // value
            // 
            this.value.Text = "";
            this.value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.value.Width = 67;
            // 
            // EBMUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "EBMUserControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1218, 672);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.pnlEBMOptions.ResumeLayout(false);
            this.grpRefresh.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpColourScheme.ResumeLayout(false);
            this.grpColourScheme.PerformLayout();
            this.splitContainerLegend.Panel1.ResumeLayout(false);
            this.splitContainerLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLegend)).EndInit();
            this.splitContainerLegend.ResumeLayout(false);
            this.grpLegend.ResumeLayout(false);
            this.grpValues.ResumeLayout(false);
            this.pnlSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private EBMDataUserControl ucEBMData;
        public System.Windows.Forms.GroupBox grpChart;
        public System.Windows.Forms.Panel pnlChart;
        public Generic.ElvisChartUserControl chart;
        private System.Windows.Forms.Panel pnlEBMOptions;
        private System.Windows.Forms.GroupBox grpRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grpColourScheme;
        private System.Windows.Forms.RadioButton rbEBMHighContrastColour;
        private System.Windows.Forms.RadioButton rbEBMDefaultColour;
        private System.Windows.Forms.SplitContainer splitContainerLegend;
        private System.Windows.Forms.GroupBox grpValues;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.ListView lstSelection;
        private System.Windows.Forms.ColumnHeader tag;
        private System.Windows.Forms.ColumnHeader value;
        public System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpLegend;
        private Generic.LegendForChart legendForChart;



    }
}
