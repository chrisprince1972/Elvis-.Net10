using System.Windows.Forms;
using Elvis.Properties;
using System.Collections.Generic;
using System;
using ElvisDataModel.EDMX;
using System.Drawing;
using System.ComponentModel;

namespace Elvis.UserControls.CasterMachineCondition
{
    public partial class Overall : UserControl
    {

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public Overall()
        {
            InitializeComponent();
            CustomiseColours();
            BindData();
        }

        private void PopulateSprayWaterUserControl()
        {
            TestIndex latestTestIndex = ElvisDataModel.EntityHelper.CasterMachineCondition.GetTopSingle<TestIndex>("", "it.TestDate desc");
            dtTestDate.Value = (DateTime)latestTestIndex.TestDate;
            sprayWater1.GetData((int)latestTestIndex.Caster, (int)latestTestIndex.Strand, latestTestIndex.TestDate.Value);
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtTestDate.Value = dtTestDate.Value.AddDays(1);
            BindData();
        }

        private void BindData()
        {
            //Sulphur print overall
            ucSulphurPrintOverallC1S1.GetData(1, 1, dtTestDate.Value.Date);
            ucSulphurPrintOverallC1S2.GetData(1, 2, dtTestDate.Value.Date);
            ucSulphurPrintOverallC2S5.GetData(2, 5, dtTestDate.Value.Date);
            ucSulphurPrintOverallC2S6.GetData(2, 6, dtTestDate.Value.Date);
            ucSulphurPrintOverallC3S3.GetData(3, 3, dtTestDate.Value.Date);
            ucSulphurPrintOverallC3S4.GetData(3, 4, dtTestDate.Value.Date);

            //Sarclad overall
            ucsarcladOverallC1S1.GetData(1, 1, dtTestDate.Value.Date);
            ucsarcladOverallC1S2.GetData(1, 2, dtTestDate.Value.Date);
            ucsarcladOverallC2S5.GetData(2, 5, dtTestDate.Value.Date);
            ucsarcladOverallC2S6.GetData(2, 6, dtTestDate.Value.Date);
            ucSarcladOverallC3S3.GetData(3, 3, dtTestDate.Value.Date);
            ucSarcladOverallC3S4.GetData(3, 4, dtTestDate.Value.Date);

            //Strand Assessment
            ucStrandAssessmentOverallC1S1.GetData(1, 1, dtTestDate.Value.Date);
            ucStrandAssessmentOverallC1S2.GetData(1, 2, dtTestDate.Value.Date);
            ucStrandAssessmentOverallC2S5.GetData(2, 5, dtTestDate.Value.Date);
            ucStrandAssessmentOverallC2S6.GetData(2, 6, dtTestDate.Value.Date);
            ucStrandAssessmentOverallC3S3.GetData(3, 3, dtTestDate.Value.Date);
            ucStrandAssessmentOverallC3S4.GetData(3, 4, dtTestDate.Value.Date);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dtTestDate.Value = dtTestDate.Value.AddDays(-1);
            BindData();
        }
    }
}
