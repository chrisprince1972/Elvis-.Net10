using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using BusinessLogic.Constants.Trending.Dashboards;

namespace Elvis.Forms.Trending
{
    public partial class DashboardConfig : Form
    {
        #region Variables

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private List<KPIConfig> kpiConfigs = new List<KPIConfig>();
        private bool readOnly = true;
        private bool isAdmin = false;
        private bool dirty = false;
        private bool error = false;

        #endregion Variables

        /// <summary>
        /// Standard constructor for the form.
        /// </summary>
        /// <param name="isAdmin">Is the user admin.</param>
        /// <param name="isKPIAdmin">Is the User a KPIAdmin.</param>
        /// <param name="selectedKPI">Optional parameter to select a KPI on load.</param>
        public DashboardConfig(bool isAdmin, bool isKPIAdmin, KPIConfig selectedKPI = null)
        {
            InitializeComponent();

            this.kpiConfigs = GetKPIConfigs();
            this.isAdmin = isAdmin;
            this.readOnly = !isKPIAdmin;

            if (this.readOnly)
                SetupReadOnly();

            PopulateDropDowns();

            if (selectedKPI != null)//Pre-Select a Node
                treeDashboards.SelectedNode = BuildDashboardTree(selectedKPI);
            else//Default
                BuildDashboardTree();
        }

        /// <summary>
        /// Handles the getting of the KPI Configs.
        /// </summary>
        /// <returns>A list of KPI Configs.</returns>
        private List<KPIConfig> GetKPIConfigs()
        {
            try
            {
                return EntityHelper.KPIConfig.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetKPIConfigs() -- Error getting KPI Configs from database -- ", ex);
            }
            return new List<KPIConfig>();
        }

        /// <summary>
        /// Handles the getting of the Group Configs
        /// for the drop down list.
        /// </summary>
        /// <returns>A list of Group Configs.</returns>
        private List<GroupConfig> GetGroupConfigs()
        {
            try
            {
                return EntityHelper.GroupConfig.GetAllEnabled();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetGroupConfigs() -- Error getting Group Configs from database -- ", ex);
            }
            return new List<GroupConfig>();
        }

        /// <summary>
        /// Handles the getting of the Group Configs
        /// for the drop down list.
        /// </summary>
        /// <returns>A list of Group Configs.</returns>
        private List<KPIActionRule> GetKPIActions()
        {
            try
            {
                return EntityHelper.KPIActionRules.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetKPIActions() -- Error getting KPI Actions from database -- ", ex);
            }
            return new List<KPIActionRule>();
        }

