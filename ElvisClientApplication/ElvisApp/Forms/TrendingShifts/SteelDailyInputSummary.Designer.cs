namespace Elvis.Forms.TrendingShifts
{
    partial class SteelDailyInputSummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SteelDailyInputSummary));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpSteelInputs = new System.Windows.Forms.GroupBox();
            this.pnlGridview = new System.Windows.Forms.Panel();
            this.dgvManDailyInputs = new System.Windows.Forms.DataGridView();
            this.DayDateIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BFOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpPracticeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGridviewButtons = new System.Windows.Forms.Panel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpSteelInputs.SuspendLayout();
            this.pnlGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManDailyInputs)).BeginInit();
            this.pnlGridviewButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpSteelInputs);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(378, 266);
            this.pnlMain.TabIndex = 20;
            // 
            // grpSteelInputs
            // 
            this.grpSteelInputs.Controls.Add(this.pnlGridview);
            this.grpSteelInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSteelInputs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSteelInputs.Location = new System.Drawing.Point(6, 6);
            this.grpSteelInputs.Name = "grpSteelInputs";
            this.grpSteelInputs.Size = new System.Drawing.Size(366, 254);
            this.grpSteelInputs.TabIndex = 12;
            this.grpSteelInputs.TabStop = false;
            this.grpSteelInputs.Text = "Steelmaking Daily Inputs";
            // 
            // pnlGridview
            // 
            this.pnlGridview.Controls.Add(this.dgvManDailyInputs);
            this.pnlGridview.Controls.Add(this.pnlGridviewButtons);
            this.pnlGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridview.Location = new System.Drawing.Point(3, 17);
            this.pnlGridview.Name = "pnlGridview";
            this.pnlGridview.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.pnlGridview.Size = new System.Drawing.Size(360, 234);
            this.pnlGridview.TabIndex = 20;
            // 
            // dgvManDailyInputs
            // 
            this.dgvManDailyInputs.AllowUserToAddRows = false;
            this.dgvManDailyInputs.AllowUserToDeleteRows = false;
            this.dgvManDailyInputs.AllowUserToResizeRows = false;
            this.dgvManDailyInputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManDailyInputs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvManDailyInputs.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvManDailyInputs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvManDailyInputs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvManDailyInputs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManDailyInputs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManDailyInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManDailyInputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DayDateIndex,
            this.DayDate,
            this.BFOutput,
            this.OpPracticeText});
            this.dgvManDailyInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManDailyInputs.EnableHeadersVisualStyles = false;
            this.dgvManDailyInputs.GridColor = System.Drawing.Color.DimGray;
            this.dgvManDailyInputs.Location = new System.Drawing.Point(6, 30);
            this.dgvManDailyInputs.MultiSelect = false;
            this.dgvManDailyInputs.Name = "dgvManDailyInputs";
            this.dgvManDailyInputs.ReadOnly = true;
            this.dgvManDailyInputs.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvManDailyInputs.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvManDailyInputs.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvManDailyInputs.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvManDailyInputs.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvManDailyInputs.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvManDailyInputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManDailyInputs.Size = new System.Drawing.Size(348, 198);
            this.dgvManDailyInputs.TabIndex = 11;
            this.dgvManDailyInputs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManDailyInputs_CellDoubleClick);
            this.dgvManDailyInputs.SelectionChanged += new System.EventHandler(this.dgvManDailyInputs_SelectionChanged);
            this.dgvManDailyInputs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvManDailyInputs_KeyDown);
            // 
            // DayDateIndex
            // 
            this.DayDateIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DayDateIndex.DataPropertyName = "DayDateIndex";
            dataGridViewCellStyle2.NullValue = "-";
            this.DayDateIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.DayDateIndex.HeaderText = "Index";
            this.DayDateIndex.Name = "DayDateIndex";
            this.DayDateIndex.ReadOnly = true;
            this.DayDateIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DayDateIndex.Width = 45;
            // 
            // DayDate
            // 
            this.DayDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DayDate.DataPropertyName = "DayDate";
            dataGridViewCellStyle3.NullValue = "-";
            this.DayDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.DayDate.HeaderText = "Date";
            this.DayDate.Name = "DayDate";
            this.DayDate.ReadOnly = true;
            this.DayDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DayDate.Width = 39;
            // 
            // BFOutput
            // 
            this.BFOutput.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BFOutput.DataPropertyName = "BFOutput";
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = "-";
            this.BFOutput.DefaultCellStyle = dataGridViewCellStyle4;
            this.BFOutput.FillWeight = 80F;
            this.BFOutput.HeaderText = "BF Output";
            this.BFOutput.Name = "BFOutput";
            this.BFOutput.ReadOnly = true;
            this.BFOutput.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BFOutput.Width = 67;
            // 
            // OpPracticeText
            // 
            this.OpPracticeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OpPracticeText.DataPropertyName = "OpPracticeText";
            dataGridViewCellStyle5.NullValue = "-";
            this.OpPracticeText.DefaultCellStyle = dataGridViewCellStyle5;
            this.OpPracticeText.FillWeight = 82.08122F;
            this.OpPracticeText.HeaderText = "Op. Practice ";
            this.OpPracticeText.Name = "OpPracticeText";
            this.OpPracticeText.ReadOnly = true;
            this.OpPracticeText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlGridviewButtons
            // 
            this.pnlGridviewButtons.Controls.Add(this.lblFromDate);
            this.pnlGridviewButtons.Controls.Add(this.btnAdd);
            this.pnlGridviewButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridviewButtons.Location = new System.Drawing.Point(6, 0);
            this.pnlGridviewButtons.Name = "pnlGridviewButtons";
            this.pnlGridviewButtons.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlGridviewButtons.Size = new System.Drawing.Size(348, 30);
            this.pnlGridviewButtons.TabIndex = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(0, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.lblFromDate.Size = new System.Drawing.Size(231, 26);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "Showing records from the last 7 days.";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(252, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(96, 26);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add &New...";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // SteelDailyInputSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 266);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SteelDailyInputSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steelmaking Daily Input Summary";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SteelDailyInputSummary_KeyDown);
            this.pnlMain.ResumeLayout(false);
            this.grpSteelInputs.ResumeLayout(false);
            this.pnlGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManDailyInputs)).EndInit();
            this.pnlGridviewButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpSteelInputs;
        private System.Windows.Forms.Panel pnlGridview;
        private System.Windows.Forms.DataGridView dgvManDailyInputs;
        private System.Windows.Forms.Panel pnlGridviewButtons;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayDateIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BFOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpPracticeText;
    }
}