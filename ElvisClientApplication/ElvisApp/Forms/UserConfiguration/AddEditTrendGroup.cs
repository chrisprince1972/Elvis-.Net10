using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.UserConfiguration
{
    public partial class AddEditTrendGroup : Form
    {
        #region Variables and Parameters
        private bool hasErrors = false;
        private bool isDirty = false;
        private bool hasLoaded = false;
        private TrendGrouping trendGroup;
        private GroupConfig groupConfig;
        private List<ParConfig> allParameters;
        private List<ParConfig> groupParameters;
        private List<GroupHighlight> groupHighlights;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Create a new instance of the AddEditTrendGroup form.
        /// </summary>
        /// <param name="trendGroup">The TrendGrouping record to edit, pass null if
        /// add new record is required.</param>
        public AddEditTrendGroup(TrendGrouping trendGroup)
        {
            InitializeComponent();
            this.trendGroup = trendGroup;

            GetGroupHighlights();
            PopulateGroupHighlights();

            if (this.trendGroup != null)
            {
                this.groupConfig = GetGroupConfig(trendGroup.GroupIndex);
                if (this.groupConfig != null)
                {
                    PopulateFormData();
                }
            }

            GetAllParameters();
            GetGroupParameters();
            PopulateAllParameters();
            PopulateGroupParameters();

            SetToolTips();
            CustomiseColours();
        }

        /// <summary>
        /// Gets the specific Group Config related to
        /// the index passed in.
        /// </summary>
        /// <param name="groupIndex">The Group Index of the object.</param>
        /// <returns>A GroupConfig data object.</returns>
        private GroupConfig GetGroupConfig(int groupIndex)
        {
            this.groupConfig = new GroupConfig();
            try
            {
                this.groupConfig = EntityHelper.GroupConfig.GetByID(groupIndex);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting GroupConfig data for AddEditTrendGroup -- GetGroupConfig() -- ",
                    ex);
            }
            return this.groupConfig;
        }

        /// <summary>
        /// Fills the general part of the form with data.
        /// </summary>
        private void PopulateFormData()
        {
            chbEnabled.Checked = false;
            this.Text = "Edit Trend Group";
            grpMain.Text = "Edit Existing Trend Group";

            if (this.groupConfig != null)
            {
                txtGroupDesc.Text = this.groupConfig.GroupDesc;
                //cmboGroupHighlight.SelectedItem = this.groupConfig.GroupHighlight;
                cmboGroupHighlight.SelectedValue = this.groupConfig.GroupHighlight.HighlightID;
                if (this.groupConfig.DisplayCode.HasValue &&
                    this.groupConfig.DisplayCode == 1)
                {
                    chbEnabled.Checked = true;
                }
            }
        }

        /// <summary>
        /// Populates the Group Highlight Combobox with data.
        /// </summary>
        private void PopulateGroupHighlights()
        {
            if (this.groupHighlights != null &&
                this.groupHighlights.Count > 0)
            {
                cmboGroupHighlight.DataSource = this.groupHighlights;
                cmboGroupHighlight.DisplayMember = "Description";
                cmboGroupHighlight.ValueMember = "HighlightID";
            }
        }

        /// <summary>
        /// Populates the Group Parameters List box with data.
        /// </summary>
        private void PopulateGroupParameters()
        {
            lstParameters.DataSource = null;
            lstParameters.Items.Clear();

            if (this.groupParameters != null)
            {
                lstParameters.DataSource = this.groupParameters;
                lstParameters.DisplayMember = "ParFieldName";
                lstParameters.ValueMember = "ParIndex";
            }
        }

        /// <summary>
        /// Populates the All Parameters List box with data.
        /// </summary>
        private void PopulateAllParameters()
        {
            lstAllParameters.DataSource = null;
            lstAllParameters.Items.Clear();
            if (this.allParameters != null)
            {
                lstAllParameters.DataSource = this.allParameters
                    .Except(this.groupParameters)
                    .ToList();//Remove the parameters already in the group
                lstAllParameters.DisplayMember = "ParFieldName";
                lstAllParameters.ValueMember = "ParIndex";
            }
        }

        /// <summary>
        /// Gets all the parameters to populate
        /// </summary>
        private void GetAllParameters()
        {
            this.allParameters = new List<ParConfig>();
            try
            {
                this.allParameters = EntityHelper.ParConfig.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting parameter data for AddEditTrendGroup -- GetAllParameters() -- ",
                    ex);
            }
        }

        /// <summary>
        /// Gets all the Group highlights.
        /// </summary>
        private void GetGroupHighlights()
        {
            this.groupHighlights = new List<GroupHighlight>();
            try
            {
                this.groupHighlights = EntityHelper.GroupHighlight.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting Group Highlight data for AddEditTrendGroup -- GetGroupHighlights() -- ",
                    ex);
            }
        }

        /// <summary>
        /// Populates the list of groupParameters, which 
        /// contains a list of parameters associated
        /// with this particular Group Config.
        /// </summary>
        private void GetGroupParameters()
        {
            this.groupParameters = new List<ParConfig>();
            if (this.allParameters != null &&
                this.groupConfig != null)
            {
                List<int> groupParameterIDs = new List<int>();

                if (this.groupConfig.Par1.HasValue)
                    groupParameterIDs.Add(this.groupConfig.Par1.Value);
                if (this.groupConfig.Par2.HasValue)
                    groupParameterIDs.Add(this.groupConfig.Par2.Value);
                if (this.groupConfig.Par3.HasValue)
                    groupParameterIDs.Add(this.groupConfig.Par3.Value);
                if (this.groupConfig.Par4.HasValue)
                    groupParameterIDs.Add(this.groupConfig.Par4.Value);
                if (this.groupConfig.Par5.HasValue)
                    groupParameterIDs.Add(this.groupConfig.Par5.Value);
                if (this.groupConfig.Par6.HasValue)
                    groupParameterIDs.Add(this.groupConfig.Par6.Value);

                //Only get the Parameters that are associated with the Group Config.
                if (groupParameterIDs.Count > 0)
                {
                    //Filtering a list of Ints (Parameter IDs) with another list of objects (Full list of Parameters).
                    this.groupParameters = this.allParameters
                        .Where(a => groupParameterIDs
                            .Any(p => p.Equals(a.ParIndex)))
                        .OrderBy(o => groupParameterIDs.IndexOf(o.ParIndex))
                        .ToList();
                }
            }
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                grpMain.BackColor =
                pnlGroup.BackColor =
                grpParameters.BackColor =
                grpAllParameters.BackColor =
                pnlClose.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                grpMain.ForeColor =
                pnlGroup.ForeColor =
                grpParameters.ForeColor =
                grpAllParameters.ForeColor =
                pnlClose.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Checks to see if the form passes the
        /// validation checks. Sets an error label if not.
        /// </summary>
        /// <returns>True for valid, false for invalid.</returns>
        private bool FormIsValid()
        {
            bool valid = true;

            lblError.Visible = false;
            CommonMethods.HighlightControl(txtGroupDesc, false);
            CommonMethods.HighlightControl(lstParameters, false);

            if (string.IsNullOrWhiteSpace(txtGroupDesc.Text))
            {
                CommonMethods.HighlightControl(txtGroupDesc, true);
                valid = false;//Invalid
                ShowError("Group description required.");
            }
            if (lstParameters.Items.Count < 1)
            {
                CommonMethods.HighlightControl(lstParameters, true);
                valid = false;//Invalid
                ShowError("At least 1 parameter must be present.");
            }

            btnSave.Enabled = valid;
            return valid;
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

        /// <summary>
        /// Gives the controls on the form tool tips.
        /// </summary>
        private void SetToolTips()
        {
            toolTip1.SetToolTip(pbDescInfo, "Group description. Max 100 characters.");

            toolTip1.SetToolTip(pbHighlightInfo, 
                "Defaults the group to the selected highlight value on the Trending form.");

            toolTip1.SetToolTip(pbParamInfo, 
                "The right hand list displays the parameters that " + Environment.NewLine + 
                "have been added to the group. The left hand list displays " + Environment.NewLine +
                "the parameters that can be added to the group. " + Environment.NewLine +
                "Use the arrow buttons (or double click) to add/remove parameters from the " + Environment.NewLine +
                "right hand list to get the desired result. " + Environment.NewLine + Environment.NewLine +  
                "A maximum of 6 parameters per Group."
                );

            toolTip1.SetToolTip(pbEnabledInfo, "Display the Group on the Trending form.");
        }

        /// <summary>
        /// Gets the selected Paramter from the list given.
        /// </summary>
        /// <param name="lst">The List box to obtain the selected par from.</param>
        /// <returns>A ParConfig object.</returns>
        private ParConfig GetSelectedPar(ListBox lst)
        {
            if (lst.SelectedItem != null)
            {
                return (ParConfig)lst.SelectedItem;
            }
            return null;
        }

        /// <summary>
        /// Edits the existing GroupConfig record with the new values
        /// from the form.
        /// </summary>
        /// <returns>True if success, false if failed.</returns>
        private bool EditExistingGroupConfig()
        {
            if (FormIsValid() && this.groupConfig != null)
            {
                try
                {
                    GroupConfig newGroupConfig = new GroupConfig()
                    {
                        GroupIndex = this.groupConfig.GroupIndex,
                        GroupDesc = txtGroupDesc.Text,
                        DisplayCode = GetDisplayCode(),
                        Par1 = GetParameter(1),
                        Par2 = GetParameter(2),
                        Par3 = GetParameter(3),
                        Par4 = GetParameter(4),
                        Par5 = GetParameter(5),
                        Par6 = GetParameter(6),
                        DefaultHighlight = Convert.ToInt32(cmboGroupHighlight.SelectedValue)
                    };

                    EntityHelper.GroupConfig.EditExisting(newGroupConfig);
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
        /// Adds a new GroupConfig to the database.
        /// </summary>
        /// <returns>True if success, false if failed.</returns>
        private bool AddNewGroupConfig()
        {
            if (FormIsValid())
            {
                try
                {
                    GroupConfig newGroupConfig = new GroupConfig()
                    {
                        GroupDesc = txtGroupDesc.Text,
                        DisplayCode = GetDisplayCode(),
                        GroupSort = GetGroupSort(),
                        Par1 = GetParameter(1),
                        Par2 = GetParameter(2),
                        Par3 = GetParameter(3),
                        Par4 = GetParameter(4),
                        Par5 = GetParameter(5),
                        Par6 = GetParameter(6),
                        DefaultHighlight = Convert.ToInt32(cmboGroupHighlight.SelectedValue)
                    };

                    EntityHelper.GroupConfig.AddNew(newGroupConfig);
                    this.hasErrors = this.isDirty = false;
                    return true;
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error adding new GroupConfig -- AddNewGroupConfig() -- ",
                        ex);
                }
            }
            this.hasErrors = true;
            return false;
        }

        /// <summary>
        /// Gets the existing highest group sort and 
        /// adds a value to make the new record the last
        /// in the sort order.
        /// </summary>
        /// <returns>A group sort as an int or 999 as default if it fails.</returns>
        private int? GetGroupSort()
        {
            try
            {
                //Return a new group sort at the bottom of the list.
                return EntityHelper.GroupConfig.GetHighestGroupSort() + 100;
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting max group sort from database -- GetGroupSort() -- ",
                    ex);
            }
            return 999;//Default
        }

        /// <summary>
        /// Gets a parameter from the list of selected paramters
        /// and passes back the ParIndex property.
        /// </summary>
        /// <param name="parNo">The parNo in the list of parameters.</param>
        /// <returns>An int representing a ParConfig ParIndex property.</returns>
        private int? GetParameter(int parNo)
        {
            if (lstParameters.Items.Count >= parNo)
            {
                //Gets the index from the list of selected parameters.
                return ((ParConfig)lstParameters.Items[parNo - 1]).ParIndex;
            }
            return null;
        }

        /// <summary>
        /// Gets the display code from the state of the 
        /// Enabled checkbox.
        /// </summary>
        /// <returns>An int representing Enabled or Disabled.</returns>
        private int GetDisplayCode()
        {
            if (chbEnabled.Checked)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Event handler for the list boxes on the form.
        /// </summary>
        private void lstBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRightToLeft.Enabled = false;
            btnLeftToRight.Enabled = false;

            ListBox lb = (ListBox)sender;
            if (lb.Name.Equals("lstAllParameters") &&
                lb.SelectedIndex != -1)
            {
                lstParameters.ClearSelected();
                if (lstParameters.Items.Count < 6)
                    btnLeftToRight.Enabled = true;
            }
            else if (lb.Name.Equals("lstParameters") &&
                     lb.SelectedIndex != -1)
            {
                lstAllParameters.ClearSelected();
                if (lstParameters.Items.Count > 0)
                    btnRightToLeft.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for the removal of an item from the 
        /// Group Parameters list to the All Parameters List.
        /// Right to Left button.
        /// </summary>
        private void btnRightToLeft_Click(object sender, EventArgs e)
        {
            if (this.groupParameters != null)
            {
                ParConfig selectedPar = GetSelectedPar(lstParameters);
                if (selectedPar != null)
                {
                    this.groupParameters.Remove(selectedPar);
                    PopulateGroupParameters();
                    PopulateAllParameters();
                    lstAllParameters.SelectedItem = selectedPar;
                    FormIsValid();
                    if (this.hasLoaded)
                    {
                        this.isDirty = true;
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the removal of an item from the 
        /// All Parameters list to the Group Parameters List.
        /// Left to Right button.
        /// </summary>
        private void btnLeftToRight_Click(object sender, EventArgs e)
        {
            if (this.groupParameters != null)
            {
                ParConfig selectedPar = GetSelectedPar(lstAllParameters);
                if (selectedPar != null)
                {
                    this.groupParameters.Add(selectedPar);
                    PopulateGroupParameters();
                    PopulateAllParameters();
                    lstParameters.SelectedItem = selectedPar;
                    FormIsValid();
                    if (this.hasLoaded)
                    {
                        this.isDirty = true;
                    }
                }
            }
        }

        /// <summary>
        /// Text changed event handler for the Group Desc
        /// textbox.
        /// </summary>
        private void txtGroupDesc_TextChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
            FormIsValid();
        }

        /// <summary>
        /// Save Button click event handler.
        /// Saves new or edits existing records.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.groupConfig == null)
            {
                AddNewGroupConfig();
            }
            else
            {
                if (this.isDirty)
                {
                    EditExistingGroupConfig();
                }
            }
        }

        /// <summary>
        /// Cancel the form closing event if errors present on form or 
        /// changes have been made but no save operation has occurred.
        /// </summary>
        private void AddEditTrendGroup_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Double Click event handler for lstParameters.
        /// Does the same as btnRightToLeft click event.
        /// </summary>
        private void lstParameters_DoubleClick(object sender, EventArgs e)
        {
            btnRightToLeft.PerformClick();
        }

        /// <summary>
        /// Double Click event handler for lstAllParameters.
        /// Does the same as btnLeftToRight click event.
        /// </summary>
        private void lstAllParameters_DoubleClick(object sender, EventArgs e)
        {
            btnLeftToRight.PerformClick();
        }

        /// <summary>
        /// Delete button down event handler for lstParameters.
        /// Does the same as btnRightToLeft click event.
        /// </summary>
        private void lstParameters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRightToLeft.PerformClick();
            }
        }

        /// <summary>
        /// Event handler for the form load of the form.
        /// </summary>
        private void AddEditTrendGroup_Load(object sender, EventArgs e)
        {
            this.hasLoaded = true;
        }

        /// <summary>
        /// Event handler for the Enabled Checkbox.
        /// Allows the form to know something has changed
        /// and saving is required.
        /// </summary>
        private void chbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
        }

        /// <summary>
        /// Event handler for the Highlight Combobox.
        /// Allows the form to know something has changed
        /// and saving is required.
        /// </summary>
        private void cmboGroupHighlight_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                this.isDirty = true;
            }
        }
    }
}
