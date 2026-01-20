using System.Drawing;

namespace BusinessLogic.Models.ViewModels
{
    public class ElvisSettings
    {
        public Color ColourDashGoodBackground { get; private set; }
        public Color ColourDashGoodText { get; private set; }
        public Color ColourDashBadBackground { get; private set; }
        public Color ColourDashBadText { get; private set; }
        public Color ColourDashMissingBackground { get; private set; }
        public Color ColourDashMissingText { get; private set; }
        public Color ColourDashRowBackground { get; private set; }
        public Color ColourDashRowText { get; private set; }
        public Color ColourDashAltRowBackground { get; private set; }
        public Color ColourDashAltRowText { get; private set; }

        public ElvisSettings(Color colourDashGoodBackground,
            Color colourDashGoodText,
            Color colourDashBadBackground,
            Color colourDashBadText,
            Color colourDashMissingBackground,
            Color colourDashMissingText,
            Color colourDashRowBackground,
            Color colourDashRowText,
            Color colourDashAltRowBackground,
            Color colourDashAltRowText)
        {
            ColourDashGoodBackground = colourDashGoodBackground;
            ColourDashGoodText = colourDashGoodText;
            ColourDashBadBackground = colourDashBadBackground;
            ColourDashBadText = colourDashBadText;
            ColourDashMissingBackground = colourDashMissingBackground;
            ColourDashMissingText = colourDashMissingText;
            ColourDashRowBackground = colourDashRowBackground;
            ColourDashRowText = colourDashRowText;
            ColourDashAltRowBackground = colourDashAltRowBackground;
            ColourDashAltRowText = colourDashAltRowText;
        }
    }

}
