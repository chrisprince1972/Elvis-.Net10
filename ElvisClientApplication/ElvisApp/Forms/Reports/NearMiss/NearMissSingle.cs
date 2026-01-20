using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;
using NLog;

namespace Elvis.Forms.Reports.NearMiss
{
    public partial class NearMissSingle : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private int NearMissID { get; set; }

        public NearMissSingle(int nearMissID)
        {
            this.NearMissID = nearMissID;
            InitializeComponent();
        }

        /// <summary>
        /// Load the near miss report and display it.
        /// </summary>
        private void NearMiss_Load(object sender, EventArgs e)
        {
            try
            {
                SAS_NM_DataForElvis nmData = EntityHelper.SAS_NM_DataForElvis
                   .GetByNearMissID(this.NearMissID);

                bsSSNearMiss.DataSource = nmData;

                List<SAS_NM_Actions> nmActions = EntityHelper.SAS_NM_Actions
                    .GetByNearMissID(this.NearMissID);

                bsSSNearMissActions.DataSource = nmActions;

                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("NearMissID", NearMissID.ToString());

                this.rptNearMiss.LocalReport.SetParameters(parameters);
                this.rptNearMiss.RefreshReport();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- NearMiss_Load() -- Error generating near miss report -- ",
                    ex);
            }
        }
    }
}