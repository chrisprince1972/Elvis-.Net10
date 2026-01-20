using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Forms;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.UserControls.Caster
{
    public partial class QuickCasterCustoms : UserControl
    {
        #region Variables
        private MainForm main;
        private List<Unit> units;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Properties
        public bool ShowShadows
        {
            get { return chbShowShadows.Checked; }
        }

        public bool ShowTimeline
        {
            get { return chbTimeLine.Checked; }
        }

        public bool ShowChart
        {
            get { return chbShowChart.Checked; }
        }

        public bool Show7pmPlan
        {
            get { return chbShow7pmPlan.Checked; }
        }

        public bool Show10amPlan
        {
            get { return chbShow10amPlan.Checked; }
        }

        public bool ShowHMStock7am
        {
            get { return chbHMStock7am.Checked; }
        }

        public BaseScheduler.ExtraData ExtraData
        {
            get
            {
                if (rbShowProgNo.Checked)
                    return BaseScheduler.ExtraData.ProgramNo;
                else if (rbShowGrade.Checked)
                    return BaseScheduler.ExtraData.Grade;
                else
                    return BaseScheduler.ExtraData.None;
            }
        }
        #endregion

        #region Constructor
        public QuickCasterCustoms(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            GetUnits();

            chbShowShadows.Checked = Settings.Default.QuickCasterShadows;
            chbTimeLine.Checked = Settings.Default.QuickCasterTimeLine;
            chbShowChart.Checked = Settings.Default.QuickCasterChart;
            chbShow7pmPlan.Checked = Settings.Default.QuickCaster7pmPlan;
            chbShow10amPlan.Checked = Settings.Default.QuickCaster10amPlan;
            chbHMStock7am.Checked = Settings.Default.QuickCaster7amStock;

            if (Settings.Default.QuickCasterExtraData == "ProgramNo")
                rbShowProgNo.Checked = true;
            else if (Settings.Default.QuickCasterExtraData == "Grade")
                rbShowGrade.Checked = true;

            CustomiseColours();
        }
        #endregion

        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
            pnlCustoms.BackColor =
            grpCustomisation.BackColor =
            grpData.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlCustoms.ForeColor =
            grpCustomisation.ForeColor =
            grpData.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the units for the form and catches any errors.
        /// </summary>
        private void GetUnits()
        {
            try
            {
                this.units = EntityHelper.Units.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetUnits() -- " +
                    "Getting Unit data from database -- ", ex);
            }
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
            else
                return BaseScheduler.ExtraData.None;
        }

        private void chbShowShadows_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                Settings.Default.QuickCasterShadows =
                    this.main.SchedulerCaster.ShowShadows =
                    chbShowShadows.Checked;
            }
            this.Cursor = Cursors.Default;
        }

        private void chbTimeLine_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                Settings.Default.QuickCasterTimeLine =
                    this.main.SchedulerCaster.ShowTimeline =
                    chbTimeLine.Checked;
            }
            this.Cursor = Cursors.Default;
        }

        private void chbShowChart_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                Settings.Default.QuickCasterChart =
                    this.main.SchedulerCaster.ShowChart =
                    chbShowChart.Checked;
            }
            this.Cursor = Cursors.Default;
        }

        private void chbShow7pmPlan_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                Settings.Default.QuickCaster7pmPlan =
                    this.main.SchedulerCaster.Show7PMPlan =
                    chbShow7pmPlan.Checked;
                this.main.SchedulerCaster.LoadCasterReviewUnits(this.units
                    .Where(u => u.UnitNumber >= 11 && u.UnitNumber <= 13)
                    .ToList<Unit>());
                this.main.LoadCasterData();
            }
            this.Cursor = Cursors.Default;
        }

        private void rbExtraData_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                RadioButton rb = (RadioButton)sender;
                this.main.SchedulerCaster.CurrentDataSetting = GetDataSetting();
                Settings.Default.QuickCasterExtraData = rb.Tag.ToString();
            }
            this.Cursor = Cursors.Default;
        }

        private void chbHMStock7am_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                Settings.Default.QuickCaster7amStock =
                    this.main.SchedulerCaster.Show7amHMStock =
                    chbHMStock7am.Checked;
            }
            this.Cursor = Cursors.Default;
        }

        private void chbShow10amPlan_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.main.SchedulerCaster != null)
            {
                Settings.Default.QuickCaster10amPlan =
                    this.main.SchedulerCaster.Show10AMPlan =
                    chbShow10amPlan.Checked;
                this.main.SchedulerCaster.LoadCasterReviewUnits(this.units
                    .Where(u => u.UnitNumber >= 11 && u.UnitNumber <= 13)
                    .ToList<Unit>());
                this.main.LoadCasterData();
            }
            this.Cursor = Cursors.Default;
        }
    }
}
