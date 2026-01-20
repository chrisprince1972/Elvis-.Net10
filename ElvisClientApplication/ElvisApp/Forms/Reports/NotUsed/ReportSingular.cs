using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Elvis.UserControls;
using System.ComponentModel;


namespace Elvis.Forms
{
    public partial class ReportSingular : Form
    {
        #region Variables
        private string reportNo;
        #endregion

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReportStatusIsDirty { get; set; }
        #endregion

        #region Constructor
        public ReportSingular(string reportNo)
        {
            InitializeComponent();
            this.Text += reportNo;
            this.reportNo = reportNo;
        }
        #endregion

        #region Tool Strip Menu Events
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Populate Tabs
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
            {
                case "Comments":
                    //GetComments
                    break;
                case "Images":
                    //GetImages
                    break;
                case "Links":
                    //GetLinks
                    btnOpenLink.Enabled = false;
                    btnRemoveLink.Enabled = false;
                    break;
                case "Report Status":
                    PopulateReportStatus();
                    ReportStatusIsDirty = false;
                    break;
                case "Cost":
                    //GetCostData
                    break;
                default:
                    break;
            }
        }
        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "Report Status" && ReportStatusIsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "Warning! Unsaved changes will be lost. Continue?",
                    "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void PopulateReportStatus()
        {
            //TO DO: Need to get list of areas and use foreach loop to add user controls
            //Foreach report area add a user control
            //Just doing this as an example for now.
            int topPosition = 65;
            List<string> areas = new List<string> { "Test Area", "Test Area 2", "Test Area 3", "Test Area 4" };
            foreach (string area in areas)
            {
                ReportStatus usrReportStatus = new ReportStatus(reportNo, area);
                tabReportStatus.Controls.Add(usrReportStatus);
                usrReportStatus.Left = 20;
                usrReportStatus.Top = topPosition;
                usrReportStatus.BringToFront();
                topPosition += 30;
            }
            btnSaveReportStatus.Left = 220;
            btnSaveReportStatus.Top = topPosition + 10;
        }
        #endregion

        #region Events

        #region Button Click Events
        private void AddComments_Click(object sender, EventArgs e)
        {
            ReportAddEditComment addComment = new ReportAddEditComment("Add", "");
            addComment.ShowDialog();
        }

        private void EditComments_Click(object sender, EventArgs e)
        {
            ReportCommentSelection selectCommentForEdit = new ReportCommentSelection(reportNo);
            selectCommentForEdit.ShowDialog();
        }

        private void btnEditCost_Click(object sender, EventArgs e)
        {
            ReportEditCost editCost = new ReportEditCost(reportNo);
            editCost.ShowDialog();
        }
        private void btnSaveReportStatus_Click(object sender, EventArgs e)
        {
            //Save all of the report status' off to database
            //if save is success{
            ReportStatusIsDirty = false;
            //}
            //else ERROR
        }
        #endregion

        private void lbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveImage.Enabled = false;
            btnImageDetails.Enabled = false;
            if (lbImages.SelectedIndex >= 0)
            {
                btnRemoveImage.Enabled = true;
                btnImageDetails.Enabled = true;
            }
        }

        private void lvLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpenLink.Enabled = false;
            btnRemoveLink.Enabled = false;
            if (lvLinks.SelectedIndices[0] >= 0)
            {
                btnOpenLink.Enabled = true;
                btnRemoveLink.Enabled = true;
            }
        }

        //Stop Form from Closing if changes have been made.
        private void ReportSingular_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReportStatusIsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "Warning! Unsaved changes will be lost. Continue?",
                    "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            DialogResult result = fileDialogDocument.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (fileDialogDocument.FileName.Length <= 50)
                {
                    FileStream fs = new FileStream(
                        fileDialogDocument.FileName, FileMode.Open, FileAccess.Read);

                    long length = fs.Length;
                    if (length > 0)
                    {
                        //string contentType = GetContentType(fileDialogDocument.FileName);
                        //NOT FINISHED
                    }
                }
                else
                {
                    //error filename must be less than 50 characters
                }
            }
        }

        //DO NOT NEED CONTENT TYPE (MAYBE)
        //Ignore this for now, I was testing saving off documents, we may need for future
        ///// <summary>
        ///// Using the registry this method locates the content type of a file.
        ///// This can then be stored in the database for future use when opening the file.
        ///// </summary>
        ///// <param name="filepath">The full path to the file in question.</param>
        ///// <returns>The Content Type of that file i.e. application\msword as a string</returns>
        //public string GetContentType(string filepath)
        //{
        //    try
        //    {
        //        RegistryPermission regPerm = new RegistryPermission(RegistryPermissionAccess.Read, "\\\\HKEY_CLASSES_ROOT");
        //        RegistryKey classesRoot = Registry.ClassesRoot;
        //        FileInfo fi = new FileInfo(filepath);
        //        RegistryKey typeKey = classesRoot.OpenSubKey("MIME\\Database\\Content Type");

        //        string dotExt = fi.Extension.ToLower();

        //        foreach (string keyname in typeKey.GetSubKeyNames())
        //        {
        //            RegistryKey curKey = classesRoot.OpenSubKey("MIME\\Database\\Content Type\\" + keyname);

        //            var ext = curKey.GetValue("Extension");
        //            if (ext != null)
        //            {
        //                if (ext.ToString().ToLower() == dotExt)
        //                {
        //                    return keyname;//Content Type
        //                }
        //            }
        //        }
        //    }
        //    catch { }
        //    return "ERROR";
        //}

        private void DownloadDocument(string name, string contentType, Byte[] data)
        {
            //this could be tricky
            //Save it onto disk and then open it using Process.something or other
        }
    }
}
