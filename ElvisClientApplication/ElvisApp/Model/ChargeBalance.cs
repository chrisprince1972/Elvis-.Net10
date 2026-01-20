using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace Elvis.Model
{
    public static class ChargeBalance
    {

        #region CBM Overview
        /// <summary>
        /// Generates the records used for the CBM Overview Table on the 
        /// ChargeBalanceControl User Control.
        /// </summary>
        /// <param name="heatNumber">The Heat Number.</param>
        /// <param name="heatNumberSet">The Heat Number Set.</param>
        /// <returns>A List of CBMOverviewRow Objects.</returns>
        public static List<CBMOverviewRow> GetCBMOverviewData(
            int heatNumber, int heatNumberSet,
            List<CbmDisplayMaterial> cbmDisplayMaterials,
            List<CbmDisplayAnalysis> cbmDisplayAnalysis)
        {
            List<CBMOverviewRow> cbmOverview = new List<CBMOverviewRow>();
            List<CbmResult> cbmResults = EntityHelper.CbmResult.GetByHeat(heatNumber, heatNumberSet);

            if (cbmResults != null)
            {
                foreach (CbmResult result in cbmResults)
                {
                    CBMOverviewRow cbmRow = new CBMOverviewRow();
                    cbmRow.MaterialList = new List<CBMMaterial>();

                    //Populate easy data
                    if (result.RUN_TIME.HasValue &&
                        result.RUN_TIME.Value > DateTime.MinValue)
                    {
                        cbmRow.Time = result.RUN_TIME.Value;
                    }
                    if (result.CONVERTER.HasValue &&
                        result.CONVERTER.Value > 0)
                    {
                        cbmRow.VesselNo = result.CONVERTER.Value;
                    }
                    if (result.PREDICTED_SLAG_MGO.HasValue)
                    {
                        cbmRow.SlagMgO = result.PREDICTED_SLAG_MGO.Value;
                    }
                    if (result.PREDICTED_SLAG_FEO.HasValue)
                    {
                        cbmRow.SlagVR = result.PREDICTED_SLAG_FEO.Value;
                    }
                    if (result.CbmRunNumber.HasValue)
                    {
                        cbmRow.RunNumber = result.CbmRunNumber.Value;
                    }

                    //Get the Material/Analysis info for that row.
                    if (cbmDisplayAnalysis != null)
                    {
                        CbmDisplayAnalysis displayAnalysisRow = cbmDisplayAnalysis
                                .FirstOrDefault(c =>
                                    c.CbmRunNumber == result.CbmRunNumber
                            );

                        if (displayAnalysisRow != null)
                        {
                            cbmRow.MaterialList.AddRange(GetMaterialList(displayAnalysisRow));
                        }
                    }

                    if (cbmDisplayMaterials != null)
                    {
                        CbmDisplayMaterial displayMaterialRow = cbmDisplayMaterials
                                .FirstOrDefault(c =>
                                    c.CbmRunNumber == result.CbmRunNumber
                            );

                        if (displayMaterialRow != null)
                        {
                            cbmRow.MaterialList.AddRange(GetMaterialList(displayMaterialRow));
                        }
                    }

                    cbmOverview.Add(cbmRow);
                }
            }

            return cbmOverview;
        }

        /// <summary>
        /// Builds the Material List for a specific row concerning the
        /// CBM Display Analysis table.  Add materials in here if you wish to add
        /// any additional Columns.
        /// </summary>
        /// <param name="displayAnalysisRow">The row you wish to add the material data to.</param>
        /// <returns>A list of CBMMaterials</returns>
        private static List<CBMMaterial> GetMaterialList(CbmDisplayAnalysis displayAnalysisRow)
        {
            List<CBMMaterial> materialList = new List<CBMMaterial>();

            AddMaterial(
                "HM Si",
                displayAnalysisRow.HM_LADLE_SILICON,
                displayAnalysisRow.CALC_HM_SILICON,
                materialList);

            AddMaterial(
                "HM S",
                displayAnalysisRow.HM_LADLE_SULPHUR,
                displayAnalysisRow.CALC_HM_SULPHUR,
                materialList);

            AddMaterial(
                "HM Temp",
                displayAnalysisRow.HM_LADLE_TEMPERATURE,
                displayAnalysisRow.CALC_HM_TEMPERATURE,
                materialList);

            //Add any new materials here that you wish to add to the table from the Analysis

            return materialList;
        }

        /// <summary>
        /// Builds the Material List for a specific row concerning the
        /// CBM Display Materials table.  Add materials in here if you wish to add
        /// any additional Columns.
        /// </summary>
        /// <param name="displayMaterialRow">The row you wish to add the material data to.</param>
        /// <returns>A list of CBMMaterials</returns>
        private static List<CBMMaterial> GetMaterialList(CbmDisplayMaterial displayMaterialRow)
        {
            List<CBMMaterial> materialList = new List<CBMMaterial>();

            AddMaterial(
                displayMaterialRow.HM_DESC_TEXT,
                displayMaterialRow.HM_ACTUAL,
                displayMaterialRow.HM_PREPARED,
                displayMaterialRow.HM_CONSTRAINED,
                displayMaterialRow.HM_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.SCRAP_DESC_TEXT,
                displayMaterialRow.SCRAP_ACTUAL,
                displayMaterialRow.SCRAP_PREPARED,
                displayMaterialRow.SCRAP_CONSTRAINED,
                displayMaterialRow.SCRAP_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.OXYGEN_DESC_TEXT,
                displayMaterialRow.OXYGEN_ACTUAL,
                displayMaterialRow.OXYGEN_PREPARED,
                displayMaterialRow.OXYGEN_CONSTRAINED,
                displayMaterialRow.OXYGEN_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.CHB_MAT_1_DESC_TEXT,
                displayMaterialRow.CHB_MAT_1_ACTUAL,
                displayMaterialRow.CHB_MAT_1_PREPARED,
                displayMaterialRow.CHB_MAT_1_CONSTRAINED,
                displayMaterialRow.CHB_MAT_1_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.CHB_MAT_2_DESC_TEXT,
                displayMaterialRow.CHB_MAT_2_ACTUAL,
                displayMaterialRow.CHB_MAT_2_PREPARED,
                displayMaterialRow.CHB_MAT_2_CONSTRAINED,
                displayMaterialRow.CHB_MAT_2_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.CHB_MAT_3_DESC_TEXT,
                displayMaterialRow.CHB_MAT_3_ACTUAL,
                displayMaterialRow.CHB_MAT_3_PREPARED,
                displayMaterialRow.CHB_MAT_3_CONSTRAINED,
                displayMaterialRow.CHB_MAT_3_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.CHB_MAT_4_DESC_TEXT,
                displayMaterialRow.CHB_MAT_4_ACTUAL,
                displayMaterialRow.CHB_MAT_4_PREPARED,
                displayMaterialRow.CHB_MAT_4_CONSTRAINED,
                displayMaterialRow.CHB_MAT_4_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.CHB_MAT_5_DESC_TEXT,
                displayMaterialRow.CHB_MAT_5_ACTUAL,
                displayMaterialRow.CHB_MAT_5_PREPARED,
                displayMaterialRow.CHB_MAT_5_CONSTRAINED,
                displayMaterialRow.CHB_MAT_5_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.CHB_MAT_6_DESC_TEXT,
                displayMaterialRow.CHB_MAT_6_ACTUAL,
                displayMaterialRow.CHB_MAT_6_PREPARED,
                displayMaterialRow.CHB_MAT_6_CONSTRAINED,
                displayMaterialRow.CHB_MAT_6_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.TF_MAT_1_DESC_TEXT,
                displayMaterialRow.TF_MAT_1_ACTUAL,
                displayMaterialRow.TF_MAT_1_PREPARED,
                displayMaterialRow.TF_MAT_1_CONSTRAINED,
                displayMaterialRow.TF_MAT_1_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.TF_MAT_2_DESC_TEXT,
                displayMaterialRow.TF_MAT_2_ACTUAL,
                displayMaterialRow.TF_MAT_2_PREPARED,
                displayMaterialRow.TF_MAT_2_CONSTRAINED,
                displayMaterialRow.TF_MAT_2_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.MAN_MAT_1_DESC_TEXT,
                displayMaterialRow.MAN_MAT_1_ACTUAL,
                displayMaterialRow.MAN_MAT_1_PREPARED,
                displayMaterialRow.MAN_MAT_1_CONSTRAINED,
                displayMaterialRow.MAN_MAT_1_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.MAN_MAT_2_DESC_TEXT,
                displayMaterialRow.MAN_MAT_2_ACTUAL,
                displayMaterialRow.MAN_MAT_2_PREPARED,
                displayMaterialRow.MAN_MAT_2_CONSTRAINED,
                displayMaterialRow.MAN_MAT_2_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.MAN_MAT_3_DESC_TEXT,
                displayMaterialRow.MAN_MAT_3_ACTUAL,
                displayMaterialRow.MAN_MAT_3_PREPARED,
                displayMaterialRow.MAN_MAT_3_CONSTRAINED,
                displayMaterialRow.MAN_MAT_3_CALCULATED,
                materialList);

            AddMaterial(
                displayMaterialRow.MAN_MAT_4_DESC_TEXT,
                displayMaterialRow.MAN_MAT_4_ACTUAL,
                displayMaterialRow.MAN_MAT_4_PREPARED,
                displayMaterialRow.MAN_MAT_4_CONSTRAINED,
                displayMaterialRow.MAN_MAT_4_CALCULATED,
                materialList);

            //Add any new materials here that you wish to add to the table from the Materials

            return materialList;
        }

        /// <summary>
        /// Determines which value to add to the row depending 
        /// on what values are available. Then adds the material to the list.
        /// </summary>
        /// <param name="materialDesc">The description/name of the material (_DESC_TEXT).</param>
        /// <param name="valueActual">The actual of the material (_ACTUAL).</param>
        /// <param name="valuePrepared">The prepared of the material (_PREPARED).</param>
        /// <param name="valueConstrained">The constrained of the material (_CONSTRAINED).</param>
        /// <param name="valueCalculated">The calculated of the material (_CALCULATED).</param>
        /// <param name="materialList">The material list in that Material Row.</param>
        private static void AddMaterial(string materialDesc,
            float? valueActual, float? valuePrepared,
            float? valueConstrained, float? valueCalculated,
            List<CBMMaterial> materialList)
        {
            if (string.IsNullOrWhiteSpace(materialDesc))
            {//Just return without any addition, if no material exists.
                return;
            }

            CBMMaterial newMaterial = new CBMMaterial();
            newMaterial.Name = materialDesc;

            if (valueActual.HasValue)
            {
                newMaterial.Value = valueActual.Value;
                newMaterial.Type = CBMType.Actual;
            }
            else if (valuePrepared.HasValue)
            {
                newMaterial.Value = valuePrepared.Value;
                newMaterial.Type = CBMType.Prepared;
            }
            else if (valueConstrained.HasValue)
            {
                newMaterial.Value = valueConstrained.Value;
                newMaterial.Type = CBMType.Constrained;
            }
            else if (valueCalculated.HasValue)
            {
                newMaterial.Value = valueCalculated.Value;
                newMaterial.Type = CBMType.Calculated;
            }

            materialList.Add(newMaterial);
        }

        /// <summary>
        /// Determines which value to add to the row depending 
        /// on what values are available. Then adds the material to the list.
        /// </summary>
        /// <param name="valuePoured">The Poured Ladle of the material (HM_LADLE_).</param>
        /// <param name="valueCalculated">The calculated of the material (CALC_HM_).</param>
        /// <param name="materialList">The material list in that Material Row.</param>
        private static void AddMaterial(string materialDesc,
            float? valuePoured, float? valueCalculated,
            List<CBMMaterial> materialList)
        {
            CBMMaterial newMaterial = new CBMMaterial();
            newMaterial.Name = materialDesc;

            if (valuePoured.HasValue)
            {
                newMaterial.Value = valuePoured.Value;
                newMaterial.Type = CBMType.PouredHM;
            }
            else if (valueCalculated.HasValue)
            {
                newMaterial.Value = valueCalculated.Value;
                newMaterial.Type = CBMType.Calculated;
            }

            materialList.Add(newMaterial);
        }

        /// <summary>
        /// Gets and returns the string formatting for each material.
        /// Default is N1 e.g. 1.1, 0.1, 10.1
        /// </summary>
        /// <param name="materialName">The Name of the Material.</param>
        /// <returns>The string formatting.</returns>
        public static string FormatValueFromName(string materialName)
        {
            switch (materialName.ToUpper())
            {
                case "HM TEMP":
                case "OXYGEN":
                    return "N0";
                case "HM SI":
                case "SLAG MGO":
                case "SLAG VR":
                    return "N2";
                case "HM S":
                    return "N3";
                case "HM":
                case "SCRAP":
                case "TF-WOBS":
                case "DOLOMET":
                case "LIME":
                case "WOBS":
                default:
                    return "N1";
            }
        }

        /// <summary>
        /// Gets and returns the decimal places as an int for each material.
        /// Default is 1.
        /// </summary>
        /// <param name="materialName">The Name of the Material.</param>
        /// <returns>The decimal places in int.</returns>
        public static int GetDPForMaterial(string materialName)
        {
            switch (materialName.ToUpper())
            {
                case "HM TEMP":
                case "OXYGEN":
                    return 0;
                case "HM SI":
                case "SLAG MGO":
                case "SLAG VR":
                    return 2;
                case "HM S":
                    return 3;
                case "HM":
                case "SCRAP":
                case "TF-WOBS":
                case "DOLOMET":
                case "LIME":
                case "WOBS":
                default:
                    return 1;
            }
        }

        /// <summary>
        /// Gets the CBM Type from the value.
        /// </summary>
        /// <param name="value">The value of the CBM object as a string.</param>
        /// <returns>The CBMType. Default is Calculated.</returns>
        public static CBMType GetCBMTypeFromValue(string value)
        {
            if (value.Contains("C"))
            {
                return CBMType.Constrained;
            }
            else if (value.Contains("P"))
            {
                return CBMType.Prepared;//Same as Poured HM
            }
            else if (value.Contains("A"))
            {
                return CBMType.Actual;
            }
            else if (value.Contains("D"))
            {
                return CBMType.DesulphHM;
            }
            return CBMType.Calculated;
        }
        #endregion

        #region CBM Analysis 1
        /// <summary>
        /// Generates the records used for the Analysis Data Grid 1
        /// on the ChargeBalanceControl User Control.
        /// </summary>
        /// <param name="displayAnalysis">The display analysis to generate.</param>
        /// <returns>A list of records to populate the Analysis 1 Data Gridview.</returns>
        public static List<CBMAnalysis1Row> GetAnalysis1TableData(CbmDisplayAnalysis displayAnalysis)
        {
            List<CBMAnalysis1Row> analysis1Data = new List<CBMAnalysis1Row>();

            if (displayAnalysis != null)
            {
                AddAnalysis1("HM Calc",
                    displayAnalysis.CALC_HM_TEMPERATURE,
                    displayAnalysis.CALC_HM_CARBON,
                    displayAnalysis.CALC_HM_SILICON,
                    displayAnalysis.CALC_HM_MANGANESE,
                    displayAnalysis.CALC_HM_PHOSPHORUS,
                    displayAnalysis.CALC_HM_SULPHUR,
                    displayAnalysis.CALC_HM_NITROGEN,
                    displayAnalysis.CALC_HM_WEIGHT,
                    displayAnalysis.CALC_HM_DIP_TIME,
                    analysis1Data);

                AddAnalysis1("HM Ladle",
                     displayAnalysis.HM_LADLE_TEMPERATURE,
                     displayAnalysis.HM_LADLE_CARBON,
                     displayAnalysis.HM_LADLE_SILICON,
                     displayAnalysis.HM_LADLE_MANGANESE,
                     displayAnalysis.HM_LADLE_PHOSPHORUS,
                     displayAnalysis.HM_LADLE_SULPHUR,
                     displayAnalysis.HM_LADLE_NITROGEN,
                     displayAnalysis.HM_LADLE_WEIGHT,
                     displayAnalysis.HM_LADLE_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("Desulph",
                     displayAnalysis.DESULPH_TEMPERATURE,
                     displayAnalysis.DESULPH_CARBON,
                     displayAnalysis.DESULPH_SILICON,
                     displayAnalysis.DESULPH_MANGANESE,
                     displayAnalysis.DESULPH_PHOSPHORUS,
                     displayAnalysis.DESULPH_SULPHUR,
                     displayAnalysis.DESULPH_NITROGEN,
                     displayAnalysis.DESULPH_WEIGHT,
                     displayAnalysis.DESULPH_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("Recycle",
                     displayAnalysis.RECYCLE_TEMPERATURE,
                     displayAnalysis.RECYCLE_CARBON,
                     displayAnalysis.RECYCLE_SILICON,
                     displayAnalysis.RECYCLE_MANGANESE,
                     displayAnalysis.RECYCLE_PHOSPHORUS,
                     displayAnalysis.RECYCLE_SULPHUR,
                     displayAnalysis.RECYCLE_NITROGEN,
                     displayAnalysis.RECYCLE_WEIGHT,
                     displayAnalysis.RECYCLE_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("IB Aim",
                     displayAnalysis.INBLOW_AIM_TEMPERATURE,
                     displayAnalysis.INBLOW_AIM_CARBON,
                     displayAnalysis.INBLOW_AIM_SILICON,
                     displayAnalysis.INBLOW_AIM_MANGANESE,
                     displayAnalysis.INBLOW_AIM_PHOSPHORUS,
                     displayAnalysis.INBLOW_AIM_SULPHUR,
                     displayAnalysis.INBLOW_AIM_NITROGEN,
                     displayAnalysis.INBLOW_AIM_WEIGHT,
                     displayAnalysis.INBLOW_AIM_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("IB Act",
                     displayAnalysis.INBLOW_ACTUAL_TEMPERATURE,
                     displayAnalysis.INBLOW_ACTUAL_CARBON,
                     displayAnalysis.INBLOW_ACTUAL_SILICON,
                     displayAnalysis.INBLOW_ACTUAL_MANGANESE,
                     displayAnalysis.INBLOW_ACTUAL_PHOSPHORUS,
                     displayAnalysis.INBLOW_ACTUAL_SULPHUR,
                     displayAnalysis.INBLOW_ACTUAL_NITROGEN,
                     displayAnalysis.INBLOW_ACTUAL_WEIGHT,
                     displayAnalysis.INBLOW_ACTUAL_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("EB Aim",
                     displayAnalysis.ENDBLOW_AIM_TEMPERATURE,
                     displayAnalysis.ENDBLOW_AIM_CARBON,
                     displayAnalysis.ENDBLOW_AIM_SILICON,
                     displayAnalysis.ENDBLOW_AIM_MANGANESE,
                     displayAnalysis.ENDBLOW_AIM_PHOSPHORUS,
                     displayAnalysis.ENDBLOW_AIM_SULPHUR,
                     displayAnalysis.ENDBLOW_AIM_NITROGEN,
                     displayAnalysis.ENDBLOW_AIM_WEIGHT,
                     displayAnalysis.ENDBLOW_AIM_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("EB Act",
                     displayAnalysis.ENDBLOW_ACTUAL_TEMPERATURE,
                     displayAnalysis.ENDBLOW_ACTUAL_CARBON,
                     displayAnalysis.ENDBLOW_ACTUAL_SILICON,
                     displayAnalysis.ENDBLOW_ACTUAL_MANGANESE,
                     displayAnalysis.ENDBLOW_ACTUAL_PHOSPHORUS,
                     displayAnalysis.ENDBLOW_ACTUAL_SULPHUR,
                     displayAnalysis.ENDBLOW_ACTUAL_NITROGEN,
                     displayAnalysis.ENDBLOW_ACTUAL_WEIGHT,
                     displayAnalysis.ENDBLOW_ACTUAL_DIP_TIME,
                     analysis1Data);

                AddAnalysis1("Steel Calc",
                     displayAnalysis.STEEL_CALC_TEMPERATURE,
                     displayAnalysis.STEEL_CALC_CARBON,
                     displayAnalysis.STEEL_CALC_SILICON,
                     displayAnalysis.STEEL_CALC_MANGANESE,
                     displayAnalysis.STEEL_CALC_PHOSPHORUS,
                     displayAnalysis.STEEL_CALC_SULPHUR,
                     displayAnalysis.STEEL_CALC_NITROGEN,
                     displayAnalysis.STEEL_CALC_WEIGHT,
                     displayAnalysis.STEEL_CALC_DIP_TIME,
                     analysis1Data);
            }

            return analysis1Data;
        }

        /// <summary>
        /// Add an analysis record to the Analysis List.
        /// </summary>
        /// <param name="name">The Name of the item.</param>
        /// <param name="temperature">The Temperature value.</param>
        /// <param name="carbon">The Carbon value.</param>
        /// <param name="silicon">The Silicon value.</param>
        /// <param name="manganese">The Manganese value.</param>
        /// <param name="phosphorus">The Phosphorus value.</param>
        /// <param name="sulphur">The Sulphur value.</param>
        /// <param name="nitrogen">The Nitrogen value.</param>
        /// <param name="weight">The Weight value.</param>
        /// <param name="dipTime">The Dip Time value.</param>
        /// <param name="analysis1Data">The List to add the record to.</param>
        private static void AddAnalysis1(string name, float? temperature,
            float? carbon, float? silicon, float? manganese, float? phosphorus,
            float? sulphur, float? nitrogen, float? weight, DateTime? dipTime,
            List<CBMAnalysis1Row> analysis1Data)
        {
            analysis1Data.Add(new CBMAnalysis1Row()
            {
                Name = name,
                Temperature = temperature,
                Carbon = carbon,
                Silicon = silicon,
                Manganese = manganese,
                Phosphorus = phosphorus,
                Sulphur = sulphur,
                Nitrogen = nitrogen,
                Weight = weight,
                DipTime = dipTime
            });
        }
        #endregion

        #region CBM Analysis 2
        /// <summary>
        /// Generates the records used for the Analysis Data Grid 2
        /// on the ChargeBalanceControl User Control.
        /// </summary>
        /// <param name="displayAnalysis">The display analysis to generate.</param>
        /// <returns>A list of records to populate the Analysis 2 Data Gridview.</returns>
        public static List<CBMAnalysis2Row> GetAnalysis2TableData(CbmDisplayAnalysis displayAnalysis)
        {
            List<CBMAnalysis2Row> analysis2Data = new List<CBMAnalysis2Row>();

            if (displayAnalysis != null)
            {
                analysis2Data.Add(new CBMAnalysis2Row()
                {
                    Name = "Slag Calc",
                    Iron = displayAnalysis.SLAG_CALC_FE,
                    CalciumOxide = displayAnalysis.SLAG_CALC_CAO,
                    Silica = displayAnalysis.SLAG_CALC_SIO2,
                    MagnesiumOxide = displayAnalysis.SLAG_CALC_MGO,
                    VR = displayAnalysis.SLAG_CALC_VR,
                    PhosphorusPentoxide = displayAnalysis.SLAG_CALC_P2O5,
                    ManganeseOxide = displayAnalysis.SLAG_CALC_MNO,
                    Weight = displayAnalysis.SLAG_CALC_WEIGHT
                });

                analysis2Data.Add(new CBMAnalysis2Row()
                {
                    Name = "Slag Act",
                    Iron = displayAnalysis.SLAG_ACTUAL_FE,
                    CalciumOxide = displayAnalysis.SLAG_ACTUAL_CAO,
                    Silica = displayAnalysis.SLAG_ACTUAL_SIO2,
                    MagnesiumOxide = displayAnalysis.SLAG_ACTUAL_MGO,
                    VR = displayAnalysis.SLAG_ACTUAL_VR,
                    PhosphorusPentoxide = displayAnalysis.SLAG_ACTUAL_P2O5,
                    ManganeseOxide = displayAnalysis.SLAG_ACTUAL_MNO,
                    Weight = displayAnalysis.SLAG_ACTUAL_WEIGHT
                });
            }

            return analysis2Data;
        }
        #endregion

        #region CBM Analysis 3
        /// <summary>
        /// Generates the records used for the Analysis Data Grid 3
        /// on the ChargeBalanceControl User Control.
        /// </summary>
        /// <param name="displayMaterial">The display material to generate.</param>
        /// <returns>A list of records to populate the Analysis 3 Data Gridview.</returns>
        public static List<CBMAnalysis3Row> GetAnalysis3TableData(CbmDisplayMaterial displayMaterial)
        {
            List<CBMAnalysis3Row> analysis3Data = new List<CBMAnalysis3Row>();

            if (displayMaterial != null)
            {
                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.OXYGEN_DESC_TEXT,
                    Calculated = displayMaterial.OXYGEN_CALCULATED,
                    Constraint = displayMaterial.OXYGEN_CONSTRAINED,
                    Prepared = displayMaterial.OXYGEN_PREPARED,
                    Actual = displayMaterial.OXYGEN_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.HM_DESC_TEXT,
                    Calculated = displayMaterial.HM_CALCULATED,
                    Constraint = displayMaterial.HM_CONSTRAINED,
                    Prepared = displayMaterial.HM_PREPARED,
                    Actual = displayMaterial.HM_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.SCRAP_DESC_TEXT,
                    Calculated = displayMaterial.SCRAP_CALCULATED,
                    Constraint = displayMaterial.SCRAP_CONSTRAINED,
                    Prepared = displayMaterial.SCRAP_PREPARED,
                    Actual = displayMaterial.SCRAP_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.HM_RATIO_DESC_TEXT,
                    Calculated = displayMaterial.HM_RATIO_CALCULATED,
                    Constraint = displayMaterial.HM_RATIO_CONSTRAINED,
                    Prepared = displayMaterial.HM_RATIO_PREPARED,
                    Actual = displayMaterial.HM_RATIO_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.RECYCLE_DESC_TEXT,
                    Calculated = displayMaterial.RECYCLE_CALCULATED,
                    Constraint = displayMaterial.RECYCLE_CONSTRAINED,
                    Prepared = displayMaterial.RECYCLE_PREPARED,
                    Actual = displayMaterial.RECYCLE_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.CHB_MAT_1_DESC_TEXT,
                    Calculated = displayMaterial.CHB_MAT_1_CALCULATED,
                    Constraint = displayMaterial.CHB_MAT_1_CONSTRAINED,
                    Prepared = displayMaterial.CHB_MAT_1_PREPARED,
                    Actual = displayMaterial.CHB_MAT_1_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.CHB_MAT_2_DESC_TEXT,
                    Calculated = displayMaterial.CHB_MAT_2_CALCULATED,
                    Constraint = displayMaterial.CHB_MAT_2_CONSTRAINED,
                    Prepared = displayMaterial.CHB_MAT_2_PREPARED,
                    Actual = displayMaterial.CHB_MAT_2_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.CHB_MAT_3_DESC_TEXT,
                    Calculated = displayMaterial.CHB_MAT_3_CALCULATED,
                    Constraint = displayMaterial.CHB_MAT_3_CONSTRAINED,
                    Prepared = displayMaterial.CHB_MAT_3_PREPARED,
                    Actual = displayMaterial.CHB_MAT_3_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.CHB_MAT_4_DESC_TEXT,
                    Calculated = displayMaterial.CHB_MAT_4_CALCULATED,
                    Constraint = displayMaterial.CHB_MAT_4_CONSTRAINED,
                    Prepared = displayMaterial.CHB_MAT_4_PREPARED,
                    Actual = displayMaterial.CHB_MAT_4_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.CHB_MAT_5_DESC_TEXT,
                    Calculated = displayMaterial.CHB_MAT_5_CALCULATED,
                    Constraint = displayMaterial.CHB_MAT_5_CONSTRAINED,
                    Prepared = displayMaterial.CHB_MAT_5_PREPARED,
                    Actual = displayMaterial.CHB_MAT_5_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.CHB_MAT_6_DESC_TEXT,
                    Calculated = displayMaterial.CHB_MAT_6_CALCULATED,
                    Constraint = displayMaterial.CHB_MAT_6_CONSTRAINED,
                    Prepared = displayMaterial.CHB_MAT_6_PREPARED,
                    Actual = displayMaterial.CHB_MAT_6_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.TF_MAT_1_DESC_TEXT,
                    Calculated = displayMaterial.TF_MAT_1_CALCULATED,
                    Constraint = displayMaterial.TF_MAT_1_CONSTRAINED,
                    Prepared = displayMaterial.TF_MAT_1_PREPARED,
                    Actual = displayMaterial.TF_MAT_1_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.TF_MAT_2_DESC_TEXT,
                    Calculated = displayMaterial.TF_MAT_2_CALCULATED,
                    Constraint = displayMaterial.TF_MAT_2_CONSTRAINED,
                    Prepared = displayMaterial.TF_MAT_2_PREPARED,
                    Actual = displayMaterial.TF_MAT_2_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.MAN_MAT_1_DESC_TEXT,
                    Calculated = displayMaterial.MAN_MAT_1_CALCULATED,
                    Constraint = displayMaterial.MAN_MAT_1_CONSTRAINED,
                    Prepared = displayMaterial.MAN_MAT_1_PREPARED,
                    Actual = displayMaterial.MAN_MAT_1_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.MAN_MAT_2_DESC_TEXT,
                    Calculated = displayMaterial.MAN_MAT_2_CALCULATED,
                    Constraint = displayMaterial.MAN_MAT_2_CONSTRAINED,
                    Prepared = displayMaterial.MAN_MAT_2_PREPARED,
                    Actual = displayMaterial.MAN_MAT_2_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.MAN_MAT_3_DESC_TEXT,
                    Calculated = displayMaterial.MAN_MAT_3_CALCULATED,
                    Constraint = displayMaterial.MAN_MAT_3_CONSTRAINED,
                    Prepared = displayMaterial.MAN_MAT_3_PREPARED,
                    Actual = displayMaterial.MAN_MAT_3_ACTUAL
                });

                analysis3Data.Add(new CBMAnalysis3Row()
                {
                    Name = displayMaterial.MAN_MAT_4_DESC_TEXT,
                    Calculated = displayMaterial.MAN_MAT_4_CALCULATED,
                    Constraint = displayMaterial.MAN_MAT_4_CONSTRAINED,
                    Prepared = displayMaterial.MAN_MAT_4_PREPARED,
                    Actual = displayMaterial.MAN_MAT_4_ACTUAL
                });
            }

            return analysis3Data;
        }
        #endregion
    }

    #region Supporting Classes
    public class CBMOverviewRow
    {
        public DateTime Time { get; set; }
        public int VesselNo { get; set; }
        public List<CBMMaterial> MaterialList { get; set; }
        public double SlagMgO { get; set; }
        public double SlagVR { get; set; }
        public int RunNumber { get; set; }
    }

    public class CBMAnalysis1Row
    {
        public string Name { get; set; }
        public double? Temperature { get; set; }
        public double? Carbon { get; set; }
        public double? Silicon { get; set; }
        public double? Manganese { get; set; }
        public double? Phosphorus { get; set; }
        public double? Sulphur { get; set; }
        public double? Nitrogen { get; set; }
        public double? Weight { get; set; }
        public DateTime? DipTime { get; set; }
    }

    public class CBMAnalysis2Row
    {
        public string Name { get; set; }
        public double? Iron { get; set; }
        public double? CalciumOxide { get; set; }
        public double? Silica { get; set; }
        public double? MagnesiumOxide { get; set; }
        public double? VR { get; set; }
        public double? PhosphorusPentoxide { get; set; }
        public double? ManganeseOxide { get; set; }
        public double? Weight { get; set; }
    }

    public class CBMAnalysis3Row
    {
        public string Name { get; set; }
        public double? Calculated { get; set; }
        public double? Constraint { get; set; }
        public double? Prepared { get; set; }
        public double? Actual { get; set; }
        public string Comment { get; set; }
    }

    public class CBMMaterial
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public CBMType Type { get; set; }
    }

    public enum CBMType
    {
        Calculated,
        Constrained,
        Prepared,
        PouredHM,
        Actual,
        DesulphHM,
        None
    }
    #endregion
}
