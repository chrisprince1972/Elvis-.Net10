namespace Elvis.UserControls.HeatDetails
{
    partial class HeatsPlannedVsActual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.totalPanel = new System.Windows.Forms.Panel();
            this.totalLabel = new System.Windows.Forms.Label();
            this.dataGridPanel = new System.Windows.Forms.Panel();
            this.heatsDataGridView = new System.Windows.Forms.DataGridView();
            this.casterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heatNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combinedWidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPanel.SuspendLayout();
            this.dataGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalPanel
            // 
            this.totalPanel.Controls.Add(this.totalLabel);
            this.totalPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.totalPanel.Location = new System.Drawing.Point(402, 0);
            this.totalPanel.Name = "totalPanel";
            this.totalPanel.Size = new System.Drawing.Size(26, 228);
            this.totalPanel.TabIndex = 0;
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(3, 212);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(19, 13);
            this.totalLabel.TabIndex = 0;
            this.totalLabel.Text = "99";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridPanel
            // 
            this.dataGridPanel.Controls.Add(this.heatsDataGridView);
            this.dataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPanel.Location = new System.Drawing.Point(0, 0);
            this.dataGridPanel.Name = "dataGridPanel";
            this.dataGridPanel.Size = new System.Drawing.Size(402, 228);
            this.dataGridPanel.TabIndex = 1;
            // 
            // heatsDataGridView
            // 
            this.heatsDataGridView.AllowUserToAddRows = false;
            this.heatsDataGridView.AllowUserToDeleteRows = false;
            this.heatsDataGridView.AllowUserToResizeColumns = false;
            this.heatsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.heatsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.heatsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.heatsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.casterColumn,
            this.heatNumberColumn,
            this.programNoColumn,
            this.gradeColumn,
            this.startTimeColumn,
            this.durationColumn,
            this.combinedWidthColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.heatsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.heatsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.heatsDataGridView.MultiSelect = false;
            this.heatsDataGridView.Name = "heatsDataGridView";
            this.heatsDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.heatsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.heatsDataGridView.RowHeadersVisible = false;
            this.heatsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.heatsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.heatsDataGridView.Size = new System.Drawing.Size(402, 228);
            this.heatsDataGridView.TabIndex = 0;
            this.heatsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.heatsDataGridView_CellFormatting);
            this.heatsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.heatsDataGridView_DataBindingComplete);
            // 
            // casterColumn
            // 
            this.casterColumn.DataPropertyName = "CasterName";
            this.casterColumn.HeaderText = "Caster";
            this.casterColumn.Name = "casterColumn";
            this.casterColumn.ReadOnly = true;
            this.casterColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.casterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.casterColumn.Width = 48;
            // 
            // heatNumberColumn
            // 
            this.heatNumberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.heatNumberColumn.DataPropertyName = "HeatNumber";
            this.heatNumberColumn.HeaderText = "Heat";
            this.heatNumberColumn.MinimumWidth = 50;
            this.heatNumberColumn.Name = "heatNumberColumn";
            this.heatNumberColumn.ReadOnly = true;
            this.heatNumberColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.heatNumberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // programNoColumn
            // 
            this.programNoColumn.DataPropertyName = "ProgramNumber";
            this.programNoColumn.HeaderText = "Program";
            this.programNoColumn.Name = "programNoColumn";
            this.programNoColumn.ReadOnly = true;
            this.programNoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.programNoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.programNoColumn.Width = 52;
            // 
            // gradeColumn
            // 
            this.gradeColumn.DataPropertyName = "Grade";
            this.gradeColumn.HeaderText = "Grade";
            this.gradeColumn.Name = "gradeColumn";
            this.gradeColumn.ReadOnly = true;
            this.gradeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gradeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gradeColumn.Width = 42;
            // 
            // startTimeColumn
            // 
            this.startTimeColumn.DataPropertyName = "StartTimeDisplayDate";
            this.startTimeColumn.HeaderText = "Start";
            this.startTimeColumn.Name = "startTimeColumn";
            this.startTimeColumn.ReadOnly = true;
            this.startTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.startTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.startTimeColumn.Width = 68;
            // 
            // durationColumn
            // 
            this.durationColumn.DataPropertyName = "Duration";
            this.durationColumn.HeaderText = "Duration";
            this.durationColumn.Name = "durationColumn";
            this.durationColumn.ReadOnly = true;
            this.durationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.durationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.durationColumn.Width = 50;
            // 
            // combinedWidthColumn
            // 
            this.combinedWidthColumn.DataPropertyName = "CombinedWidth";
            this.combinedWidthColumn.HeaderText = "Total Width";
            this.combinedWidthColumn.Name = "combinedWidthColumn";
            this.combinedWidthColumn.ReadOnly = true;
            this.combinedWidthColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.combinedWidthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.combinedWidthColumn.Width = 95;
            // 
            // HeatsPlannedVsActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dataGridPanel);
            this.Controls.Add(this.totalPanel);
            this.Name = "HeatsPlannedVsActual";
            this.Size = new System.Drawing.Size(428, 228);
            this.totalPanel.ResumeLayout(false);
            this.totalPanel.PerformLayout();
            this.dataGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heatsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel totalPanel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Panel dataGridPanel;
        private System.Windows.Forms.DataGridView heatsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn casterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heatNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn programNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn combinedWidthColumn;
    }
}