        /// <summary>
        /// Sets up a read only view for the user.
        /// </summary>
        private void SetupReadOnly()
        {
            btnSave.Visible = false;
            btnCancel.Text = "Close";
            numMin.ReadOnly = true;
            numMin.Enabled = false;
            numMax.ReadOnly = true;
            numMax.Enabled = false;
            numDP.ReadOnly = true;
            numDP.Enabled = false;
            chbTrailingZeros.Enabled = false;
            chbShowValue.Enabled = false;
            cmboKPIActions.Enabled = false;
            cmboGroupConfigs.Enabled = false;
            txtTooltip.ReadOnly = true;
            txtTooltip.BackColor = Color.FromKnownColor(KnownColor.Window);
            txtInfo.ReadOnly = true;
            txtInfo.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        /// <summary>
        /// Populates the Drop Downs on the Form.
        /// </summary>
        private void PopulateDropDowns()
        {
            cmboKPIActions.DataSource = GetKPIActions();
            cmboKPIActions.DisplayMember = "KPIActionDescription";
            cmboKPIActions.ValueMember = "KPIActionIndex";

            cmboGroupConfigs.DataSource = GetGroupConfigs();
            cmboGroupConfigs.DisplayMember = "GroupDesc";
            cmboGroupConfigs.ValueMember = "GroupIndex";
        }

        /// <summary>
        /// Builds the Dashboard Tree with the KPI Config Data.
        /// </summary>
        private TreeNode BuildDashboardTree(KPIConfig selectedKPI = null)
        {
            TreeNode nodeToSelect = null;
            if (this.kpiConfigs != null && this.kpiConfigs.Count > 0)
            {
                foreach (DashboardType dashType in
                    Enum.GetValues(typeof(DashboardType)))
                {
                    if (!this.isAdmin && dashType == DashboardType.Test)
                    {//Skip the Test Dashboard if user is not admin
                        continue;
                    }

                    int dashboardNo = Convert.ToInt16(dashType);
                    TreeNode dashboardNode = new TreeNode(dashType.ToString());

                    TreeNode nodeReturned = AddLevel1ToDashboardNode(
                        dashboardNode,
                        dashboardNo,
                        this.kpiConfigs
                            .Where(c => c.Dashboard == dashboardNo && c.KPISubLevel == 0)
                            .ToList(),
                        selectedKPI
                        );

                    if (nodeToSelect == null)
                    {//If node to select has already been populated then ignore.
                        nodeToSelect = nodeReturned;
                    }

                    treeDashboards.Nodes.Add(dashboardNode);
                    dashboardNode.Expand();
                }
            }
            return nodeToSelect;
        }

        /// <summary>
        /// Adds Level 1 KPI's to Root Nodes.
        /// </summary>
        /// <param name="dashboardNode">The Dashboard Node e.g. CMM</param>
        /// <param name="dashboardNo">The Dashboard Number e.g. 1</param>
        /// <param name="level1Configs">The Level 1 KPI configs to add.</param>
        /// <returns>Returns the TreeNode that should be selected.</returns>
        private TreeNode AddLevel1ToDashboardNode(TreeNode dashboardNode, int dashboardNo,
            List<KPIConfig> level1Configs, KPIConfig selectedKPI)
        {
            TreeNode nodeToReturn = null;
            foreach (KPIConfig config in level1Configs)
            {
                TreeNode level1Node = new TreeNode
                    (RemoveEscapedCharacters(config.KPIDescription));

                level1Node.Tag = config;

                TreeNode nodeReturned = AddLevel2ToLevel1Node(
                    level1Node,
                    this.kpiConfigs
                        .Where(c =>
                            c.KPISubLevel > 0 &&
                            c.KPILevel == config.KPILevel &&
                            c.Dashboard == dashboardNo)
                        .ToList(),
                    selectedKPI
                    );

                dashboardNode.Nodes.Add(level1Node);

                if (selectedKPI != null &&
                    config.KPIINdex == selectedKPI.KPIINdex)
                {
                    nodeReturned = level1Node;
                }

                if (nodeToReturn == null)
                {//Only set if the Node has not already been filled.
                    nodeToReturn = nodeReturned;
                }
            }
            return nodeToReturn;
        }

        /// <summary>
        /// Adds Level 2 KPI's to Level 1 Node.
        /// </summary>
        /// <param name="level1Node">The Level 1 Node to add to e.g. Liquid Steel Output</param>
        /// <param name="level2Configs">The Level 2 KPI configs to add.</param>
        /// <returns>Returns the TreeNode that should be selected.</returns>
        private TreeNode AddLevel2ToLevel1Node(TreeNode level1Node, List<KPIConfig> level2Configs,
            KPIConfig selectedKPI)
        {
            TreeNode nodeToReturn = null;
            foreach (KPIConfig config in level2Configs)
            {
                TreeNode level2Node = new TreeNode
                    (RemoveEscapedCharacters(config.KPIDescription));

                level2Node.Tag = config;

                level1Node.Nodes.Add(level2Node);

                if (nodeToReturn == null &&
                    selectedKPI != null &&
                    config.KPIINdex == selectedKPI.KPIINdex)
                {
                    nodeToReturn = level2Node;
                }
            }
            return nodeToReturn;
        }

        /// <summary>
        /// Removes any characters that have been
        /// doubled up for escaping.
        /// </summary>
        /// <param name="text">The Text to check.</param>
        /// <returns>The new Text with removed characters if needed.</returns>
        private string RemoveEscapedCharacters(string text)
        {
            if (text.Contains("&&"))
            {
                return text.Replace("&&", "&");
            }
            return text;
        }

        /// <summary>
        /// Clears the KPI Details Form of data.
        /// </summary>
        private void ClearKPIDetails()
        {
            RemoveEventHandlers();//Need to do this to handle any user changes.
            numMin.Value = 0;
            numMax.Value = 0;
            numDP.Value = 0;
            chbTrailingZeros.Checked = false;
            chbTrailingZeros.Enabled = false;
            txtInfo.Text = "";
            txtTooltip.Text = "";
            cmboKPIActions.SelectedIndex = 0;
            cmboGroupConfigs.SelectedIndex = 0;
            AddEventHandlers();//Need to do this to handle any user changes.
        }

        /// <summary>
        /// Populates the KPI Details form.
        /// </summary>
        /// <param name="selectedConfig">The Selected Info to Populate.</param>
        private void PopulateKPIDetails(KPIConfig selectedConfig)
        {
            RemoveEventHandlers();//Need to do this to handle any user changes.
            if (selectedConfig != null)
            {
                grpKPIConfig.Text = "KPI Configuration - " + selectedConfig.KPIDescription;

                if (selectedConfig.Minimum.HasValue)
                {
                    numMin.Value = HelperFunctions.GetDecimalFromFloat(selectedConfig.Minimum.Value);
                }
                if (selectedConfig.Maximum.HasValue)
                {
                    numMax.Value = HelperFunctions.GetDecimalFromFloat(selectedConfig.Maximum.Value);
                }

                if (!string.IsNullOrWhiteSpace(selectedConfig.StringFormat))
                {
                    char dpChar = '#';//Hash implies show value if exists.
                    string strDPCount = "";

                    if (selectedConfig.StringFormat.Contains('.'))
                    {
                        strDPCount = selectedConfig.StringFormat.Split('.').Last();

                        if (strDPCount.Contains("0"))
                        {
                            dpChar = '0';//Zero implies always show value, even if zero
                            chbTrailingZeros.Checked = true;
                        }

                        numDP.Value = strDPCount.Count(f => f == dpChar);
                    }
                    else
                    {
                        numDP.Value = 0;
                    }
                }

                chbShowValue.Checked = selectedConfig.ShowValue;
                cmboKPIActions.SelectedIndex = 0;
                ShowTrendGroup(false);

                if (selectedConfig.KPIActionIndex.HasValue)
                {
                    cmboKPIActions.SelectedValue = selectedConfig.KPIActionIndex;

                    if (selectedConfig.KPIActionIndex == 1)
                    {
                        ShowTrendGroup(true);

                        if (selectedConfig.KPIActionGroup.HasValue)
                        {
                            cmboGroupConfigs.SelectedValue = selectedConfig.KPIActionGroup;
                        }
                    }
                }

                txtTooltip.Text = selectedConfig.ToolTip;
                txtInfo.Text = selectedConfig.KPIInfo;
                numMin.DecimalPlaces = HelperFunctions.GetIntFromDecimal(numDP.Value);
                numMax.DecimalPlaces = HelperFunctions.GetIntFromDecimal(numDP.Value);

                if (!this.readOnly && numDP.Value > 0)
                    chbTrailingZeros.Enabled = true;

                GenerateExamples();
            }
            AddEventHandlers();//Need to do this to handle any user changes.
        }

        /// <summary>
        /// Shows or hides the Trend Group combobox.
        /// </summary>
        /// <param name="show">True for show, false for hide.</param>
        private void ShowTrendGroup(bool show)
        {
            cmboKPIActions.Width = 158;
            if (show)
            {
                cmboKPIActions.Width = 94;
            }
            lblTrendGroup.Visible = show;
            cmboGroupConfigs.Visible = show;
        }

        /// <summary>
        /// Saves the changes to the currently selected
        /// KPI Config.
        /// </summary>
        private bool SaveKPIChanges()
        {
            if (treeDashboards.SelectedNode != null && treeDashboards.SelectedNode.Tag != null &&
                treeDashboards.SelectedNode.Tag is KPIConfig)
            {
                KPIConfig selectedConfig = (KPIConfig)treeDashboards.SelectedNode.Tag;
                //Need to do this to stop any decimals that shouldn't be there.
                selectedConfig.Minimum = HelperFunctions.GetFloatFromDecimal(
                    Math.Round(numMin.Value, HelperFunctions.GetIntFromDecimal(numDP.Value))
                    );
                selectedConfig.Maximum = HelperFunctions.GetFloatFromDecimal(
                    Math.Round(numMax.Value, HelperFunctions.GetIntFromDecimal(numDP.Value))
                    );
                selectedConfig.StringFormat = GenerateStringFormat();
                selectedConfig.ShowValue = chbShowValue.Checked;
                selectedConfig.KPIActionGroup = null;

                if (HelperFunctions.GetIntSafely(cmboKPIActions.SelectedValue) == 1)
                {
                    selectedConfig.KPIActionGroup = HelperFunctions.GetIntSafely(
                        cmboGroupConfigs.SelectedValue);
                }

                selectedConfig.ToolTip = txtTooltip.Text;
                selectedConfig.KPIInfo = txtInfo.Text;

                try
                {
                    if (EntityHelper.KPIConfig.Update(selectedConfig))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR -- SaveKPIChanges() -- Error updating KPI Config -- ", ex);
                }
            }
            return false;//ERROR
        }

        /// <summary>
        /// Adds the Event Handler to the controls on
        /// the form.
        /// </summary>
        private void AddEventHandlers()
        {
            numMin.ValueChanged += new EventHandler(numMin_ValueChanged);
            numMax.ValueChanged += new EventHandler(numMax_ValueChanged);
            numDP.ValueChanged += new EventHandler(numDP_ValueChanged);
            chbTrailingZeros.CheckedChanged += new EventHandler(chbTrailingZeros_CheckedChanged);
            chbShowValue.CheckedChanged += new EventHandler(chbShowValue_CheckedChanged);
            txtInfo.TextChanged += new EventHandler(txtInfo_TextChanged);
            cmboKPIActions.SelectedValueChanged += new EventHandler(cmboKPIActions_SelectedValueChanged);
            cmboGroupConfigs.SelectedValueChanged += new EventHandler(cmboGroupConfigs_SelectedValueChanged);
            txtTooltip.TextChanged += new EventHandler(txtTooltip_TextChanged);
        }

        /// <summary>
        /// Removes the Event Handler to the controls on
        /// the form.
        /// </summary>
        private void RemoveEventHandlers()
        {
            numMin.ValueChanged -= new EventHandler(numMin_ValueChanged);
            numMax.ValueChanged -= new EventHandler(numMax_ValueChanged);
            numDP.ValueChanged -= new EventHandler(numDP_ValueChanged);
            chbTrailingZeros.CheckedChanged -= new EventHandler(chbTrailingZeros_CheckedChanged);
            chbShowValue.CheckedChanged -= new EventHandler(chbShowValue_CheckedChanged);
            txtInfo.TextChanged -= new EventHandler(txtInfo_TextChanged);
            cmboKPIActions.SelectedValueChanged -= new EventHandler(cmboKPIActions_SelectedValueChanged);
            cmboGroupConfigs.SelectedValueChanged -= new EventHandler(cmboGroupConfigs_SelectedValueChanged);
            txtTooltip.TextChanged -= new EventHandler(txtTooltip_TextChanged);
        }

        /// <summary>
        /// Builds the example data boxes to display
        /// to the user what the data will look like.
        /// </summary>
        private void GenerateExamples()
        {
            int xStartPos = 8;
            int yStartPos = 18;

            grpExample.Controls.Clear();

            AddExampleDataBox(1.123456789, new Point(xStartPos, yStartPos), true);
            AddExampleDataBox(2.000000000, new Point(xStartPos, yStartPos + Settings.Default.DashboardRowHeight + 2), true);
            AddExampleDataBox(3.123456789, new Point(xStartPos + Settings.Default.DashboardSingleBoxWidth + 2, yStartPos), false);
            AddExampleDataBox(4.000000000, new Point(xStartPos + Settings.Default.DashboardSingleBoxWidth + 2, yStartPos + Settings.Default.DashboardRowHeight + 2), false);
        }

        /// <summary>
        /// Generates an individual data box example.
        /// </summary>
        /// <param name="dataValue">The Value to Place in the Box</param>
        /// <param name="location">The location of the box in the container.</param>
        /// <param name="isWithinLimit">Is the box within limit e.g. Green or Red.</param>
        private void AddExampleDataBox(double dataValue, Point location, bool isWithinLimit)
        {
            Panel singleDataBox = new Panel()
            {
                Height = Settings.Default.DashboardRowHeight,
                Width = Settings.Default.DashboardSingleBoxWidth,
                Padding = Settings.Default.DashboardBoxPadding
            };

            Label lbl = new Label()
            {
                Font = Settings.Default.DashboardBoxFont,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Colours.GetKPIDataBackground(isWithinLimit),
                ForeColor = Colours.GetKPIDataForeColour(isWithinLimit),
                BorderStyle = BorderStyle.FixedSingle,
                Text = dataValue.ToString(GenerateStringFormat())
            };

            if (!chbShowValue.Checked)
            {//Hide Value
                lbl.Text = "";
            }

            toolTips.SetToolTip(singleDataBox, txtTooltip.Text + GetAdditionalToolTipInfo());

            singleDataBox.Controls.Add(lbl);
            lbl.Dock = DockStyle.Fill;

            grpExample.Controls.Add(singleDataBox);
            singleDataBox.Location = location;
        }

        /// <summary>
        /// Gets any additional info for the tooltips.
        /// </summary>
        /// <returns>Additional text as a string or empty.</returns>
        private string GetAdditionalToolTipInfo()
        {
            if (cmboGroupConfigs.Visible && 
                HelperFunctions.GetIntSafely(cmboKPIActions.SelectedValue) == 1 &&
                cmboGroupConfigs.SelectedItem is GroupConfig)
            {
                GroupConfig groupConfig = cmboGroupConfigs.SelectedItem as GroupConfig;
                if (groupConfig != null)
                {
                    return " for " + groupConfig.GroupDesc;
                }
            }
            return "";
        }

        /// <summary>
        /// Generates the formatting string for the data
        /// depending on the selections of the user.
        /// </summary>
        /// <returns>The format string.</returns>
        private string GenerateStringFormat()
        {
            char decChars = '#';
            string formatString = "0";

            if (chbTrailingZeros.Checked)
                decChars = '0';

            for (int i = 0; i < numDP.Value; i++)
            {
                if (i == 0)
                    formatString += '.';
                formatString += decChars;
            }

            return formatString;
        }

        /// <summary>
        /// Checks with the user if they want to save or not.
        /// </summary>
        /// <returns>Return a true if they want to cancel any operations,
        /// return false to continue.</returns>
        private bool CheckIfUserWantsToSave()
        {
            DialogResult result = MessageBox.Show(
                "Would you like to save your changes? Any changes will be lost if you click No.",
                "Please Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel)
            {
                return true;//Cancel Operation
            }
            else if (result == DialogResult.Yes)
            {
                if (SaveKPIChanges())
                {
                    this.dirty = false;
                }
                else
                {
                    MessageBox.Show(
                        "There has been an error saving your changes. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;//Cancel Operation
                }
            }
            else if (result == DialogResult.No)
            {
                this.dirty = false;
            }
            return false;
        }

        #region Events

        /// <summary>
        /// Event handler for the change of
        /// item selection on the treeview.
        /// </summary>
        private void treeDashboards_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearKPIDetails();
            if (e.Node != null && e.Node.Tag != null &&
                e.Node.Tag is KPIConfig)
            {
                pnlKPIDetails.BringToFront();
                KPIConfig selectedConfig = (KPIConfig)e.Node.Tag;
                PopulateKPIDetails(selectedConfig);
            }
            else
            {
                lblPleaseSelect.BringToFront();
                grpKPIConfig.Text = "KPI Configuration";
            }
        }

        private void chbTrailingZeros_CheckedChanged(object sender, EventArgs e)
        {
            GenerateExamples();
            this.dirty = true;
        }

        private void chbShowValue_CheckedChanged(object sender, EventArgs e)
        {
            GenerateExamples();
            this.dirty = true;
        }

        private void numDP_ValueChanged(object sender, EventArgs e)
        {
            GenerateExamples();

            chbTrailingZeros.Enabled = false;
            if (!this.readOnly && numDP.Value > 0)
                chbTrailingZeros.Enabled = true;

            numMin.DecimalPlaces = HelperFunctions.GetIntFromDecimal(numDP.Value);
            numMax.DecimalPlaces = HelperFunctions.GetIntFromDecimal(numDP.Value);

            this.dirty = true;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            this.dirty = true;
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            this.dirty = true;
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {
            this.dirty = true;
        }

        private void cmboKPIActions_SelectedValueChanged(object sender, EventArgs e)
        {
            this.dirty = true;
            ShowTrendGroup(false);

            if (HelperFunctions.GetIntSafely(cmboKPIActions.SelectedValue) == 1)
            {
                ShowTrendGroup(true);
            }
        }

        private void txtTooltip_TextChanged(object sender, EventArgs e)
        {
            this.dirty = true;
            GenerateExamples();
        }

        private void cmboGroupConfigs_SelectedValueChanged(object sender, EventArgs e)
        {
            this.dirty = true;
        }

        private void treeDashboards_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (this.dirty && !this.readOnly)
            {
                e.Cancel = CheckIfUserWantsToSave();
            }
        }

        /// <summary>
        /// Save button click event handler.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dirty)
            {
                if (SaveKPIChanges())
                {
                    this.error = false;
                    this.dirty = false;
                }
                else
                {
                    this.error = true;
                }
            }
        }

        /// <summary>
        /// Checks for any conditions under which we
        /// need to cancel the form closing event.
        /// </summary>
        private void DashboardConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.readOnly)
            {
                if (this.dirty)
                {
                    e.Cancel = CheckIfUserWantsToSave();
                }
                else if (this.error)
                {
                    MessageBox.Show(
                        "There has been an error saving your changes. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
        #endregion Events
    }
}
