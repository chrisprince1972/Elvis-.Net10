namespace Elvis.UserControls.Tib
{
    partial class QuickTibDetails
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
            this.lblStart = new System.Windows.Forms.Label();
            this.lblHeatNo = new System.Windows.Forms.Label();
            this.pnlTibDetails = new System.Windows.Forms.Panel();
            this.grpSelectedTib = new System.Windows.Forms.GroupBox();
            this.lstReasons = new System.Windows.Forms.ListBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlTibDetails.SuspendLayout();
            this.grpSelectedTib.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(9, 63);
            this.lblStart.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(35, 13);
            this.lblStart.TabIndex = 11;
            this.lblStart.Text = "Start:";
            // 
            // lblHeatNo
            // 
            this.lblHeatNo.AutoSize = true;
            this.lblHeatNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatNo.Location = new System.Drawing.Point(9, 105);
            this.lblHeatNo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblHeatNo.Name = "lblHeatNo";
            this.lblHeatNo.Size = new System.Drawing.Size(74, 13);
            this.lblHeatNo.TabIndex = 10;
            this.lblHeatNo.Text = "Heat Number:";
            // 
            // pnlTibDetails
            // 
            this.pnlTibDetails.Controls.Add(this.grpSelectedTib);
            this.pnlTibDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTibDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlTibDetails.Name = "pnlTibDetails";
            this.pnlTibDetails.Padding = new System.Windows.Forms.Padding(6, 3, 3, 6);
            this.pnlTibDetails.Size = new System.Drawing.Size(330, 145);
            this.pnlTibDetails.TabIndex = 2;
            // 
            // grpSelectedTib
            // 
            this.grpSelectedTib.Controls.Add(this.lstReasons);
            this.grpSelectedTib.Controls.Add(this.lblStart);
            this.grpSelectedTib.Controls.Add(this.lblHeatNo);
            this.grpSelectedTib.Controls.Add(this.lblEnd);
            this.grpSelectedTib.Controls.Add(this.lblDuration);
            this.grpSelectedTib.Controls.Add(this.lblType);
            this.grpSelectedTib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedTib.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSelectedTib.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpSelectedTib.Location = new System.Drawing.Point(6, 3);
            this.grpSelectedTib.Name = "grpSelectedTib";
            this.grpSelectedTib.Padding = new System.Windows.Forms.Padding(6, 8, 6, 6);
            this.grpSelectedTib.Size = new System.Drawing.Size(321, 136);
            this.grpSelectedTib.TabIndex = 1;
            this.grpSelectedTib.TabStop = false;
            this.grpSelectedTib.Text = "Selected Tib Details";
            // 
            // lstReasons
            // 
            this.lstReasons.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstReasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstReasons.FormattingEnabled = true;
            this.lstReasons.Location = new System.Drawing.Point(153, 22);
            this.lstReasons.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lstReasons.Name = "lstReasons";
            this.lstReasons.Size = new System.Drawing.Size(162, 108);
            this.lstReasons.TabIndex = 13;
            this.lstReasons.Visible = false;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(9, 84);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(29, 13);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "End:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(9, 42);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(55, 13);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "Duration: ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(9, 21);
            this.lblType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(38, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type: ";
            // 
            // QuickTibDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlTibDetails);
            this.Name = "QuickTibDetails";
            this.Size = new System.Drawing.Size(330, 145);
            this.pnlTibDetails.ResumeLayout(false);
            this.grpSelectedTib.ResumeLayout(false);
            this.grpSelectedTib.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblHeatNo;
        private System.Windows.Forms.Panel pnlTibDetails;
        private System.Windows.Forms.GroupBox grpSelectedTib;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ListBox lstReasons;
    }
}
