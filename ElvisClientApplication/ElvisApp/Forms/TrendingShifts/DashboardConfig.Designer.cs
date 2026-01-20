namespace Elvis.Forms.TrendingShifts
{
    partial class DashboardConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardConfig));
            this.optionsContainer = new System.Windows.Forms.SplitContainer();
            this.treeDashboards = new System.Windows.Forms.TreeView();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.grpKPIConfig = new System.Windows.Forms.GroupBox();
            this.pnlKPIDetails = new System.Windows.Forms.Panel();
            this.grpKPIAction = new System.Windows.Forms.GroupBox();
            this.cmboGroupConfigs = new System.Windows.Forms.ComboBox();
            this.lblTrendGroup = new System.Windows.Forms.Label();
            this.cmboKPIActions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpExample = new System.Windows.Forms.GroupBox();
            this.chbShowValue = new System.Windows.Forms.CheckBox();
            this.chbTrailingZeros = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numDP = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.lblMin = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.grpTooltip = new System.Windows.Forms.GroupBox();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblPleaseSelect = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.optionsContainer)).BeginInit();
            this.optionsContainer.Panel1.SuspendLayout();
            this.optionsContainer.Panel2.SuspendLayout();
            this.optionsContainer.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            this.grpKPIConfig.SuspendLayout();
            this.pnlKPIDetails.SuspendLayout();
            this.grpKPIAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            this.grpTooltip.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsContainer
            // 
            this.optionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsContainer.Location = new System.Drawing.Point(6, 6);
            this.optionsContainer.Name = "optionsContainer";
            // 
            // optionsContainer.Panel1
            // 
            this.optionsContainer.Panel1.Controls.Add(this.treeDashboards);
            // 
            // optionsContainer.Panel2
            // 
            this.optionsContainer.Panel2.Controls.Add(this.pnlConfig);
            this.optionsContainer.Panel2.Controls.Add(this.pnlButtons);
            this.optionsContainer.Size = new System.Drawing.Size(703, 428);
            this.optionsContainer.SplitterDistance = 243;
            this.optionsContainer.TabIndex = 1;
            // 
            // treeDashboards
            // 
            this.treeDashboards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDashboards.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDashboards.Location = new System.Drawing.Point(0, 0);
            this.treeDashboards.Name = "treeDashboards";
            this.treeDashboards.Size = new System.Drawing.Size(243, 428);
            this.treeDashboards.TabIndex = 0;
            this.treeDashboards.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDashboards_BeforeSelect);
            this.treeDashboards.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDashboards_AfterSelect);
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.grpKPIConfig);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.pnlConfig.Size = new System.Drawing.Size(456, 402);
            this.pnlConfig.TabIndex = 4;
            // 
            // grpKPIConfig
            // 
            this.grpKPIConfig.Controls.Add(this.pnlKPIDetails);
            this.grpKPIConfig.Controls.Add(this.lblPleaseSelect);
            this.grpKPIConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKPIConfig.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKPIConfig.Location = new System.Drawing.Point(1, 0);
            this.grpKPIConfig.Name = "grpKPIConfig";
            this.grpKPIConfig.Padding = new System.Windows.Forms.Padding(8);
            this.grpKPIConfig.Size = new System.Drawing.Size(454, 401);
            this.grpKPIConfig.TabIndex = 0;
            this.grpKPIConfig.TabStop = false;
            this.grpKPIConfig.Text = "KPI Configuration";
            // 
            // pnlKPIDetails
            // 
            this.pnlKPIDetails.Controls.Add(this.grpKPIAction);
            this.pnlKPIDetails.Controls.Add(this.grpExample);
            this.pnlKPIDetails.Controls.Add(this.chbShowValue);
            this.pnlKPIDetails.Controls.Add(this.chbTrailingZeros);
            this.pnlKPIDetails.Controls.Add(this.label2);
            this.pnlKPIDetails.Controls.Add(this.numDP);
            this.pnlKPIDetails.Controls.Add(this.label1);
            this.pnlKPIDetails.Controls.Add(this.numMax);
            this.pnlKPIDetails.Controls.Add(this.lblMin);
            this.pnlKPIDetails.Controls.Add(this.numMin);
            this.pnlKPIDetails.Controls.Add(this.grpTooltip);
            this.pnlKPIDetails.Controls.Add(this.grpInfo);
            this.pnlKPIDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKPIDetails.Location = new System.Drawing.Point(8, 23);
            this.pnlKPIDetails.Name = "pnlKPIDetails";
            this.pnlKPIDetails.Size = new System.Drawing.Size(438, 370);
            this.pnlKPIDetails.TabIndex = 1;
            // 
            // grpKPIAction
            // 
            this.grpKPIAction.Controls.Add(this.cmboGroupConfigs);
            this.grpKPIAction.Controls.Add(this.cmboKPIActions);
            this.grpKPIAction.Controls.Add(this.label3);
            this.grpKPIAction.Controls.Add(this.lblTrendGroup);
            this.grpKPIAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpKPIAction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKPIAction.Location = new System.Drawing.Point(0, 109);
            this.grpKPIAction.Name = "grpKPIAction";
            this.grpKPIAction.Padding = new System.Windows.Forms.Padding(4, 4, 6, 3);
            this.grpKPIAction.Size = new System.Drawing.Size(438, 52);
            this.grpKPIAction.TabIndex = 11;
            this.grpKPIAction.TabStop = false;
            this.grpKPIAction.Text = "KPI Action";
            // 
            // cmboGroupConfigs
            // 
            this.cmboGroupConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboGroupConfigs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboGroupConfigs.FormattingEnabled = true;
            this.cmboGroupConfigs.Location = new System.Drawing.Point(238, 21);
            this.cmboGroupConfigs.Name = "cmboGroupConfigs";
            this.cmboGroupConfigs.Size = new System.Drawing.Size(191, 21);
            this.cmboGroupConfigs.TabIndex = 7;
            this.cmboGroupConfigs.Visible = false;
            // 
            // lblTrendGroup
            // 
            this.lblTrendGroup.AutoSize = true;
            this.lblTrendGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrendGroup.Location = new System.Drawing.Point(155, 23);
            this.lblTrendGroup.Name = "lblTrendGroup";
            this.lblTrendGroup.Size = new System.Drawing.Size(77, 14);
            this.lblTrendGroup.TabIndex = 6;
            this.lblTrendGroup.Text = "Trend Group";
            this.lblTrendGroup.Visible = false;
            // 
            // cmboKPIActions
            // 
            this.cmboKPIActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboKPIActions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboKPIActions.FormattingEnabled = true;
            this.cmboKPIActions.Location = new System.Drawing.Point(55, 21);
            this.cmboKPIActions.Name = "cmboKPIActions";
            this.cmboKPIActions.Size = new System.Drawing.Size(158, 21);
            this.cmboKPIActions.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Action";
            // 
            // grpExample
            // 
            this.grpExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExample.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExample.Location = new System.Drawing.Point(318, 39);
            this.grpExample.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.grpExample.Name = "grpExample";
            this.grpExample.Size = new System.Drawing.Size(120, 70);
            this.grpExample.TabIndex = 10;
            this.grpExample.TabStop = false;
            this.grpExample.Text = "Example Data";
            // 
            // chbShowValue
            // 
            this.chbShowValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowValue.Location = new System.Drawing.Point(6, 83);
            this.chbShowValue.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chbShowValue.Name = "chbShowValue";
            this.chbShowValue.Size = new System.Drawing.Size(171, 22);
            this.chbShowValue.TabIndex = 9;
            this.chbShowValue.Text = "Show data value";
            this.chbShowValue.UseVisualStyleBackColor = true;
            this.chbShowValue.CheckedChanged += new System.EventHandler(this.chbShowValue_CheckedChanged);
            // 
            // chbTrailingZeros
            // 
            this.chbTrailingZeros.Enabled = false;
            this.chbTrailingZeros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTrailingZeros.Location = new System.Drawing.Point(6, 61);
            this.chbTrailingZeros.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.chbTrailingZeros.Name = "chbTrailingZeros";
            this.chbTrailingZeros.Size = new System.Drawing.Size(200, 22);
            this.chbTrailingZeros.TabIndex = 8;
            this.chbTrailingZeros.Text = "Always show any trailing zeros";
            this.chbTrailingZeros.UseVisualStyleBackColor = true;
            this.chbTrailingZeros.CheckedChanged += new System.EventHandler(this.chbTrailingZeros_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Decimal Places";
            // 
            // numDP
            // 
            this.numDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDP.Location = new System.Drawing.Point(94, 35);
            this.numDP.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numDP.Name = "numDP";
            this.numDP.Size = new System.Drawing.Size(43, 20);
            this.numDP.TabIndex = 6;
            this.numDP.ValueChanged += new System.EventHandler(this.numDP_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Maximum";
            // 
            // numMax
            // 
            this.numMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMax.Location = new System.Drawing.Point(218, 9);
            this.numMax.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMax.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(86, 20);
            this.numMax.TabIndex = 4;
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(3, 10);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(54, 14);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "Minimum";
            // 
            // numMin
            // 
            this.numMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMin.Location = new System.Drawing.Point(63, 9);
            this.numMin.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMin.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(86, 20);
            this.numMin.TabIndex = 2;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // grpTooltip
            // 
            this.grpTooltip.Controls.Add(this.txtTooltip);
            this.grpTooltip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpTooltip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTooltip.Location = new System.Drawing.Point(0, 161);
            this.grpTooltip.Name = "grpTooltip";
            this.grpTooltip.Padding = new System.Windows.Forms.Padding(4, 3, 4, 4);
            this.grpTooltip.Size = new System.Drawing.Size(438, 54);
            this.grpTooltip.TabIndex = 12;
            this.grpTooltip.TabStop = false;
            this.grpTooltip.Text = "Tooltip";
            // 
            // txtTooltip
            // 
            this.txtTooltip.AcceptsReturn = true;
            this.txtTooltip.AcceptsTab = true;
            this.txtTooltip.AllowDrop = true;
            this.txtTooltip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTooltip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTooltip.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTooltip.Location = new System.Drawing.Point(4, 17);
            this.txtTooltip.MaxLength = 1500;
            this.txtTooltip.Multiline = true;
            this.txtTooltip.Name = "txtTooltip";
            this.txtTooltip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTooltip.Size = new System.Drawing.Size(430, 33);
            this.txtTooltip.TabIndex = 2;
            this.txtTooltip.TextChanged += new System.EventHandler(this.txtTooltip_TextChanged);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtInfo);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(0, 215);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(4);
            this.grpInfo.Size = new System.Drawing.Size(438, 155);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "KPI Information";
            // 
            // txtInfo
            // 
            this.txtInfo.AcceptsReturn = true;
            this.txtInfo.AcceptsTab = true;
            this.txtInfo.AllowDrop = true;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInfo.Location = new System.Drawing.Point(4, 18);
            this.txtInfo.MaxLength = 1500;
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(430, 133);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.TextChanged += new System.EventHandler(this.txtInfo_TextChanged);
            // 
            // lblPleaseSelect
            // 
            this.lblPleaseSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPleaseSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseSelect.Location = new System.Drawing.Point(8, 23);
            this.lblPleaseSelect.Name = "lblPleaseSelect";
            this.lblPleaseSelect.Size = new System.Drawing.Size(438, 370);
            this.lblPleaseSelect.TabIndex = 0;
            this.lblPleaseSelect.Text = "Please select a KPI to view.";
            this.lblPleaseSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 402);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(456, 26);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(257, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 1, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(358, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DashboardConfig
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(715, 440);
            this.Controls.Add(this.optionsContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardConfig";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardConfig_FormClosing);
            this.optionsContainer.Panel1.ResumeLayout(false);
            this.optionsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionsContainer)).EndInit();
            this.optionsContainer.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.grpKPIConfig.ResumeLayout(false);
            this.pnlKPIDetails.ResumeLayout(false);
            this.pnlKPIDetails.PerformLayout();
            this.grpKPIAction.ResumeLayout(false);
            this.grpKPIAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            this.grpTooltip.ResumeLayout(false);
            this.grpTooltip.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer optionsContainer;
        private System.Windows.Forms.TreeView treeDashboards;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.GroupBox grpKPIConfig;
        private System.Windows.Forms.Label lblPleaseSelect;
        private System.Windows.Forms.Panel pnlKPIDetails;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDP;
        private System.Windows.Forms.CheckBox chbTrailingZeros;
        private System.Windows.Forms.CheckBox chbShowValue;
        private System.Windows.Forms.GroupBox grpExample;
        private System.Windows.Forms.GroupBox grpKPIAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmboKPIActions;
        private System.Windows.Forms.Label lblTrendGroup;
        private System.Windows.Forms.ComboBox cmboGroupConfigs;
        private System.Windows.Forms.GroupBox grpTooltip;
        private System.Windows.Forms.TextBox txtTooltip;
        private System.Windows.Forms.ToolTip toolTips;
    }
}
