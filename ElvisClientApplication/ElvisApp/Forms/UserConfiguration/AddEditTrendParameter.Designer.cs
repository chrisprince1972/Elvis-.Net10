namespace Elvis.Forms.UserConfiguration
{
    partial class AddEditTrendParameter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditTrendParameter));
            this.pnlClose = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.pnlParameter = new System.Windows.Forms.Panel();
            this.numCellWidth = new System.Windows.Forms.NumericUpDown();
            this.lblCellWidth = new System.Windows.Forms.Label();
            this.numDisplayMax = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numDisplayMin = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numAimTarget = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numMaxLimit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numMinLimit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.toolTipGroupCount = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlClose.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.pnlParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCellWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplayMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAimTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.lblError);
            this.pnlClose.Controls.Add(this.btnSave);
            this.pnlClose.Controls.Add(this.btnCancel);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClose.Location = new System.Drawing.Point(0, 215);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Padding = new System.Windows.Forms.Padding(6, 0, 10, 5);
            this.pnlClose.Size = new System.Drawing.Size(418, 27);
            this.pnlClose.TabIndex = 5;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(259, 22);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Error Text";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(272, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(344, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6, 6, 6, 4);
            this.pnlMain.Size = new System.Drawing.Size(418, 215);
            this.pnlMain.TabIndex = 6;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.pnlParameter);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMain.Location = new System.Drawing.Point(6, 6);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(6);
            this.grpMain.Size = new System.Drawing.Size(406, 205);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "New Trend Parameter";
            // 
            // pnlParameter
            // 
            this.pnlParameter.Controls.Add(this.label9);
            this.pnlParameter.Controls.Add(this.txtParameter);
            this.pnlParameter.Controls.Add(this.label10);
            this.pnlParameter.Controls.Add(this.numCellWidth);
            this.pnlParameter.Controls.Add(this.lblCellWidth);
            this.pnlParameter.Controls.Add(this.numDisplayMax);
            this.pnlParameter.Controls.Add(this.label8);
            this.pnlParameter.Controls.Add(this.numDisplayMin);
            this.pnlParameter.Controls.Add(this.label7);
            this.pnlParameter.Controls.Add(this.numAimTarget);
            this.pnlParameter.Controls.Add(this.label6);
            this.pnlParameter.Controls.Add(this.numMaxLimit);
            this.pnlParameter.Controls.Add(this.label5);
            this.pnlParameter.Controls.Add(this.numMinLimit);
            this.pnlParameter.Controls.Add(this.label4);
            this.pnlParameter.Controls.Add(this.label3);
            this.pnlParameter.Controls.Add(this.txtDesc);
            this.pnlParameter.Controls.Add(this.label1);
            this.pnlParameter.Controls.Add(this.txtFieldName);
            this.pnlParameter.Controls.Add(this.label2);
            this.pnlParameter.Controls.Add(this.lblFieldName);
            this.pnlParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameter.Location = new System.Drawing.Point(6, 19);
            this.pnlParameter.Name = "pnlParameter";
            this.pnlParameter.Padding = new System.Windows.Forms.Padding(3);
            this.pnlParameter.Size = new System.Drawing.Size(394, 180);
            this.pnlParameter.TabIndex = 1;
            // 
            // numCellWidth
            // 
            this.numCellWidth.DecimalPlaces = 1;
            this.numCellWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCellWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numCellWidth.Location = new System.Drawing.Point(327, 154);
            this.numCellWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numCellWidth.Name = "numCellWidth";
            this.numCellWidth.Size = new System.Drawing.Size(61, 20);
            this.numCellWidth.TabIndex = 17;
            this.numCellWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCellWidth.ValueChanged += new System.EventHandler(this.numPicker_ValueChanged);
            // 
            // lblCellWidth
            // 
            this.lblCellWidth.AutoSize = true;
            this.lblCellWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellWidth.Location = new System.Drawing.Point(266, 158);
            this.lblCellWidth.Name = "lblCellWidth";
            this.lblCellWidth.Size = new System.Drawing.Size(55, 13);
            this.lblCellWidth.TabIndex = 16;
            this.lblCellWidth.Text = "Cell Width";
            // 
            // numDisplayMax
            // 
            this.numDisplayMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDisplayMax.Location = new System.Drawing.Point(196, 154);
            this.numDisplayMax.Maximum = new decimal(new int[] {
            32786,
            0,
            0,
            0});
            this.numDisplayMax.Minimum = new decimal(new int[] {
            32786,
            0,
            0,
            -2147483648});
            this.numDisplayMax.Name = "numDisplayMax";
            this.numDisplayMax.Size = new System.Drawing.Size(61, 20);
            this.numDisplayMax.TabIndex = 15;
            this.numDisplayMax.ValueChanged += new System.EventHandler(this.numPicker_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(141, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Axis Max";
            // 
            // numDisplayMin
            // 
            this.numDisplayMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDisplayMin.Location = new System.Drawing.Point(72, 154);
            this.numDisplayMin.Maximum = new decimal(new int[] {
            32786,
            0,
            0,
            0});
            this.numDisplayMin.Minimum = new decimal(new int[] {
            32786,
            0,
            0,
            -2147483648});
            this.numDisplayMin.Name = "numDisplayMin";
            this.numDisplayMin.Size = new System.Drawing.Size(61, 20);
            this.numDisplayMin.TabIndex = 13;
            this.numDisplayMin.ValueChanged += new System.EventHandler(this.numPicker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Axis Min";
            // 
            // numAimTarget
            // 
            this.numAimTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAimTarget.Location = new System.Drawing.Point(327, 128);
            this.numAimTarget.Maximum = new decimal(new int[] {
            32786,
            0,
            0,
            0});
            this.numAimTarget.Minimum = new decimal(new int[] {
            32786,
            0,
            0,
            -2147483648});
            this.numAimTarget.Name = "numAimTarget";
            this.numAimTarget.Size = new System.Drawing.Size(61, 20);
            this.numAimTarget.TabIndex = 11;
            this.numAimTarget.ValueChanged += new System.EventHandler(this.numPicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(263, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Aim Target";
            // 
            // numMaxLimit
            // 
            this.numMaxLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxLimit.Location = new System.Drawing.Point(196, 128);
            this.numMaxLimit.Maximum = new decimal(new int[] {
            32786,
            0,
            0,
            0});
            this.numMaxLimit.Minimum = new decimal(new int[] {
            32786,
            0,
            0,
            -2147483648});
            this.numMaxLimit.Name = "numMaxLimit";
            this.numMaxLimit.Size = new System.Drawing.Size(61, 20);
            this.numMaxLimit.TabIndex = 9;
            this.numMaxLimit.ValueChanged += new System.EventHandler(this.numPicker_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Max Limit";
            // 
            // numMinLimit
            // 
            this.numMinLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinLimit.Location = new System.Drawing.Point(72, 128);
            this.numMinLimit.Maximum = new decimal(new int[] {
            32786,
            0,
            0,
            0});
            this.numMinLimit.Minimum = new decimal(new int[] {
            32786,
            0,
            0,
            -2147483648});
            this.numMinLimit.Name = "numMinLimit";
            this.numMinLimit.Size = new System.Drawing.Size(61, 20);
            this.numMinLimit.TabIndex = 7;
            this.numMinLimit.ValueChanged += new System.EventHandler(this.numPicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min Limit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Max 200 char.)";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(72, 58);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(226, 64);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "(Max 50 char.)";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFieldName.Location = new System.Drawing.Point(72, 6);
            this.txtFieldName.MaxLength = 50;
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(226, 20);
            this.txtFieldName.TabIndex = 2;
            this.txtFieldName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldName.Location = new System.Drawing.Point(6, 9);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(60, 13);
            this.lblFieldName.TabIndex = 0;
            this.lblFieldName.Text = "Field Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(304, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "(Max 50 char.)";
            // 
            // txtParameter
            // 
            this.txtParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParameter.Location = new System.Drawing.Point(72, 32);
            this.txtParameter.MaxLength = 50;
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(226, 20);
            this.txtParameter.TabIndex = 19;
            this.txtParameter.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Parameter";
            // 
            // AddEditTrendParameter
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(418, 242);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditTrendParameter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Trend Parameter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditTrendParameter_FormClosing);
            this.Load += new System.EventHandler(this.AddEditTrendParameter_Load);
            this.pnlClose.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.pnlParameter.ResumeLayout(false);
            this.pnlParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCellWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplayMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplayMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAimTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Panel pnlParameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMinLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMaxLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAimTarget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numDisplayMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numDisplayMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.NumericUpDown numCellWidth;
        private System.Windows.Forms.Label lblCellWidth;
        private System.Windows.Forms.ToolTip toolTipGroupCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Label label10;
    }
}