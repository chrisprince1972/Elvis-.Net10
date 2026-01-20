namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    partial class RCAWhy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RCAWhy));
            this.pnlWhy = new System.Windows.Forms.Panel();
            this.txtWhy = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblWhy = new System.Windows.Forms.Label();
            this.pnlWhy.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWhy
            // 
            this.pnlWhy.Controls.Add(this.txtWhy);
            this.pnlWhy.Controls.Add(this.btnDelete);
            this.pnlWhy.Controls.Add(this.lblWhy);
            this.pnlWhy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWhy.Location = new System.Drawing.Point(0, 0);
            this.pnlWhy.Name = "pnlWhy";
            this.pnlWhy.Padding = new System.Windows.Forms.Padding(2);
            this.pnlWhy.Size = new System.Drawing.Size(698, 26);
            this.pnlWhy.TabIndex = 68;
            // 
            // txtWhy
            // 
            this.txtWhy.BackColor = System.Drawing.SystemColors.Window;
            this.txtWhy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWhy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhy.Location = new System.Drawing.Point(124, 2);
            this.txtWhy.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.txtWhy.MaxLength = 100;
            this.txtWhy.Name = "txtWhy";
            this.txtWhy.ReadOnly = true;
            this.txtWhy.Size = new System.Drawing.Size(548, 22);
            this.txtWhy.TabIndex = 0;
            this.txtWhy.TextChanged += new System.EventHandler(this.txtWhy_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(672, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 22);
            this.btnDelete.TabIndex = 60;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblWhy
            // 
            this.lblWhy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWhy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhy.Location = new System.Drawing.Point(2, 2);
            this.lblWhy.Name = "lblWhy";
            this.lblWhy.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblWhy.Size = new System.Drawing.Size(122, 22);
            this.lblWhy.TabIndex = 56;
            this.lblWhy.Text = "Why";
            this.lblWhy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RCAWhy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlWhy);
            this.Name = "RCAWhy";
            this.Size = new System.Drawing.Size(698, 26);
            this.Load += new System.EventHandler(this.RCAWhy_Load);
            this.pnlWhy.ResumeLayout(false);
            this.pnlWhy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWhy;
        private System.Windows.Forms.TextBox txtWhy;
        private System.Windows.Forms.Label lblWhy;
        private System.Windows.Forms.Button btnDelete;
    }
}
