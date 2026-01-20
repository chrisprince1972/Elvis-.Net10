using System;
using System.Text;
using System.Windows.Forms;
using Elvis.Properties;
using NLog;

namespace Elvis.Forms.TrendingShifts.UserControls
{
    public partial class UnitsVertical : UserControl
    {
        #region Variables and Properties
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Property to determine if parent form should be 
        /// filtering on Units.
        /// </summary>
        public bool FilterMe
        {
            get
            {
                if (!rbHMAny.Checked || !rbDesAny.Checked || !rbVesselsAny.Checked ||
                    !chbSSAny.Checked || !rbCCAny.Checked)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Property to determine if parent form should be 
        /// filtering on HM Units.
        /// </summary>
        public string FilterHotMetal
        {
            get
            {
                if (rbHMNorth.Checked)
                    return "1";
                if (rbHMSouth.Checked)
                    return "2";
                return "NoFilter";
            }
        }

        /// <summary>
        /// Property to determine if parent form should be 
        /// filtering on Desulph Units.
        /// </summary>
        public string FilterDesulph
        {
            get
            {
                if (rbDesNorth.Checked)
                    return "3";
                if (rbDesSouth.Checked)
                    return "4";
                return "NoFilter";
            }
        }

        /// <summary>
        /// Property to determine if parent form should be 
        /// filtering on Vessel Units.
        /// </summary>
        public string FilterVessels
        {
            get
            {
                if (rbVessel1.Checked)
                    return "5";
                if (rbVessel2.Checked)
                    return "6";
                return "NoFilter";
            }
        }

        /// <summary>
        /// Property to determine if parent form should be 
        /// filtering on Sec Steel Units.
        /// </summary>
        public string FilterSecSteel
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (chbCAS1.Checked)
                    sb.Append("9|");
                if (chbCAS2.Checked)
                    sb.Append("10|");
                if (chbRD.Checked)
                    sb.Append("8|");
                if (chbRH.Checked)
                    sb.Append("7|");

                if (string.IsNullOrWhiteSpace(sb.ToString()) || 
                    chbSSAny.Checked)
                    return "NoFilter";
                else
                    return sb.ToString();
            }
        }

        /// <summary>
        /// Property to determine if parent form should be 
        /// filtering on Caster Units.
        /// </summary>
        public string FilterCasters
        {
            get
            {
                if (rbCC1.Checked)
                    return "11";
                if (rbCC2.Checked)
                    return "12";
                if (rbCC3.Checked)
                    return "13";
                return "NoFilter";
            }
        }

        #endregion

        public UnitsVertical()
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
                grpHotMetal.BackColor =
                grpDesulph.BackColor =
                grpVessels.BackColor =
                grpSecSteel.BackColor =
                grpCasters.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                grpHotMetal.ForeColor =
                grpDesulph.ForeColor =
                grpVessels.ForeColor =
                grpSecSteel.ForeColor =
                grpCasters.ForeColor =
                    Settings.Default.ColourText;
        }

        public void ResetSelections()
        {
            rbHMAny.Checked = rbDesAny.Checked =
            rbVesselsAny.Checked = chbSSAny.Checked =
            rbCCAny.Checked =
                true;

            chbCAS1.Checked = chbCAS2.Checked =
            chbRD.Checked = chbRH.Checked =
                false;
        }

        private void chbSSAny_CheckedChanged(object sender, EventArgs e)
        {
            chbCAS1.Enabled = chbCAS2.Enabled =
                chbRH.Enabled = chbRD.Enabled =
                !chbSSAny.Checked;
        }
    }
}
