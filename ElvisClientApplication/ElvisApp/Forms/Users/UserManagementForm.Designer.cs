namespace Elvis.Forms.Users
{
    partial class UserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            this.pnlClose = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpUsers = new System.Windows.Forms.GroupBox();
            this.lstUsers = new System.Windows.Forms.Panel();
            this.usersListView = new System.Windows.Forms.ListView();
            this.usersColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlButtonControls = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlClose.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpUsers.SuspendLayout();
            this.lstUsers.SuspendLayout();
            this.pnlButtonControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.btnClose);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClose.Location = new System.Drawing.Point(0, 482);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlClose.Size = new System.Drawing.Size(407, 29);
            this.pnlClose.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(326, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpUsers);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(407, 482);
            this.pnlMain.TabIndex = 2;
            // 
            // grpUsers
            // 
            this.grpUsers.Controls.Add(this.lstUsers);
            this.grpUsers.Controls.Add(this.pnlButtonControls);
            this.grpUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUsers.Location = new System.Drawing.Point(6, 6);
            this.grpUsers.Name = "grpUsers";
            this.grpUsers.Padding = new System.Windows.Forms.Padding(6);
            this.grpUsers.Size = new System.Drawing.Size(395, 470);
            this.grpUsers.TabIndex = 0;
            this.grpUsers.TabStop = false;
            this.grpUsers.Text = "Users";
            // 
            // lstUsers
            // 
            this.lstUsers.Controls.Add(this.usersListView);
            this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsers.Location = new System.Drawing.Point(6, 51);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(383, 413);
            this.lstUsers.TabIndex = 1;
            // 
            // usersListView
            // 
            this.usersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.usersColumnHeader,
            this.nameColumnHeader});
            this.usersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersListView.FullRowSelect = true;
            this.usersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.usersListView.Location = new System.Drawing.Point(0, 0);
            this.usersListView.MultiSelect = false;
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(383, 413);
            this.usersListView.TabIndex = 0;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.Details;
            this.usersListView.DoubleClick += new System.EventHandler(this.usersListView_DoubleClick);
            this.usersListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usersListView_KeyDown);
            // 
            // usersColumnHeader
            // 
            this.usersColumnHeader.Text = "Username";
            this.usersColumnHeader.Width = 212;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Full Name";
            this.nameColumnHeader.Width = 151;
            // 
            // pnlButtonControls
            // 
            this.pnlButtonControls.Controls.Add(this.btnDelete);
            this.pnlButtonControls.Controls.Add(this.btnEdit);
            this.pnlButtonControls.Controls.Add(this.btnAdd);
            this.pnlButtonControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonControls.Location = new System.Drawing.Point(6, 19);
            this.pnlButtonControls.Name = "pnlButtonControls";
            this.pnlButtonControls.Size = new System.Drawing.Size(383, 32);
            this.pnlButtonControls.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Location = new System.Drawing.Point(305, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEdit.Location = new System.Drawing.Point(224, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.usersListView_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(143, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.addButton_Click);
            // 
            // UserManagementForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(407, 511);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagementForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            this.pnlClose.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.grpUsers.ResumeLayout(false);
            this.lstUsers.ResumeLayout(false);
            this.pnlButtonControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpUsers;
        private System.Windows.Forms.Panel lstUsers;
        private System.Windows.Forms.Panel pnlButtonControls;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.ColumnHeader usersColumnHeader;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
    }
}