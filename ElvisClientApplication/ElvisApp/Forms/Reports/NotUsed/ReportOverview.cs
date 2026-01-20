using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elvis.Forms
{
    public partial class ReportOverview : Form
    {
        #region Constructor
        public ReportOverview()
        {
            InitializeComponent();
            AddItemsToToolStrip();
            editReportToolStripMenuItem.Enabled = true;//Remove this once we populate the table etc.
            toolStripEditReport.Enabled = true;//Remove this once we populate the table etc.
            dgvReports.Refresh();
        }
        #endregion

        #region Menu + ToolStrip Events
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void createReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewReport();
        }
        private void toolStripCalenderBtnControls_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton btnClicked = (ToolStripButton)sender;//Get Button
                Control[] toolStripControls = toolStrip1.Controls.Find(
                    btnClicked.Tag.ToString(), true);//Find which date picker
                
                if (toolStripControls[0] is DateTimePicker)
                {//Send Date Picker to Method for processing
                    DateTimePicker datePicker = (DateTimePicker)toolStripControls[0];
                    EditDatePicker(datePicker, btnClicked.Text);
                }
            }
        }
        private void editReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditReport();
        }
        private void toolStripNewReport_Click(object sender, EventArgs e)
        {
            CreateNewReport();
        }
        private void toolStripEditReport_Click(object sender, EventArgs e)
        {
            EditReport();
        }
        #endregion

        #region Visual Mods

        #region Search Box
        private void toolStripSearchBox_Enter(object sender, EventArgs e)
        {
            if (toolStripSearchBox.Text == "[Report Number]")
            {
                toolStripSearchBox.Text = "";
                toolStripSearchBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            }
        }

        private void toolStripSearchBox_Leave(object sender, EventArgs e)
        {
            if (toolStripSearchBox.Text == "")
            {
                toolStripSearchBox.Text = "[Report Number]";
                toolStripSearchBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
        }
        #endregion 

        private void AddItemsToToolStrip()
        {
            //Adds both calenders and checkbox to the toolstrip (can't do it in designer)
            toolStrip1.Items.Insert(5, new ToolStripControlHost(dateFrom));//From Calender
            toolStrip1.Items.Insert(10, new ToolStripControlHost(dateTo));//To Calender
            toolStrip1.Items.Insert(17, new ToolStripControlHost(chbHistoric));//Checkbox
        }

        #endregion

        private void EditDatePicker(DateTimePicker datePicker, string direction)
        {
            if (direction == "Increase")
                datePicker.Value = datePicker.Value.AddDays(1);
            else
                datePicker.Value = datePicker.Value.AddDays(-1);
        }

        private void dgvReports_SelectionChanged(object sender, EventArgs e)
        {
            //Enable the Edit Report if row is selected
        }

        private void CreateNewReport()
        {
            
        }
        private void EditReport()
        {
            using (ReportSingular reportSingle = new ReportSingular(GetReportNo()))
            {
                 reportSingle.ShowDialog();
            }
        }

        private string GetReportNo()
        {
            //Get report number from selected item on dgvReports
            return "Test";
        }
    }
}
