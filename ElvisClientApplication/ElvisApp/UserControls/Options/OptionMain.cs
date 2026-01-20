using System;
using System.Windows.Forms;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Options
{
    public partial class OptionMain : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoUpdate { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DaysToShowModified { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OverviewDaysToShow { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TibDaysToShow { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MemoryLimit { get; set; }

        public OptionMain()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            chbAutoUpdate.Checked = AutoUpdate = Settings.Default.AutoUpdate;
            numOverviewDays.Value = OverviewDaysToShow = Settings.Default.OverviewDaysToShow;
            numTibDays.Value = TibDaysToShow = Settings.Default.TibDaysToShow;
            numMemoryUsage.Value = MemoryLimit = Settings.Default.MemoryLimit;
            DaysToShowModified = false;
        }

        private void chbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            AutoUpdate = chbAutoUpdate.Checked;
        }

        private void numOverviewDays_ValueChanged(object sender, EventArgs e)
        {
            OverviewDaysToShow = Convert.ToInt16(numOverviewDays.Value);
            DaysToShowModified = true;
        }

        private void numTibDays_ValueChanged(object sender, EventArgs e)
        {
            TibDaysToShow = Convert.ToInt16(numTibDays.Value);
            DaysToShowModified = true;
        }

        private void numMemoryUsage_ValueChanged(object sender, EventArgs e)
        {
            MemoryLimit = Convert.ToInt16(numMemoryUsage.Value);
        }

        private void btnMemoryDefault_Click(object sender, EventArgs e)
        {
            numMemoryUsage.Value = 400;
        }
    }
}
