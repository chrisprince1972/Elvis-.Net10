using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System.ComponentModel;

namespace Elvis.Forms.Users
{
    public partial class EditUserForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User User { get; set; }
        private List<Role> Roles { get; set; }
        private FormOpenMode FormOpenMode { get; set; }
        private SecuritySchemaEntities _context;

        public EditUserForm(User user, FormOpenMode formOpenMode)
        {
            InitializeComponent();
            CustomiseColours();

            _context = new SecuritySchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString);
            FormOpenMode = formOpenMode;

            if (FormOpenMode == FormOpenMode.AddMode)
            {
                Text = "Add a New User";
                User = user;
            }
            else
            {
                Text = "Edit a User";
                User = _context.Users.Single(u => u.UserID == user.UserID);
            }
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            if (User != null)
            {
                userNameTextBox.DataBindings.Add(new Binding("Text", User, "Username"));
                fullnameTextBox.DataBindings.Add(new Binding("Text", User, "Fullname"));
            }

            Roles = _context.Roles.ToList();

            Roles.ForEach(role =>
                {
                    ListViewItem lvi = new ListViewItem(role.RoleName);
                    lvi.Tag = role;
                    lvi.SubItems.Add(role.Description);

                    if (User.Roles.FirstOrDefault(ur => ur.RoleName == role.RoleName) != null)
                    {
                        lvi.Checked = true;
                    }
                    rolesListView.Items.Add(lvi);
                });
        }

        private void ConfigureUserRoles()
        {
            try
            {
                foreach (ListViewItem item in rolesListView.Items)
                {
                    if (item.Checked)
                    {
                        var role = User.Roles.SingleOrDefault(r => r.RoleName == item.Text);
                        if (role == null)
                        {
                            User.Roles.Add((Role)item.Tag);
                        }
                    }
                    else
                    {
                        var roleID = ((Role)item.Tag).RoleID;
                        var roles = User.Roles.Where(r => r.RoleID == roleID);

                        if (roles.Count() > 0)
                        {
                            Role roleToRemove = User.Roles.SingleOrDefault(r => r == roles.First());
                            User.Roles.Remove(roleToRemove);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Configuring User Roles -- ", ex);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ConfigureUserRoles();
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Saving User Details -- ", ex);
            }
        }

        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                grpUserDetails.BackColor =
                Settings.Default.ColourBackground;
            this.ForeColor =
                pnlMain.ForeColor =
                grpUserDetails.ForeColor =
                Settings.Default.ColourText;
        }
    }
}
