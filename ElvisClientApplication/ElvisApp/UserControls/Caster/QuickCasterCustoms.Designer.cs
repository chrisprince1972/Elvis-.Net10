namespace Elvis.UserControls.Caster
{
    partial class QuickCasterCustoms
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
            this.chbShow10amPlan = new System.Windows.Forms.CheckBox();
            this.chbHMStock7am = new System.Windows.Forms.CheckBox();
            this.chbShow7pmPlan = new System.Windows.Forms.CheckBox();
            this.chbShowChart = new System.Windows.Forms.CheckBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.rbShowProgNo = new System.Windows.Forms.RadioButton();
            this.rbShowNone = new System.Windows.Forms.RadioButton();
            this.rbShowGrade = new System.Windows.Forms.RadioButton();
            this.chbTimeLine = new System.Windows.Forms.CheckBox();
            this.chbShowShadows = new System.Windows.Forms.CheckBox();
            this.pnlCustoms.SuspendLayout();
            this.grpCustomisation.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCustoms
            // 
            this.pnlCustoms.Controls.Add(this.grpCustomisation);
            this.pnlCustoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustoms.Location = new System.Drawing.Point(0, 0);
            this.pnlCustoms.Name = "pnlCustoms";
            this.pnlCustoms.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.pnlCustoms.Size = new System.Drawing.Size(402, 122);
            this.pnlCustoms.TabIndex = 1;
            // 
            // grpCustomisation
            // 
            this.grpCustomisation.Controls.Add(this.chbShow10amPlan);
            this.grpCustomisation.Controls.Add(this.chbHMStock7am);
            this.grpCustomisation.Controls.Add(this.chbShow7pmPlan);
            this.grpCustomisation.Controls.Add(this.chbShowChart);
            this.grpCustomisation.Controls.Add(this.grpData);
            this.grpCustomisation.Controls.Add(this.chbTimeLine);
            this.grpCustomisation.Controls.Add(this.chbShowShadows);
            this.grpCustomisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCustomisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomisation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpCustomisation.Location = new System.Drawing.Point(6, 3);
            this.grpCustomisation.Name = "grpCustomisation";
            this.grpCustomisation.Padding = new System.Windows.Forms.Padding(6);
            this.grpCustomisation.Size = new System.Drawing.Size(390, 113);
            this.grpCustomisation.TabIndex = 3;
            this.grpCustomisation.TabStop = false;
            this.grpCustomisation.Text = "Caster Review Customisations";
            // 
            // chbShow10amPlan
            // 
            this.chbShow10amPlan.AutoSize = true;
            this.chbShow10amPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShow10amPlan.Location = new System.Drawing.Point(118, 42);
            this.chbShow10amPlan.Name = "chbShow10amPlan";
            this.chbShow10amPlan.Size = new System.Drawing.Size(106, 17);
            this.chbShow10amPlan.TabIndex = 19;
            this.chbShow10amPlan.Text = "Show 10am Plan";
            this.chbShow10amPlan.UseVisualStyleBackColor = true;
            this.chbShow10amPlan.CheckedChanged += new System.EventHandler(this.chbShow10amPlan_CheckedChanged);
            // 
            // chbHMStock7am
            // 
            this.chbHMStock7am.AutoSize = true;
            this.chbHMStock7am.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHMStock7am.Location = new System.Drawing.Point(118, 59);
            this.chbHMStock7am.Name = "chbHMStock7am";
            this.chbHMStock7am.Size = new System.Drawing.Size(127, 17);
            this.chbHMStock7am.TabIndex = 18;
            this.chbHMStock7am.Text = "Show 7am HM Stock";
            this.chbHMStock7am.UseVisualStyleBackColor = true;
            this.chbHMStock7am.CheckedChanged += new System.EventHandler(this.chbHMStock7am_CheckedChanged);
            // 
            // chbShow7pmPlan
            // 
            this.chbShow7pmPlan.AutoSize = true;
            this.chbShow7pmPlan.Checked = true;
            this.chbShow7pmPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShow7pmPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShow7pmPlan.Location = new System.Drawing.Point(118, 25);
            this.chbShow7pmPlan.Name = "chbShow7pmPlan";
            this.chbShow7pmPlan.Size = new System.Drawing.Size(100, 17);
            this.chbShow7pmPlan.TabIndex = 17;
            this.chbShow7pmPlan.Text = "Show 7pm Plan";
            this.chbShow7pmPlan.UseVisualStyleBackColor = true;
            this.chbShow7pmPlan.CheckedChanged += new System.EventHandler(this.chbShow7pmPlan_CheckedChanged);
            // 
            // chbShowChart
            // 
            this.chbShowChart.AutoSize = true;
            this.chbShowChart.Checked = true;
            this.chbShowChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowChart.Location = new System.Drawing.Point(12, 59);
            this.chbShowChart.Name = "chbShowChart";
            this.chbShowChart.Size = new System.Drawing.Size(81, 17);
            this.chbShowChart.TabIndex = 16;
            this.chbShowChart.Text = "Show Chart";
            this.chbShowChart.UseVisualStyleBackColor = true;
            this.chbShowChart.CheckedChanged += new System.EventHandler(this.chbShowChart_CheckedChanged);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.rbShowProgNo);
            this.grpData.Controls.Add(this.rbShowNone);
            this.grpData.Controls.Add(this.rbShowGrade);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpData.Location = new System.Drawing.Point(255, 19);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(8, 4, 3, 3);
            this.grpData.Size = new System.Drawing.Size(129, 88);
            this.grpData.TabIndex = 14;
            this.grpData.TabStop = false;
            this.grpData.Text = "Extra Data";
            // 
            // rbShowProgNo
            // 
            this.rbShowProgNo.AutoSize = true;
            this.rbShowProgNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.rbShowNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbShowNone.Location = new System.Drawing.Point(11, 20);
            this.rbShowNone.Name = "rbShowNone";
            this.rbShowNone.Size = new System.Drawing.Size(98, 17);
            this.rbShowNone.TabIndex = 13;
            this.rbShowNone.TabStop = true;
            this.rbShowNone.Tag = "None";
            this.rbShowNone.Text = "Show Heat No.";
            this.rbShowNone.UseVisualStyleBackColor = true;
            this.rbShowNone.CheckedChanged += new System.EventHandler(this.rbExtraData_CheckedChanged);
            // 
            // rbShowGrade
            // 
            this.rbShowGrade.AutoSize = true;
            this.rbShowGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbShowGrade.Location = new System.Drawing.Point(11, 58);
            this.rbShowGrade.Name = "rbShowGrade";
            this.rbShowGrade.Size = new System.Drawing.Size(84, 17);
            this.rbShowGrade.TabIndex = 12;
            this.rbShowGrade.Tag = "Grade";
            this.rbShowGrade.Text = "Show Grade";
            this.rbShowGrade.UseVisualStyleBackColor = true;
            this.rbShowGrade.CheckedChanged += new System.EventHandler(this.rbExtraData_CheckedChanged);
            // 
            // chbTimeLine
            // 
            this.chbTimeLine.AutoSize = true;
            this.chbTimeLine.Checked = true;
            this.chbTimeLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTimeLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTimeLine.Location = new System.Drawing.Point(12, 42);
            this.chbTimeLine.Name = "chbTimeLine";
            this.chbTimeLine.Size = new System.Drawing.Size(95, 17);
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
            this.chbShowShadows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowShadows.Location = new System.Drawing.Point(12, 25);
            this.chbShowShadows.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.chbShowShadows.Name = "chbShowShadows";
            this.chbShowShadows.Size = new System.Drawing.Size(100, 17);
            this.chbShowShadows.TabIndex = 2;
            this.chbShowShadows.Text = "Show Shadows";
            this.chbShowShadows.UseVisualStyleBackColor = true;
            this.chbShowShadows.CheckedChanged += new System.EventHandler(this.chbShowShadows_CheckedChanged);
            // 
            // QuickCasterCustoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlCustoms);
            this.Name = "QuickCasterCustoms";
            this.Size = new System.Drawing.Size(402, 122);
            this.pnlCustoms.ResumeLayout(false);
            this.grpCustomisation.ResumeLayout(false);
            this.grpCustomisation.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCustoms;
        private System.Windows.Forms.GroupBox grpCustomisation;
        private System.Windows.Forms.CheckBox chbShow7pmPlan;
        private System.Windows.Forms.CheckBox chbShowChart;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.RadioButton rbShowProgNo;
        private System.Windows.Forms.RadioButton rbShowNone;
        private System.Windows.Forms.RadioButton rbShowGrade;
        private System.Windows.Forms.CheckBox chbTimeLine;
        private System.Windows.Forms.CheckBox chbShowShadows;
        private System.Windows.Forms.CheckBox chbHMStock7am;
        private System.Windows.Forms.CheckBox chbShow10amPlan;
    }
}
