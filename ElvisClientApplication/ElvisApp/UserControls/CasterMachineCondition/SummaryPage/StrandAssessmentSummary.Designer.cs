namespace Elvis.UserControls.CasterMachineCondition
{
    partial class StrandAssessmentSummary
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
            this.tableLayoutPanelSummary = new System.Windows.Forms.TableLayoutPanel();
            this.lblDaysSinceLastSarclad = new System.Windows.Forms.Label();
            this.lblSpeedRestriction = new System.Windows.Forms.Label();
            this.lblSlitting = new System.Windows.Forms.Label();
            this.lblInternalCritical = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanelSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Controls.Add(this.tableLayoutPanelSummary);
            this.pnlMain.Location = new System.Drawing.Point(0, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(122, 305);
            this.pnlMain.TabIndex = 8;
            // 
            // tableLayoutPanelSummary
            // 
            this.tableLayoutPanelSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelSummary.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelSummary.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanelSummary.ColumnCount = 1;
            this.tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSummary.Controls.Add(this.lblDaysSinceLastSarclad, 0, 3);
            this.tableLayoutPanelSummary.Controls.Add(this.lblSpeedRestriction, 0, 2);
            this.tableLayoutPanelSummary.Controls.Add(this.lblSlitting, 0, 1);
            this.tableLayoutPanelSummary.Controls.Add(this.lblInternalCritical, 0, 0);
            this.tableLayoutPanelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelSummary.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
            this.tableLayoutPanelSummary.RowCount = 4;
            this.tableLayoutPanelSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSummary.Size = new System.Drawing.Size(118, 300);
            this.tableLayoutPanelSummary.TabIndex = 12;
            this.tableLayoutPanelSummary.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanelSummary_CellPaint);
            // 
            // lblDaysSinceLastSarclad
            // 
            this.lblDaysSinceLastSarclad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDaysSinceLastSarclad.AutoSize = true;
            this.lblDaysSinceLastSarclad.BackColor = System.Drawing.Color.Transparent;
            this.lblDaysSinceLastSarclad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysSinceLastSarclad.Location = new System.Drawing.Point(13, 244);
            this.lblDaysSinceLastSarclad.Name = "lblDaysSinceLastSarclad";
            this.lblDaysSinceLastSarclad.Size = new System.Drawing.Size(92, 34);
            this.lblDaysSinceLastSarclad.TabIndex = 6;
            this.lblDaysSinceLastSarclad.Text = "Days since last sarclad";
            // 
            // lblSpeedRestriction
            // 
            this.lblSpeedRestriction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSpeedRestriction.AutoSize = true;
            this.lblSpeedRestriction.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeedRestriction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedRestriction.Location = new System.Drawing.Point(16, 169);
            this.lblSpeedRestriction.Name = "lblSpeedRestriction";
            this.lblSpeedRestriction.Size = new System.Drawing.Size(86, 34);
            this.lblSpeedRestriction.TabIndex = 5;
            this.lblSpeedRestriction.Text = "Speed Restriction";
            // 
            // lblSlitting
            // 
            this.lblSlitting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSlitting.AutoSize = true;
            this.lblSlitting.BackColor = System.Drawing.Color.Transparent;
            this.lblSlitting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlitting.Location = new System.Drawing.Point(30, 104);
            this.lblSlitting.Name = "lblSlitting";
            this.lblSlitting.Size = new System.Drawing.Size(58, 17);
            this.lblSlitting.TabIndex = 4;
            this.lblSlitting.Text = "Slitting";
            // 
            // lblInternalCritical
            // 
            this.lblInternalCritical.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInternalCritical.AutoSize = true;
            this.lblInternalCritical.BackColor = System.Drawing.Color.Transparent;
            this.lblInternalCritical.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalCritical.Location = new System.Drawing.Point(25, 21);
            this.lblInternalCritical.Name = "lblInternalCritical";
            this.lblInternalCritical.Size = new System.Drawing.Size(68, 34);
            this.lblInternalCritical.TabIndex = 3;
            this.lblInternalCritical.Text = "Internal Critical";
            // 
            // StrandAssessmentSummary
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlMain);
            this.Name = "StrandAssessmentSummary";
            this.Size = new System.Drawing.Size(125, 311);
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanelSummary.ResumeLayout(false);
            this.tableLayoutPanelSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSummary;
        private System.Windows.Forms.Label lblSpeedRestriction;
        private System.Windows.Forms.Label lblSlitting;
        private System.Windows.Forms.Label lblInternalCritical;
        private System.Windows.Forms.Label lblDaysSinceLastSarclad;
    }
}
