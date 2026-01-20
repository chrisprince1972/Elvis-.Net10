using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Options
{
    public partial class OptionFonts : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font OverviewHeatNo { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font OverviewExtraData { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font OverviewMiscast { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font TibHeatNo { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font CasterHeatNo { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font CasterExtraData { get; set; }
        #endregion

        #region Constructor
        public OptionFonts()
        {
            InitializeComponent();
            SetupFonts();
            SetupLabelText();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the labels and properties to the current
        /// saved user settings.
        /// </summary>
        private void SetupFonts()
        {
            lblOverviewHN.Font = this.OverviewHeatNo = Settings.Default.FontOverviewHeatNo;
            lblOverviewED.Font = this.OverviewExtraData = Settings.Default.FontOverviewExtraData;
            lblOverviewMC.Font = this.OverviewMiscast = Settings.Default.FontOverviewMiscast;
            lblTibHN.Font = this.TibHeatNo = Settings.Default.FontTibHeatNo;
            lblCasterHN.Font = this.CasterHeatNo = Settings.Default.FontCasterHeatNo;
            lblCasterED.Font = this.CasterExtraData = Settings.Default.FontCasterExtraData;
        }

        /// <summary>
        /// Sets up the text and font of the labels.
        /// </summary>
        private void SetupLabelText()
        {
            lblOverviewHN.Text = GetLabelText(lblOverviewHN.Font);
            lblOverviewED.Text = GetLabelText(lblOverviewED.Font);
            lblOverviewMC.Text = GetLabelText(lblOverviewMC.Font);
            lblTibHN.Text = GetLabelText(lblTibHN.Font);
            lblCasterHN.Text = GetLabelText(lblCasterHN.Font);
            lblCasterED.Text = GetLabelText(lblCasterED.Font);
        }

        private string GetLabelText(Font font)
        {
            return string.Format(
                "Font: {0}, {1}pt, {2}",
                font.FontFamily.Name,
                Math.Round(font.Size),
                font.Style
                );
        }

        /// <summary>
        /// Sets a new font for the label and properties
        /// </summary>
        /// <param name="name">The Name of the Property.</param>
        /// <param name="font">The new Font to set it to.</param>
        private void SetNewFont(string name, Font font)
        {
            switch (name)
            {
                case "OverviewHN":
                    lblOverviewHN.Font = OverviewHeatNo = font;
                    break;
                case "OverviewED":
                    lblOverviewED.Font = OverviewExtraData = font;
                    break;
                case "OverviewMC":
                    lblOverviewMC.Font = OverviewMiscast = font;
                    break;
                case "TibHN":
                    lblTibHN.Font = TibHeatNo = font;
                    break;
                case "CasterHN":
                    lblCasterHN.Font = CasterHeatNo = font;
                    break;
                case "CasterED":
                    lblCasterED.Font = CasterExtraData = font;
                    break;
            }
        }

        /// <summary>
        /// Gets the default font from the class and reverts
        /// the label and property to default styles.
        /// </summary>
        /// <param name="name">The name of the property to revert.</param>
        private void DefaultAFont(string name)
        {
            switch (name)
            {
                case "OverviewHN":
                    lblOverviewHN.Font =
                        OverviewHeatNo =
                        DefaultSettings.FontSchedulerDefault;
                    break;
                case "OverviewED":
                    lblOverviewED.Font =
                        OverviewExtraData =
                        DefaultSettings.FontSchedulerDefault;
                    break;
                case "OverviewMC":
                    lblOverviewMC.Font =
                        OverviewMiscast =
                        DefaultSettings.FontSchedulerDefault;
                    break;
                case "TibHN":
                    lblTibHN.Font =
                        TibHeatNo =
                        DefaultSettings.FontSchedulerDefault;
                    break;
                case "CasterHN":
                    lblCasterHN.Font =
                        CasterHeatNo =
                        DefaultSettings.FontSchedulerDefault;
                    break;
                case "CasterED":
                    lblCasterED.Font =
                        CasterExtraData =
                        DefaultSettings.FontSchedulerDefault;
                    break;
            }
        }

        /// <summary>
        /// Sets the default font on the font picker.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        private void SetDefaultFontOnPicker(string name)
        {
            switch (name)
            {
                case "OverviewHN":
                    fontPicker.Font = lblOverviewHN.Font;
                    break;
                case "OverviewED":
                    fontPicker.Font = lblOverviewED.Font;
                    break;
                case "OverviewMC":
                    fontPicker.Font = lblOverviewMC.Font;
                    break;
                case "TibHN":
                    fontPicker.Font = lblTibHN.Font;
                    break;
                case "CasterHN":
                    fontPicker.Font = lblCasterHN.Font;
                    break;
                case "CasterED":
                    fontPicker.Font = lblCasterED.Font;
                    break;
            }
        }

        #region Events
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            SetDefaultFontOnPicker(btnClicked.Tag.ToString());
            DialogResult result = fontPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetNewFont(btnClicked.Tag.ToString(), fontPicker.Font);
                SetupLabelText();
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            DefaultAFont(btnClicked.Tag.ToString());
            SetupLabelText();
        }
        #endregion

        #endregion
    }
}
