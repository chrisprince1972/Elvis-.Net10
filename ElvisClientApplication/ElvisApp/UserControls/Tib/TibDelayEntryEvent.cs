using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Elvis.Model;
using NLog;

// Explicit alias to avoid Unit ambiguity
using EdmxUnit = ElvisDataModel.EDMX.Unit;

namespace Elvis.UserControls.Tib
{
    public partial class TibDelayEntryEvent : UserControl
    {
        #region Variables
        private EdmxUnit unit;
        private TIBEvent tibEvent;
        private List<EdmxUnit> units;
        private List<Treatment> treatments;
        private List<HeatTreatmentDTO> heatTreatmentsDTO;
        private List<TreatmentTracking> treatmentTrackings;

        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        public TibDelayEntryEvent()
        {
            InitializeComponent();
            treatmentDataGridView.AutoGenerateColumns = false;
        }

        public void ConfigureTreatmentDetails(EdmxUnit unit, TIBEvent tibEvent)
        {
            this.unit = unit;
            this.tibEvent = tibEvent;

            if (this.unit != null && this.tibEvent != null)
            {
                GetTreatmentsForHeat();
                SetupTreeView();
            }
        }

        private void GetTreatmentsForHeat()
        {
            if (tibEvent.HeatNumber.HasValue && tibEvent.HNS.HasValue)
            {
                try
                {
                    // Gets all the data required for the page.
                    this.units = EntityHelper.Units.GetAll();
                    this.treatments = EntityHelper.Treatment.GetAll();
                    this.treatmentTrackings = EntityHelper.TreatmentTracking
                        .GetByHeatNumber(tibEvent.HeatNumber.Value, tibEvent.HNS.Value);
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR -- GetTreatmentsForHeat() -- " +
                        "Heat Number: " + tibEvent.HeatNumber.Value + " Set: " + tibEvent.HNS.Value + " -- " +
                        "Error Getting Data -- ", ex);
                }

                if (this.treatmentTrackings != null && this.units != null && this.treatments != null)
                {
                    // Generates the HeatTreatmentsDTO List
                    this.heatTreatmentsDTO = Model.Tib.GetHeatTreatmentDTOData(
                        this.treatmentTrackings,
                        this.units,
                        this.treatments);
                }
            }
        }

        private void SetupTreeView()
        {
            // Add the root node for the Heat Number;
            if (tibEvent.HeatNumber != 0)
            {
                treatmentsTreeView.Nodes.Add(string.Format("Heat {0}", tibEvent.HeatNumber));
            }
            else
            {
                treatmentsTreeView.Nodes.Add("No Heat Number");
                return;
            }

            if (this.treatmentTrackings != null && this.units != null)
            {
                // Filter the units list to only get the Visited Units.
                List<EdmxUnit> visitedUnits = units
                    .Where(u => treatmentTrackings.Any(t => t.UnitNumber.Equals(u.UnitNumber)))
                    .ToList();

                int currentUnitIndex = 0;
                int counter = 0;

                foreach (EdmxUnit visitedUnit in visitedUnits)
                {
                    TreeNode node = new TreeNode
                    {
                        Text = visitedUnit.UnitText,
                        Tag = visitedUnit
                    };

                    if (treatmentsTreeView.Nodes.Count > 0)
                        treatmentsTreeView.Nodes[0].Nodes.Add(node);

                    List<Treatment> unitTreatments = this.treatments
                        .Where(t => t.UnitNumber == visitedUnit.UnitNumber)
                        .OrderBy(t => t.TreatmentNumber)
                        .ToList();

                    foreach (Treatment unitTreatment in unitTreatments)
                    {
                        TreeNode treatmentNode = new TreeNode
                        {
                            Text = unitTreatment.TreatmentText,
                            Tag = unitTreatment
                        };
                        node.Nodes.Add(treatmentNode);
                    }

                    // Is this the unit the user selected the delay for?
                    if (this.unit != null && visitedUnit.UnitNumber == this.unit.UnitNumber)
                    {
                        currentUnitIndex = counter;
                    }

                    counter++;
                }

                if (treatmentsTreeView.Nodes.Count > 0)
                {
                    treatmentsTreeView.Nodes[0].Expand();

                    if (treatmentsTreeView.Nodes[0].Nodes != null &&
                        treatmentsTreeView.Nodes[0].Nodes.Count > 0)
                    {
                        // Guard against index issues
                        if (currentUnitIndex < 0 || currentUnitIndex >= treatmentsTreeView.Nodes[0].Nodes.Count)
                            currentUnitIndex = 0;

                        treatmentsTreeView.SelectedNode = treatmentsTreeView.Nodes[0].Nodes[currentUnitIndex];
                        treatmentsTreeView.SelectedNode.ExpandAll();
                        treatmentsTreeView.Select();
                    }
                }
            }
        }

        private void CustomiseColours()
        {
            this.BackColor =
                splitContainer1.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                splitContainer1.ForeColor =
                    Settings.Default.ColourText;
        }

        private void treatmentsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            // Heat Number root node
            if (treatmentsTreeView.Nodes.Count > 0 &&
                selectedNode.Equals(treatmentsTreeView.Nodes[0]))
            {
                treatmentDataGridView.DataSource = heatTreatmentsDTO
                    .OrderBy(t => t.UnitGroupSort)
                    .ThenBy(t => t.UnitNumber)
                    .ThenBy(t => t.TimeStampStart)
                    .ToList();
            }
            else if (selectedNode.Nodes.Count > 0) // Unit node
            {
                if (selectedNode.Tag is EdmxUnit unit)
                {
                    treatmentDataGridView.DataSource = heatTreatmentsDTO
                        .Where(t => t.UnitNumber == unit.UnitNumber)
                        .OrderBy(t => t.TimeStampStart)
                        .ToList();
                }
            }
            else if (selectedNode.Nodes.Count == 0) // Treatment node
            {
                if (selectedNode.Tag is Treatment treatment)
                {
                    treatmentDataGridView.DataSource = heatTreatmentsDTO
                        .Where(t => t.TreatmentNumber == treatment.TreatmentNumber)
                        .OrderBy(t => t.TimeStampStart)
                        .ToList();
                }
            }
        }

        private void treatmentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (treatmentDataGridView.Rows.Count > 0)
            {
                var row = treatmentDataGridView.Rows[e.RowIndex];

                if (row.DataBoundItem is HeatTreatmentDTO treatment)
                {
                    if (treatment.HasExceededPlannedDuration && e.ColumnIndex == 5)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        return;
                    }
                }
            }
        }

        // Prevent the default behaviour of selecting the first row as it masks the colours of the row.
        private void treatmentDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                grid.ClearSelection();
            }
        }
    }
}
