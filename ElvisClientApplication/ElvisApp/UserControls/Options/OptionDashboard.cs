using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Options
{
    public partial class OptionDashboard : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HeaderBack { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color RowBack { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color AltRowBack { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GoodBack { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BadBack { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color MissingBack { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HeaderText { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color RowText { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color AltRowText { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GoodText { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BadText { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color MissingText { get; set; }
        #endregion

        public OptionDashboard()
        {
            InitializeComponent();
            SetupColourPanelsAndProperties();
        }

        /// <summary>
        /// Adds the saved colour settings to the panels and the
        /// properties of the class.
        /// </summary>
        private void SetupColourPanelsAndProperties()
        {
            pnlHeaderBack.BackColor = this.HeaderBack = Settings.Default.ColourDashHeaderBack;
            pnlRowBack.BackColor = this.RowBack = Settings.Default.ColourDashRowBack;
            pnlAltRowBack.BackColor = this.AltRowBack = Settings.Default.ColourDashAltRowBack;
            pnlGoodBack.BackColor = this.GoodBack = Settings.Default.ColourDashGoodBack;
            pnlBadBack.BackColor = this.BadBack = Settings.Default.ColourDashBadBack;
            pnlMissingBack.BackColor = this.MissingBack = Settings.Default.ColourDashMissingBack;

            pnlHeaderText.BackColor = this.HeaderText = Settings.Default.ColourDashHeaderText;
            pnlRowText.BackColor = this.RowText = Settings.Default.ColourDashRowText;
            pnlAltRowText.BackColor = this.AltRowText = Settings.Default.ColourDashAltRowText;
            pnlGoodText.BackColor = this.GoodText = Settings.Default.ColourDashGoodText;
            pnlBadText.BackColor = this.BadText = Settings.Default.ColourDashBadText;
            pnlMissingText.BackColor = this.MissingText = Settings.Default.ColourDashMissingText;
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
                case "HeaderBack":
                    pnlHeaderBack.BackColor = this.HeaderBack = colour;
                    break;
                case "RowBack":
                    pnlRowBack.BackColor = this.RowBack = colour;
                    break;
                case "AltRowBack":
                    pnlAltRowBack.BackColor = this.AltRowBack = colour;
                    break;
                case "GoodBack":
                    pnlGoodBack.BackColor = this.GoodBack = colour;
                    break;
                case "BadBack":
                    pnlBadBack.BackColor = this.BadBack = colour;
                    break;
                case "MissingBack":
                    pnlMissingBack.BackColor = this.MissingBack = colour;
                    break;
                case "HeaderText":
                    pnlHeaderText.BackColor = this.HeaderText = colour;
                    break;
                case "RowText":
                    pnlRowText.BackColor = this.RowText = colour;
                    break;
                case "AltRowText":
                    pnlAltRowText.BackColor = this.AltRowText = colour;
                    break;
                case "GoodText":
                    pnlGoodText.BackColor = this.GoodText = colour;
                    break;
                case "BadText":
                    pnlBadText.BackColor = this.BadText = colour;
                    break;
                case "MissingText":
                    pnlMissingText.BackColor = this.MissingText = colour;
                    break;
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            Button btnDefault = (Button)sender;

            switch (btnDefault.Tag.ToString())
            {
                case "HeaderBack":
                    pnlHeaderBack.BackColor =
                        this.HeaderBack =
                            Common.DefaultSettings.DashHeaderBack;
                    break;
                case "RowBack":
                    pnlRowBack.BackColor =
                        this.RowBack =
                            Common.DefaultSettings.DashRowBack;
                    break;
                case "AltRowBack":
                    pnlAltRowBack.BackColor =
                        this.AltRowBack =
                            Common.DefaultSettings.DashAltRowBack;
                    break;
                case "GoodBack":
                    pnlGoodBack.BackColor =
                        this.GoodBack =
                            Common.DefaultSettings.DashGoodBack;
                    break;
                case "BadBack":
                    pnlBadBack.BackColor =
                        this.BadBack =
                            Common.DefaultSettings.DashBadBack;
                    break;
                case "MissingBack":
                    pnlMissingBack.BackColor =
                        this.MissingBack =
                            Common.DefaultSettings.DashMissingBack;
                    break;
                case "HeaderText":
                    pnlHeaderText.BackColor =
                        this.HeaderText =
                            Common.DefaultSettings.DashHeaderText;
                    break;
                case "RowText":
                    pnlRowText.BackColor =
                        this.RowText =
                            Common.DefaultSettings.DashRowText;
                    break;
                case "AltRowText":
                    pnlAltRowText.BackColor =
                        this.AltRowText =
                            Common.DefaultSettings.DashAltRowText;
                    break;
                case "GoodText":
                    pnlGoodText.BackColor =
                        this.GoodText =
                            Common.DefaultSettings.DashGoodText;
                    break;
                case "BadText":
                    pnlBadText.BackColor =
                        this.BadText =
                            Common.DefaultSettings.DashBadText;
                    break;
                case "MissingText":
                    pnlMissingText.BackColor =
                        this.MissingText =
                            Common.DefaultSettings.DashMissingText;
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
    }
}
