namespace Elvis.UserControls.Tib
{
    partial class DelayDetailGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewDelays = new System.Windows.Forms.DataGridView();
            this.TibIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIBClassText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIBDisText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayReason1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayReason2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayReason3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayReason4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TibDelayIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelays)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvDelays
            // 
            this.dataGridViewDelays.AllowUserToAddRows = false;
            this.dataGridViewDelays.AllowUserToDeleteRows = false;
            this.dataGridViewDelays.AllowUserToResizeColumns = false;
            this.dataGridViewDelays.AllowUserToResizeRows = false;
            this.dataGridViewDelays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDelays.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDelays.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewDelays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDelays.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewDelays.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDelays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDelays.ColumnHeadersHeight = 25;
            this.dataGridViewDelays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewDelays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TibIndex,
            this.DelayColUnit,
            this.DelayNumber,
            this.DelayStart,
            this.DelayEnd,
            this.DelayDuration,
            this.PlantArea,
            this.TIBClassText,
            this.TIBDisText,
            this.DelayReason1,
            this.DelayReason2,
            this.DelayReason3,
            this.DelayReason4,
            this.UnitGroup,
            this.Category,
            this.Comment,
            this.TibDelayIndex});
            this.dataGridViewDelays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDelays.EnableHeadersVisualStyles = false;
            this.dataGridViewDelays.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewDelays.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDelays.MultiSelect = false;
            this.dataGridViewDelays.Name = "gdvDelays";
            this.dataGridViewDelays.ReadOnly = true;
            this.dataGridViewDelays.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDelays.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewDelays.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDelays.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewDelays.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dataGridViewDelays.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewDelays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDelays.Size = new System.Drawing.Size(1061, 204);
            this.dataGridViewDelays.TabIndex = 11;
            this.dataGridViewDelays.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDelays_DoubleClick);
            this.dataGridViewDelays.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewDelays_CellFormatting);
            this.dataGridViewDelays.SelectionChanged += new System.EventHandler(this.dataGridViewDelays_OnSelectionChange);
            this.dataGridViewDelays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewDelays_KeyDown);
            // 
            // TibIndex
            // 
            this.TibIndex.DataPropertyName = "TibIndex";
            this.TibIndex.HeaderText = "TibIndex";
            this.TibIndex.Name = "TibIndex";
            this.TibIndex.ReadOnly = true;
            this.TibIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TibIndex.Visible = false;
            // 
            // DelayColUnit
            // 
            this.DelayColUnit.DataPropertyName = "Unit";
            this.DelayColUnit.HeaderText = "Unit";
            this.DelayColUnit.Name = "DelayColUnit";
            this.DelayColUnit.ReadOnly = true;
            this.DelayColUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DelayColUnit.Visible = false;
            // 
            // DelayNumber
            // 
            this.DelayNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DelayNumber.DataPropertyName = "No";
            this.DelayNumber.FillWeight = 80F;
            this.DelayNumber.HeaderText = "No.";
            this.DelayNumber.Name = "DelayNumber";
            this.DelayNumber.ReadOnly = true;
            this.DelayNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DelayNumber.Width = 32;
            // 
            // DelayStart
            // 
            this.DelayStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DelayStart.DataPropertyName = "StartTime";
            this.DelayStart.FillWeight = 82.08122F;
            this.DelayStart.HeaderText = "Start Time";
            this.DelayStart.Name = "DelayStart";
            this.DelayStart.ReadOnly = true;
            this.DelayStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DelayStart.Visible = false;
            this.DelayStart.Width = 70;
            // 
            // DelayEnd
            // 
            this.DelayEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DelayEnd.DataPropertyName = "EndTime";
            this.DelayEnd.FillWeight = 82.08122F;
            this.DelayEnd.HeaderText = "End Time";
            this.DelayEnd.Name = "DelayEnd";
            this.DelayEnd.ReadOnly = true;
            this.DelayEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DelayEnd.Visible = false;
            this.DelayEnd.Width = 65;
            // 
            // DelayDuration
            // 
            this.DelayDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DelayDuration.DataPropertyName = "Duration";
            this.DelayDuration.FillWeight = 82.08122F;
            this.DelayDuration.HeaderText = "Duration";
            this.DelayDuration.Name = "DelayDuration";
            this.DelayDuration.ReadOnly = true;
            this.DelayDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DelayDuration.Width = 60;
            // 
            // PlantArea
            // 
            this.PlantArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlantArea.DataPropertyName = "PlantArea";
            this.PlantArea.HeaderText = "Plant Area";
            this.PlantArea.Name = "PlantArea";
            this.PlantArea.ReadOnly = true;
            this.PlantArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlantArea.Width = 71;
            // 
            // TIBClassText
            // 
            this.TIBClassText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TIBClassText.DataPropertyName = "DelayClass";
            this.TIBClassText.HeaderText = "Class";
            this.TIBClassText.Name = "TIBClassText";
            this.TIBClassText.ReadOnly = true;
            this.TIBClassText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TIBClassText.Width = 42;
            // 
            // TIBDisText
            // 
            this.TIBDisText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TIBDisText.DataPropertyName = "Discipline";
            dataGridViewCellStyle2.Format = "0.0";
            this.TIBDisText.DefaultCellStyle = dataGridViewCellStyle2;
            this.TIBDisText.FillWeight = 82.08122F;
            this.TIBDisText.HeaderText = "Discipline";
            this.TIBDisText.Name = "TIBDisText";
            this.TIBDisText.ReadOnly = true;
            this.TIBDisText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TIBDisText.Width = 67;
            // 
            // DelayReason1
            // 
            this.DelayReason1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DelayReason1.DataPropertyName = "Level1";
            dataGridViewCellStyle3.Format = "t";
            this.DelayReason1.DefaultCellStyle = dataGridViewCellStyle3;
            this.DelayReason1.FillWeight = 82.08122F;
            this.DelayReason1.HeaderText = "Level 1";
            this.DelayReason1.Name = "DelayReason1";
            this.DelayReason1.ReadOnly = true;
            this.DelayReason1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DelayReason2
            // 
            this.DelayReason2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DelayReason2.DataPropertyName = "Level2";
            dataGridViewCellStyle4.Format = "t";
            this.DelayReason2.DefaultCellStyle = dataGridViewCellStyle4;
            this.DelayReason2.FillWeight = 82.08122F;
            this.DelayReason2.HeaderText = "Level 2";
            this.DelayReason2.Name = "DelayReason2";
            this.DelayReason2.ReadOnly = true;
            this.DelayReason2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DelayReason3
            // 
            this.DelayReason3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DelayReason3.DataPropertyName = "Level3";
            dataGridViewCellStyle5.Format = "t";
            this.DelayReason3.DefaultCellStyle = dataGridViewCellStyle5;
            this.DelayReason3.FillWeight = 82.08122F;
            this.DelayReason3.HeaderText = "Level 3";
            this.DelayReason3.Name = "DelayReason3";
            this.DelayReason3.ReadOnly = true;
            this.DelayReason3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DelayReason4
            // 
            this.DelayReason4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DelayReason4.DataPropertyName = "Level4";
            this.DelayReason4.FillWeight = 82.08122F;
            this.DelayReason4.HeaderText = "Level 4";
            this.DelayReason4.Name = "DelayReason4";
            this.DelayReason4.ReadOnly = true;
            this.DelayReason4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UnitGroup
            // 
            this.UnitGroup.DataPropertyName = "UnitGroup";
            this.UnitGroup.HeaderText = "UnitGroup";
            this.UnitGroup.Name = "UnitGroup";
            this.UnitGroup.ReadOnly = true;
            this.UnitGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitGroup.Visible = false;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            dataGridViewCellStyle6.Format = "0.0";
            this.Category.DefaultCellStyle = dataGridViewCellStyle6;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Category.Visible = false;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "Comment";
            dataGridViewCellStyle7.Format = "0.0";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Comment.DefaultCellStyle = dataGridViewCellStyle7;
            this.Comment.FillWeight = 82.08122F;
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TibDelayIndex
            // 
            this.TibDelayIndex.DataPropertyName = "TibDelayIndex";
            this.TibDelayIndex.HeaderText = "TibDelayIndex";
            this.TibDelayIndex.Name = "TibDelayIndex";
            this.TibDelayIndex.ReadOnly = true;
            this.TibDelayIndex.Visible = false;
            // 
            // DelayDetailGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewDelays);
            this.Name = "DelayDetailGrid";
            this.Size = new System.Drawing.Size(1061, 204);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDelays;
        private System.Windows.Forms.DataGridViewTextBoxColumn TibIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIBClassText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIBDisText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayReason1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayReason2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayReason3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayReason4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn TibDelayIndex;
    }
}
