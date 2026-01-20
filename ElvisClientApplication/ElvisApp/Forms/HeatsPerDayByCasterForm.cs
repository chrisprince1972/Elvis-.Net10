using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using Elvis.Model;
using Elvis.Model.ViewModels;
using System.ComponentModel;

namespace Elvis.Forms
{
    public partial class HeatsPerDayByCasterForm : Form
    {
        #region Variables
        private Bitmap memoryImage;
        private Boolean pagePrint;
        private HeatsPerDayByCasterViewModel shiftHeatsViewModel;
        private HeatsPerDayByCasterViewModel cumulativeViewModel;
        private HeatsPerDayByCasterViewModel plan24HourViewModel;
        private SteelInMouldViewModel steelInMouldViewModel;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate { get; set; }
        #endregion

        public HeatsPerDayByCasterForm()
            : this(DateTime.Now)
        {
        }

        public HeatsPerDayByCasterForm(DateTime selectedDate)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();

            shiftHeatsPerDay.HeatsDataGridView.DoubleClick += DataGrid_DoubleClick;
            cumulativeShiftsPerDay.HeatsDataGridView.DoubleClick += DataGrid_DoubleClick;
            planningShiftsPerDay.HeatsDataGridView.DoubleClick += new EventHandler(HeatsDataGridView_DoubleClick);

            shiftHeatsPerDay.HeatsDataGridView.KeyDown += DataGrid_KeyDown;
            cumulativeShiftsPerDay.HeatsDataGridView.KeyDown += DataGrid_KeyDown;

            heatsTabControl.Selected += delegate { SetTimePeriodLabels(); };

            SelectedDate = selectedDate;
            LoadData();
            DoDataBinding();
        }

        private void LoadData()
        {
            // Show the wait cursor as the weekly operations take a noticeable amount of time.
            Cursor currentCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            PeriodType periodType = dayRadioButton.Checked ? PeriodType.Day : PeriodType.Week;

            SetGridAlternativeRows(weekRadioButton.Checked);

            try
            {
                this.shiftHeatsViewModel = CasterReviewData.GetCasterTotals(SelectedDate, periodType);
                this.cumulativeViewModel = CasterReviewData.GetCumulativeHeatsViewModel(this.shiftHeatsViewModel);
                this.plan24HourViewModel = CasterReviewData.Get24HourPlan(SelectedDate, periodType);
                this.steelInMouldViewModel = CasterReviewData.GetSteelInMouldViewModel(SelectedDate, periodType);
            }
            finally
            {
                // Ensure the cursor is restored in case an exception is raised in a lower layer.
                Cursor = currentCursor;
            }
        }

