namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    partial class DesulphModel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvHMDesModel = new System.Windows.Forms.DataGridView();
            this.dgvHMDesModelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelHMWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelHMTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelStartS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelAimHMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelAimSteelS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelEstInjTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelWtLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelTemperatureLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelTotalMg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHMDesModelTotalLime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHMDesModel)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvHMDesModel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1010, 192);
            this.pnlMain.TabIndex = 9;
            // 
            // dgvHMDesModel
            // 
            this.dgvHMDesModel.AllowUserToAddRows = false;
            this.dgvHMDesModel.AllowUserToDeleteRows = false;
            this.dgvHMDesModel.AllowUserToOrderColumns = true;
            this.dgvHMDesModel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHMDesModel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHMDesModel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHMDesModel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHMDesModel.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHMDesModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHMDesModel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHMDesModel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvHMDesModel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHMDesModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHMDesModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHMDesModelTime,
            this.dgvHMDesModelHMWeight,
            this.dgvHMDesModelHMTemperature,
            this.dgvHMDesModelStartS,
            this.dgvHMDesModelAimHMS,
            this.dgvHMDesModelAimSteelS,
            this.dgvHMDesModelType,
            this.dgvHMDesModelEstInjTime,
            this.dgvHMDesModelWtLoss,
            this.dgvHMDesModelTemperatureLoss,
            this.dgvHMDesModelTotalMg,
            this.dgvHMDesModelTotalLime});
            this.dgvHMDesModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHMDesModel.EnableHeadersVisualStyles = false;
            this.dgvHMDesModel.GridColor = System.Drawing.Color.DimGray;
            this.dgvHMDesModel.Location = new System.Drawing.Point(0, 0);
            this.dgvHMDesModel.Name = "dgvHMDesModel";
            this.dgvHMDesModel.ReadOnly = true;
            this.dgvHMDesModel.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1);
            this.dgvHMDesModel.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHMDesModel.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgvHMDesModel.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvHMDesModel.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvHMDesModel.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvHMDesModel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHMDesModel.Size = new System.Drawing.Size(1010, 192);
            this.dgvHMDesModel.TabIndex = 9;
            this.dgvHMDesModel.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // dgvHMDesModelTime
            // 
            this.dgvHMDesModelTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvHMDesModelTime.DataPropertyName = "TimeAsString";
            this.dgvHMDesModelTime.HeaderText = "Time";
            this.dgvHMDesModelTime.Name = "dgvHMDesModelTime";
            this.dgvHMDesModelTime.ReadOnly = true;
            this.dgvHMDesModelTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvHMDesModelTime.Width = 41;
            // 
            // dgvHMDesModelHMWeight
            // 
            this.dgvHMDesModelHMWeight.DataPropertyName = "HMWeight";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvHMDesModelHMWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHMDesModelHMWeight.HeaderText = "HM Weight (t)";
            this.dgvHMDesModelHMWeight.Name = "dgvHMDesModelHMWeight";
            this.dgvHMDesModelHMWeight.ReadOnly = true;
            this.dgvHMDesModelHMWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelHMTemperature
            // 
            this.dgvHMDesModelHMTemperature.DataPropertyName = "lHMTemp";
            this.dgvHMDesModelHMTemperature.HeaderText = "HM Temp (°C)";
            this.dgvHMDesModelHMTemperature.Name = "dgvHMDesModelHMTemperature";
            this.dgvHMDesModelHMTemperature.ReadOnly = true;
            this.dgvHMDesModelHMTemperature.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelStartS
            // 
            this.dgvHMDesModelStartS.DataPropertyName = "StartS";
            this.dgvHMDesModelStartS.HeaderText = "Start S (%)";
            this.dgvHMDesModelStartS.Name = "dgvHMDesModelStartS";
            this.dgvHMDesModelStartS.ReadOnly = true;
            this.dgvHMDesModelStartS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelAimHMS
            // 
            this.dgvHMDesModelAimHMS.DataPropertyName = "AimHMS";
            this.dgvHMDesModelAimHMS.HeaderText = "Aim HM S (%)";
            this.dgvHMDesModelAimHMS.Name = "dgvHMDesModelAimHMS";
            this.dgvHMDesModelAimHMS.ReadOnly = true;
            this.dgvHMDesModelAimHMS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelAimSteelS
            // 
            this.dgvHMDesModelAimSteelS.DataPropertyName = "AimSteelS";
            this.dgvHMDesModelAimSteelS.HeaderText = "Aim Steel S";
            this.dgvHMDesModelAimSteelS.Name = "dgvHMDesModelAimSteelS";
            this.dgvHMDesModelAimSteelS.ReadOnly = true;
            this.dgvHMDesModelAimSteelS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelType
            // 
            this.dgvHMDesModelType.DataPropertyName = "Type";
            this.dgvHMDesModelType.HeaderText = "Type";
            this.dgvHMDesModelType.Name = "dgvHMDesModelType";
            this.dgvHMDesModelType.ReadOnly = true;
            this.dgvHMDesModelType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelEstInjTime
            // 
            this.dgvHMDesModelEstInjTime.DataPropertyName = "EstInjTime";
            this.dgvHMDesModelEstInjTime.HeaderText = "Est Inj Time";
            this.dgvHMDesModelEstInjTime.Name = "dgvHMDesModelEstInjTime";
            this.dgvHMDesModelEstInjTime.ReadOnly = true;
            this.dgvHMDesModelEstInjTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelWtLoss
            // 
            this.dgvHMDesModelWtLoss.DataPropertyName = "WtLoss";
            this.dgvHMDesModelWtLoss.HeaderText = "Wt Loss (t)";
            this.dgvHMDesModelWtLoss.Name = "dgvHMDesModelWtLoss";
            this.dgvHMDesModelWtLoss.ReadOnly = true;
            this.dgvHMDesModelWtLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelTemperatureLoss
            // 
            this.dgvHMDesModelTemperatureLoss.DataPropertyName = "TemperatureLoss";
            this.dgvHMDesModelTemperatureLoss.HeaderText = "Temp Loss (°C)";
            this.dgvHMDesModelTemperatureLoss.Name = "dgvHMDesModelTemperatureLoss";
            this.dgvHMDesModelTemperatureLoss.ReadOnly = true;
            this.dgvHMDesModelTemperatureLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelTotalMg
            // 
            this.dgvHMDesModelTotalMg.DataPropertyName = "TotalMg";
            this.dgvHMDesModelTotalMg.HeaderText = "Total Mg (kg)";
            this.dgvHMDesModelTotalMg.Name = "dgvHMDesModelTotalMg";
            this.dgvHMDesModelTotalMg.ReadOnly = true;
            this.dgvHMDesModelTotalMg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHMDesModelTotalLime
            // 
            this.dgvHMDesModelTotalLime.DataPropertyName = "TotalLime";
            this.dgvHMDesModelTotalLime.HeaderText = "Total Lime (kg)";
            this.dgvHMDesModelTotalLime.Name = "dgvHMDesModelTotalLime";
            this.dgvHMDesModelTotalLime.ReadOnly = true;
            this.dgvHMDesModelTotalLime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DesulphModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "DesulphModel";
            this.Size = new System.Drawing.Size(1010, 192);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHMDesModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvHMDesModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelHMWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelHMTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelStartS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelAimHMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelAimSteelS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelEstInjTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelWtLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelTemperatureLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelTotalMg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHMDesModelTotalLime;

    }
}
