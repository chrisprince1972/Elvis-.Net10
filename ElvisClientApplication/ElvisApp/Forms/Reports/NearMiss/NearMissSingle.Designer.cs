namespace Elvis.Forms.Reports.NearMiss
{
    partial class NearMissSingle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NearMissSingle));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bsSSNearMissActions = new System.Windows.Forms.BindingSource(this.components);
            this.bsSSNearMiss = new System.Windows.Forms.BindingSource(this.components);
            this.rptNearMiss = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bsSSNearMissActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSSNearMiss)).BeginInit();
            this.SuspendLayout();
            // 
            // bsSSNearMissActions
            // 
            this.bsSSNearMissActions.DataSource = typeof(ElvisDataModel.EDMX.SAS_NM_Actions);
            // 
            // bsSSNearMiss
            // 
            this.bsSSNearMiss.DataSource = typeof(ElvisDataModel.EDMX.SAS_NM_DataForElvis);
            // 
            // rptNearMiss
            // 
            resources.ApplyResources(this.rptNearMiss, "rptNearMiss");
            reportDataSource1.Name = "SSNearMissActions";
            reportDataSource1.Value = this.bsSSNearMissActions;
            reportDataSource2.Name = "SSNearMiss";
            reportDataSource2.Value = this.bsSSNearMiss;
            this.rptNearMiss.LocalReport.DataSources.Add(reportDataSource1);
            this.rptNearMiss.LocalReport.DataSources.Add(reportDataSource2);
            this.rptNearMiss.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.NearMiss.NearMissSingleReport.rdlc";
            this.rptNearMiss.Name = "rptNearMiss";
            // 
            // NearMissSingle
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptNearMiss);
            this.Name = "NearMissSingle";
            this.Load += new System.EventHandler(this.NearMiss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsSSNearMissActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSSNearMiss)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptNearMiss;
        private System.Windows.Forms.BindingSource bsSSNearMiss;
        private System.Windows.Forms.BindingSource bsSSNearMissActions;
    }
}