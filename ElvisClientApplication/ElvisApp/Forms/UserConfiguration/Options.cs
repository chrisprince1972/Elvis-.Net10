using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.UserControls.Options;
using Elvis.Properties;

namespace Elvis.Forms.UserConfiguration
{
    public partial class Options : Form
    {
        #region Variables + Properties
        private OptionColours ucColours = new OptionColours();
        private OptionTib ucTibOptions = new OptionTib();
        private OptionFonts ucFonts = new OptionFonts();
        private OptionMain ucMainOptions = new OptionMain();
        private OptionOEEReport ucOEEReports = new OptionOEEReport();
        private OptionDashboard ucDashboards = new OptionDashboard();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RefreshData { get; set; }
        #endregion

        #region Constructor
        public Options()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            optionsContainer.Panel2.Controls.Clear();
            if (e.Node.Text == "General Colours" || e.Node.Text == "Appearance")
            {
                optionsContainer.Panel2.Controls.Add(ucColours);
                ucColours.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "Tib")
            {
                optionsContainer.Panel2.Controls.Add(ucTibOptions);
                ucTibOptions.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "Fonts")
            {
                optionsContainer.Panel2.Controls.Add(ucFonts);
                ucFonts.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "Options")
            {
                optionsContainer.Panel2.Controls.Add(ucMainOptions);
                ucMainOptions.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "OEE")
            {
                optionsContainer.Panel2.Controls.Add(ucOEEReports);
                ucOEEReports.Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "Dashboards")
            {
                optionsContainer.Panel2.Controls.Add(ucDashboards);
                ucDashboards.Dock = DockStyle.Fill;
            }
            else //Adds the default Option Screen
            {
                optionsContainer.Panel2.Controls.Add(ucMainOptions);
                ucColours.Dock = DockStyle.Fill;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region General Colours
            Settings.Default.ColourBackground = ucColours.Background;
            Settings.Default.ColourText = ucColours.TextColour;
            Settings.Default.ColourHeatScheduler1 = ucColours.Scheduler1;
            Settings.Default.ColourHeatScheduler2 = ucColours.Scheduler2;
            Settings.Default.ColourCaster1 = ucColours.Caster1;
            Settings.Default.ColourCaster2 = ucColours.Caster2;
            Settings.Default.ColourCaster3 = ucColours.Caster3;
            Settings.Default.ColourCaster1Plan = ucColours.Caster1Plan;
            Settings.Default.ColourCaster2Plan = ucColours.Caster2Plan;
            Settings.Default.ColourCaster3Plan = ucColours.Caster3Plan;
            Settings.Default.SlowCastColour = ucColours.SlowCastPlan;
            Settings.Default.ColourVessel1 = ucColours.Vessel1;
            Settings.Default.ColourVessel2 = ucColours.Vessel2;
            Settings.Default.ColourVessel1Plan = ucColours.Vessel1Plan;
            Settings.Default.ColourVessel2Plan = ucColours.Vessel2Plan;
            Settings.Default.TableTheme = ucColours.TableTheme;
            #endregion

            #region Tib
            Settings.Default.TibExternal = ucTibOptions.External;
            Settings.Default.TibExternalText = ucTibOptions.ExternalTxt;
            Settings.Default.TibMultiServ = ucTibOptions.Multiserv;
            Settings.Default.TibMultiServText = ucTibOptions.MultiservTxt;
            Settings.Default.TibHMScrap = ucTibOptions.HMScrap;
            Settings.Default.TibHMScrapText = ucTibOptions.HMScrapTxt;
            Settings.Default.TibVessels = ucTibOptions.Vessels;
            Settings.Default.TibVesselsText = ucTibOptions.VesselsTxt;
            Settings.Default.TibPlan = ucTibOptions.Plan;
            Settings.Default.TibPlanText = ucTibOptions.PlanTxt;
            Settings.Default.TibSecSteel = ucTibOptions.SecSteel;
            Settings.Default.TibSecSteelText = ucTibOptions.SecSteelTxt;
            Settings.Default.TibCasters = ucTibOptions.Casters;
            Settings.Default.TibCastersText = ucTibOptions.CastersTxt;
            Settings.Default.TibCranes = ucTibOptions.Cranes;
            Settings.Default.TibCranesText = ucTibOptions.CranesTxt;
            Settings.Default.TibNoReason = ucTibOptions.NoReason;
            Settings.Default.TibNoReasonText = ucTibOptions.NoReasonTxt;
            Settings.Default.LimePlantEventColour = ucTibOptions.LimePlant;
            Settings.Default.LimePlantChangeOverColour = ucTibOptions.LPChangeover;

            Settings.Default.HeightTibNotProducing = ucTibOptions.NotProducing;
            Settings.Default.HeightTibProducing = ucTibOptions.Producing;
            Settings.Default.HeightTibInProcess = ucTibOptions.InProcess;
            Settings.Default.HeightTibOutProcess = ucTibOptions.OutProcess;
            Settings.Default.HeightTibUnproductive = ucTibOptions.Unproductive;
            #endregion

            #region Fonts
            Settings.Default.FontOverviewHeatNo = ucFonts.OverviewHeatNo;
            Settings.Default.FontOverviewExtraData = ucFonts.OverviewExtraData;
            Settings.Default.FontOverviewMiscast = ucFonts.OverviewMiscast;
            Settings.Default.FontTibHeatNo= ucFonts.TibHeatNo;
            Settings.Default.FontCasterHeatNo = ucFonts.CasterHeatNo;
            Settings.Default.FontCasterExtraData = ucFonts.CasterExtraData;
            #endregion

            #region Options
            Settings.Default.AutoUpdate = ucMainOptions.AutoUpdate;
            Settings.Default.OverviewDaysToShow = ucMainOptions.OverviewDaysToShow;
            Settings.Default.TibDaysToShow = ucMainOptions.TibDaysToShow;
            Settings.Default.MemoryLimit = ucMainOptions.MemoryLimit;
            RefreshData = ucMainOptions.DaysToShowModified;
            #endregion

            #region OEE
            Settings.Default.OEELevel1Background = ucOEEReports.L1BackColour;
            Settings.Default.OEEL1Text = ucOEEReports.L1TextColour;
            Settings.Default.OEELevel2Background = ucOEEReports.L2BackColour;
            Settings.Default.OEEL2Text = ucOEEReports.L2TextColour;
            #endregion

            #region Dashboards
            Settings.Default.ColourDashHeaderBack = ucDashboards.HeaderBack;
            Settings.Default.ColourDashRowBack = ucDashboards.RowBack;
            Settings.Default.ColourDashAltRowBack = ucDashboards.AltRowBack;
            Settings.Default.ColourDashGoodBack = ucDashboards.GoodBack;
            Settings.Default.ColourDashBadBack = ucDashboards.BadBack;
            Settings.Default.ColourDashMissingBack = ucDashboards.MissingBack;

            Settings.Default.ColourDashHeaderText = ucDashboards.HeaderText;
            Settings.Default.ColourDashRowText = ucDashboards.RowText;
            Settings.Default.ColourDashAltRowText = ucDashboards.AltRowText;
            Settings.Default.ColourDashGoodText = ucDashboards.GoodText;
            Settings.Default.ColourDashBadText = ucDashboards.BadText;
            Settings.Default.ColourDashMissingText = ucDashboards.MissingText;
            #endregion
        }

        private void Options_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