        private void ShowActualVsPlannedHeatsForShift(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            if (sender is DataGridView)
            {
                var sourceGrid = sender as DataGridView;
                if (sourceGrid != null && sourceGrid.SelectedRows.Count > 0)
                {
                    // Get the summary line containing the shift details bound to current row.
                    if (sourceGrid.CurrentRow != null)
                    {
                        var summaryLine = sourceGrid.CurrentRow.DataBoundItem as ShiftHeatCountSummary;
                        if (summaryLine != null)
                        {
                            using (var heatsForm =
                                new HeatsPlannedVsActualForm(summaryLine.ShiftDate, summaryLine.ShiftType))
                            {
                                heatsForm.ShowDialog(this);
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        void HeatsDataGridView_DoubleClick(object sender, EventArgs e)
        {
            ShowActualVsPlannedHeatsFor24HourPlan(sender);
        }

        private void ShowActualVsPlannedHeatsFor24HourPlan(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            if (sender is DataGridView)
            {
                var sourceGrid = sender as DataGridView;
                if (sourceGrid != null && sourceGrid.SelectedRows.Count > 0)
                {
                    // Get the summary line containing the shift details bound to current row.
                    if (sourceGrid.CurrentRow != null)
                    {
                        var summaryLine = sourceGrid.CurrentRow.DataBoundItem as ShiftHeatCountSummary;
                        if (summaryLine != null)
                        {
                            using (var heatsForm =
                                new HeatsPlannedVsActual24HourForm(summaryLine.ShiftDate))
                            {
                                heatsForm.ShowDialog(this);
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoDataBinding()
        {
            SetTimePeriodLabels();

            shiftHeatsPerDay.SetViewModel(this.shiftHeatsViewModel);
            cumulativeShiftsPerDay.SetViewModel(this.cumulativeViewModel);
            planningShiftsPerDay.SetViewModel(this.plan24HourViewModel);
            steelInMouldSpeedRatio.SetViewModel(this.steelInMouldViewModel);
        }

        private void SetTimePeriodLabels()
        {
            IHeatsPerDayByCasterPeriod currentModel = null;

            switch (heatsTabControl.SelectedIndex)
            {
                case 0:
                    currentModel = this.shiftHeatsViewModel;
                    break;
                case 1:
                    currentModel = this.cumulativeViewModel;
                    break;
                case 2:
                    currentModel = this.plan24HourViewModel;
                    break;
                case 3:
                    currentModel = this.steelInMouldViewModel;
                    break;
                default:
                    break;
            }

            if (currentModel != null)
            {
                modelPeriodStartLabel.DataBindings.Clear();
                modelPeriodStartLabel.DataBindings.Add(
                    new Binding("Text", currentModel, "PeriodStartDisplayDate"));

                modelPeriodEndLabel.DataBindings.Clear();
                modelPeriodEndLabel.DataBindings.Add(
                    new Binding("Text", currentModel, "PeriodEndDisplayDate"));
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                var rb = sender as RadioButton;
                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        LoadData();
                        DoDataBinding();
                    }
                }
            }
        }

        private void directionButtons_Click(object sender, EventArgs e)
        {
            // If the Day radio button is selected modify by 1 day, else 1 week.
            int daysToAdd = dayRadioButton.Checked ? 1 : 7;

            if (sender is Button)
            {
                var b = sender as Button;
                if (b != null)
                {
                    if (b.Equals(previousButton))
                    {
                        SelectedDate = SelectedDate.AddDays((daysToAdd * (-1)));
                    }
                    else if (b.Equals(nextButton))
                    {
                        // Next button
                        SelectedDate = SelectedDate.AddDays(daysToAdd);
                    }
                    else
                    {
                        // Now Button
                        SelectedDate = DateTime.Now;
                    }
                    LoadData();
                    DoDataBinding();
                }
            }
        }

        private void DataGrid_DoubleClick(object sender, EventArgs e)
        {
            ShowActualVsPlannedHeatsForShift(sender);
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                // Prevent the default behaviour of selecting the next row.
                e.SuppressKeyPress = true;
                ShowActualVsPlannedHeatsForShift(sender);
            }
        }

        // If the user has selected the weekly view, color the alternatives rows light green
        // to aid readability, otherwise leave them white for the 2 daily rows.
        private void SetGridAlternativeRows(bool isWeeklyView)
        {
            if (isWeeklyView)
            {
                shiftHeatsPerDay.HeatsDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    Properties.Settings.Default.ColourHeatScheduler2;

                cumulativeShiftsPerDay.HeatsDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    Properties.Settings.Default.ColourHeatScheduler2;

                planningShiftsPerDay.HeatsDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    Properties.Settings.Default.ColourHeatScheduler2;

                steelInMouldSpeedRatio.CastersDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    Properties.Settings.Default.ColourHeatScheduler2;
            }
            else
            {
                shiftHeatsPerDay.HeatsDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    shiftHeatsPerDay.HeatsDataGridView.DefaultCellStyle.BackColor;

                cumulativeShiftsPerDay.HeatsDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    cumulativeShiftsPerDay.HeatsDataGridView.DefaultCellStyle.BackColor;

                planningShiftsPerDay.HeatsDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    planningShiftsPerDay.HeatsDataGridView.DefaultCellStyle.BackColor;

                steelInMouldSpeedRatio.CastersDataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                    steelInMouldSpeedRatio.CastersDataGridView.DefaultCellStyle.BackColor;
            }
        }

        private void HeatsPerDayByCasterForm_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Closes form when esc key is pressed.
        /// </summary>
        private void HeatsPerDayByCasterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #region Print

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = printDocument1;
            // Display the dialog. This returns true if the user presses the Print button.
            DialogResult print = pDialog.ShowDialog();
            if (print == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.Print();
                pagePrint = false;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.DefaultPageSettings.Landscape = true;
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            ((ToolStripButton)((ToolStrip)dlg.Controls[1]).Items[0]).Visible = false;
            dlg.Document = printDocument1;
            ((Form)dlg).WindowState = FormWindowState.Maximized;
            dlg.ShowDialog();
            pagePrint = false;
        }

        /// <summary>
        /// Store form data for print form.
        /// </summary>
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // pagePrint added due to control fireing twice, one image
            // and then a smaller one on top which is reduced again.
            if (pagePrint == false)
            {
                e.Graphics.ScaleTransform(1.3F, 1.3F);
                e.Graphics.DrawImage(memoryImage, 0, 0);
                pagePrint = true;
            }
        }
        #endregion
    }
}
