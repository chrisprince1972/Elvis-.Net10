namespace Elvis.Forms.Reports.Miscasts
{
    partial class MiscastReportHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiscastReportHolder));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.miscastMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.miscastInvestigationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.miscastActionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.miscastWhyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.heatLogToolStripPrintLog = new System.Windows.Forms.ToolStripMenuItem();
            this.heatLogToolStripPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportExportViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.miscastReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlClose = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.miscastMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miscastInvestigationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miscastActionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miscastWhyBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // miscastMainBindingSource
            // 
            this.miscastMainBindingSource.DataSource = typeof(ElvisDataModel.EDMX.MiscastMain);
            // 
            // miscastInvestigationBindingSource
            // 
            this.miscastInvestigationBindingSource.DataSource = typeof(ElvisDataModel.EDMX.MiscastInvestigation);
            // 
            // miscastActionBindingSource
            // 
            this.miscastActionBindingSource.DataSource = typeof(ElvisDataModel.EDMX.MiscastAction);
            // 
            // miscastWhyBindingSource
            // 
            this.miscastWhyBindingSource.DataSource = typeof(ElvisDataModel.EDMX.MiscastWhy);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveCloseToolStripMenuItem,
            this.toolStripSeparator4,
            this.heatLogToolStripPrintLog,
            this.heatLogToolStripPrintPreview,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Visible = false;
            // 
            // saveCloseToolStripMenuItem
            // 
            this.saveCloseToolStripMenuItem.Enabled = false;
            this.saveCloseToolStripMenuItem.Name = "saveCloseToolStripMenuItem";
            this.saveCloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveCloseToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.saveCloseToolStripMenuItem.Text = "S&ave && Close";
            this.saveCloseToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(212, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // heatLogToolStripPrintLog
            // 
            this.heatLogToolStripPrintLog.Enabled = false;
            this.heatLogToolStripPrintLog.Image = ((System.Drawing.Image)(resources.GetObject("heatLogToolStripPrintLog.Image")));
            this.heatLogToolStripPrintLog.Name = "heatLogToolStripPrintLog";
            this.heatLogToolStripPrintLog.Size = new System.Drawing.Size(215, 22);
            this.heatLogToolStripPrintLog.Text = "Print";
            this.heatLogToolStripPrintLog.Visible = false;
            // 
            // heatLogToolStripPrintPreview
            // 
            this.heatLogToolStripPrintPreview.Enabled = false;
            this.heatLogToolStripPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("heatLogToolStripPrintPreview.Image")));
            this.heatLogToolStripPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heatLogToolStripPrintPreview.Name = "heatLogToolStripPrintPreview";
            this.heatLogToolStripPrintPreview.Size = new System.Drawing.Size(215, 22);
            this.heatLogToolStripPrintPreview.Text = "Print Pre&view";
            this.heatLogToolStripPrintPreview.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportExportViewMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "&View";
            // 
            // reportExportViewMenuItem
            // 
            this.reportExportViewMenuItem.CheckOnClick = true;
            this.reportExportViewMenuItem.Name = "reportExportViewMenuItem";
            this.reportExportViewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.reportExportViewMenuItem.Size = new System.Drawing.Size(214, 22);
            this.reportExportViewMenuItem.Text = "Report E&xport View";
            this.reportExportViewMenuItem.CheckedChanged += new System.EventHandler(this.reportExportViewToolStripMenuItem_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.miscastReportViewer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(746, 666);
            this.pnlMain.TabIndex = 0;
            // 
            // miscastReportViewer
            // 
            this.miscastReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscastReportViewer.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "MiscastDataSet";
            reportDataSource1.Value = this.miscastMainBindingSource;
            reportDataSource2.Name = "MiscastInvestigations";
            reportDataSource2.Value = this.miscastInvestigationBindingSource;
            reportDataSource3.Name = "MiscastActions";
            reportDataSource3.Value = this.miscastActionBindingSource;
            this.miscastReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.miscastReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.miscastReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.miscastReportViewer.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.Miscast.MiscastReport.rdlc";
            this.miscastReportViewer.Location = new System.Drawing.Point(0, 0);
            this.miscastReportViewer.Name = "miscastReportViewer";
            this.miscastReportViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.miscastReportViewer.Size = new System.Drawing.Size(746, 666);
            this.miscastReportViewer.TabIndex = 0;
            this.miscastReportViewer.Visible = false;
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.btnClose);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClose.Location = new System.Drawing.Point(0, 690);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Padding = new System.Windows.Forms.Padding(3, 3, 4, 3);
            this.pnlClose.Size = new System.Drawing.Size(746, 30);
            this.pnlClose.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(667, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MiscastReportHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(746, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlClose);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "MiscastReportHolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Miscast Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiscastReportHolder_FormClosing);
            this.Load += new System.EventHandler(this.MiscastReportHolder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MiscastReportHolder_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.miscastMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miscastInvestigationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miscastActionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miscastWhyBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlClose.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem heatLogToolStripPrintLog;
        private System.Windows.Forms.ToolStripMenuItem heatLogToolStripPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCloseToolStripMenuItem;
        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Button btnClose;
        private Microsoft.Reporting.WinForms.ReportViewer miscastReportViewer;
        private System.Windows.Forms.BindingSource miscastMainBindingSource;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportExportViewMenuItem;
        private System.Windows.Forms.BindingSource miscastInvestigationBindingSource;
        private System.Windows.Forms.BindingSource miscastActionBindingSource;
        private System.Windows.Forms.BindingSource miscastWhyBindingSource;
    }
}