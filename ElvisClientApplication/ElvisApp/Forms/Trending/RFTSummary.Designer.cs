namespace Elvis.Forms.Trending
{
    partial class RFTSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFTSummary));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fowardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpRFT = new System.Windows.Forms.GroupBox();
            this.dgvRFTSummary = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSlabsMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPercRFT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC1SlabsMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC1PercRFT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC2SlabsMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC2PercRFT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC3SlabsMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC3PercRFT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripTimeControls = new System.Windows.Forms.ToolStrip();
            this.toolStripLastDay = new System.Windows.Forms.ToolStripButton();
            this.toolStripBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripForward = new System.Windows.Forms.ToolStripButton();
            this.pnlFooter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpRFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRFTSummary)).BeginInit();
            this.toolStripTimeControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(674, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 209);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.pnlFooter.Size = new System.Drawing.Size(752, 30);
            this.pnlFooter.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrint,
            this.menuPrintPreview,
            this.toolStripSeparator1,
            this.menuClose});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuPrint
            // 
            this.menuPrint.Image = ((System.Drawing.Image)(resources.GetObject("menuPrint.Image")));
            this.menuPrint.Name = "menuPrint";
            this.menuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuPrint.Size = new System.Drawing.Size(149, 22);
            this.menuPrint.Text = "&Print...";
            this.menuPrint.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // menuPrintPreview
            // 
            this.menuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("menuPrintPreview.Image")));
            this.menuPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuPrintPreview.Name = "menuPrintPreview";
            this.menuPrintPreview.Size = new System.Drawing.Size(149, 22);
            this.menuPrintPreview.Text = "Print Pre&view";
            this.menuPrintPreview.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // menuClose
            // 
            this.menuClose.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(149, 22);
            this.menuClose.Text = "&Close";
            this.menuClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastDayToolStripMenuItem,
            this.fowardToolStripMenuItem,
            this.backToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // lastDayToolStripMenuItem
            // 
            this.lastDayToolStripMenuItem.Name = "lastDayToolStripMenuItem";
            this.lastDayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.lastDayToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.lastDayToolStripMenuItem.Text = "Last Day";
            this.lastDayToolStripMenuItem.Click += new System.EventHandler(this.toolStripLastDay_Click);
            // 
            // fowardToolStripMenuItem
            // 
            this.fowardToolStripMenuItem.Enabled = false;
            this.fowardToolStripMenuItem.Name = "fowardToolStripMenuItem";
            this.fowardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fowardToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.fowardToolStripMenuItem.Text = "Forward";
            this.fowardToolStripMenuItem.Click += new System.EventHandler(this.toolStripForward_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.backToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.toolStripBack_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "BOS Plant - Current Schedule Screenshot";
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCharts_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpRFT);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 49);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlMain.Size = new System.Drawing.Size(752, 160);
            this.pnlMain.TabIndex = 5;
            // 
            // grpRFT
            // 
            this.grpRFT.Controls.Add(this.dgvRFTSummary);
            this.grpRFT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRFT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRFT.Location = new System.Drawing.Point(3, 6);
            this.grpRFT.Name = "grpRFT";
            this.grpRFT.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.grpRFT.Size = new System.Drawing.Size(746, 151);
            this.grpRFT.TabIndex = 3;
            this.grpRFT.TabStop = false;
            this.grpRFT.Text = "RFT Summary";
            // 
            // dgvRFTSummary
            // 
            this.dgvRFTSummary.AllowUserToAddRows = false;
            this.dgvRFTSummary.AllowUserToDeleteRows = false;
            this.dgvRFTSummary.AllowUserToResizeRows = false;
            this.dgvRFTSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRFTSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRFTSummary.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRFTSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRFTSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvRFTSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRFTSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRFTSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRFTSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.TotalSlabsMade,
            this.TotalPercRFT,
            this.CC1SlabsMade,
            this.CC1PercRFT,
            this.CC2SlabsMade,
            this.CC2PercRFT,
            this.CC3SlabsMade,
            this.CC3PercRFT});
            this.dgvRFTSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRFTSummary.EnableHeadersVisualStyles = false;
            this.dgvRFTSummary.GridColor = System.Drawing.Color.DimGray;
            this.dgvRFTSummary.Location = new System.Drawing.Point(3, 20);
            this.dgvRFTSummary.MultiSelect = false;
            this.dgvRFTSummary.Name = "dgvRFTSummary";
            this.dgvRFTSummary.ReadOnly = true;
            this.dgvRFTSummary.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRFTSummary.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRFTSummary.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRFTSummary.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRFTSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRFTSummary.Size = new System.Drawing.Size(740, 128);
            this.dgvRFTSummary.TabIndex = 2;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalSlabsMade
            // 
            this.TotalSlabsMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TotalSlabsMade.DataPropertyName = "TotalSlabsMade";
            this.TotalSlabsMade.FillWeight = 90F;
            this.TotalSlabsMade.HeaderText = "Total Slabs";
            this.TotalSlabsMade.Name = "TotalSlabsMade";
            this.TotalSlabsMade.ReadOnly = true;
            this.TotalSlabsMade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalSlabsMade.Width = 74;
            // 
            // TotalPercRFT
            // 
            this.TotalPercRFT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TotalPercRFT.DataPropertyName = "TotalPercRFT";
            this.TotalPercRFT.FillWeight = 90F;
            this.TotalPercRFT.HeaderText = "Total RFT %";
            this.TotalPercRFT.Name = "TotalPercRFT";
            this.TotalPercRFT.ReadOnly = true;
            this.TotalPercRFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalPercRFT.Width = 81;
            // 
            // CC1SlabsMade
            // 
            this.CC1SlabsMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CC1SlabsMade.DataPropertyName = "CC1SlabsMade";
            this.CC1SlabsMade.FillWeight = 90F;
            this.CC1SlabsMade.HeaderText = "CC1 Slabs";
            this.CC1SlabsMade.Name = "CC1SlabsMade";
            this.CC1SlabsMade.ReadOnly = true;
            this.CC1SlabsMade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CC1SlabsMade.Width = 66;
            // 
            // CC1PercRFT
            // 
            this.CC1PercRFT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CC1PercRFT.DataPropertyName = "CC1PercRFT";
            this.CC1PercRFT.FillWeight = 90F;
            this.CC1PercRFT.HeaderText = "CC1 RFT %";
            this.CC1PercRFT.Name = "CC1PercRFT";
            this.CC1PercRFT.ReadOnly = true;
            this.CC1PercRFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CC1PercRFT.Width = 73;
            // 
            // CC2SlabsMade
            // 
            this.CC2SlabsMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CC2SlabsMade.DataPropertyName = "CC2SlabsMade";
            this.CC2SlabsMade.FillWeight = 90F;
            this.CC2SlabsMade.HeaderText = "CC2 Slabs";
            this.CC2SlabsMade.Name = "CC2SlabsMade";
            this.CC2SlabsMade.ReadOnly = true;
            this.CC2SlabsMade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CC2SlabsMade.Width = 66;
            // 
            // CC2PercRFT
            // 
            this.CC2PercRFT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CC2PercRFT.DataPropertyName = "CC2PercRFT";
            this.CC2PercRFT.FillWeight = 90F;
            this.CC2PercRFT.HeaderText = "CC2 RFT %";
            this.CC2PercRFT.Name = "CC2PercRFT";
            this.CC2PercRFT.ReadOnly = true;
            this.CC2PercRFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CC2PercRFT.Width = 73;
            // 
            // CC3SlabsMade
            // 
            this.CC3SlabsMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CC3SlabsMade.DataPropertyName = "CC3SlabsMade";
            dataGridViewCellStyle2.NullValue = null;
            this.CC3SlabsMade.DefaultCellStyle = dataGridViewCellStyle2;
            this.CC3SlabsMade.FillWeight = 90F;
            this.CC3SlabsMade.HeaderText = "CC3 Slabs";
            this.CC3SlabsMade.Name = "CC3SlabsMade";
            this.CC3SlabsMade.ReadOnly = true;
            this.CC3SlabsMade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CC3SlabsMade.Width = 66;
            // 
            // CC3PercRFT
            // 
            this.CC3PercRFT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CC3PercRFT.DataPropertyName = "CC3PercRFT";
            this.CC3PercRFT.FillWeight = 90F;
            this.CC3PercRFT.HeaderText = "CC3 RFT %";
            this.CC3PercRFT.Name = "CC3PercRFT";
            this.CC3PercRFT.ReadOnly = true;
            this.CC3PercRFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CC3PercRFT.Width = 73;
            // 
            // toolStripTimeControls
            // 
            this.toolStripTimeControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLastDay,
            this.toolStripBack,
            this.toolStripForward});
            this.toolStripTimeControls.Location = new System.Drawing.Point(0, 24);
            this.toolStripTimeControls.Name = "toolStripTimeControls";
            this.toolStripTimeControls.Size = new System.Drawing.Size(752, 25);
            this.toolStripTimeControls.TabIndex = 13;
            this.toolStripTimeControls.Text = "Time Controls";
            // 
            // toolStripLastDay
            // 
            this.toolStripLastDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripLastDay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLastDay.Image")));
            this.toolStripLastDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLastDay.Name = "toolStripLastDay";
            this.toolStripLastDay.Size = new System.Drawing.Size(71, 22);
            this.toolStripLastDay.Text = "Last Day";
            this.toolStripLastDay.ToolTipText = "Last Day (Ctrl+L)";
            this.toolStripLastDay.Click += new System.EventHandler(this.toolStripLastDay_Click);
            // 
            // toolStripBack
            // 
            this.toolStripBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBack.Image")));
            this.toolStripBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBack.Name = "toolStripBack";
            this.toolStripBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripBack.ToolTipText = "Previous Day (Ctrl+B)";
            this.toolStripBack.Click += new System.EventHandler(this.toolStripBack_Click);
            // 
            // toolStripForward
            // 
            this.toolStripForward.Enabled = false;
            this.toolStripForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripForward.Image")));
            this.toolStripForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripForward.Name = "toolStripForward";
            this.toolStripForward.Size = new System.Drawing.Size(23, 22);
            this.toolStripForward.ToolTipText = "Next Day (Ctrl+F)";
            this.toolStripForward.Click += new System.EventHandler(this.toolStripForward_Click);
            this.toolStripForward.EnabledChanged += new System.EventHandler(this.toolStripForward_EnabledChanged);
            // 
            // RFTSummary
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(752, 239);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStripTimeControls);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "RFTSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFT Summary";
            this.Load += new System.EventHandler(this.RFTSummary_Load);
            this.pnlFooter.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpRFT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRFTSummary)).EndInit();
            this.toolStripTimeControls.ResumeLayout(false);
            this.toolStripTimeControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripMenuItem menuPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvRFTSummary;
        private System.Windows.Forms.ToolStrip toolStripTimeControls;
        private System.Windows.Forms.ToolStripButton toolStripBack;
        private System.Windows.Forms.ToolStripButton toolStripForward;
        private System.Windows.Forms.GroupBox grpRFT;
        private System.Windows.Forms.ToolStripButton toolStripLastDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSlabsMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPercRFT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC1SlabsMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC1PercRFT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC2SlabsMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC2PercRFT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC3SlabsMade;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC3PercRFT;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fowardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
    }
}