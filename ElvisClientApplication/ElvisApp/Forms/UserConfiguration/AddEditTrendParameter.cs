using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.UserConfiguration
{
    public partial class AddEditTrendParameter : Form
    {
        #region Variables and Parameters
        private bool hasErrors = false;
        private bool isDirty = false;
        private bool hasLoaded = false;
        private decimal groupCount = 0;
        private ParConfig parConfig;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Create a new instance of the AddEditTrendParameter form.
        /// </summary>
        /// <param name="parConfig">The ParConfig record to edit, pass null if
        /// add new record is required.</param>
        public AddEditTrendParameter(ParConfig parConfig)
        {
            InitializeComponent();
            this.parConfig = parConfig;

            if (this.parConfig != null)
            {
                this.Text = "Edit Trend Parameter";
                grpMain.Text = "Edit Existing Trend Parameter";
                txtFieldName.ReadOnly = true;
                txtFieldName.BackColor = Color.WhiteSmoke;
                PopulateForm();
            }

            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                grpMain.BackColor =
                pnlParameter.BackColor =
                pnlClose.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                grpMain.ForeColor =
                pnlParameter.ForeColor =
                pnlClose.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Fills the form with data.
        /// </summary>
        private void PopulateForm()
        {
            txtFieldName.Text = this.parConfig.ParFieldName;
            txtParameter.Text = this.parConfig.Parameter;
            txtDesc.Text = this.parConfig.ParDesc;

            if (this.parConfig.MinLimit.HasValue)
                numMinLimit.Value = HelperFunctions.GetDecimalFromFloat(this.parConfig.MinLimit.Value);

            if (this.parConfig.MaxLimit.HasValue)
                numMaxLimit.Value = HelperFunctions.GetDecimalFromFloat(this.parConfig.MaxLimit.Value);

            if (this.parConfig.AimTarget.HasValue)
                numAimTarget.Value = HelperFunctions.GetDecimalFromFloat(this.parConfig.AimTarget.Value);

            if (this.parConfig.DisplayMin.HasValue)
                numDisplayMin.Value = HelperFunctions.GetDecimalFromFloat(this.parConfig.DisplayMin.Value);

            if (this.parConfig.DisplayMax.HasValue)
                numDisplayMax.Value = HelperFunctions.GetDecimalFromFloat(this.parConfig.DisplayMax.Value);

            if (this.parConfig.CellWidth.HasValue)
            {
                decimal decCellWidth = HelperFunctions.GetDecimalFromFloat(this.parConfig.CellWidth.Value);
                SetupNumericProperties();

                if (decCellWidth >= numCellWidth.Minimum &&
                    decCellWidth <= numCellWidth.Maximum)
                {
                    numCellWidth.Value = decCellWidth;
                }
                else
                {
                    MessageBox.Show(
                        "Error getting the record from the database.",
                        "Data Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Error("DATA ERROR -- Could not input value into numCellWidth on AddEditTrendParameter form -- PopulateForm() -- AddEditTrendParameter.cs ");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Method to check the cell widths.
        /// Changes the increment on the number pickers
        /// if certain values have been met.
        /// </summary>
        private void SetupNumericProperties()
        {
            if ((numMaxLimit.Value - numMinLimit.Value) < 1)
            {
                ModifyNumericUpDownProperties(numCellWidth, 0.001M, 0.001M, 3);
                ModifyNumericUpDownProperties(numMinLimit, numMinLimit.Minimum, 0.001M, 3);
                ModifyNumericUpDownProperties(numMaxLimit, numMaxLimit.Minimum, 0.001M, 3);
                ModifyNumericUpDownProperties(numAimTarget, numAimTarget.Minimum, 0.001M, 3);
                ModifyNumericUpDownProperties(numDisplayMin, numDisplayMin.Minimum, 0.001M, 3);
                ModifyNumericUpDownProperties(numDisplayMax, numDisplayMax.Minimum, 0.001M, 3);
            }
            else if ((numMaxLimit.Value - numMinLimit.Value) < 5)
            {
                ModifyNumericUpDownProperties(numCellWidth, 0.1M, 0.1M, 1);
                ModifyNumericUpDownProperties(numMinLimit, numMinLimit.Minimum, 0.1M, 1);
                ModifyNumericUpDownProperties(numMaxLimit, numMaxLimit.Minimum, 0.1M, 1);
                ModifyNumericUpDownProperties(numAimTarget, numAimTarget.Minimum, 0.1M, 1);
                ModifyNumericUpDownProperties(numDisplayMin, numDisplayMin.Minimum, 0.1M, 1);
                ModifyNumericUpDownProperties(numDisplayMax, numDisplayMax.Minimum, 0.1M, 1);
            }
            else
            {
                if (numCellWidth.Value < 0.5M)
                {
                    numCellWidth.Value = 0.5M;
                }
                ModifyNumericUpDownProperties(numCellWidth, 0.5M, 0.5M, 1);
                ModifyNumericUpDownProperties(numMinLimit, numMinLimit.Minimum, 1, 0);
                ModifyNumericUpDownProperties(numMaxLimit, numMaxLimit.Minimum, 1, 0);
                ModifyNumericUpDownProperties(numAimTarget, numAimTarget.Minimum, 1, 0);
                ModifyNumericUpDownProperties(numDisplayMin, numDisplayMin.Minimum, 1, 0);
                ModifyNumericUpDownProperties(numDisplayMax, numDisplayMax.Minimum, 1, 0);
            }
        }

        /// <summary>
        /// Modifies the given Numeric Up Down Properties
        /// </summary>
        /// <param name="numUpDown">The Numeric Up Down to modify.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="increment">The amount to increment by.</param>
        /// <param name="decimalPlaces">The number of decimal places.</param>
        private void ModifyNumericUpDownProperties(NumericUpDown numUpDown, 
            decimal min, decimal increment, int decimalPlaces)
        {
            numUpDown.Minimum = min;
            numUpDown.Increment = increment;
            numUpDown.DecimalPlaces = decimalPlaces;
        }

        /// <summary>
        /// Adds a new ParConfig to the database.
        /// </summary>
        /// <returns>True if success, false if failed.</returns>
        private bool AddNewParConfig()
        {
            if (FormIsValid())
            {
                try
                {
                    ParConfig newParConfig = new ParConfig()
                    {
                        ParDesc = txtDesc.Text,
                        Parameter = txtParameter.Text,
                        ParFieldName = txtFieldName.Text,
                        MinLimit = HelperFunctions.GetFloatFromDecimal(numMinLimit.Value),
                        MaxLimit = HelperFunctions.GetFloatFromDecimal(numMaxLimit.Value),
                        AimTarget = HelperFunctions.GetFloatFromDecimal(numAimTarget.Value),
                        DisplayMin = HelperFunctions.GetFloatFromDecimal(numDisplayMin.Value),
                        DisplayMax = HelperFunctions.GetFloatFromDecimal(numDisplayMax.Value),
                        //ActionCode = ActionCode,
                        //ActionGroupNumber = ActionGroupNumber,
                        CellWidth = HelperFunctions.GetFloatFromDecimal(numCellWidth.Value)
                    };

                    EntityHelper.ParConfig.AddNew(newParConfig);
                    this.hasErrors = this.isDirty = false;
                    return true;
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error adding new ParConfig -- AddNewParConfig() -- ",
                        ex);
                }
            }
            this.hasErrors = true;
            return false;
        }

        /// <summary>
        /// Edits the existing ParConfig record with the new values
        /// from the form.
        /// </summary>
        /// <returns>True if success, false if failed.</returns>
        private bool EditExistingParConfig()
        {
            if (FormIsValid())
            {
                try
                {
                    ParConfig newParConfig = new ParConfig()
                    {
                        ParIndex = this.parConfig.ParIndex,
                        Parameter = txtParameter.Text,
                        ParDesc = txtDesc.Text,
                        ParFieldName = txtFieldName.Text,
                        MinLimit = HelperFunctions.GetFloatFromDecimal(numMinLimit.Value),
                        MaxLimit = HelperFunctions.GetFloatFromDecimal(numMaxLimit.Value),
                        AimTarget = HelperFunctions.GetFloatFromDecimal(numAimTarget.Value),
                        DisplayMin = HelperFunctions.GetFloatFromDecimal(numDisplayMin.Value),
                        DisplayMax = HelperFunctions.GetFloatFromDecimal(numDisplayMax.Value),
                        //ActionCode = ActionCode,
                        //ActionGroupNumber = ActionGroupNumber,
                        CellWidth = HelperFunctions.GetFloatFromDecimal(numCellWidth.Value)
                    };

                    EntityHelper.ParConfig.EditExisting(newParConfig);
                    this.hasErrors = this.isDirty = false;
                    return true;
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error editing existing ParConfig -- EditExistingParConfig() -- ",
                        ex);
                }
            }
            this.hasErrors = true;
            return false;
        }

        /// <summary>
        /// Checks to see if the form passes the
        /// validation checks.
        /// </summary>
        /// <returns>True for valid, false for invalid.</returns>
        private bool FormIsValid()
        {
            bool valid = true;

            lblError.Visible = false;
            CommonMethods.HighlightControl(txtFieldName, false);
            CommonMethods.HighlightControl(txtParameter, false);
            CommonMethods.HighlightControl(numMinLimit, false);
            CommonMethods.HighlightControl(numMaxLimit, false);
            CommonMethods.HighlightControl(numDisplayMin, false);
            CommonMethods.HighlightControl(numDisplayMax, false);
            CommonMethods.HighlightControl(numAimTarget, false);
            CommonMethods.HighlightControl(numCellWidth, false);

            if (string.IsNullOrWhiteSpace(txtFieldName.Text))
            {
                CommonMethods.HighlightControl(txtFieldName, true);
                valid = false;//Invalid
                ShowError("Field name required.");
            }
            if (string.IsNullOrWhiteSpace(txtParameter.Text))
            {
                CommonMethods.HighlightControl(txtParameter, true);
                valid = false;//Invalid
                ShowError("Parameter text required.");
            }
            if (numMinLimit.Value >= numMaxLimit.Value)
            {
                CommonMethods.HighlightControl(numMinLimit, true);
                CommonMethods.HighlightControl(numMaxLimit, true);
                valid = false;//Invalid
                ShowError("Min Limit should be less than max.");
            }
            if (numDisplayMin.Value >= numDisplayMax.Value)
            {
                CommonMethods.HighlightControl(numDisplayMin, true);
                CommonMethods.HighlightControl(numDisplayMax, true);
                valid = false;//Invalid
                ShowError("Min Limit should be less than max.");
            }
            if (numMinLimit.Value < numDisplayMin.Value)
            {
                CommonMethods.HighlightControl(numMinLimit, true);
                CommonMethods.HighlightControl(numDisplayMin, true);
                valid = false;//Invalid
                ShowError("Axis Min should be <= Min Limit.");
            }
            if (numMaxLimit.Value > numDisplayMax.Value)
            {
                CommonMethods.HighlightControl(numMaxLimit, true);
                CommonMethods.HighlightControl(numDisplayMax, true);
                valid = false;//Invalid
                ShowError("Axis Max should be >= Max Limit.");
            }
            if (numAimTarget.Value > numMaxLimit.Value ||
                numAimTarget.Value < numMinLimit.Value)
            {
                CommonMethods.HighlightControl(numAimTarget, true);
                valid = false;//Invalid
                ShowError("Aim Target should be within Min and Max Limits.");
            }

            this.groupCount = CalculateGroupCount();
            toolTipGroupCount.SetToolTip(numCellWidth, "Group Count of " + this.groupCount);
            toolTipGroupCount.SetToolTip(lblCellWidth, "Group Count of " + this.groupCount);

            if (groupCount % 1 != 0)//Check to see if it's a whole number
            {
                CommonMethods.HighlightControl(numCellWidth, true);
                valid = false;//Invalid
                ShowError("Group count is not whole number.");
            }
            if (groupCount > 20)
            {
                CommonMethods.HighlightControl(numCellWidth, true);
                valid = false;//Invalid
                ShowError("Group count " + groupCount.ToString("N0") + ". Max 20. Increase Cell Width.");
            }
            if (groupCount < 2)
            {
                CommonMethods.HighlightControl(numCellWidth, true);
                valid = false;//Invalid
                ShowError("Group count less than min of 2. Decrease Cell Width.");
            }

            btnSave.Enabled = valid;
            return valid;//Valid
        }

        /// <summary>
        /// Calculates the group count result from the 
        /// max, min and cellwidth number pickers.
        /// </summary>
        /// <returns>The amount of groups from calculation.</returns>
        private decimal CalculateGroupCount()
        {
            return (numDisplayMax.Value - numDisplayMin.Value) / numCellWidth.Value;
        }

        /// <summary>
        /// Displays the error label on the form
        /// with the given text.
        /// </summary>
        /// <param name="errorText">The text to display in the error.</param>
        private void ShowError(string errorText)
        {
            lblError.Visible = true;
            lblError.Text = errorText;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private void SetDecimalPlaces()
        //{
        //    if ((numMaxLimit.Value - numMinLimit.Value) < 1)
        //    {
        //        numMinLimit.DecimalPlaces = 3;
        //        numMaxLimit.DecimalPlaces = 3;
        //    }
        //}

        /// <summary>
        /// Cancel the form closing event if errors present on form or 
        /// changes have been made but no save operation has occurred.
        /// </summary>
        private void AddEditTrendParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isDirty && !this.hasErrors)
            {
                DialogResult result = MessageBox.Show(
                    "All unsaved changes will be lost. Continue?",
                    "Please Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
            else
            {
                e.Cancel = this.hasErrors;
                this.hasErrors = false;
            }

        }

        /// <summary>
        /// Event handler for a change in text on the textboxes.
        /// </summary>
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
            FormIsValid();
        }

        /// <summary>
        /// Event handler for the numeric up downs value changed.
        /// </summary>
        private void numPicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
            FormIsValid();
            SetupNumericProperties();
        }

        /// <summary>
        /// Event handler for the Save button click event.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.parConfig == null)
            {
                AddNewParConfig();
            }
            else
            {
                if (this.isDirty)
                {
                    EditExistingParConfig();
                }
            }
        }

        /// <summary>
        /// Event handler for the form load event.
        /// </summary>
        private void AddEditTrendParameter_Load(object sender, EventArgs e)
        {
            this.hasLoaded = true;
        }
    }
}
