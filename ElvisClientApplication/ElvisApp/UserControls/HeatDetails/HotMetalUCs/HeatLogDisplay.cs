using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NLog;
using Elvis.Properties;
using System.Drawing;
using Elvis.Common;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    public partial class HeatLogDisplay : ElvisHeatDetailsUserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool isDesulphPour = false;
        private IEnumerable<ElvisDataModel.EDMX.HeatLog> heatLogData = null;
        private int unitNumber = 0;

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public HeatLogDisplay()
        {
            InitializeComponent();
            dgvHeatLog.AutoGenerateColumns = false;
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                dgvHeatLog.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to put the values into the control.
        /// Call is same key to avoid hitting the database multiple times to get the same information.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        /// <param name="unitId">Specifies which unit to show.</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet, int unitNumber)
        {
            if (!IsSameKey(heatNumber, heatNumberSet, unitNumber))
            {
                base.SetHeatDetails(heatNumber, heatNumberSet);
            }
            this.unitNumber = unitNumber;
        }

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to put the values into the control.
        /// Call is same key to avoid hitting the database multiple times to get the same information.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        public override void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            if (!IsSameKey(heatNumber, heatNumberSet, 0))
            {
                base.SetHeatDetails(heatNumber, heatNumberSet);
            }
        }

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to 
        /// put the values into the control when they want to display the 
        /// desulph and pour data.
        /// Call is same key to avoid hitting the database multiple times to get the same information.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        public void SetupUserControlForDesulphPour(int heatNumber, int heatNumberSet)
        {
            if (!IsSameKey(heatNumber, heatNumberSet, unitNumber))
            {
                base.SetHeatDetails(heatNumber, heatNumberSet);
            }
            this.isDesulphPour = true;
        }


        /// <summary>
        /// Gets the data for the entire user control by calling the relevant methods.
        /// </summary>
        /// <returns>Empty string on success.</returns>
        protected override string GetData()
        {
            string error = String.Empty;

            try
            {
                if (this.isDesulphPour)
                {
                    SetDataDesulphPourModel();
                }
                else
                {
                    LoadAll();
                }
            }
            catch (Exception ex)
            {
                error = String.Format("Error getting data for heat log: {0}", ex.Message);
                string msg
                    = string.Format(
                        "DATA ERROR HEAT LOG -- GetData() -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet);

                logger.ErrorException(msg, ex);
            }

            return error;
        }

        /// <summary>
        /// When the thread has finished executing it will call this. So populate the data on the gridview.
        /// </summary>
        protected override void PopulateForm()
        {
            this.FilterByUnitId();
        }

        /// <summary>
        /// Passes back the control's main panel so it can overwrite the loading image.
        /// </summary>
        protected override void ShowMainPanel()
        {
            this.ShowMainPanel(pnlMain);
        }

        /// <summary>
        /// This function is to check if the data needs to be retrieved or not by checking if the key has changed.
        /// If the key has not changed then this.heatLogData does not need to be updated.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        /// <param name="unitId">Specifies which unit to show.</param>
        /// <returns></returns>
        private bool IsSameKey(int heatNumber, int heatNumberSet, int unitNumber = 0)
        {
            return
                this.heatNumberSet == heatNumberSet
                && this.heatNumber == heatNumber
                && this.unitNumber == unitNumber;
        }


        /// <summary>
        /// Filter the records by this.unit number if it has a value and this.heatlogdata is not null.
        /// </summary>
        private void FilterByUnitId()
        {
            if (this.heatLogData != null)
            {
                if (this.unitNumber > 0)
                {
                    dgvHeatLog.DataSource = this.heatLogData
                        .Where(h => h.Unit == this.unitNumber)
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
                else
                {
                    dgvHeatLog.DataSource = this.heatLogData
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
            }
        }

        /// <summary>
        /// Shows the data for the desulph and HM pour model.
        /// </summary>
        private void SetDataDesulphPourModel()
        {
            heatLogData = EntityHelper.HeatLog.GetByHeatForDesulphPour(
                this.heatNumber, 
                this.heatNumberSet
                );
        }

        /// <summary>
        /// Shows heat log from a specific unit.
        /// </summary>
        private void LoadAll()
        {
            heatLogData = EntityHelper.HeatLog.GetByHeat(
                this.heatNumber, 
                this.heatNumberSet
                );
        }

        /// <summary>
        /// When the user cant see the whole message.
        /// </summary>
        /// <param name="dataGridViewCellCollection">The cells in the row the first should be the 
        /// timestamp and the second should be the message.</param>
        private void ShowHeatLogMessageInFull(DataGridViewCellCollection dataGridViewCellCollection)
        {
            string timesampAsString = dataGridViewCellCollection[0].Value.ToString();
            string message = dataGridViewCellCollection[1].Value.ToString();
            string msg = String.Format("{0}: {1}", timesampAsString, message);

            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Double click on the DataGridView, event handler.
        /// </summary>
        private void gdvHeatLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //We should only be able to select one row.
            ShowHeatLogMessageInFull(dgvHeatLog.SelectedRows[0].Cells);

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Key down event for gridview.
        /// </summary>
        private void gdvHeatLog_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                //We should only be able to select one row.
                ShowHeatLogMessageInFull(dgvHeatLog.SelectedRows[0].Cells);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Sets up the column header font after binding is complete.
        /// </summary>
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CommonMethods.FormatColumnFont(
                sender as DataGridView,
                new Font("Microsoft Sans Serif", 8, FontStyle.Bold));
        }
    }
}
