namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    partial class KeyDetails
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtHMSTreated = new System.Windows.Forms.TextBox();
            this.txtAimSteelS = new System.Windows.Forms.TextBox();
            this.txtHMSDirect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtHMSTreated);
            this.pnlMain.Controls.Add(this.txtAimSteelS);
            this.pnlMain.Controls.Add(this.txtHMSDirect);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.pnlMain.Size = new System.Drawing.Size(284, 75);
            this.pnlMain.TabIndex = 1;
            // 
            // txtHMSTreated
            // 
            this.txtHMSTreated.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHMSTreated.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHMSTreated.Location = new System.Drawing.Point(150, 51);
            this.txtHMSTreated.Name = "txtHMSTreated";
            this.txtHMSTreated.ReadOnly = true;
            this.txtHMSTreated.Size = new System.Drawing.Size(50, 15);
            this.txtHMSTreated.TabIndex = 12;
            this.txtHMSTreated.Tag = "";
            this.txtHMSTreated.Text = "#";
            this.txtHMSTreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAimSteelS
            // 
            this.txtAimSteelS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAimSteelS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAimSteelS.Location = new System.Drawing.Point(150, 9);
            this.txtAimSteelS.Name = "txtAimSteelS";
            this.txtAimSteelS.ReadOnly = true;
            this.txtAimSteelS.Size = new System.Drawing.Size(50, 15);
            this.txtAimSteelS.TabIndex = 11;
            this.txtAimSteelS.Tag = "";
            this.txtAimSteelS.Text = "#";
            this.txtAimSteelS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHMSDirect
            // 
            this.txtHMSDirect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHMSDirect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHMSDirect.Location = new System.Drawing.Point(150, 30);
            this.txtHMSDirect.Name = "txtHMSDirect";
            this.txtHMSDirect.ReadOnly = true;
            this.txtHMSDirect.Size = new System.Drawing.Size(50, 15);
            this.txtHMSDirect.TabIndex = 10;
            this.txtHMSDirect.Tag = "";
            this.txtHMSDirect.Text = "#";
            this.txtHMSDirect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Aim HM S Treated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max HM S Direct Charge";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aim Steel S";
            // 
            // KeyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "KeyDetails";
            this.Size = new System.Drawing.Size(284, 75);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHMSTreated;
        private System.Windows.Forms.TextBox txtAimSteelS;
        private System.Windows.Forms.TextBox txtHMSDirect;

    }
}
