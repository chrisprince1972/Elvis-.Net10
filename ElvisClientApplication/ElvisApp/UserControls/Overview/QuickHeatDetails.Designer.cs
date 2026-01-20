namespace Elvis.UserControls.HeatDetails
{
    partial class QuickHeatDetails
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
            this.pnlHeatDetails = new System.Windows.Forms.Panel();
            this.grpSelectedHeat = new System.Windows.Forms.GroupBox();
            this.lblLadleNo = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblVesselNumber = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblCasterNumber = new System.Windows.Forms.Label();
            this.lblProgramNumber = new System.Windows.Forms.Label();
            this.lblHeatNumber = new System.Windows.Forms.Label();
            this.pnlHeatDetails.SuspendLayout();
            this.grpSelectedHeat.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeatDetails
            // 
            this.pnlHeatDetails.Controls.Add(this.grpSelectedHeat);
            this.pnlHeatDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeatDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlHeatDetails.Name = "pnlHeatDetails";
            this.pnlHeatDetails.Padding = new System.Windows.Forms.Padding(6, 3, 3, 6);
            this.pnlHeatDetails.Size = new System.Drawing.Size(330, 138);
            this.pnlHeatDetails.TabIndex = 1;
            // 
            // grpSelectedHeat
            // 
            this.grpSelectedHeat.Controls.Add(this.lblLadleNo);
            this.grpSelectedHeat.Controls.Add(this.lblGrade);
            this.grpSelectedHeat.Controls.Add(this.lblVesselNumber);
            this.grpSelectedHeat.Controls.Add(this.lblEndTime);
            this.grpSelectedHeat.Controls.Add(this.lblStartTime);
            this.grpSelectedHeat.Controls.Add(this.lblDuration);
            this.grpSelectedHeat.Controls.Add(this.lblCasterNumber);
            this.grpSelectedHeat.Controls.Add(this.lblProgramNumber);
            this.grpSelectedHeat.Controls.Add(this.lblHeatNumber);
            this.grpSelectedHeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedHeat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSelectedHeat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpSelectedHeat.Location = new System.Drawing.Point(6, 3);
            this.grpSelectedHeat.Name = "grpSelectedHeat";
            this.grpSelectedHeat.Padding = new System.Windows.Forms.Padding(6, 8, 6, 6);
            this.grpSelectedHeat.Size = new System.Drawing.Size(321, 129);
            this.grpSelectedHeat.TabIndex = 1;
            this.grpSelectedHeat.TabStop = false;
            this.grpSelectedHeat.Text = "Selected Heat Details";
            // 
            // lblLadleNo
            // 
            this.lblLadleNo.AutoSize = true;
            this.lblLadleNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLadleNo.Location = new System.Drawing.Point(9, 105);
            this.lblLadleNo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblLadleNo.Name = "lblLadleNo";
            this.lblLadleNo.Size = new System.Drawing.Size(76, 13);
            this.lblLadleNo.TabIndex = 12;
            this.lblLadleNo.Text = "Ladle Number:";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(9, 63);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(40, 13);
            this.lblGrade.TabIndex = 11;
            this.lblGrade.Text = "Grade:";
            // 
            // lblVesselNumber
            // 
            this.lblVesselNumber.AutoSize = true;
            this.lblVesselNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVesselNumber.Location = new System.Drawing.Point(164, 84);
            this.lblVesselNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblVesselNumber.Name = "lblVesselNumber";
            this.lblVesselNumber.Size = new System.Drawing.Size(41, 13);
            this.lblVesselNumber.TabIndex = 10;
            this.lblVesselNumber.Text = "Vessel:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(164, 42);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(68, 13);
            this.lblEndTime.TabIndex = 9;
            this.lblEndTime.Text = "Activity End:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(164, 21);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(74, 13);
            this.lblStartTime.TabIndex = 8;
            this.lblStartTime.Text = "Activity Start:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(164, 63);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(91, 13);
            this.lblDuration.TabIndex = 6;
            this.lblDuration.Text = "Activity Duration:";
            // 
            // lblCasterNumber
            // 
            this.lblCasterNumber.AutoSize = true;
            this.lblCasterNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasterNumber.Location = new System.Drawing.Point(9, 84);
            this.lblCasterNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblCasterNumber.Name = "lblCasterNumber";
            this.lblCasterNumber.Size = new System.Drawing.Size(43, 13);
            this.lblCasterNumber.TabIndex = 3;
            this.lblCasterNumber.Text = "Caster:";
            // 
            // lblProgramNumber
            // 
            this.lblProgramNumber.AutoSize = true;
            this.lblProgramNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramNumber.Location = new System.Drawing.Point(9, 42);
            this.lblProgramNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblProgramNumber.Name = "lblProgramNumber";
            this.lblProgramNumber.Size = new System.Drawing.Size(94, 13);
            this.lblProgramNumber.TabIndex = 1;
            this.lblProgramNumber.Text = "Program Number: ";
            // 
            // lblHeatNumber
            // 
            this.lblHeatNumber.AutoSize = true;
            this.lblHeatNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatNumber.Location = new System.Drawing.Point(9, 21);
            this.lblHeatNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblHeatNumber.Name = "lblHeatNumber";
            this.lblHeatNumber.Size = new System.Drawing.Size(77, 13);
            this.lblHeatNumber.TabIndex = 0;
            this.lblHeatNumber.Text = "Heat Number: ";
            // 
            // QuickHeatDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlHeatDetails);
            this.Name = "QuickHeatDetails";
            this.Size = new System.Drawing.Size(330, 138);
            this.pnlHeatDetails.ResumeLayout(false);
            this.grpSelectedHeat.ResumeLayout(false);
            this.grpSelectedHeat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeatDetails;
        private System.Windows.Forms.GroupBox grpSelectedHeat;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblVesselNumber;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblCasterNumber;
        private System.Windows.Forms.Label lblProgramNumber;
        private System.Windows.Forms.Label lblHeatNumber;
        private System.Windows.Forms.Label lblLadleNo;
    }
}
