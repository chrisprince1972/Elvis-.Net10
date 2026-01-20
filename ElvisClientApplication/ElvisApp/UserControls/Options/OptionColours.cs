using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Options
{
    public partial class OptionColours : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Background { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TextColour { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Scheduler1 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Scheduler2 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Caster1 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Caster2 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Caster3 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Caster1Plan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Caster2Plan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Caster3Plan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SlowCastPlan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Vessel1 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Vessel2 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Vessel1Plan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Vessel2Plan { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TableTheme { get; set; }
        #endregion

        #region Constructor
        public OptionColours()
        {
            InitializeComponent();
            SetupColourPanelsAndProperties();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the saved colour settings to the panels and the
        /// properties of the class.
        /// </summary>
        private void SetupColourPanelsAndProperties()
        {
            pnlBackground.BackColor = this.Background = Settings.Default.ColourBackground;
            pnlText.BackColor = this.TextColour = Settings.Default.ColourText;
            pnlScheduler1.BackColor = this.Scheduler1 = Settings.Default.ColourHeatScheduler1;
            pnlScheduler2.BackColor = this.Scheduler2 = Settings.Default.ColourHeatScheduler2;

            this.TableTheme = Settings.Default.TableTheme;
            if (this.TableTheme == "High Contrast")
                rbTabHighContrast.Checked = true;

            pnlCaster1.BackColor = this.Caster1 = Settings.Default.ColourCaster1;
            pnlCaster2.BackColor = this.Caster2 = Settings.Default.ColourCaster2;
            pnlCaster3.BackColor = this.Caster3 = Settings.Default.ColourCaster3;

            pnlCaster1Plan.BackColor = this.Caster1Plan = Settings.Default.ColourCaster1Plan;
            pnlCaster2Plan.BackColor = this.Caster2Plan = Settings.Default.ColourCaster2Plan;
            pnlCaster3Plan.BackColor = this.Caster3Plan = Settings.Default.ColourCaster3Plan;
            pnlSlowCastPlan.BackColor = this.SlowCastPlan = Settings.Default.SlowCastColour;

            pnlVessel1.BackColor = this.Vessel1 = Settings.Default.ColourVessel1;
            pnlVessel2.BackColor = this.Vessel2 = Settings.Default.ColourVessel2;

            pnlVessel1Plan.BackColor = this.Vessel1Plan = Settings.Default.ColourVessel1Plan;
            pnlVessel2Plan.BackColor = this.Vessel2Plan = Settings.Default.ColourVessel2Plan;
        }

        /// <summary>
        /// Sets a new colour setting when the user changes
        /// a value.
        /// </summary>
        /// <param name="name">The Name of the property to change.</param>
        /// <param name="colour">The colour to change it to.</param>
        private void SetNewColourSetting(string name, Color colour)
        {
            switch (name)
            {
                case "Background":
                    pnlBackground.BackColor = this.Background = colour;
                    break;
                case "Text":
                    pnlText.BackColor = this.TextColour = colour;
                    break;
                case "Scheduler1":
                    pnlScheduler1.BackColor = this.Scheduler1 = colour;
                    break;
                case "Scheduler2":
                    pnlScheduler2.BackColor = this.Scheduler2 = colour;
                    break;
                case "Caster1":
                    pnlCaster1.BackColor = this.Caster1 = colour;
                    break;
                case "Caster2":
                    pnlCaster2.BackColor = this.Caster2 = colour;
                    break;
                case "Caster3":
                    pnlCaster3.BackColor = this.Caster3 = colour;
                    break;
                case "Caster1Plan":
                    pnlCaster1Plan.BackColor = this.Caster1Plan = colour;
                    break;
                case "Caster2Plan":
                    pnlCaster2Plan.BackColor = this.Caster2Plan = colour;
                    break;
                case "Caster3Plan":
                    pnlCaster3Plan.BackColor = this.Caster3Plan = colour;
                    break;
                case "SlowCastPlan":
                    pnlSlowCastPlan.BackColor = this.SlowCastPlan = colour;
                    break;
                case "Vessel1":
                    pnlVessel1.BackColor = this.Vessel1 = colour;
                    break;
                case "Vessel2":
                    pnlVessel2.BackColor = this.Vessel2 = colour;
                    break;
                case "Vessel1Plan":
                    pnlVessel1Plan.BackColor = this.Vessel1Plan = colour;
                    break;
                case "Vessel2Plan":
                    pnlVessel2Plan.BackColor = this.Vessel2Plan = colour;
                    break;
            }
        }

        #region Button Click Events
        private void btnDefault_Click(object sender, EventArgs e)
        {
            Button btnDefault = (Button)sender;

            switch (btnDefault.Tag.ToString())
            {
                case "Background":
                    pnlBackground.BackColor =
                        this.Background =
                            Common.DefaultSettings.Background;
                    break;
                case "Text":
                    pnlText.BackColor =
                        this.TextColour =
                            Common.DefaultSettings.Text;
                    break;
                case "Scheduler1":
                    pnlScheduler1.BackColor =
                        this.Scheduler1 =
                            Common.DefaultSettings.HeatSchedulerBackground1;
                    break;
                case "Scheduler2":
                    pnlScheduler2.BackColor =
                        this.Scheduler2 =
                            Common.DefaultSettings.HeatSchedulerBackground2;
                    break;
                case "Caster1":
                    pnlCaster1.BackColor =
                        this.Caster1 =
                            Common.DefaultSettings.Caster1;

                    pnlCaster1Plan.BackColor =
                        this.Caster1Plan =
                            Common.DefaultSettings.Caster1Planning;
                    break;
                case "Caster2":
                    pnlCaster2.BackColor =
                        this.Caster2 =
                            Common.DefaultSettings.Caster2;

                    pnlCaster2Plan.BackColor =
                        this.Caster2Plan =
                            Common.DefaultSettings.Caster2Planning;
                    break;
                case "Caster3":
                    pnlCaster3.BackColor =
                        this.Caster3 =
                            Common.DefaultSettings.Caster3;

                    pnlCaster3Plan.BackColor =
                        this.Caster3Plan =
                            Common.DefaultSettings.Caster3Planning;
                    break;
                case "SlowCastPlan":
                    pnlSlowCastPlan.BackColor =
                        this.SlowCastPlan =
                            Common.DefaultSettings.SlowCastPlan;
                    break;
                case "Vessel1":
                    pnlVessel1.BackColor =
                        this.Vessel1 =
                            Common.DefaultSettings.Vessel1;

                    pnlVessel1Plan.BackColor =
                        this.Vessel1Plan =
                            Common.DefaultSettings.Vessel1Planning;
                    break;
                case "Vessel2":
                    pnlVessel2.BackColor =
                        this.Vessel2 =
                            Common.DefaultSettings.Vessel2;

                    pnlVessel2Plan.BackColor =
                        this.Vessel2Plan =
                            Common.DefaultSettings.Vessel2Planning;
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Control ctrlClicked = (Control)sender;

            DialogResult result = colourPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetNewColourSetting(ctrlClicked.Tag.ToString(), colourPicker.Color);
            }
        }
        #endregion

        private void rbTableTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTabDefault.Checked)
                this.TableTheme = "Default";
            else
                this.TableTheme = "High Contrast";
        }

        #endregion
    }
}
