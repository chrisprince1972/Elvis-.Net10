namespace Elvis.Forms
{
    partial class HeatsPlannedVsActualForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatsPlannedVsActualForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.blueMessageLabel = new System.Windows.Forms.Label();
            this.greenMessageLabel = new System.Windows.Forms.Label();
            this.redMessageLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.plannedHeatsGroupBox = new System.Windows.Forms.GroupBox();
            this.plannedHeatsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cc1PlannedHeats = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.cc2PlannedHeats = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.cc3PlannedHeats = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.navigationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.plannedHeatsTotalLabel = new System.Windows.Forms.Label();
            this.navigationButtonsPanel = new System.Windows.Forms.Panel();
            this.nextButton = new System.Windows.Forms.Button();
            this.buttonImageList = new System.Windows.Forms.ImageList(this.components);
            this.previousButton = new System.Windows.Forms.Button();
            this.nowButton = new System.Windows.Forms.Button();
            this.actualHeatsGroupBox = new System.Windows.Forms.GroupBox();
            this.actualHeatsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.actualHeatsTotalLabel = new System.Windows.Forms.Label();
            this.cc1ActualHeats = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.cc2ActualHeats = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.cc3ActualHeats = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.heatsPlannedVsActual1 = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.heatsPlannedVsActual2 = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.heatsPlannedVsActual3 = new Elvis.UserControls.HeatDetails.HeatsPlannedVsActual();
            this.menuStrip1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.plannedHeatsGroupBox.SuspendLayout();
            this.plannedHeatsTableLayoutPanel.SuspendLayout();
            this.navigationTableLayoutPanel.SuspendLayout();
            this.navigationButtonsPanel.SuspendLayout();
            this.actualHeatsGroupBox.SuspendLayout();
            this.actualHeatsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.blueMessageLabel);
            this.buttonPanel.Controls.Add(this.greenMessageLabel);
            this.buttonPanel.Controls.Add(this.redMessageLabel);
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 706);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(912, 62);
            this.buttonPanel.TabIndex = 0;
            // 
            // blueMessageLabel
            // 
            this.blueMessageLabel.AutoSize = true;
            this.blueMessageLabel.ForeColor = System.Drawing.Color.Blue;
            this.blueMessageLabel.Location = new System.Drawing.Point(5, 39);
            this.blueMessageLabel.Name = "blueMessageLabel";
            this.blueMessageLabel.Size = new System.Drawing.Size(367, 13);
            this.blueMessageLabel.TabIndex = 3;
            this.blueMessageLabel.Text = "Blue - Heat cast on other caster (planned for one caster but cast on another)";
            // 
            // greenMessageLabel
            // 
            this.greenMessageLabel.AutoSize = true;
            this.greenMessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.greenMessageLabel.Location = new System.Drawing.Point(5, 25);
            this.greenMessageLabel.Name = "greenMessageLabel";
            this.greenMessageLabel.Size = new System.Drawing.Size(226, 13);
            this.greenMessageLabel.TabIndex = 2;
            this.greenMessageLabel.Text = "Green - extra Heat (Heat cast but not planned)";
            // 
            // redMessageLabel
            // 
            this.redMessageLabel.AutoSize = true;
            this.redMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.redMessageLabel.Location = new System.Drawing.Point(5, 11);
            this.redMessageLabel.Name = "redMessageLabel";
            this.redMessageLabel.Size = new System.Drawing.Size(217, 13);
            this.redMessageLabel.TabIndex = 1;
            this.redMessageLabel.Text = "Red - deviation (all red line = Heat not made)";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(829, 20);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.Controls.Add(this.plannedHeatsGroupBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.actualHeatsGroupBox, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(912, 682);
            this.mainTableLayoutPanel.TabIndex = 2;
            // 
            // plannedHeatsGroupBox
            // 
            this.plannedHeatsGroupBox.Controls.Add(this.plannedHeatsTableLayoutPanel);
            this.plannedHeatsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plannedHeatsGroupBox.Location = new System.Drawing.Point(8, 8);
            this.plannedHeatsGroupBox.Margin = new System.Windows.Forms.Padding(8, 8, 4, 0);
            this.plannedHeatsGroupBox.Name = "plannedHeatsGroupBox";
            this.plannedHeatsGroupBox.Size = new System.Drawing.Size(444, 674);
            this.plannedHeatsGroupBox.TabIndex = 0;
            this.plannedHeatsGroupBox.TabStop = false;
            this.plannedHeatsGroupBox.Text = "Planned Heats";
            // 
            // plannedHeatsTableLayoutPanel
            // 
            this.plannedHeatsTableLayoutPanel.ColumnCount = 1;
            this.plannedHeatsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.plannedHeatsTableLayoutPanel.Controls.Add(this.cc1PlannedHeats, 0, 0);
            this.plannedHeatsTableLayoutPanel.Controls.Add(this.cc2PlannedHeats, 0, 1);
            this.plannedHeatsTableLayoutPanel.Controls.Add(this.cc3PlannedHeats, 0, 2);
            this.plannedHeatsTableLayoutPanel.Controls.Add(this.navigationTableLayoutPanel, 0, 3);
            this.plannedHeatsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plannedHeatsTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.plannedHeatsTableLayoutPanel.Name = "plannedHeatsTableLayoutPanel";
            this.plannedHeatsTableLayoutPanel.RowCount = 4;
            this.plannedHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.plannedHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.plannedHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.plannedHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.plannedHeatsTableLayoutPanel.Size = new System.Drawing.Size(438, 655);
            this.plannedHeatsTableLayoutPanel.TabIndex = 0;
            // 
            // cc1PlannedHeats
            // 
            this.cc1PlannedHeats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cc1PlannedHeats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cc1PlannedHeats.HeatSummaries = null;
            this.cc1PlannedHeats.Location = new System.Drawing.Point(3, 3);
            this.cc1PlannedHeats.Name = "cc1PlannedHeats";
            this.cc1PlannedHeats.ShowTotalLabel = true;
            this.cc1PlannedHeats.Size = new System.Drawing.Size(432, 201);
            this.cc1PlannedHeats.TabIndex = 0;
            // 
            // cc2PlannedHeats
            // 
            this.cc2PlannedHeats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cc2PlannedHeats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cc2PlannedHeats.HeatSummaries = null;
            this.cc2PlannedHeats.Location = new System.Drawing.Point(3, 210);
            this.cc2PlannedHeats.Name = "cc2PlannedHeats";
            this.cc2PlannedHeats.ShowTotalLabel = true;
            this.cc2PlannedHeats.Size = new System.Drawing.Size(432, 201);
            this.cc2PlannedHeats.TabIndex = 1;
            // 
            // cc3PlannedHeats
            // 
            this.cc3PlannedHeats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cc3PlannedHeats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cc3PlannedHeats.HeatSummaries = null;
            this.cc3PlannedHeats.Location = new System.Drawing.Point(3, 417);
            this.cc3PlannedHeats.Name = "cc3PlannedHeats";
            this.cc3PlannedHeats.ShowTotalLabel = true;
            this.cc3PlannedHeats.Size = new System.Drawing.Size(432, 201);
            this.cc3PlannedHeats.TabIndex = 2;
            // 
            // navigationTableLayoutPanel
            // 
            this.navigationTableLayoutPanel.ColumnCount = 2;
            this.navigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navigationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.navigationTableLayoutPanel.Controls.Add(this.plannedHeatsTotalLabel, 1, 0);
            this.navigationTableLayoutPanel.Controls.Add(this.navigationButtonsPanel, 0, 0);
            this.navigationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationTableLayoutPanel.Location = new System.Drawing.Point(0, 621);
            this.navigationTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navigationTableLayoutPanel.Name = "navigationTableLayoutPanel";
            this.navigationTableLayoutPanel.RowCount = 1;
            this.navigationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navigationTableLayoutPanel.Size = new System.Drawing.Size(438, 34);
            this.navigationTableLayoutPanel.TabIndex = 3;
            // 
            // plannedHeatsTotalLabel
            // 
            this.plannedHeatsTotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.plannedHeatsTotalLabel.AutoSize = true;
            this.plannedHeatsTotalLabel.Location = new System.Drawing.Point(412, 10);
            this.plannedHeatsTotalLabel.Name = "plannedHeatsTotalLabel";
            this.plannedHeatsTotalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.plannedHeatsTotalLabel.Size = new System.Drawing.Size(23, 13);
            this.plannedHeatsTotalLabel.TabIndex = 4;
            this.plannedHeatsTotalLabel.Text = "0";
            this.plannedHeatsTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // navigationButtonsPanel
            // 
            this.navigationButtonsPanel.Controls.Add(this.nextButton);
            this.navigationButtonsPanel.Controls.Add(this.previousButton);
            this.navigationButtonsPanel.Controls.Add(this.nowButton);
            this.navigationButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navigationButtonsPanel.Name = "navigationButtonsPanel";
            this.navigationButtonsPanel.Size = new System.Drawing.Size(385, 34);
            this.navigationButtonsPanel.TabIndex = 5;
            // 
            // nextButton
            // 
            this.nextButton.ImageIndex = 2;
            this.nextButton.ImageList = this.buttonImageList;
            this.nextButton.Location = new System.Drawing.Point(231, 5);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(24, 24);
            this.nextButton.TabIndex = 2;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // buttonImageList
            // 
            this.buttonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonImageList.ImageStream")));
            this.buttonImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.buttonImageList.Images.SetKeyName(0, "Calendar_schedule.bmp");
            this.buttonImageList.Images.SetKeyName(1, "GoRtl.bmp");
            this.buttonImageList.Images.SetKeyName(2, "GoLtr.bmp");
            // 
            // previousButton
            // 
            this.previousButton.ImageIndex = 1;
            this.previousButton.ImageList = this.buttonImageList;
            this.previousButton.Location = new System.Drawing.Point(201, 5);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(24, 24);
            this.previousButton.TabIndex = 1;
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nowButton
            // 
            this.nowButton.ImageIndex = 0;
            this.nowButton.ImageList = this.buttonImageList;
            this.nowButton.Location = new System.Drawing.Point(171, 5);
            this.nowButton.Name = "nowButton";
            this.nowButton.Size = new System.Drawing.Size(24, 24);
            this.nowButton.TabIndex = 0;
            this.nowButton.UseVisualStyleBackColor = true;
            this.nowButton.Click += new System.EventHandler(this.nowButton_Click);
            // 
            // actualHeatsGroupBox
            // 
            this.actualHeatsGroupBox.Controls.Add(this.actualHeatsTableLayoutPanel);
            this.actualHeatsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualHeatsGroupBox.Location = new System.Drawing.Point(460, 8);
            this.actualHeatsGroupBox.Margin = new System.Windows.Forms.Padding(4, 8, 8, 0);
            this.actualHeatsGroupBox.Name = "actualHeatsGroupBox";
            this.actualHeatsGroupBox.Size = new System.Drawing.Size(444, 674);
            this.actualHeatsGroupBox.TabIndex = 1;
            this.actualHeatsGroupBox.TabStop = false;
            this.actualHeatsGroupBox.Text = "Actual Heats";
            // 
            // actualHeatsTableLayoutPanel
            // 
            this.actualHeatsTableLayoutPanel.ColumnCount = 1;
            this.actualHeatsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actualHeatsTableLayoutPanel.Controls.Add(this.actualHeatsTotalLabel, 0, 3);
            this.actualHeatsTableLayoutPanel.Controls.Add(this.cc1ActualHeats, 0, 0);
            this.actualHeatsTableLayoutPanel.Controls.Add(this.cc2ActualHeats, 0, 1);
            this.actualHeatsTableLayoutPanel.Controls.Add(this.cc3ActualHeats, 0, 2);
            this.actualHeatsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualHeatsTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.actualHeatsTableLayoutPanel.Name = "actualHeatsTableLayoutPanel";
            this.actualHeatsTableLayoutPanel.RowCount = 4;
            this.actualHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.actualHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.actualHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.actualHeatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.actualHeatsTableLayoutPanel.Size = new System.Drawing.Size(438, 655);
            this.actualHeatsTableLayoutPanel.TabIndex = 0;
            // 
            // actualHeatsTotalLabel
            // 
            this.actualHeatsTotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.actualHeatsTotalLabel.AutoSize = true;
            this.actualHeatsTotalLabel.Location = new System.Drawing.Point(412, 631);
            this.actualHeatsTotalLabel.Name = "actualHeatsTotalLabel";
            this.actualHeatsTotalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.actualHeatsTotalLabel.Size = new System.Drawing.Size(23, 13);
            this.actualHeatsTotalLabel.TabIndex = 4;
            this.actualHeatsTotalLabel.Text = "0";
            this.actualHeatsTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc1ActualHeats
            // 
            this.cc1ActualHeats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cc1ActualHeats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cc1ActualHeats.HeatSummaries = null;
            this.cc1ActualHeats.Location = new System.Drawing.Point(3, 3);
            this.cc1ActualHeats.Name = "cc1ActualHeats";
            this.cc1ActualHeats.ShowTotalLabel = true;
            this.cc1ActualHeats.Size = new System.Drawing.Size(432, 201);
            this.cc1ActualHeats.TabIndex = 0;
            // 
            // cc2ActualHeats
            // 
            this.cc2ActualHeats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cc2ActualHeats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cc2ActualHeats.HeatSummaries = null;
            this.cc2ActualHeats.Location = new System.Drawing.Point(3, 210);
            this.cc2ActualHeats.Name = "cc2ActualHeats";
            this.cc2ActualHeats.ShowTotalLabel = true;
            this.cc2ActualHeats.Size = new System.Drawing.Size(432, 201);
            this.cc2ActualHeats.TabIndex = 1;
            // 
            // cc3ActualHeats
            // 
            this.cc3ActualHeats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cc3ActualHeats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cc3ActualHeats.HeatSummaries = null;
            this.cc3ActualHeats.Location = new System.Drawing.Point(3, 417);
            this.cc3ActualHeats.Name = "cc3ActualHeats";
            this.cc3ActualHeats.ShowTotalLabel = true;
            this.cc3ActualHeats.Size = new System.Drawing.Size(432, 201);
            this.cc3ActualHeats.TabIndex = 2;
            // 
            // heatsPlannedVsActual1
            // 
            this.heatsPlannedVsActual1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.heatsPlannedVsActual1.HeatSummaries = null;
            this.heatsPlannedVsActual1.Location = new System.Drawing.Point(0, 0);
            this.heatsPlannedVsActual1.Name = "heatsPlannedVsActual1";
            this.heatsPlannedVsActual1.ShowTotalLabel = true;
            this.heatsPlannedVsActual1.Size = new System.Drawing.Size(428, 228);
            this.heatsPlannedVsActual1.TabIndex = 0;
            // 
            // heatsPlannedVsActual2
            // 
            this.heatsPlannedVsActual2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.heatsPlannedVsActual2.HeatSummaries = null;
            this.heatsPlannedVsActual2.Location = new System.Drawing.Point(0, 0);
            this.heatsPlannedVsActual2.Name = "heatsPlannedVsActual2";
            this.heatsPlannedVsActual2.ShowTotalLabel = true;
            this.heatsPlannedVsActual2.Size = new System.Drawing.Size(428, 228);
            this.heatsPlannedVsActual2.TabIndex = 0;
            // 
            // heatsPlannedVsActual3
            // 
            this.heatsPlannedVsActual3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.heatsPlannedVsActual3.HeatSummaries = null;
            this.heatsPlannedVsActual3.Location = new System.Drawing.Point(0, 0);
            this.heatsPlannedVsActual3.Name = "heatsPlannedVsActual3";
            this.heatsPlannedVsActual3.ShowTotalLabel = true;
            this.heatsPlannedVsActual3.Size = new System.Drawing.Size(428, 228);
            this.heatsPlannedVsActual3.TabIndex = 0;
            // 
            // HeatsPlannedVsActualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(912, 768);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeatsPlannedVsActualForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Planned vs Actual Heats";
            this.Shown += new System.EventHandler(this.HeatsPlannedVsActualForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.plannedHeatsGroupBox.ResumeLayout(false);
            this.plannedHeatsTableLayoutPanel.ResumeLayout(false);
            this.navigationTableLayoutPanel.ResumeLayout(false);
            this.navigationTableLayoutPanel.PerformLayout();
            this.navigationButtonsPanel.ResumeLayout(false);
            this.actualHeatsGroupBox.ResumeLayout(false);
            this.actualHeatsTableLayoutPanel.ResumeLayout(false);
            this.actualHeatsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Label blueMessageLabel;
        private System.Windows.Forms.Label greenMessageLabel;
        private System.Windows.Forms.Label redMessageLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.GroupBox plannedHeatsGroupBox;
        private System.Windows.Forms.GroupBox actualHeatsGroupBox;
        private System.Windows.Forms.TableLayoutPanel plannedHeatsTableLayoutPanel;
        private UserControls.HeatDetails.HeatsPlannedVsActual cc1PlannedHeats;
        private UserControls.HeatDetails.HeatsPlannedVsActual cc2PlannedHeats;
        private UserControls.HeatDetails.HeatsPlannedVsActual cc3PlannedHeats;
        private System.Windows.Forms.TableLayoutPanel actualHeatsTableLayoutPanel;
        private UserControls.HeatDetails.HeatsPlannedVsActual heatsPlannedVsActual1;
        private UserControls.HeatDetails.HeatsPlannedVsActual heatsPlannedVsActual2;
        private UserControls.HeatDetails.HeatsPlannedVsActual heatsPlannedVsActual3;
        private UserControls.HeatDetails.HeatsPlannedVsActual cc1ActualHeats;
        private UserControls.HeatDetails.HeatsPlannedVsActual cc2ActualHeats;
        private UserControls.HeatDetails.HeatsPlannedVsActual cc3ActualHeats;
        private System.Windows.Forms.Label actualHeatsTotalLabel;
        private System.Windows.Forms.TableLayoutPanel navigationTableLayoutPanel;
        private System.Windows.Forms.Label plannedHeatsTotalLabel;
        private System.Windows.Forms.Panel navigationButtonsPanel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nowButton;
        private System.Windows.Forms.ImageList buttonImageList;
    }
}