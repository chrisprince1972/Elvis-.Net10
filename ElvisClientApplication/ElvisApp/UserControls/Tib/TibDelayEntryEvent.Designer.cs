namespace Elvis.UserControls.Tib
{
    partial class TibDelayEntryEvent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DelayEntryEventMainPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treatmentsTreeView = new System.Windows.Forms.TreeView();
            this.treatmentDataGridView = new System.Windows.Forms.DataGridView();
            this.UnitTextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlannedDurationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualDurationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayEntryEventMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DelayEntryEventMainPanel
            // 
            this.DelayEntryEventMainPanel.Controls.Add(this.splitContainer1);
            this.DelayEntryEventMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DelayEntryEventMainPanel.Location = new System.Drawing.Point(0, 0);
            this.DelayEntryEventMainPanel.Name = "DelayEntryEventMainPanel";
            this.DelayEntryEventMainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.DelayEntryEventMainPanel.Size = new System.Drawing.Size(780, 160);
            this.DelayEntryEventMainPanel.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treatmentsTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treatmentDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(774, 154);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 0;
            // 
            // treatmentsTreeView
            // 
            this.treatmentsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treatmentsTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treatmentsTreeView.Location = new System.Drawing.Point(0, 0);
            this.treatmentsTreeView.Name = "treatmentsTreeView";
            this.treatmentsTreeView.Size = new System.Drawing.Size(197, 154);
            this.treatmentsTreeView.TabIndex = 0;
            this.treatmentsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treatmentsTreeView_AfterSelect);
            // 
            // treatmentDataGridView
            // 
            this.treatmentDataGridView.AllowUserToAddRows = false;
            this.treatmentDataGridView.AllowUserToDeleteRows = false;
            this.treatmentDataGridView.AllowUserToResizeColumns = false;
            this.treatmentDataGridView.AllowUserToResizeRows = false;
            this.treatmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.treatmentDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.treatmentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treatmentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.treatmentDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.treatmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.treatmentDataGridView.ColumnHeadersHeight = 25;
            this.treatmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.treatmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnitTextColumn,
            this.TreatmentColumn,
            this.StartTimeColumn,
            this.EndTimeColumn,
            this.PlannedDurationColumn,
            this.ActualDurationColumn});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.treatmentDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.treatmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treatmentDataGridView.EnableHeadersVisualStyles = false;
            this.treatmentDataGridView.GridColor = System.Drawing.Color.DimGray;
            this.treatmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.treatmentDataGridView.Name = "treatmentDataGridView";
            this.treatmentDataGridView.ReadOnly = true;
            this.treatmentDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.treatmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.treatmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.treatmentDataGridView.Size = new System.Drawing.Size(573, 154);
            this.treatmentDataGridView.TabIndex = 1;
            this.treatmentDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.treatmentDataGridView_CellFormatting);
            this.treatmentDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.treatmentDataGridView_DataBindingComplete);
            // 
            // UnitTextColumn
            // 
            this.UnitTextColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitTextColumn.DataPropertyName = "UnitText";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitTextColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.UnitTextColumn.FillWeight = 369.365F;
            this.UnitTextColumn.HeaderText = "Unit";
            this.UnitTextColumn.Name = "UnitTextColumn";
            this.UnitTextColumn.ReadOnly = true;
            this.UnitTextColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitTextColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitTextColumn.Width = 148;
            // 
            // TreatmentColumn
            // 
            this.TreatmentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TreatmentColumn.DataPropertyName = "TreatmentText";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreatmentColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.TreatmentColumn.FillWeight = 39.82216F;
            this.TreatmentColumn.HeaderText = "Treatment";
            this.TreatmentColumn.Name = "TreatmentColumn";
            this.TreatmentColumn.ReadOnly = true;
            this.TreatmentColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StartTimeColumn.DataPropertyName = "TimeStampStart";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = null;
            this.StartTimeColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.StartTimeColumn.FillWeight = 46.73182F;
            this.StartTimeColumn.HeaderText = "Start";
            this.StartTimeColumn.Name = "StartTimeColumn";
            this.StartTimeColumn.ReadOnly = true;
            this.StartTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StartTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTimeColumn.Width = 64;
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EndTimeColumn.DataPropertyName = "TimeStampEnd";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "t";
            dataGridViewCellStyle5.NullValue = null;
            this.EndTimeColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.EndTimeColumn.FillWeight = 47.34261F;
            this.EndTimeColumn.HeaderText = "End";
            this.EndTimeColumn.Name = "EndTimeColumn";
            this.EndTimeColumn.ReadOnly = true;
            this.EndTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EndTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndTimeColumn.Width = 64;
            // 
            // PlannedDurationColumn
            // 
            this.PlannedDurationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PlannedDurationColumn.DataPropertyName = "PlannedDuration";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.PlannedDurationColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.PlannedDurationColumn.FillWeight = 48.00741F;
            this.PlannedDurationColumn.HeaderText = "Planned Duration";
            this.PlannedDurationColumn.Name = "PlannedDurationColumn";
            this.PlannedDurationColumn.ReadOnly = true;
            this.PlannedDurationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PlannedDurationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlannedDurationColumn.Width = 116;
            // 
            // ActualDurationColumn
            // 
            this.ActualDurationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ActualDurationColumn.DataPropertyName = "ActualDuration";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.ActualDurationColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.ActualDurationColumn.FillWeight = 48.73096F;
            this.ActualDurationColumn.HeaderText = "Actual Duration";
            this.ActualDurationColumn.Name = "ActualDurationColumn";
            this.ActualDurationColumn.ReadOnly = true;
            this.ActualDurationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ActualDurationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ActualDurationColumn.Width = 116;
            // 
            // TibDelayEntryEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.DelayEntryEventMainPanel);
            this.Name = "TibDelayEntryEvent";
            this.Size = new System.Drawing.Size(780, 160);
            this.DelayEntryEventMainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treatmentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel DelayEntryEventMainPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treatmentsTreeView;
        private System.Windows.Forms.DataGridView treatmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitTextColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlannedDurationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualDurationColumn;
    }
}
