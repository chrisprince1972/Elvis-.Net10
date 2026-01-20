namespace Elvis.UserControls.DatePickers
{
    partial class DPDayWeekYear
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
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.SuspendLayout();
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(195, 3);
            this.numYear.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.numYear.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(54, 21);
            this.numYear.TabIndex = 37;
            this.numYear.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(161, 5);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 36;
            this.lblYear.Text = "Year";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(78, 5);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(34, 13);
            this.lblWeek.TabIndex = 35;
            this.lblWeek.Text = "Week";
            // 
            // numWeek
            // 
            this.numWeek.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeek.Location = new System.Drawing.Point(117, 3);
            this.numWeek.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.numWeek.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(38, 21);
            this.numWeek.TabIndex = 34;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numDay
            // 
            this.numDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDay.Location = new System.Drawing.Point(34, 3);
            this.numDay.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.numDay.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(38, 21);
            this.numDay.TabIndex = 32;
            this.numDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(3, 5);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 33;
            this.lblDay.Text = "Day";
            // 
            // DPDayWeekYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.numWeek);
            this.Controls.Add(this.numDay);
            this.Controls.Add(this.lblDay);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DPDayWeekYear";
            this.Size = new System.Drawing.Size(252, 27);
            this.Load += new System.EventHandler(this.DPDayWeekYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lblDay;
    }
}
