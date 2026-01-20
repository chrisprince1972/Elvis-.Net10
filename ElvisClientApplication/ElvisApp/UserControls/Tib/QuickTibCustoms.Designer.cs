namespace Elvis.UserControls.Tib
{
    partial class QuickTibCustoms
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
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.pnlUnitsRight = new System.Windows.Forms.Panel();
            this.chbLimePlant = new System.Windows.Forms.CheckBox();
            this.chbCasters = new System.Windows.Forms.CheckBox();
            this.chbSecSteel = new System.Windows.Forms.CheckBox();
            this.pnlUnitsLeft = new System.Windows.Forms.Panel();
            this.chbVessels = new System.Windows.Forms.CheckBox();
            this.chbHMDes = new System.Windows.Forms.CheckBox();
            this.chbScrap = new System.Windows.Forms.CheckBox();
            this.chbHMPour = new System.Windows.Forms.CheckBox();
            this.chbShowLegend = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarCellWidth = new System.Windows.Forms.TrackBar();
            this.chbTimeLine = new System.Windows.Forms.CheckBox();
            this.chbShowShadows = new System.Windows.Forms.CheckBox();
            this.pnlCustoms.SuspendLayout();
            this.grpCustomisation.SuspendLayout();
            this.grpUnits.SuspendLayout();
            this.pnlUnitsRight.SuspendLayout();
            this.pnlUnitsLeft.SuspendLayout();
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
            this.pnlCustoms.Size = new System.Drawing.Size(365, 137);
            this.pnlCustoms.TabIndex = 2;
            // 
            // grpCustomisation
            // 
            this.grpCustomisation.Controls.Add(this.grpUnits);
            this.grpCustomisation.Controls.Add(this.chbShowLegend);
            this.grpCustomisation.Controls.Add(this.label1);
            this.grpCustomisation.Controls.Add(this.trackBarCellWidth);
            this.grpCustomisation.Controls.Add(this.chbTimeLine);
            this.grpCustomisation.Controls.Add(this.chbShowShadows);
            this.grpCustomisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCustomisation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomisation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCustomisation.Location = new System.Drawing.Point(3, 3);
            this.grpCustomisation.Name = "grpCustomisation";
            this.grpCustomisation.Padding = new System.Windows.Forms.Padding(6);
            this.grpCustomisation.Size = new System.Drawing.Size(356, 128);
            this.grpCustomisation.TabIndex = 3;
            this.grpCustomisation.TabStop = false;
            this.grpCustomisation.Text = "Tib Customisations";
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.pnlUnitsRight);
            this.grpUnits.Controls.Add(this.pnlUnitsLeft);
            this.grpUnits.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpUnits.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUnits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpUnits.Location = new System.Drawing.Point(166, 20);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Padding = new System.Windows.Forms.Padding(12, 8, 8, 8);
            this.grpUnits.Size = new System.Drawing.Size(184, 102);
            this.grpUnits.TabIndex = 16;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            // 
            // pnlUnitsRight
            // 
            this.pnlUnitsRight.Controls.Add(this.chbLimePlant);
            this.pnlUnitsRight.Controls.Add(this.chbCasters);
            this.pnlUnitsRight.Controls.Add(this.chbSecSteel);
            this.pnlUnitsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitsRight.Location = new System.Drawing.Point(101, 22);
            this.pnlUnitsRight.Name = "pnlUnitsRight";
            this.pnlUnitsRight.Size = new System.Drawing.Size(75, 72);
            this.pnlUnitsRight.TabIndex = 18;
            // 
            // chbLimePlant
            // 
            this.chbLimePlant.AutoSize = true;
            this.chbLimePlant.Checked = true;
            this.chbLimePlant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLimePlant.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbLimePlant.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLimePlant.Location = new System.Drawing.Point(0, 34);
            this.chbLimePlant.Name = "chbLimePlant";
            this.chbLimePlant.Size = new System.Drawing.Size(75, 17);
            this.chbLimePlant.TabIndex = 24;
            this.chbLimePlant.Tag = "14";
            this.chbLimePlant.Text = "Lime Plant";
            this.chbLimePlant.UseVisualStyleBackColor = true;
            this.chbLimePlant.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // chbCasters
            // 
            this.chbCasters.AutoSize = true;
            this.chbCasters.Checked = true;
            this.chbCasters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCasters.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbCasters.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCasters.Location = new System.Drawing.Point(0, 17);
            this.chbCasters.Name = "chbCasters";
            this.chbCasters.Size = new System.Drawing.Size(75, 17);
            this.chbCasters.TabIndex = 28;
            this.chbCasters.Tag = "11|12|13";
            this.chbCasters.Text = "Casters";
            this.chbCasters.UseVisualStyleBackColor = true;
            this.chbCasters.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // chbSecSteel
            // 
            this.chbSecSteel.AutoSize = true;
            this.chbSecSteel.Checked = true;
            this.chbSecSteel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSecSteel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbSecSteel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSecSteel.Location = new System.Drawing.Point(0, 0);
            this.chbSecSteel.Name = "chbSecSteel";
            this.chbSecSteel.Size = new System.Drawing.Size(75, 17);
            this.chbSecSteel.TabIndex = 29;
            this.chbSecSteel.Tag = "7|8|9|10";
            this.chbSecSteel.Text = "Sec Steel";
            this.chbSecSteel.UseVisualStyleBackColor = true;
            this.chbSecSteel.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // pnlUnitsLeft
            // 
            this.pnlUnitsLeft.Controls.Add(this.chbVessels);
            this.pnlUnitsLeft.Controls.Add(this.chbHMDes);
            this.pnlUnitsLeft.Controls.Add(this.chbScrap);
            this.pnlUnitsLeft.Controls.Add(this.chbHMPour);
            this.pnlUnitsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnitsLeft.Location = new System.Drawing.Point(12, 22);
            this.pnlUnitsLeft.Name = "pnlUnitsLeft";
            this.pnlUnitsLeft.Size = new System.Drawing.Size(89, 72);
            this.pnlUnitsLeft.TabIndex = 17;
            // 
            // chbVessels
            // 
            this.chbVessels.AutoSize = true;
            this.chbVessels.Checked = true;
            this.chbVessels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVessels.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbVessels.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbVessels.Location = new System.Drawing.Point(0, 51);
            this.chbVessels.Name = "chbVessels";
            this.chbVessels.Size = new System.Drawing.Size(89, 17);
            this.chbVessels.TabIndex = 25;
            this.chbVessels.Tag = "5|6";
            this.chbVessels.Text = "Vessels";
            this.chbVessels.UseVisualStyleBackColor = true;
            this.chbVessels.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // chbHMDes
            // 
            this.chbHMDes.AutoSize = true;
            this.chbHMDes.Checked = true;
            this.chbHMDes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMDes.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbHMDes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMDes.Location = new System.Drawing.Point(0, 34);
            this.chbHMDes.Name = "chbHMDes";
            this.chbHMDes.Size = new System.Drawing.Size(89, 17);
            this.chbHMDes.TabIndex = 24;
            this.chbHMDes.Tag = "3|4";
            this.chbHMDes.Text = "HM Desulph";
            this.chbHMDes.UseVisualStyleBackColor = true;
            this.chbHMDes.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // chbScrap
            // 
            this.chbScrap.AutoSize = true;
            this.chbScrap.Checked = true;
            this.chbScrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbScrap.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbScrap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbScrap.Location = new System.Drawing.Point(0, 17);
            this.chbScrap.Name = "chbScrap";
            this.chbScrap.Size = new System.Drawing.Size(89, 17);
            this.chbScrap.TabIndex = 27;
            this.chbScrap.Tag = "16|17";
            this.chbScrap.Text = "Scrap";
            this.chbScrap.UseVisualStyleBackColor = true;
            this.chbScrap.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // chbHMPour
            // 
            this.chbHMPour.AutoSize = true;
            this.chbHMPour.Checked = true;
            this.chbHMPour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHMPour.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbHMPour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMPour.Location = new System.Drawing.Point(0, 0);
            this.chbHMPour.Name = "chbHMPour";
            this.chbHMPour.Size = new System.Drawing.Size(89, 17);
            this.chbHMPour.TabIndex = 23;
            this.chbHMPour.Tag = "1|2";
            this.chbHMPour.Text = "HM Pour";
            this.chbHMPour.UseVisualStyleBackColor = true;
            this.chbHMPour.CheckedChanged += new System.EventHandler(this.chbUnits_CheckedChanged);
            // 
            // chbShowLegend
            // 
            this.chbShowLegend.AutoSize = true;
            this.chbShowLegend.Checked = true;
            this.chbShowLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowLegend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowLegend.Location = new System.Drawing.Point(12, 59);
            this.chbShowLegend.Name = "chbShowLegend";
            this.chbShowLegend.Size = new System.Drawing.Size(90, 17);
            this.chbShowLegend.TabIndex = 15;
            this.chbShowLegend.Text = "Show Legend";
            this.chbShowLegend.UseVisualStyleBackColor = true;
            this.chbShowLegend.CheckedChanged += new System.EventHandler(this.chbShowLegend_CheckedChanged);
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
            // trackBarCellWidth
            // 
            this.trackBarCellWidth.LargeChange = 10;
            this.trackBarCellWidth.Location = new System.Drawing.Point(73, 79);
            this.trackBarCellWidth.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.trackBarCellWidth.Maximum = 240;
            this.trackBarCellWidth.Minimum = 65;
            this.trackBarCellWidth.Name = "trackBarCellWidth";
            this.trackBarCellWidth.Size = new System.Drawing.Size(84, 45);
            this.trackBarCellWidth.SmallChange = 5;
            this.trackBarCellWidth.TabIndex = 1;
            this.trackBarCellWidth.Value = 65;
            this.trackBarCellWidth.Scroll += new System.EventHandler(this.trackBarCellWidth_Scroll);
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
            // QuickTibCustoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlCustoms);
            this.Name = "QuickTibCustoms";
            this.Size = new System.Drawing.Size(365, 137);
            this.pnlCustoms.ResumeLayout(false);
            this.grpCustomisation.ResumeLayout(false);
            this.grpCustomisation.PerformLayout();
            this.grpUnits.ResumeLayout(false);
            this.pnlUnitsRight.ResumeLayout(false);
            this.pnlUnitsRight.PerformLayout();
            this.pnlUnitsLeft.ResumeLayout(false);
            this.pnlUnitsLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCellWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCustoms;
        private System.Windows.Forms.GroupBox grpCustomisation;
        private System.Windows.Forms.CheckBox chbShowLegend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarCellWidth;
        private System.Windows.Forms.CheckBox chbTimeLine;
        private System.Windows.Forms.CheckBox chbShowShadows;
        private System.Windows.Forms.GroupBox grpUnits;
        private System.Windows.Forms.Panel pnlUnitsLeft;
        private System.Windows.Forms.CheckBox chbVessels;
        private System.Windows.Forms.CheckBox chbHMDes;
        private System.Windows.Forms.CheckBox chbHMPour;
        private System.Windows.Forms.Panel pnlUnitsRight;
        private System.Windows.Forms.CheckBox chbLimePlant;
        private System.Windows.Forms.CheckBox chbCasters;
        private System.Windows.Forms.CheckBox chbSecSteel;
        private System.Windows.Forms.CheckBox chbScrap;
    }
}
