using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ElvisDataModel;
using System.Reflection;
using Elvis.Common;

namespace Elvis.UserControls.Tib
{
    public partial class DelayDetailGrid : UserControl
    {
        /// <summary>
        /// Container for the records also resolves unit id to text.
        /// </summary>
        public class DelayDisplay
        {
            public string TibIndex { get; set; }
            public string Unit { get; set; }
            public string No { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            //mins
            public string Duration { get; set; }
            public string PlantArea { get; set; }
            public string DelayClass { get; set; }
            public string Discipline { get; set; }
            public string Level1 { get; set; }
            public string Level2 { get; set; }
            public string Level3 { get; set; }
            public string Level4 { get; set; }
            public string UnitGroup { get; set; }
            public string Category { get; set; }
            public string Comment { get; set; }
            public string TibDelayIndex { get; set; }

            ///Ctor
            public DelayDisplay(ElvisDataModel.EDMX.TIBDelaysView delay)
            {
                this.TibIndex = delay.TibIndex.ToString();
                this.Unit = ElvisDataModel.EntityHelper.TIBEvents.GetUnitText(delay.TibIndex);
                this.No = delay.DelayNumber.ToString();
                this.StartTime = delay.DelayStart.HasValue ? delay.DelayStart.Value.ToString("dd/mm/yyyy hh:MM:ss") : String.Empty;
                this.EndTime = delay.DelayEnd.HasValue ? delay.DelayEnd.Value.ToString("dd/mm/yyyy hh:MM:ss") : String.Empty;
                this.Duration = delay.DelayDuration.HasValue ? delay.DelayDuration.Value.ToString() : String.Empty;
                this.PlantArea = delay.PlantArea;
                this.DelayClass = delay.TIBClassText;
                this.Discipline = delay.TIBDisText;
                this.Level1 = delay.DelayReason1;
                this.Level2 = delay.DelayReason2;
                this.Level3 = delay.DelayReason3;
                this.Level4 = delay.DelayReason4;
                this.UnitGroup = delay.UnitGroup.HasValue ? delay.UnitGroup.Value.ToString() : String.Empty;
                this.Category = delay.Category.HasValue ? delay.Category.Value.ToString() : String.Empty;
                this.Comment = delay.Comment;
                this.TibDelayIndex = delay.TibDelayIndex.ToString();
            }

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DelayDisplay> DelayList { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<DelayDisplay> BoundToDataGridView { get; set; }
        protected NLog.Logger Logger { get; set; }
        public event EventHandler OnSelectionChange;
        public event EventHandler OnChange;
        private bool ReadOnly { get; set; }
        private int Duration { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        public DelayDetailGrid()
        {
            InitializeComponent();
            dataGridViewDelays.AutoGenerateColumns = false;
            this.Logger = NLog.LogManager.GetCurrentClassLogger();
            this.DelayList = new List<DelayDisplay>();
            this.ReadOnly = false;
            this.BoundToDataGridView = new BindingList<DelayDisplay>();

        }

        #region public methods
        /// <summary>
        /// Builds the coloured box display on the pannel that is passed in to 
        /// display the delays in picutre form.
        /// </summary>
        /// <param name="toPopulate">Panel to populate with mini panels representing delays.</param>
        /// <param name="totalTIBDuration">The total size of the TIB event.</param>
        public void BuildBoxDisplay(Panel toPopulate, int totalTIBDuration)
        {
            toPopulate.Controls.Clear();
            this.Duration = totalTIBDuration;

            foreach (DataGridViewRow row in dataGridViewDelays.Rows)
            {
                Panel pnl = new Panel();

                object cellPlantAreaValue
                    = row.Cells["PlantArea"].Value;
                object cellDelayDurationValue
                    = row.Cells["DelayDuration"].Value;

                double delayDuration = 0;

                if (cellPlantAreaValue != null
                    && cellDelayDurationValue != null
                    && double.TryParse(cellDelayDurationValue.ToString(), out delayDuration))
                {
                    pnl.BackColor
                        = Elvis
                        .Common
                        .Colours
                        .GetTibDelayColour(cellPlantAreaValue.ToString());

                    pnl.Width = CalculatePanelWidth(
                        toPopulate.Width,
                        totalTIBDuration,
                        delayDuration);
                }

                toPopulate.Controls.Add(pnl);
                pnl.Dock = DockStyle.Left;
                pnl.BringToFront();
            }
        }

        /// <summary>
        /// Wrapper for clearing the selection from the data grid view.
        /// </summary>
        public void ClearSelection()
        {
            dataGridViewDelays.ClearSelection();
        }

        /// <summary>
        /// Wraps getting the row count from the data grid view.
        /// </summary>
        /// <returns>Number of rows on the data grid view.</returns>
        public int GetRowCount()
        {
            return dataGridViewDelays.Rows.Count;
        }

        /// <summary>
        /// Calculates the total minutes of the delays gridview
        /// </summary>
        /// <returns>The Total Minutes as a string.</returns>
        public int GetTotalDelayAccountedForMins()
        {
            int mins = 0;
            foreach (DataGridViewRow row in dataGridViewDelays.Rows)
            {//Loops through each row and accumalates a sum.
                int container = 0;

                if (row.Cells["DelayDuration"].Value != null
                    && int.TryParse(row.Cells["DelayDuration"].Value.ToString(), out container))
                {
                    mins += container;
                }
            }

            return mins;
        }


        /// <summary>
        /// Returns delay that is currently selected.
        /// </summary>
        /// <returns>Delay that is currently selected on the grid view.</returns>
        public ElvisDataModel.EDMX.TIBDelaysView GetSelectedDelay()
        {
            ElvisDataModel.EDMX.TIBDelaysView tibDelaysView = null;

            if (GetSelectedIndex() >= 0)
            {

                tibDelaysView
                    = ElvisDataModel
                    .EntityHelper
                    .TIBDelaysView
                    .GetByTibDelayIndex(GetSelectedDelayIndex());
            }

            return tibDelaysView;
        }

        /// <summary>
        /// Gets TIB delay index of selected delay.
        /// </summary>
        /// <returns>Selected TIB delay index.</returns>
        public int GetSelectedDelayIndex()
        {
            return int.Parse(dataGridViewDelays.CurrentRow.Cells["TibDelayIndex"].Value.ToString());
        }

        /// <summary>
        /// Gets the index of the selected row.
        /// </summary>
        /// <returns>Selected index if there is one -1 if not.</returns>
        public int GetSelectedIndex()
        {
            int selectedIndex = -1;
            if (dataGridViewDelays.SelectedRows.Count > 0)
            {
                selectedIndex = dataGridViewDelays.SelectedRows[0].Index;
            }

            return selectedIndex;
        }

        /// <summary>
        /// Gets the time of the TIB event that has yet to be allocated by a delay.
        /// </summary>
        /// <param name="tibIndex">The identify for the TIB to get the total amount of time from.</param>
        /// <returns>The ammount of unallocated time for the TIB event.</returns>
        public int GetTotalUnallocatedEventTime(int tibIndex)
        {
            int eventTime = this.Duration;
            int accounted = GetTotalDelayAccountedForMins();
            return eventTime - accounted;
        }

        /// <summary>
        /// Moves the delay up or down in the list of delays for that event
        /// </summary>
        /// <param name="moveUp">True if wanting to move up, false if wanting to move down.</param>
        public void MoveDelay(bool moveUp)
        {
            if (dataGridViewDelays.SelectedRows.Count > 0)
            {
                int tibIndex = 0;
                int tibDelayNo = 0;
                if (int.TryParse(dataGridViewDelays.SelectedRows[0].Cells["TibIndex"].Value.ToString(), out tibIndex) &&
                    int.TryParse(dataGridViewDelays.SelectedRows[0].Cells["DelayNumber"].Value.ToString(), out tibDelayNo))
                {
                    try
                    {
                        ElvisDataModel.EntityHelper.TIBDelays.ChangeOrder(tibIndex, tibDelayNo, moveUp);
                        Reset();
                        KeepRowSelected(tibDelayNo, moveUp);
                    }
                    catch (Exception ex)
                    {
                        Logger.ErrorException("DATA ERROR -- EditTibDelayNumber() -- " +
                            "Editing TIB Delay Numbers -- ", ex);
                        MessageBox.Show("Failed to change delay order.",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    }
                }
            }
        }

        /// <summary>
        /// Reset the grid by passing a list of the stored TIB Indexes back into setup user control and then calling show data.
        /// </summary>
        public void Reset()
        {
            SetupUserControl(Enumerable.DistinctBy(DelayList,r => r.TibIndex).Select(r => int.Parse(r.TibIndex)).ToList());
            ShowData();
        }

        /// <summary>
        /// Setup the usre control with a list of TIB indexes.
        /// </summary>
        /// <param name="tibIndexList">List of multiple TIB indexes to show.</param>
        public void SetupUserControl(List<int> tibIndexList)
        {
            this.DelayList.Clear();
            foreach (int tibIndex in tibIndexList)
            {
                List<ElvisDataModel.EDMX.TIBDelaysView> tibDelayList
                       = ElvisDataModel
                       .EntityHelper
                       .TIBDelaysView
                       .GetByTibEvent(tibIndex);

                foreach (ElvisDataModel.EDMX.TIBDelaysView delay in tibDelayList)
                {
                    this.DelayList.Add(new DelayDisplay(delay));
                }
            }
        }


        /// <summary>
        /// Sets the TIB Events using the entity helper and logs
        /// any errors.
        /// </summary>
        /// <param name="tibIndex">The Tib Event Index you wish to get.</param>
        /// <returns>The TIB Event.</returns>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            // Configure for heat details tab.
            this.ReadOnly = true;

            try
            {
                SetupUserControl
                (
                    ElvisDataModel
                    .EntityHelper
                    .TIBEvents
                    .GetByHeat(heatNumber, heatNumberSet)
                    .Select(r => r.TibIndex)
                    .ToList()
                );
            }
            catch (Exception ex)
            {
                Logger.ErrorException(
                    "DATA ERROR -- TibUserControl -- "
                    + "Getting Tib Event data from database -- heatNumberSet: "
                    + heatNumberSet
                    + ", heatNumber: "
                    + heatNumber
                    + " -- ", ex);
            }
        }

        /// <summary>
        /// Displays the data in the grid view.  Seperated for threaded calls.
        /// </summary>
        public void ShowData()
        {
            this.BoundToDataGridView.Clear();

            foreach(DelayDisplay dd in this.DelayList)
            {
                this.BoundToDataGridView.Add(dd);
            }

            if (this.ReadOnly)
            {
                DelayColUnit.Visible = true;
                DelayNumber.Visible = false;
            }

            dataGridViewDelays.DataSource = this.BoundToDataGridView;
        }


        /// <summary>
        /// Shows the popup to add delays
        /// </summary>
        /// <param name="tibIndex">The Tib Index for that Delay.</param>
        /// <returns>bool true if ok.</returns>
        public bool ShowNewDelayPopup(int tibIndex, int minsRemaining, DateTime onGoingEndTime)
        {
            bool success = false;
            using
            (
                Elvis
                    .Forms
                    .Tib
                    .DelayPopup delayPopup
                    = new Elvis
                        .Forms
                        .Tib
                        .DelayPopup
                        (
                            tibIndex,
                            0,
                            GetTotalUnallocatedEventTime(tibIndex),
                            onGoingEndTime
                        )
            )
            {
                success = delayPopup.ShowDialog() == DialogResult.OK;
            }

            return success;
        }

        /// <summary>
        /// Shows the popup to edit/delete delays
        /// </summary>
        /// <returns>bool true if ok.</returns>
        public bool ShowSelectedDelayPopup()
        {
            bool success = false;
            ElvisDataModel.EDMX.TIBDelaysView delay = GetSelectedDelay();
            if (delay != null)
            {
                using
                (
                    Elvis
                        .Forms
                        .Tib
                        .DelayPopup delayPopup
                        = new Elvis
                            .Forms
                            .Tib
                            .DelayPopup
                            (
                                delay.TibIndex,
                                delay.TibDelayIndex,
                                GetTotalUnallocatedEventTime(delay.TibIndex),
                                MyDateTime.Now
                            )
                )
                {
                    DialogResult result = delayPopup.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Reset();
                        success = true;
                    }
                }

            }

            return success;
        }

        #endregion

        #region private part

        /// <summary>
        /// Calculates the width of each panel (delay) on screen for the 
        /// colour delay display
        /// </summary>
        /// <param name="panelWidth">The panel's width</param>
        /// <param name="overallDuration">The overall event duration</param>
        /// <param name="delayTime">The duration of the delay</param>
        /// <returns>The width of the panel as a duoble</returns>
        private int CalculatePanelWidth(int panelWidth, int overallDuration, double delayTime)
        {
            int newWidth = 50;
            double overAllDurationAsDouble = 0;
            double panelWidthAsDouble = 0;

            if (double.TryParse(overallDuration.ToString(), out overAllDurationAsDouble)
                && double.TryParse(panelWidth.ToString(), out panelWidthAsDouble))
            {
                double newWidthAsDouble = (panelWidthAsDouble / overAllDurationAsDouble) * delayTime;
                newWidth = Convert.ToInt32(Math.Round(newWidthAsDouble, 0));
            }

            return newWidth;
        }

        /// <summary>
        /// When some data is changed on the grid raise the on change event.
        /// </summary>
        private void Changed()
        {
            if (this.OnChange != null)
            {
                this.OnChange(null, null);
            }
        }

        /// <summary>
        /// After move row has been performed, keep it selected
        /// </summary>
        /// <param name="rowIndex">The row index you wish to select</param>
        /// <param name="moveUp">The direction to move the record.</param>
        private void KeepRowSelected(int rowIndex, bool moveUp)
        {
            if (dataGridViewDelays.Rows.Count > 0)
            {
                if (moveUp)
                    dataGridViewDelays.Rows[rowIndex - 2].Selected = true;
                else
                    dataGridViewDelays.Rows[rowIndex].Selected = true;
            }
        }

        /// <summary>
        /// When a different delay is selected rais the on selection changed event.
        /// </summary>
        private void SelectionChange()
        {
            if (this.OnSelectionChange != null)
            {
                this.OnSelectionChange(null, null);
            }
        }
        #endregion

        #region events
        /// <summary>
        /// Called when the selection changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDelays_OnSelectionChange(object sender, EventArgs e)
        {
            if (this.ReadOnly)
            {
                dataGridViewDelays.ClearSelection();
            }
            else
            {
                SelectionChange();
            }
        }

        /// <summary>
        /// Find the row clicked and the index of that row and then show popup
        /// then show edit popup.
        /// </summary>
        private void dataGridViewDelays_DoubleClick(object sender, EventArgs e)
        {
            if (!this.ReadOnly)
            {
                ShowSelectedDelayPopup();
                Changed();
            }
        }

        /// <summary>
        /// Removes any spaces from the string content of the data grid and colours the boxes.
        /// </summary>
        private void dataGridViewDelays_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.Value != null)
            {
                e.Value = e.Value.ToString().Trim();

                if (e.ColumnIndex == 6)
                {
                    e.CellStyle.BackColor = Elvis.Common.Colours.GetTibDelayColour(e.Value.ToString());
                    e.CellStyle.ForeColor = Elvis.Common.Colours.GetTibDelayForeColour(e.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Key down event for gridview
        /// </summary>
        private void dataGridViewDelays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !this.ReadOnly)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ShowSelectedDelayPopup();
                Changed();
            }
        }
        #endregion




    }
}
