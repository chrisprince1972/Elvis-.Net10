using System;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using System.Drawing;
using System.ComponentModel;

namespace Elvis.UserControls.CasterMachineCondition
{

    public partial class StrandAssessmentSummary : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Caster { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Strand { get; set; }
        StrandAssessment strandAssessment;

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public StrandAssessmentSummary()
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
            int daysSinceLastSarclad = 0;
            DateTime? sarcladTestDate;
            string error = String.Empty;

            try
            {
                strandAssessment = ElvisDataModel.EntityHelper.CasterMachineCondition.GetTopSingle<StrandAssessment>
                                             ("it.Caster = " + caster + " and it.Strand = " + strand, "it.AssessmentDate desc");

                sarcladTestDate = ElvisDataModel.EntityHelper.CasterMachineCondition.GetTopSingle<SarcladTestIndex>
                                       ("it.Caster = " + caster + " and it.Strand = " + strand, "it.TestDate desc").TestDate;
                daysSinceLastSarclad = (DateTime.Now - sarcladTestDate).Value.Days;
                BindData(strandAssessment, daysSinceLastSarclad);
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
        private void BindData(StrandAssessment strandAssessment, int daysSinceLastSarclad)
        {

            if (strandAssessment != null)
            {
                lblInternalCritical.Text = strandAssessment.InternalCritical;
                //Slitting only available on Caster 3
                if (strandAssessment.Caster == 3)
                {
                    lblSlitting.Text = strandAssessment.Slitting;
                }
                else
                {
                    lblSlitting.Text = " ";
                }
                lblSpeedRestriction.Text = strandAssessment.CastingSpeed.ToString();
                lblDaysSinceLastSarclad.Text = daysSinceLastSarclad.ToString();
            }
            else
            {
                lblInternalCritical.Text = "";
                lblSlitting.Text = "";
                lblSpeedRestriction.Text = "";
                lblDaysSinceLastSarclad.Text = "";
            }
        }

        /// <summary>
        /// Paint the cell values with the required color code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableLayoutPanelSummary_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;
            //Get the cell value by row and column
            string cellValue = tableLayoutPanelSummary.GetControlFromPosition(e.Column, e.Row).Text;

            if (e.Row == 0)
            {
                g.FillRectangle(SharedCode.CMCShared.SetInternalCriticalColorCode(cellValue), r);
            }
            //Slitting only available to caster 3
            if (strandAssessment.Caster == 3 && e.Row == 1)
            {
                g.FillRectangle(SharedCode.CMCShared.SetInternalCriticalColorCode(cellValue), r);
            }
            //Days since last Sarclad
            else if (e.Row == 3)
            {
                g.FillRectangle(SharedCode.CMCShared.SetDaysSinceLastSarcladColorCode(cellValue, Caster, Strand), r);
            }
        }
    }
}
