namespace Elvis.Forms.Trending.UserControls
{
    partial class TrendLegendItem
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
            this.components = new System.ComponentModel.Container();
            this.pnlLegContainer = new System.Windows.Forms.Panel();
            this.pnlLegColour = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.defaultColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLegTitle = new System.Windows.Forms.Label();
            this.colourPicker = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlLegContainer.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLegContainer
            // 
            this.pnlLegContainer.Controls.Add(this.pnlLegColour);
            this.pnlLegContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLegContainer.Location = new System.Drawing.Point(83, 0);
            this.pnlLegContainer.Name = "pnlLegContainer";
            this.pnlLegContainer.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLegContainer.Size = new System.Drawing.Size(110, 26);
            this.pnlLegContainer.TabIndex = 3;
            // 
            // pnlLegColour
            // 
            this.pnlLegColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegColour.ContextMenuStrip = this.contextMenuStrip1;
            this.pnlLegColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLegColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLegColour.Location = new System.Drawing.Point(3, 4);
            this.pnlLegColour.Name = "pnlLegColour";
            this.pnlLegColour.Size = new System.Drawing.Size(104, 18);
            this.pnlLegColour.TabIndex = 0;
            this.toolTip1.SetToolTip(this.pnlLegColour, "Left Click to change legend item colour or Right Click to set to default");
            this.pnlLegColour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlLegColour_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultColourToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            // 
            // defaultColourToolStripMenuItem
            // 
            this.defaultColourToolStripMenuItem.Name = "defaultColourToolStripMenuItem";
            this.defaultColourToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.defaultColourToolStripMenuItem.Text = "Default Colour";
            this.defaultColourToolStripMenuItem.ToolTipText = "Set Colour to Default Value";
            this.defaultColourToolStripMenuItem.Click += new System.EventHandler(this.defaultColourToolStripMenuItem_Click);
            // 
            // lblLegTitle
            // 
            this.lblLegTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLegTitle.Name = "lblLegTitle";
            this.lblLegTitle.Size = new System.Drawing.Size(83, 26);
            this.lblLegTitle.TabIndex = 2;
            this.lblLegTitle.Text = "Legend Text";
            this.lblLegTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrendLegendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLegTitle);
            this.Controls.Add(this.pnlLegContainer);
            this.Name = "TrendLegendItem";
            this.Size = new System.Drawing.Size(193, 26);
            this.pnlLegContainer.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLegContainer;
        private System.Windows.Forms.Panel pnlLegColour;
        private System.Windows.Forms.Label lblLegTitle;
        private System.Windows.Forms.ColorDialog colourPicker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem defaultColourToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
