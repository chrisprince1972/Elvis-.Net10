namespace Elvis.UserControls.Options
{
    partial class OptionMain
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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlMemoryUsage = new System.Windows.Forms.Panel();
            this.grpMemoryUsage = new System.Windows.Forms.GroupBox();
            this.btnMemoryDefault = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numMemoryUsage = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlHistorical = new System.Windows.Forms.Panel();
            this.grpHistorical = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numTibDays = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOverviewDays = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlUpdates = new System.Windows.Forms.Panel();
            this.grpSoftwareUpdate = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.chbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.fontPicker = new System.Windows.Forms.FontDialog();
            this.grpMain.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlMemoryUsage.SuspendLayout();
            this.grpMemoryUsage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMemoryUsage)).BeginInit();
            this.pnlHistorical.SuspendLayout();
            this.grpHistorical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTibDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOverviewDays)).BeginInit();
            this.pnlUpdates.SuspendLayout();
            this.grpSoftwareUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.pnlOptions);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpMain.ForeColor = System.Drawing.Color.Black;
            this.grpMain.Location = new System.Drawing.Point(3, 3);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(6);
            this.grpMain.Size = new System.Drawing.Size(614, 228);
            this.grpMain.TabIndex = 2;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Options";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.pnlMemoryUsage);
            this.pnlOptions.Controls.Add(this.pnlHistorical);
            this.pnlOptions.Controls.Add(this.pnlUpdates);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.Location = new System.Drawing.Point(6, 20);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(3);
            this.pnlOptions.Size = new System.Drawing.Size(602, 202);
            this.pnlOptions.TabIndex = 2;
            // 
            // pnlMemoryUsage
            // 
            this.pnlMemoryUsage.Controls.Add(this.grpMemoryUsage);
            this.pnlMemoryUsage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMemoryUsage.Location = new System.Drawing.Point(3, 142);
            this.pnlMemoryUsage.Name = "pnlMemoryUsage";
            this.pnlMemoryUsage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlMemoryUsage.Size = new System.Drawing.Size(596, 56);
            this.pnlMemoryUsage.TabIndex = 7;
            // 
            // grpMemoryUsage
            // 
            this.grpMemoryUsage.Controls.Add(this.btnMemoryDefault);
            this.grpMemoryUsage.Controls.Add(this.label7);
            this.grpMemoryUsage.Controls.Add(this.numMemoryUsage);
            this.grpMemoryUsage.Controls.Add(this.label6);
            this.grpMemoryUsage.Controls.Add(this.label5);
            this.grpMemoryUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMemoryUsage.ForeColor = System.Drawing.Color.Black;
            this.grpMemoryUsage.Location = new System.Drawing.Point(0, 0);
            this.grpMemoryUsage.Name = "grpMemoryUsage";
            this.grpMemoryUsage.Padding = new System.Windows.Forms.Padding(8, 8, 3, 3);
            this.grpMemoryUsage.Size = new System.Drawing.Size(596, 53);
            this.grpMemoryUsage.TabIndex = 0;
            this.grpMemoryUsage.TabStop = false;
            this.grpMemoryUsage.Text = "Memory Usage";
            // 
            // btnMemoryDefault
            // 
            this.btnMemoryDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemoryDefault.ForeColor = System.Drawing.Color.Black;
            this.btnMemoryDefault.Location = new System.Drawing.Point(253, 25);
            this.btnMemoryDefault.Name = "btnMemoryDefault";
            this.btnMemoryDefault.Size = new System.Drawing.Size(56, 20);
            this.btnMemoryDefault.TabIndex = 12;
            this.btnMemoryDefault.Tag = "Caster1";
            this.btnMemoryDefault.Text = "Default";
            this.btnMemoryDefault.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMemoryDefault.UseVisualStyleBackColor = true;
            this.btnMemoryDefault.Click += new System.EventHandler(this.btnMemoryDefault_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(224, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "MB";
            // 
            // numMemoryUsage
            // 
            this.numMemoryUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMemoryUsage.Location = new System.Drawing.Point(174, 25);
            this.numMemoryUsage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.numMemoryUsage.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numMemoryUsage.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numMemoryUsage.Name = "numMemoryUsage";
            this.numMemoryUsage.Size = new System.Drawing.Size(50, 20);
            this.numMemoryUsage.TabIndex = 6;
            this.numMemoryUsage.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numMemoryUsage.ValueChanged += new System.EventHandler(this.numMemoryUsage_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Max allowed memory usage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(315, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "(Warning - only modify if you get memory errors)";
            // 
            // pnlHistorical
            // 
            this.pnlHistorical.Controls.Add(this.grpHistorical);
            this.pnlHistorical.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistorical.Location = new System.Drawing.Point(3, 57);
            this.pnlHistorical.Name = "pnlHistorical";
            this.pnlHistorical.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlHistorical.Size = new System.Drawing.Size(596, 85);
            this.pnlHistorical.TabIndex = 6;
            // 
            // grpHistorical
            // 
            this.grpHistorical.Controls.Add(this.label3);
            this.grpHistorical.Controls.Add(this.numTibDays);
            this.grpHistorical.Controls.Add(this.label4);
            this.grpHistorical.Controls.Add(this.label2);
            this.grpHistorical.Controls.Add(this.numOverviewDays);
            this.grpHistorical.Controls.Add(this.label1);
            this.grpHistorical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHistorical.ForeColor = System.Drawing.Color.Black;
            this.grpHistorical.Location = new System.Drawing.Point(0, 0);
            this.grpHistorical.Name = "grpHistorical";
            this.grpHistorical.Padding = new System.Windows.Forms.Padding(6, 8, 3, 3);
            this.grpHistorical.Size = new System.Drawing.Size(596, 82);
            this.grpHistorical.TabIndex = 0;
            this.grpHistorical.TabStop = false;
            this.grpHistorical.Text = "Historical Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "days worth of data on the TIB scheduler.";
            // 
            // numTibDays
            // 
            this.numTibDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTibDays.Location = new System.Drawing.Point(50, 54);
            this.numTibDays.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.numTibDays.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numTibDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTibDays.Name = "numTibDays";
            this.numTibDays.Size = new System.Drawing.Size(40, 20);
            this.numTibDays.TabIndex = 4;
            this.numTibDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTibDays.ValueChanged += new System.EventHandler(this.numTibDays_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Show";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "days worth of data on the Overview scheduler.";
            // 
            // numOverviewDays
            // 
            this.numOverviewDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOverviewDays.Location = new System.Drawing.Point(50, 25);
            this.numOverviewDays.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numOverviewDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOverviewDays.Name = "numOverviewDays";
            this.numOverviewDays.Size = new System.Drawing.Size(40, 20);
            this.numOverviewDays.TabIndex = 1;
            this.numOverviewDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOverviewDays.ValueChanged += new System.EventHandler(this.numOverviewDays_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show";
            // 
            // pnlUpdates
            // 
            this.pnlUpdates.Controls.Add(this.grpSoftwareUpdate);
            this.pnlUpdates.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdates.Location = new System.Drawing.Point(3, 3);
            this.pnlUpdates.Name = "pnlUpdates";
            this.pnlUpdates.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlUpdates.Size = new System.Drawing.Size(596, 54);
            this.pnlUpdates.TabIndex = 5;
            // 
            // grpSoftwareUpdate
            // 
            this.grpSoftwareUpdate.Controls.Add(this.lblNote);
            this.grpSoftwareUpdate.Controls.Add(this.chbAutoUpdate);
            this.grpSoftwareUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSoftwareUpdate.ForeColor = System.Drawing.Color.Black;
            this.grpSoftwareUpdate.Location = new System.Drawing.Point(0, 0);
            this.grpSoftwareUpdate.Name = "grpSoftwareUpdate";
            this.grpSoftwareUpdate.Padding = new System.Windows.Forms.Padding(8, 8, 3, 3);
            this.grpSoftwareUpdate.Size = new System.Drawing.Size(596, 51);
            this.grpSoftwareUpdate.TabIndex = 0;
            this.grpSoftwareUpdate.TabStop = false;
            this.grpSoftwareUpdate.Text = "Software Updates";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(257, 26);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(250, 15);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "(Updates unavailable for standalone version)";
            // 
            // chbAutoUpdate
            // 
            this.chbAutoUpdate.AutoSize = true;
            this.chbAutoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAutoUpdate.Location = new System.Drawing.Point(11, 25);
            this.chbAutoUpdate.Name = "chbAutoUpdate";
            this.chbAutoUpdate.Size = new System.Drawing.Size(246, 19);
            this.chbAutoUpdate.TabIndex = 0;
            this.chbAutoUpdate.Text = "Automatically check for software updates";
            this.chbAutoUpdate.UseVisualStyleBackColor = true;
            this.chbAutoUpdate.CheckedChanged += new System.EventHandler(this.chbAutoUpdate_CheckedChanged);
            // 
            // OptionMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Name = "OptionMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(620, 234);
            this.grpMain.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlMemoryUsage.ResumeLayout(false);
            this.grpMemoryUsage.ResumeLayout(false);
            this.grpMemoryUsage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMemoryUsage)).EndInit();
            this.pnlHistorical.ResumeLayout(false);
            this.grpHistorical.ResumeLayout(false);
            this.grpHistorical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTibDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOverviewDays)).EndInit();
            this.pnlUpdates.ResumeLayout(false);
            this.grpSoftwareUpdate.ResumeLayout(false);
            this.grpSoftwareUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlUpdates;
        private System.Windows.Forms.GroupBox grpSoftwareUpdate;
        private System.Windows.Forms.CheckBox chbAutoUpdate;
        private System.Windows.Forms.FontDialog fontPicker;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlHistorical;
        private System.Windows.Forms.GroupBox grpHistorical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numOverviewDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTibDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlMemoryUsage;
        private System.Windows.Forms.GroupBox grpMemoryUsage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMemoryUsage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMemoryDefault;
    }
}
