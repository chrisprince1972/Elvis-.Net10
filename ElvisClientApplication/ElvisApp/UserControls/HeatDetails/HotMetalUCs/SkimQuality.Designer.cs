namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    partial class SkimQuality
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpSkimQuality = new System.Windows.Forms.GroupBox();
            this.pnlSkimQuality = new System.Windows.Forms.Panel();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.pbSkim = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dgvSkimQuality = new System.Windows.Forms.DataGridView();
            this.DateTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkimPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpSkimQuality.SuspendLayout();
            this.pnlSkimQuality.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkimQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSkimQuality
            // 
            this.grpSkimQuality.Controls.Add(this.pnlSkimQuality);
            this.grpSkimQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSkimQuality.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSkimQuality.Location = new System.Drawing.Point(0, 0);
            this.grpSkimQuality.Name = "grpSkimQuality";
            this.grpSkimQuality.Padding = new System.Windows.Forms.Padding(6);
            this.grpSkimQuality.Size = new System.Drawing.Size(638, 247);
            this.grpSkimQuality.TabIndex = 0;
            this.grpSkimQuality.TabStop = false;
            this.grpSkimQuality.Text = "Skim Quality";
            // 
            // pnlSkimQuality
            // 
            this.pnlSkimQuality.Controls.Add(this.pnlImage);
            this.pnlSkimQuality.Controls.Add(this.splitter1);
            this.pnlSkimQuality.Controls.Add(this.dgvSkimQuality);
            this.pnlSkimQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSkimQuality.Location = new System.Drawing.Point(6, 20);
            this.pnlSkimQuality.Name = "pnlSkimQuality";
            this.pnlSkimQuality.Size = new System.Drawing.Size(626, 221);
            this.pnlSkimQuality.TabIndex = 7;
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.pbSkim);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(310, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(316, 221);
            this.pnlImage.TabIndex = 7;
            // 
            // pbSkim
            // 
            this.pbSkim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pbSkim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSkim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSkim.Location = new System.Drawing.Point(0, 0);
            this.pbSkim.Name = "pbSkim";
            this.pbSkim.Size = new System.Drawing.Size(316, 221);
            this.pbSkim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSkim.TabIndex = 1;
            this.pbSkim.TabStop = false;
            this.pbSkim.Click += new System.EventHandler(this.pbSkim_Click);
            this.pbSkim.MouseEnter += new System.EventHandler(this.pbSkim_MouseEnter);
            this.pbSkim.MouseLeave += new System.EventHandler(this.pbSkim_MouseLeave);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(304, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 221);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // dgvSkimQuality
            // 
            this.dgvSkimQuality.AllowUserToAddRows = false;
            this.dgvSkimQuality.AllowUserToDeleteRows = false;
            this.dgvSkimQuality.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSkimQuality.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSkimQuality.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSkimQuality.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSkimQuality.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSkimQuality.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSkimQuality.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSkimQuality.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSkimQuality.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSkimQuality.ColumnHeadersHeight = 25;
            this.dgvSkimQuality.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSkimQuality.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTimeStamp,
            this.SkimPercentage});
            this.dgvSkimQuality.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvSkimQuality.EnableHeadersVisualStyles = false;
            this.dgvSkimQuality.GridColor = System.Drawing.Color.DimGray;
            this.dgvSkimQuality.Location = new System.Drawing.Point(0, 0);
            this.dgvSkimQuality.MultiSelect = false;
            this.dgvSkimQuality.Name = "dgvSkimQuality";
            this.dgvSkimQuality.ReadOnly = true;
            this.dgvSkimQuality.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvSkimQuality.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSkimQuality.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSkimQuality.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSkimQuality.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvSkimQuality.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvSkimQuality.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSkimQuality.Size = new System.Drawing.Size(304, 221);
            this.dgvSkimQuality.TabIndex = 6;
            this.dgvSkimQuality.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSkimQuality_DataBindingComplete);
            // 
            // DateTimeStamp
            // 
            this.DateTimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateTimeStamp.DataPropertyName = "DateTimeStamp";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.DateTimeStamp.DefaultCellStyle = dataGridViewCellStyle3;
            this.DateTimeStamp.FillWeight = 30F;
            this.DateTimeStamp.HeaderText = "Time";
            this.DateTimeStamp.Name = "DateTimeStamp";
            this.DateTimeStamp.ReadOnly = true;
            this.DateTimeStamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SkimPercentage
            // 
            this.SkimPercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SkimPercentage.DataPropertyName = "SkimPercentage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.SkimPercentage.DefaultCellStyle = dataGridViewCellStyle4;
            this.SkimPercentage.FillWeight = 70F;
            this.SkimPercentage.HeaderText = "Skim %";
            this.SkimPercentage.Name = "SkimPercentage";
            this.SkimPercentage.ReadOnly = true;
            this.SkimPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            // 
            // SkimQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSkimQuality);
            this.Name = "SkimQuality";
            this.Size = new System.Drawing.Size(638, 247);
            this.Load += new System.EventHandler(this.SkimQuality_Load);
            this.grpSkimQuality.ResumeLayout(false);
            this.pnlSkimQuality.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSkim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkimQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSkimQuality;
        private System.Windows.Forms.Panel pnlSkimQuality;
        private System.Windows.Forms.DataGridView dgvSkimQuality;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox pbSkim;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkimPercentage;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
