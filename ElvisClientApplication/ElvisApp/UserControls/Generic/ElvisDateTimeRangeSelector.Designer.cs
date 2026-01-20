namespace Elvis.UserControls.Generic
{
    partial class ElvisDateTimeRangeSelector
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
            this.grpDateSelector = new System.Windows.Forms.GroupBox();
            this.rbCurrentShift = new System.Windows.Forms.RadioButton();
            this.rbLastShift = new System.Windows.Forms.RadioButton();
            this.rbLastDay = new System.Windows.Forms.RadioButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rbFixed = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.grpDateSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.grpFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDateSelector
            // 
            this.grpDateSelector.Controls.Add(this.rbCurrentShift);
            this.grpDateSelector.Controls.Add(this.rbLastShift);
            this.grpDateSelector.Controls.Add(this.rbLastDay);
            this.grpDateSelector.Controls.Add(this.lblTo);
            this.grpDateSelector.Controls.Add(this.numYear);
            this.grpDateSelector.Controls.Add(this.dpTo);
            this.grpDateSelector.Controls.Add(this.lblYear);
            this.grpDateSelector.Controls.Add(this.lblFrom);
            this.grpDateSelector.Controls.Add(this.lblWeek);
            this.grpDateSelector.Controls.Add(this.dpFrom);
            this.grpDateSelector.Controls.Add(this.numWeek);
            this.grpDateSelector.Controls.Add(this.numDay);
            this.grpDateSelector.Controls.Add(this.lblDay);
            this.grpDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpDateSelector.Location = new System.Drawing.Point(90, 0);
            this.grpDateSelector.Name = "grpDateSelector";
            this.grpDateSelector.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.grpDateSelector.Size = new System.Drawing.Size(274, 120);
            this.grpDateSelector.TabIndex = 38;
            this.grpDateSelector.TabStop = false;
            this.grpDateSelector.Text = "Date Selector";
            // 
            // rbCurrentShift
            // 
            this.rbCurrentShift.AutoSize = true;
            this.rbCurrentShift.Checked = true;
            this.rbCurrentShift.Enabled = false;
            this.rbCurrentShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbCurrentShift.Location = new System.Drawing.Point(163, 86);
            this.rbCurrentShift.Name = "rbCurrentShift";
            this.rbCurrentShift.Size = new System.Drawing.Size(83, 17);
            this.rbCurrentShift.TabIndex = 33;
            this.rbCurrentShift.TabStop = true;
            this.rbCurrentShift.Text = "Current Shift";
            this.rbCurrentShift.UseVisualStyleBackColor = true;
            this.rbCurrentShift.CheckedChanged += new System.EventHandler(this.rbCurrentShift_CheckedChanged);
            // 
            // rbLastShift
            // 
            this.rbLastShift.AutoSize = true;
            this.rbLastShift.Enabled = false;
            this.rbLastShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbLastShift.Location = new System.Drawing.Point(88, 86);
            this.rbLastShift.Name = "rbLastShift";
            this.rbLastShift.Size = new System.Drawing.Size(69, 17);
            this.rbLastShift.TabIndex = 32;
            this.rbLastShift.Text = "Last Shift";
            this.rbLastShift.UseVisualStyleBackColor = true;
            this.rbLastShift.CheckedChanged += new System.EventHandler(this.rbLastShift_CheckedChanged);
            // 
            // rbLastDay
            // 
            this.rbLastDay.AutoSize = true;
            this.rbLastDay.Enabled = false;
            this.rbLastDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbLastDay.Location = new System.Drawing.Point(15, 86);
            this.rbLastDay.Name = "rbLastDay";
            this.rbLastDay.Size = new System.Drawing.Size(67, 17);
            this.rbLastDay.TabIndex = 31;
            this.rbLastDay.Text = "Last Day";
            this.rbLastDay.UseVisualStyleBackColor = true;
            this.rbLastDay.CheckedChanged += new System.EventHandler(this.rbLastDay_CheckedChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTo.Location = new System.Drawing.Point(144, 27);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To";
            // 
            // numYear
            // 
            this.numYear.Enabled = false;
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(210, 55);
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
            this.numYear.Size = new System.Drawing.Size(53, 20);
            this.numYear.TabIndex = 4;
            this.numYear.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // dpTo
            // 
            this.dpTo.Enabled = false;
            this.dpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(170, 23);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(93, 20);
            this.dpTo.TabIndex = 1;
            this.dpTo.ValueChanged += new System.EventHandler(this.dpTo_ValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Enabled = false;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblYear.Location = new System.Drawing.Point(175, 59);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 30;
            this.lblYear.Text = "Year";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Enabled = false;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFrom.Location = new System.Drawing.Point(9, 27);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Enabled = false;
            this.lblWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblWeek.Location = new System.Drawing.Point(89, 59);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 29;
            this.lblWeek.Text = "Week";
            // 
            // dpFrom
            // 
            this.dpFrom.Enabled = false;
            this.dpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(45, 23);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(93, 20);
            this.dpFrom.TabIndex = 0;
            this.dpFrom.ValueChanged += new System.EventHandler(this.dpFrom_ValueChanged);
            // 
            // numWeek
            // 
            this.numWeek.Enabled = false;
            this.numWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeek.Location = new System.Drawing.Point(131, 55);
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
            this.numWeek.Size = new System.Drawing.Size(38, 20);
            this.numWeek.TabIndex = 3;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.ValueChanged += new System.EventHandler(this.numWeek_ValueChanged);
            // 
            // numDay
            // 
            this.numDay.Enabled = false;
            this.numDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDay.Location = new System.Drawing.Point(45, 55);
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
            this.numDay.Size = new System.Drawing.Size(38, 20);
            this.numDay.TabIndex = 2;
            this.numDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDay.ValueChanged += new System.EventHandler(this.numDay_ValueChanged);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Enabled = false;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDay.Location = new System.Drawing.Point(13, 59);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 19;
            this.lblDay.Text = "Day";
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rbFixed);
            this.grpFormat.Controls.Add(this.rbWeekly);
            this.grpFormat.Controls.Add(this.rbDaily);
            this.grpFormat.Controls.Add(this.rbDate);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpFormat.Location = new System.Drawing.Point(0, 0);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Padding = new System.Windows.Forms.Padding(10, 10, 6, 10);
            this.grpFormat.Size = new System.Drawing.Size(90, 120);
            this.grpFormat.TabIndex = 37;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Date Format";
            // 
            // rbFixed
            // 
            this.rbFixed.AutoSize = true;
            this.rbFixed.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFixed.Location = new System.Drawing.Point(10, 86);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbFixed.Size = new System.Drawing.Size(74, 21);
            this.rbFixed.TabIndex = 4;
            this.rbFixed.Text = "&Fixed";
            this.rbFixed.UseVisualStyleBackColor = true;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.rbFixed_CheckedChanged);
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWeekly.Location = new System.Drawing.Point(10, 65);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbWeekly.Size = new System.Drawing.Size(74, 21);
            this.rbWeekly.TabIndex = 2;
            this.rbWeekly.Text = "&Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rbWeekly_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDaily.Location = new System.Drawing.Point(10, 44);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbDaily.Size = new System.Drawing.Size(74, 21);
            this.rbDaily.TabIndex = 1;
            this.rbDaily.Text = "&Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbDaily_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Checked = true;
            this.rbDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDate.Location = new System.Drawing.Point(10, 23);
            this.rbDate.Name = "rbDate";
            this.rbDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.rbDate.Size = new System.Drawing.Size(74, 21);
            this.rbDate.TabIndex = 0;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "&Pick Date";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // ElvisDateTimeRangeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDateSelector);
            this.Controls.Add(this.grpFormat);
            this.Name = "ElvisDateTimeRangeSelector";
            this.Size = new System.Drawing.Size(370, 120);
            this.Load += new System.EventHandler(this.ElvisDateTimeRangeSelector_Load);
            this.grpDateSelector.ResumeLayout(false);
            this.grpDateSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDateSelector;
        private System.Windows.Forms.RadioButton rbCurrentShift;
        private System.Windows.Forms.RadioButton rbLastShift;
        private System.Windows.Forms.RadioButton rbLastDay;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbFixed;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbDate;
    }
}
