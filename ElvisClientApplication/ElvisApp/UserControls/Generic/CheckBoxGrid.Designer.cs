namespace Elvis.UserControls.Generic
{
    partial class CheckBoxGrid
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
            this.pnlLegendMain = new System.Windows.Forms.Panel();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLegendMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLegendMain
            // 
            this.pnlLegendMain.AutoScroll = true;
            this.pnlLegendMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlLegendMain.Controls.Add(this.tlpContainer);
            this.pnlLegendMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLegendMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlLegendMain.Location = new System.Drawing.Point(0, 0);
            this.pnlLegendMain.Name = "pnlLegendMain";
            this.pnlLegendMain.Size = new System.Drawing.Size(140, 88);
            this.pnlLegendMain.TabIndex = 13;
            // 
            // tlpContainer
            // 
            this.tlpContainer.AutoSize = true;
            this.tlpContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tlpContainer.ColumnCount = 3;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 2;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.Size = new System.Drawing.Size(140, 0);
            this.tlpContainer.TabIndex = 5;
            // 
            // CheckBoxGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlLegendMain);
            this.Name = "CheckBoxGrid";
            this.Size = new System.Drawing.Size(140, 88);
            this.pnlLegendMain.ResumeLayout(false);
            this.pnlLegendMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLegendMain;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;

    }
}
