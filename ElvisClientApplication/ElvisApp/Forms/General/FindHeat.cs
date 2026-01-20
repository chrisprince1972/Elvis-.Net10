using System;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using ElvisDataModel;
using System.ComponentModel;

namespace Elvis.Forms
{
    public partial class FindHeat : Form
    {
        private bool hasError;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HeatNumberSet { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HeatNumber { get; set; }

        public FindHeat()
        {
            InitializeComponent();
            numHNS.Maximum = EntityHelper.Tracking.GetLatestHNS();
            numHNS.Value = numHNS.Maximum;
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                grpFindHeat.BackColor =
                        Settings.Default.ColourBackground;

            this.ForeColor =
                grpFindHeat.ForeColor =
                            Settings.Default.ColourText;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtHeatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Enter Key
            {
                Search();
            }

            //Checks input for numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void Search()
        {
            int heatNo = 0;
            int heatNoSet = 0;
            if (int.TryParse(txtHeatNo.Text, out heatNo) &&
                int.TryParse(numHNS.Value.ToString(), out heatNoSet))
            {
                if (heatNo >= Settings.Default.MinHeatNumber && 
                    heatNo <= Settings.Default.MaxHeatNumber)
                {
                    HeatNumber = heatNo;
                    HeatNumberSet = heatNoSet;
                    return;
                }
                else
                {
                    MessageBox.Show(
                        string.Format("Heat Number must be between {0} and {1}.", 
                            Settings.Default.MinHeatNumber, 
                            Settings.Default.MaxHeatNumber), 
                        "Invalid Heat Number",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                }
            }
            this.hasError = true;
        }

        private void FindHeat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.hasError;
            this.hasError = false;
        }
    }
}
