namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    partial class HeatLogDisplay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvHeatLog = new System.Windows.Forms.DataGridView();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeatLog)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainBase
            // 
            this.pnlMainBase.Size = new System.Drawing.Size(10, 10);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvHeatLog);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(939, 611);
            this.pnlMain.TabIndex = 1;
            // 
            // dgvHeatLog
            // 
            this.dgvHeatLog.AllowUserToAddRows = false;
            this.dgvHeatLog.AllowUserToDeleteRows = false;
            this.dgvHeatLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHeatLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHeatLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeatLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHeatLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHeatLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHeatLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHeatLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeatLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHeatLog.ColumnHeadersHeight = 25;
            this.dgvHeatLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHeatLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStamp,
            this.EventType});
            this.dgvHeatLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeatLog.EnableHeadersVisualStyles = false;
            this.dgvHeatLog.GridColor = System.Drawing.Color.DimGray;
            this.dgvHeatLog.Location = new System.Drawing.Point(0, 0);
            this.dgvHeatLog.MultiSelect = false;
            this.dgvHeatLog.Name = "dgvHeatLog";
            this.dgvHeatLog.ReadOnly = true;
            this.dgvHeatLog.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvHeatLog.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHeatLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHeatLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvHeatLog.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvHeatLog.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvHeatLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeatLog.Size = new System.Drawing.Size(939, 611);
            this.dgvHeatLog.TabIndex = 5;
            this.dgvHeatLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvHeatLog_CellDoubleClick);
            this.dgvHeatLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgvHeatLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvHeatLog_KeyDown);
            // 
            // TimeStamp
            // 
            this.TimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TimeStamp.DataPropertyName = "TimeStamp";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.TimeStamp.DefaultCellStyle = dataGridViewCellStyle3;
            this.TimeStamp.FillWeight = 30F;
            this.TimeStamp.HeaderText = "Time Created";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.ReadOnly = true;
            this.TimeStamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TimeStamp.Width = 87;
            // 
            // EventType
            // 
            this.EventType.DataPropertyName = "EventType";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.EventType.DefaultCellStyle = dataGridViewCellStyle4;
            this.EventType.FillWeight = 169.5432F;
            this.EventType.HeaderText = "Event Type";
            this.EventType.Name = "EventType";
            this.EventType.ReadOnly = true;
            this.EventType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // HeatLogDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "HeatLogDisplay";
            this.Size = new System.Drawing.Size(939, 611);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeatLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvHeatLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventType;

    }
}
