using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    public partial class MiscastLegendItem : UserControl
    {
        private Color legendColour = Color.Black;
        private Color legendForeColour = Color.Black;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MiscastLookupID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LegendColour
        {
            get { return this.legendColour; }
            set
            {
                this.legendColour = value;
                pnlColour.BackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LegendForeColour
        {
            get { return this.legendForeColour; }
            set
            {
                this.legendForeColour = value;
                lblForeColour.ForeColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LegendText
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LegendItemEnabled
        {
            get { return chbEnabled.Checked; }
            set { chbEnabled.Checked = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? LegendSort { get; set; }

        #region Delegates And Events
        /// <summary>
        /// Legend Item CheckChanged Event for the User Control
        /// </summary>
        public delegate void LegendItemCheckChangedEvent(object sender);

        public event LegendItemCheckChangedEvent LegendItemCheckChanged;

        #endregion Delegates And Events

        public MiscastLegendItem()
        {
            InitializeComponent();
        }

        private void chbShow_CheckedChanged(object sender, System.EventArgs e)
        {
            Enable(chbEnabled.Checked);
            if (LegendItemCheckChanged != null)
            {
                LegendItemCheckChanged(sender);
            }
        }

        private void Enable(bool isEnabled)
        {
            pnlColour.Enabled = isEnabled;
            lblItemName.Enabled = isEnabled;

            if (isEnabled)
            {
                pnlColour.BackColor = this.legendColour;
                lblForeColour.ForeColor = this.legendForeColour;
                lblItemName.Font = new Font("Tahoma", 8, FontStyle.Regular);
            }
            else
            {
                pnlColour.BackColor = Color.LightGray;
                lblForeColour.ForeColor = Color.WhiteSmoke;
                lblItemName.Font = new Font("Tahoma", 8, FontStyle.Strikeout);
            }
        }
    }
}
