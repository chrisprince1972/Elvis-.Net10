using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;

namespace Elvis.Forms.General
{
    public partial class ErrorBox : Form
    {
        private string userInfo = "";

        public string UserInfo
        {
            get { return this.userInfo; }
        }

        public ErrorBox()
        {
            InitializeComponent();
        }

        private void ErrorBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.userInfo = txtUserInfo.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
