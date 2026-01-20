namespace Elvis.Forms.Reports.ManagementAgendaThreats
{
    partial class DMAThreatIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMAThreatIndex));
            this.tableRowHeadersThreats = new Elvis.UserControls.Generic.TableRowHeaders();
            this.SuspendLayout();
            // 
            // tableRowHeadersThreats
            // 
            this.tableRowHeadersThreats.ColumnCount = 2;
            this.tableRowHeadersThreats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRowHeadersThreats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRowHeadersThreats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRowHeadersThreats.Location = new System.Drawing.Point(0, 0);
            this.tableRowHeadersThreats.Margin = new System.Windows.Forms.Padding(0);
            this.tableRowHeadersThreats.Name = "tableRowHeadersThreats";
            this.tableRowHeadersThreats.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tableRowHeadersThreats.RowCount = 2;
            this.tableRowHeadersThreats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRowHeadersThreats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRowHeadersThreats.Size = new System.Drawing.Size(984, 670);
            this.tableRowHeadersThreats.TabIndex = 2;
            // 
            // DMAThreatIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 670);
            this.Controls.Add(this.tableRowHeadersThreats);
            this.Name = "DMAThreatIndex";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "Daily Management Agenda – Threats";
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Generic.TableRowHeaders tableRowHeadersThreats;

    }
}