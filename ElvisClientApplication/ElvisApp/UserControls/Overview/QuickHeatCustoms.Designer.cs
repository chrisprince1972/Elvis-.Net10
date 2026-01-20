namespace Elvis.UserControls.HeatDetails
{
    partial class QuickHeatCustoms
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
            this.pnlCustoms = new System.Windows.Forms.Panel();
            this.grpCustomisation = new System.Windows.Forms.GroupBox();
            this.chbMiscasts = new System.Windows.Forms.CheckBox();
            this.pnlExtraData = new System.Windows.Forms.Panel();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.rbShowLadleNo = new System.Windows.Forms.RadioButton();
            this.rbShowProgNo = new System.Windows.Forms.RadioButton();
            this.rbShowNone = new System.Windows.Forms.RadioButton();
            this.rbShowGrade = new System.Windows.Forms.RadioButton();
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.chbCasters = new System.Windows.Forms.CheckBox();
            this.chbSecSteel = new System.Windows.Forms.CheckBox();
            this.chbVessels = new System.Windows.Forms.CheckBox();
            this.chbHMDes = new System.Windows.Forms.CheckBox();
            this.chbHMPour = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbColourByVessel = new System.Windows.Forms.RadioButton();
            this.trackBarCellWidth = new System.Windows.Forms.TrackBar();
            this.rbColourByCaster = new System.Windows.Forms.RadioButton();
            this.chbTimeLine = new System.Windows.Forms.CheckBox();
            this.chbShowShadows = new System.Windows.Forms.CheckBox();
            this.pnlCustoms.SuspendLayout();
            this.grpCustomisation.SuspendLayout();
            this.pnlExtraData.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCellWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCustoms
            // 
            this.pnlCustoms.Controls.Add(this.grpCustomisation);
            this.pnlCustoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustoms.Location = new System.Drawing.Point(0, 0);
            this.pnlCustoms.Name = "pnlCustoms";
            this.pnlCustoms.Padding = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.pnlCustoms.Size = new System.Drawing.Size(479, 145);
            this.pnlCustoms.TabIndex = 1;
            // 
            // grpCustomisation
            // 
            this.grpCustomisation.Controls.Add(this.chbMiscasts);
            this.grpCustomisation.Controls.Add(this.pnlExtraData);
            this.grpCustomisation.Controls.Add(this.grpUnits);
            this.grpCustomisation.Controls.Add(this.label1);
            this.grpCustomisation.Controls.Add(this.rbColourByVessel);
            this.grpCustomisation.Controls.Add(this.trackBarCellWidth);
            this.grpCustomisation.Controls.Add(this.rbColourByCaster);
            this.grpCustomisation.Controls.Add(this.chbTimeLine);
            this.grpCustomisation.Controls.Add(this.chbShowShadows);
            this.grpCustomisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCustomisation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomisation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCustomisation.Location = new System.Drawing.Point(3, 3);
            this.grpCustomisation.Name = "grpCustomisation";
            this.grpCustomisation.Padding = new System.Windows.Forms.Padding(6);
            this.grpCustomisation.Size = new System.Drawing.Size(470, 136);
            this.grpCustomisation.TabIndex = 3;
            this.grpCustomisation.TabStop = false;
            this.grpCustomisation.Text = "Overview Customisations";
            // 
            // chbMiscasts
            // 
            this.chbMiscasts.AutoSize = true;
            this.chbMiscasts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMiscasts.Location = new System.Drawing.Point(12, 59);
            this.chbMiscasts.Name = "chbMiscasts";
            this.chbMiscasts.Size = new System.Drawing.Size(95, 17);
            this.chbMiscasts.TabIndex = 19;
            this.chbMiscasts.Text = "Show Miscasts";
            this.chbMiscasts.UseVisualStyleBackColor = true;
            this.chbMiscasts.CheckedChanged += new System.EventHandler(this.chbMiscasts_CheckedChanged);
            // 
            // pnlExtraData
            // 
            this.pnlExtraData.Controls.Add(this.grpData);
            this.pnlExtraData.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlExtraData.Location = new System.Drawing.Point(232, 20);
            this.pnlExtraData.Name = "pnlExtraData";
            this.pnlExtraData.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlExtraData.Size = new System.Drawing.Size(133, 110);
            this.pnlExtraData.TabIndex = 18;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.rbShowLadleNo);
            this.grpData.Controls.Add(this.rbShowProgNo);
            this.grpData.Controls.Add(this.rbShowNone);
            this.grpData.Controls.Add(this.rbShowGrade);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(8, 4, 3, 3);
            this.grpData.Size = new System.Drawing.Size(127, 110);
            this.grpData.TabIndex = 15;
            this.grpData.TabStop = false;
            this.grpData.Text = "Extra Data";
            // 
            // rbShowLadleNo
            // 
            this.rbShowLadleNo.AutoSize = true;
            this.rbShowLadleNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowLadleNo.Location = new System.Drawing.Point(11, 77);
            this.rbShowLadleNo.Name = "rbShowLadleNo";
            this.rbShowLadleNo.Size = new System.Drawing.Size(99, 17);
            this.rbShowLadleNo.TabIndex = 14;
            this.rbShowLadleNo.Tag = "LadleNo";
            this.rbShowLadleNo.Text = "Show Ladle No.";
            this.rbShowLadleNo.UseVisualStyleBackColor = true;
            this.rbShowLadleNo.CheckedChanged += new System.EventHandler(this.rbExtraData_CheckedChanged);
            // 
            // rbShowProgNo
            // 
            this.rbShowProgNo.AutoSize = true;
            this.rbShowProgNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowProgNo.Location = new System.Drawing.Point(11, 39);
            this.rbShowProgNo.Name = "rbShowProgNo";
            this.rbShowProgNo.Size = new System.Drawing.Size(114, 17);
            this.rbShowProgNo.TabIndex = 11;
            this.rbShowProgNo.Tag = "ProgramNo";
            this.rbShowProgNo.Text = "Show Program No.";
            this.rbShowProgNo.UseVisualStyleBackColor = true;
            this.rbShowProgNo.CheckedChanged += new System.EventHandler(this.rbExtraData_CheckedChanged);
            // 
            // rbShowNone
            // 
            this.rbShowNone.AutoSize = true;
            this.rbShowNone.Checked = true;
            this.rbShowNone.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowNone.Location = new System.Drawing.Point(11, 20);
            this.rbShowNone.Name = "rbShowNone";
            this.rbShowNone.Size = new System.Drawing.Size(50, 17);
            this.rbShowNone.TabIndex = 13;
            this.rbShowNone.TabStop = true;
            this.rbShowNone.Tag = "None";
            this.rbShowNone.Text = "None";
            this.rbShowNone.UseVisualStyleBackColor = true;
            this.rbShowNone.CheckedChanged += new System.EventHandler(this.rbExtraData_CheckedChanged);
            // 
            // rbShowGrade
            // 
            this.rbShowGrade.AutoSize = true;
            this.rbShowGrade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowGrade.Location = new System.Drawing.Point(11, 58);
            this.rbShowGrade.Name = "rbShowGrade";
            this.rbShowGrade.Size = new System.Drawing.Size(83, 17);
            this.rbShowGrade.TabIndex = 12;
            this.rbShowGrade.Tag = "Grade";
            this.rbShowGrade.Text = "Show Grade";
            this.rbShowGrade.UseVisualStyleBackColor = true;
            this.rbShowGrade.CheckedChanged += new System.EventHandler(this.rbExtraData_CheckedChanged);
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.chbCasters);
            this.grpUnits.Controls.Add(this.chbSecSteel);
            this.grpUnits.Controls.Add(this.chbVessels);
            this.grpUnits.Controls.Add(this.chbHMDes);
            this.grpUnits.Controls.Add(this.chbHMPour);
            this.grpUnits.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpUnits.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUnits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpUnits.Location = new System.Drawing.Point(365, 20);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Padding = new System.Windows.Forms.Padding(8, 4, 3, 3);
            this.grpUnits.Size = new System.Drawing.Size(99, 110);
            this.grpUnits.TabIndex = 17;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            // 
            // chbCasters
            // 
            this.chbCasters.AutoSize = true;
            this.chbCasters.Checked = true;
            this.chbCasters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCasters.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbCasters.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCasters.Location = new System.Drawing.Point(8, 86);
            this.chbCasters.Name = "chbCasters";
            this.chbCasters.Size = new System.Drawing.Size(88, 17);
            this.chbCasters.TabIndex = 22;
            this.chbCasters.Tag = "11|12|13";
            this.chbCasters.Text = "Casters";
            this.chbCasters.UseVisualStyleBackColor = true;
            this.chbCasters.CheckedChanged += new System.EventHandler(this.chbUnit_CheckedChanged);
            // 
            // chbSecSteel
            // 
            this.chbSecSteel.AutoSize = true;
            this.chbSecSteel.Checked = true;
            this.chbSecSteel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSecSteel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbSecSteel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSecSteel.Location = new System.Drawing.Point(8, 69);
            this.chbSecSteel.Name = "chbSecSteel";
            this.chbSecSteel.Size = new System.Drawing.Size(88, 17);
            this.chbSecSteel.TabIndex = 20;
            this.chbSecSteel.Tag = "7|8|9|10";
            this.chbSecSteel.Text = "Sec Steel";
            this.chbSecSteel.UseVisualStyleBackColor = true;
            this.chbSecSteel.CheckedChanged += new System.EventHandler(this.chbUnit_CheckedChanged);
            // 
            // chbVessels
            // 
            this.chbVessels.AutoSize = true;
            this.chbVessels.Checked = true;
            this.chbVessels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVessels.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbVessels.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbVessels.Location = new System.Drawing.Point(8, 52);
            this.chbVessels.Name = "chbVessels";
            this.chbVessels.Size = new System.Drawing.Size(88, 17);
            this.chbVessels.TabIndex = 19;
            this.chbVessels.Tag = "5|6";
            this.chbVessels.Text = "Vessels";
            this.chbVessels.UseVisualStyleBackColor = true;
            this.chbVessels.CheckedChanged += new System.EventHandler(this.chbUnit_CheckedChanged);
            // 
            // chbHMDes
            // 
            this.chbHMDes.AutoSize = true;
            this.chbHMDes.Checked = true;
            this.chbHMDes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMDes.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbHMDes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMDes.Location = new System.Drawing.Point(8, 35);
            this.chbHMDes.Name = "chbHMDes";
            this.chbHMDes.Size = new System.Drawing.Size(88, 17);
            this.chbHMDes.TabIndex = 18;
            this.chbHMDes.Tag = "3|4";
            this.chbHMDes.Text = "HM Desulph";
            this.chbHMDes.UseVisualStyleBackColor = true;
            this.chbHMDes.CheckedChanged += new System.EventHandler(this.chbUnit_CheckedChanged);
            // 
            // chbHMPour
            // 
            this.chbHMPour.AutoSize = true;
            this.chbHMPour.Checked = true;
            this.chbHMPour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMPour.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbHMPour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMPour.Location = new System.Drawing.Point(8, 18);
            this.chbHMPour.Name = "chbHMPour";
            this.chbHMPour.Size = new System.Drawing.Size(88, 17);
            this.chbHMPour.TabIndex = 17;
            this.chbHMPour.Tag = "1|2";
            this.chbHMPour.Text = "HM Pour";
            this.chbHMPour.UseVisualStyleBackColor = true;
            this.chbHMPour.CheckedChanged += new System.EventHandler(this.chbUnit_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cell Width:";
            // 
            // rbColourByVessel
            // 
            this.rbColourByVessel.AutoSize = true;
            this.rbColourByVessel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbColourByVessel.Location = new System.Drawing.Point(118, 42);
            this.rbColourByVessel.Name = "rbColourByVessel";
            this.rbColourByVessel.Size = new System.Drawing.Size(104, 17);
            this.rbColourByVessel.TabIndex = 1;
            this.rbColourByVessel.Tag = "Vessel";
            this.rbColourByVessel.Text = "Colour by Vessel";
            this.rbColourByVessel.UseVisualStyleBackColor = true;
            this.rbColourByVessel.CheckedChanged += new System.EventHandler(this.rbColourBy_CheckedChanged);
            // 
            // trackBarCellWidth
            // 
            this.trackBarCellWidth.LargeChange = 10;
            this.trackBarCellWidth.Location = new System.Drawing.Point(73, 83);
            this.trackBarCellWidth.Maximum = 90;
            this.trackBarCellWidth.Minimum = 30;
            this.trackBarCellWidth.Name = "trackBarCellWidth";
            this.trackBarCellWidth.Size = new System.Drawing.Size(148, 45);
            this.trackBarCellWidth.SmallChange = 5;
            this.trackBarCellWidth.TabIndex = 1;
            this.trackBarCellWidth.Value = 50;
            this.trackBarCellWidth.Scroll += new System.EventHandler(this.trackBarCellWidth_Scroll);
            // 
            // rbColourByCaster
            // 
            this.rbColourByCaster.AutoSize = true;
            this.rbColourByCaster.Checked = true;
            this.rbColourByCaster.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbColourByCaster.Location = new System.Drawing.Point(118, 25);
            this.rbColourByCaster.Name = "rbColourByCaster";
            this.rbColourByCaster.Size = new System.Drawing.Size(106, 17);
            this.rbColourByCaster.TabIndex = 0;
            this.rbColourByCaster.TabStop = true;
            this.rbColourByCaster.Tag = "Caster";
            this.rbColourByCaster.Text = "Colour by Caster";
            this.rbColourByCaster.UseVisualStyleBackColor = true;
            this.rbColourByCaster.CheckedChanged += new System.EventHandler(this.rbColourBy_CheckedChanged);
            // 
            // chbTimeLine
            // 
            this.chbTimeLine.AutoSize = true;
            this.chbTimeLine.Checked = true;
            this.chbTimeLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTimeLine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTimeLine.Location = new System.Drawing.Point(12, 42);
            this.chbTimeLine.Name = "chbTimeLine";
            this.chbTimeLine.Size = new System.Drawing.Size(93, 17);
            this.chbTimeLine.TabIndex = 3;
            this.chbTimeLine.Text = "Show Timeline";
            this.chbTimeLine.UseVisualStyleBackColor = true;
            this.chbTimeLine.CheckedChanged += new System.EventHandler(this.chbTimeLine_CheckedChanged);
            // 
            // chbShowShadows
            // 
            this.chbShowShadows.AutoSize = true;
            this.chbShowShadows.Checked = true;
            this.chbShowShadows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowShadows.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowShadows.Location = new System.Drawing.Point(12, 25);
            this.chbShowShadows.Name = "chbShowShadows";
            this.chbShowShadows.Size = new System.Drawing.Size(98, 17);
            this.chbShowShadows.TabIndex = 2;
            this.chbShowShadows.Text = "Show Shadows";
            this.chbShowShadows.UseVisualStyleBackColor = true;
            this.chbShowShadows.CheckedChanged += new System.EventHandler(this.chbShowShadows_CheckedChanged);
            // 
            // QuickHeatCustoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlCustoms);
            this.Name = "QuickHeatCustoms";
            this.Size = new System.Drawing.Size(479, 145);
            this.pnlCustoms.ResumeLayout(false);
            this.grpCustomisation.ResumeLayout(false);
            this.grpCustomisation.PerformLayout();
            this.pnlExtraData.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpUnits.ResumeLayout(false);
            this.grpUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCellWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCustoms;
        private System.Windows.Forms.GroupBox grpCustomisation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbColourByVessel;
        private System.Windows.Forms.TrackBar trackBarCellWidth;
        private System.Windows.Forms.RadioButton rbColourByCaster;
        private System.Windows.Forms.CheckBox chbTimeLine;
        private System.Windows.Forms.CheckBox chbShowShadows;
        private System.Windows.Forms.GroupBox grpUnits;
        private System.Windows.Forms.CheckBox chbCasters;
        private System.Windows.Forms.CheckBox chbSecSteel;
        private System.Windows.Forms.CheckBox chbVessels;
        private System.Windows.Forms.CheckBox chbHMDes;
        private System.Windows.Forms.CheckBox chbHMPour;
        private System.Windows.Forms.Panel pnlExtraData;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.RadioButton rbShowProgNo;
        private System.Windows.Forms.RadioButton rbShowNone;
        private System.Windows.Forms.RadioButton rbShowGrade;
        private System.Windows.Forms.CheckBox chbMiscasts;
        private System.Windows.Forms.RadioButton rbShowLadleNo;
    }
}
