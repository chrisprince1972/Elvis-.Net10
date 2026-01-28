using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;
using Elvis.Common;

namespace Elvis.Forms.General
{
    public partial class Diagnostics : Form
    {
        private List<Log> logs = new List<Log>();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Diagnostics()
        {
            InitializeComponent();
            dgvErrorLog.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Once the Form has loaded, load the server status and logs.
        /// </summary>
        private void Diagnostics_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ucServerStatus != null)
            {
                ucServerStatus.PingServers();
            }

            GetLogData();

            if (this.logs != null && this.logs.Count > 0)
            {
                BindDataGridview();
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Obtains the filtered list and then binds the datagridview.
        /// </summary>
        private void BindDataGridview()
        {
            dgvErrorLog.DataSource = null;
            if (this.logs != null && this.logs.Count > 0)
            {
                List<Log> filteredList = new List<Log>();
                filteredList = GetFilteredLogs();

                if (filteredList != null && filteredList.Count > 0)
                {
                    dgvErrorLog.DataSource = filteredList;
                }
            }
        }

        /// <summary>
        /// Gets the Filtered Logs depending on 
        /// user settings.
        /// </summary>
        /// <returns>A list of Log Objects.</returns>
        private List<Log> GetFilteredLogs()
        {
            int monthsOfData = GetNoOfMonths();
            string username = Environment.UserName;
            string machineName = Environment.MachineName;
            DateTime dateFrom = MyDateTime.Now.AddMonths(-monthsOfData);

            if (menuAllLogs.Checked)
            {//Filter By Date
                return this.logs
                    .Where(l => l.TimeStamp >= dateFrom)
                    .ToList();
            }
            else
            {//Filter by User and Date
                return this.logs
                    .Where(l => 
                        l.UserName.Contains(username) && 
                        l.MachineName.Contains(machineName) && 
                        l.TimeStamp >= dateFrom)
                    .ToList();
            }
        }

        private int GetNoOfMonths()
        {
            if (menu1Month.Checked)
                return 1;
            return 3;
        }

        /// <summary>
        /// Gets the bulk data for future filtering.
        /// </summary>
        private void GetLogData()
        {
            try
            {
                this.logs = EntityHelper.Logs.GetByDate(3);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetLogData() -- Diagnostics.cs -- ", ex);
            }
        }

        /// <summary>
        /// Controls the Hide/Show of the Server Panel.
        /// </summary>
        private void btnShowServerStatus_Click(object sender, EventArgs e)
        {
            if (pnlServerStatus.Visible)
                pnlServerStatus.Visible = false;
            else
                pnlServerStatus.Visible = true;
        }

        /// <summary>
        /// Visible Changed event handler for the server panel.
        /// Ensures the checked menu item is the correct state.
        /// </summary>
        private void pnlServerStatus_VisibleChanged(object sender, EventArgs e)
        {
            menuServerStatus.Checked = pnlServerStatus.Visible;
        }

        /// <summary>
        /// Key down event handler.
        /// </summary>
        private void Diagnostics_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (ucServerStatus != null)
                {
                    ucServerStatus.PingServers();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 1 Month Button Click event handler.
        /// </summary>
        private void menu1Month_Click(object sender, EventArgs e)
        {
            menu1Month.Checked = true;
            menu3Months.Checked = false;
            BindDataGridview();
        }

        /// <summary>
        /// 3 Month Button Click event handler.
        /// </summary>
        private void menu3Months_Click(object sender, EventArgs e)
        {
            menu1Month.Checked = false;
            menu3Months.Checked = true;
            BindDataGridview();
        }

        /// <summary>
        /// My Log Button Click event handler.
        /// </summary>
        private void menuMyLog_Click(object sender, EventArgs e)
        {
            menuMyLog.Checked = true;
            menuAllLogs.Checked = false;
            BindDataGridview();
        }

        /// <summary>
        /// All Logs Button Click event handler.
        /// </summary>
        private void menuAllLogs_Click(object sender, EventArgs e)
        {
            menuMyLog.Checked = false;
            menuAllLogs.Checked = true;
            BindDataGridview();
        }

        /// <summary>
        /// Close window button event handler.
        /// </summary>
        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
