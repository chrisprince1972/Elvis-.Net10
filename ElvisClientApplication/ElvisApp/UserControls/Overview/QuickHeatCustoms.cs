using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Forms;
using Elvis.Properties;

namespace Elvis.UserControls.HeatDetails
{
    public partial class QuickHeatCustoms : UserControl
    {
        private MainForm main;

        #region Properties
        public bool ShowShadows
        {
            get { return chbShowShadows.Checked; }
        }

        public bool ShowTimeline
        {
            get { return chbTimeLine.Checked; }
        }

        public bool ShowMiscasts
        {
            get { return chbMiscasts.Checked; }
        }

        public int CellWidth
        {
            get { return trackBarCellWidth.Value; }
        }

        public BaseScheduler.ExtraData ExtraData
        {
            get
            {
                if (rbShowProgNo.Checked)
                    return BaseScheduler.ExtraData.ProgramNo;
                else if (rbShowGrade.Checked)
                    return BaseScheduler.ExtraData.Grade;
                else if (rbShowLadleNo.Checked)
                    return BaseScheduler.ExtraData.LadleNo;
                else
                    return BaseScheduler.ExtraData.None;
            }
        }

        public HeatScheduler.ColourSetting ColourSetting
        {
            get
            {
                if (rbColourByVessel.Checked)
                    return HeatScheduler.ColourSetting.Vessel;
                else
                    return HeatScheduler.ColourSetting.Caster;
            }
        }
        #endregion

        #region Constructor
        public QuickHeatCustoms(MainForm main)
        {
            InitializeComponent();
            this.main = main;

            if (Settings.Default.QuickHeatColourBy == "Vessel")
                rbColourByVessel.Checked = true;

            if (Settings.Default.QuickHeatExtraData.Equals("ProgramNo"))
                rbShowProgNo.Checked = true;
            else if (Settings.Default.QuickHeatExtraData.Equals("Grade"))
                rbShowGrade.Checked = true;
            else if (Settings.Default.QuickHeatExtraData.Equals("LadleNo"))
                rbShowLadleNo.Checked = true;

            chbShowShadows.Checked = Settings.Default.QuickHeatShadows;
            chbTimeLine.Checked = Settings.Default.QuickHeatTimeLine;
            chbMiscasts.Checked = Settings.Default.QuickHeatMiscasts;
            trackBarCellWidth.Value = Settings.Default.QuickHeatCellWidth;
            ConfigureUnitCheckBoxes();
            CustomiseColours();
        }
        #endregion

        #region Methods
        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
            pnlCustoms.BackColor =
            grpCustomisation.BackColor =
            grpData.BackColor =
            grpUnits.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlCustoms.ForeColor =
            grpCustomisation.ForeColor =
            grpData.ForeColor =
            grpUnits.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Finds out which units to hide depending on settings.
        /// </summary>
        /// <returns>A list of Unit Numbers.</returns>
        private List<int> GetUnitsToHide()
        {
            List<int> unitsToHide = new List<int>();

            foreach (Control ctrl in grpUnits.Controls)//Loop each checkbox
            {
                if (ctrl is CheckBox)
                {
                    CheckBox chb = (CheckBox)ctrl;
                    if (!chb.Checked)
                    {
                        //Find unit numbers from the tags
                        string[] strUnitNumbers = chb.Tag.ToString().Split('|');
                        foreach (string strUnit in strUnitNumbers)
                        {
                            int unitNo = int.Parse(strUnit);
                            unitsToHide.Add(unitNo);//Add them to a list for future use
                        }
                    }
                }
            }
            UnitVisibilityHelper.SetUnitsToHide(unitsToHide,
                UnitVisibilityHelper.UnitGroupVisibilitySettings.Heat);
            return unitsToHide;
        }

