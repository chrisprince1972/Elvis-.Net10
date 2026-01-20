namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    partial class InjectionDetails
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvInjection = new System.Windows.Forms.DataGridView();
            this.dgvInjectionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInjectionMgDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInjectionMgActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInjectionLimeDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInjectionLimeActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInjection)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvInjection);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(401, 149);
            this.pnlMain.TabIndex = 10;
            // 
            // dgvInjection
            // 
            this.dgvInjection.AllowUserToAddRows = false;
            this.dgvInjection.AllowUserToDeleteRows = false;
            this.dgvInjection.AllowUserToOrderColumns = true;
            this.dgvInjection.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInjection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInjection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInjection.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInjection.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInjection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInjection.CausesValidation = false;
            this.dgvInjection.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvInjection.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvInjection.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInjection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInjection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvInjectionTime,
            this.dgvInjectionMgDemand,
            this.dgvInjectionMgActual,
            this.dgvInjectionLimeDemand,
            this.dgvInjectionLimeActual});
            this.dgvInjection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInjection.EnableHeadersVisualStyles = false;
            this.dgvInjection.GridColor = System.Drawing.Color.DimGray;
            this.dgvInjection.Location = new System.Drawing.Point(0, 0);
            this.dgvInjection.Name = "dgvInjection";
            this.dgvInjection.ReadOnly = true;
            this.dgvInjection.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            this.dgvInjection.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInjection.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgvInjection.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvInjection.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvInjection.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvInjection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInjection.Size = new System.Drawing.Size(401, 149);
            this.dgvInjection.TabIndex = 9;
            this.dgvInjection.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // dgvInjectionTime
            // 
            this.dgvInjectionTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvInjectionTime.DataPropertyName = "TimeAsString";
            this.dgvInjectionTime.HeaderText = "Time";
            this.dgvInjectionTime.Name = "dgvInjectionTime";
            this.dgvInjectionTime.ReadOnly = true;
            this.dgvInjectionTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvInjectionTime.Width = 41;
            // 
            // dgvInjectionMgDemand
            // 
            this.dgvInjectionMgDemand.DataPropertyName = "MgDemand";
            this.dgvInjectionMgDemand.HeaderText = "Mg Demand";
            this.dgvInjectionMgDemand.Name = "dgvInjectionMgDemand";
            this.dgvInjectionMgDemand.ReadOnly = true;
            this.dgvInjectionMgDemand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvInjectionMgActual
            // 
            this.dgvInjectionMgActual.DataPropertyName = "MgActual";
            this.dgvInjectionMgActual.HeaderText = "Mg Actual";
            this.dgvInjectionMgActual.Name = "dgvInjectionMgActual";
            this.dgvInjectionMgActual.ReadOnly = true;
            this.dgvInjectionMgActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvInjectionLimeDemand
            // 
            this.dgvInjectionLimeDemand.DataPropertyName = "LimeDemand";
            this.dgvInjectionLimeDemand.HeaderText = "Lime Demand";
            this.dgvInjectionLimeDemand.Name = "dgvInjectionLimeDemand";
            this.dgvInjectionLimeDemand.ReadOnly = true;
            this.dgvInjectionLimeDemand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvInjectionLimeActual
            // 
            this.dgvInjectionLimeActual.DataPropertyName = "LimeActual";
            this.dgvInjectionLimeActual.HeaderText = "Lime Actual";
            this.dgvInjectionLimeActual.Name = "dgvInjectionLimeActual";
            this.dgvInjectionLimeActual.ReadOnly = true;
            this.dgvInjectionLimeActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InjectionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "InjectionDetails";
            this.Size = new System.Drawing.Size(401, 149);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInjection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvInjection;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInjectionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInjectionMgDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInjectionMgActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInjectionLimeDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInjectionLimeActual;

    }
}
