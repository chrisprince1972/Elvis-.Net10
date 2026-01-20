using System.Windows.Forms;
using Elvis.Properties;
using System.Collections.Generic;
using System;
using ElvisDataModel.EDMX;

namespace Elvis.UserControls.CasterMachineCondition
{
    public partial class StrandSegmentConfig : UserControl
    {
        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public StrandSegmentConfig()
        {
            InitializeComponent();
            CustomiseColours();
            BindData();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlTopHalf.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlTopHalf.ForeColor =
                    Settings.Default.ColourText;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            ucSegmentConfigC1S1.GetData(1, 1, dtTestDate.Value);
            ucSegmentConfigC1S2.GetData(1, 2, dtTestDate.Value);
            ucSegmentConfigC2S5.GetData(2, 5, dtTestDate.Value);
            ucSegmentConfigC2S6.GetData(2, 6, dtTestDate.Value);
            ucSegmentConfigC3S3.GetData(3, 3, dtTestDate.Value);
            ucSegmentConfigC3S4.GetData(3, 4, dtTestDate.Value);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtTestDate.Value =  dtTestDate.Value.Date.AddDays(1);
            BindData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dtTestDate.Value = dtTestDate.Value.Date.AddDays(-1);
            BindData();
        }
    }
}
