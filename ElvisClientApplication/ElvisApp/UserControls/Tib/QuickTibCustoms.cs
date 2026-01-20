using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Forms;
using Elvis.Properties;

namespace Elvis.UserControls.Tib
{
    public partial class QuickTibCustoms : UserControl
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

        public bool ShowLegend
        {
            get { return chbShowLegend.Checked; }
        }

        public int CellWidth
        {
            get { return trackBarCellWidth.Value; }
        }

        public bool ShowHMPour
        {
            get { return chbHMPour.Checked; }
        }

        public bool ShowHMDesulph
        {
            get { return chbHMDes.Checked; }
        }

        public bool ShowVessels
        {
            get { return chbVessels.Checked; }
        }

        public bool ShowSecSteel
        {
            get { return chbSecSteel.Checked; }
        }

        public bool ShowCasters
        {
            get { return chbCasters.Checked; }
        }
        #endregion

        public QuickTibCustoms(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            chbShowShadows.Checked = Settings.Default.QuickTibShadows;
            chbTimeLine.Checked = Settings.Default.QuickTibTimeLine;
            chbShowLegend.Checked = Settings.Default.QuickTibLegend;
            trackBarCellWidth.Value = Settings.Default.QuickTibCellWidth;
            ConfigureUnitCheckBoxes();
            CustomiseColours();
        }

        #region Methods
        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
            pnlCustoms.BackColor =
            grpCustomisation.BackColor =
            grpUnits.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlCustoms.ForeColor = 
            grpCustomisation.ForeColor =
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

            LoopThroughPanel(pnlUnitsLeft, unitsToHide);
            LoopThroughPanel(pnlUnitsRight, unitsToHide);

            UnitVisibilityHelper.SetUnitsToHide(
                unitsToHide, UnitVisibilityHelper.UnitGroupVisibilitySettings.Tib);
            return unitsToHide;
        }

        /// <summary>
        /// Loops through a panel to find all the checked check boxes to built up the
        /// unit list
        /// </summary>
        /// <param name="pnl">The Panel to Search</param>
        /// <param name="unitsToHide">The List of Units to Hide</param>
        private void LoopThroughPanel(Panel pnl, List<int> unitsToHide)
        {
            foreach (Control ctrl in pnl.Controls)//Loop each checkbox
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
        }

        /// <summary>
        /// Configures the unit group checkboxes' Checked property from the values stored in the user settings.
        /// </summary>
        private void ConfigureUnitCheckBoxes()
        {
            if (Settings.Default.ShowSelectors)
            {
                List<int> unitsToHide =
                    UnitVisibilityHelper.GetUnitsToHide(UnitVisibilityHelper.UnitGroupVisibilitySettings.Tib);

                if (unitsToHide != null && unitsToHide.Count > 0)
                {
                    // If the unit isn't in the list of units to hide, show the
                    // check in the checkbox for that unit.
                    chbHMPour.Checked = !unitsToHide.Any(u => u == 1 || u == 2);
                    chbHMDes.Checked = !unitsToHide.Any(u => u == 3 || u == 4);
                    chbVessels.Checked = !unitsToHide.Any(u => u == 5 || u == 6);
                    chbSecSteel.Checked = !unitsToHide.Any(u => u >= 7 && u <= 10);
                    chbCasters.Checked = !unitsToHide.Any(u => u >= 11 && u <= 13);
                    chbScrap.Checked = !unitsToHide.Any(u => u == 16 || u == 17);
                    chbLimePlant.Checked = !unitsToHide.Any(u => u == 14);
                }
                else
                {
                    // Show All Units.
                    chbHMPour.Checked = true;
                    chbHMDes.Checked = true;
                    chbVessels.Checked = true;
                    chbSecSteel.Checked = true;
                    chbCasters.Checked = true;
                    chbScrap.Checked = true;
                    chbLimePlant.Checked = true;
                }
            }
            else
            {//Resizes the form if units is not visible.
                grpUnits.Visible = false;
                this.Width -= (grpUnits.Width + 10);
            }
        }

        #region Events
        private void chbShowShadows_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerTib != null)
            {
                Settings.Default.QuickTibShadows =
                    this.main.SchedulerTib.ShowShadows =
                    chbShowShadows.Checked;
            }
        }

        private void chbShowLegend_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerTib != null)
            {
                Settings.Default.QuickTibLegend =
                    this.main.SchedulerTib.ShowLegend =
                    chbShowLegend.Checked;
            }
        }

        private void chbTimeLine_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerTib != null)
            {
                Settings.Default.QuickTibTimeLine =
                    this.main.SchedulerTib.ShowTimeline =
                    chbTimeLine.Checked;
            }
        }

        private void trackBarCellWidth_Scroll(object sender, EventArgs e)
        {
            if (this.main.SchedulerTib != null)
            {
                Settings.Default.QuickTibCellWidth =
                    this.main.SchedulerTib.CellWidth =
                    trackBarCellWidth.Value;
            }
        }

        private void chbUnits_CheckedChanged(object sender, EventArgs e)
        {
            if (this.main.SchedulerTib != null)
            {
                this.main.ShowHideUnits(this.main.SchedulerTib, GetUnitsToHide());
            }
        }
        #endregion

        #endregion
    }
}
