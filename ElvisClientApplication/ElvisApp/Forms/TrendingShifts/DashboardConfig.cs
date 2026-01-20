using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.TrendingShifts;
using BusinessLogic.Models.ViewModels.TrendingShifts;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elvis.Forms.TrendingShifts
{
    public partial class DashboardConfig : Form
    {
        #region Variables

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool readOnly = true;
        private bool Admin = false;
        private bool dirty = false;
        private bool error = false;

        private KpiConfigShiftDisplay Model { get; set; }
        #endregion Variables

        /// <summary>
        /// Standard constructor for the form.
        /// </summary>
        /// <param name="isAdmin">Is the user admin.</param>
        /// <param name="isKPIAdmin">Is the User a KPIAdmin.</param>
        /// <param name="selectedKPI">Optional parameter to select a KPI on 
        /// load.</param>
        public DashboardConfig(bool admin, bool kpiAdmin, 
            KpiConfigShiftWrapper selectedKPI = null)
        {
            InitializeComponent();
            try
            {
                Model =
                    new KpiConfigShiftDisplay(
                        HelperFunctions.GetElvisSettings());
                Admin = admin;
                readOnly = !kpiAdmin;

                if (readOnly)
                    SetupReadOnly();

                PopulateDropDowns();

                if (selectedKPI != null)
                {
                    treeDashboards.SelectedNode = 
                        BuildDashboardTree(selectedKPI);
                }
                else
                {
                    BuildDashboardTree();
                }
            }
            catch (Exception e)
            {
                HandleException("Error displaying configurations. ", e);
            }
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
            cmboKPIActions.DataSource = Model.KpiActions;
            cmboKPIActions.DisplayMember = "KPIActionDescription";
            cmboKPIActions.ValueMember = "KPIActionIndex";

            cmboGroupConfigs.DataSource = Model.GroupConfigs;
            cmboGroupConfigs.DisplayMember = "GroupDesc";
            cmboGroupConfigs.ValueMember = "GroupIndex";
        }

        /// <summary>
        /// Builds the Dashboard Tree with the KPI Config Data.
        /// </summary>
        private TreeNode BuildDashboardTree(KpiConfigShiftWrapper selectedKPI = null)
        {
            TreeNode nodeToSelect = null;
            if (Model != null)
            {
                foreach (DashboardType dashType in
                    Enum.GetValues(typeof(DashboardType)))
                {
                    if (Admin || dashType != DashboardType.Test)
                    {
                        
                        TreeNode dashboardNode = new TreeNode(dashType.ToString());
                        

                        TreeNode nodeReturned = AddLevel1ToDashboardNode(
                            dashboardNode, dashType, 
                            Model.GetTopLevelConfigurations(dashType),
                            selectedKPI);

                        if (nodeToSelect == null)
                        {//If node to select has already been populated then ignore.
                            nodeToSelect = nodeReturned;
                        }

                        treeDashboards.Nodes.Add(dashboardNode);
                        dashboardNode.Expand();
                    }
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
        private TreeNode AddLevel1ToDashboardNode(TreeNode dashboardNode,
            DashboardType dashboard,
            IEnumerable<KpiConfigShiftWrapper> level1Configs, KpiConfigShiftWrapper selectedKPI)
        {
            TreeNode nodeToReturn = null;
            foreach (KpiConfigShiftWrapper config in level1Configs)
            {
                TreeNode level1Node = new TreeNode
                    (RemoveEscapedCharacters(config.Description));

                level1Node.Tag = config;

                TreeNode nodeReturned = AddLevel2ToLevel1Node(
                    level1Node,
                    Model.GetSubLevelConfigurations(dashboard, config.Level),
                    selectedKPI
                    );

                dashboardNode.Nodes.Add(level1Node);

                if (selectedKPI != null &&
                    config.Index == selectedKPI.Index)
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
        private TreeNode AddLevel2ToLevel1Node(TreeNode level1Node, 
            IEnumerable<KpiConfigShiftWrapper> level1Configs,
            KpiConfigShiftWrapper selectedKPI)
        {
            TreeNode nodeToReturn = null;
            foreach (KpiConfigShiftWrapper config in level1Configs)
            {
                TreeNode level2Node = new TreeNode
                    (RemoveEscapedCharacters(config.Description));

                level2Node.Tag = config;

                level1Node.Nodes.Add(level2Node);

                if (nodeToReturn == null &&
                    selectedKPI != null &&
                    config.Index == selectedKPI.Index)
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
        private void PopulateKPIDetails(KpiConfigShiftWrapper selectedConfig)
        {
            RemoveEventHandlers();//Need to do this to handle any user changes.
            if (selectedConfig != null)
            {
                grpKPIConfig.Text = "KPI Configuration - " + selectedConfig.Description;

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

                if (selectedConfig.Action != null)
                {
                    cmboKPIActions.SelectedValue = (int)selectedConfig.Action.Index;

                    if (selectedConfig.Action.Index == DashboardActionType.Trending)
                    {
                        ShowTrendGroup(true);

                        if (selectedConfig.Action.Group != null)
                        {
                            cmboGroupConfigs.SelectedValue = selectedConfig.Action.Group.GroupIndex;
                        }
                    }
                }

                txtTooltip.Text = selectedConfig.ToolTip;
                txtInfo.Text = selectedConfig.Info;
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

        private float RemoveDecimals(decimal number, decimal decimalplaces)
        {
            return HelperFunctions.GetFloatFromDecimal(
                Math.Round(number, HelperFunctions.GetIntFromDecimal(numDP.Value)));
        }

        /// <summary>
        /// Saves the changes to the currently selected
        /// KPI Config.
        /// </summary>
        private bool SaveKPIChanges()
        {
            bool returnValue = false;
            var selectedConfiguration = 
                treeDashboards.SelectedNode.Tag as KpiConfigShiftWrapper;
            if (treeDashboards.SelectedNode != null &&
                selectedConfiguration != null)
            {
                //Need to do this to stop any decimals that shouldn't be there.
                selectedConfiguration.Minimum = RemoveDecimals(numMin.Value, numDP.Value);
                selectedConfiguration.Maximum = RemoveDecimals(numMax.Value, numDP.Value);
                selectedConfiguration.StringFormat = GenerateStringFormat();
                selectedConfiguration.ShowValue = chbShowValue.Checked;
                selectedConfiguration.ToolTip = txtTooltip.Text;
                selectedConfiguration.Info = txtInfo.Text;
                selectedConfiguration.Action = GetKpiAction();

                try
                {
                    using (TrendSchemaEntities ctx = new TrendSchemaEntities(
                        EntityHelper.ElvisDBSettings.ConnectionString))
                    {
                        returnValue = selectedConfiguration.Update(ctx);
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR -- SaveKPIChanges() -- Error updating KPI Config -- ", ex);
                }
            }
            return returnValue;
        }

        private KpiAction GetKpiAction()
        {
            GroupConfig gf = null;

            if (HelperFunctions.GetIntSafely(cmboKPIActions.SelectedValue) == 1)
            {
                int groupIndex = HelperFunctions.GetIntSafely(
                    cmboGroupConfigs.SelectedValue);
                if (groupIndex > 0)
                {
                    gf = Model.GroupConfigs.FirstOrDefault
                        (r =>
                        r.GroupIndex == groupIndex);
                }
            }

            KpiAction ka =
                new KpiAction(
                    HelperFunctions.GetIntSafely(
                        cmboKPIActions.SelectedValue), gf);
            return ka;
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

        private void HandleException(string message, Exception ex)
        {
            MessageBox.Show(message + "Report this incident to Process Control through the helpdesk #6212 with time and username.");
            NLog.LogManager.GetCurrentClassLogger().FatalException("DashboardUserControl workDashData_RunWorkerCompleted trend shift data exception. ", ex);
            Form parent = TopLevelControl as Form;
            if (parent != null)
            {
                parent.Close();
            }
        }
        #region Events

        /// <summary>
        /// Event handler for the change of
        /// item selection on the treeview.
        /// </summary>
        private void treeDashboards_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearKPIDetails();

            var selectedConfiguration = e.Node.Tag as KpiConfigShiftWrapper;
            if (e.Node != null && selectedConfiguration != null)
            {
                pnlKPIDetails.BringToFront();
                PopulateKPIDetails(selectedConfiguration);
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
