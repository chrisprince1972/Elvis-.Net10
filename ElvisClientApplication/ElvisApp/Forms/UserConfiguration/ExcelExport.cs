using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using NPOI;
using ElvisDataModel.EDMX;
using Elvis.Common;


namespace Elvis.Forms.UserConfiguration
{
    public partial class ExcelExport : Form
    {
        #region Variables
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TIBReasonsView> DataToExport { get; set; }
        #endregion

        public ExcelExport()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sets the CommonMethods function to call dependent on whether or not the user wants to
        /// export an XLS or XLSX file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rdoXls.Checked == true)
            {
                CommonMethods.ExportDataToExcel(DataToExport);
            }
            else
            {
                CommonMethods.ExportDataToExcel(DataToExport, false);
            }
            this.Close();
        }
    }
}
