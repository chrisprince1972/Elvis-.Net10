using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis;
using Elvis.Model;
using Elvis.Model.ViewModels;

namespace Elvis.Forms
{
    public partial class HeatsPlannedVsActualForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ShiftType ShiftType { get; set; }

        // Private properties to facilitate easy access to the data grid views.
        private List<DataGridView> AllDataGridViews { get; set; }
        private List<DataGridView> PlannedHeatsDataGridViews { get; set; }
        private List<DataGridView> ActualHeatsDataGridViews { get; set; }

        public HeatsPlannedVsActualForm()
            : this(DateTime.Now, ShiftType.Day)
        {
        }

        public HeatsPlannedVsActualForm(DateTime selectedDate, ShiftType shiftType)
        {
            this.Cursor = Cursors.WaitCursor;
            SelectedDate = selectedDate;
            ShiftType = shiftType;
            InitializeComponent();

            // Add the DataGridViews exposed by the 6 HeatsPlannedVsActual user controls.
            AllDataGridViews = new List<DataGridView>(6)
            {
                cc1PlannedHeats.HeatsDataGridView,
                cc2PlannedHeats.HeatsDataGridView,
                cc3PlannedHeats.HeatsDataGridView,
                cc1ActualHeats.HeatsDataGridView,
                cc2ActualHeats.HeatsDataGridView,
                cc3ActualHeats.HeatsDataGridView
            };

            PlannedHeatsDataGridViews = new List<DataGridView>(3)
            {
                cc1PlannedHeats.HeatsDataGridView,
                cc2PlannedHeats.HeatsDataGridView,
                cc3PlannedHeats.HeatsDataGridView
            };

            ActualHeatsDataGridViews = new List<DataGridView>(3)
            {
                cc1ActualHeats.HeatsDataGridView,
                cc2ActualHeats.HeatsDataGridView,
                cc3ActualHeats.HeatsDataGridView
            };

            LoadData();

            // Assign the same Click event handler to each data grid view.
            AllDataGridViews.ForEach(g => g.Click += DataGridView_OnClick);

            // Implement a KeyUp event handler for each data grid to call the corresponding
            // Click event on certain keys only. The KeyUp event is used so that the change
            // in selected heat in the grid has already occured before the key is released.
            AllDataGridViews.ForEach(g =>
                {
                    g.KeyUp += (sender, e) =>
                        {
                            var directionKeys = new List<Keys>
                            {
                                Keys.Return, Keys.Up, Keys.Down, Keys.PageUp, Keys.Next
                            };
                            if (directionKeys.Contains(e.KeyCode))
                            {
                                e.Handled = true;
                                DataGridView_OnClick(sender, e);
                            }
                        };
                });

            AllDataGridViews.ForEach(g => g.ClearSelection());
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            string shiftStartTime = ShiftType == ShiftType.Day ? "07:00" : "19:00";
            plannedHeatsGroupBox.Text = String.Format("Planned Heats as at {0}",
                    SelectedDate.ToString(String.Format("dd-MM {0}", shiftStartTime)));

            List<HeatSummaryViewItem> plannedHeats =
                CasterReviewData.GetPlannedHeatsForShift(SelectedDate, ShiftType);

            List<HeatSummaryViewItem> actualHeats =
                CasterReviewData.GetActualHeatsForShift(SelectedDate, ShiftType);
           
            CasterReviewData.ConfigureHeatDeviations(plannedHeats, actualHeats);

            List<HeatSummaryViewItem> cc1PlanHeats = plannedHeats.Where(h => h.CasterName == "CC1").ToList();
            List<HeatSummaryViewItem> cc2PlanHeats = plannedHeats.Where(h => h.CasterName == "CC2").ToList();
            List<HeatSummaryViewItem> cc3PlanHeats = plannedHeats.Where(h => h.CasterName == "CC3").ToList();

            List<HeatSummaryViewItem> cc1ActHeats = actualHeats.Where(h => h.CasterName == "CC1").ToList();
            List<HeatSummaryViewItem> cc2ActHeats = actualHeats.Where(h => h.CasterName == "CC2").ToList();
            List<HeatSummaryViewItem> cc3ActHeats = actualHeats.Where(h => h.CasterName == "CC3").ToList();

            cc1PlannedHeats.SetHeatSummaries(cc1PlanHeats);
            cc2PlannedHeats.SetHeatSummaries(cc2PlanHeats);
            cc3PlannedHeats.SetHeatSummaries(cc3PlanHeats);

            cc1ActualHeats.SetHeatSummaries(cc1ActHeats);
            cc2ActualHeats.SetHeatSummaries(cc2ActHeats);
            cc3ActualHeats.SetHeatSummaries(cc3ActHeats);

            plannedHeatsTotalLabel.Text = (cc1PlanHeats.Count + cc2PlanHeats.Count + cc3PlanHeats.Count).ToString();
            actualHeatsTotalLabel.Text = (cc1ActHeats.Count + cc2ActHeats.Count + cc3ActHeats.Count).ToString();
        }

        private void nowButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SelectedDate = DateTime.Now;
            LoadData();
            this.Cursor = Cursors.Default;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SelectedDate = SelectedDate.AddDays(-1);
            LoadData();
            this.Cursor = Cursors.Default;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SelectedDate = SelectedDate.AddDays(1);
            LoadData();
            this.Cursor = Cursors.Default;
        }

        private void DataGridView_OnClick(object sender, EventArgs e)
        {
            // Get the DataGridView that fired the event
            if (sender is DataGridView)
            {
                var sourceGrid = sender as DataGridView;
                if (sourceGrid == null) return;
                if (sourceGrid.CurrentRow == null) return;
                if (sourceGrid.CurrentRow.DataBoundItem == null) return;

                // Get the HeatSummaryViewItem bound to the row the user has just selected.
                HeatSummaryViewItem selectedHeat = sourceGrid.CurrentRow.DataBoundItem as HeatSummaryViewItem;
                if (selectedHeat == null) return;

                // Clear the selected row in all the grids except the selected one.
                AllDataGridViews.ForEach(g =>
                    {
                        if (g != sourceGrid) g.ClearSelection();
                    });

                // Get the collection of DataGridViews which will contain the equivalent planned or actual
                // record for the heat, depending on which 'side' the user clicked. ie if they clicked one the
                // planned grids, we want to look for the heat on the Actual side and vice versa.
                List<DataGridView> oppositeGrids = selectedHeat.SummaryType ==
                    HeatSummaryViewItem.HeatSummaryType.Planned
                    ? ActualHeatsDataGridViews
                    : PlannedHeatsDataGridViews;

                foreach (var grid in oppositeGrids)
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        var summary = row.DataBoundItem as HeatSummaryViewItem;
                        if (summary != null)
                        {
                            if (summary.HeatNumber == selectedHeat.HeatNumber)
                            {
                                try
                                {
                                    grid.CurrentCell = row.Cells[0];
                                    row.Selected = true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                return;
                            }
                            else
                            {
                                row.Selected = false;
                            }
                        }
                    }
                }
            }
        }

        private void HeatsPlannedVsActualForm_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
