namespace Elvis.UserControls.CasterMachineCondition
{
    partial class UnitChangePrioritySingle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvUnitChnage = new System.Windows.Forms.DataGridView();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SegmentToRemove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SegmentToInstall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitChnage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Controls.Add(this.dgvUnitChnage);
            this.pnlMain.Location = new System.Drawing.Point(7, 16);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(490, 374);
            this.pnlMain.TabIndex = 8;
            // 
            // dgvUnitChnage
            // 
            this.dgvUnitChnage.AllowUserToAddRows = false;
            this.dgvUnitChnage.AllowUserToDeleteRows = false;
            this.dgvUnitChnage.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUnitChnage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnitChnage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUnitChnage.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUnitChnage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUnitChnage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvUnitChnage.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvUnitChnage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnitChnage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnitChnage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Priority,
            this.Position,
            this.SegmentToRemove,
            this.SegmentToInstall,
            this.ChangeReason});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnitChnage.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUnitChnage.EnableHeadersVisualStyles = false;
            this.dgvUnitChnage.GridColor = System.Drawing.Color.DimGray;
            this.dgvUnitChnage.Location = new System.Drawing.Point(3, 52);
            this.dgvUnitChnage.Name = "dgvUnitChnage";
            this.dgvUnitChnage.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnitChnage.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUnitChnage.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(1);
            this.dgvUnitChnage.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUnitChnage.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgvUnitChnage.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvUnitChnage.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvUnitChnage.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvUnitChnage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnitChnage.Size = new System.Drawing.Size(484, 304);
            this.dgvUnitChnage.TabIndex = 8;
            this.dgvUnitChnage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // Priority
            // 
            this.Priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Priority.DataPropertyName = "Priority";
            dataGridViewCellStyle3.NullValue = null;
            this.Priority.DefaultCellStyle = dataGridViewCellStyle3;
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Priority.ToolTipText = "Priority";
            this.Priority.Width = 53;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "StrandPosition";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // SegmentToRemove
            // 
            this.SegmentToRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SegmentToRemove.DataPropertyName = "SegmentToRemove";
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.SegmentToRemove.DefaultCellStyle = dataGridViewCellStyle4;
            this.SegmentToRemove.HeaderText = "Remove Seg";
            this.SegmentToRemove.Name = "SegmentToRemove";
            this.SegmentToRemove.ReadOnly = true;
            this.SegmentToRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SegmentToRemove.ToolTipText = "Segment to Remove";
            this.SegmentToRemove.Width = 86;
            // 
            // SegmentToInstall
            // 
            this.SegmentToInstall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SegmentToInstall.DataPropertyName = "SegmentToInstall";
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.SegmentToInstall.DefaultCellStyle = dataGridViewCellStyle5;
            this.SegmentToInstall.HeaderText = "Install Seg";
            this.SegmentToInstall.Name = "SegmentToInstall";
            this.SegmentToInstall.ReadOnly = true;
            this.SegmentToInstall.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SegmentToInstall.ToolTipText = "Segment To Install";
            this.SegmentToInstall.Width = 74;
            // 
            // ChangeReason
            // 
            this.ChangeReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChangeReason.DataPropertyName = "ChangeReason";
            this.ChangeReason.HeaderText = "Reason";
            this.ChangeReason.Name = "ChangeReason";
            this.ChangeReason.ReadOnly = true;
            this.ChangeReason.ToolTipText = "Reason";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 400);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit Change Monitoring";
            // 
            // UnitChangePrioritySingle
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "UnitChangePrioritySingle";
            this.Size = new System.Drawing.Size(506, 403);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitChnage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvUnitChnage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentToRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentToInstall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeReason;
    }
}
