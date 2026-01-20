namespace Elvis.Forms.Reports.DRF
{
    partial class DRFReportExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRFReportExport));
            this.rptSingleReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DRFReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DRFReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptSingleReport
            // 
            this.rptSingleReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptSingleReport.DocumentMapWidth = 80;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DRFReportBindingSource;
            this.rptSingleReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rptSingleReport.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.DRF.DRFSingleReport.rdlc";
            this.rptSingleReport.Location = new System.Drawing.Point(0, 0);
            this.rptSingleReport.Margin = new System.Windows.Forms.Padding(0);
            this.rptSingleReport.Name = "rptSingleReport";
            this.rptSingleReport.Size = new System.Drawing.Size(747, 866);
            this.rptSingleReport.TabIndex = 0;
            // 
            // DRFReportBindingSource
            // 
            this.DRFReportBindingSource.DataSource = typeof(ElvisDataModel.EDMX.DRFReport);
            // 
            // SingleDrfReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 866);
            this.Controls.Add(this.rptSingleReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingleDrfReport";
            this.Text = "DRF Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DRFReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptSingleReport;
        private System.Windows.Forms.BindingSource DRFReportBindingSource;
    }
}