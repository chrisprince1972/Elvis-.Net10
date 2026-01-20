namespace Elvis.UserControls.HeatDetails
{
    partial class TibUserControl
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
            this.main = new System.Windows.Forms.Panel();
            this.tibDelayDetailGrid = new Elvis.UserControls.Tib.DelayDetailGrid();
            this.main.SuspendLayout();
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.Controls.Add(this.tibDelayDetailGrid);
            this.main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main.Location = new System.Drawing.Point(0, 0);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(731, 207);
            this.main.TabIndex = 1;
            // 
            // tibDelayDetailGrid
            // 
            this.tibDelayDetailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tibDelayDetailGrid.Location = new System.Drawing.Point(0, 0);
            this.tibDelayDetailGrid.Name = "tibDelayDetailGrid";
            this.tibDelayDetailGrid.Size = new System.Drawing.Size(731, 207);
            this.tibDelayDetailGrid.TabIndex = 1;
            // 
            // TibUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.main);
            this.Name = "TibUserControl";
            this.Size = new System.Drawing.Size(731, 207);
            this.Controls.SetChildIndex(this.main, 0);
            this.Controls.SetChildIndex(this.pnlMainBase, 0);
            this.main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main;
        private Tib.DelayDetailGrid tibDelayDetailGrid;

    }
}
