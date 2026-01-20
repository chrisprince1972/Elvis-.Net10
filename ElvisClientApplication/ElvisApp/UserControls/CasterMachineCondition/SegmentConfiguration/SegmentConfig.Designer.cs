namespace Elvis.UserControls.CasterMachineCondition
{
    partial class SegmentConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvSegConfig = new System.Windows.Forms.DataGridView();
            this.SegmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SnapShotIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrandPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateInstall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysInService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonnesCast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlannedTonnage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedsReplacingTonnage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Controls.Add(this.dgvSegConfig);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(360, 370);
            this.pnlMain.TabIndex = 8;
            // 
            // dgvSegConfig
            // 
            this.dgvSegConfig.AllowUserToAddRows = false;
            this.dgvSegConfig.AllowUserToDeleteRows = false;
            this.dgvSegConfig.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSegConfig.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSegConfig.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSegConfig.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSegConfig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSegConfig.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSegConfig.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvSegConfig.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSegConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSegConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SegmentName,
            this.SnapShotIndex,
            this.StrandPosition,
            this.DateInstall,
            this.DaysInService,
            this.TonnesCast,
            this.PlannedTonnage,
            this.NeedsReplacingTonnage});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSegConfig.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSegConfig.EnableHeadersVisualStyles = false;
            this.dgvSegConfig.GridColor = System.Drawing.Color.DimGray;
            this.dgvSegConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvSegConfig.Name = "dgvSegConfig";
            this.dgvSegConfig.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSegConfig.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSegConfig.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(1);
            this.dgvSegConfig.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSegConfig.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgvSegConfig.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSegConfig.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvSegConfig.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvSegConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSegConfig.Size = new System.Drawing.Size(358, 368);
            this.dgvSegConfig.TabIndex = 8;
            this.dgvSegConfig.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSegConfig_CellFormatting);
            this.dgvSegConfig.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // SegmentName
            // 
            this.SegmentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SegmentName.DataPropertyName = "SegmentName";
            this.SegmentName.HeaderText = "Segment";
            this.SegmentName.Name = "SegmentName";
            this.SegmentName.ReadOnly = true;
            // 
            // SnapShotIndex
            // 
            this.SnapShotIndex.DataPropertyName = "SnapShotIndex";
            this.SnapShotIndex.HeaderText = "SnapShotIndex";
            this.SnapShotIndex.Name = "SnapShotIndex";
            this.SnapShotIndex.ReadOnly = true;
            this.SnapShotIndex.Visible = false;
            // 
            // StrandPosition
            // 
            this.StrandPosition.DataPropertyName = "StrandPosition";
            this.StrandPosition.HeaderText = "Position";
            this.StrandPosition.Name = "StrandPosition";
            this.StrandPosition.ReadOnly = true;
            this.StrandPosition.ToolTipText = "Strand Position";
            this.StrandPosition.Width = 55;
            // 
            // DateInstall
            // 
            this.DateInstall.DataPropertyName = "DateInstall";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DateInstall.DefaultCellStyle = dataGridViewCellStyle3;
            this.DateInstall.HeaderText = "Date Installed";
            this.DateInstall.Name = "DateInstall";
            this.DateInstall.ReadOnly = true;
            this.DateInstall.ToolTipText = "Date Installed";
            this.DateInstall.Width = 93;
            // 
            // DaysInService
            // 
            this.DaysInService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DaysInService.DataPropertyName = "DaysInService";
            dataGridViewCellStyle4.NullValue = null;
            this.DaysInService.DefaultCellStyle = dataGridViewCellStyle4;
            this.DaysInService.HeaderText = "Days";
            this.DaysInService.Name = "DaysInService";
            this.DaysInService.ReadOnly = true;
            this.DaysInService.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DaysInService.ToolTipText = "Days In Service";
            this.DaysInService.Width = 42;
            // 
            // TonnesCast
            // 
            this.TonnesCast.DataPropertyName = "TonnesCast";
            this.TonnesCast.HeaderText = "Tonnes";
            this.TonnesCast.Name = "TonnesCast";
            this.TonnesCast.ReadOnly = true;
            this.TonnesCast.ToolTipText = "Tonnes Cast";
            this.TonnesCast.Width = 50;
            // 
            // PlannedTonnage
            // 
            this.PlannedTonnage.DataPropertyName = "PlannedTonnage";
            this.PlannedTonnage.HeaderText = "PlannedTonnage";
            this.PlannedTonnage.Name = "PlannedTonnage";
            this.PlannedTonnage.ReadOnly = true;
            this.PlannedTonnage.Visible = false;
            // 
            // NeedsReplacingTonnage
            // 
            this.NeedsReplacingTonnage.DataPropertyName = "NeedsReplacingTonnage";
            this.NeedsReplacingTonnage.HeaderText = "NeedsReplacingTonnage";
            this.NeedsReplacingTonnage.Name = "NeedsReplacingTonnage";
            this.NeedsReplacingTonnage.ReadOnly = true;
            this.NeedsReplacingTonnage.Visible = false;
            // 
            // SegmentConfig
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlMain);
            this.Name = "SegmentConfig";
            this.Size = new System.Drawing.Size(363, 373);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvSegConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SnapShotIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrandPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateInstall;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysInService;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonnesCast;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlannedTonnage;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedsReplacingTonnage;
    }
}
