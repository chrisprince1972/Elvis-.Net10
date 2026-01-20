using System.Windows.Forms;
using Elvis.Properties;
using System.Collections.Generic;
using System;
using ElvisDataModel.EDMX;

namespace Elvis.UserControls.CasterMachineCondition
{
    public partial class Summary : UserControl
    {
        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public Summary()
        {
            InitializeComponent();
            CustomiseColours();
            GetData();
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


        private void GetData()
        {
            ucStrandAssessmentSummaryC1S1.GetData(1, 1, DateTime.Now);
            ucStrandAssessmentSummaryC1S2.GetData(1, 2, DateTime.Now);
            ucStrandAssessmentSummaryC2S5.GetData(2, 5, DateTime.Now);
            ucStrandAssessmentSummaryC2S6.GetData(2, 6, DateTime.Now);
            ucStrandAssessmentSummaryC3S3.GetData(3, 3, DateTime.Now);
            ucStrandAssessmentSummaryC3S4.GetData(3, 4, DateTime.Now);
            ucUnitChangePrioritySummaryC1S1.GetData();
        }

        private void C1S1Btn_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(1, 1);
        }

        private void C1S2Btn_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(1, 2);
        }

        private void C2S5Btn_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(2, 5);
        }

        private void C2S6Btn_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(2, 6);
        }

        private void C3S3Btn_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(3, 3);
        }

        private void C3S4Btn_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(3, 4);
        }

        private void lblC1S1_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(1, 1);
        }

        private void lblC1S2_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(1, 2);
        }

        private void lblC2S5_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(2, 5);
        }

        private void lblC2S6_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(2, 6);
        }

        private void lblC3S3_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(3, 3);
        }

        private void lblC3S4_Click(object sender, EventArgs e)
        {
            DisplaySinlgeStrandScreen(3, 4);
        }

        private void DisplaySinlgeStrandScreen(int caster, int strand)
        {
            Form pForm = ParentForm;
            TabControl CMCTabControl = pForm.Controls["CMCTabControl"] as TabControl;
            TabPage singleStrandTabPage = CMCTabControl.Controls["singleStrandTabPage"] as TabPage;
            SingleStrandDetail ucSingleStrandDetail = singleStrandTabPage.Controls["ucSingleStrandDetail"] as SingleStrandDetail;
            Panel pnlMain = ucSingleStrandDetail.Controls["pnlMain"] as Panel;
            Panel pnlTopHalf = pnlMain.Controls["pnlTopHalf"] as Panel;
            GroupBox options = pnlTopHalf.Controls["options"] as GroupBox;
            ComboBox cmboCaster = options.Controls["cmboCaster"] as ComboBox;
            cmboCaster.Text = caster.ToString();
            ComboBox cmboStrand = options.Controls["cmboStrand"] as ComboBox;
            cmboStrand.Text = strand.ToString();
            DateTimePicker dtTestDate = options.Controls["dtTestDate"] as DateTimePicker;
            dtTestDate.Value = DateTime.Now.Date;
            Button btnSearch = options.Controls["btnSearch"] as Button;
            CMCTabControl.SelectTab("singleStrandTabPage");
        }
    }
}
