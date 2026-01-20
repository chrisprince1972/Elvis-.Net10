using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.UserConfiguration
{
    public partial class TrendingConfiguration : Form
    {
        #region Variables and Properties
        private bool isAdmin = false;
        private List<ParConfig> paraData;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Creates a new instance of the TrendingConfiguration form.
        /// </summary>
        public TrendingConfiguration(bool isAdmin)
        {
            InitializeComponent();
            btnAddParam.Visible = this.isAdmin = isAdmin;
            SetToolTips();
            LoadParameters(GetParaData());
            LoadGroupings(GetGroupingData(), null);
            CustomiseColours();
        }

        /// <summary>
        /// Gives the controls on the form tool tips.
        /// </summary>
        private void SetToolTips()
        {
            toolTip1.SetToolTip(btnMoveUp, "Move selected group up in the sort order.");
            toolTip1.SetToolTip(btnMoveDown, "Move selected group down in the sort order.");
            toolTip1.SetToolTip(btnAddGroup, "Add a new grouping.");
            toolTip1.SetToolTip(btnEditGroup, "Edit the selected group.");
            toolTip1.SetToolTip(btnDeleteGroup, "Delete the selected Group Configuration.");

            toolTip1.SetToolTip(btnAddParam, "Add a new parameter.");
            toolTip1.SetToolTip(btnEditParam, "Edit the selected parameter.");
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlGroupings.BackColor =
                pnlParameters.BackColor =
                pnlBtnCtrlsParam.BackColor =
                pnlBtnCtrlsGroup.BackColor =
                pnlClose.BackColor =
                Settings.Default.ColourBackground;
            this.ForeColor =
                pnlMain.ForeColor =
                pnlGroupings.ForeColor =
                pnlParameters.ForeColor =
                pnlBtnCtrlsParam.ForeColor =
                pnlBtnCtrlsGroup.ForeColor =
                pnlClose.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the ParConfig data for the form.
        /// </summary>
        /// <returns>A list of ParConfig objects.</returns>
        private List<ParConfig> GetParaData()
        {
            this.paraData = new List<ParConfig>();
            try
            {
                this.paraData = EntityHelper.ParConfig.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting parameter data for TrendingConfiguration -- GetParaData() -- ",
                    ex);
            }
            return this.paraData;
        }

        /// <summary>
        /// Gets the Group Config data for the form.
        /// </summary>
        /// <returns>A list of TrendGrouping objects.</returns>
        private List<TrendGrouping> GetGroupingData()
        {
            List<TrendGrouping> trendGroupings = new List<TrendGrouping>();
            try
            {
                int i = 1;
                List<GroupConfig> groupConfigs = EntityHelper.GroupConfig.GetAll();
                foreach (GroupConfig config in groupConfigs.OrderBy(g => g.GroupSort))
                {
                    TrendGrouping trendGrouping = new TrendGrouping()
                    {
                        GroupIndex = config.GroupIndex,
                        GroupDesc = config.GroupDesc,
                        Enabled = "No",
                        DBGroupSort = config.GroupSort,
                        GroupSort = i,//Changes the Sort order to something the user understands
                        Par1 = GetParameterName(config.Par1),
                        Par2 = GetParameterName(config.Par2),
                        Par3 = GetParameterName(config.Par3),
                        Par4 = GetParameterName(config.Par4),
                        Par5 = GetParameterName(config.Par5),
                        Par6 = GetParameterName(config.Par6),
                    };

                    if (config.DisplayCode.HasValue &&
                        config.DisplayCode.Value == 1)
                    {
                        trendGrouping.Enabled = "Yes";
                    }

                    if (config.GroupHighlight != null)
                    {
                        trendGrouping.Highlight = config.GroupHighlight.Description;
                    }

                    trendGroupings.Add(trendGrouping);

                    i++;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting Group Config data for TrendingConfiguration -- GetGroupingData() -- ",
                    ex);
            }
            return trendGroupings;
        }

        /// <summary>
        /// Gets the parameter name from the parIndex.
        /// </summary>
        /// <param name="parIndex">The index number representing a par config record.</param>
        /// <returns>The name of the parameter as a string or empty string if not found.</returns>
        private string GetParameterName(int? parIndex)
        {
            if (parIndex.HasValue)
            {
                ParConfig parConfig = this.paraData.FirstOrDefault(p => p.ParIndex == parIndex);
                if (parConfig != null)
                {
                    return parConfig.Parameter;
                }
            }
            return "";
        }

        /// <summary>
        /// Loads the paramters given into the list view.
        /// </summary>
        /// <param name="parameters">A list of par config parameters to populate 
        /// the list view.</param>
        private void LoadParameters(List<ParConfig> parameters)
        {
            lstParameters.Items.Clear();

            if (parameters != null &&
                parameters.Count > 0)
            {
                foreach (ParConfig parameter in parameters)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = parameter.Parameter,
                        Tag = parameter
                    };

                    item.SubItems.Add(parameter.ParDesc);

                    if (parameter.MinLimit.HasValue)
                        item.SubItems.Add(parameter.MinLimit.Value.ToString());

                    if (parameter.MaxLimit.HasValue)
                        item.SubItems.Add(parameter.MaxLimit.Value.ToString());

                    if (parameter.AimTarget.HasValue)
                        item.SubItems.Add(parameter.AimTarget.Value.ToString());

                    if (parameter.DisplayMin.HasValue)
                        item.SubItems.Add(parameter.DisplayMin.Value.ToString());

                    if (parameter.DisplayMax.HasValue)
                        item.SubItems.Add(parameter.DisplayMax.Value.ToString());

                    if (parameter.CellWidth.HasValue)
                        item.SubItems.Add(parameter.CellWidth.Value.ToString());

                    lstParameters.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show(
                    "No parameters found in the database!",
                    "Data Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Loads the grouping config given into the list view.
        /// </summary>
        /// <param name="grouping">A list of groups to add to the ListView.</param>
        /// <param name="selectItemIndex">Leave null to select default, give value
        /// to select specific record.</param>
        private void LoadGroupings(List<TrendGrouping> grouping, int? selectItemIndex)
        {
            lstGrouping.Items.Clear();

            if (grouping != null &&
                grouping.Count > 0)
            {
                foreach (TrendGrouping group in grouping)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = group.GroupDesc,
                        Tag = group
                    };

                    item.SubItems.Add(group.Par1);
                    item.SubItems.Add(group.Par2);
                    item.SubItems.Add(group.Par3);
                    item.SubItems.Add(group.Par4);
                    item.SubItems.Add(group.Par5);
                    item.SubItems.Add(group.Par6);
                    item.SubItems.Add(group.GroupSort.ToString());
                    item.SubItems.Add(group.Enabled);
                    item.SubItems.Add(group.Highlight);

                    lstGrouping.Items.Add(item);
                }
                if (selectItemIndex.HasValue)
                    lstGrouping.Items[selectItemIndex.Value].Selected = true;
            }
            else
            {
                MessageBox.Show(
                    "No grouping config found in the database!",
                    "Data Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Opens the Add Edit form for the trend parameters.
        /// </summary>
        /// <param name="parConfig">
        /// If parameter is null then the 
        /// add new parameter form will show, 
        /// edit parameter screen otherwise.</param>
        private void OpenAddEditParameter(ParConfig parConfig)
        {
            AddEditTrendParameter addEditParam = new AddEditTrendParameter(parConfig);
            if (addEditParam != null && !addEditParam.IsDisposed)
            {
                addEditParam.ShowDialog();

                if (addEditParam.DialogResult == DialogResult.OK)
                {
                    LoadParameters(GetParaData());
                    LoadGroupings(GetGroupingData(), null);
                }

                if (lstParameters.Items.Count > 0)
                {
                    lstParameters.Focus();
                    lstParameters.Items[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// Finds the currently selected parameter in the list view.
        /// Returns null if no item selected.
        /// </summary>
        /// <returns>The selected ParConfig object, 
        /// or null if no list item selected.</returns>
        private ParConfig GetSelectedParameter()
        {
            if (lstParameters.SelectedItems != null &&
                lstParameters.SelectedItems.Count == 1)
            {
                //Check to ensure the item tag is a ParConfig object.
                if (lstParameters.SelectedItems[0].Tag is ParConfig)
                {
                    return (ParConfig)lstParameters.SelectedItems[0].Tag;
                }
            }
            return null;
        }

        /// <summary>
        /// Opens the Add Edit form for the trend Grouping.
        /// </summary>
        /// <param name="trendGroup">
        /// If trendGroup is null then the 
        /// add new group form will show, 
        /// edit group screen otherwise.</param>
        private void OpenAddEditGrouping(TrendGrouping trendGroup)
        {
            AddEditTrendGroup addEditGroup = new AddEditTrendGroup(trendGroup);
            addEditGroup.ShowDialog();

            if (addEditGroup.DialogResult == DialogResult.OK)
            {
                LoadParameters(GetParaData());
                LoadGroupings(GetGroupingData(), null);
            }
            SelectDefaultGroup();
        }

        /// <summary>
        /// Deletes a Group Config record from the database after
        /// user confirms the deletion.
        /// </summary>
        /// <param name="trendGrouping">The Trend Grouping associated with teh Group Config to delete.</param>
        private void DeleteGroup(TrendGrouping trendGrouping)
        {
            DialogResult result = MessageBox.Show(string.Format(
                "Are you sure you wish to permanently delete the '{0}' group? This process cannot be undone.",
                    trendGrouping.GroupDesc),
                "Please Confirm Deletion",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (EntityHelper.GroupConfig.DeleteRecord(trendGrouping.GroupIndex))
                    {
                        LoadParameters(GetParaData());
                        LoadGroupings(GetGroupingData(), null);
                        SelectDefaultGroup();
                        return;
                    }
                    throw new Exception("Record not found in database! -- ID: " + trendGrouping.GroupIndex);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error deleting Group Config record from database -- DeleteGroup() -- ",
                        ex);
                    MessageBox.Show(
                        "Error deleting the Group from the database!",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Selects a default Group from the list.
        /// </summary>
        private void SelectDefaultGroup()
        {
            if (lstGrouping.Items.Count > 0)
            {
                lstGrouping.Focus();
                lstGrouping.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// Finds the currently selected group in the list view.
        /// Returns null if no item selected.
        /// </summary>
        /// <returns>The selected TrendGrouping object, 
        /// or null if no list item selected.</returns>
        private TrendGrouping GetSelectedGrouping()
        {
            if (lstGrouping.SelectedItems != null &&
                lstGrouping.SelectedItems.Count == 1)
            {
                //Check to ensure the item tag is a ParConfig object.
                if (lstGrouping.SelectedItems[0].Tag is TrendGrouping)
                {
                    return (TrendGrouping)lstGrouping.SelectedItems[0].Tag;
                }
            }
            return null;
        }

        /// <summary>
        /// Moves a group up or down 1 place in the sort order.
        /// </summary>
        /// <param name="groupToMove">The group to move.</param>
        /// <param name="moveUp">Move up is true, move down is false.</param>
        private void MoveSelectedGroup(TrendGrouping groupToMove, bool moveUp)
        {
            if (lstGrouping.SelectedItems != null &&
                lstGrouping.SelectedItems.Count == 1)
            {
                int indexOfSelected = lstGrouping.SelectedItems[0].Index;
                int indexToReplace = 0;
                if (moveUp)
                {//Record above to replace
                    indexToReplace = indexOfSelected - 1;
                }
                else
                {//Record below to replace
                    indexToReplace = indexOfSelected + 1;
                }

                TrendGrouping groupToReplace =
                    (TrendGrouping)lstGrouping.Items[indexToReplace].Tag;

                try
                {
                    int? oldGroupSort = groupToMove.DBGroupSort;
                    EntityHelper.GroupConfig.EditGroupSort(groupToReplace.DBGroupSort, groupToMove.GroupIndex);
                    EntityHelper.GroupConfig.EditGroupSort(oldGroupSort, groupToReplace.GroupIndex);
                    LoadGroupings(GetGroupingData(), indexToReplace);
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR -- Error modifying the Group Sort numbers -- MoveSelectedGroup() -- ", ex);
                }
            }
        }

        #region Events
        /// <summary>
        /// Handles the clock button click event.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Selected Index changed event on the 
        /// parameters list view.
        /// </summary>
        private void lstParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditParam.Enabled = false;
            if (lstParameters.SelectedItems != null &&
                lstParameters.SelectedItems.Count == 1)
            {
                btnEditParam.Enabled = true;
            }
        }

        /// <summary>
        /// Add button event handler for Parameters.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAddEditParameter(null);//Add New
        }

        /// <summary>
        /// Edit button event handler for Parameters.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenAddEditParameter(GetSelectedParameter());//Edit Selected
        }

        /// <summary>
        /// Key Down event handler for the Parameter List view.
        /// </summary>
        private void lstParameters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenAddEditParameter(GetSelectedParameter());//Edit Selected
            }
        }

        /// <summary>
        /// Double Click event handler for the Parameter List View.
        /// </summary>
        private void lstParameters_DoubleClick(object sender, EventArgs e)
        {
            OpenAddEditParameter(GetSelectedParameter());//Edit Selected
        }

        /// <summary>
        /// Double Click event handler for the Grouping List View.
        /// </summary>
        private void lstGrouping_DoubleClick(object sender, EventArgs e)
        {
            OpenAddEditGrouping(GetSelectedGrouping());//Edit Selected
        }

        /// <summary>
        /// Key Down event handler for the Grouping List view.
        /// </summary>
        private void lstGrouping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEditGroup.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDeleteGroup.PerformClick();
            }
        }

        /// <summary>
        /// Handles the Selected Index changed event on the 
        /// groupings list view.
        /// </summary>
        private void lstGrouping_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditGroup.Enabled = false;
            btnMoveUp.Enabled = false;
            btnMoveDown.Enabled = false;
            btnDeleteGroup.Enabled = false;

            if (lstGrouping.SelectedItems != null &&
                lstGrouping.SelectedItems.Count == 1)
            {
                btnEditGroup.Enabled = true;
                btnDeleteGroup.Enabled = true;
                if (lstGrouping.SelectedItems[0].Index != 0)
                    btnMoveUp.Enabled = true;
                if (lstGrouping.SelectedItems[0].Index < lstGrouping.Items.Count - 1)
                    btnMoveDown.Enabled = true;
            }
        }

        /// <summary>
        /// Add button event handler for Groupings.
        /// </summary>
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            OpenAddEditGrouping(null);//Add New
        }

        /// <summary>
        /// Edit button event handler for Groupings.
        /// </summary>
        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            OpenAddEditGrouping(GetSelectedGrouping());//Edit Selected
        }

        /// <summary>
        /// Delete button event handler for deleting groups.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteGroup(GetSelectedGrouping());//Delete Selected Group
        }

        /// <summary>
        /// Move up click event handler for changing the sort order.
        /// </summary>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelectedGroup(GetSelectedGrouping(), true);
        }

        /// <summary>
        /// Move down click event handler for changing the sort order.
        /// </summary>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelectedGroup(GetSelectedGrouping(), false);
        }
        #endregion
    }

    #region Supporting Classes
    public class TrendGrouping
    {
        public int GroupIndex { get; set; }
        public string GroupDesc { get; set; }
        public string Par1 { get; set; }
        public string Par2 { get; set; }
        public string Par3 { get; set; }
        public string Par4 { get; set; }
        public string Par5 { get; set; }
        public string Par6 { get; set; }
        public int GroupSort { get; set; }
        public int? DBGroupSort { get; set; }//Actual group sort value stored in database.
        public string Enabled { get; set; }
        public string Highlight { get; set; } //Highlight parameter as a string desc for the table.
    }
    #endregion
}
