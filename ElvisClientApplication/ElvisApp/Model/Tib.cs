using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Elvis.Common;
using NLog;
using Elvis.Properties;

// Explicit alias to avoid Unit ambiguity (this file is in Elvis.Model namespace)
using EdmxUnit = ElvisDataModel.EDMX.Unit;

namespace Elvis.Model
{
    public static class Tib
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string TibDataFileName = "tibData.json";

        #region File: Save and Load (JSON)
        public static bool SaveTibEvents(List<TibEvent> events)
        {
            try
            {
                events ??= new List<TibEvent>();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = false
                };

                var json = JsonSerializer.Serialize(events, options);
                File.WriteAllText(TibDataFileName, json);
                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorException("TIB DATA ERROR -- Save Failure -- ", ex);
            }
            return false;
        }

        public static List<TibEvent> LoadTibEvents()
        {
            try
            {
                if (!File.Exists(TibDataFileName))
                    return new List<TibEvent>();

                var json = File.ReadAllText(TibDataFileName);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<TibEvent>>(json, options) ?? new List<TibEvent>();
            }
            catch (Exception ex)
            {
                logger.ErrorException("TIB DATA ERROR -- Load Failure -- ", ex);
            }
            return new List<TibEvent>();
        }
        #endregion

        #region Public

        #region Tib Events
        public static List<TibEvent> GetTibEvents()
        {
            List<TibEvent> tibEvents = new List<TibEvent>();
            List<TIBEvent> dbTIBEvents = GetDBTibEvents();
            List<TIBDelay> dbTIBDelays = GetDBTibDelays();

            if (dbTIBEvents != null)
            {
                foreach (TIBEvent tibDBEvent in dbTIBEvents)
                {
                    TibEvent tib = new TibEvent()
                    {
                        TibIndex = tibDBEvent.TibIndex,
                        UnitNumber = tibDBEvent.UnitNumber,
                        HeatNumber = tibDBEvent.HeatNumber,
                        HeatNumberSet = tibDBEvent.HNS,
                        ProgramNumber = tibDBEvent.ProgramNumber,
                        StartTime = tibDBEvent.EventStart,
                        EndTime = tibDBEvent.EventEnd,
                        Duration = tibDBEvent.TibDuration,
                        TibStatus = tibDBEvent.TibStatus,
                        Delays = GetTibDelaysSafely(dbTIBDelays, tibDBEvent.TibIndex)
                    };

                    tibEvents.Add(tib);
                }
            }

            return tibEvents;
        }

        public static List<TIBEvent> GetDBTibEvents()
        {
            try
            {
                return EntityHelper.TIBEvents.GetLastXDays(Settings.Default.TibDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetDBTibEvents() -- " +
                    "Getting TIB Events data from database -- ", ex);
                return new List<TIBEvent>();
            }
        }

        public static TIBEvent GetDBTibEvent(int tibIndex)
        {
            try
            {
                return EntityHelper.TIBEvents.GetSingle(tibIndex);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetDBTibEvent() -- " +
                    "Getting TIB Event data from database -- Tib Index: " +
                    tibIndex + " -- ", ex);
                return null;
            }
        }

        public static int GetAppointmentHeight(int? tibStatus)
        {
            switch (tibStatus)
            {
                case 1: return Settings.Default.HeightTibNotProducing;
                case 2: return Settings.Default.HeightTibProducing;
                case 3: return Settings.Default.HeightTibInProcess;
                case 4: return Settings.Default.HeightTibOutProcess;
                case 5: return Settings.Default.HeightTibUnproductive;
                case 100: return 13;
                default: return 20;
            }
        }
        #endregion

        #region Tib Delays
        public static List<TIBDelay> GetDBTibDelays()
        {
            try
            {
                return EntityHelper.TIBDelays.GetLastXDays(Settings.Default.TibDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetDBTibDelays() -- " +
                    "Getting TIB Delays data from database -- ", ex);
                return new List<TIBDelay>();
            }
        }
        #endregion

        #region Tib Reports
        public static List<TibReportDelaysView> GetDelaysToEnterView(DateTime dateFrom, DateTime dateTo, int minimumDuration = 0)
        {
            try
            {
                var rawDelaysData = EntityHelper.TibReportDelaysView.GetByDateRange(dateFrom, dateTo);

                rawDelaysData = rawDelaysData.Where(d => d.TibDuration > 0).ToList();
                rawDelaysData.ForEach(r => r.Rota = string.IsNullOrEmpty(r.Rota) ? "Unknown" : r.Rota.Trim());

                var tibEventStartLookUp = EntityHelper.TIBEvents
                    .GetByDateRange(dateFrom, dateTo)
                    .Select(e => new { e.TibIndex, e.UnitNumber, e.EventStart })
                    .ToList();

                var groupedUnitEvents = rawDelaysData.GroupBy(e => e.UnitNumber).OrderBy(g => g.Key);

                foreach (var unitEventGrouping in groupedUnitEvents)
                {
                    var unitEvents = unitEventGrouping.OrderBy(e => e.EventStart).ToList();
                    if (unitEvents.Count > 0)
                    {
                        for (int i = 0; i < unitEvents.Count; i++)
                        {
                            if (!unitEvents[i].EventEnd.HasValue && unitEvents[i].TibDuration > 0)
                            {
                                var nextEventForUnit = tibEventStartLookUp
                                    .OrderBy(t => t.TibIndex)
                                    .Where(e => e.UnitNumber == unitEvents[i].UnitNumber && e.TibIndex > unitEvents[i].TibIndex)
                                    .FirstOrDefault();

                                unitEvents[i].EventEnd = nextEventForUnit != null ? nextEventForUnit.EventStart : MyDateTime.Now;

                                unitEvents[i].TibDuration = Convert.ToInt32(
                                    (unitEvents[i].EventEnd.Value - unitEvents[i].EventStart.Value).TotalMinutes);
                            }

                            bool isEventStartOrEndChanged = false;

                            if (unitEvents[i].EventEnd.GetValueOrDefault() > dateTo)
                            {
                                unitEvents[i].EventEnd = dateTo.AddMinutes(-1);
                                isEventStartOrEndChanged = true;
                            }

                            if (unitEvents[i].EventStart.GetValueOrDefault() < dateFrom)
                            {
                                unitEvents[i].EventStart = dateFrom;
                                isEventStartOrEndChanged = true;
                            }

                            if (isEventStartOrEndChanged)
                            {
                                TimeSpan? ts = unitEvents[i].EventEnd - unitEvents[i].EventStart;
                                unitEvents[i].TibDuration = Convert.ToInt16(ts.Value.TotalMinutes);
                            }
                        }
                    }
                }

                var processedDelays = groupedUnitEvents.SelectMany(d => d).ToList();
                processedDelays.RemoveAll(d => d.TibDuration < minimumDuration);

                return processedDelays.Distinct().ToList();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetDelaysToEnterView() -- " +
                    "Getting TIB Delays To Enter Reports View data from database -- ", ex);
                return new List<TibReportDelaysView>();
            }
        }
        #endregion

        #region Treatment Tracking
        public static List<HeatTreatmentDTO> GetHeatTreatmentDTOData(
            List<TreatmentTracking> treatmentTrackings,
            List<EdmxUnit> units,
            List<Treatment> treatments)
        {
            try
            {
                List<HeatTreatmentDTO> heatTreatmentsDTO = new List<HeatTreatmentDTO>();

                foreach (TreatmentTracking treatmentTrack in treatmentTrackings)
                {
                    HeatTreatmentDTO treatmentDTO = new HeatTreatmentDTO()
                    {
                        TreatmentIndex = treatmentTrack.TreatmentIndex,
                        HeatNumber = treatmentTrack.HeatNumber,
                        HNS = treatmentTrack.HNS,
                        UnitNumber = treatmentTrack.UnitNumber,
                        TreatmentNumber = treatmentTrack.TreatmentNumber,
                        TimeStampStart = treatmentTrack.TimeStampStart,
                        TimeStampEnd = treatmentTrack.TimeStampEnd
                    };

                    if (treatments != null)
                    {
                        Treatment treatment = treatments.FirstOrDefault(t =>
                            t.TreatmentNumber == treatmentTrack.TreatmentNumber &&
                            t.UnitNumber == treatmentTrack.UnitNumber);

                        if (treatment != null)
                            treatmentDTO.TreatmentText = treatment.TreatmentText;
                    }

                    if (units != null)
                    {
                        EdmxUnit unit = units.FirstOrDefault(u => u.UnitNumber == treatmentTrack.UnitNumber);
                        if (unit != null)
                        {
                            treatmentDTO.UnitGroupSort = unit.UnitGroupSort;
                            treatmentDTO.UnitShort = unit.UnitShort;
                            treatmentDTO.UnitText = unit.UnitText;
                        }
                    }

                    heatTreatmentsDTO.Add(treatmentDTO);
                }

                return heatTreatmentsDTO.OrderBy(h => h.TimeStampStart).ToList();
            }
            catch (Exception ex)
            {
                logger.ErrorException("TIB DATA ERROR -- GetHeatTreatmentDTOData() -- " +
                    "Error Building TIB HeatTreatmentDTO data from database -- ", ex);
                return new List<HeatTreatmentDTO>();
            }
        }
        #endregion

        // (Rest of file unchanged from your current version)
        // Keep your Caster Review + GetNextEvent + helper methods as-is

        #region Private
        private static List<TIBDelay> GetTibDelaysSafely(List<TIBDelay> dbTIBDelays, int tibIndex)
        {
            if (dbTIBDelays != null)
                return dbTIBDelays.Where(t => t.TibIndex == tibIndex).ToList();
            return new List<TIBDelay>();
        }
        #endregion

        public static ElvisDataModel.EDMX.TIBEvent GetNextEvent(int referenceNumber, int lastTib, bool isSingleUnit)
        {
            if (isSingleUnit)
                return EntityHelper.TIBEvents.GetNextEventForUnit(lastTib, referenceNumber);
            else
                return EntityHelper.TIBEvents.GetNextEventForUnitGroup(lastTib, referenceNumber);
        }
    }

    public class HeatTreatmentDTO
    {
        public int TreatmentIndex { get; set; }
        public int HeatNumber { get; set; }
        public int HNS { get; set; }
        public int UnitNumber { get; set; }
        public int TreatmentNumber { get; set; }
        public string TreatmentText { get; set; }
        public DateTime? TimeStampStart { get; set; }
        public DateTime? TimeStampEnd { get; set; }
        public string UnitText { get; set; }
        public string UnitShort { get; set; }
        public int? UnitGroupSort { get; set; }

        public int PlannedDuration => 0;

        public int ActualDuration
        {
            get
            {
                if (TimeStampStart.HasValue && TimeStampEnd.HasValue)
                    return Convert.ToInt32((TimeStampEnd.Value - TimeStampStart.Value).TotalMinutes);
                return 0;
            }
        }

        public bool HasExceededPlannedDuration => ActualDuration > PlannedDuration;
    }
}
#endregion