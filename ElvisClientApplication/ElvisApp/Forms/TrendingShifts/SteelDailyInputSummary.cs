using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.TrendingShifts
{
    public partial class SteelDailyInputSummary : Form
    {
        private const int lowerTimeConstraint = 6;
        private const int upperTimeConstraint = 10;

        private int selectedDelayDateIndex = 0;
        private int rowIndex = 0;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public SteelDailyInputSummary()
        {
            InitializeComponent();
            dgvManDailyInputs.AutoGenerateColumns = false;
            BindDataGridview();
            CustomiseColours();
        }

        private void CustomiseColours()
        {
            this.BackColor =
            pnlMain.BackColor =
            grpSteelInputs.BackColor =
            dgvManDailyInputs.BackgroundColor =
            pnlGridview.BackColor =
            pnlGridviewButtons.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlMain.ForeColor =
            grpSteelInputs.ForeColor =
            pnlGridview.ForeColor =
            pnlGridviewButtons.ForeColor =
                Settings.Default.ColourText;
        }

        private void BindDataGridview()
        {
            dgvManDailyInputs.DataSource = null;
            dgvManDailyInputs.DataSource = GetDailyInputs();
        }

        private List<ManInputDayWithText> GetDailyInputs()
        {
            try
            {
                List<ManInputDayWithText> manInputWithTexts = new List<ManInputDayWithText>();
                List<OpPractice> opPractices = EntityHelper.OpPractice.GetAll();
                List<ManInputDay> manInputDays = EntityHelper.ManInputDay.GetLast7Days();

                foreach (ManInputDay manInput in manInputDays)
                {
                    ManInputDayWithText manInputWithText = new ManInputDayWithText()
                    {
                        DayDateIndex = manInput.DayDateIndex,
                        DayDate = manInput.DayDate,
                        BFOutput = manInput.BFOutput,
                        OPPracticeIndex = manInput.OPPracticeIndex
                    };

                    if (opPractices != null)
                    {
                        OpPractice opPractice = opPractices.FirstOrDefault(o => o.OpPracticeIndex == manInput.OPPracticeIndex);

                        if (opPractice != null)
                        {
                            manInputWithText.OpPracticeText = opPractice.OpPracticeText;
                        }
                    }

                    manInputWithTexts.Add(manInputWithText);
                }

                return manInputWithTexts;
            }
            catch (Exception ex)
            {
                logger.DebugException("DATA ERROR -- Error generating Manual Input Day data -- ", ex);
            }
            return new List<ManInputDayWithText>();
        }

        /// <summary>
        /// Opens the selected Heat Details.
        /// </summary>
        private void ViewManualInput(int rowIndex)
        {
            if (rowIndex == 0 && CanUserEdit() && this.selectedDelayDateIndex > 0)
            {
                using (SteelDailyInput steelDailyInput = new SteelDailyInput(this.selectedDelayDateIndex))
                {
                    steelDailyInput.ShowDialog();
                }
                BindDataGridview();
            }
            else
            {
                MessageBox.Show(
                    string.Format(
                        "User can only edit latest record if the time is after {0}:00 and before {1}:00 on the current date.",
                        lowerTimeConstraint, upperTimeConstraint),
                    "Cannot Edit this Record",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Checks the time to see if user can edit the record.
        /// </summary>
        /// <returns>True if user can edit, false otherwise.</returns>
        private bool CanUserEdit()
        {
            if (DateTime.Now.Hour >= lowerTimeConstraint && DateTime.Now.Hour < upperTimeConstraint)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void SteelDailyInputSummary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Click event for the Add button.
        /// Opens the add daily input form.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SteelDailyInput dailyInput = new SteelDailyInput())
            {
                this.Cursor = Cursors.WaitCursor;
                dailyInput.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
            BindDataGridview();
        }

        /// <summary>
        /// Find the row clicked and the index of that row and then
        /// display the edit report popup.
        /// </summary>
        private void dgvManDailyInputs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ViewManualInput(e.RowIndex);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Key down event for gridview
        /// </summary>
        private void dgvManDailyInputs_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                ViewManualInput(this.rowIndex);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Selection changed on the DataGridView event handler.
        /// </summary>
        private void dgvManDailyInputs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManDailyInputs.SelectedRows.Count > 0 && dgvManDailyInputs.CurrentRow != null)
            {
                this.rowIndex = dgvManDailyInputs.CurrentRow.Index;
                ManInputDay manInputDay = dgvManDailyInputs.CurrentRow.DataBoundItem as ManInputDay;
                if (manInputDay != null)
                {
                    this.selectedDelayDateIndex = manInputDay.DayDateIndex;
                }
            }
        }
    }

    class ManInputDayWithText : ManInputDay
    {
        public string OpPracticeText { get; set; }
    }
}
