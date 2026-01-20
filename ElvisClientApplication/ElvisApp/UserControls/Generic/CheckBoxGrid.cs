using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace Elvis.UserControls.Generic
{
    /// <summary>
    /// Creates a list of check boxes in a given space.
    /// Each check box is assigned a corisponding tag value.
    /// When the public method GetCheckedTagValues is called a list of all 
    /// the checked check boxes values are returned.
    /// </summary>
    public partial class CheckBoxGrid : UserControl
    {
        //Persist the legend status.
        private List<Tuple<int, bool>> CheckBoxesChecked { get; set; }
        public bool InhibitCheckBoxLoading { get; private set; }
        public event EventHandler OnChange;
        private List<CheckBoxInfo> ListOfCheckboxesToAdd { get; set; }
        private bool highContrast = false;
        private int ControlWidth { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HighContrast
        {
            get
            {
                return highContrast;
            }
            set
            {
                highContrast = value;
                LegendChanged();
            }
        }

        /// <summary>
        /// Container for the information required to build a checkbox.
        /// </summary>
        public class CheckBoxInfo
        {
            public CheckBox ObjCheckBox { get; set; }
            public Color ObjColor { get; set; }
            public Color ObjHighContrastColor { get; set; }
            public int GroupTypeID { get; set; }
            public object ObjForTag { get; set; }
            public string ToolTip { get; set; }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public CheckBoxGrid()
        {
            InitializeComponent();
            this.HighContrast = false;
            this.CheckBoxesChecked = new List<Tuple<int, bool>>();
        }

        /// <summary>
        /// Entry point to the class as controls built with a constructor with parameters.
        /// Builds the grid with the list of checkbox descriptors provided in the parameters.
        /// </summary>
        /// <param name="listOfCheckboxesToAdd">List of checkbox descriptors to build the grid with.</param>
        /// <param name="listOfCheckboxesToAdd">To define the how many wide the grid should be.</param>
        public void SetupUserControl(List<CheckBoxInfo> listOfCheckboxesToAdd, int width)
        {
            this.ListOfCheckboxesToAdd = listOfCheckboxesToAdd;
            this.ControlWidth = width;
            LoadLegend();
            SetCheckBoxCheckedFromMemory();
            CustomiseColours();

            //if not set as a parameter try to guess.
            if (this.ControlWidth == 0)
            {
                SetNumberOfColumns();
            }

        }

        /// <summary>
        /// Returns a list of all of the tags that have their checkbox checked.
        /// </summary>
        /// <returns>Returns a list of all of the tags that have their checkbox checked.</returns>
        public List<object> GetCheckedTagValues()
        {
            List<object> listOfTagValuesToReturn = new List<object>();
            foreach (Control c in tlpContainer.Controls)
            {
                if (c is CheckBox && c.Tag != null && ((CheckBox)c).Checked)
                {
                    listOfTagValuesToReturn.Add(c.Tag);
                }
            }

            return listOfTagValuesToReturn;
        }


        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                tlpContainer.BackColor =
                    Elvis.Properties.Settings.Default.ColourBackground;

            this.ForeColor =
                tlpContainer.ForeColor =
                    Elvis.Properties.Settings.Default.ColourText;
        }


        /// <summary>
        /// Loads the legend into the side bar.
        /// </summary>
        private void LoadLegend()
        {
            tlpContainer.Controls.Clear();
            tlpContainer.ColumnCount = this.ControlWidth;

            int rowCounter = 0;
            CheckBox chb = new CheckBox();
            chb.BringToFront();
            chb.AutoSize = true;
            chb.Text = "All";
            chb.Name = "chbSelectAll";
            chb.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            chb.CheckedChanged += new EventHandler(chbSelectAllChanged);
            //-1 is the psudo group that select all is in.
            PersistChecked(-1, false, false);
            chb.Checked = GetChecked(-1);
            tlpContainer.Controls.Add(chb, 0, rowCounter++);

            foreach (CheckBoxInfo checkBoxToAdd in this.ListOfCheckboxesToAdd)
            {
                AddCellTableLayoutPanelRow(checkBoxToAdd, rowCounter++);
            }
        }

        /// <summary>
        /// Works out how many columns to draw using the width on the container and the longest
        /// checkbox name.  There is probably a better way of doing this.
        /// </summary>
        private void SetNumberOfColumns()
        {
            /// Get longest name
            int longestNameLength
                = this.ListOfCheckboxesToAdd
                .Aggregate
                (
                    String.Empty,
                    (max, curr) => max.Length > curr.ObjCheckBox.Text.Length ? max : curr.ObjCheckBox.Text
                ).Length;


            if (longestNameLength > 0)
            {
                double doubleNumberOfColumns = ((double)this.Size.Width) / (((double)longestNameLength) * 7);
                this.ControlWidth = (int)doubleNumberOfColumns;
                //Keep the value sane.
                this.ControlWidth = this.ControlWidth < 1 ? 1 : this.ControlWidth;
                this.ControlWidth = this.ControlWidth > 10 ? 10 : this.ControlWidth;
            }
            else
            {
                this.ControlWidth = 1;
            }
        }



        /// <summary>
        /// Loops through all check boxes and checks or unchecks them.
        /// </summary>
        /// <param name="isChecked">To set all checked properties.</param>
        private void CheckAllInLegend(bool isChecked)
        {
            foreach (Control ctrl in tlpContainer.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = isChecked;
                }
            }
        }

        /// <summary>
        /// If persisted entry does not exits then add one. But don't overwrite 
        /// current value if overwrite is true.
        /// </summary>
        /// <param name="checkBoxName">Entry to find.</param>
        /// <param name="value">Value to set it to.</param>
        /// <param name="overwrite">If true overwrite a value if it exists.</param>
        private void PersistChecked(int seriesGroupId, bool value, bool overwrite)
        {
            Tuple<int, bool> foundEntry
                = this
                .CheckBoxesChecked
                .Where(r => r.Item1 == seriesGroupId)
                .FirstOrDefault();

            if (foundEntry == null)
            {
                this.CheckBoxesChecked.Add(new Tuple<int, bool>(seriesGroupId, value));
            }
            else
            {
                if (overwrite)
                {
                    this
                        .CheckBoxesChecked
                        .Remove(foundEntry);

                    this.CheckBoxesChecked.Add(new Tuple<int, bool>(seriesGroupId, value));

                }
            }
        }

        /// <summary>
        /// Sets checkboxes checked status with the values that was saved from the above function.
        /// </summary>
        private void SetCheckBoxCheckedFromMemory()
        {
            foreach (Control c in tlpContainer.Controls)
            {
                int groupId = -1;
                if (c is CheckBox && c.Tag != null && int.TryParse(c.Name, out groupId))
                {
                    ((CheckBox)c).Checked = GetChecked(groupId);
                }
            }
        }

        /// <summary>
        /// Get the value checked against the group id.
        /// </summary>
        /// <param name="checkboxGroupId">Identify which value to get.</param>
        /// <returns>The value.</returns>
        private bool GetChecked(int checkboxGroupId)
        {
            bool isChecked = false;
            Tuple<int, bool> foundEntry
                = this
                .CheckBoxesChecked
                .Find(r => r.Item1 == checkboxGroupId);

            if (foundEntry != null)
            {
                isChecked = foundEntry.Item2;
            }

            return isChecked;
        }

        /// <summary>
        /// This function sets a field's value for given coordinates.
        /// </summary>
        /// <param name="value">The check box info that contains the checkbox with the properties set. </param>
        /// <param name="colNumber">The column number.</param>
        private void AddCellTableLayoutPanelRow(CheckBoxInfo checkBoxToAdd, int checkboxNumber)
        {
            PersistChecked(checkBoxToAdd.GroupTypeID, checkBoxToAdd.ObjCheckBox.Checked, false);

            checkBoxToAdd.ObjCheckBox.Checked = GetChecked(checkBoxToAdd.GroupTypeID);
            checkBoxToAdd.ObjCheckBox.Tag = checkBoxToAdd.ObjForTag;
            checkBoxToAdd.ObjCheckBox.Name = checkBoxToAdd.GroupTypeID.ToString();

            SetCheckBoxForeColor(checkBoxToAdd.ObjCheckBox, checkBoxToAdd.GroupTypeID);

            checkBoxToAdd.ObjCheckBox.CheckedChanged += ChangeEvent;

            tlpContainer.Controls.Add
                (
                    checkBoxToAdd.ObjCheckBox,
                    checkboxNumber % this.ControlWidth,
                    checkboxNumber / this.ControlWidth
                );
        }

        /// <summary>
        /// Work out what colour to set the checkbox to... And set it.
        /// </summary>
        /// <param name="checkbox">Checkbox to set the colour.</param>
        /// <param name="groupId">To identify the check box description.</param>
        void SetCheckBoxForeColor(CheckBox checkbox, int groupId)
        {
            if (checkbox.Checked)
            {
                CheckBoxInfo checkBoxDescription
                    = this
                    .ListOfCheckboxesToAdd
                    .Where
                    (r =>
                        r.GroupTypeID == groupId
                    )
                    .FirstOrDefault();

                if (checkBoxDescription != null)
                {
                    if (this.HighContrast)
                    {
                        checkbox.ForeColor = checkBoxDescription.ObjHighContrastColor;
                    }
                    else
                    {
                        checkbox.ForeColor = checkBoxDescription.ObjColor;
                    }
                }
            }
            else
            {
                checkbox.ForeColor = Color.SlateGray;
            }

        }

        ///// <summary>
        ///// Stores the state of the check boxes in the legend.
        ///// </summary>
        private void SaveCheckboxState()
        {
            if (!this.InhibitCheckBoxLoading)
            {
                foreach (Control control in tlpContainer.Controls)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkBox = ((CheckBox)control);
                        //If it is the select all box give it a special group of -1.
                        int checkBoxGroupId = -1;
                        if (int.TryParse(checkBox.Name, out checkBoxGroupId))
                        {
                            PersistChecked(checkBoxGroupId, checkBox.Checked, true);
                            SetCheckBoxForeColor(checkBox, checkBoxGroupId);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if select all check box is checked and checks or unchecks all subsequent checkboxes with this status.
        /// </summary>
        private void chbSelectAllChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.InhibitCheckBoxLoading = true;


            foreach (Control ctrl in tlpContainer.Controls)
            {
                if (ctrl is CheckBox
                    && ctrl.Name == "chbSelectAll")
                {
                    CheckAllInLegend(((CheckBox)ctrl).Checked);
                    break;
                }
            }
            this.InhibitCheckBoxLoading = false;
            //Fire once.
            ChangeEvent(sender, e);
            this.Cursor = Cursors.Default;
        }


        private void ChangeEvent(object sender, EventArgs e)
        {
            if (this.OnChange != null && !this.InhibitCheckBoxLoading)
            {
                this.OnChange(this, e);
                LegendChanged();
            }
        }

        /// <summary>
        /// If a the legend has changed in any way reload.
        /// </summary>
        private void LegendChanged()
        {
            this.Cursor = Cursors.WaitCursor;
            SaveCheckboxState();
            pnlLegendMain.AutoScrollMinSize = new Size(tlpContainer.Width, 0);
            this.Cursor = Cursors.Default;
        }
    }
}
