namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    partial class HotMetalMakeUp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvHotMetalData = new System.Windows.Forms.DataGridView();
            this.RowDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChemCarbon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChemSilicon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChemSulphur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChemPhosphorous = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChemManganese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotMetalData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvHotMetalData);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(924, 476);
            this.pnlMain.TabIndex = 8;
            // 
            // dgvHotMetalData
            // 
            this.dgvHotMetalData.AllowUserToAddRows = false;
            this.dgvHotMetalData.AllowUserToDeleteRows = false;
            this.dgvHotMetalData.AllowUserToOrderColumns = true;
            this.dgvHotMetalData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHotMetalData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHotMetalData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHotMetalData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHotMetalData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHotMetalData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHotMetalData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHotMetalData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvHotMetalData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHotMetalData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHotMetalData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowDescription,
            this.ChemCarbon,
            this.ChemSilicon,
            this.ChemSulphur,
            this.ChemPhosphorous,
            this.ChemManganese,
            this.Temperature,
            this.RequiredWeight,
            this.ActualWeight,
            this.Time});
            this.dgvHotMetalData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHotMetalData.EnableHeadersVisualStyles = false;
            this.dgvHotMetalData.GridColor = System.Drawing.Color.DimGray;
            this.dgvHotMetalData.Location = new System.Drawing.Point(0, 0);
            this.dgvHotMetalData.Name = "dgvHotMetalData";
            this.dgvHotMetalData.ReadOnly = true;
            this.dgvHotMetalData.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(1);
            this.dgvHotMetalData.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvHotMetalData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgvHotMetalData.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvHotMetalData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvHotMetalData.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvHotMetalData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHotMetalData.Size = new System.Drawing.Size(924, 476);
            this.dgvHotMetalData.TabIndex = 8;
            this.dgvHotMetalData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // RowDescription
            // 
            this.RowDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RowDescription.DataPropertyName = "RowDescription";
            this.RowDescription.HeaderText = " ";
            this.RowDescription.Name = "RowDescription";
            this.RowDescription.ReadOnly = true;
            this.RowDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowDescription.Width = 18;
            // 
            // ChemCarbon
            // 
            this.ChemCarbon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChemCarbon.DataPropertyName = "Carbon";
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.ChemCarbon.DefaultCellStyle = dataGridViewCellStyle3;
            this.ChemCarbon.HeaderText = "C";
            this.ChemCarbon.Name = "ChemCarbon";
            this.ChemCarbon.ReadOnly = true;
            this.ChemCarbon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChemCarbon.ToolTipText = "Carbon";
            // 
            // ChemSilicon
            // 
            this.ChemSilicon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChemSilicon.DataPropertyName = "Silicon";
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.ChemSilicon.DefaultCellStyle = dataGridViewCellStyle4;
            this.ChemSilicon.HeaderText = "Si";
            this.ChemSilicon.Name = "ChemSilicon";
            this.ChemSilicon.ReadOnly = true;
            this.ChemSilicon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChemSilicon.ToolTipText = "Silicon";
            // 
            // ChemSulphur
            // 
            this.ChemSulphur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChemSulphur.DataPropertyName = "Sulphur";
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.ChemSulphur.DefaultCellStyle = dataGridViewCellStyle5;
            this.ChemSulphur.HeaderText = "S";
            this.ChemSulphur.Name = "ChemSulphur";
            this.ChemSulphur.ReadOnly = true;
            this.ChemSulphur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChemSulphur.ToolTipText = "Sulphur";
            // 
            // ChemPhosphorous
            // 
            this.ChemPhosphorous.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChemPhosphorous.DataPropertyName = "Phosphorous";
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.ChemPhosphorous.DefaultCellStyle = dataGridViewCellStyle6;
            this.ChemPhosphorous.HeaderText = "P";
            this.ChemPhosphorous.Name = "ChemPhosphorous";
            this.ChemPhosphorous.ReadOnly = true;
            this.ChemPhosphorous.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChemPhosphorous.ToolTipText = "Phosphorus";
            // 
            // ChemManganese
            // 
            this.ChemManganese.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChemManganese.DataPropertyName = "Manganese";
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = null;
            this.ChemManganese.DefaultCellStyle = dataGridViewCellStyle7;
            this.ChemManganese.HeaderText = "Mn";
            this.ChemManganese.Name = "ChemManganese";
            this.ChemManganese.ReadOnly = true;
            this.ChemManganese.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChemManganese.ToolTipText = "Manganese";
            // 
            // Temperature
            // 
            this.Temperature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Temperature.DataPropertyName = "Temperature";
            dataGridViewCellStyle8.Format = "N4";
            dataGridViewCellStyle8.NullValue = null;
            this.Temperature.DefaultCellStyle = dataGridViewCellStyle8;
            this.Temperature.HeaderText = "Temp";
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            this.Temperature.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Temperature.ToolTipText = "Temperature";
            // 
            // RequiredWeight
            // 
            this.RequiredWeight.DataPropertyName = "RequiredWeight";
            this.RequiredWeight.HeaderText = "Req Wt (t)";
            this.RequiredWeight.Name = "RequiredWeight";
            this.RequiredWeight.ReadOnly = true;
            this.RequiredWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActualWeight
            // 
            this.ActualWeight.DataPropertyName = "ActualWeight";
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.ActualWeight.DefaultCellStyle = dataGridViewCellStyle9;
            this.ActualWeight.HeaderText = "Act Wt (t)";
            this.ActualWeight.Name = "ActualWeight";
            this.ActualWeight.ReadOnly = true;
            this.ActualWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "TimeAsString";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // HotMetalMakeUp
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "HotMetalMakeUp";
            this.Size = new System.Drawing.Size(924, 476);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotMetalData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvHotMetalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChemCarbon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChemSilicon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChemSulphur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChemPhosphorous;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChemManganese;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;


    }
}
