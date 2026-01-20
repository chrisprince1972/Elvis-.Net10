using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Model.ViewModels;

namespace Elvis.UserControls.HeatDetails
{
    public partial class HeatsPerDayByCaster : UserControl
    {
        #region Variables and Properties
        private HeatsPerDayByCasterViewModel _viewModel;

        public DataGridView HeatsDataGridView
        {
            get { return heatsDataGridView; }
        }
        #endregion

        #region Constructor
        public HeatsPerDayByCaster()
        {
            InitializeComponent();
            _viewModel = new HeatsPerDayByCasterViewModel();

            dayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            shiftColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            BindColumnTotalLabels();
        }
        #endregion

        /// <summary>
        /// Inject the HeatsPerDayByCasterViewModel instance for the control
        /// to display.
        /// </summary>
        /// <param name="viewModel">A populated view model instance.</param>
        public void SetViewModel(HeatsPerDayByCasterViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel",
                    "A non-null instance of the View Model must be supplied");
            }

            _viewModel = viewModel;
            heatsDataGridView.DataSource = _viewModel.ShiftHeatCountSummaries;
            BindColumnTotalLabels();
        }

        private void BindColumnTotalLabels()
        {
            foreach (var control in totalsTableLayoutPanel.Controls)
            {
                if (control is Label)
                {
                    var label = control as Label;
                    if (label != null)
                    {
                        label.DataBindings.Clear();
                    }
                }
            }

            cc1PlannedCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC1PlannedCountTotal"));
            cc2PlannedCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC2PlannedCountTotal"));
            cc3PlannedCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC3PlannedCountTotal"));
            plannedCountTotalLabel.DataBindings.Add(new Binding("Text", _viewModel, "PlannedCountTotalSum"));

            cc1DeviationsCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC1DeviationsCountTotal"));
            cc2DeviationsCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC2DeviationsCountTotal"));
            cc3DeviationsCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC3DeviationsCountTotal"));
            deviationsCountTotalLabel.DataBindings.Add(new Binding("Text", _viewModel, "DeviationsCountTotalSum"));

            cc1ActualCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC1ActualCountTotal"));
            cc2ActualCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC2ActualCountTotal"));
            cc3ActualCountLabel.DataBindings.Add(new Binding("Text", _viewModel, "CC3ActualCountTotal"));
            actualCountTotalLabel.DataBindings.Add(new Binding("Text", _viewModel, "ActualCountTotalSum"));
        }

        // Respond to the CellPaint event to draw vertical lines between the cells to improve readability
        // on the screen.
        private void totalsTableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            // These 3 columns have a thicker 4px line to visually divide sections.
            if (e.Column == 0 || e.Column == 4 || e.Column == 8)
            {
                e.Graphics.FillRectangle(Brushes.DimGray,
                    new Rectangle(e.CellBounds.Right - 4, e.CellBounds.Y, 4, e.CellBounds.Height));
            }
            else
            {
                // All others have a thin 1px line, except the last one which has the outer border
                // of the parent control instead.
                if (e.Column != 12)
                {
                    e.Graphics.FillRectangle(Brushes.DimGray,
                        new Rectangle(e.CellBounds.Right - 1, e.CellBounds.Y, 1, e.CellBounds.Height));
                }
            }
        }
    }
}
