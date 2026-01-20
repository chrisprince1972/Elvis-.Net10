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

    public partial class SarcladSingle : UserControl
    {
        //private List<TestDetail> listSprayWaterData;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Caster { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Strand { get; set; }

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public SarcladSingle()
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
                dgvSarclad.BackgroundColor =
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
            List<GetSarcladDetail_Result> listSarcladData;
            int days = -1;

            try
            {
                do
                {
                    listSarcladData = ElvisDataModel.EntityHelper.SarcladDetails.
                                                GetByCasterStrandDate(testDate, caster, strand);
                    testDate = testDate.AddDays(-1);
                    days -= 1;
                                                            //CMCMaxDaysHistory max days to go back and look for data
                } while (listSarcladData.Count == 0 && days!=Settings.Default.CMCMaxDaysHistory);

                BindData(listSarcladData);

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
        private void BindData(List<GetSarcladDetail_Result> listSracladData)
        {
            dgvSarclad.AutoGenerateColumns = false;
            dgvSarclad.DataSource = listSracladData;
            dgvSarclad.Refresh();
            if (listSracladData.Count > 0)
            {
                lblDate.Text = listSracladData[0].TestDate.Value.ToShortDateString();
            }
            else
            {
                lblDate.Text = "";
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

        private void dgvSarclad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        { 
            if(dgvSarclad.Columns[e.ColumnIndex].Name.Equals("RollGap"))
            {
                e.CellStyle.BackColor = SetRollgapCellBGColor(e.Value.ToString());
                e.Value = SetRollgapCellValues(e.Value.ToString());
            }
            else if(dgvSarclad.Columns[e.ColumnIndex].Name.Equals("Backface"))
            {
                e.CellStyle.BackColor =  SetBackfaceCellBGColor(e.Value.ToString());
                e.Value = SetBackfaceCellValue(e.Value.ToString());
            }
        }

        private Color SetRollgapCellBGColor(string cellValue)
        {
            Color cellBgColor = Color.Transparent;

            float cellValueFloat;
            float.TryParse(cellValue, out cellValueFloat);

            if(cellValueFloat < 1)
            {
                cellBgColor = Color.LimeGreen;
            }
            else if(cellValueFloat >= 1 && cellValueFloat <= 1.3)
            {
                cellBgColor = Color.Khaki;
            }
            else if (cellValueFloat >= 1.3 && cellValueFloat <= 1.7)
            {
                cellBgColor = Color.Yellow;
            }
            else if (cellValueFloat >= 1.7 && cellValueFloat <= 2)
            {
                cellBgColor = Color.Orange;
            }
            else if (cellValueFloat > 2)
            {
                cellBgColor = Color.Red;
            }

            return cellBgColor;
        }

        private float SetRollgapCellValues(string cellValue)
        {
            float cellValueFloat;
            float.TryParse(cellValue, out cellValueFloat);

            if (cellValueFloat < 1)
            {
                cellValueFloat = 100;
            }
            else if (cellValueFloat >= 1 && cellValueFloat <= 1.3)
            {
                cellValueFloat = 75;
            }
            else if (cellValueFloat >= 1.3 && cellValueFloat <= 1.7)
            {
                cellValueFloat = 50;
            }
            else if (cellValueFloat >= 1.7 && cellValueFloat <= 2)
            {
                cellValueFloat = 25;
            }
            else if (cellValueFloat > 2)
            {
                cellValueFloat = 0;
            }

            return cellValueFloat;
        }

        private Color SetBackfaceCellBGColor(string cellValue)
        {
            Color cellBgColor = Color.Transparent;

            float cellValueFloat;
            float.TryParse(cellValue, out cellValueFloat);

            if (Math.Abs(cellValueFloat) < 1)
            {
                cellBgColor = Color.LimeGreen;
            }
            else if (Math.Abs(cellValueFloat) >= 1 && Math.Abs(cellValueFloat) <= 1.5)
            {
                cellBgColor = Color.Orange;
            }
            else if (Math.Abs(cellValueFloat) > 1.5)
            {
                cellBgColor = Color.Red;
            }

            return cellBgColor;
        }

        private float SetBackfaceCellValue(string cellValue)
        {
            float cellValueFloat;
            float.TryParse(cellValue, out cellValueFloat);

            if (Math.Abs(cellValueFloat) < 1)
            {
                cellValueFloat = 100;
            }
            else if (Math.Abs(cellValueFloat) >= 1 && Math.Abs(cellValueFloat) <= 1.5)
            {
                cellValueFloat = 50;
            }
            else if (Math.Abs(cellValueFloat) > 1.5)
            {
                cellValueFloat = 0;
            }

            return cellValueFloat;
        }
    }
}
