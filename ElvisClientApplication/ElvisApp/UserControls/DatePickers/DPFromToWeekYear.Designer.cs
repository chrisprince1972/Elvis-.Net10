namespace Elvis.UserControls.DatePickers
{
    partial class DPFromToWeekYear
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
            this.numYearFrom = new System.Windows.Forms.NumericUpDown();
            this.lblYearFrom = new System.Windows.Forms.Label();
            this.lblWeekFrom = new System.Windows.Forms.Label();
            this.numWeekFrom = new System.Windows.Forms.NumericUpDown();
            this.grpFrom = new System.Windows.Forms.GroupBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.grpTo = new System.Windows.Forms.GroupBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.numWeekTo = new System.Windows.Forms.NumericUpDown();
            this.lblWeekTo = new System.Windows.Forms.Label();
            this.lblYearTo = new System.Windows.Forms.Label();
            this.numYearTo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numYearFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekFrom)).BeginInit();
            this.grpFrom.SuspendLayout();
            this.grpTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTo)).BeginInit();
            this.SuspendLayout();
            // 
            // numYearFrom
            // 
            this.numYearFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYearFrom.Location = new System.Drawing.Point(123, 18);
            this.numYearFrom.Margin = new System.Windows.Forms.Padding(2, 3, 3, 1);
            this.numYearFrom.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numYearFrom.Minimum = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYearFrom.Name = "numYearFrom";
            this.numYearFrom.Size = new System.Drawing.Size(54, 21);
            this.numYearFrom.TabIndex = 41;
            this.numYearFrom.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYearFrom.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // lblYearFrom
            // 
            this.lblYearFrom.AutoSize = true;
            this.lblYearFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearFrom.Location = new System.Drawing.Point(89, 20);
            this.lblYearFrom.Name = "lblYearFrom";
            this.lblYearFrom.Size = new System.Drawing.Size(29, 13);
            this.lblYearFrom.TabIndex = 40;
            this.lblYearFrom.Text = "Year";
            // 
            // lblWeekFrom
            // 
            this.lblWeekFrom.AutoSize = true;
            this.lblWeekFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeekFrom.Location = new System.Drawing.Point(6, 20);
            this.lblWeekFrom.Name = "lblWeekFrom";
            this.lblWeekFrom.Size = new System.Drawing.Size(34, 13);
            this.lblWeekFrom.TabIndex = 39;
            this.lblWeekFrom.Text = "Week";
            // 
            // numWeekFrom
            // 
            this.numWeekFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeekFrom.Location = new System.Drawing.Point(45, 18);
            this.numWeekFrom.Margin = new System.Windows.Forms.Padding(2, 3, 3, 1);
            this.numWeekFrom.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.numWeekFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekFrom.Name = "numWeekFrom";
            this.numWeekFrom.Size = new System.Drawing.Size(38, 21);
            this.numWeekFrom.TabIndex = 38;
            this.numWeekFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekFrom.ValueChanged += new System.EventHandler(this.numWeek_ValueChanged);
            // 
            // grpFrom
            // 
            this.grpFrom.Controls.Add(this.lblDateFrom);
            this.grpFrom.Controls.Add(this.numWeekFrom);
            this.grpFrom.Controls.Add(this.lblWeekFrom);
            this.grpFrom.Controls.Add(this.lblYearFrom);
            this.grpFrom.Controls.Add(this.numYearFrom);
            this.grpFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpFrom.Location = new System.Drawing.Point(0, 0);
            this.grpFrom.Name = "grpFrom";
            this.grpFrom.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFrom.Size = new System.Drawing.Size(248, 46);
            this.grpFrom.TabIndex = 46;
            this.grpFrom.TabStop = false;
            this.grpFrom.Text = "From";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(183, 20);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(55, 13);
            this.lblDateFrom.TabIndex = 42;
            this.lblDateFrom.Text = "dd/MM/yy";
            // 
            // grpTo
            // 
            this.grpTo.Controls.Add(this.lblDateTo);
            this.grpTo.Controls.Add(this.numWeekTo);
            this.grpTo.Controls.Add(this.lblWeekTo);
            this.grpTo.Controls.Add(this.lblYearTo);
            this.grpTo.Controls.Add(this.numYearTo);
            this.grpTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpTo.Location = new System.Drawing.Point(0, 46);
            this.grpTo.Name = "grpTo";
            this.grpTo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTo.Size = new System.Drawing.Size(248, 46);
            this.grpTo.TabIndex = 47;
            this.grpTo.TabStop = false;
            this.grpTo.Text = "To";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(183, 20);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(55, 13);
            this.lblDateTo.TabIndex = 42;
            this.lblDateTo.Text = "dd/MM/yy";
            // 
            // numWeekTo
            // 
            this.numWeekTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeekTo.Location = new System.Drawing.Point(45, 18);
            this.numWeekTo.Margin = new System.Windows.Forms.Padding(2, 3, 3, 1);
            this.numWeekTo.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.numWeekTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekTo.Name = "numWeekTo";
            this.numWeekTo.Size = new System.Drawing.Size(38, 21);
            this.numWeekTo.TabIndex = 38;
            this.numWeekTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekTo.ValueChanged += new System.EventHandler(this.numWeek_ValueChanged);
            // 
            // lblWeekTo
            // 
            this.lblWeekTo.AutoSize = true;
            this.lblWeekTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeekTo.Location = new System.Drawing.Point(6, 20);
            this.lblWeekTo.Name = "lblWeekTo";
            this.lblWeekTo.Size = new System.Drawing.Size(34, 13);
            this.lblWeekTo.TabIndex = 39;
            this.lblWeekTo.Text = "Week";
            // 
            // lblYearTo
            // 
            this.lblYearTo.AutoSize = true;
            this.lblYearTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearTo.Location = new System.Drawing.Point(89, 20);
            this.lblYearTo.Name = "lblYearTo";
            this.lblYearTo.Size = new System.Drawing.Size(29, 13);
            this.lblYearTo.TabIndex = 40;
            this.lblYearTo.Text = "Year";
            // 
            // numYearTo
            // 
            this.numYearTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYearTo.Location = new System.Drawing.Point(123, 18);
            this.numYearTo.Margin = new System.Windows.Forms.Padding(2, 3, 3, 1);
            this.numYearTo.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numYearTo.Minimum = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYearTo.Name = "numYearTo";
            this.numYearTo.Size = new System.Drawing.Size(54, 21);
            this.numYearTo.TabIndex = 41;
            this.numYearTo.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYearTo.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // DPFromToWeekYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTo);
            this.Controls.Add(this.grpFrom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DPFromToWeekYear";
            this.Size = new System.Drawing.Size(248, 92);
            this.Load += new System.EventHandler(this.DPFromToWeekYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYearFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekFrom)).EndInit();
            this.grpFrom.ResumeLayout(false);
            this.grpFrom.PerformLayout();
            this.grpTo.ResumeLayout(false);
            this.grpTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numYearFrom;
        private System.Windows.Forms.Label lblYearFrom;
        private System.Windows.Forms.Label lblWeekFrom;
        private System.Windows.Forms.NumericUpDown numWeekFrom;
        private System.Windows.Forms.GroupBox grpFrom;
        private System.Windows.Forms.GroupBox grpTo;
        private System.Windows.Forms.NumericUpDown numWeekTo;
        private System.Windows.Forms.Label lblWeekTo;
        private System.Windows.Forms.Label lblYearTo;
        private System.Windows.Forms.NumericUpDown numYearTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
    }
}
