using System;
using System.Collections.Generic;
using Elvis.Properties;
using System.Windows.Forms;
using Elvis.Common;
using System.Drawing;

namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    public partial class InjectionDetails : ElvisHeatDetailsUserControl
    {
        private List<InjectionData> listInjectionData = new List<InjectionData>();

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public InjectionDetails()
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
                dgvInjection.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to put the values into the control.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        public override void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            base.SetHeatDetails(heatNumber, heatNumberSet);
        }

        /// <summary>
        /// Gets the data for the entire user control by calling the relevant methods.
        /// </summary>
        /// <returns>Empty string on success.</returns>
        protected override string GetData()
        {
            string error = string.Empty;

            try
            {
                List<ElvisDataModel.EDMX.HMDesulphReport> listHMDesulphReports
                    = ElvisDataModel
                    .EntityHelper
                    .HMDesulphResult
                    .GetByHeat(heatNumber, heatNumberSet);

                listInjectionData.Clear();

                foreach (ElvisDataModel.EDMX.HMDesulphReport hmDesulphReport in listHMDesulphReports)
                {
                    listInjectionData.Add(new InjectionData(hmDesulphReport));
                }
            }
            catch (Exception ex)
            {
                error += ex.Message;
            }

            return error;
        }

        /// <summary>
        /// When the thread has finished executing it will call this. So populate the data on the gridview.
        /// </summary>
        protected override void PopulateForm()
        {
            dgvInjection.AutoGenerateColumns = false;
            dgvInjection.DataSource = listInjectionData;
            dgvInjection.Refresh();
        }

        /// <summary>
        /// Passes back the control's main panel so it can overwrite the loading image.
        /// </summary>
        protected override void ShowMainPanel()
        {
            ShowMainPanel(pnlMain);
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

        /// <summary>
        /// Helper class to contain and format each of the fields of the injection data.
        /// </summary>
        private class InjectionData
        {
            //Backing store for the 'front-ended' properties below.
            public DateTime? Time { get; set; }
            public string TimeAsString
            {
                get
                {
                    return Time.HasValue ? Time.Value.ToString("HH:mm:ss") : String.Empty;
                }
            }

            public float? MgDemand { get; set; }
            public float? MgActual { get; set; }
            public float? LimeDemand { get; set; }
            public float? LimeActual { get; set; }

            public InjectionData(ElvisDataModel.EDMX.HMDesulphReport hmDesulphReport)
            {
                this.Time = hmDesulphReport.TimeStamp;
                this.MgDemand = hmDesulphReport.MgDemand;
                this.MgActual = hmDesulphReport.MgActual;
                this.LimeDemand = hmDesulphReport.LimeDemand;
                this.LimeActual = hmDesulphReport.LimeActual;
            }

            /// <summary>
            /// Helper function to format a floating point value.
            /// </summary>
            /// <param name="f">Floating point value to format.</param>
            /// <param name="decimals">Integer of the amount of decimal places to display.</param>
            /// <returns>String of float showing number of decimal places or empty string if null.</returns>
            private static string DisplayFloat(float? f, int decimals)
            {
                return f.HasValue ? Math.Round(f.Value, decimals).ToString() : String.Empty;
            }
        }
    }
}
