namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    partial class RCAInvestigation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RCAInvestigation));
            this.grpInvestigation = new System.Windows.Forms.GroupBox();
            this.pnlWhys = new System.Windows.Forms.Panel();
            this.pnlRootCause = new System.Windows.Forms.Panel();
            this.txtRootCause = new System.Windows.Forms.TextBox();
            this.lblRoot = new System.Windows.Forms.Label();
            this.pnlProblemStatement = new System.Windows.Forms.Panel();
            this.txtProblemStatement = new System.Windows.Forms.TextBox();
            this.lblProblem = new System.Windows.Forms.Label();
            this.pnlArea = new System.Windows.Forms.Panel();
            this.txtInvestigator = new System.Windows.Forms.TextBox();
            this.lblInvestigator = new System.Windows.Forms.Label();
            this.cmboArea = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.pnlAddWhy = new System.Windows.Forms.Panel();
            this.btnDeleteInvestigation = new System.Windows.Forms.Button();
            this.btnAddWhy = new System.Windows.Forms.Button();
            this.grpInvestigation.SuspendLayout();
            this.pnlRootCause.SuspendLayout();
            this.pnlProblemStatement.SuspendLayout();
            this.pnlArea.SuspendLayout();
            this.pnlAddWhy.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInvestigation
            // 
            this.grpInvestigation.Controls.Add(this.pnlWhys);
            this.grpInvestigation.Controls.Add(this.pnlRootCause);
            this.grpInvestigation.Controls.Add(this.pnlProblemStatement);
            this.grpInvestigation.Controls.Add(this.pnlArea);
            this.grpInvestigation.Controls.Add(this.pnlAddWhy);
            this.grpInvestigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInvestigation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInvestigation.Location = new System.Drawing.Point(0, 0);
            this.grpInvestigation.Name = "grpInvestigation";
            this.grpInvestigation.Size = new System.Drawing.Size(704, 127);
            this.grpInvestigation.TabIndex = 0;
            this.grpInvestigation.TabStop = false;
            this.grpInvestigation.Text = "Investigation No. #";
            // 
            // pnlWhys
            // 
            this.pnlWhys.AutoScroll = true;
            this.pnlWhys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWhys.Location = new System.Drawing.Point(3, 69);
            this.pnlWhys.Name = "pnlWhys";
            this.pnlWhys.Size = new System.Drawing.Size(698, 0);
            this.pnlWhys.TabIndex = 67;
            // 
            // pnlRootCause
            // 
            this.pnlRootCause.Controls.Add(this.txtRootCause);
            this.pnlRootCause.Controls.Add(this.lblRoot);
            this.pnlRootCause.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRootCause.Location = new System.Drawing.Point(3, 69);
            this.pnlRootCause.Name = "pnlRootCause";
            this.pnlRootCause.Padding = new System.Windows.Forms.Padding(2);
            this.pnlRootCause.Size = new System.Drawing.Size(698, 26);
            this.pnlRootCause.TabIndex = 68;
            // 
            // txtRootCause
            // 
            this.txtRootCause.BackColor = System.Drawing.SystemColors.Window;
            this.txtRootCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRootCause.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRootCause.Location = new System.Drawing.Point(124, 2);
            this.txtRootCause.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.txtRootCause.Name = "txtRootCause";
            this.txtRootCause.ReadOnly = true;
            this.txtRootCause.Size = new System.Drawing.Size(572, 22);
            this.txtRootCause.TabIndex = 0;
            this.txtRootCause.TextChanged += new System.EventHandler(this.Ctrl_Modified);
            // 
            // lblRoot
            // 
            this.lblRoot.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRoot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoot.Location = new System.Drawing.Point(2, 2);
            this.lblRoot.Name = "lblRoot";
            this.lblRoot.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRoot.Size = new System.Drawing.Size(122, 22);
            this.lblRoot.TabIndex = 56;
            this.lblRoot.Text = "Root Cause";
            this.lblRoot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlProblemStatement
            // 
            this.pnlProblemStatement.Controls.Add(this.txtProblemStatement);
            this.pnlProblemStatement.Controls.Add(this.lblProblem);
            this.pnlProblemStatement.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProblemStatement.Location = new System.Drawing.Point(3, 43);
            this.pnlProblemStatement.Name = "pnlProblemStatement";
            this.pnlProblemStatement.Padding = new System.Windows.Forms.Padding(2);
            this.pnlProblemStatement.Size = new System.Drawing.Size(698, 26);
            this.pnlProblemStatement.TabIndex = 66;
            // 
            // txtProblemStatement
            // 
            this.txtProblemStatement.BackColor = System.Drawing.SystemColors.Window;
            this.txtProblemStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProblemStatement.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProblemStatement.Location = new System.Drawing.Point(124, 2);
            this.txtProblemStatement.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.txtProblemStatement.Name = "txtProblemStatement";
            this.txtProblemStatement.ReadOnly = true;
            this.txtProblemStatement.Size = new System.Drawing.Size(572, 22);
            this.txtProblemStatement.TabIndex = 0;
            this.txtProblemStatement.TextChanged += new System.EventHandler(this.Ctrl_Modified);
            // 
            // lblProblem
            // 
            this.lblProblem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProblem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblem.Location = new System.Drawing.Point(2, 2);
            this.lblProblem.Name = "lblProblem";
            this.lblProblem.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblProblem.Size = new System.Drawing.Size(122, 22);
            this.lblProblem.TabIndex = 56;
            this.lblProblem.Text = "Problem Statement";
            this.lblProblem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlArea
            // 
            this.pnlArea.Controls.Add(this.txtInvestigator);
            this.pnlArea.Controls.Add(this.lblInvestigator);
            this.pnlArea.Controls.Add(this.cmboArea);
            this.pnlArea.Controls.Add(this.lblArea);
            this.pnlArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArea.Location = new System.Drawing.Point(3, 17);
            this.pnlArea.Name = "pnlArea";
            this.pnlArea.Padding = new System.Windows.Forms.Padding(2);
            this.pnlArea.Size = new System.Drawing.Size(698, 26);
            this.pnlArea.TabIndex = 65;
            // 
            // txtInvestigator
            // 
            this.txtInvestigator.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvestigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvestigator.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvestigator.Location = new System.Drawing.Point(323, 2);
            this.txtInvestigator.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.txtInvestigator.Name = "txtInvestigator";
            this.txtInvestigator.ReadOnly = true;
            this.txtInvestigator.Size = new System.Drawing.Size(373, 22);
            this.txtInvestigator.TabIndex = 1;
            this.txtInvestigator.TextChanged += new System.EventHandler(this.Ctrl_Modified);
            // 
            // lblInvestigator
            // 
            this.lblInvestigator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInvestigator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvestigator.Location = new System.Drawing.Point(223, 2);
            this.lblInvestigator.Name = "lblInvestigator";
            this.lblInvestigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblInvestigator.Size = new System.Drawing.Size(100, 22);
            this.lblInvestigator.TabIndex = 58;
            this.lblInvestigator.Text = "Investigator";
            this.lblInvestigator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmboArea
            // 
            this.cmboArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboArea.FormattingEnabled = true;
            this.cmboArea.Location = new System.Drawing.Point(124, 2);
            this.cmboArea.Margin = new System.Windows.Forms.Padding(0, 3, 6, 6);
            this.cmboArea.Name = "cmboArea";
            this.cmboArea.Size = new System.Drawing.Size(99, 21);
            this.cmboArea.TabIndex = 0;
            this.cmboArea.SelectedIndexChanged += new System.EventHandler(this.Ctrl_Modified);
            // 
            // lblArea
            // 
            this.lblArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(2, 2);
            this.lblArea.Name = "lblArea";
            this.lblArea.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblArea.Size = new System.Drawing.Size(122, 22);
            this.lblArea.TabIndex = 56;
            this.lblArea.Text = "Area";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlAddWhy
            // 
            this.pnlAddWhy.Controls.Add(this.btnDeleteInvestigation);
            this.pnlAddWhy.Controls.Add(this.btnAddWhy);
            this.pnlAddWhy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAddWhy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAddWhy.Location = new System.Drawing.Point(3, 95);
            this.pnlAddWhy.Name = "pnlAddWhy";
            this.pnlAddWhy.Padding = new System.Windows.Forms.Padding(3, 1, 1, 2);
            this.pnlAddWhy.Size = new System.Drawing.Size(698, 29);
            this.pnlAddWhy.TabIndex = 69;
            // 
            // btnDeleteInvestigation
            // 
            this.btnDeleteInvestigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteInvestigation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInvestigation.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteInvestigation.Image")));
            this.btnDeleteInvestigation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteInvestigation.Location = new System.Drawing.Point(3, 1);
            this.btnDeleteInvestigation.Name = "btnDeleteInvestigation";
            this.btnDeleteInvestigation.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.btnDeleteInvestigation.Size = new System.Drawing.Size(151, 26);
            this.btnDeleteInvestigation.TabIndex = 0;
            this.btnDeleteInvestigation.Text = "&Delete Investigation";
            this.btnDeleteInvestigation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteInvestigation.UseVisualStyleBackColor = true;
            this.btnDeleteInvestigation.Click += new System.EventHandler(this.btnDeleteInvestigation_Click);
            // 
            // btnAddWhy
            // 
            this.btnAddWhy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddWhy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWhy.Image = ((System.Drawing.Image)(resources.GetObject("btnAddWhy.Image")));
            this.btnAddWhy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddWhy.Location = new System.Drawing.Point(611, 1);
            this.btnAddWhy.Name = "btnAddWhy";
            this.btnAddWhy.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.btnAddWhy.Size = new System.Drawing.Size(86, 26);
            this.btnAddWhy.TabIndex = 1;
            this.btnAddWhy.Text = "Add &Why";
            this.btnAddWhy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddWhy.UseVisualStyleBackColor = true;
            this.btnAddWhy.Click += new System.EventHandler(this.btnAddWhy_Click);
            // 
            // RCAInvestigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.grpInvestigation);
            this.Name = "RCAInvestigation";
            this.Size = new System.Drawing.Size(704, 127);
            this.Load += new System.EventHandler(this.RCAInvestigation_Load);
            this.grpInvestigation.ResumeLayout(false);
            this.pnlRootCause.ResumeLayout(false);
            this.pnlRootCause.PerformLayout();
            this.pnlProblemStatement.ResumeLayout(false);
            this.pnlProblemStatement.PerformLayout();
            this.pnlArea.ResumeLayout(false);
            this.pnlArea.PerformLayout();
            this.pnlAddWhy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInvestigation;
        private System.Windows.Forms.Panel pnlArea;
        private System.Windows.Forms.TextBox txtInvestigator;
        private System.Windows.Forms.Label lblInvestigator;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cmboArea;
        private System.Windows.Forms.Panel pnlProblemStatement;
        private System.Windows.Forms.TextBox txtProblemStatement;
        private System.Windows.Forms.Label lblProblem;
        private System.Windows.Forms.Panel pnlRootCause;
        private System.Windows.Forms.TextBox txtRootCause;
        private System.Windows.Forms.Label lblRoot;
        private System.Windows.Forms.Panel pnlAddWhy;
        private System.Windows.Forms.Button btnAddWhy;
        private System.Windows.Forms.Panel pnlWhys;
        private System.Windows.Forms.Button btnDeleteInvestigation;
    }
}
