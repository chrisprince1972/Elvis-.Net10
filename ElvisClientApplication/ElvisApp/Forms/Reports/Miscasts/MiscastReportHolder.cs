using System;
using System.Windows.Forms;
using Elvis.Forms.Reports.Miscasts.UserControls;
using Elvis.Properties;
using ElvisDataModel;
using Data = ElvisDataModel.EDMX;
using NLog;
using Elvis.Common;
using Microsoft.Reporting.WinForms;

namespace Elvis.Forms.Reports.Miscasts
{
    public partial class MiscastReportHolder : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Data.MiscastMain miscast;
        private MiscastReportNew ucMiscastReport;
        private bool isAdmin;
        private bool showReportViewer = false;

        public MiscastReportHolder(int miscastID, bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.miscast = GetMiscast(miscastID);
        }

        public MiscastReportHolder(int heatNumber, int heatNumberSet, bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.miscast = GetMiscast(heatNumber, heatNumberSet);
        }

        private Data.MiscastMain GetMiscast(int heatNumber, int heatNumberSet)
        {
            try
            {
                return EntityHelper.MiscastMain.GetByHeatNumber(
                    heatNumber,
                    heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Getting miscast by heat for Miscast Report Holder -- GetMiscast()", 
                    ex);
            }
            return null;
        }

        private Data.MiscastMain GetMiscast(int miscastID)
        {
            try
            {
                return EntityHelper.MiscastMain.GetByID(miscastID);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Getting miscast by MiscastID for Miscast Report Holder -- GetMiscast()",
                    ex);
            }
            return null;
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Adds the Miscast report User control to the form.
        /// </summary>
        private void LoadMiscastUC()
        {
            if (this.miscast != null)
            {
                ucMiscastReport = new MiscastReportNew(this.isAdmin);
                ucMiscastReport.SetupUserControl(miscast);
                pnlMain.Controls.Add(ucMiscastReport);
                ucMiscastReport.Dock = DockStyle.Fill;
            }
        }

        private void LoadReportViewer()
        {
            if (this.miscast != null)
            {
                miscastReportViewer.Visible = true;
                pnlMain.Controls.Add(miscastReportViewer);
                miscastReportViewer.Dock = DockStyle.Fill;

                miscastReportViewer.LocalReport.SubreportProcessing +=
                    new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

                if (this.miscast != null)
                {
                    miscastMainBindingSource.DataSource = this.miscast;
                    miscastInvestigationBindingSource.DataSource = this.miscast.MiscastInvestigations;
                    miscastActionBindingSource.DataSource = this.miscast.MiscastActions;
                    miscastWhyBindingSource.DataSource = EntityHelper.MiscastWhy.GetByInvestigationIDs(
                        this.miscast.MiscastInvestigations);

                    miscastReportViewer.RefreshReport();
                }
            }
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("MiscastWhys", miscastWhyBindingSource));
            e.DataSources.Add(new ReportDataSource("MiscastInvestigations", miscastInvestigationBindingSource));
        }

        private void ShowReportViewer(bool show)
        {
            pnlMain.Controls.Clear();
            if (show && this.miscast != null)
            {
                if (ucMiscastReport != null && ucMiscastReport.IsDirty)
                {
                    DialogResult result = MessageBox.Show(
                        "There are unsaved changes on the Miscast Report. Would you like to Save your changes?",
                        "Please Confirm", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        ucMiscastReport.SaveReport();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        this.showReportViewer = false;
                        return;//Skip out as the user has cancelled the operation.
                    }
                }
                this.miscast = GetMiscast(this.miscast.MiscastID);
                LoadReportViewer();
            }
            else if (this.miscast != null)
            {
                this.miscast = GetMiscast(this.miscast.MiscastID);
                LoadMiscastUC();
            }
        }

        /// <summary>
        /// Form load event.
        /// </summary>
        private void MiscastReportHolder_Load(object sender, EventArgs e)
        {
            LoadMiscastUC();
            CustomiseColours();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void MiscastReportHolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MiscastReportHolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.showReportViewer && ucMiscastReport != null && ucMiscastReport.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                    "There are unsaved changes on the Miscast Report. Would you like to Save your changes?",
                    "Please Confirm", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (ucMiscastReport.DataValid)
                    {
                        ucMiscastReport.SaveReport();
                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show(
                            "Failed to save Miscast Report. Please validate your data entry.",
                            "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Swaps out the Miscast User Control for a report viewer and vice versa, 
        /// depending on the selection.
        /// </summary>
        private void reportExportViewToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ShowReportViewer(reportExportViewMenuItem.Checked);
            this.Cursor = Cursors.Default;
        }
    }
}
