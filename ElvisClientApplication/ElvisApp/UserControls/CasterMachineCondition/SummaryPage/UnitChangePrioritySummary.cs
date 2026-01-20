using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using System.Linq;
using System.Reflection;

namespace Elvis.UserControls.CasterMachineCondition
{

    public partial class UnitChangePrioritySummary: UserControl
    {
        //public int Caster { get; set; }
        //public int Strand { get; set; }

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public UnitChangePrioritySummary()
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
                dgvUnitChnage.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }


        /// <summary>
        /// Gets the data for the entire user control by calling the relevant methods.
        /// </summary>
        /// <returns>Empty string on success.</returns>
        public string GetData()
        {
            string error = String.Empty;

            try
            {
                List<UnitChange> listUnitChange = ElvisDataModel.EntityHelper.CasterMachineCondition.
                                                  GetAllWithOrder<UnitChange>("it.Priority asc", "it.Priority != 4").ToList();
                BindData(listUnitChange);
            }
            catch (Exception ex)
            {
                error = String.Format("Error getting data for the Sulphur Print. Error: {0}", ex.Message);
            }

            return error;
        }

        /// <summary>
        /// Binds spray watet test daya to the main grid + test details(date, caster, strand, speed...etc)
        /// </summary>
        /// <param name="listSprayWaterData"></param>
        private void BindData(List<UnitChange> listUnitChange)
        {
            dgvUnitChnage.AutoGenerateColumns = false;
            dgvUnitChnage.DataSource = listUnitChange;
            dgvUnitChnage.Refresh();
        }


        /// <summary>
        /// Sets up the column header font after binding is complete.
        /// </summary>
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CommonMethods.FormatColumnFont(
                sender as DataGridView,
                new Font("Microsoft Sans Serif", 8, FontStyle.Bold));
        }

    }

}
