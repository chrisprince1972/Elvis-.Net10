namespace Elvis.UserControls.HeatDetails
{
    partial class CasterTrendUserControl
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

            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chart = new Elvis.UserControls.Generic.ElvisChartWithLegendUserControl();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chart);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(815, 669);
            this.pnlMain.TabIndex = 3;
            // 
            // chart
            // 
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(815, 669);
            this.chart.TabIndex = 3;
            title3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            title3.Name = "title";
            title3.Position.Auto = false;
            title3.Position.Height = 3.08121F;
            title3.Position.Width = 94F;
            title3.Position.X = 3F;
            title3.Position.Y = 2F;
            title3.Text = "CC# - Heat #####";
            title4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            title4.Name = "fromTo";
            title4.Position.Auto = false;
            title4.Position.Height = 3.08121F;
            title4.Position.Width = 94F;
            title4.Position.X = 3F;
            title4.Position.Y = 5.5F;
            title4.Text = "Start HH:mm - End HH:mm";
            this.chart.chart.Titles.Add(title3);
            this.chart.chart.Titles.Add(title4);
            // 
            // CasterTrend2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "CasterTrend2";
            this.Size = new System.Drawing.Size(815, 669);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Elvis.UserControls.Generic.ElvisChartWithLegendUserControl chart;

    }
}
