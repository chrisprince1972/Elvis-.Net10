using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Options
{
    public partial class OptionTib : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color External { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ExternalTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Multiserv { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color MultiservTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HMScrap { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HMScrapTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Vessels { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color VesselsTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Plan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PlanTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SecSteel { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SecSteelTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Casters { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CastersTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Cranes { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CranesTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color NoReason { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color NoReasonTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LimePlant { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LimePlantTxt { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LPChangeover { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NotProducing { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Producing { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int InProcess { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OutProcess { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Unproductive { get; set; }
        #endregion

        #region Constructor
        public OptionTib()
        {
            InitializeComponent();
            SetupColourPanelsAndProperties();
            SetupNumberPickersAndProperties();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initial loadup of the saved user settings for colours.
        /// </summary>
        private void SetupColourPanelsAndProperties()
        {
            pnlExternal.BackColor = this.External = Settings.Default.TibExternal;
            pnlExternalTxt.BackColor = this.ExternalTxt = Settings.Default.TibExternalText;
            pnlMultiserv.BackColor = this.Multiserv = Settings.Default.TibMultiServ;
            pnlMultiservTxt.BackColor = this.MultiservTxt = Settings.Default.TibMultiServText;
            pnlHMScrap.BackColor = this.HMScrap = Settings.Default.TibHMScrap;
            pnlHMScrapTxt.BackColor = this.HMScrapTxt = Settings.Default.TibHMScrapText;
            pnlVessels.BackColor = this.Vessels = Settings.Default.TibVessels;
            pnlVesselsTxt.BackColor = this.VesselsTxt = Settings.Default.TibVesselsText;
            pnlPlan.BackColor = this.Plan = Settings.Default.TibPlan;
            pnlPlanTxt.BackColor = this.PlanTxt = Settings.Default.TibPlanText;
            pnlSecSteel.BackColor = this.SecSteel = Settings.Default.TibSecSteel;
            pnlSecSteelTxt.BackColor = this.SecSteelTxt = Settings.Default.TibSecSteelText;
            pnlCasters.BackColor = this.Casters = Settings.Default.TibCasters;
            pnlCastersTxt.BackColor = this.CastersTxt = Settings.Default.TibCastersText;
            pnlCranes.BackColor = this.Cranes = Settings.Default.TibCranes;
            pnlCranesTxt.BackColor = this.CranesTxt = Settings.Default.TibCranesText;
            pnlNoReason.BackColor = this.NoReason = Settings.Default.TibNoReason;
            pnlNoReasonTxt.BackColor = this.NoReasonTxt = Settings.Default.TibNoReasonText;
            pnlLimePlant.BackColor = this.LimePlant = Settings.Default.LimePlantEventColour;
            pnlLPChangeover.BackColor = this.LPChangeover = Settings.Default.LimePlantChangeOverColour;
        }

        /// <summary>
        /// Initial loadup of the saved user settings for numeric up downs.
        /// </summary>
        private void SetupNumberPickersAndProperties()
        {
            numNotProducing.Value = this.NotProducing = Settings.Default.HeightTibNotProducing;
            numProducing.Value = this.Producing = Settings.Default.HeightTibProducing;
            numInProcess.Value = this.InProcess = Settings.Default.HeightTibInProcess;
            numOutProcess.Value = this.OutProcess = Settings.Default.HeightTibOutProcess;
            numUnproductive.Value = this.Unproductive = Settings.Default.HeightTibUnproductive;
        }

        /// <summary>
        /// Sets the new colour setting for a specific property.
        /// </summary>
        /// <param name="name">Name of the Property.</param>
        /// <param name="color">The New Colour to set it to.</param>
        private void SetNewColourSetting(string name, Color color)
        {
            switch (name)
            {
                case "External":
                    pnlExternal.BackColor = this.External = color;
                    break;
                case "ExternalTxt":
                    pnlExternalTxt.BackColor = this.ExternalTxt = color;
                    break;
                case "Multiserv":
                    pnlMultiserv.BackColor = this.Multiserv = color;
                    break;
                case "MultiservTxt":
                    pnlMultiservTxt.BackColor = this.MultiservTxt = color;
                    break;
                case "HMScrap":
                    pnlHMScrap.BackColor = this.HMScrap = color;
                    break;
                case "HMScrapTxt":
                    pnlHMScrapTxt.BackColor = this.HMScrapTxt = color;
                    break;
                case "Vessels":
                    pnlVessels.BackColor = this.Vessels = color;
                    break;
                case "VesselsTxt":
                    pnlVesselsTxt.BackColor = this.VesselsTxt = color;
                    break;
                case "Plan":
                    pnlPlan.BackColor = this.Plan = color;
                    break;
                case "PlanTxt":
                    pnlPlanTxt.BackColor = this.PlanTxt = color;
                    break;
                case "SecSteel":
                    pnlSecSteel.BackColor = this.SecSteel = color;
                    break;
                case "SecSteelTxt":
                    pnlSecSteelTxt.BackColor = this.SecSteelTxt = color;
                    break;
                case "Casters":
                    pnlCasters.BackColor = this.Casters = color;
                    break;
                case "CastersTxt":
                    pnlCastersTxt.BackColor = this.CastersTxt = color;
                    break;
                case "Cranes":
                    pnlCranes.BackColor = this.Cranes = color;
                    break;
                case "CranesTxt":
                    pnlCranesTxt.BackColor = this.CranesTxt = color;
                    break;
                case "NoReason":
                    pnlNoReason.BackColor = this.NoReason = color;
                    break;
                case "NoReasonTxt":
                    pnlNoReasonTxt.BackColor = this.NoReasonTxt = color;
                    break;
                case "LimePlant":
                    pnlLimePlant.BackColor = this.LimePlant = color;
                    break;
                case "LPChangeover":
                    pnlLPChangeover.BackColor = this.LPChangeover = color;
                    break;
            }
        }

        #region Events
        /// <summary>
        /// Defaults the Colour Settings
        /// </summary>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            Button btnDefault = (Button)sender;

            switch (btnDefault.Tag.ToString())
            {
                case "External":
                    pnlExternal.BackColor =
                        this.External =
                            Common.DefaultSettings.TibExternal;
                    break;
                case "ExternalTxt":
                    pnlExternalTxt.BackColor =
                        this.ExternalTxt =
                            Common.DefaultSettings.TibExternalFore;
                    break;
                case "Multiserv":
                    pnlMultiserv.BackColor =
                        this.Multiserv =
                            Common.DefaultSettings.TibMultiServ;
                    break;
                case "MultiservTxt":
                    pnlMultiservTxt.BackColor =
                        this.MultiservTxt =
                            Common.DefaultSettings.TibMultiServFore;
                    break;
                case "HMScrap":
                    pnlHMScrap.BackColor =
                        this.HMScrap =
                            Common.DefaultSettings.TibHMScrap;
                    break;
                case "HMScrapTxt":
                    pnlHMScrapTxt.BackColor =
                        this.HMScrapTxt =
                            Common.DefaultSettings.TibHMScrapFore;
                    break;
                case "Vessels":
                    pnlVessels.BackColor =
                        this.Vessels =
                            Common.DefaultSettings.TibVessels;
                    break;
                case "VesselsTxt":
                    pnlVesselsTxt.BackColor =
                        this.VesselsTxt =
                            Common.DefaultSettings.TibVesselsFore;
                    break;
                case "Plan":
                    pnlPlan.BackColor =
                        this.Plan =
                            Common.DefaultSettings.TibPlan;
                    break;
                case "PlanTxt":
                    pnlPlanTxt.BackColor =
                        this.PlanTxt =
                            Common.DefaultSettings.TibPlanFore;
                    break;
                case "SecSteel":
                    pnlSecSteel.BackColor =
                        this.SecSteel =
                            Common.DefaultSettings.TibSecSteel;
                    break;
                case "SecSteelTxt":
                    pnlSecSteelTxt.BackColor =
                        this.SecSteelTxt =
                            Common.DefaultSettings.TibSecSteelFore;
                    break;
                case "Casters":
                    pnlCasters.BackColor =
                        this.Casters =
                            Common.DefaultSettings.TibCasters;
                    break;
                case "CastersTxt":
                    pnlCastersTxt.BackColor =
                        this.CastersTxt =
                            Common.DefaultSettings.TibCastersFore;
                    break;
                case "Cranes":
                    pnlCranes.BackColor =
                        this.Cranes =
                            Common.DefaultSettings.TibCranes;
                    break;
                case "CranesTxt":
                    pnlCranesTxt.BackColor =
                        this.CranesTxt =
                            Common.DefaultSettings.TibCranesFore;
                    break;
                case "NoReason":
                    pnlNoReason.BackColor =
                        this.NoReason =
                            Common.DefaultSettings.TibNoReason;
                    break;
                case "NoReasonTxt":
                    pnlNoReasonTxt.BackColor =
                        this.NoReasonTxt =
                            Common.DefaultSettings.TibNoReasonFore;
                    break;
                case "LimePlant":
                    pnlLimePlant.BackColor =
                        this.LimePlant =
                            Common.DefaultSettings.LimePlant;
                    break;
                case "LPChangeover":
                    pnlLPChangeover.BackColor =
                        this.LPChangeover =
                            Common.DefaultSettings.LPChangeover;
                    break;
            }
        }

        /// <summary>
        /// Gets colour from colour picker and sets new colour property
        /// and panel colour.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Control ctrlClicked = (Control)sender;

            DialogResult result = colourPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetNewColourSetting(ctrlClicked.Tag.ToString(), colourPicker.Color);
            }
        }

        /// <summary>
        /// Defaults the height properties for Tib
        /// </summary>
        private void btnDefaultHeights_Click(object sender, EventArgs e)
        {
            numNotProducing.Value = this.NotProducing = DefaultSettings.TibNotProducingHeight;
            numProducing.Value = this.Producing = DefaultSettings.TibProducingHeight;
            numInProcess.Value = this.InProcess = DefaultSettings.TibInProcessHeight;
            numOutProcess.Value = this.OutProcess = DefaultSettings.TibOutProcessHeight;
            numUnproductive.Value = this.Unproductive = DefaultSettings.TibUnproductiveHeight;
        }

        /// <summary>
        /// Sets the respective property values when the numeric up downs
        /// have been changed.
        /// </summary>
        private void numPicker_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numPicker = (NumericUpDown)sender;

            switch (numPicker.Tag.ToString())
            {
                case "NotProducing":
                    this.NotProducing = Convert.ToInt32(numNotProducing.Value);
                    break;
                case "Producing":
                    this.Producing = Convert.ToInt32(numProducing.Value);
                    break;
                case "InProcess":
                    this.InProcess = Convert.ToInt32(numInProcess.Value);
                    break;
                case "OutProcess":
                    this.OutProcess = Convert.ToInt32(numOutProcess.Value);
                    break;
                case "Unproductive":
                    this.Unproductive = Convert.ToInt32(numUnproductive.Value);
                    break;
            }
        }
        #endregion

        #endregion
    }
}
