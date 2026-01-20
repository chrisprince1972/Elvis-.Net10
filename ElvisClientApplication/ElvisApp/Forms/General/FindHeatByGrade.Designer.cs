namespace Elvis.Forms.General
{
    partial class FindHeatByGrade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindHeatByGrade));
            this.grpFindHeat = new System.Windows.Forms.GroupBox();
            this.pnlGradeAndButtons = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpGrade = new System.Windows.Forms.GroupBox();
            this.ccbGrades = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.chbAllGrades = new System.Windows.Forms.CheckBox();
            this.elvisDateTimeRangeSelector = new Elvis.UserControls.Generic.ElvisDateTimeRangeSelector();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.HeatNumberSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultsClmHeatNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdvResultsClmGrades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultsClmProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.grpFindHeat.SuspendLayout();
            this.pnlGradeAndButtons.SuspendLayout();
            this.grpGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFindHeat
            // 
            this.grpFindHeat.Controls.Add(this.pnlGradeAndButtons);
            this.grpFindHeat.Controls.Add(this.elvisDateTimeRangeSelector);
            this.grpFindHeat.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFindHeat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFindHeat.Location = new System.Drawing.Point(6, 6);
            this.grpFindHeat.Name = "grpFindHeat";
            this.grpFindHeat.Padding = new System.Windows.Forms.Padding(6);
            this.grpFindHeat.Size = new System.Drawing.Size(577, 148);
            this.grpFindHeat.TabIndex = 0;
            this.grpFindHeat.TabStop = false;
            this.grpFindHeat.Text = "Search";
            // 
            // pnlGradeAndButtons
            // 
            this.pnlGradeAndButtons.Controls.Add(this.btnReset);
            this.pnlGradeAndButtons.Controls.Add(this.btnSearch);
            this.pnlGradeAndButtons.Controls.Add(this.grpGrade);
            this.pnlGradeAndButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGradeAndButtons.Location = new System.Drawing.Point(432, 20);
            this.pnlGradeAndButtons.Name = "pnlGradeAndButtons";
            this.pnlGradeAndButtons.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlGradeAndButtons.Size = new System.Drawing.Size(139, 122);
            this.pnlGradeAndButtons.TabIndex = 41;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(3, 74);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 24);
            this.btnReset.TabIndex = 39;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(3, 98);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 24);
            this.btnSearch.TabIndex = 40;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpGrade
            // 
            this.grpGrade.Controls.Add(this.ccbGrades);
            this.grpGrade.Controls.Add(this.chbAllGrades);
            this.grpGrade.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.grpGrade.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGrade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGrade.Location = new System.Drawing.Point(3, 0);
            this.grpGrade.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpGrade.Name = "grpGrade";
            this.grpGrade.Padding = new System.Windows.Forms.Padding(6, 6, 6, 8);
            this.grpGrade.Size = new System.Drawing.Size(136, 70);
            this.grpGrade.TabIndex = 38;
            this.grpGrade.TabStop = false;
            this.grpGrade.Text = "Grades";
            // 
            // ccbGrades
            // 
            this.ccbGrades.CheckOnClick = true;
            this.ccbGrades.Dock = System.Windows.Forms.DockStyle.Top;
            this.ccbGrades.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbGrades.DropDownHeight = 1;
            this.ccbGrades.Enabled = false;
            this.ccbGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbGrades.FormattingEnabled = true;
            this.ccbGrades.IntegralHeight = false;
            this.ccbGrades.Location = new System.Drawing.Point(6, 20);
            this.ccbGrades.Name = "ccbGrades";
            this.ccbGrades.Size = new System.Drawing.Size(124, 21);
            this.ccbGrades.TabIndex = 15;
            this.ccbGrades.ValueSeparator = ", ";
            // 
            // chbAllGrades
            // 
            this.chbAllGrades.AutoSize = true;
            this.chbAllGrades.Checked = true;
            this.chbAllGrades.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAllGrades.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chbAllGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllGrades.Location = new System.Drawing.Point(6, 45);
            this.chbAllGrades.Name = "chbAllGrades";
            this.chbAllGrades.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.chbAllGrades.Size = new System.Drawing.Size(124, 17);
            this.chbAllGrades.TabIndex = 14;
            this.chbAllGrades.Text = "Show All";
            this.chbAllGrades.UseVisualStyleBackColor = true;
            this.chbAllGrades.CheckedChanged += new System.EventHandler(this.chbAllGrades_CheckedChanged);
            // 
            // elvisDateTimeRangeSelector
            // 
            this.elvisDateTimeRangeSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.elvisDateTimeRangeSelector.Location = new System.Drawing.Point(6, 20);
            this.elvisDateTimeRangeSelector.Name = "elvisDateTimeRangeSelector";
            this.elvisDateTimeRangeSelector.Size = new System.Drawing.Size(426, 122);
            this.elvisDateTimeRangeSelector.TabIndex = 40;
            this.elvisDateTimeRangeSelector.OnChange += new System.EventHandler(this.elvisDateTimeRangeSelector_OnChange);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvResults.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResults.ColumnHeadersHeight = 25;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeatNumberSet,
            this.dgvResultsClmHeatNumber,
            this.gdvResultsClmGrades,
            this.dgvResultsClmProgram});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.GridColor = System.Drawing.Color.DimGray;
            this.dgvResults.Location = new System.Drawing.Point(6, 154);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResults.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResults.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvResults.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvResults.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(577, 364);
            this.dgvResults.TabIndex = 3;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellDoubleClick);
            // 
            // HeatNumberSet
            // 
            this.HeatNumberSet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HeatNumberSet.DataPropertyName = "HNS";
            this.HeatNumberSet.HeaderText = "HNS";
            this.HeatNumberSet.Name = "HeatNumberSet";
            this.HeatNumberSet.ReadOnly = true;
            this.HeatNumberSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HeatNumberSet.Width = 38;
            // 
            // dgvResultsClmHeatNumber
            // 
            this.dgvResultsClmHeatNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvResultsClmHeatNumber.DataPropertyName = "HeatNumber";
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.dgvResultsClmHeatNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResultsClmHeatNumber.FillWeight = 80F;
            this.dgvResultsClmHeatNumber.HeaderText = "Heat";
            this.dgvResultsClmHeatNumber.Name = "dgvResultsClmHeatNumber";
            this.dgvResultsClmHeatNumber.ReadOnly = true;
            this.dgvResultsClmHeatNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvResultsClmHeatNumber.ToolTipText = "Heat Number";
            this.dgvResultsClmHeatNumber.Width = 39;
            // 
            // gdvResultsClmGrades
            // 
            this.gdvResultsClmGrades.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gdvResultsClmGrades.DataPropertyName = "GradesAsString";
            this.gdvResultsClmGrades.FillWeight = 82.08122F;
            this.gdvResultsClmGrades.HeaderText = "Grades";
            this.gdvResultsClmGrades.Name = "gdvResultsClmGrades";
            this.gdvResultsClmGrades.ReadOnly = true;
            this.gdvResultsClmGrades.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gdvResultsClmGrades.ToolTipText = "Grades";
            // 
            // dgvResultsClmProgram
            // 
            this.dgvResultsClmProgram.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvResultsClmProgram.DataPropertyName = "ProgramNumber";
            this.dgvResultsClmProgram.FillWeight = 82.08122F;
            this.dgvResultsClmProgram.HeaderText = "Program";
            this.dgvResultsClmProgram.Name = "dgvResultsClmProgram";
            this.dgvResultsClmProgram.ReadOnly = true;
            this.dgvResultsClmProgram.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvResultsClmProgram.ToolTipText = "Program";
            this.dgvResultsClmProgram.Width = 58;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 32);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(474, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelect.Location = new System.Drawing.Point(368, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 26);
            this.btnSelect.TabIndex = 41;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FindHeatByGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(589, 552);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpFindHeat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindHeatByGrade";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 2);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Heat by Grade";
            this.Load += new System.EventHandler(this.FindHeatByGrade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindHeatByGrade_KeyDown);
            this.grpFindHeat.ResumeLayout(false);
            this.pnlGradeAndButtons.ResumeLayout(false);
            this.grpGrade.ResumeLayout(false);
            this.grpGrade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFindHeat;
        private System.Windows.Forms.DataGridView dgvResults;
        private UserControls.Generic.ElvisDateTimeRangeSelector elvisDateTimeRangeSelector;
        private System.Windows.Forms.Panel pnlGradeAndButtons;
        private System.Windows.Forms.GroupBox grpGrade;
        private Common.ThirdPartyControls.CheckedComboBox ccbGrades;
        private System.Windows.Forms.CheckBox chbAllGrades;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeatNumberSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultsClmHeatNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdvResultsClmGrades;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultsClmProgram;
    }
}