using System.Drawing;
using System.Windows.Forms;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class QuickHeatDetails : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HeatNumber { set { lblHeatNumber.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProgramNo { set { lblProgramNumber.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Grade { set { lblGrade.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caster { set { lblCasterNumber.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Vessel { set { lblVesselNumber.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LadleNo { set { lblLadleNo.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Start { set { lblStartTime.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string End { set { lblEndTime.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Duration { set { lblDuration.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VesselVisible { set { lblVesselNumber.Visible = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LadleNoVisible { set { lblLadleNo.Visible = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color EndTimeBackColour { set { lblEndTime.BackColor = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color EndTimeForeColour { set { lblEndTime.ForeColor = value; } }
        #endregion

        public QuickHeatDetails()
        {
            InitializeComponent();
            CustomiseColours();
        }

        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
            pnlHeatDetails.BackColor =
            grpSelectedHeat.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlHeatDetails.ForeColor =
            grpSelectedHeat.ForeColor =
                Settings.Default.ColourText;
        }
    }
}