        /// <summary>
        /// Configures the unit group checkboxes' Checked property from the values stored in the user settings.
        /// </summary>
        private void ConfigureUnitCheckBoxes()
        {
            if (Settings.Default.ShowSelectors)
            {
                List<int> unitsToHide =
                    UnitVisibilityHelper.GetUnitsToHide(UnitVisibilityHelper.UnitGroupVisibilitySettings.Heat);

                if (unitsToHide != null && unitsToHide.Count > 0)
                {
                    // If the unit isn't in the list of units to hide, show the
                    // check in the checkbox for that unit.
                    chbHMPour.Checked = !unitsToHide.Any(u => u == 1 || u == 2);
                    chbHMDes.Checked = !unitsToHide.Any(u => u == 3 || u == 4);
                    chbVessels.Checked = !unitsToHide.Any(u => u == 5 || u == 6);
                    chbSecSteel.Checked = !unitsToHide.Any(u => u >= 7 && u <= 10);
                    chbCasters.Checked = !unitsToHide.Any(u => u >= 11 && u <= 13);
                }
                else
                {
                    // Ensure all checkboxes are checked.
                    chbHMPour.Checked = true;
                    chbHMDes.Checked = true;
                    chbVessels.Checked = true;
                    chbSecSteel.Checked = true;
                    chbCasters.Checked = true;
                }
            }
            else
            {//Resizes the form if units is not visible.
                grpUnits.Visible = false;
                this.Width -= grpUnits.Width;
                pnlExtraData.Padding = new Padding(0);
            }
        }

        /// <summary>
        /// Gets Current Colour Setting from Radio Button selected.
        /// </summary>
        /// <returns>An Enum representing the current setting.</returns>
        private HeatScheduler.ColourSetting GetColourSetting()
        {
            if (rbColourByVessel.Checked)
                return HeatScheduler.ColourSetting.Vessel;
            else
                return HeatScheduler.ColourSetting.Caster;
        }

        /// <summary>
        /// Gets Current Data Setting from Radio Button selected.
        /// </summary>
        /// <returns>An Enum representing the current setting.</returns>
        private BaseScheduler.ExtraData GetDataSetting()
        {
            if (rbShowProgNo.Checked)
                return BaseScheduler.ExtraData.ProgramNo;
            else if (rbShowGrade.Checked)
                return BaseScheduler.ExtraData.Grade;
            else if (rbShowLadleNo.Checked)
                return BaseScheduler.ExtraData.LadleNo;
            else
                return BaseScheduler.ExtraData.None;
        }

        #region Events
        private void chbUnit_CheckedChanged(object sender, EventArgs e)
        {
            this.main.ShowHideUnits(this.main.SchedulerHeat, GetUnitsToHide());
        }

        private void chbShowShadows_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerHeat != null)
            {
                Settings.Default.QuickHeatShadows =
                    this.main.SchedulerHeat.ShowShadows =
                    chbShowShadows.Checked;
            }
        }

        private void chbTimeLine_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerHeat != null)
            {
                Settings.Default.QuickHeatTimeLine =
                    this.main.SchedulerHeat.ShowTimeline =
                    chbTimeLine.Checked;
            }
        }

        private void chbMiscasts_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerHeat != null)
            {
                Settings.Default.QuickHeatMiscasts =
                    this.main.SchedulerHeat.ShowMiscasts =
                    chbMiscasts.Checked;
            }
        }

        private void rbColourBy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerHeat != null)
            {
                RadioButton rb = (RadioButton)sender;
                this.main.SchedulerHeat.CurrentColourSetting = GetColourSetting();
                Settings.Default.QuickHeatColourBy = rb.Tag.ToString();
            }
        }

        private void rbExtraData_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerHeat != null)
            {
                RadioButton rb = (RadioButton)sender;
                this.main.SchedulerHeat.CurrentDataSetting = GetDataSetting();
                Settings.Default.QuickHeatExtraData = rb.Tag.ToString();
            }
        }

        private void trackBarCellWidth_Scroll(object sender, EventArgs e)
        {
            if (this.main.SchedulerHeat != null)
            {
                Settings.Default.QuickHeatCellWidth =
                    this.main.SchedulerHeat.CellWidth =
                    trackBarCellWidth.Value;
            }
        }
        #endregion

        #endregion
    }
}
