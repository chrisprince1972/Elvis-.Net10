using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{

    public partial class HotMetalMakeUp : ElvisHeatDetailsUserControl
    {
        private List<HotMetalMakeUpData> listHotMetalMakupData;

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public HotMetalMakeUp()
        {
            listHotMetalMakupData = new List<HotMetalMakeUpData>();
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
                dgvHotMetalData.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the entire user control by calling the relevant methods.
        /// </summary>
        /// <returns>Empty string on success.</returns>
        protected override string GetData()
        {
            string error = String.Empty;
            listHotMetalMakupData.Clear();

            try
            {
                AddTorpedoData();
                AddCbmEstimateData();
                AddDipResultData(ElvisDataModel.EntityHelper.DipResult.DipType.HotMetal);
                AddPreDesHMData();
                AddDipResultData(ElvisDataModel.EntityHelper.DipResult.DipType.Sulphox);
            }
            catch (Exception ex)
            {
                error = String.Format("Error getting data for the hot metal make up. Error: {0}",
                    ex.Message);
            }

            return error;
        }

        /// <summary>
        /// When the thread has finished executing it will call this. So populate the data on the gridview.
        /// </summary>
        protected override void PopulateForm()
        {
            dgvHotMetalData.AutoGenerateColumns = false;
            dgvHotMetalData.DataSource = listHotMetalMakupData;
            dgvHotMetalData.Refresh();
        }

        /// <summary>
        /// Passes back the control's main panel so it can overwrite the loading image.
        /// </summary>
        protected override void ShowMainPanel()
        {
            this.ShowMainPanel(pnlMain);
        }

        /// <summary>
        /// Gets list of records from the torpedo table and adds them to the 
        /// main list after using the custom class below to filter the data.  
        /// </summary>
        public void AddTorpedoData()
        {
            List<ElvisDataModel.EDMX.Torpedo> lstTorpedo
                = ElvisDataModel
                .EntityHelper
                .Torpedo
                .GetByHeat(this.heatNumber, this.heatNumberSet);

            foreach (ElvisDataModel.EDMX.Torpedo torp in lstTorpedo)
            {
                this.listHotMetalMakupData.Add(new HotMetalMakeUpData(torp));
            }

        }


        /// <summary>
        /// Gets list of records from the Analysis table and adds them to the 
        /// main list after using the custom class below to filter the data.  
        /// </summary>
        private void AddPreDesHMData()
        {
            ElvisDataModel.EDMX.Analysis analysis
               = ElvisDataModel
               .EntityHelper
               .Analysis
               .GetByHeatAndMaterialCode(this.heatNumber, this.heatNumberSet, 29);


            if (analysis != null)
            {
                HotMetalMakeUpData hmdm
                    = new HotMetalMakeUpData(analysis);
                this.listHotMetalMakupData.Add(hmdm);
            }
        }

        /// <summary>
        /// Gets list of records from the DipResult table and adds them to the 
        /// main list after using the custom class below to filter the data.  
        /// </summary>
        private void AddDipResultData(EntityHelper.DipResult.DipType dipType)
        {
            var dipTypes = new List<EntityHelper.DipResult.DipType>() { dipType };

            List<DipResult> lstHMDipResult = EntityHelper.DipResult
               .GetByHeatDipTypeList(this.heatNumber, this.heatNumberSet, dipTypes)
               .OrderBy(r => r.TimeStamp)
               .ToList();

            foreach (DipResult dip in lstHMDipResult)
            {
                HotMetalMakeUpData hmdm
                    = new HotMetalMakeUpData(dip);
                this.listHotMetalMakupData.Add(hmdm);
            }
        }

        /// <summary>
        /// Gets list of records from the CbmResult table and adds them to the 
        /// main list after using the custom class below to filter the data.  
        /// </summary>
        private void AddCbmEstimateData()
        {

            ElvisDataModel.EDMX.CbmResult cbmResult
               = ElvisDataModel
               .EntityHelper
               .CbmResult
               .GetByHeat(this.heatNumber, this.heatNumberSet)
               .OrderByDescending(r => r.CbmRunNumber)
               .FirstOrDefault();

            if (cbmResult != null)
            {
                HotMetalMakeUpData hmdm
                    = new HotMetalMakeUpData(cbmResult);

                this.listHotMetalMakupData.Add(hmdm);
            }
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
        /// A helper class to convert certain table record objects to ones 
        /// that can be displayed in the format requried.
        /// </summary>
        class HotMetalMakeUpData
        {
            public string RowDescription { get; private set; }
            //Backing store for the 'front-ended' properties below.
            private float? carbon, silicon, sulphur, phosphorous, manganese, temperature;
            public string Carbon { get { return DisplayFloat(carbon, 2); } }
            public string Silicon { get { return DisplayFloat(silicon, 2); } }
            public string Sulphur { get { return DisplayFloat(sulphur, 3); } }
            public string Phosphorous { get { return DisplayFloat(phosphorous, 3); } }
            public string Manganese { get { return DisplayFloat(manganese, 3); } }
            public string Temperature { get { return DisplayFloat(temperature, 0); } }
            public float? RequiredWeight { get; set; }
            public float? ActualWeight { get; set; }
            public DateTime? Time { get; set; }

            /// <summary>
            /// Format DateTime as time.
            /// </summary>
            public string TimeAsString
            {
                get
                {
                    return Time.HasValue ? Time.Value.ToString("HH:mm") : String.Empty;
                }
            }

            /// <summary>
            /// Prepare float values for presentation.  Empty string if null.
            /// </summary>
            /// <param name="f">Nullable float.</param>
            /// <param name="decimals">Number of decimal places.</param>
            /// <returns></returns>
            private static string DisplayFloat(float? f, int decimals)
            {
                return f.HasValue ? Math.Round(f.Value, decimals).ToString() : String.Empty;
            }

            /// <summary>
            /// Contructor to build object based on the values from a Torpedo record.
            /// </summary>
            /// <param name="value">Torpedo record to populate it's values with.</param>
            public HotMetalMakeUpData(ElvisDataModel.EDMX.Torpedo value)
            {
                SetTripInfo(value.TorpedoNumber, value.BfNumber);
                this.carbon = value.IronC;
                this.silicon = value.IronSi;
                this.sulphur = value.IronS;
                this.phosphorous = value.IronP;
                this.manganese = value.IronMn;
                this.temperature = value.RunnerTemperature;
                //this.RequiredWeight = value.EstimatedWeight;
                this.RequiredWeight = null;//Temporary fix until they decide on what they want to show here.
                this.ActualWeight = value.TotalPouredWeight;
                this.Time = value.PourStationTime;
            }

            /// <summary>
            /// Contructor to build object based on the values from a CbmResult record.
            /// </summary>
            /// <param name="value">CbmResult record to populate it's values with.</param>
            public HotMetalMakeUpData(ElvisDataModel.EDMX.CbmResult value)
            {
                this.RowDescription = "CBM Estimate";
                this.carbon = value.HM_CARBON;
                this.silicon = value.HM_SILICON;
                this.sulphur = value.HM_SULPHUR;
                this.phosphorous = value.HM_PHOSPHORUS;
                this.manganese = value.HM_MANGANESE;
                this.temperature = value.HM_TEMPERATURE;
                this.RequiredWeight = null;
                this.ActualWeight = null;
                this.Time = value.RUN_TIME;
            }

            /// <summary>
            /// Contructor to build object based on the values from a DipResult record.
            /// </summary>
            /// <param name="value">DipResult record to populate it's values with.</param>
            public HotMetalMakeUpData(ElvisDataModel.EDMX.DipResult value)
            {
                if (value.DipType == 7)
                {
                    this.RowDescription = "HM Dip";
                    this.sulphur = null;
                }
                else if (value.DipType == 2)
                {
                    this.RowDescription = "Desulph Dip";
                    this.sulphur = value.S;
                }

                this.carbon = value.Carbon;
                this.silicon = null;
                this.phosphorous = null;
                this.manganese = null;
                this.temperature = value.Temperature;
                this.RequiredWeight = null;
                this.ActualWeight = null;
                this.Time = value.TimeStamp;
            }

            /// <summary>
            /// Contructor to build object based on the values from a Analysis record.
            /// </summary>
            /// <param name="value">Analysis record to populate it's values with.</param>
            public HotMetalMakeUpData(ElvisDataModel.EDMX.Analysis value)
            {
                this.RowDescription = "Pre Des HM";

                this.carbon = value.C;
                this.silicon = value.Si;
                this.sulphur = value.S;
                this.phosphorous = value.P;
                this.manganese = value.Mn;
                this.temperature = null;
                this.RequiredWeight = null;
                this.ActualWeight = null;
                this.Time = value.TimeStamp;
            }

            /// <summary>
            /// Helper function to build the heading of the row for a Torpedo.
            /// </summary>
            /// <param name="torpedoNumber"></param>
            /// <param name="blastFurnaceId"></param>
            private void SetTripInfo(int torpedoNumber, int? blastFurnaceId)
            {
                string bfId = blastFurnaceId.HasValue ? blastFurnaceId.Value.ToString() : "";
                this.RowDescription = String.Format("Torp {0} BF {1}", torpedoNumber, blastFurnaceId);
            }
        }
    }

}
