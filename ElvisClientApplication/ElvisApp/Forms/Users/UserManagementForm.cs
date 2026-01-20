using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Users
{
    public partial class UserManagementForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private List<User> Users { get; set; }

        public UserManagementForm()
        {
            InitializeComponent();
            CustomiseColours();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // Loads the full list of named Elvis users.
        private void LoadUsers()
        {
            try
            {
                Users = EntityHelper.Users.GetAllUsers();
                usersListView.Items.Clear();

                foreach (var user in Users)
                {
                    ListViewItem lvi = new ListViewItem
                    {
                        Text = user.Username,
                        Tag = user
                    };

                    lvi.SubItems.Add(user.Fullname);
                    usersListView.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading user list -- ", ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usersListView_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }
        
        private void usersListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditUser();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems.Count <= 0) return;

            if (usersListView.SelectedItems[0].Tag is User)
            {
                User user = usersListView.SelectedItems[0].Tag as User;
                if (user != null)
                {
                    DialogResult result = MessageBox.Show(this,
                        String.Format("Are you sure you want to delete user: {0}?", user.Username),
                        "Confirm Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool isDeleted = SecurityLayer.DeleteUser(user);
                        if (isDeleted)
                        {
                            LoadUsers();
                        }
                    }
                }
            }
        }

        private void EditUser()
        {
            if (usersListView.SelectedItems.Count <= 0) return;

            if (usersListView.SelectedItems[0].Tag is User)
            {
                User user = usersListView.SelectedItems[0].Tag as User;
                if (user != null)
                {
                    using (var form = new EditUserForm(user, FormOpenMode.EditMode))
                    {
                        DialogResult result = form.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            LoadUsers();
                        }
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newUserName = String.Empty;

            // Get the new username from the Admin user.
            using (var form = new AddUserForm())
            {
                DialogResult result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    newUserName = form.Username;
                }
            }

            if (!String.IsNullOrEmpty(newUserName))
            {
                User user = EntityHelper.Users.GetUserByName(newUserName);

                if (user != null)
                {
                    string message = String.Format(
                        "User {0} already exists. If you want to edit them, select the name in the list and click Edit",
                        user.Username);
                    MessageBox.Show(this, message, "User Already Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    user = new User { Username = newUserName };

                    using (var form = new EditUserForm(user, FormOpenMode.AddMode))
                    {
                        DialogResult result = form.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            LoadUsers();
                        }
                    }
                }
            }
        }

        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlClose.BackColor = 
                grpUsers.BackColor =
                Settings.Default.ColourBackground;
            this.ForeColor =
                pnlMain.ForeColor =
                pnlClose.ForeColor = 
                grpUsers.ForeColor =
                Settings.Default.ColourText;
        }
    }
}
