using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using NLog;

namespace Elvis.Forms.TrendingShifts
{
    public partial class RFTSummary : Form
    {
        private bool hasErrors = false;
        private bool setDate = false;
        private DateTime dateForForm;
        private DateTimePicker picker;
        private List<RFTRecord> rftRecords = new List<RFTRecord>();
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creats a new instance of the RFT Summary Form
        /// </summary>
        public RFTSummary()
        {
            InitializeComponent();
            this.dateForForm = new DateTime();
            dgvRFTSummary.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
            dgvRFTSummary.AutoGenerateColumns = false;
            printDocument1.DefaultPageSettings.Landscape = true;
            SetupBackgroundWorker();
            AddDateTimePickerToToolbar();
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor = 
                pnlFooter.BackColor = 
                grpRFT.BackColor = 
                dgvRFTSummary.BackgroundColor = 
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlFooter.ForeColor = 
                grpRFT.ForeColor = 
                    Settings.Default.ColourText;
        }


        /// <summary>
        /// Sets up the form to open at a specific date.
        /// </summary>
        /// <param name="dateForForm">The date you wish to view.</param>
        public void SetupForm(DateTime dateForForm)
        {
            this.dateForForm = dateForForm;
            this.setDate = true;
            SetDatePicker();
        }

        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Datetime picker must be added to toolbar in code 
        /// (cannot be done through designer).
        /// </summary>
        private void AddDateTimePickerToToolbar()
        {
            picker = new DateTimePicker();
            picker.Width = 90;
            picker.Format = DateTimePickerFormat.Short;
            toolStripTimeControls.Items.Insert(2, new ToolStripControlHost(picker));
        }

        /// <summary>
        /// Sets the value and the MaxDate values of the 
        /// Date Time Picker to a default value depending on 
        /// any parameters passed in.
        /// </summary>
        private void SetDatePicker()
        {
            if (picker != null)
            {
                picker.MaxDate = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    0, 0, 0, 0);
                picker.MaxDate = picker.MaxDate.AddDays(-1);

                if (this.setDate && this.dateForForm != null &&
                    this.dateForForm <= picker.MaxDate)
                {
                    picker.Value = this.dateForForm;//Date passed in so use it.
                }
                else
                {
                    picker.Value = picker.MaxDate;//Default to yesterday shift.
                }
            }
        }

        /// <summary>
        /// Method that shows the Loading Box on the 
        /// screen for the user.
        /// </summary>
        private void ShowLoading()
        {
            this.Cursor = Cursors.AppStarting;
            CommonMethods.LoadImageIntoPanel(Resources.loading, pnlMain);
        }

        /// <summary>
        /// Clear any controls and show the gridview
        /// on the form.
        /// </summary>
        private void ShowGridview()
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(grpRFT);
            grpRFT.Dock = DockStyle.Fill;
            grpRFT.BringToFront();
            grpRFT.Refresh();
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, pnlMain);
        }

        /// <summary>
        /// Load the latest plan from the database, and display in the grid.
        /// </summary>
        private void GetData()
        {
            this.rftRecords = new List<RFTRecord>();

            try
            {
                this.rftRecords = Model.RFTData.GetRFTRecords(this.picker.Value);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Getting RFT Data from model/database -- GetData() -- RFTSummary.cs -- ",
                    ex);
            }
        }

        /// <summary>
        /// Bind the Data Gridview on the form.
        /// </summary>
        private void BindGridview()
        {
            dgvRFTSummary.DataSource = null;
            if (this.rftRecords != null &&
                this.rftRecords.Count > 0)
            {
                dgvRFTSummary.DataSource = this.rftRecords;
            }
        }

        /// <summary>
        /// Select Specific day using the date picker
        /// </summary>
        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            toolStripForward.Enabled = false;
            if (picker != null &&
                picker.Value < picker.MaxDate)
            {//Enable the forward button
                toolStripForward.Enabled = true;
            }

            ShowLoading();

            if (!worker.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                worker.RunWorkerAsync();
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// The do work event handler for the background worker.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// The run worker completed event handler for the background worker.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.hasErrors)
            {
                ShowErrorForm();
            }
            else
            {
                BindGridview();
                ShowGridview();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Button close click event handler.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Back button event handler.
        /// </summary>
        private void toolStripBack_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (picker.Value.AddDays(-1) >= picker.MinDate)
            {//Decrease the date on the picker.
                picker.Value = picker.Value.AddDays(-1);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Forward button event handler.
        /// </summary>
        private void toolStripForward_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (picker.Value.AddDays(1) <= picker.MaxDate)
            {//Increase the date on the picker.
                picker.Value = picker.Value.AddDays(1);
            }
            this.Cursor = Cursors.Default;
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

        /// <summary>
        /// Last Day button event handler.
        /// </summary>
        private void toolStripLastDay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            picker.Value = picker.MaxDate;//Default to yesterday shift.
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Enabled changed event handler for the Forward navigation button.
        /// </summary>
        private void toolStripForward_EnabledChanged(object sender, EventArgs e)
        {
            fowardToolStripMenuItem.Enabled = toolStripForward.Enabled;
        }

        #region Print
        /// <summary>
        /// Prints out the Charts Generated.
        /// </summary>
        private void printCharts_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Font setup for the pages.
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font dateFont = new Font("Arial", 100);

            //Print Header Onto Page.
            e.Graphics.DrawString(string.Format(
                "Elvis - RFT Summary Screenshot - {0}",
                picker.Value.ToString("dd MMMM yyyy")),
                headerFont, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);

            //Print Body Content.
            Bitmap bm = new Bitmap(dgvRFTSummary.Width, dgvRFTSummary.Height);
            dgvRFTSummary.DrawToBitmap(bm, new Rectangle(0, 0, dgvRFTSummary.Width, dgvRFTSummary.Height));

            Rectangle rect = HelperFunctions.ResizeAndMaintainAspectRatio(e.MarginBounds, bm);
            rect.Y += 30;//move it down pixels to make room for header.
            e.Graphics.DrawImage(bm, rect);

            ////Print Footer Onto Page. Not showing up for some reason!
            //e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
            //    dateFont, Brushes.Black,
            //    e.PageSettings.PrintableArea.Width - e.MarginBounds.X - 60,
            //    e.PageSettings.PrintableArea.Height - e.MarginBounds.Y + 30);
        }

        /// <summary>
        /// Print Event Handler
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        /// <summary>
        /// Print Preview Event Handler
        /// </summary>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        #endregion

        private void RFTSummary_Load(object sender, EventArgs e)
        {
            picker.ValueChanged += new EventHandler(DatePickerValueChanged);

            ShowLoading();

            if (!worker.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                worker.RunWorkerAsync();
            }

            if (picker != null &&
                picker.Value < picker.MaxDate)
            {//Enable the forward button
                toolStripForward.Enabled = true;
            }
        }
    }
}
