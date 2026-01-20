using System;
using System.Data;
using System.Windows.Forms;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;

namespace Elvis.Forms.Reports.DRF
{
    public partial class DRFReportExport : Form
    {
        #region Variables
        private int drfIndex;
        private DRFReport drfReport;
        #endregion

        /// <summary>
        /// Constructor for creating a new instance of the SingleDrfReport 
        /// form for printing a drf report.
        /// </summary>
        /// <param name="drfIndex">The DRF index to edit (Set to 
        /// Passing in DRFIndex from AddEditDRF).</param>
        /// <param name="tibDelayIndex">The Delay Index that the Report is associated with (set to zero if no delay).</param>
        public DRFReportExport(int drfIndex)
        {
            InitializeComponent();
            this.drfIndex = drfIndex;
            GetReport();
            BindReportView();

        }

        /// <summary>
        /// Gets the Report seperately from the other Data Function.
        /// </summary>
        private void GetReport()
        {
            this.drfReport = EntityHelper.DRFReport.GetSingle(this.drfIndex);
        }

        /// <summary>
        /// Load data table with report data, then pass to report viewer.
        /// </summary>
        private void BindReportView()
        {
            if (this.drfReport != null)
            {
                DRFReportBindingSource.DataSource = this.drfReport;
                this.rptSingleReport.RefreshReport();
                this.rptSingleReport.ZoomMode = ZoomMode.PageWidth;
            }
        }
    }
}
