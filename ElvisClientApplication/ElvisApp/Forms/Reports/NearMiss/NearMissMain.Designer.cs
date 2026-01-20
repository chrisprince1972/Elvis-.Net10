namespace Elvis.Forms.Reports.NearMiss
{
    partial class NearMissMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NearMissMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.nearmissBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRecordsReturned = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heatLogToolStripPrintLog = new System.Windows.Forms.ToolStripMenuItem();
            this.heatLogToolStripPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportExportViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.findReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlAdvancedSearch = new System.Windows.Forms.Panel();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.pnlDropDowns = new System.Windows.Forms.Panel();
            this.cmboStatus = new System.Windows.Forms.ComboBox();
            this.cmboRota = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboPriority = new System.Windows.Forms.ComboBox();
            this.cmboLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboInitiatorsName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboType = new System.Windows.Forms.ComboBox();
            this.pnlDateSelector = new System.Windows.Forms.Panel();
            this.elvisDateTimeRangeSelector = new Elvis.UserControls.Generic.ElvisDateTimeRangeSelector();
            this.grpNearMiss = new System.Windows.Forms.GroupBox();
            this.pnlGridview = new System.Windows.Forms.Panel();
            this.dgvNearMiss = new System.Windows.Forms.DataGridView();
            this.columnNearMissID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnInitiatorsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDescriptionOfAccident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGridviewButtons = new System.Windows.Forms.Panel();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.rptPrintExport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlResults = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nearmissBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlAdvancedSearch.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.pnlDropDowns.SuspendLayout();
            this.pnlDateSelector.SuspendLayout();
            this.grpNearMiss.SuspendLayout();
            this.pnlGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNearMiss)).BeginInit();
            this.pnlGridviewButtons.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // nearmissBindingSource
            // 
            this.nearmissBindingSource.DataSource = typeof(ElvisDataModel.EDMX.ClusterWW_SafetySystemsModel);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRecordsReturned});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRecordsReturned
            // 
            this.lblRecordsReturned.BackColor = System.Drawing.SystemColors.Control;
            this.lblRecordsReturned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRecordsReturned.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.lblRecordsReturned.Name = "lblRecordsReturned";
            this.lblRecordsReturned.Size = new System.Drawing.Size(110, 17);
            this.lblRecordsReturned.Text = "# Records Returned";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heatLogToolStripPrintLog,
            this.heatLogToolStripPrintPreview,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // heatLogToolStripPrintLog
            // 
            this.heatLogToolStripPrintLog.Image = ((System.Drawing.Image)(resources.GetObject("heatLogToolStripPrintLog.Image")));
            this.heatLogToolStripPrintLog.Name = "heatLogToolStripPrintLog";
            this.heatLogToolStripPrintLog.Size = new System.Drawing.Size(143, 22);
            this.heatLogToolStripPrintLog.Text = "&Print";
            this.heatLogToolStripPrintLog.Visible = false;
            // 
            // heatLogToolStripPrintPreview
            // 
            this.heatLogToolStripPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("heatLogToolStripPrintPreview.Image")));
            this.heatLogToolStripPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heatLogToolStripPrintPreview.Name = "heatLogToolStripPrintPreview";
            this.heatLogToolStripPrintPreview.Size = new System.Drawing.Size(143, 22);
            this.heatLogToolStripPrintPreview.Text = "Print Pre&view";
            this.heatLogToolStripPrintPreview.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
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
            this.reportExportViewMenuItem.Text = "&Report Export View";
            this.reportExportViewMenuItem.CheckedChanged += new System.EventHandler(this.reportExportViewToolStripMenuItem_CheckedChanged);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewReportToolStripMenuItem,
            this.editSelectedToolStripMenuItem,
            this.toolStripSeparator2,
            this.findReportToolStripMenuItem});
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Actions";
            // 
            // addNewReportToolStripMenuItem
            // 
            this.addNewReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewReportToolStripMenuItem.Image")));
            this.addNewReportToolStripMenuItem.Name = "addNewReportToolStripMenuItem";
            this.addNewReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.addNewReportToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.addNewReportToolStripMenuItem.Text = "Add &New...";
            this.addNewReportToolStripMenuItem.Visible = false;
            // 
            // editSelectedToolStripMenuItem
            // 
            this.editSelectedToolStripMenuItem.Enabled = false;
            this.editSelectedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editSelectedToolStripMenuItem.Image")));
            this.editSelectedToolStripMenuItem.Name = "editSelectedToolStripMenuItem";
            this.editSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.editSelectedToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.editSelectedToolStripMenuItem.Text = "&View Report...";
            this.editSelectedToolStripMenuItem.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // findReportToolStripMenuItem
            // 
            this.findReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("findReportToolStripMenuItem.Image")));
            this.findReportToolStripMenuItem.Name = "findReportToolStripMenuItem";
            this.findReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findReportToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.findReportToolStripMenuItem.Text = "Find by &DRF Number...";
            this.findReportToolStripMenuItem.Visible = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 24);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Size = new System.Drawing.Size(1016, 146);
            this.pnlFilter.TabIndex = 18;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.pnlButtons);
            this.grpFilter.Controls.Add(this.pnlAdvancedSearch);
            this.grpFilter.Controls.Add(this.pnlDateSelector);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(6, 6);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(6);
            this.grpFilter.Size = new System.Drawing.Size(1004, 134);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Search";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnReset);
            this.pnlButtons.Controls.Add(this.btnSearch);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(877, 20);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(120, 108);
            this.pnlButtons.TabIndex = 36;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(0, 62);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 23);
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(0, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlAdvancedSearch
            // 
            this.pnlAdvancedSearch.Controls.Add(this.grpFilters);
            this.pnlAdvancedSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAdvancedSearch.Location = new System.Drawing.Point(436, 20);
            this.pnlAdvancedSearch.Name = "pnlAdvancedSearch";
            this.pnlAdvancedSearch.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlAdvancedSearch.Size = new System.Drawing.Size(441, 108);
            this.pnlAdvancedSearch.TabIndex = 38;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.pnlDropDowns);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilters.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilters.Location = new System.Drawing.Point(0, 0);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(435, 108);
            this.grpFilters.TabIndex = 24;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // pnlDropDowns
            // 
            this.pnlDropDowns.Controls.Add(this.cmboStatus);
            this.pnlDropDowns.Controls.Add(this.cmboRota);
            this.pnlDropDowns.Controls.Add(this.label6);
            this.pnlDropDowns.Controls.Add(this.label1);
            this.pnlDropDowns.Controls.Add(this.cmboPriority);
            this.pnlDropDowns.Controls.Add(this.cmboLocation);
            this.pnlDropDowns.Controls.Add(this.label5);
            this.pnlDropDowns.Controls.Add(this.label2);
            this.pnlDropDowns.Controls.Add(this.cmboInitiatorsName);
            this.pnlDropDowns.Controls.Add(this.label3);
            this.pnlDropDowns.Controls.Add(this.label4);
            this.pnlDropDowns.Controls.Add(this.cmboType);
            this.pnlDropDowns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDropDowns.Location = new System.Drawing.Point(3, 17);
            this.pnlDropDowns.Name = "pnlDropDowns";
            this.pnlDropDowns.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlDropDowns.Size = new System.Drawing.Size(429, 88);
            this.pnlDropDowns.TabIndex = 12;
            this.pnlDropDowns.Visible = false;
            // 
            // cmboStatus
            // 
            this.cmboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmboStatus.FormattingEnabled = true;
            this.cmboStatus.Location = new System.Drawing.Point(232, 56);
            this.cmboStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cmboStatus.Name = "cmboStatus";
            this.cmboStatus.Size = new System.Drawing.Size(190, 21);
            this.cmboStatus.TabIndex = 15;
            // 
            // cmboRota
            // 
            this.cmboRota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboRota.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmboRota.FormattingEnabled = true;
            this.cmboRota.Location = new System.Drawing.Point(58, 31);
            this.cmboRota.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cmboRota.Name = "cmboRota";
            this.cmboRota.Size = new System.Drawing.Size(118, 21);
            this.cmboRota.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(188, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Location";
            // 
            // cmboPriority
            // 
            this.cmboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboPriority.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmboPriority.FormattingEnabled = true;
            this.cmboPriority.Location = new System.Drawing.Point(232, 31);
            this.cmboPriority.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cmboPriority.Name = "cmboPriority";
            this.cmboPriority.Size = new System.Drawing.Size(190, 21);
            this.cmboPriority.TabIndex = 13;
            // 
            // cmboLocation
            // 
            this.cmboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmboLocation.FormattingEnabled = true;
            this.cmboLocation.Location = new System.Drawing.Point(58, 6);
            this.cmboLocation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cmboLocation.Name = "cmboLocation";
            this.cmboLocation.Size = new System.Drawing.Size(118, 21);
            this.cmboLocation.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Priority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rota";
            // 
            // cmboInitiatorsName
            // 
            this.cmboInitiatorsName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboInitiatorsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboInitiatorsName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmboInitiatorsName.FormattingEnabled = true;
            this.cmboInitiatorsName.Location = new System.Drawing.Point(232, 6);
            this.cmboInitiatorsName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cmboInitiatorsName.Name = "cmboInitiatorsName";
            this.cmboInitiatorsName.Size = new System.Drawing.Size(190, 21);
            this.cmboInitiatorsName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Initiator";
            // 
            // cmboType
            // 
            this.cmboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmboType.FormattingEnabled = true;
            this.cmboType.Location = new System.Drawing.Point(58, 56);
            this.cmboType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cmboType.Name = "cmboType";
            this.cmboType.Size = new System.Drawing.Size(118, 21);
            this.cmboType.TabIndex = 9;
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.elvisDateTimeRangeSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDateSelector.Location = new System.Drawing.Point(6, 20);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(430, 108);
            this.pnlDateSelector.TabIndex = 34;
            // 
            // elvisDateTimeRangeSelector
            // 
            this.elvisDateTimeRangeSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elvisDateTimeRangeSelector.Location = new System.Drawing.Point(0, 0);
            this.elvisDateTimeRangeSelector.Name = "elvisDateTimeRangeSelector";
            this.elvisDateTimeRangeSelector.Size = new System.Drawing.Size(424, 108);
            this.elvisDateTimeRangeSelector.TabIndex = 42;
            // 
            // grpNearMiss
            // 
            this.grpNearMiss.Controls.Add(this.pnlGridview);
            this.grpNearMiss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNearMiss.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNearMiss.Location = new System.Drawing.Point(6, 0);
            this.grpNearMiss.Name = "grpNearMiss";
            this.grpNearMiss.Size = new System.Drawing.Size(1004, 536);
            this.grpNearMiss.TabIndex = 12;
            this.grpNearMiss.TabStop = false;
            this.grpNearMiss.Text = "NearMiss Reports";
            // 
            // pnlGridview
            // 
            this.pnlGridview.Controls.Add(this.dgvNearMiss);
            this.pnlGridview.Controls.Add(this.pnlGridviewButtons);
            this.pnlGridview.Controls.Add(this.rptPrintExport);
            this.pnlGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridview.Location = new System.Drawing.Point(3, 17);
            this.pnlGridview.Name = "pnlGridview";
            this.pnlGridview.Padding = new System.Windows.Forms.Padding(6, 2, 6, 6);
            this.pnlGridview.Size = new System.Drawing.Size(998, 516);
            this.pnlGridview.TabIndex = 20;
            // 
            // dgvNearMiss
            // 
            this.dgvNearMiss.AllowUserToAddRows = false;
            this.dgvNearMiss.AllowUserToDeleteRows = false;
            this.dgvNearMiss.AllowUserToResizeRows = false;
            this.dgvNearMiss.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNearMiss.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNearMiss.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvNearMiss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNearMiss.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvNearMiss.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNearMiss.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNearMiss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNearMiss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNearMissID,
            this.columnInitiatorsName,
            this.columnDate,
            this.columnMPriority,
            this.columnStatus,
            this.columnLocation,
            this.columnDescriptionOfAccident});
            this.dgvNearMiss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNearMiss.EnableHeadersVisualStyles = false;
            this.dgvNearMiss.GridColor = System.Drawing.Color.DimGray;
            this.dgvNearMiss.Location = new System.Drawing.Point(6, 38);
            this.dgvNearMiss.MultiSelect = false;
            this.dgvNearMiss.Name = "dgvNearMiss";
            this.dgvNearMiss.ReadOnly = true;
            this.dgvNearMiss.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNearMiss.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvNearMiss.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNearMiss.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNearMiss.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvNearMiss.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvNearMiss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNearMiss.Size = new System.Drawing.Size(986, 472);
            this.dgvNearMiss.TabIndex = 11;
            this.dgvNearMiss.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNearMiss_CellDoubleClick);
            this.dgvNearMiss.SelectionChanged += new System.EventHandler(this.dgvNearMiss_SelectionChanged);
            this.dgvNearMiss.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvNearMiss_KeyDown);
            // 
            // columnNearMissID
            // 
            this.columnNearMissID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.columnNearMissID.DataPropertyName = "No";
            dataGridViewCellStyle2.NullValue = "-";
            this.columnNearMissID.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnNearMissID.HeaderText = "No.";
            this.columnNearMissID.Name = "columnNearMissID";
            this.columnNearMissID.ReadOnly = true;
            this.columnNearMissID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnNearMissID.Width = 29;
            // 
            // columnInitiatorsName
            // 
            this.columnInitiatorsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.columnInitiatorsName.DataPropertyName = "Initiator";
            dataGridViewCellStyle3.NullValue = "-";
            this.columnInitiatorsName.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnInitiatorsName.HeaderText = "Initiator";
            this.columnInitiatorsName.Name = "columnInitiatorsName";
            this.columnInitiatorsName.ReadOnly = true;
            this.columnInitiatorsName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnInitiatorsName.Width = 59;
            // 
            // columnDate
            // 
            this.columnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.columnDate.DataPropertyName = "Date";
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = "-";
            this.columnDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnDate.FillWeight = 80F;
            this.columnDate.HeaderText = "Date";
            this.columnDate.Name = "columnDate";
            this.columnDate.ReadOnly = true;
            this.columnDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnDate.Width = 39;
            // 
            // columnMPriority
            // 
            this.columnMPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.columnMPriority.DataPropertyName = "Priority";
            dataGridViewCellStyle5.NullValue = "-";
            this.columnMPriority.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnMPriority.FillWeight = 82.08122F;
            this.columnMPriority.HeaderText = "Priority";
            this.columnMPriority.Name = "columnMPriority";
            this.columnMPriority.ReadOnly = true;
            this.columnMPriority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnMPriority.Width = 54;
            // 
            // columnStatus
            // 
            this.columnStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.columnStatus.DataPropertyName = "Status";
            dataGridViewCellStyle6.NullValue = "-";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnStatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnStatus.FillWeight = 82.08122F;
            this.columnStatus.HeaderText = "Status";
            this.columnStatus.MinimumWidth = 55;
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.ReadOnly = true;
            this.columnStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnStatus.Width = 55;
            // 
            // columnLocation
            // 
            this.columnLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.columnLocation.DataPropertyName = "Location";
            dataGridViewCellStyle7.NullValue = "-";
            this.columnLocation.DefaultCellStyle = dataGridViewCellStyle7;
            this.columnLocation.HeaderText = "Location";
            this.columnLocation.Name = "columnLocation";
            this.columnLocation.ReadOnly = true;
            this.columnLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnLocation.Width = 60;
            // 
            // columnDescriptionOfAccident
            // 
            this.columnDescriptionOfAccident.DataPropertyName = "Description";
            this.columnDescriptionOfAccident.HeaderText = "Description";
            this.columnDescriptionOfAccident.Name = "columnDescriptionOfAccident";
            this.columnDescriptionOfAccident.ReadOnly = true;
            // 
            // pnlGridviewButtons
            // 
            this.pnlGridviewButtons.Controls.Add(this.btnViewReport);
            this.pnlGridviewButtons.Controls.Add(this.lblToDate);
            this.pnlGridviewButtons.Controls.Add(this.lblFromDate);
            this.pnlGridviewButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridviewButtons.Location = new System.Drawing.Point(6, 2);
            this.pnlGridviewButtons.Name = "pnlGridviewButtons";
            this.pnlGridviewButtons.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlGridviewButtons.Size = new System.Drawing.Size(986, 36);
            this.pnlGridviewButtons.TabIndex = 0;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewReport.Enabled = false;
            this.btnViewReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnViewReport.Image = ((System.Drawing.Image)(resources.GetObject("btnViewReport.Image")));
            this.btnViewReport.Location = new System.Drawing.Point(879, 0);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnViewReport.Size = new System.Drawing.Size(107, 32);
            this.btnViewReport.TabIndex = 22;
            this.btnViewReport.Text = "&View Report...";
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(170, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.lblToDate.Size = new System.Drawing.Size(176, 32);
            this.lblToDate.TabIndex = 21;
            this.lblToDate.Text = "To - ";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(0, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.lblFromDate.Size = new System.Drawing.Size(170, 32);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "From -";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rptPrintExport
            // 
            reportDataSource1.Name = "dsNearMissData";
            reportDataSource1.Value = this.nearmissBindingSource;
            this.rptPrintExport.LocalReport.DataSources.Add(reportDataSource1);
            this.rptPrintExport.LocalReport.ReportEmbeddedResource = "Elvis.Forms.Reports.RDLC.NearMiss.NearMissReport.rdlc";
            this.rptPrintExport.Location = new System.Drawing.Point(6, 38);
            this.rptPrintExport.Name = "rptPrintExport";
            this.rptPrintExport.Size = new System.Drawing.Size(983, 476);
            this.rptPrintExport.TabIndex = 12;
            // 
            // pnlResults
            // 
            this.pnlResults.Controls.Add(this.grpNearMiss);
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResults.Location = new System.Drawing.Point(0, 170);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.pnlResults.Size = new System.Drawing.Size(1016, 542);
            this.pnlResults.TabIndex = 19;
            // 
            // NearMissMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "NearMissMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NearMiss Reports";
            this.Load += new System.EventHandler(this.NearMissMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NearMissMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nearmissBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlAdvancedSearch.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.pnlDropDowns.ResumeLayout(false);
            this.pnlDropDowns.PerformLayout();
            this.pnlDateSelector.ResumeLayout(false);
            this.grpNearMiss.ResumeLayout(false);
            this.pnlGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNearMiss)).EndInit();
            this.pnlGridviewButtons.ResumeLayout(false);
            this.pnlResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heatLogToolStripPrintLog;
        private System.Windows.Forms.ToolStripMenuItem heatLogToolStripPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlDateSelector;
        private System.Windows.Forms.Panel pnlAdvancedSearch;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboLocation;
        private System.Windows.Forms.ComboBox cmboType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmboRota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboInitiatorsName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmboPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNearMiss;
        private System.Windows.Forms.Panel pnlGridview;
        private System.Windows.Forms.DataGridView dgvNearMiss;
        private System.Windows.Forms.Panel pnlGridviewButtons;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordsReturned;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem findReportToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmboStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlDropDowns;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportExportViewMenuItem;
        private Microsoft.Reporting.WinForms.ReportViewer rptPrintExport;
        private System.Windows.Forms.BindingSource nearmissBindingSource;
        private UserControls.Generic.ElvisDateTimeRangeSelector elvisDateTimeRangeSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNearMissID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnInitiatorsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDescriptionOfAccident;
    }
}