using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Models.Reports.DailyManagementAgendaThreats;

namespace Elvis.Forms.Reports.ManagementAgendaThreats
{
    public partial class DMAThreatEdit : Form
    {
        private DailyManagementAgendaThreat DmaToEdit { get; set; }

        public DMAThreatEdit()
        {
            InitializeComponent();
        }

        public DMAThreatEdit(DailyManagementAgendaThreat dmatToEdit)
        {
            InitializeComponent();

            DmaToEdit = dmatToEdit;
            DmaToEdit.Reload();

            Text = labelTitle.Text = GetName();
            textBoxTextToEdit.Text = dmatToEdit.Threat;
        }

        private string GetName()
        {
            string threatLoc = ThreatLocation.GetLocationDescription(DmaToEdit.ThreatLocationId);
            string threatTime = ThreatTimeScale.GetTimeScaleDescription(DmaToEdit.ThreatTimeScaleId);
            return threatLoc + " - " + threatTime;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DmaToEdit.Threat = textBoxTextToEdit.Text;
            DmaToEdit.Save();
            Close();
        }

        private void DMAThreatEdit_Load(object sender, EventArgs e)
        {
            textBoxTextToEdit.Focus();
            textBoxTextToEdit.SelectionStart = 0;
            textBoxTextToEdit.SelectionLength = 0;
        }
    }
}
