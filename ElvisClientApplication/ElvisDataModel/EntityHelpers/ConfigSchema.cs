using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region AimUnits Table Functions
        public static class AimUnits
        {
            /// <summary>
            /// Gets the Aim Units ordered by UnitNumber
            /// </summary>
            /// <returns>List of AimUnits</returns>
            public static List<AimUnit> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.AimUnits
                        .OrderBy(u => u.UnitNumber)
                        .ToList();
                }
            }
        }
        #endregion

        #region CasterTag Table Functions
        public static class CasterTag
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="casterNo">The Castet Number to filter by.</param>
            /// <returns>List of Tags and Ranges.</returns>
            public static List<ElvisDataModel.EDMX.CasterTag> GetByCaster(int casterNo)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CasterTags
                        .Where(c => c.Caster == casterNo)
                        .ToList();
                }
            }
        }
        #endregion

        #region ChartsConfiguration Table Functions
        public static class ChartsConfiguration
        {
            public enum ChartsType
            {
                CasterTrend = 1,
                EndBlowingModel

            }

            /// <summary>
            /// Get Chart Data by chartType.
            /// </summary>
            /// <param name="chartType">Chart type to get.</param>
            /// <returns>Chart configuration.</returns>
            public static ElvisDataModel.EDMX.ChartsConfiguration GetByChartType(ChartsType chartType)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx
                        .ChartsConfigurations
                        .FirstOrDefault(r =>
                            r.ID == (int)chartType);
                }
            }
        }
        #endregion

        #region ChartsArea Table Functions
        public static class ChartsAreas
        {
            /// <summary>
            /// Get a list of ChartAreas by ChartType.
            /// </summary>
            /// <param name="chartType">Chart type to get area for.</param>
            /// <returns>List of chart area configurations.</returns>
            public static List<ElvisDataModel.EDMX.ChartArea> GetByChartType(ElvisDataModel.EntityHelper.ChartsConfiguration.ChartsType chartType)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx
                        .ChartAreas
                        .Where(r =>
                            r.ChartID == (int)chartType)
                        .ToList();
                }
            }
        }
        #endregion

        #region ChartsAxis Table Functions
        public static class ChartsAxis
        {
            public enum chartAxisType
            {
                X = 1,
                Y
            }
            /// <summary>
            /// Get Chart axis configuration by ChartAreaID.
            /// </summary>
            /// <param name="chartAreaID">To identify which areas to get.</param>
            /// <returns>List of chart axis configurations.</returns>
            public static List<ElvisDataModel.EDMX.ChartAxi> GetByChartAreaID(int chartAreaID)
            {

                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx
                        .ChartAxis
                        .Where(r =>
                            r.ChartAreasID == chartAreaID)
                        .ToList();
                }
            }
        }
        #endregion

        #region ChartDataLocations Table Functions
        public static class ChartDataLocations
        {
            /// <summary>
            /// Get Chart Data by ChartDataLocationsID.
            /// </summary>
            /// <param name="chartDataLocationsID">Identifier for record.</param>
            /// <returns>List of chart data location configuration, scales and Ranges or null if not found.</returns>
            public static ElvisDataModel.EDMX.ChartDataLocation GetByChartDataLocationsID(int chartDataLocationsID)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx
                        .ChartDataLocations
                        .FirstOrDefault(r => r.Id == chartDataLocationsID);
                }
            }

            /// <summary>
            /// Get Chart Data by ChartDataLocationsID.
            /// </summary>
            /// <param name="chartTypes">List of chart types.</param>
            /// <returns>List of Tags, scales and Ranges or null if not found.</returns>
            public static ElvisDataModel.EDMX.ChartDataLocation GetByReferenceID(string referenceID)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx
                        .ChartDataLocations
                        .FirstOrDefault(r => r.ReferenceId == referenceID);
                }
            }
        }
        #endregion

        #region ChartSeriesSet Table Functions
        public static class ChartSeriesSet
        {

            public enum ChartSeriesSetTypes
            {
                EBMDataVessel1 = 1,
                EBMDataVessel2,
                Caster1Trend,
                Caster2Trend,
                Caster3Trend
            }

            /// <summary>
            /// Get series set name by id.
            /// </summary>
            /// <param name="seriesSet">Series set identifier for filtering ChartSeriesSets.</param>
            /// <returns>Name of series set.</returns>
            public static string GetByChartID(ChartSeriesSetTypes seriesSet)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.ChartSeriesSet chartSeriesSet
                        = ctx
                        .ChartSeriesSets
                        .FirstOrDefault(r => r.Id == (int)seriesSet);

                    return chartSeriesSet != null ? chartSeriesSet.Name : String.Empty;
                }
            }
        }

        #endregion

        #region ChartSeries Table Functions
        public static class ChartSery
        {
            public enum RetrievalDataMethod
            {
                GetInterpolatedPIData5Sec = 1,
                GetCasterDataPoints,
            }


            /// <summary>
            /// Get list of Chart Series configuration data by a list of ChartSeriesSetTypes.
            /// </summary>
            /// <param name="chartTypes">List of chart series sets.</param>
            /// <returns>List of series configurations.</returns>
            public static List<ElvisDataModel.EDMX.ChartSery> GetByChartID(List<ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> chartTypes)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    // Convert to list of ints.
                    List<int> chartTypesAsInt = new List<int>(chartTypes.Select(r => (int)r).ToList());
                    return ctx
                        .ChartSeries
                        .Where(r => chartTypesAsInt.Contains(r.ChartSeriesSetID))
                        .ToList();
                }
            }
        }
        #endregion

        #region HmdsmTreatmentTypes Table Functions
        public static class HmdsmTreatmentTypes
        {
            /// <summary>
            /// Gets the HMDSM Treatment type description based on the treatment type id.
            /// </summary>
            /// <param name="hmdsmTreatmentTypeID">The id of the treatment type to get the description for.</param>
            /// <returns>Description of the type or null if id is not found.</returns>
            public static string GetDescriptionById(int hmdsmTreatmentTypeID)
            {
                string desc = String.Empty;
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    HmdsmTreatmentType record
                        = ctx
                        .HmdsmTreatmentTypes
                        .Where(r => r.HmdsmTreatmentTypeID == hmdsmTreatmentTypeID)
                        .FirstOrDefault();
                    if (record != null)
                    {
                        desc = record.Description;
                    }
                }

                return desc;
            }
        }
        #endregion

        #region Logs Table Functions
        public static class Logs
        {
            /// <summary>
            /// Gets a list of usernames that have connected to Elvis previously.
            /// </summary>
            /// <returns>An array of username strings.</returns>
            public static string[] GetPreviousLoginNames()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Logs.Select(l => l.UserName).Distinct().ToArray<string>();
                }
            }

            /// <summary>
            /// Gets the config logs for an x amount of months ago.
            /// Excludes all 'Info' LogLevels.
            /// Ignores following errors:
            ///    -- Save Failure --
            ///    -- Load Failure --.
            /// </summary>
            /// <param name="monthsOfData">How many months to go back as an int.</param>
            /// <returns></returns>
            public static List<Log> GetByDate(int monthsOfData)
            {
                DateTime dateFrom = DateTime.Now.AddMonths(-monthsOfData);
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.LiveConnectionString))
                {
                    return ctx.Logs
                        .Where(l =>
                            l.TimeStamp >= dateFrom && 
                            !l.LogLevel.Contains("Info") &&
                            !l.Message.Contains("-- Save Failure --") &&
                            !l.Message.Contains("-- Load Failure --"))
                        .OrderByDescending(l => l.TimeStamp)
                        .ToList();
                }
            }
        }
        #endregion

        #region OpPractice Table Functions
        public static class OpPractice
        {
            /// <summary>
            /// Gets all the OpPractices from the database.
            /// </summary>
            /// <returns>A List of OpPractice objects.</returns>
            public static List<EDMX.OpPractice> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.OpPractices.ToList();
                }
            }
        }
        #endregion

        #region Scrap Box Types Table Functions
        public static class ScrapBoxTypes
        {
            /// <summary>
            /// Gets all the Scrap Box Types from the database.
            /// </summary>
            /// <returns>A List of ScrapEventType objects.</returns>
            public static List<ScrapBoxType> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ScrapBoxTypes.ToList();
                }
            }
        }
        #endregion

        #region Scrap Events Table Functions
        public static class ScrapEventTypes
        {
            /// <summary>
            /// Gets all the Scrap Event Types from the database.
            /// </summary>
            /// <returns>A List of ScrapEventType objects.</returns>
            public static List<ScrapEventType> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ScrapEventTypes.ToList();
                }
            }
        }
        #endregion

        #region Scrap Types
        public static class ScrapTypes
        {
            /// <summary>
            /// Gets all the Scrap Types from the database.
            /// </summary>
            /// <returns>A List of ScrapType objects.</returns>
            public static List<ElvisDataModel.EDMX.ScrapType> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ScrapTypes.ToList();
                }
            }
        }
        #endregion

        #region TibCategoryLookUp Table Functions
        public static class TibCategoryLookUp
        {
            /// <summary>
            /// Gets the full list of Categories from TibCategoryLookUp Table.
            /// </summary>
            /// <returns>List of TibCategoryLookUp objects.</returns>
            public static List<ElvisDataModel.EDMX.TibCategoryLookUp> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibCategoryLookUps.ToList();
                }
            }

            /// <summary>
            /// Get only TIBCategoryText
            /// </summary>
            /// <returns>List of TIBCategoryText.</returns>
            public static List<string> GetByCategoryText()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibCategoryLookUps
                        .OrderBy(o => o.TIBCategoryIndex)
                        .Select(p => p.TIBCategoryText)
                        .ToList();
                }
            }
        }
        #endregion

        #region TibClassLookUp Table Functions
        public static class TibClassLookUp
        {
            /// <summary>
            /// Gets the full list of Classes from TibClassLookUp Table.
            /// </summary>
            /// <returns>List of TibClassLookUp objects.</returns>
            public static List<ElvisDataModel.EDMX.TibClassLookUp> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibClassLookUps.ToList();
                }
            }

            /// <summary>
            /// Gets the full list of Classes from TibClassLookUp Table.
            /// </summary>
            /// <returns>List of TibClassLookUp objects.</returns>
            public static List<ElvisDataModel.EDMX.TibClassLookUp> GetByIndex(int tibClassNo)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibClassLookUps.ToList();
                }
            }

            /// <summary>
            /// Get only TIBClassText
            /// </summary>
            /// <returns>List of TIBClassText.</returns>
            public static List<string> GetBydelayClassText()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibClassLookUps
                        .OrderBy(o => o.TIBClassIndex)
                        .Select(p => p.TIBClassText)
                        .ToList();
                }
            }

        }
        #endregion

        #region TibDisciplineLookUp Table Functions
        public static class TibDisciplineLookUp
        {
            /// <summary>
            /// Gets the full list of Disciplines from TibDisciplineLookUp Table.
            /// </summary>
            /// <returns>List of TibDisciplineLookUp objects.</returns>
            public static List<ElvisDataModel.EDMX.TibDisciplineLookUp> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibDisciplineLookUps.ToList();
                }
            }

            /// <summary>
            /// Get only TIBDisText
            /// </summary>
            /// <returns>List of TIBDisText.</returns>
            public static List<string> GetByDisciplineText()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibDisciplineLookUps
                        .OrderBy(o => o.TIBDisIndex)
                        .Select(p => p.TIBDisText)
                        .ToList();
                }
            }
        }
        #endregion

        #region TIBStates Table Functions
        public static class TIBStates
        {
            /// <summary>
            /// Gets the Tib Status Description by Status ID
            /// </summary>
            /// <param name="statusID">The Status ID of the record.</param>
            /// <returns>The Status Description as a string.</returns>
            public static string GetDescription(int? statusID)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (statusID.HasValue)
                    {
                        string statusNoSpace = ctx.TIBStates.FirstOrDefault(u =>
                                u.TIBStatus == statusID).TIBStatusDescription;
                        //Adds spaces to status' with no spaces.
                        switch (statusNoSpace)
                        {
                            case "NotProducing":
                                return "Not Producing";
                            case "InProcessDelay":
                                return "In Process Delay";
                            case "OutProcessDelay":
                                return "Out Process Delay";
                            default:
                                return statusNoSpace;
                        }
                    }
                }
                return "Unavailable";
            }
        }
        #endregion

        #region TIBReasons Table Functions
        public static class TIBReasons
        {
            /// <summary>
            /// Gets the column data using a filter.
            /// </summary>
            /// <param name="filter">The filter as a tring.</param>
            /// <returns>A list of TIBReasons.</returns>
            public static List<ElvisDataModel.EDMX.TIBReason> GetColumnData(string filter)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBReasons.Where(filter + " is not null").ToList();
                }
            }

            /// <summary>
            /// Get record with selected index number
            /// </summary>
            /// <returns>TIBReason object.</returns>
            public static EDMX.TIBReason GetByIndex(int reasonIndex)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBReasons
                        .FirstOrDefault(t => t.ReasonIndex == reasonIndex);
                }
            }

            /// <summary>
            /// Adds a new TIB Reason to the database.
            /// </summary>
            /// <param name="reasonToAdd">The report object you wish to add.</param>
            public static void AddNew(ElvisDataModel.EDMX.TIBReason reasonToAdd)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.TIBReasons.AddObject(reasonToAdd);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Updates a specific TIBReason record in the
            /// database.
            /// </summary>
            /// <param name="updateData">The TIBReason object to update.</param>
            public static void Update(ElvisDataModel.EDMX.TIBReason updateData)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    TIBReason reasonToUpdate = ctx.TIBReasons.FirstOrDefault(
                        r => r.ReasonIndex == updateData.ReasonIndex);

                    if (reasonToUpdate != null)
                    {
                        reasonToUpdate.DelayIndex = updateData.DelayIndex;
                        reasonToUpdate.UnitGroup = updateData.UnitGroup;
                        reasonToUpdate.PlantArea = updateData.PlantArea;
                        reasonToUpdate.DelayReason1 = updateData.DelayReason1;
                        reasonToUpdate.DelayReason2 = updateData.DelayReason2;
                        reasonToUpdate.DelayReason3 = updateData.DelayReason3;
                        reasonToUpdate.DelayReason4 = updateData.DelayReason4;
                        reasonToUpdate.DelayClass = updateData.DelayClass;
                        reasonToUpdate.Category = updateData.Category;
                        reasonToUpdate.Discipline = updateData.Discipline;
                        reasonToUpdate.OEECategory = updateData.OEECategory;
                        reasonToUpdate.LossType = updateData.LossType;
                        reasonToUpdate.Owner = updateData.Owner;
                        reasonToUpdate.ReportingTextLevel1 = updateData.ReportingTextLevel1;
                        reasonToUpdate.ReportingTextLevel2 = updateData.ReportingTextLevel2;
                        reasonToUpdate.ObjectDescription = updateData.ObjectDescription;
                        reasonToUpdate.ObjectCode = updateData.ObjectCode;
                        reasonToUpdate.DamageDescription = updateData.DamageDescription;
                        reasonToUpdate.DamageCode = updateData.DamageCode;
                        reasonToUpdate.DeviationType = updateData.DeviationType;
                        reasonToUpdate.CauseText = updateData.CauseText;
                        reasonToUpdate.Section = updateData.Section;
                        reasonToUpdate.ExternalInternal = updateData.ExternalInternal;
                        reasonToUpdate.SupplierDownStream = updateData.SupplierDownStream;
                        reasonToUpdate.NoExtraWork = updateData.NoExtraWork;
                        reasonToUpdate.FlocDescriptionL3 = updateData.FlocDescriptionL3;
                        reasonToUpdate.FlocNumberL3 = updateData.FlocNumberL3;
                        reasonToUpdate.FlocDescriptionL4 = updateData.FlocDescriptionL4;
                        reasonToUpdate.FlocNumberL4 = updateData.FlocNumberL4;
                        reasonToUpdate.FlocDescriptionL5 = updateData.FlocDescriptionL5;
                        reasonToUpdate.FlocNumberL5 = updateData.FlocNumberL5;
                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Deletes a Specific TIBReason from the database.
            /// </summary>
            /// <param name="reasonIndex">The Reason Index to delete.</param>
            public static void Delete(int reasonIndex)
            {
                TIBReason reasonToDelete = new TIBReason();
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    reasonToDelete = ctx.TIBReasons.FirstOrDefault(r => r.ReasonIndex == reasonIndex);
                    if (reasonToDelete != null)
                    {
                        ctx.TIBReasons.DeleteObject(reasonToDelete);
                        ctx.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region Treatment Table Functions
        public static class Treatment
        {
            /// <summary>
            /// Gets the Treatment Table
            /// </summary>
            /// <returns>A list of the treatment records.</returns>
            public static List<ElvisDataModel.EDMX.Treatment> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(
                    EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Treatments.ToList();
                }
            }

        }
        #endregion

        #region Units Table Functions
        public static class Units
        {
            /// <summary>
            /// Gets all plant units below a unit number of 99.
            /// </summary>
            /// <returns>List of Unit Database Objects.</returns>
            public static List<Unit> GetAll()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Units
                        .Where(u => u.UnitNumber < 99)
                        .OrderBy(o => o.UnitGroupSort)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a Unit's text with specific Unit Number
            /// </summary>
            /// <param name="unitNo">The Unit Number</param>
            /// <returns>Empty string if not found</returns>
            public static string GetText(int unitNo)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    string unitText = String.Empty;

                    Unit unit = ctx.Units.FirstOrDefault(u => u.UnitNumber == unitNo);

                    if (unit != null)
                    {
                        unitText = unit.UnitText;
                    }

                    return unitText;
                }
            }

            /// <summary>
            /// Gets a Unit with specific Unit Number
            /// </summary>
            /// <param name="unitNo">The Unit Number</param>
            /// <returns>A Unit</returns>
            public static Unit GetSingle(int unitNo)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Units.FirstOrDefault(u => u.UnitNumber == unitNo);
                }
            }

            /// <summary>
            /// Gets a Unit with specific Unit Number
            /// </summary>
            /// <param name="unitNo">The Unit Number</param>
            /// <returns>A Unit</returns>
            public static List<Unit> GetByUnitGroupNum()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Units
                        .Where(u => u.UnitGroupNumber != null)
                        .OrderBy(o => o.UnitGroupNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets Units with specific Unit Group Number
            /// </summary>
            /// <param name="unitGroupNum">The Unit Number</param>
            /// <returns>Unit</returns>
            public static List<Unit> GetByUnitGroupNum(int unitGroupNum)
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Units
                        .Where(u => u.UnitGroupNumber == unitGroupNum)
                        .OrderBy(o => o.UnitGroupNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// Get only UnitShort text
            /// </summary>
            /// <returns>List of UnitShort.</returns>
            public static List<string> GetByUnitShort()
            {
                using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Units
                        .Where(u => u.UnitNumber < 99)
                        .OrderBy(o => o.UnitNumber)
                        .Select(p => p.UnitShort)
                        .ToList();
                }
            }

            

        }
        #endregion
       
    }
}
