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

    public partial class SprayWaterSingle : UserControl
    {
        //private List<TestDetail> listSprayWaterData;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Caster { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Strand { get; set; }

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public SprayWaterSingle()
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
                dgvSprayWater.BackgroundColor =
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
            string error = String.Empty;
            List<GetStrandDetail_Result> listSprayWaterData;
            int days = -1;

            try
            {
                do
                {
                    listSprayWaterData = ElvisDataModel.EntityHelper.StrandSprayWater.
                                                 GetByCasterStrandDate(testDate, caster, strand);
                    testDate = testDate.AddDays(-1);
                    days -= 1;
                                                            //CMCMaxDaysHistory max days to go back and look for data
                } while (listSprayWaterData.Count == 0 && days!=Settings.Default.CMCMaxDaysHistory);

                BindData(listSprayWaterData);

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
        /// <param name="listSprayWaterData"></param>
        private void BindData(List<GetStrandDetail_Result> listSprayWaterData)
        {
            dgvSprayWater.AutoGenerateColumns = false;
            dgvSprayWater.DataSource = listSprayWaterData;
            dgvSprayWater.Refresh();

            if (listSprayWaterData.Count>0)
            {
                lblDate.Text = listSprayWaterData[0].TestDate.Value.ToShortDateString();
                lblSpeed.Text = listSprayWaterData[0].Speed.ToString();
                lblPractice.Text = listSprayWaterData[0].Practice.ToString();
            }
            else
            {
                lblDate.Text = "";
                lblSpeed.Text = "";
                lblPractice.Text = "";
            }
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

        private void dgvSprayWater_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(dgvSprayWater.Columns[e.ColumnIndex].Name.Equals("ActualFlow"))
            {
                e.CellStyle.BackColor = GetSprayWaterStatusColor((int)dgvSprayWater["Status", e.RowIndex].Value);
            }
        }

        private Color GetSprayWaterStatusColor(int statusInteger)
        {
            Color statusColor = Color.LimeGreen; ;

            if(statusInteger == 1)
            {
                statusColor = Color.LimeGreen;
            }
            else if(statusInteger == 2)
            {
                statusColor = Color.Yellow;
            }
            else if (statusInteger == 3)
            {
                statusColor = Color.Red;
            }

            return statusColor;
        }
    }

}
