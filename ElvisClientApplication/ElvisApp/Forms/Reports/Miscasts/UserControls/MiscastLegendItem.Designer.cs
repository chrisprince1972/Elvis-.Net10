namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    partial class MiscastLegendItem
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
            this.pnlColour = new System.Windows.Forms.Panel();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblForeColour = new System.Windows.Forms.Label();
            this.pnlColour.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColour
            // 
            this.pnlColour.BackColor = System.Drawing.Color.Red;
            this.pnlColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColour.Controls.Add(this.lblForeColour);
            this.pnlColour.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlColour.Location = new System.Drawing.Point(8, 4);
            this.pnlColour.Name = "pnlColour";
            this.pnlColour.Size = new System.Drawing.Size(22, 15);
            this.pnlColour.TabIndex = 0;
            // 
            // chbEnabled
            // 
            this.chbEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbEnabled.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbEnabled.Location = new System.Drawing.Point(146, 4);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.chbEnabled.Size = new System.Drawing.Size(20, 15);
            this.chbEnabled.TabIndex = 2;
            this.chbEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbEnabled.UseVisualStyleBackColor = true;
            this.chbEnabled.CheckedChanged += new System.EventHandler(this.chbShow_CheckedChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoEllipsis = true;
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(30, 4);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Padding = new System.Windows.Forms.Padding(6, 0, 0, 1);
            this.lblItemName.Size = new System.Drawing.Size(116, 15);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Legend Item Text";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForeColour
            // 
            this.lblForeColour.BackColor = System.Drawing.Color.Transparent;
            this.lblForeColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblForeColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForeColour.Location = new System.Drawing.Point(0, 0);
            this.lblForeColour.Name = "lblForeColour";
            this.lblForeColour.Size = new System.Drawing.Size(20, 13);
            this.lblForeColour.TabIndex = 0;
            this.lblForeColour.Text = "-";
            this.lblForeColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiscastLegendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.chbEnabled);
            this.Controls.Add(this.pnlColour);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MiscastLegendItem";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.Size = new System.Drawing.Size(170, 23);
            this.pnlColour.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColour;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblForeColour;
    }
}
