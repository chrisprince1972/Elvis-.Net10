using System.Windows.Forms;
using System.ComponentModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class HeatsPlannedVsActual24HourTotals : UserControl
    {
        public HeatsPlannedVsActual24HourTotals()
        {
            InitializeComponent();
            _cc1Total = _cc2Total = _cc3Total = 0;
        }

        private int _cc1Total;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CC1Total
        {
            get { return _cc1Total; }
            set
            {
                _cc1Total = value;
                cc1TotalLabel.Text = _cc1Total.ToString();
                allCastersTotalLabel.Text = TotalHeats.ToString();
            }
        }

        private int _cc2Total;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CC2Total
        {
            get { return _cc2Total; }
            set
            {
                _cc2Total = value;
                cc2TotalLabel.Text = _cc2Total.ToString();
                allCastersTotalLabel.Text = TotalHeats.ToString();
            }
        }

        private int _cc3Total;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CC3Total
        {
            get { return _cc3Total; }
            set
            {
                _cc3Total = value;
                cc3TotalLabel.Text = _cc3Total.ToString();
                allCastersTotalLabel.Text = TotalHeats.ToString();
            }
        }

        public int TotalHeats
        {
            get { return CC1Total + CC2Total + CC3Total; }
        }

        public void SetCasterHeatsTotals(int cc1Total = 0, int cc2Total = 0, int cc3Total = 0)
        {
            CC1Total = cc1Total;
            CC2Total = cc2Total;
            CC3Total = cc3Total;
        }
    }
}