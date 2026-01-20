using System;
using System.Collections.Generic;
using Elvis.Properties;
using System.Windows.Forms;
using Elvis.Common;
using System.Drawing;
using ElvisDataModel;
using ElvisDataModel.EDMX;

/// Hot Metal DeSulph Model (HMDSM).
namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    public partial class DesulphModel : ElvisHeatDetailsUserControl
    {
        private List<HMDesModelData> listDesulphModelData;

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public DesulphModel()
        {
            InitializeComponent();
            dgvHMDesModel.AutoGenerateColumns = false;
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                dgvHMDesModel.BackgroundColor =
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
            listDesulphModelData = new List<HMDesModelData>();

            try
            {
                float? totalPouredWeight = GetTotalPouredWeightOfHeat();

                float? dipTemperature = GetHeatsHotMetalDipTemperature();

                float? startS = GetHeatsTransferLadleSampleAnalysisSulphur();

                float? aimSteelS = GetHotMetalTargetSulphur();

                foreach (HmdsmResult hmdsmResult in GetHotMetalDesulphModelResult())
                {
                    listDesulphModelData.Add(
                        new HMDesModelData(
                            hmdsmResult, 
                            totalPouredWeight, 
                            dipTemperature, 
                            startS, 
                            aimSteelS)
                        );
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;

        }

        /// <summary>
        /// When the thread has finished executing it will call this. So populate the data on the gridview.
        /// </summary>
        protected override void PopulateForm()
        {
            dgvHMDesModel.DataSource = listDesulphModelData;
            dgvHMDesModel.Refresh();
        }

        /// <summary>
        /// Passes back the control's main panel so it can overwrite the loading image.
        /// </summary>
        protected override void ShowMainPanel()
        {
            this.ShowMainPanel(pnlMain);
        }

        #region Get data to populate the grid view.
        /// <summary>
        /// Aim sulphur post vessel.
        /// </summary>
        /// <returns>A nullable floating point value of the quantity of sulphur aimed for.</returns>
        private float? GetHotMetalTargetSulphur()
        {
            float? aimSteelS = null;

            HeatAimAnalysi heatAimAnalysis = EntityHelper.HeatAimAnalysis.GetByHeat(
                this.heatNumber,
                this.heatNumberSet
                );

            if (heatAimAnalysis != null)
            {
                aimSteelS = heatAimAnalysis.S;
            }
            return aimSteelS;
        }

        /// <summary>
        /// Aim Sulphur post desulph.
        /// </summary>
        /// <returns>A nullable floating point value of the quantity of sulphur.</returns>
        private float? GetHeatsTransferLadleSampleAnalysisSulphur()
        {
            ElvisDataModel.EDMX.Analysis analysis = EntityHelper.Analysis.GetByHeatAndMaterialCode(
                this.heatNumber,
                this.heatNumberSet,
                29
            );

            float? startS = null;

            if (analysis != null)
            {
                startS = analysis.S;
            }

            return startS;
        }

        /// <summary>
        /// Temperature of iron from pour station dip.
        /// </summary>
        /// <returns>A nullable floating point of the temperature of the hot metal.</returns>
        private float? GetHeatsHotMetalDipTemperature()
        {
            EntityHelper.DipResult.DipType dipType = EntityHelper.DipResult.DipType.HotMetal;

            return EntityHelper.DipResult.GetHeatsTemperatureByDipType(
                        this.heatNumber,
                        this.heatNumberSet,
                        dipType
                    );
        }

        /// <summary>
        /// Weight of the poured Iron in tonnes.
        /// </summary>
        /// <returns>A nullable floating point of the summed total poured weight of each of the torpedos.</returns>
        private float? GetTotalPouredWeightOfHeat()
        {
            return EntityHelper.Torpedo.GetTotalPouredWeightOfHeat(
                this.heatNumber,
                this.heatNumberSet
                );
        }

        /// <summary>
        /// Gets a list of each of the Hot Metal DeSulph Models (HMDSM) for the heat.
        /// </summary>
        /// <returns>A list of HMDSMs.</returns>
        private List<HmdsmResult> GetHotMetalDesulphModelResult()
        {
            List<HmdsmResult> listHmdsmResult = EntityHelper.HmdsmResult.GetByHeat(
                this.heatNumber,
                this.heatNumberSet);

            return listHmdsmResult;
        }
        #endregion

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
        /// Helper class to contain and format each of the fields of the desulph results.
        /// </summary>
        class HMDesModelData
        {
            //Backing store for the 'front-ended' properties below.
            public DateTime? Time { get; set; }
            public float? startS, aimHMS, aimSteelS, wtLoss, temperatureLoss, totalMg, totalLime = 0;
            // Just show the time of the DateTime value.
            public string TimeAsString
            {
                get
                {
                    return Time.HasValue ? Time.Value.ToString("HH:mm:ss") : String.Empty;
                }
            }

            public float? HMWeight { get; set; }
            public float? HMTemperature { get; set; }
            public string StartS { get { return DisplayFloat(startS, 3); } }
            public string AimHMS { get { return DisplayFloat(aimHMS, 3); } }
            public string AimSteelS { get { return DisplayFloat(aimSteelS, 3); } }
            public string Type { get; set; }
            public float? EstInjTime { get; set; }

            public string WtLoss { get { return DisplayFloat(wtLoss, 0); } }
            public string TemperatureLoss { get { return DisplayFloat(temperatureLoss, 0); } }
            public string TotalMg { get { return DisplayFloat(totalMg, 0); } }
            public string TotalLime { get { return DisplayFloat(totalLime, 0); } }

            /// <summary>
            /// Constructor to build the object with the values given.
            /// </summary>
            /// <param name="hmdsmResult">Record from the hot metal desulpherisation model result table.</param>
            /// <param name="hmWeight">Weight of the poured Iron in tonnes.</param>
            /// <param name="temperature">Temperature of iron from pour station dip. (°C)</param>
            /// <param name="startS">Sulphur from iron before desulph.</param>
            /// <param name="aimSteelS">Aim sulphur post vessel.</param>
            public HMDesModelData(HmdsmResult hmdsmResult, float? hmWeight, 
                float? temperature, float? startS, float? aimSteelS)
            {
                //Run Time of the HMDSM.
                this.Time = hmdsmResult.HmdsmRunTimeStamp;
                this.HMWeight = hmWeight;
                this.HMTemperature = temperature;
                this.startS = startS;
                // Aim Sulphur post desulph.
                this.aimHMS = hmdsmResult.AimHMSulpur;
                this.aimSteelS = aimSteelS;

                //Convert to string using lookup table for presentation.
                this.Type = EntityHelper.HmdsmTreatmentTypes.GetDescriptionById(
                    hmdsmResult.HmdsmTreatmentTypeID
                    );

                //Estimated injection time in minutes.
                this.EstInjTime = hmdsmResult.TreatmentTime;
                //Weight lost during desulph process (skim loss). (t).
                this.wtLoss = hmdsmResult.HMWeightLoss;
                //Temperature change during process.
                this.temperatureLoss = hmdsmResult.HMTemperatureLoss;
                //The total amount of magnesium injected into iron. (kg).
                this.totalMg = hmdsmResult.TotalMgWeight;
                //Total amount of lime injected into the iron. (kg).
                this.totalLime = hmdsmResult.TotalLimeWeight;
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
