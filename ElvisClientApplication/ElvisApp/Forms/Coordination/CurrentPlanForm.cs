using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Coordination
{
    public partial class CurrentPlanForm : Form
    {
        private List<CoordLink> coordLinkRows = new List<CoordLink>();
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public CurrentPlanForm()
        {
            InitializeComponent();
            dgvSchedule.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
            dgvSchedule.AutoGenerateColumns = false;
            lblScheduleUpdate.Text = string.Empty;

            // Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateGrid(coordLinkRows);
        }

        /// <summary>
        /// Load the latest plan from the database, and display in the grid.
        /// </summary>
        private void LoadData()
        {
            coordLinkRows = new List<CoordLink>();

            try
            {
                coordLinkRows = EntityHelper.CoordLink.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GETTING COORD LINK VIEW -- LoadData() -- CurrentPlanForm -- ",
                    ex);
            }
        }

        /// <summary>
        /// Async or Sync update of the grid (cross thread if required)
        /// </summary>
        /// <param name="coordLinkRows"></param>
        private void UpdateGrid(List<CoordLink> plan)
        {
            try
            {
                if (this.dgvSchedule.InvokeRequired)
                {
                    this.dgvSchedule.BeginInvoke((MethodInvoker)delegate()
                    {
                        UpdateGridview(plan);
                    });
                }
                else
                {
                    UpdateGridview(plan);
                }
            }
            catch
            {
                // This can throw if the user cancels the Window display before the thread as
                // called back. 
                // We can quietly ignore this. 
            }
        }

        private void UpdateGridview(List<CoordLink> plan)
        {
            dgvSchedule.Rows.Clear();
            dgvSchedule.DataSource = plan;
            dgvSchedule.Select();

            if (plan != null && plan.Count > 0)
            {
                lblScheduleUpdate.Text = string.Format(
                    "Plan Last Updated - {0}",
                    Model.MainForm.PlanPublishTime.ToString("dd MMM HH:mm")
                    );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Remove the column header border in the Aero theme in Vista,
        /// but keep it for other themes such as standard and classic.
        /// </summary>
        static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle
        {
            get
            {
                return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
                DataGridViewHeaderBorderStyle.None :
                DataGridViewHeaderBorderStyle.Raised;
            }
        }

        private void CurrentPlanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
        }

        #region Print
        private void menuPrint_Click(object sender, EventArgs e)
        {
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();

            pDialog.Document = printDocument1;
            // Display the dialog. This returns true if the user presses the Print button.
            DialogResult print = pDialog.ShowDialog();
            if (print == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Title
            e.Graphics.DrawString(
                "BOS Plant - Current Schedule Screenshot - " + DateTime.Now.ToString("dd MMM yyyy HH:mm"),
                new Font("Arial", 16),
                SystemBrushes.WindowText, 25, 20);

            Bitmap bm = new Bitmap(dgvSchedule.Width, dgvSchedule.Height);
            dgvSchedule.DrawToBitmap(bm, new Rectangle(0, 0, dgvSchedule.Width, dgvSchedule.Height));
            e.Graphics.DrawImage(bm, 15, 65);
        }

        private void menuPrintPreview_Click(object sender, EventArgs e)
        {
            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Visible = false;
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        #endregion
    }
}
