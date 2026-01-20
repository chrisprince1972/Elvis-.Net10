using Elvis.Properties;
using ElvisDataModel.EDMX;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Elvis.UserControls.CasterMachineCondition
{

    public partial class StrandAssessmentOverall : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Caster { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Strand { get; set; }

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public StrandAssessmentOverall()
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
                pnlMain.BackColor = Settings.Default.ColourBackground;

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

            try
            {
                StrandAssessment strandAssessment = ElvisDataModel.EntityHelper.CasterMachineCondition.GetTopSingle<StrandAssessment>
                                    ("it.Caster = " + caster + " and it.Strand = " + strand + " and it.AssessmentDate <= DATETIME '" + castDate.ToString("yyyy-MM-dd HH:mm") + "'"
                                    , "it.AssessmentDate desc");

                BindData(strandAssessment);
            }
            catch (Exception ex)
            {
                error = String.Format("Error getting data for the Sulphur Print. Error: {0}", ex.Message);
            }

            return error;
        }

        /// <summary>
        /// Binds spray watet test daya to the main grid + test details(date, caster, strand, speed...etc)
        /// </summary>
        /// <param name="listSprayWaterData"></param>
        private void BindData(StrandAssessment strandAssessment)
        {
            if (strandAssessment != null)
            {
                lblInternalCritical.Text = strandAssessment.InternalCritical;
                lblSlitting.Text = strandAssessment.Slitting;
                lblSpeedRestriction.Text = strandAssessment.CastingSpeed.ToString();
                txtComment.Text = strandAssessment.Comment;
            }
            else
            {
                lblInternalCritical.Text = "";
                lblSlitting.Text = "";
                lblSpeedRestriction.Text = "";
                txtComment.Text = "";
            }
        }

        private void tableLayoutPanelOverallSummary_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;
            //Get the cell value by row and column
            string cellValue = tableLayoutPanelOverallSummary.GetControlFromPosition(e.Column, e.Row).Text;

            if ((e.Row == 0 || e.Row == 1) && e.Column == 1)
            {
                g.FillRectangle(SharedCode.CMCShared.SetInternalCriticalColorCode(cellValue), r);
            }
        }
    }

}
