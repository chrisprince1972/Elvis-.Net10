using System.Windows.Forms;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Tib
{
    public partial class QuickTibDetails : UserControl
    {
        #region Variables and Properties
        private string type;
        private string[] reasons;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HeatNumber { set { lblHeatNo.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HeatNumberVisible { set { lblHeatNo.Visible = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Start { set { lblStart.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string End { set { lblEnd.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Duration { set { lblDuration.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReasonsVisible { set { lstReasons.Visible = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Type
        {
            get { return this.type ;}
            set
            {
                this.type = value;
                lblType.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] Reasons
        {
            get { return this.reasons; }
            set
            {
                this.reasons = value;
                lstReasons.Items.Clear();
                foreach (string reason in this.reasons)
                {
                    if (!string.IsNullOrWhiteSpace(reason))
                        lstReasons.Items.Add(reason);
                }
            }
        }
        #endregion

        public QuickTibDetails()
        {
            InitializeComponent(); 
            CustomiseColours();
        }

        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
            pnlTibDetails.BackColor =
            grpSelectedTib.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            pnlTibDetails.ForeColor =
            grpSelectedTib.ForeColor =
                Settings.Default.ColourText;
        }
    }
}
