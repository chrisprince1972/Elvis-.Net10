using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Elvis.Common.ThirdPartyControls;
using NLog;
using Elvis.Common;

namespace Elvis.Forms.General
{
    public partial class FindHeatByGrade : Form
    {
        private List<HeatAimGrade> listHeatAimGrades;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool isMiscastAdmin;

        public FindHeatByGrade(bool isMiscastAdmin)
        {
            InitializeComponent();
            this.isMiscastAdmin = isMiscastAdmin;
            dgvResults.AutoGenerateColumns = false;
            elvisDateTimeRangeSelector.SetupUserControl(MyDateTime.Now.AddDays(-2), MyDateTime.Now.AddDays(1));
            GetData();
            PopulateGradesCombo();
            CustomiseColours();
        }

        private void GetData()
        {
            listHeatAimGrades = new List<HeatAimGrade>();
            try
            {
                List<Vessel> listVessel = EntityHelper.Vessel.GetRangeByStartTapTime(
                        this.elvisDateTimeRangeSelector.From,
                        this.elvisDateTimeRangeSelector.To
                    );

                foreach (Vessel vessel in listVessel)
                {
                    listHeatAimGrades.AddRange(
                        EntityHelper.HeatAimGrades.GetByHeat(vessel.HeatNumber, vessel.HNS)
                        );
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting data for FindHeatByGrade -- ",
                    ex);
                listHeatAimGrades = null;
            }
        }

        private void PopulateGradesCombo()
        {
            CommonMethods.ReadyCheckedComboBox(ccbGrades, 8, ", ");

            if (this.listHeatAimGrades != null)
            {
                //Loop data finding all the grades and adding them to combo box.
                foreach (HeatAimGrade heatAimGrade in 
                            Enumerable.DistinctBy(this.listHeatAimGrades,r => r.Grade)
                            .OrderBy(r => r.Grade)
                            .ToList())
                {
                    //Only add if grade exists and not already in list.
                    if (heatAimGrade.Grade.HasValue &&
                        heatAimGrade.Grade.Value > 0 &&
                        !ccbGrades.Items.Contains(heatAimGrade.Grade.Value.ToString()))
                    {
                        ccbGrades.Items.Add(new CCBoxItem(
                            heatAimGrade.Grade.ToString(),
                            heatAimGrade.Grade.Value)
                            );
                    }
                }
            }
        }

        private void CustomiseColours()
        {
            this.BackColor =
                panel1.BackColor = 
                grpFindHeat.BackColor =
                dgvResults.BackgroundColor = 
                        Settings.Default.ColourBackground;

            this.ForeColor =
                panel1.ForeColor = 
                grpFindHeat.ForeColor =
                            Settings.Default.ColourText;
        }

        private void Search()
        {
            this.Cursor = Cursors.WaitCursor;
            PopulateGridview(GetFilteredHeatAimGrades());
            this.Cursor = Cursors.Default;
        }

        private List<HeatAimGrade> GetFilteredHeatAimGrades()
        {
            List<HeatAimGrade> filteredHeatAimGrades = this.listHeatAimGrades;
            if (!chbAllGrades.Checked)
            {
                List<int> grades = new List<int>();
                foreach (CCBoxItem item in ccbGrades.CheckedItems)
                {
                    grades.Add(item.Value);
                }

                filteredHeatAimGrades = this.listHeatAimGrades
                    .Where(r => r.Grade.HasValue && grades.Contains(r.Grade.Value))
                    .ToList();
            }
            return filteredHeatAimGrades;
        }

        private void PopulateGridview(List<HeatAimGrade> filteredHeatAimGrades)
        {
            List<HeatAimGradeFindByGrade> gridviewData = new List<HeatAimGradeFindByGrade>();
            foreach (HeatAimGrade heatAimGrade in filteredHeatAimGrades)
            {
                gridviewData.Add(new HeatAimGradeFindByGrade()
                {
                    HeatNumber = heatAimGrade.HeatNumber,
                    HNS = heatAimGrade.HNS,
                    GradesAsString = GetGradeListAsString(heatAimGrade.HeatNumber, heatAimGrade.HNS),
                    ProgramNumber = heatAimGrade.ProgramNumber
                });
            }

            dgvResults.DataSource = gridviewData
                .OrderByDescending(r => r.HNS)
                .ThenByDescending(r => r.HeatNumber)
                .ToList();
        }

        private string GetGradeListAsString(int heatNumber, int heatNumberSet)
        {
            string gradeList = "";

            List<HeatAimGrade> filteredList = this.listHeatAimGrades
                .Where(h => 
                    h.HeatNumber == heatNumber && 
                    h.HNS == heatNumberSet)
                .ToList();

            if (filteredList != null)
            {
                gradeList = string.Join(", ", 
                    (Enumerable.DistinctBy(filteredList,r => r.Grade).Select(g => g.Grade)));
            }

            return gradeList;
        }

        private void OpenDgvResultsHeat(int index)
        {
            if (index >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                int heatNumberSet = 0;
                int heatNumber = 0;

                if (int.TryParse(dgvResults.Rows[index].Cells[0].Value.ToString(), out heatNumberSet) &&
                    int.TryParse(dgvResults.Rows[index].Cells[1].Value.ToString(), out heatNumber))
                {
                    HeatDetails hd = new HeatDetails(
                        heatNumber, false, false, 
                        this.isMiscastAdmin, heatNumberSet);
                    hd.Show();
                }
            }
        }

        #region events
        private void elvisDateTimeRangeSelector_OnChange(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GetData();
            PopulateGradesCombo();
            this.Cursor = Cursors.Default;
        }

        private void chbAllGrades_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ccbGrades.Enabled = !chbAllGrades.Checked;
            if (ccbGrades.Enabled)
            {
                for (int i = 0; i < ccbGrades.Items.Count; i++)
                {
                    ccbGrades.SetItemChecked(i, false);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenDgvResultsHeat(e.RowIndex);
            this.Cursor = Cursors.Default;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elvisDateTimeRangeSelector.SetupUserControl(MyDateTime.Now.AddDays(-2), MyDateTime.Now.AddDays(1));
            dgvResults.DataSource = null;
            this.Cursor = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Search();
            this.Cursor = Cursors.Default;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (dgvResults.CurrentCell != null)
            {
                OpenDgvResultsHeat(dgvResults.CurrentCell.RowIndex);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
        }

        private void FindHeatByGrade_KeyDown(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            this.Cursor = Cursors.Default;
        }

        private void FindHeatByGrade_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnSearch.PerformClick();
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
        }
        #endregion

        private class HeatAimGradeFindByGrade : HeatAimGrade
        {
            public string GradesAsString { get; set; }
        }
    }
}
