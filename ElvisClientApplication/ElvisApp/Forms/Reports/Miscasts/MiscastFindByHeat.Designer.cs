namespace Elvis.Forms.Reports.Miscasts
{
    partial class MiscastFindByHeat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiscastFindByHeat));
            this.grpFindHeat = new System.Windows.Forms.GroupBox();
            this.numHNS = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeatNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpFindHeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHNS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFindHeat
            // 
            this.grpFindHeat.Controls.Add(this.numHNS);
            this.grpFindHeat.Controls.Add(this.label2);
            this.grpFindHeat.Controls.Add(this.txtHeatNo);
            this.grpFindHeat.Controls.Add(this.label1);
            this.grpFindHeat.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFindHeat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFindHeat.Location = new System.Drawing.Point(6, 6);
            this.grpFindHeat.Name = "grpFindHeat";
            this.grpFindHeat.Padding = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.grpFindHeat.Size = new System.Drawing.Size(160, 79);
            this.grpFindHeat.TabIndex = 1;
            this.grpFindHeat.TabStop = false;
            this.grpFindHeat.Text = "Search";
            // 
            // numHNS
            // 
            this.numHNS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numHNS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHNS.Location = new System.Drawing.Point(104, 21);
            this.numHNS.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numHNS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHNS.Name = "numHNS";
            this.numHNS.Size = new System.Drawing.Size(47, 21);
            this.numHNS.TabIndex = 19;
            this.numHNS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Heat Number Set";
            // 
            // txtHeatNo
            // 
            this.txtHeatNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeatNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeatNo.Location = new System.Drawing.Point(85, 48);
            this.txtHeatNo.MaxLength = 5;
            this.txtHeatNo.Name = "txtHeatNo";
            this.txtHeatNo.Size = new System.Drawing.Size(66, 21);
            this.txtHeatNo.TabIndex = 1;
            this.txtHeatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeatNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heat Number";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(89, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(9, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MiscastFindByHeat
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(172, 118);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grpFindHeat);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiscastFindByHeat";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 2);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find by Heat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindHeat_FormClosing);
            this.Load += new System.EventHandler(this.MiscastFindByHeat_Load);
            this.grpFindHeat.ResumeLayout(false);
            this.grpFindHeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHNS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFindHeat;
        private System.Windows.Forms.NumericUpDown numHNS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeatNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
    }
}