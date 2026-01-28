using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Trending
{
    public partial class SlabStockSummary : Form
    {
        private bool hasErrors = false;
        private bool setDate = false;
        private DateTime dateForForm;
        private DateTimePicker picker;
        private List<SlabStock> slabStock = new List<SlabStock>();
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creats a new instance of the RFT Summary Form
        /// </summary>
        public SlabStockSummary()
        {
            InitializeComponent();
            this.dateForForm = new DateTime();

            dgvSlabStock1.AutoGenerateColumns =
                dgvSlabStock2.AutoGenerateColumns =
                dgvSlabStock3.AutoGenerateColumns = false;

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
                pnlSlabStock1.BackColor =
                pnlSlabStock2.BackColor =
                pnlSlabStock3.BackColor =
                grpSlabStock.BackColor =
                dgvSlabStock1.BackgroundColor =
                dgvSlabStock2.BackgroundColor =
                dgvSlabStock3.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlFooter.ForeColor =
                pnlSlabStock1.ForeColor =
                pnlSlabStock2.ForeColor =
                pnlSlabStock3.ForeColor =
                grpSlabStock.ForeColor =
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
                    MyDateTime.Now.Year,
                    MyDateTime.Now.Month,
                    MyDateTime.Now.Day,
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
        private void ShowGridviews()
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(grpSlabStock);
            grpSlabStock.Dock = DockStyle.Fill;
            grpSlabStock.BringToFront();
            grpSlabStock.Refresh();
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, pnlMain);
        }

        /// <summary>
        /// Load the SlabStock from the database, and display in the grids.
        /// </summary>
        private void GetData()
        {
            this.slabStock = new List<SlabStock>();

            try
            {
                this.slabStock = EntityHelper.SlabStocks.GetByDate(this.picker.Value);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Getting SlabStocks Data from database -- GetData() -- SlabStockSummary.cs -- ",
                    ex);
            }
        }

        /// <summary>
        /// Bind the Data Gridviews on the form.
        /// </summary>
        private void BindGridviews()
        {
            dgvSlabStock1.DataSource =
                dgvSlabStock2.DataSource =
                dgvSlabStock3.DataSource = null;

            if (this.slabStock != null)
            {
                dgvSlabStock1.DataSource =
                    dgvSlabStock2.DataSource =
                    dgvSlabStock3.DataSource = this.slabStock;
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
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// The run worker completed event handler for the background worker.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.hasErrors)
            {
                ShowErrorForm();
            }
            else
            {
                BindGridviews();
                ShowGridviews();
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

        /// <summary>
        /// Load event for the Form.
        /// </summary>
        private void SlabStockSummary_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Data Binding Complete event handler for the
        /// Datagridviews. Clears the selection.
        /// </summary>
        private void dgvSlabStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;
                dgv.ClearSelection();
            }
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
                "Elvis - SlabStocks Summary Screenshot - {0}",
                picker.Value.ToString("dd MMMM yyyy")),
                headerFont, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);

            //Print Body Content.
            Bitmap bm1 = new Bitmap(dgvSlabStock1.Width, dgvSlabStock1.Height);
            dgvSlabStock1.DrawToBitmap(bm1, new Rectangle(0, 0, dgvSlabStock1.Width, dgvSlabStock1.Height));

            //Print Body Content.
            Bitmap bm2 = new Bitmap(dgvSlabStock2.Width, dgvSlabStock2.Height);
            dgvSlabStock2.DrawToBitmap(bm2, new Rectangle(0, 0, dgvSlabStock2.Width, dgvSlabStock2.Height));

            //Print Body Content.
            Bitmap bm3 = new Bitmap(dgvSlabStock3.Width, dgvSlabStock3.Height);
            dgvSlabStock3.DrawToBitmap(bm3, new Rectangle(0, 0, dgvSlabStock3.Width, dgvSlabStock3.Height));

            Rectangle rect1 = HelperFunctions.ResizeAndMaintainAspectRatio(e.MarginBounds, bm1);
            Rectangle rect2 = HelperFunctions.ResizeAndMaintainAspectRatio(e.MarginBounds, bm2);
            Rectangle rect3 = HelperFunctions.ResizeAndMaintainAspectRatio(e.MarginBounds, bm3);

            rect1.Y += 50;//move it down pixels to make room for header.
            rect2.Y += rect1.Y + rect1.Height - 70;
            rect3.Y += rect2.Y + rect2.Height - 70;
            e.Graphics.DrawImage(bm1, rect1);
            e.Graphics.DrawImage(bm2, rect2);
            e.Graphics.DrawImage(bm3, rect3);

            //Print Footer Onto Page. Not showing up for some reason!
            e.Graphics.DrawString(MyDateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                dateFont, Brushes.Black,
                e.PageSettings.PrintableArea.Width - e.MarginBounds.X - 60,
                e.PageSettings.PrintableArea.Height - e.MarginBounds.Y + 30);
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

        #endregion Print
    }
}