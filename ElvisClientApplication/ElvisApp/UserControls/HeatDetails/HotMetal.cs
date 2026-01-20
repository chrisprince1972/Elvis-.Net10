using System.Windows.Forms;
using Elvis.Properties;

namespace Elvis.UserControls.HeatDetails
{
    public partial class HotMetal : UserControl
    {
        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public HotMetal()
        {
            InitializeComponent();
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlTopHalf.BackColor =
                pnlBottomHalf.BackColor = 
                grpHotMetalDetails.BackColor = 
                grpTreatmentDetails.BackColor = 
                grpInjection.BackColor = 
                grpHMDesModel.BackColor = 
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlTopHalf.ForeColor =
                pnlBottomHalf.ForeColor =
                grpHotMetalDetails.ForeColor =
                grpTreatmentDetails.ForeColor = 
                grpInjection.ForeColor = 
                grpHMDesModel.ForeColor = 
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to 
        /// put the values into the control when they want to display the data.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            if (ucKeyDetails != null)
                ucKeyDetails.SetupUserControl(heatNumber, heatNumberSet);

            if (ucHotMetalMakeUp != null)
                ucHotMetalMakeUp.SetupUserControl(heatNumber, heatNumberSet);

            if (ucDesulphModel != null)
                ucDesulphModel.SetupUserControl(heatNumber, heatNumberSet);

            if (ucInjectionDetails != null)
                ucInjectionDetails.SetupUserControl(heatNumber, heatNumberSet);

            if (ucHeatLogDisplay != null)
                ucHeatLogDisplay.SetupUserControlForDesulphPour(heatNumber, heatNumberSet);

            if (ucSkimQuality != null)
                ucSkimQuality.SetupUserControl(heatNumber, heatNumberSet);
        }
    }
}
