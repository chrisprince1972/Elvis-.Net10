using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.Forms.TrendingShifts.UserControls
{
    public partial class TrendLegendItem : UserControl
    {
        private const int offset = 16;

        private int highlightNo = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LegendText
        {
            get { return lblLegTitle.Text; }
            set { lblLegTitle.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LegendColour
        {
            get { return pnlLegColour.BackColor; }
            set { pnlLegColour.BackColor = value; }
        }

        public TrendLegendItem()
        {
            InitializeComponent();
        }

        public void SetupUserControl(string legendText, Color legendColour, int highlightNo)
        {
            LegendText = legendText;
            LegendColour = legendColour;
            this.highlightNo = highlightNo;

            SizeF fontSize = HelperFunctions.GetFontSizeInPixels(LegendText, lblLegTitle.Font);
            int width = HelperFunctions.GetIntSafely(fontSize.Width);
            if (width > 0)
            {
                this.Width = width + pnlLegContainer.Width + offset;
            }
        }

        private void SetHighlightUserSetting(Color color)
        {
            switch (highlightNo)
            {
                case 1:
                    Settings.Default.ColourHighlight1 = color;
                    break;
                case 2:
                    Settings.Default.ColourHighlight2 = color;
                    break;
                case 3:
                    Settings.Default.ColourHighlight3 = color;
                    break;
                case 4:
                    Settings.Default.ColourHighlight4 = color;
                    break;
            }
        }

        private Color GetDefaultHighlightColour()
        {
            switch (highlightNo)
            {
                case 1:
                    return DefaultSettings.ColourHighlight1;
                case 2:
                    return DefaultSettings.ColourHighlight2;
                case 3:
                    return DefaultSettings.ColourHighlight3;
                case 4:
                    return DefaultSettings.ColourHighlight4;
            }
            return Color.Black;
        }

        private void pnlLegColour_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                colourPicker.Color = LegendColour;
                DialogResult result = colourPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pnlLegColour.BackColor = LegendColour = colourPicker.Color;
                    SetHighlightUserSetting(colourPicker.Color);
                }
            }
        }

        private void defaultColourToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            pnlLegColour.BackColor = LegendColour = GetDefaultHighlightColour();
            SetHighlightUserSetting(LegendColour);
        }
    }
}
