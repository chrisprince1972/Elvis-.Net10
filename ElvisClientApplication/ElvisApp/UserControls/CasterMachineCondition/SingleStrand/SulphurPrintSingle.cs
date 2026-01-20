using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel;

namespace Elvis.UserControls.CasterMachineCondition
{

    public partial class SulphurPrintSingle : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Caster { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Strand { get; set; }

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public SulphurPrintSingle()
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
                dgvSulphurPrintDetails.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }


        /// <summary>
        /// Gets the data for the entire user control by calling the relevant methods.
        /// </summary>
        /// <returns>Empty string on success.</returns>
        public string GetData(int caster, int strand, DateTime castDate)
        {
            this.Caster = caster;
            this.Strand = strand;
            string error = String.Empty;
            int days = -1, counter=0;

            try
            {
                string ICAssessment = string.Empty;
                //List below will hold the data that is bound to the gridview
                List<ElvisDataModel.Classes.SulphurPrintSegmentDetails> listSulphurPrintSegmentDetails = new List<ElvisDataModel.Classes.SulphurPrintSegmentDetails>();
                GetSulphutPrintDetails_Result suplhurPrintDetails;
                //Get Sulphut Print details
                do { 
                        suplhurPrintDetails = ElvisDataModel.EntityHelper.SulphurPrintDetails.
                                              GetByCasterStrandDate(castDate, caster, strand);
                    castDate = castDate.AddDays(-1);
                    days -= 1;
                                                            //CMCMaxDaysHistory max days to go back and look for data
                } while (suplhurPrintDetails == null && days!=Settings.Default.CMCMaxDaysHistory);

                if (suplhurPrintDetails != null)
                {
                    StringBuilder sqlFilterQuery = new StringBuilder();
                    sqlFilterQuery.Append("it.caster = ");
                    sqlFilterQuery.Append(Caster);

                    if (Caster == 3)
                    {
                        sqlFilterQuery.Append(" and it.StrandPosition != -1 ");
                    }
                    else
                    {
                        sqlFilterQuery.Append(" and (it.StrandPosition != -1 and  it.StrandPosition != 0 ) ");
                    }
                    //Get strand details for the selected Caster
                    List<StrandConfig> listStrandConfig = ElvisDataModel.EntityHelper.CasterMachineCondition.GetAll<StrandConfig>(sqlFilterQuery.ToString()).ToList();

                    //Sulphur print IC Assessment are stored in one row, we have to convert the row to an array to access them properly in the loop
                    PropertyInfo[] sulphutPrintProperties = suplhurPrintDetails.GetType().GetProperties();

                    //Get Segment Snapshotdtails
                    List<GetSegmentSnapshotDetails_Result> listSegmentSnapshotDetails = ElvisDataModel.EntityHelper.SegmentSnapshotDetails.GetByCasterStrandDate(castDate, caster, strand);


                    if (listStrandConfig.Count < listSegmentSnapshotDetails.Count)
                    {
                        counter = listStrandConfig.Count;
                    }
                    else
                    {
                        counter = listSegmentSnapshotDetails.Count;
                    }


                    for (int i = 0; i < counter; i++)
                    {
                        foreach (PropertyInfo propInfo in sulphutPrintProperties)
                        {
                            if (propInfo.Name.Equals("IC" + (i + 1)))
                            {
                                ICAssessment = Convert.ToString(propInfo.GetValue(suplhurPrintDetails, null));
                            }
                        }
                        listSulphurPrintSegmentDetails.Add(new ElvisDataModel.Classes.SulphurPrintSegmentDetails
                        {
                            Segment = listStrandConfig[i].Description,
                            ICAssessment = ICAssessment,
                            DateInstalled = Convert.ToDateTime(listSegmentSnapshotDetails[i].DateInstall),
                            DaysInService = Convert.ToInt32(listSegmentSnapshotDetails[i].DaysInService),
                            TonnesCast = float.Parse(listSegmentSnapshotDetails[i].TonnesCast.ToString()),
                            GreenLookup  = float.Parse(suplhurPrintDetails.GreenLookup.ToString()),
                            RedLookup = float.Parse(suplhurPrintDetails.RedLookup.ToString())
                        });
                    }
                }
                BindData(suplhurPrintDetails, listSulphurPrintSegmentDetails);
            }
            catch (Exception ex)
            {
                error = String.Format("Error getting data for the Sulphur Print. Error: {0}", ex.Message);
            }

            return error;
        }

        /// <summary>
        /// Binds Sulphur Print data to the main grid + test details(date, caster, strand, speed...etc)
        /// </summary>
        /// <param name="listSulphurPrintSegmentDetails"></param>
        private void BindData(GetSulphutPrintDetails_Result suplhurPrintDetails, 
                              List<ElvisDataModel.Classes.SulphurPrintSegmentDetails> listSulphurPrintSegmentDetails)
        {
            dgvSulphurPrintDetails.AutoGenerateColumns = false;
            dgvSulphurPrintDetails.DataSource = listSulphurPrintSegmentDetails;
            dgvSulphurPrintDetails.Refresh();

            if (suplhurPrintDetails != null)
            {
                lblDate.Text = suplhurPrintDetails.DateCast.Value.ToShortDateString();
                lblSlabNumer.Text = suplhurPrintDetails.SlabNumber.ToString();
                lblSpeed.Text = suplhurPrintDetails.CastSpeed.ToString();
                lblGrade.Text = suplhurPrintDetails.SlabGrade.ToString();
                lblWidth.Text = suplhurPrintDetails.SlabWidth.ToString();
                lblReported.Text = suplhurPrintDetails.CLReported.ToString();
                lblLocation.Text = suplhurPrintDetails.CLLocation.ToString();
            }
            else
            {
                lblDate.Text = "";
                lblSlabNumer.Text = "";
                lblSpeed.Text = "";
                lblGrade.Text = "";
                lblWidth.Text = "";
                lblReported.Text ="";
                lblLocation.Text = "";
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

        private void dgvSulphurPrintDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            float greenLookup, redLookup;

            if(dgvSulphurPrintDetails.Columns[e.ColumnIndex].Name.Equals("ICAssessment"))
            {
                greenLookup = float.Parse(dgvSulphurPrintDetails.Rows[e.RowIndex].Cells["GreenLookup"].Value.ToString());
                redLookup = float.Parse(dgvSulphurPrintDetails.Rows[e.RowIndex].Cells["RedLookup"].Value.ToString());
                e.CellStyle.BackColor = SharedCode.CMCShared.SetICbgColor(e.Value.ToString(), greenLookup, redLookup);
            }
        }


    }

}
