namespace Elvis.UserControls.DatePickers
{
    partial class ElvisDateSelector
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
            this.pnlFormat = new System.Windows.Forms.Panel();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbWeekSpan = new System.Windows.Forms.RadioButton();
            this.rbDateSpan = new System.Windows.Forms.RadioButton();
            this.pnlDateSelector = new System.Windows.Forms.Panel();
            this.grpDateSelector = new System.Windows.Forms.GroupBox();
            this.pnlFormat.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.pnlDateSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormat
            // 
            this.pnlFormat.Controls.Add(this.grpFormat);
            this.pnlFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFormat.Location = new System.Drawing.Point(0, 0);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlFormat.Size = new System.Drawing.Size(97, 117);
            this.pnlFormat.TabIndex = 34;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rbDaily);
            this.grpFormat.Controls.Add(this.rbWeekly);
            this.grpFormat.Controls.Add(this.rbWeekSpan);
            this.grpFormat.Controls.Add(this.rbDateSpan);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFormat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFormat.Location = new System.Drawing.Point(0, 0);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Padding = new System.Windows.Forms.Padding(10, 7, 4, 10);
            this.grpFormat.Size = new System.Drawing.Size(94, 117);
            this.grpFormat.TabIndex = 33;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Date Format";
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDaily.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDaily.Location = new System.Drawing.Point(10, 87);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbDaily.Size = new System.Drawing.Size(80, 22);
            this.rbDaily.TabIndex = 16;
            this.rbDaily.Text = "&Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWeekly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWeekly.Location = new System.Drawing.Point(10, 65);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbWeekly.Size = new System.Drawing.Size(80, 22);
            this.rbWeekly.TabIndex = 17;
            this.rbWeekly.Text = "&Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbWeekSpan
            // 
            this.rbWeekSpan.AutoSize = true;
            this.rbWeekSpan.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbWeekSpan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWeekSpan.Location = new System.Drawing.Point(10, 43);
            this.rbWeekSpan.Name = "rbWeekSpan";
            this.rbWeekSpan.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbWeekSpan.Size = new System.Drawing.Size(80, 22);
            this.rbWeekSpan.TabIndex = 28;
            this.rbWeekSpan.Text = "Week &Span";
            this.rbWeekSpan.UseVisualStyleBackColor = true;
            this.rbWeekSpan.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbDateSpan
            // 
            this.rbDateSpan.AutoSize = true;
            this.rbDateSpan.Checked = true;
            this.rbDateSpan.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDateSpan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDateSpan.Location = new System.Drawing.Point(10, 21);
            this.rbDateSpan.Name = "rbDateSpan";
            this.rbDateSpan.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.rbDateSpan.Size = new System.Drawing.Size(80, 22);
            this.rbDateSpan.TabIndex = 27;
            this.rbDateSpan.TabStop = true;
            this.rbDateSpan.Text = "Da&te Span";
            this.rbDateSpan.UseVisualStyleBackColor = true;
            this.rbDateSpan.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // pnlDateSelector
            // 
            this.pnlDateSelector.Controls.Add(this.grpDateSelector);
            this.pnlDateSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDateSelector.Location = new System.Drawing.Point(97, 0);
            this.pnlDateSelector.Name = "pnlDateSelector";
            this.pnlDateSelector.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlDateSelector.Size = new System.Drawing.Size(280, 117);
            this.pnlDateSelector.TabIndex = 35;
            // 
            // grpDateSelector
            // 
            this.grpDateSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDateSelector.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDateSelector.Location = new System.Drawing.Point(0, 0);
            this.grpDateSelector.Name = "grpDateSelector";
            this.grpDateSelector.Padding = new System.Windows.Forms.Padding(8, 6, 10, 10);
            this.grpDateSelector.Size = new System.Drawing.Size(277, 117);
            this.grpDateSelector.TabIndex = 34;
            this.grpDateSelector.TabStop = false;
            this.grpDateSelector.Text = "Date Selector";
            // 
            // ElvisDateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDateSelector);
            this.Controls.Add(this.pnlFormat);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ElvisDateSelector";
            this.Size = new System.Drawing.Size(377, 117);
            this.Load += new System.EventHandler(this.ElvisDateSelector_Load);
            this.pnlFormat.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.pnlDateSelector.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbWeekSpan;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbDateSpan;
        private System.Windows.Forms.Panel pnlDateSelector;
        private System.Windows.Forms.GroupBox grpDateSelector;
    }
}
