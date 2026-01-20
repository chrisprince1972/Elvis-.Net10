namespace Elvis.Forms.Tib
{
    partial class DelayPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelayPopup));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDRF = new System.Windows.Forms.Button();
            this.btnDeleteDelay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpReasons = new System.Windows.Forms.GroupBox();
            this.pnlLevel4 = new System.Windows.Forms.Panel();
            this.grpLevel4 = new System.Windows.Forms.GroupBox();
            this.lstLevel4 = new System.Windows.Forms.CheckedListBox();
            this.pnlLevel3 = new System.Windows.Forms.Panel();
            this.grpLevel3 = new System.Windows.Forms.GroupBox();
            this.lstLevel3 = new System.Windows.Forms.CheckedListBox();
            this.pnlLevel2 = new System.Windows.Forms.Panel();
            this.grpLevel2 = new System.Windows.Forms.GroupBox();
            this.lstLevel2 = new System.Windows.Forms.CheckedListBox();
            this.pnlLevel1 = new System.Windows.Forms.Panel();
            this.grpLevel1 = new System.Windows.Forms.GroupBox();
            this.lstLevel1 = new System.Windows.Forms.CheckedListBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlReasons = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtDiscipline = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numMins = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlButtons.SuspendLayout();
            this.grpReasons.SuspendLayout();
            this.pnlLevel4.SuspendLayout();
            this.grpLevel4.SuspendLayout();
            this.pnlLevel3.SuspendLayout();
            this.grpLevel3.SuspendLayout();
            this.pnlLevel2.SuspendLayout();
            this.grpLevel2.SuspendLayout();
            this.pnlLevel1.SuspendLayout();
            this.grpLevel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlReasons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMins)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDRF);
            this.pnlButtons.Controls.Add(this.btnDeleteDelay);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 394);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Size = new System.Drawing.Size(819, 34);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnDRF
            // 
            this.btnDRF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDRF.Enabled = false;
            this.btnDRF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDRF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDRF.Location = new System.Drawing.Point(500, 1);
            this.btnDRF.Name = "btnDRF";
            this.btnDRF.Size = new System.Drawing.Size(100, 26);
            this.btnDRF.TabIndex = 21;
            this.btnDRF.Text = "New &DRF...";
            this.toolTip1.SetToolTip(this.btnDRF, "Create a new DRF Report associated with this delay.");
            this.btnDRF.UseVisualStyleBackColor = true;
            this.btnDRF.Click += new System.EventHandler(this.btnDRF_Click);
            // 
            // btnDeleteDelay
            // 
            this.btnDeleteDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteDelay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeleteDelay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteDelay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteDelay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteDelay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDelay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteDelay.Image = global::Elvis.Properties.Resources.delete_12x12;
            this.btnDeleteDelay.Location = new System.Drawing.Point(7, 1);
            this.btnDeleteDelay.Name = "btnDeleteDelay";
            this.btnDeleteDelay.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnDeleteDelay.Size = new System.Drawing.Size(76, 26);
            this.btnDeleteDelay.TabIndex = 20;
            this.btnDeleteDelay.Text = "&Delete";
            this.btnDeleteDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDeleteDelay, "Delete this delay permanently. This process cannot be undone.");
            this.btnDeleteDelay.Click += new System.EventHandler(this.btnDeleteDelay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(606, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "&Save";
            this.toolTip1.SetToolTip(this.btnSave, "Saves and updates an existing delay or adds a new delay.");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(712, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "&Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Closes the form and loses any unsaved changes.");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpReasons
            // 
            this.grpReasons.Controls.Add(this.pnlLevel4);
            this.grpReasons.Controls.Add(this.pnlLevel3);
            this.grpReasons.Controls.Add(this.pnlLevel2);
            this.grpReasons.Controls.Add(this.pnlLevel1);
            this.grpReasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReasons.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReasons.Location = new System.Drawing.Point(0, 0);
            this.grpReasons.Name = "grpReasons";
            this.grpReasons.Padding = new System.Windows.Forms.Padding(6);
            this.grpReasons.Size = new System.Drawing.Size(807, 240);
            this.grpReasons.TabIndex = 1;
            this.grpReasons.TabStop = false;
            this.grpReasons.Text = "Reasons";
            // 
            // pnlLevel4
            // 
            this.pnlLevel4.Controls.Add(this.grpLevel4);
            this.pnlLevel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLevel4.Location = new System.Drawing.Point(606, 20);
            this.pnlLevel4.Name = "pnlLevel4";
            this.pnlLevel4.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlLevel4.Size = new System.Drawing.Size(200, 214);
            this.pnlLevel4.TabIndex = 3;
            // 
            // grpLevel4
            // 
            this.grpLevel4.Controls.Add(this.lstLevel4);
            this.grpLevel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLevel4.Location = new System.Drawing.Point(0, 0);
            this.grpLevel4.Name = "grpLevel4";
            this.grpLevel4.Padding = new System.Windows.Forms.Padding(6);
            this.grpLevel4.Size = new System.Drawing.Size(194, 214);
            this.grpLevel4.TabIndex = 0;
            this.grpLevel4.TabStop = false;
            this.grpLevel4.Text = "Level 4";
            // 
            // lstLevel4
            // 
            this.lstLevel4.CheckOnClick = true;
            this.lstLevel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLevel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstLevel4.FormattingEnabled = true;
            this.lstLevel4.Location = new System.Drawing.Point(6, 20);
            this.lstLevel4.Name = "lstLevel4";
            this.lstLevel4.Size = new System.Drawing.Size(182, 188);
            this.lstLevel4.TabIndex = 4;
            this.lstLevel4.Tag = "DelayReason4";
            this.lstLevel4.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLevel_ItemCheck);
            // 
            // pnlLevel3
            // 
            this.pnlLevel3.Controls.Add(this.grpLevel3);
            this.pnlLevel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLevel3.Location = new System.Drawing.Point(406, 20);
            this.pnlLevel3.Name = "pnlLevel3";
            this.pnlLevel3.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlLevel3.Size = new System.Drawing.Size(200, 214);
            this.pnlLevel3.TabIndex = 2;
            // 
            // grpLevel3
            // 
            this.grpLevel3.Controls.Add(this.lstLevel3);
            this.grpLevel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLevel3.Location = new System.Drawing.Point(0, 0);
            this.grpLevel3.Name = "grpLevel3";
            this.grpLevel3.Padding = new System.Windows.Forms.Padding(6);
            this.grpLevel3.Size = new System.Drawing.Size(194, 214);
            this.grpLevel3.TabIndex = 0;
            this.grpLevel3.TabStop = false;
            this.grpLevel3.Text = "Level 3";
            // 
            // lstLevel3
            // 
            this.lstLevel3.CheckOnClick = true;
            this.lstLevel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLevel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstLevel3.FormattingEnabled = true;
            this.lstLevel3.Location = new System.Drawing.Point(6, 20);
            this.lstLevel3.Name = "lstLevel3";
            this.lstLevel3.Size = new System.Drawing.Size(182, 188);
            this.lstLevel3.TabIndex = 3;
            this.lstLevel3.Tag = "DelayReason3";
            this.lstLevel3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLevel_ItemCheck);
            // 
            // pnlLevel2
            // 
            this.pnlLevel2.Controls.Add(this.grpLevel2);
            this.pnlLevel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLevel2.Location = new System.Drawing.Point(206, 20);
            this.pnlLevel2.Name = "pnlLevel2";
            this.pnlLevel2.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlLevel2.Size = new System.Drawing.Size(200, 214);
            this.pnlLevel2.TabIndex = 1;
            // 
            // grpLevel2
            // 
            this.grpLevel2.Controls.Add(this.lstLevel2);
            this.grpLevel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLevel2.Location = new System.Drawing.Point(0, 0);
            this.grpLevel2.Name = "grpLevel2";
            this.grpLevel2.Padding = new System.Windows.Forms.Padding(6);
            this.grpLevel2.Size = new System.Drawing.Size(194, 214);
            this.grpLevel2.TabIndex = 1;
            this.grpLevel2.TabStop = false;
            this.grpLevel2.Text = "Level 2";
            // 
            // lstLevel2
            // 
            this.lstLevel2.CheckOnClick = true;
            this.lstLevel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLevel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstLevel2.FormattingEnabled = true;
            this.lstLevel2.Location = new System.Drawing.Point(6, 20);
            this.lstLevel2.Name = "lstLevel2";
            this.lstLevel2.Size = new System.Drawing.Size(182, 188);
            this.lstLevel2.TabIndex = 2;
            this.lstLevel2.Tag = "DelayReason2";
            this.lstLevel2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLevel_ItemCheck);
            // 
            // pnlLevel1
            // 
            this.pnlLevel1.Controls.Add(this.grpLevel1);
            this.pnlLevel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLevel1.Location = new System.Drawing.Point(6, 20);
            this.pnlLevel1.Name = "pnlLevel1";
            this.pnlLevel1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlLevel1.Size = new System.Drawing.Size(200, 214);
            this.pnlLevel1.TabIndex = 0;
            // 
            // grpLevel1
            // 
            this.grpLevel1.Controls.Add(this.lstLevel1);
            this.grpLevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLevel1.Location = new System.Drawing.Point(0, 0);
            this.grpLevel1.Name = "grpLevel1";
            this.grpLevel1.Padding = new System.Windows.Forms.Padding(6);
            this.grpLevel1.Size = new System.Drawing.Size(194, 214);
            this.grpLevel1.TabIndex = 0;
            this.grpLevel1.TabStop = false;
            this.grpLevel1.Text = "Level 1";
            // 
            // lstLevel1
            // 
            this.lstLevel1.CheckOnClick = true;
            this.lstLevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLevel1.FormattingEnabled = true;
            this.lstLevel1.Location = new System.Drawing.Point(6, 20);
            this.lstLevel1.Name = "lstLevel1";
            this.lstLevel1.Size = new System.Drawing.Size(182, 188);
            this.lstLevel1.TabIndex = 1;
            this.lstLevel1.Tag = "DelayReason1";
            this.lstLevel1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLevel_ItemCheck);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlReasons);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(819, 394);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlReasons
            // 
            this.pnlReasons.Controls.Add(this.grpReasons);
            this.pnlReasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReasons.Location = new System.Drawing.Point(6, 6);
            this.pnlReasons.Name = "pnlReasons";
            this.pnlReasons.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlReasons.Size = new System.Drawing.Size(807, 243);
            this.pnlReasons.TabIndex = 3;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.grpInfo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(6, 249);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlInfo.Size = new System.Drawing.Size(807, 139);
            this.pnlInfo.TabIndex = 4;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtCategory);
            this.grpInfo.Controls.Add(this.txtClass);
            this.grpInfo.Controls.Add(this.txtDiscipline);
            this.grpInfo.Controls.Add(this.lblMax);
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.txtComments);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.numMins);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(0, 3);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(807, 136);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Info";
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.SystemColors.Window;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(64, 110);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(117, 20);
            this.txtCategory.TabIndex = 34;
            // 
            // txtClass
            // 
            this.txtClass.BackColor = System.Drawing.SystemColors.Window;
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(64, 84);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(117, 20);
            this.txtClass.TabIndex = 33;
            // 
            // txtDiscipline
            // 
            this.txtDiscipline.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiscipline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscipline.Location = new System.Drawing.Point(64, 58);
            this.txtDiscipline.Name = "txtDiscipline";
            this.txtDiscipline.ReadOnly = true;
            this.txtDiscipline.Size = new System.Drawing.Size(117, 20);
            this.txtDiscipline.TabIndex = 32;
            // 
            // lblMax
            // 
            this.lblMax.BackColor = System.Drawing.Color.Red;
            this.lblMax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.ForeColor = System.Drawing.Color.White;
            this.lblMax.Location = new System.Drawing.Point(117, 32);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(64, 20);
            this.lblMax.TabIndex = 10;
            this.lblMax.Text = "Max - ";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMax.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Category";
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(187, 32);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(614, 98);
            this.txtComments.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(187, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Comments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Discipline";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mins";
            // 
            // numMins
            // 
            this.numMins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMins.Location = new System.Drawing.Point(64, 32);
            this.numMins.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMins.Name = "numMins";
            this.numMins.Size = new System.Drawing.Size(47, 20);
            this.numMins.TabIndex = 5;
            this.numMins.ValueChanged += new System.EventHandler(this.Ctrl_ValueChanged);
            this.numMins.Click += new System.EventHandler(this.Ctrl_ValueChanged);
            this.numMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numMins_KeyPress);
            // 
            // DelayPopup
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(819, 428);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DelayPopup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Delay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DelayPopup_FormClosing);
            this.Load += new System.EventHandler(this.DelayPopup_Load);
            this.pnlButtons.ResumeLayout(false);
            this.grpReasons.ResumeLayout(false);
            this.pnlLevel4.ResumeLayout(false);
            this.grpLevel4.ResumeLayout(false);
            this.pnlLevel3.ResumeLayout(false);
            this.grpLevel3.ResumeLayout(false);
            this.pnlLevel2.ResumeLayout(false);
            this.grpLevel2.ResumeLayout(false);
            this.pnlLevel1.ResumeLayout(false);
            this.grpLevel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlReasons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteDelay;
        private System.Windows.Forms.GroupBox grpReasons;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlReasons;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Panel pnlLevel1;
        private System.Windows.Forms.Panel pnlLevel2;
        private System.Windows.Forms.GroupBox grpLevel1;
        private System.Windows.Forms.Panel pnlLevel3;
        private System.Windows.Forms.GroupBox grpLevel3;
        private System.Windows.Forms.GroupBox grpLevel2;
        private System.Windows.Forms.CheckedListBox lstLevel2;
        private System.Windows.Forms.CheckedListBox lstLevel1;
        private System.Windows.Forms.NumericUpDown numMins;
        private System.Windows.Forms.CheckedListBox lstLevel3;
        private System.Windows.Forms.Panel pnlLevel4;
        private System.Windows.Forms.GroupBox grpLevel4;
        private System.Windows.Forms.CheckedListBox lstLevel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDRF;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtDiscipline;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}