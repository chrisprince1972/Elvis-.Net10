using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;

namespace Elvis.Forms
{
    public partial class ReportEditCost : Form
    {
        #region Variables
        private string reportNo;
        #endregion

        #region Constructor
        public ReportEditCost(string reportNo)
        {
            InitializeComponent();
            this.reportNo = reportNo;
            this.Text += reportNo;
        }
        #endregion

        #region Button Click Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormControl.ConfirmCloseForm(this);
        }
        #endregion
    }
}
