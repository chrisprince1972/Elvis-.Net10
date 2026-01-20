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
    public partial class ReportCommentSelection : Form
    {
        #region Attribtues
        private string reportNo;
        private string selectedCommentID;
        #endregion

        #region Constructor
        public ReportCommentSelection(string reportNo)
        {
            InitializeComponent();
            this.reportNo = reportNo;
            this.Text += reportNo;
            GetComments();
            BindListView();
        }
        #endregion

        private void BindListView()
        {
            this.selectedCommentID = "TESTCOMMENTID";//Remove this once we get actual Data
        }

        private void GetComments()
        {

        }

        #region Button Click Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedCommentID))
            {
                ReportAddEditComment editComments = new ReportAddEditComment(reportNo, selectedCommentID);
                editComments.ShowDialog();
            }
        }
        #endregion

        private void lvComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the comment ID from the listview
        }
    }
}
