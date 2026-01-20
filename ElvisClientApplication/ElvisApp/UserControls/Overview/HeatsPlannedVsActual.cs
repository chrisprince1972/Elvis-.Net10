using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Model.ViewModels;
using System.ComponentModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class HeatsPlannedVsActual : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<HeatSummaryViewItem> HeatSummaries { get; set; }

        public DataGridView HeatsDataGridView
        {
            get { return heatsDataGridView; }
        }

        /// <summary>
        /// Shows or hides the Total label, plus its associated panel, to the left of the grid.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowTotalLabel
        {
            get { return totalLabel.Visible; }
            set
            {
                totalLabel.Visible = value;
                totalPanel.Visible = value;
            }
        }
        #endregion

        #region Constructor
        public HeatsPlannedVsActual()
        {
            InitializeComponent();
            heatsDataGridView.AutoGenerateColumns = false;

            HeatSummaries = new List<HeatSummaryViewItem>();
            heatsDataGridView.DataSource = HeatSummaries;
        }
        #endregion

        public void SetHeatSummaries(IEnumerable<HeatSummaryViewItem> heatSummaries)
        {
            HeatSummaries = heatSummaries;
            HeatsDataGridView.DataSource = HeatSummaries;
        }

        private void heatsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (HeatSummaries == null || HeatSummaries.Count() == 0) return;
            if (HeatSummaries.Count() < (e.RowIndex + 1)) return;

            HeatSummaryViewItem heatSummary = HeatSummaries.ElementAt(e.RowIndex);

            if (heatSummary.SummaryType == HeatSummaryViewItem.HeatSummaryType.Planned)
            {
                // Heat planned but not made so show whole line red and return.
                if (heatSummary.HasPlannedNotMadeDeviation)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    return;
                }
            }

            if (heatSummary.SummaryType == HeatSummaryViewItem.HeatSummaryType.Actual)
            {

                // Convert the "Total Width" column to n/a as we don't have a value.
                if (e.ColumnIndex == 6)
                {
                    e.Value = "n/a";
                }

                // Heat made but not planned so show whole line green and return.
                if (heatSummary.HasMadeNotPlannedDeviation)
                {
                    e.CellStyle.ForeColor = Color.Green;
                    return;
                }
            }

            // Planned on one caster but made on another so show whole line blue, but don't
            // return yet as other cells might need to be coloured red to show other deviations.
            if (heatSummary.HasCasterNameDeviation)
            {
                e.CellStyle.ForeColor = Color.Blue;
            }

            if (e.ColumnIndex == 2 && heatSummary.HasProgramNumberDeviation)
            {
                e.CellStyle.ForeColor = Color.Red;
            }

            if (e.ColumnIndex == 3 && heatSummary.HasGradeDeviation)
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        // Prevent the default behaviour of selecting the first row as it masks the colours of the row.
        private void heatsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView)
            {
                var grid = sender as DataGridView;
                if (grid != null)
                {
                    grid.ClearSelection();
                }

                totalLabel.Text = heatsDataGridView.RowCount.ToString();
            }
        }
    }
}
