using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;

namespace Elvis.Forms.Users
{
    public partial class AddUserForm : Form
    {
        /// <summary>
        /// The username entered or selected.
        /// </summary>
        public string Username
        {
            get { return usernameComboBox.Text; }
        }

        public AddUserForm()
        {
            InitializeComponent();
            CustomiseColours();
        }

        private void usernameComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnOK.PerformClick();
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            List<string> logins = SecurityLayer.GetPreviousLoginNames();

            usernameComboBox.DataSource = logins;
            usernameComboBox.SelectedItem = null;
        }

        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                grpUser.BackColor =
                Settings.Default.ColourBackground;
            this.ForeColor =
                pnlMain.ForeColor =
                grpUser.ForeColor =
                Settings.Default.ColourText;
        }
    }
}
