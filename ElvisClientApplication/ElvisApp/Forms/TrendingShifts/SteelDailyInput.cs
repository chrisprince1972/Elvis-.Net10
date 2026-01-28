using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.TrendingShifts
{
    public partial class SteelDailyInput : Form
    {
        private bool error = false;
        private ManInputDay manInputDay;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public SteelDailyInput(int dayDateIndex = 0)
        {
            InitializeComponent();
            CustomiseColours();
            manInputDay = null;

            if (dayDateIndex > 0)
            {//EDIT
                manInputDay = GetManInputDay(dayDateIndex);
            }

            BindForm();
        }

        private ManInputDay GetManInputDay(int dayDateIndex)
        {
            try
            {
                return EntityHelper.ManInputDay.GetByIndex(dayDateIndex);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetManInputDay() -- Error getting Manual Input Day record from ManInputDay -- ",
                    ex);
            }
            return null;
        }

        private void BindForm()
        {
            cmboOperatingPrac.DataSource = GetOperatingPractices();
            cmboOperatingPrac.ValueMember = "OpPracticeIndex";
            cmboOperatingPrac.DisplayMember = "OpPracticeText";

            dpDate.Value = new DateTime(
                MyDateTime.Now.Year,
                MyDateTime.Now.Month,
                MyDateTime.Now.Day,
                0, 0, 0);

            if (manInputDay != null)
            {//EDIT
                dpDate.Value = manInputDay.DayDate;
                if (manInputDay.BFOutput.HasValue)
                {
                    numBFOutput.Value = HelperFunctions.GetDecimalFromFloat(manInputDay.BFOutput.Value);
                }
                if (manInputDay.OPPracticeIndex.HasValue)
                {
                    cmboOperatingPrac.SelectedValue = manInputDay.OPPracticeIndex;
                }
            }
        }

        private void CustomiseColours()
        {
            this.BackColor =
            pnlMain.BackColor =
            grpMain.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlMain.ForeColor =
            grpMain.ForeColor =
                Settings.Default.ColourText;
        }

        private List<OpPractice> GetOperatingPractices()
        {
            try
            {
                return EntityHelper.OpPractice.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetOperatingPractices() -- Error getting Operating Practices from OpPractice -- ",
                    ex);
            }
            return new List<OpPractice>();
        }

        private bool SaveSteelmakingInput()
        {
            try
            {
                ManInputDay newManInputDay = new ManInputDay()
                {
                    DayDate = dpDate.Value,
                    BFOutput = HelperFunctions.GetFloatFromDecimal(numBFOutput.Value),
                    OPPracticeIndex = HelperFunctions.GetIntSafely(cmboOperatingPrac.SelectedValue)
                };

                ManInputDay existingRecord = EntityHelper.ManInputDay.GetByDate(dpDate.Value);

                if (existingRecord != null)
                {
                    DialogResult result = MessageBox.Show(
                        "Record already exists for the date - " +
                            dpDate.Value.ToShortDateString() +
                        ". Would you like to save and overwrite the existing record?",
                        "Record Already Exists",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information
                        );

                    if (result == DialogResult.Yes)
                    {
                        string errorMessage = EntityHelper.ManInputDay.UpdateExisting(newManInputDay);
                        if (string.IsNullOrWhiteSpace(errorMessage))
                        {
                            return false;//It's all good!
                        }

                        MessageBox.Show(
                            errorMessage, "Error Saving Record",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                    }
                }
                else
                {
                    EntityHelper.ManInputDay.InsertNew(newManInputDay);
                    return false;//It's all good!
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error saving daily manual input for steelmaking calculations -- ", ex);
            }
            return true;//Error Condition
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you wish to save this information?",
                "Confirm Submission",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                this.error = SaveSteelmakingInput();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "All unsaved changes will be lost. Continue?",
                "Please Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.error = true;
            }
        }

        private void SteelDailyInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.error;
            this.error = false;
        }
    }
}
