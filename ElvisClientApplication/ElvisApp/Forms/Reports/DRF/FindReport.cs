using System;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using ElvisDataModel;
using System.ComponentModel;

namespace Elvis.Forms.Reports.DRF
{
    public partial class FindReport : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DRFIndex { get; set; }

        public FindReport()
        {
            InitializeComponent();
            numDRFIndex.Maximum = EntityHelper.DRFReport.GetMaxDRFIndex();
            numDRFIndex.Minimum = 0;
            numDRFIndex.Value = numDRFIndex.Maximum;
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                grpFindDRF.BackColor =
                        Settings.Default.ColourBackground;

            this.ForeColor =
                grpFindDRF.ForeColor =
                            Settings.Default.ColourText;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            DRFIndex = Convert.ToInt32(numDRFIndex.Value);
        }
    }
}
