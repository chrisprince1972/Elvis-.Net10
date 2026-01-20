using System.Windows.Forms;
using Elvis.Properties;
using System.Collections.Generic;
using System;
using ElvisDataModel.EDMX;

namespace Elvis.UserControls.CasterMachineCondition
{
    public partial class SingleStrandDetail : UserControl
    {
        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public SingleStrandDetail()
        {
            InitializeComponent();
            CustomiseColours();
            cmboCaster.SelectedIndex = 0;
            BindData();
            //cmboStrand.SelectedIndex = 1;
            //PopulateSprayWaterUserControl();  //Might be deleted
        }


        private void PopulateSprayWaterUserControl()
        {
            TestIndex latestTestIndex = ElvisDataModel.EntityHelper.CasterMachineCondition.GetTopSingle<TestIndex>("", "it.TestDate desc");
            cmboCaster.SelectedItem = latestTestIndex.Caster.ToString();
            ModifyStrandsDropDown((int)latestTestIndex.Caster,(int)latestTestIndex.Strand);
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


        /// <summary>
        /// Enable/Disable Strands in the Strand dropdown list depending on the selected Caster
        /// </summary>
        private void ModifyStrandsDropDown(int caster = 1, int Strand = 1)
        {
            cmboStrand.Items.Clear();
            switch (caster)
            {
                case 1:
                    cmboStrand.Items.Add(1);
                    cmboStrand.Items.Add(2);
                    break;
                case 2:
                    cmboStrand.Items.Add(5);
                    cmboStrand.Items.Add(6);
                    break;
                case 3:
                    cmboStrand.Items.Add(3);
                    cmboStrand.Items.Add(4);
                    break;
            }
            //cmboStrand.SelectedItem = Strand;
            cmboStrand.SelectedIndex = 0;
        }

        private void cmboCaster_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ModifyStrandsDropDown(Convert.ToInt32(cmboCaster.SelectedItem.ToString()));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            int caster, strand;

            int.TryParse(cmboCaster.SelectedItem.ToString(), out caster);
            int.TryParse(cmboStrand.SelectedItem.ToString(), out strand);

            ucSprayWater.GetData(caster, strand, dtTestDate.Value.Date);
            ucSulphurPrint.GetData(caster, strand, dtTestDate.Value.Date);
            ucUnitChangePriority.GetData(caster, strand);
            ucSarclad.GetData(caster, strand, dtTestDate.Value.Date);
            ucStrandAssessment.GetData(caster, strand, dtTestDate.Value.Date);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            dtTestDate.Value = dtTestDate.Value.AddDays(1);
            BindData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dtTestDate.Value = dtTestDate.Value.AddDays(-1);
            BindData();
        }

        private void pnlMain_Enter(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
