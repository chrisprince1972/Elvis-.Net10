namespace Elvis.Forms.Reports.Incident
{
    partial class SaveAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAction));
            this.dtpTargetDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtClosedBy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtActionCreated = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenAction = new System.Windows.Forms.Button();
            this.btnCloseAction = new System.Windows.Forms.Button();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlMasterSave = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIncidentOwner = new System.Windows.Forms.TextBox();
            this.txtIncidentFunction = new System.Windows.Forms.TextBox();
            this.txtIncidentArea = new System.Windows.Forms.TextBox();
            this.txtIncidentDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIncidentClosed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIncidentCreated = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpClosedWarning = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.pnlMasterSave.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpClosedWarning.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpTargetDate
            // 
            this.dtpTargetDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTargetDate.Location = new System.Drawing.Point(71, 60);
            this.dtpTargetDate.Name = "dtpTargetDate";
            this.dtpTargetDate.Size = new System.Drawing.Size(150, 22);
            this.dtpTargetDate.TabIndex = 13;
            this.dtpTargetDate.ValueChanged += new System.EventHandler(this.dtpTargetDate_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtClosedBy);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtActionCreated);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.dtpTargetDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboOwner);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnOpenAction);
            this.groupBox1.Controls.Add(this.btnCloseAction);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(9, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 102);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // txtClosedBy
            // 
            this.txtClosedBy.Location = new System.Drawing.Point(553, 21);
            this.txtClosedBy.Name = "txtClosedBy";
            this.txtClosedBy.ReadOnly = true;
            this.txtClosedBy.Size = new System.Drawing.Size(150, 22);
            this.txtClosedBy.TabIndex = 27;
            this.txtClosedBy.Text = "Open";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(477, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 26;
            this.label11.Text = "Closed By:";
            // 
            // txtActionCreated
            // 
            this.txtActionCreated.Location = new System.Drawing.Point(308, 24);
            this.txtActionCreated.Name = "txtActionCreated";
            this.txtActionCreated.ReadOnly = true;
            this.txtActionCreated.Size = new System.Drawing.Size(150, 22);
            this.txtActionCreated.TabIndex = 25;
            this.txtActionCreated.Text = "<Not Created>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(243, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 14);
            this.label10.TabIndex = 24;
            this.label10.Text = "Created:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Target:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(308, 60);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(150, 22);
            this.txtStatus.TabIndex = 22;
            this.txtStatus.Text = "Open";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(243, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "Closed:";
            // 
            // cboOwner
            // 
            this.cboOwner.BackColor = System.Drawing.Color.White;
            this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(71, 23);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(150, 22);
            this.cboOwner.TabIndex = 20;
            this.cboOwner.SelectedIndexChanged += new System.EventHandler(this.cboOwner_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "Owner:";
            // 
            // btnOpenAction
            // 
            this.btnOpenAction.Location = new System.Drawing.Point(585, 60);
            this.btnOpenAction.Name = "btnOpenAction";
            this.btnOpenAction.Size = new System.Drawing.Size(102, 23);
            this.btnOpenAction.TabIndex = 10;
            this.btnOpenAction.Text = "Open Action";
            this.btnOpenAction.UseVisualStyleBackColor = true;
            this.btnOpenAction.Click += new System.EventHandler(this.btnOpenAction_Click);
            // 
            // btnCloseAction
            // 
            this.btnCloseAction.Location = new System.Drawing.Point(477, 60);
            this.btnCloseAction.Name = "btnCloseAction";
            this.btnCloseAction.Size = new System.Drawing.Size(102, 23);
            this.btnCloseAction.TabIndex = 9;
            this.btnCloseAction.Text = "Close Action";
            this.btnCloseAction.UseVisualStyleBackColor = true;
            this.btnCloseAction.Click += new System.EventHandler(this.btnCloseAction_Click);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.txtDescription);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grpAction.Location = new System.Drawing.Point(9, 446);
            this.grpAction.Name = "grpAction";
            this.grpAction.Padding = new System.Windows.Forms.Padding(9);
            this.grpAction.Size = new System.Drawing.Size(718, 285);
            this.grpAction.TabIndex = 20;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(9, 24);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(700, 252);
            this.txtDescription.TabIndex = 21;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // pnlMasterSave
            // 
            this.pnlMasterSave.Controls.Add(this.btnSave);
            this.pnlMasterSave.Controls.Add(this.btnCancel);
            this.pnlMasterSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMasterSave.Location = new System.Drawing.Point(9, 731);
            this.pnlMasterSave.Name = "pnlMasterSave";
            this.pnlMasterSave.Size = new System.Drawing.Size(718, 26);
            this.pnlMasterSave.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(478, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 26);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(598, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 26);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIncidentOwner);
            this.groupBox2.Controls.Add(this.txtIncidentFunction);
            this.groupBox2.Controls.Add(this.txtIncidentArea);
            this.groupBox2.Controls.Add(this.txtIncidentDescription);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtIncidentClosed);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtIncidentCreated);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(9, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 304);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Incident Information";
            // 
            // txtIncidentOwner
            // 
            this.txtIncidentOwner.Location = new System.Drawing.Point(553, 52);
            this.txtIncidentOwner.Name = "txtIncidentOwner";
            this.txtIncidentOwner.ReadOnly = true;
            this.txtIncidentOwner.Size = new System.Drawing.Size(150, 22);
            this.txtIncidentOwner.TabIndex = 26;
            this.txtIncidentOwner.Text = "Open";
            this.txtIncidentOwner.Visible = false;
            // 
            // txtIncidentFunction
            // 
            this.txtIncidentFunction.Location = new System.Drawing.Point(317, 52);
            this.txtIncidentFunction.Name = "txtIncidentFunction";
            this.txtIncidentFunction.ReadOnly = true;
            this.txtIncidentFunction.Size = new System.Drawing.Size(150, 22);
            this.txtIncidentFunction.TabIndex = 25;
            this.txtIncidentFunction.Text = "Open";
            // 
            // txtIncidentArea
            // 
            this.txtIncidentArea.Location = new System.Drawing.Point(71, 52);
            this.txtIncidentArea.Name = "txtIncidentArea";
            this.txtIncidentArea.ReadOnly = true;
            this.txtIncidentArea.Size = new System.Drawing.Size(150, 22);
            this.txtIncidentArea.TabIndex = 24;
            this.txtIncidentArea.Text = "Open";
            // 
            // txtIncidentDescription
            // 
            this.txtIncidentDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtIncidentDescription.Location = new System.Drawing.Point(9, 81);
            this.txtIncidentDescription.Multiline = true;
            this.txtIncidentDescription.Name = "txtIncidentDescription";
            this.txtIncidentDescription.ReadOnly = true;
            this.txtIncidentDescription.Size = new System.Drawing.Size(694, 211);
            this.txtIncidentDescription.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(487, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "Owner: ";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(243, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "Function: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(26, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Area:";
            // 
            // txtIncidentClosed
            // 
            this.txtIncidentClosed.Location = new System.Drawing.Point(317, 21);
            this.txtIncidentClosed.Name = "txtIncidentClosed";
            this.txtIncidentClosed.ReadOnly = true;
            this.txtIncidentClosed.Size = new System.Drawing.Size(150, 22);
            this.txtIncidentClosed.TabIndex = 8;
            this.txtIncidentClosed.Text = "Open";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(256, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Closed: ";
            // 
            // txtIncidentCreated
            // 
            this.txtIncidentCreated.Location = new System.Drawing.Point(71, 24);
            this.txtIncidentCreated.Name = "txtIncidentCreated";
            this.txtIncidentCreated.ReadOnly = true;
            this.txtIncidentCreated.Size = new System.Drawing.Size(150, 22);
            this.txtIncidentCreated.TabIndex = 6;
            this.txtIncidentCreated.Text = "<Not Created>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Created:";
            // 
            // grpClosedWarning
            // 
            this.grpClosedWarning.Controls.Add(this.label9);
            this.grpClosedWarning.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpClosedWarning.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grpClosedWarning.Location = new System.Drawing.Point(9, 3);
            this.grpClosedWarning.Name = "grpClosedWarning";
            this.grpClosedWarning.Padding = new System.Windows.Forms.Padding(9);
            this.grpClosedWarning.Size = new System.Drawing.Size(718, 37);
            this.grpClosedWarning.TabIndex = 23;
            this.grpClosedWarning.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(697, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Action can not be edited because the incident is marked as closed";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 760);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.pnlMasterSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpClosedWarning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveAction";
            this.Padding = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.Text = "Save Action";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveAction_FormClosing);
            this.Load += new System.EventHandler(this.AddAction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.pnlMasterSave.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpClosedWarning.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTargetDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenAction;
        private System.Windows.Forms.Button btnCloseAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlMasterSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIncidentClosed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIncidentCreated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIncidentOwner;
        private System.Windows.Forms.TextBox txtIncidentFunction;
        private System.Windows.Forms.TextBox txtIncidentArea;
        private System.Windows.Forms.TextBox txtIncidentDescription;
        private System.Windows.Forms.GroupBox grpClosedWarning;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtActionCreated;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtClosedBy;
        private System.Windows.Forms.Label label11;
    }
}