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
    public partial class ReportAddEditComment : Form
    {
        #region Variables
        private string reportNo;
        private string commentID;
        #endregion

        #region Constructor
        public ReportAddEditComment(string reportNo, string commentID)
        {
            InitializeComponent();
            this.reportNo = reportNo;
            this.commentID = commentID;
            SetupForm();
        }
        #endregion

        private void SetupForm()
        {
            PopulateHeader();
            if (string.IsNullOrEmpty(commentID))//Add Comments
            {
                this.Text = "Add Comments";
            }
            else //Edit comments
            {
                this.Text = "Edit Comments";
                PopulateBody();
            }
        }

        #region Get Data
        private void PopulateHeader()
        {
            
        }
        private void PopulateBody()
        {
            
        }
        #endregion

        #region Button Click Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormControl.ConfirmCloseForm(this);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Text.Contains("Edit"))
            {
                //Edit Existing Record
            }
            else
            {
                //Save New Record
            }
        }
        #endregion
    }
}
