using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using System.ComponentModel;

namespace Elvis.UserControls.CasterMachineCondition
{

    public partial class SegmentConfig : UserControl
    {
        //private List<TestDetail> listSprayWaterData;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Caster { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Strand { get; set; }

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public SegmentConfig()
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
                dgvSegConfig.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the entire user control by calling the relevant methods.
        /// </summary>
        /// <returns>Empty string on success.</returns>
        public string GetData(int caster, int strand, DateTime testDate)
        {
            this.Caster = caster;
            this.Strand = strand;

            List<GetStrandSegmentConfig_Result> listStrandSegmentConfig;
            string error = String.Empty;
            int days = -1;

            try
            {
                do
                {
                    listStrandSegmentConfig = ElvisDataModel.EntityHelper.StrandSegmentConfig.
                                              GetByCasterStrandDate(string.Format("{0:dd/MMM/yyyy}",testDate), caster, strand);
                    testDate = testDate.AddDays(-1);
                    days -= 1;
                                                            //CMCMaxDaysHistory max days to go back and look for data
                } while (listStrandSegmentConfig.Count == 0 && days != Settings.Default.CMCMaxDaysHistory);
                BindData(listStrandSegmentConfig);
            }
            catch (Exception ex)
            {
                error = String.Format("Error getting data for the spray water. Error: {0}", ex.Message);
            }

            return error;
        }

        /// <summary>
        /// Binds spray watet test daya to the main grid + test details(date, caster, strand, speed...etc)
        /// </summary>
        /// <param name="listSracladData"></param>
        private void BindData(List<GetStrandSegmentConfig_Result> listSegmentSnapshotDetail)
        {
            dgvSegConfig.AutoGenerateColumns = false;
            dgvSegConfig.DataSource = listSegmentSnapshotDetail;
            dgvSegConfig.Refresh();
        }
        
        /// <summary>
        /// Sets up the column header font after binding is complete.
        /// </summary>
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CommonMethods.FormatColumnFont(
                sender as DataGridView,
                new Font("Microsoft Sans Serif", 8, FontStyle.Bold));
        }

        private void dgvSegConfig_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            decimal PlannedTonnage, NeedsReplacingTonnage;
            if (e.Value != null)
            {
                if (dgvSegConfig.Columns[e.ColumnIndex].Name.Equals("TonnesCast"))
                {
                    PlannedTonnage = Convert.ToDecimal(dgvSegConfig.Rows[e.RowIndex].Cells["PlannedTonnage"].Value);
                    NeedsReplacingTonnage = Convert.ToDecimal(dgvSegConfig.Rows[e.RowIndex].Cells["NeedsReplacingTonnage"].Value);
                    e.CellStyle.BackColor = SharedCode.CMCShared.SetSegmentTonnageColor(e.Value.ToString(), PlannedTonnage, NeedsReplacingTonnage);
                }
            }
        }
    }

}
