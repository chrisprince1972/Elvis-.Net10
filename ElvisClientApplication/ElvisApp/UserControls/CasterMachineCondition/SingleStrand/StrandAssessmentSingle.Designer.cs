namespace Elvis.UserControls.CasterMachineCondition
{
    partial class StrandAssessmentSingle
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
            this.tableLayoutPanelSingleSummary = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSpeedRestriction = new System.Windows.Forms.Label();
            this.lblSlitting = new System.Windows.Forms.Label();
            this.lblInternalCritical = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanelSingleSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Controls.Add(this.tableLayoutPanelSingleSummary);
            this.pnlMain.Location = new System.Drawing.Point(0, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(248, 143);
            this.pnlMain.TabIndex = 8;
            // 
            // tableLayoutPanelSingleSummary
            // 
            this.tableLayoutPanelSingleSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelSingleSummary.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelSingleSummary.ColumnCount = 2;
            this.tableLayoutPanelSingleSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.71784F));
            this.tableLayoutPanelSingleSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.28216F));
            this.tableLayoutPanelSingleSummary.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.lblSpeedRestriction, 1, 2);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.lblSlitting, 1, 1);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.lblInternalCritical, 1, 0);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanelSingleSummary.Controls.Add(this.txtComment, 1, 3);
            this.tableLayoutPanelSingleSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelSingleSummary.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSingleSummary.Name = "tableLayoutPanelSingleSummary";
            this.tableLayoutPanelSingleSummary.RowCount = 4;
            this.tableLayoutPanelSingleSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.11765F));
            this.tableLayoutPanelSingleSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.91176F));
            this.tableLayoutPanelSingleSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tableLayoutPanelSingleSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.32353F));
            this.tableLayoutPanelSingleSummary.Size = new System.Drawing.Size(242, 137);
            this.tableLayoutPanelSingleSummary.TabIndex = 12;
            this.tableLayoutPanelSingleSummary.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanelSingleSummary_CellPaint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Comment";
            // 
            // lblSpeedRestriction
            // 
            this.lblSpeedRestriction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSpeedRestriction.AutoSize = true;
            this.lblSpeedRestriction.Location = new System.Drawing.Point(178, 55);
            this.lblSpeedRestriction.Name = "lblSpeedRestriction";
            this.lblSpeedRestriction.Size = new System.Drawing.Size(0, 13);
            this.lblSpeedRestriction.TabIndex = 5;
            // 
            // lblSlitting
            // 
            this.lblSlitting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSlitting.AutoSize = true;
            this.lblSlitting.BackColor = System.Drawing.Color.Transparent;
            this.lblSlitting.Location = new System.Drawing.Point(178, 31);
            this.lblSlitting.Name = "lblSlitting";
            this.lblSlitting.Size = new System.Drawing.Size(0, 13);
            this.lblSlitting.TabIndex = 4;
            // 
            // lblInternalCritical
            // 
            this.lblInternalCritical.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInternalCritical.AutoSize = true;
            this.lblInternalCritical.BackColor = System.Drawing.Color.Transparent;
            this.lblInternalCritical.Location = new System.Drawing.Point(178, 7);
            this.lblInternalCritical.Name = "lblInternalCritical";
            this.lblInternalCritical.Size = new System.Drawing.Size(0, 13);
            this.lblInternalCritical.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Internal Critical";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Speed Restriction";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Slitting";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(119, 77);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(119, 56);
            this.txtComment.TabIndex = 7;
            // 
            // StrandAssessmentSingle
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlMain);
            this.Name = "StrandAssessmentSingle";
            this.Size = new System.Drawing.Size(251, 149);
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanelSingleSummary.ResumeLayout(false);
            this.tableLayoutPanelSingleSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSingleSummary;
        private System.Windows.Forms.Label lblSpeedRestriction;
        private System.Windows.Forms.Label lblSlitting;
        private System.Windows.Forms.Label lblInternalCritical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
    }
}
