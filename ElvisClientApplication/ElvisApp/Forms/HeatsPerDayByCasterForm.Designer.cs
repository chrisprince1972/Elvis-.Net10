namespace Elvis.Forms
{
    partial class HeatsPerDayByCasterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatsPerDayByCasterForm));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.nowButton = new System.Windows.Forms.Button();
            this.buttonImageList = new System.Windows.Forms.ImageList(this.components);
            this.radioButtonPanel = new System.Windows.Forms.Panel();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            this.dayRadioButton = new System.Windows.Forms.RadioButton();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.modelPeriodEndLabel = new System.Windows.Forms.Label();
            this.periodEndLabel = new System.Windows.Forms.Label();
            this.modelPeriodStartLabel = new System.Windows.Forms.Label();
            this.periodStartLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.heatsTabControl = new System.Windows.Forms.TabControl();
            this.shiftTabPage = new System.Windows.Forms.TabPage();
            this.shiftHeatsPerDay = new Elvis.UserControls.HeatDetails.HeatsPerDayByCaster();
            this.cumulativeTabPage = new System.Windows.Forms.TabPage();
            this.cumulativeShiftsPerDay = new Elvis.UserControls.HeatDetails.HeatsPerDayByCaster();
            this.planningTabPage = new System.Windows.Forms.TabPage();
            this.planningShiftsPerDay = new Elvis.UserControls.HeatDetails.HeatsPerDayByCaster();
            this.steelInMouldTabPage = new System.Windows.Forms.TabPage();
            this.steelInMouldSpeedRatio = new Elvis.UserControls.HeatDetails.SteelInMouldSpeedRatio();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.mainMenuStrip.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.radioButtonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.heatsTabControl.SuspendLayout();
            this.shiftTabPage.SuspendLayout();
            this.cumulativeTabPage.SuspendLayout();
            this.planningTabPage.SuspendLayout();
            this.steelInMouldTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(652, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::Elvis.Properties.Resources.Print_11009;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = global::Elvis.Properties.Resources.PrintPreviewControl_698;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.nowButton);
            this.bottomPanel.Controls.Add(this.radioButtonPanel);
            this.bottomPanel.Controls.Add(this.nextButton);
            this.bottomPanel.Controls.Add(this.previousButton);
            this.bottomPanel.Controls.Add(this.modelPeriodEndLabel);
            this.bottomPanel.Controls.Add(this.periodEndLabel);
            this.bottomPanel.Controls.Add(this.modelPeriodStartLabel);
            this.bottomPanel.Controls.Add(this.periodStartLabel);
            this.bottomPanel.Controls.Add(this.closeButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 460);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(652, 62);
            this.bottomPanel.TabIndex = 1;
            // 
            // nowButton
            // 
            this.nowButton.ImageIndex = 0;
            this.nowButton.ImageList = this.buttonImageList;
            this.nowButton.Location = new System.Drawing.Point(284, 20);
            this.nowButton.Name = "nowButton";
            this.nowButton.Size = new System.Drawing.Size(24, 24);
            this.nowButton.TabIndex = 8;
            this.nowButton.UseVisualStyleBackColor = true;
            this.nowButton.Click += new System.EventHandler(this.directionButtons_Click);
            // 
            // buttonImageList
            // 
            this.buttonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonImageList.ImageStream")));
            this.buttonImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.buttonImageList.Images.SetKeyName(0, "Calendar_schedule.bmp");
            this.buttonImageList.Images.SetKeyName(1, "GoLtr.bmp");
            this.buttonImageList.Images.SetKeyName(2, "GoRtl.bmp");
            // 
            // radioButtonPanel
            // 
            this.radioButtonPanel.AutoSize = true;
            this.radioButtonPanel.Controls.Add(this.weekRadioButton);
            this.radioButtonPanel.Controls.Add(this.dayRadioButton);
            this.radioButtonPanel.Location = new System.Drawing.Point(407, 20);
            this.radioButtonPanel.Name = "radioButtonPanel";
            this.radioButtonPanel.Size = new System.Drawing.Size(111, 23);
            this.radioButtonPanel.TabIndex = 7;
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Location = new System.Drawing.Point(54, 3);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(54, 17);
            this.weekRadioButton.TabIndex = 0;
            this.weekRadioButton.Text = "Week";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            this.weekRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // dayRadioButton
            // 
            this.dayRadioButton.AutoSize = true;
            this.dayRadioButton.Checked = true;
            this.dayRadioButton.Location = new System.Drawing.Point(4, 3);
            this.dayRadioButton.Name = "dayRadioButton";
            this.dayRadioButton.Size = new System.Drawing.Size(44, 17);
            this.dayRadioButton.TabIndex = 0;
            this.dayRadioButton.TabStop = true;
            this.dayRadioButton.Text = "Day";
            this.dayRadioButton.UseVisualStyleBackColor = true;
            this.dayRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // nextButton
            // 
            this.nextButton.ImageIndex = 1;
            this.nextButton.ImageList = this.buttonImageList;
            this.nextButton.Location = new System.Drawing.Point(344, 20);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(24, 24);
            this.nextButton.TabIndex = 6;
            this.nextButton.TabStop = false;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.directionButtons_Click);
            // 
            // previousButton
            // 
            this.previousButton.ImageIndex = 2;
            this.previousButton.ImageList = this.buttonImageList;
            this.previousButton.Location = new System.Drawing.Point(314, 20);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(24, 24);
            this.previousButton.TabIndex = 5;
            this.previousButton.TabStop = false;
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.directionButtons_Click);
            // 
            // modelPeriodEndLabel
            // 
            this.modelPeriodEndLabel.AutoSize = true;
            this.modelPeriodEndLabel.Location = new System.Drawing.Point(72, 33);
            this.modelPeriodEndLabel.Name = "modelPeriodEndLabel";
            this.modelPeriodEndLabel.Size = new System.Drawing.Size(65, 13);
            this.modelPeriodEndLabel.TabIndex = 4;
            this.modelPeriodEndLabel.Text = "01/01/1900";
            // 
            // periodEndLabel
            // 
            this.periodEndLabel.AutoSize = true;
            this.periodEndLabel.Location = new System.Drawing.Point(3, 33);
            this.periodEndLabel.Name = "periodEndLabel";
            this.periodEndLabel.Size = new System.Drawing.Size(61, 13);
            this.periodEndLabel.TabIndex = 3;
            this.periodEndLabel.Text = "Period end:";
            // 
            // modelPeriodStartLabel
            // 
            this.modelPeriodStartLabel.AutoSize = true;
            this.modelPeriodStartLabel.Location = new System.Drawing.Point(72, 15);
            this.modelPeriodStartLabel.Name = "modelPeriodStartLabel";
            this.modelPeriodStartLabel.Size = new System.Drawing.Size(65, 13);
            this.modelPeriodStartLabel.TabIndex = 2;
            this.modelPeriodStartLabel.Text = "01/01/1900";
            // 
            // periodStartLabel
            // 
            this.periodStartLabel.AutoSize = true;
            this.periodStartLabel.Location = new System.Drawing.Point(3, 15);
            this.periodStartLabel.Name = "periodStartLabel";
            this.periodStartLabel.Size = new System.Drawing.Size(63, 13);
            this.periodStartLabel.TabIndex = 1;
            this.periodStartLabel.Text = "Period start:";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(571, 20);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.heatsTabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.mainPanel.Size = new System.Drawing.Size(652, 436);
            this.mainPanel.TabIndex = 1;
            // 
            // heatsTabControl
            // 
            this.heatsTabControl.Controls.Add(this.shiftTabPage);
            this.heatsTabControl.Controls.Add(this.cumulativeTabPage);
            this.heatsTabControl.Controls.Add(this.planningTabPage);
            this.heatsTabControl.Controls.Add(this.steelInMouldTabPage);
            this.heatsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatsTabControl.Location = new System.Drawing.Point(6, 6);
            this.heatsTabControl.Name = "heatsTabControl";
            this.heatsTabControl.SelectedIndex = 0;
            this.heatsTabControl.Size = new System.Drawing.Size(640, 430);
            this.heatsTabControl.TabIndex = 0;
            this.heatsTabControl.TabStop = false;
            // 
            // shiftTabPage
            // 
            this.shiftTabPage.Controls.Add(this.shiftHeatsPerDay);
            this.shiftTabPage.Location = new System.Drawing.Point(4, 22);
            this.shiftTabPage.Name = "shiftTabPage";
            this.shiftTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.shiftTabPage.Size = new System.Drawing.Size(632, 404);
            this.shiftTabPage.TabIndex = 0;
            this.shiftTabPage.Text = "Shift";
            this.shiftTabPage.UseVisualStyleBackColor = true;
            // 
            // shiftHeatsPerDay
            // 
            this.shiftHeatsPerDay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.shiftHeatsPerDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftHeatsPerDay.Location = new System.Drawing.Point(3, 3);
            this.shiftHeatsPerDay.Name = "shiftHeatsPerDay";
            this.shiftHeatsPerDay.Size = new System.Drawing.Size(626, 398);
            this.shiftHeatsPerDay.TabIndex = 0;
            // 
            // cumulativeTabPage
            // 
            this.cumulativeTabPage.Controls.Add(this.cumulativeShiftsPerDay);
            this.cumulativeTabPage.Location = new System.Drawing.Point(4, 22);
            this.cumulativeTabPage.Name = "cumulativeTabPage";
            this.cumulativeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cumulativeTabPage.Size = new System.Drawing.Size(632, 404);
            this.cumulativeTabPage.TabIndex = 1;
            this.cumulativeTabPage.Text = "Cumulative";
            this.cumulativeTabPage.UseVisualStyleBackColor = true;
            // 
            // cumulativeShiftsPerDay
            // 
            this.cumulativeShiftsPerDay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cumulativeShiftsPerDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cumulativeShiftsPerDay.Location = new System.Drawing.Point(3, 3);
            this.cumulativeShiftsPerDay.Name = "cumulativeShiftsPerDay";
            this.cumulativeShiftsPerDay.Size = new System.Drawing.Size(186, 68);
            this.cumulativeShiftsPerDay.TabIndex = 0;
            // 
            // planningTabPage
            // 
            this.planningTabPage.Controls.Add(this.planningShiftsPerDay);
            this.planningTabPage.Location = new System.Drawing.Point(4, 22);
            this.planningTabPage.Name = "planningTabPage";
            this.planningTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.planningTabPage.Size = new System.Drawing.Size(632, 404);
            this.planningTabPage.TabIndex = 2;
            this.planningTabPage.Text = "24 Hours Planning";
            this.planningTabPage.UseVisualStyleBackColor = true;
            // 
            // planningShiftsPerDay
            // 
            this.planningShiftsPerDay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.planningShiftsPerDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.planningShiftsPerDay.Location = new System.Drawing.Point(3, 3);
            this.planningShiftsPerDay.Name = "planningShiftsPerDay";
            this.planningShiftsPerDay.Size = new System.Drawing.Size(186, 68);
            this.planningShiftsPerDay.TabIndex = 0;
            // 
            // steelInMouldTabPage
            // 
            this.steelInMouldTabPage.Controls.Add(this.steelInMouldSpeedRatio);
            this.steelInMouldTabPage.Location = new System.Drawing.Point(4, 22);
            this.steelInMouldTabPage.Name = "steelInMouldTabPage";
            this.steelInMouldTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.steelInMouldTabPage.Size = new System.Drawing.Size(632, 404);
            this.steelInMouldTabPage.TabIndex = 3;
            this.steelInMouldTabPage.Text = "Steel in Mould & Speed Ratio";
            this.steelInMouldTabPage.UseVisualStyleBackColor = true;
            // 
            // steelInMouldSpeedRatio
            // 
            this.steelInMouldSpeedRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.steelInMouldSpeedRatio.Location = new System.Drawing.Point(3, 3);
            this.steelInMouldSpeedRatio.Name = "steelInMouldSpeedRatio";
            this.steelInMouldSpeedRatio.Size = new System.Drawing.Size(626, 398);
            this.steelInMouldSpeedRatio.TabIndex = 0;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // HeatsPerDayByCasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(652, 522);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "HeatsPerDayByCasterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heats Cast per Day by Caster";
            this.Shown += new System.EventHandler(this.HeatsPerDayByCasterForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeatsPerDayByCasterForm_KeyDown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.radioButtonPanel.ResumeLayout(false);
            this.radioButtonPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.heatsTabControl.ResumeLayout(false);
            this.shiftTabPage.ResumeLayout(false);
            this.cumulativeTabPage.ResumeLayout(false);
            this.planningTabPage.ResumeLayout(false);
            this.steelInMouldTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl heatsTabControl;
        private System.Windows.Forms.TabPage shiftTabPage;
        private System.Windows.Forms.TabPage cumulativeTabPage;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabPage planningTabPage;
        private UserControls.HeatDetails.HeatsPerDayByCaster shiftHeatsPerDay;
        private UserControls.HeatDetails.HeatsPerDayByCaster cumulativeShiftsPerDay;
        private UserControls.HeatDetails.HeatsPerDayByCaster planningShiftsPerDay;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Label modelPeriodEndLabel;
        private System.Windows.Forms.Label periodEndLabel;
        private System.Windows.Forms.Label modelPeriodStartLabel;
        private System.Windows.Forms.Label periodStartLabel;
        private System.Windows.Forms.Panel radioButtonPanel;
        private System.Windows.Forms.RadioButton weekRadioButton;
        private System.Windows.Forms.RadioButton dayRadioButton;
        private System.Windows.Forms.Button nowButton;
        private System.Windows.Forms.ImageList buttonImageList;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TabPage steelInMouldTabPage;
        private UserControls.HeatDetails.SteelInMouldSpeedRatio steelInMouldSpeedRatio;

    }
}