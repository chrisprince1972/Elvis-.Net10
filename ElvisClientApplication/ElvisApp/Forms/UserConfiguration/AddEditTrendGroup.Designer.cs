namespace Elvis.Forms.UserConfiguration
{
    partial class AddEditTrendGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditTrendGroup));
            this.pnlClose = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.pbHighlightInfo = new System.Windows.Forms.PictureBox();
            this.cmboGroupHighlight = new System.Windows.Forms.ComboBox();
            this.lblGroupHigh = new System.Windows.Forms.Label();
            this.pbEnabledInfo = new System.Windows.Forms.PictureBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.pbDescInfo = new System.Windows.Forms.PictureBox();
            this.pbParamInfo = new System.Windows.Forms.PictureBox();
            this.grpAllParameters = new System.Windows.Forms.GroupBox();
            this.lstAllParameters = new System.Windows.Forms.ListBox();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.lstParameters = new System.Windows.Forms.ListBox();
            this.btnRightToLeft = new System.Windows.Forms.Button();
            this.btnLeftToRight = new System.Windows.Forms.Button();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.lblGrpDesc = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlClose.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.pnlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighlightInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnabledInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbParamInfo)).BeginInit();
            this.grpAllParameters.SuspendLayout();
            this.grpParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.lblError);
            this.pnlClose.Controls.Add(this.btnSave);
            this.pnlClose.Controls.Add(this.btnCancel);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClose.Location = new System.Drawing.Point(0, 225);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Padding = new System.Windows.Forms.Padding(6, 0, 10, 5);
            this.pnlClose.Size = new System.Drawing.Size(478, 27);
            this.pnlClose.TabIndex = 6;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(326, 22);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Error Text";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(332, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(404, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6, 6, 6, 4);
            this.pnlMain.Size = new System.Drawing.Size(478, 225);
            this.pnlMain.TabIndex = 7;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.pnlGroup);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMain.Location = new System.Drawing.Point(6, 6);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(6);
            this.grpMain.Size = new System.Drawing.Size(466, 215);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "New Trend Group";
            // 
            // pnlGroup
            // 
            this.pnlGroup.Controls.Add(this.pbHighlightInfo);
            this.pnlGroup.Controls.Add(this.cmboGroupHighlight);
            this.pnlGroup.Controls.Add(this.lblGroupHigh);
            this.pnlGroup.Controls.Add(this.pbEnabledInfo);
            this.pnlGroup.Controls.Add(this.chbEnabled);
            this.pnlGroup.Controls.Add(this.pbDescInfo);
            this.pnlGroup.Controls.Add(this.pbParamInfo);
            this.pnlGroup.Controls.Add(this.grpAllParameters);
            this.pnlGroup.Controls.Add(this.grpParameters);
            this.pnlGroup.Controls.Add(this.btnRightToLeft);
            this.pnlGroup.Controls.Add(this.btnLeftToRight);
            this.pnlGroup.Controls.Add(this.txtGroupDesc);
            this.pnlGroup.Controls.Add(this.lblGrpDesc);
            this.pnlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroup.Location = new System.Drawing.Point(6, 19);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Padding = new System.Windows.Forms.Padding(3);
            this.pnlGroup.Size = new System.Drawing.Size(454, 190);
            this.pnlGroup.TabIndex = 1;
            // 
            // pbHighlightInfo
            // 
            this.pbHighlightInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbHighlightInfo.Image")));
            this.pbHighlightInfo.Location = new System.Drawing.Point(224, 32);
            this.pbHighlightInfo.Name = "pbHighlightInfo";
            this.pbHighlightInfo.Size = new System.Drawing.Size(21, 21);
            this.pbHighlightInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHighlightInfo.TabIndex = 19;
            this.pbHighlightInfo.TabStop = false;
            // 
            // cmboGroupHighlight
            // 
            this.cmboGroupHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboGroupHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboGroupHighlight.FormattingEnabled = true;
            this.cmboGroupHighlight.Location = new System.Drawing.Point(97, 32);
            this.cmboGroupHighlight.Name = "cmboGroupHighlight";
            this.cmboGroupHighlight.Size = new System.Drawing.Size(121, 21);
            this.cmboGroupHighlight.TabIndex = 18;
            this.cmboGroupHighlight.SelectedValueChanged += new System.EventHandler(this.cmboGroupHighlight_SelectedValueChanged);
            // 
            // lblGroupHigh
            // 
            this.lblGroupHigh.AutoSize = true;
            this.lblGroupHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupHigh.Location = new System.Drawing.Point(11, 36);
            this.lblGroupHigh.Name = "lblGroupHigh";
            this.lblGroupHigh.Size = new System.Drawing.Size(80, 13);
            this.lblGroupHigh.TabIndex = 17;
            this.lblGroupHigh.Text = "Group Highlight";
            // 
            // pbEnabledInfo
            // 
            this.pbEnabledInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbEnabledInfo.Image")));
            this.pbEnabledInfo.Location = new System.Drawing.Point(428, 32);
            this.pbEnabledInfo.Name = "pbEnabledInfo";
            this.pbEnabledInfo.Size = new System.Drawing.Size(20, 20);
            this.pbEnabledInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbEnabledInfo.TabIndex = 16;
            this.pbEnabledInfo.TabStop = false;
            // 
            // chbEnabled
            // 
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEnabled.Location = new System.Drawing.Point(328, 34);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(97, 17);
            this.chbEnabled.TabIndex = 15;
            this.chbEnabled.Text = "Group Enabled";
            this.chbEnabled.UseVisualStyleBackColor = true;
            this.chbEnabled.CheckedChanged += new System.EventHandler(this.chbEnabled_CheckedChanged);
            // 
            // pbDescInfo
            // 
            this.pbDescInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbDescInfo.Image")));
            this.pbDescInfo.Location = new System.Drawing.Point(428, 6);
            this.pbDescInfo.Name = "pbDescInfo";
            this.pbDescInfo.Size = new System.Drawing.Size(20, 20);
            this.pbDescInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDescInfo.TabIndex = 14;
            this.pbDescInfo.TabStop = false;
            // 
            // pbParamInfo
            // 
            this.pbParamInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbParamInfo.Image")));
            this.pbParamInfo.Location = new System.Drawing.Point(212, 115);
            this.pbParamInfo.Name = "pbParamInfo";
            this.pbParamInfo.Size = new System.Drawing.Size(30, 30);
            this.pbParamInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbParamInfo.TabIndex = 13;
            this.pbParamInfo.TabStop = false;
            // 
            // grpAllParameters
            // 
            this.grpAllParameters.Controls.Add(this.lstAllParameters);
            this.grpAllParameters.Location = new System.Drawing.Point(6, 62);
            this.grpAllParameters.Name = "grpAllParameters";
            this.grpAllParameters.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.grpAllParameters.Size = new System.Drawing.Size(200, 122);
            this.grpAllParameters.TabIndex = 12;
            this.grpAllParameters.TabStop = false;
            this.grpAllParameters.Text = "All Parameters";
            // 
            // lstAllParameters
            // 
            this.lstAllParameters.BackColor = System.Drawing.SystemColors.Window;
            this.lstAllParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAllParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstAllParameters.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstAllParameters.FormattingEnabled = true;
            this.lstAllParameters.HorizontalScrollbar = true;
            this.lstAllParameters.IntegralHeight = false;
            this.lstAllParameters.Items.AddRange(new object[] {
            "Parameter 1",
            "Parameter 2",
            "Parameter 3",
            "Parameter 4",
            "Parameter 5",
            "Parameter 6",
            "Parameter N"});
            this.lstAllParameters.Location = new System.Drawing.Point(3, 17);
            this.lstAllParameters.Name = "lstAllParameters";
            this.lstAllParameters.Size = new System.Drawing.Size(194, 102);
            this.lstAllParameters.TabIndex = 8;
            this.lstAllParameters.SelectedIndexChanged += new System.EventHandler(this.lstBox_SelectedIndexChanged);
            this.lstAllParameters.DoubleClick += new System.EventHandler(this.lstAllParameters_DoubleClick);
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.lstParameters);
            this.grpParameters.Location = new System.Drawing.Point(248, 62);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.grpParameters.Size = new System.Drawing.Size(200, 122);
            this.grpParameters.TabIndex = 11;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Group Parameters";
            // 
            // lstParameters
            // 
            this.lstParameters.BackColor = System.Drawing.SystemColors.Window;
            this.lstParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstParameters.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstParameters.FormattingEnabled = true;
            this.lstParameters.HorizontalScrollbar = true;
            this.lstParameters.IntegralHeight = false;
            this.lstParameters.Items.AddRange(new object[] {
            "Parameter 1",
            "Parameter 2",
            "Parameter 3",
            "Parameter 4",
            "Parameter 5"});
            this.lstParameters.Location = new System.Drawing.Point(3, 17);
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(194, 102);
            this.lstParameters.TabIndex = 8;
            this.lstParameters.SelectedIndexChanged += new System.EventHandler(this.lstBox_SelectedIndexChanged);
            this.lstParameters.DoubleClick += new System.EventHandler(this.lstParameters_DoubleClick);
            this.lstParameters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstParameters_KeyDown);
            // 
            // btnRightToLeft
            // 
            this.btnRightToLeft.Enabled = false;
            this.btnRightToLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRightToLeft.Image")));
            this.btnRightToLeft.Location = new System.Drawing.Point(212, 151);
            this.btnRightToLeft.Name = "btnRightToLeft";
            this.btnRightToLeft.Size = new System.Drawing.Size(30, 30);
            this.btnRightToLeft.TabIndex = 10;
            this.btnRightToLeft.UseVisualStyleBackColor = true;
            this.btnRightToLeft.Click += new System.EventHandler(this.btnRightToLeft_Click);
            // 
            // btnLeftToRight
            // 
            this.btnLeftToRight.Enabled = false;
            this.btnLeftToRight.Image = ((System.Drawing.Image)(resources.GetObject("btnLeftToRight.Image")));
            this.btnLeftToRight.Location = new System.Drawing.Point(212, 79);
            this.btnLeftToRight.Name = "btnLeftToRight";
            this.btnLeftToRight.Size = new System.Drawing.Size(30, 30);
            this.btnLeftToRight.TabIndex = 9;
            this.btnLeftToRight.UseVisualStyleBackColor = true;
            this.btnLeftToRight.Click += new System.EventHandler(this.btnLeftToRight_Click);
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupDesc.Location = new System.Drawing.Point(81, 6);
            this.txtGroupDesc.MaxLength = 50;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.Size = new System.Drawing.Size(341, 20);
            this.txtGroupDesc.TabIndex = 5;
            this.txtGroupDesc.TextChanged += new System.EventHandler(this.txtGroupDesc_TextChanged);
            // 
            // lblGrpDesc
            // 
            this.lblGrpDesc.AutoSize = true;
            this.lblGrpDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrpDesc.Location = new System.Drawing.Point(11, 9);
            this.lblGrpDesc.Name = "lblGrpDesc";
            this.lblGrpDesc.Size = new System.Drawing.Size(64, 13);
            this.lblGrpDesc.TabIndex = 4;
            this.lblGrpDesc.Text = "Group Desc";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 17000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1;
            // 
            // AddEditTrendGroup
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(478, 252);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditTrendGroup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Trend Group";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditTrendGroup_FormClosing);
            this.Load += new System.EventHandler(this.AddEditTrendGroup_Load);
            this.pnlClose.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighlightInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnabledInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbParamInfo)).EndInit();
            this.grpAllParameters.ResumeLayout(false);
            this.grpParameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Panel pnlGroup;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.Label lblGrpDesc;
        private System.Windows.Forms.ListBox lstParameters;
        private System.Windows.Forms.Button btnRightToLeft;
        private System.Windows.Forms.Button btnLeftToRight;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.GroupBox grpAllParameters;
        private System.Windows.Forms.ListBox lstAllParameters;
        private System.Windows.Forms.PictureBox pbParamInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbDescInfo;
        private System.Windows.Forms.PictureBox pbEnabledInfo;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.Label lblGroupHigh;
        private System.Windows.Forms.ComboBox cmboGroupHighlight;
        private System.Windows.Forms.PictureBox pbHighlightInfo;
    }
}