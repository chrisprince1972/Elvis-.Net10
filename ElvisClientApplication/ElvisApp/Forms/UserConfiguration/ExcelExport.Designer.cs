namespace Elvis.Forms.UserConfiguration
{
    partial class ExcelExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelExport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbxExportOption = new System.Windows.Forms.GroupBox();
            this.rdoXlsx = new System.Windows.Forms.RadioButton();
            this.rdoXls = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.gbxExportOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.gbxExportOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 159);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(98, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(13, 118);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gbxExportOption
            // 
            this.gbxExportOption.Controls.Add(this.rdoXlsx);
            this.gbxExportOption.Controls.Add(this.rdoXls);
            this.gbxExportOption.Location = new System.Drawing.Point(12, 25);
            this.gbxExportOption.Name = "gbxExportOption";
            this.gbxExportOption.Size = new System.Drawing.Size(217, 86);
            this.gbxExportOption.TabIndex = 0;
            this.gbxExportOption.TabStop = false;
            this.gbxExportOption.Text = "Export Version";
            // 
            // rdoXlsx
            // 
            this.rdoXlsx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdoXlsx.AutoSize = true;
            this.rdoXlsx.Location = new System.Drawing.Point(29, 46);
            this.rdoXlsx.Name = "rdoXlsx";
            this.rdoXlsx.Size = new System.Drawing.Size(158, 17);
            this.rdoXlsx.TabIndex = 1;
            this.rdoXlsx.Text = "Excel 2007 and above (xlsx)";
            this.rdoXlsx.UseVisualStyleBackColor = true;
            // 
            // rdoXls
            // 
            this.rdoXls.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdoXls.AutoSize = true;
            this.rdoXls.Checked = true;
            this.rdoXls.Location = new System.Drawing.Point(29, 22);
            this.rdoXls.Name = "rdoXls";
            this.rdoXls.Size = new System.Drawing.Size(132, 17);
            this.rdoXls.TabIndex = 0;
            this.rdoXls.TabStop = true;
            this.rdoXls.Text = "Excel 2000 - 2003 (xls)";
            this.rdoXls.UseVisualStyleBackColor = true;
            // 
            // ExcelExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 159);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Options";
            this.panel1.ResumeLayout(false);
            this.gbxExportOption.ResumeLayout(false);
            this.gbxExportOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox gbxExportOption;
        private System.Windows.Forms.RadioButton rdoXlsx;
        private System.Windows.Forms.RadioButton rdoXls;
    }
}