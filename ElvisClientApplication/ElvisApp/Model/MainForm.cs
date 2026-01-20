using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Elvis.Common;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using Elvis.Properties;

namespace Elvis.Model
{
    public static class MainForm
    {
        #region Variables + Properties
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static DateTime PlanPublishTime { get; set; }
        #endregion

        #region Bin File: Save and Load
        /// <summary>
        /// Push out the events to a binary file.
        /// </summary>
        /// <param name="events">A boolean with state of Save</param>
        public static bool SaveEvents(List<ProductionEvent> events)
        {
            try
            {
                using (FileStream stream = new FileStream("data.bin", FileMode.Create))
                {
                    if (stream != null && stream.CanRead && stream.CanWrite)
                    {//Added checks to try and remove certain user errors.
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, events);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("BIN DATA ERROR -- Save Failure -- ", ex);
            }
            return false;
        }

        /// <summary>
        /// Pull in the events from a binary file.
        /// </summary>
        /// <returns>A list of event objects.</returns>
        public static List<ProductionEvent> LoadEvents()
        {
            List<ProductionEvent> events = new List<ProductionEvent>();
            try
            {
                if (File.Exists("data.bin"))
                {
                    using (FileStream stream = new FileStream("data.bin", FileMode.Open))
                    {
                        if (stream != null && stream.CanRead && stream.CanWrite)
                        {//Added checks to try and remove certain user errors.
                            BinaryFormatter bin = new BinaryFormatter();
                            events = (List<ProductionEvent>)bin.Deserialize(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("BIN DATA ERROR -- Load Failure -- ", ex);
            }
            return events;
        }
        #endregion

        #region Get Data

        #region Planned Heats
        /// <summary>
        /// Gets all planned heats from the new Elvis Database
        /// </summary>
        /// <returns>A list of event objects.</returns>
        public static List<ProductionEvent> GetPlannedHeats()
        {
            List<CoordLink> plannedHeats = GetCoordLink();
            List<ProductionEvent> events = new List<ProductionEvent>();
            List<HotConnect> hotConnects = GetHotConnectData();

            try
            {
                if (plannedHeats != null && plannedHeats.Count > 0)
                {
                    if (plannedHeats[0].UPDATE_TIME.HasValue)
                    {
                        DateTime dtConvert = new DateTime();
                        if (DateTime.TryParse(plannedHeats[0].UPDATE_TIME.ToString(), out dtConvert))
                        {
                            PlanPublishTime = dtConvert;
                        }
                    }

                    foreach (CoordLink heat in plannedHeats)
                    {
                        if (heat != null)
                        {
                            string casterNumber = GetPlanCasterName(heat.CASTER_NUMBER.ToString());
                            int programNumber = 0;
                            int vesselNumber = 0;
                            int grade = 0;
                            int ladleNo = 0;
                            bool isHotConnect = false;

                            if (heat.PROGRAM_NUMBER.HasValue)
                                int.TryParse(heat.PROGRAM_NUMBER.Value.ToString(), out programNumber);

                            if (heat.VESSEL_NUMBER.HasValue)
                                int.TryParse(heat.VESSEL_NUMBER.Value.ToString(), out vesselNumber);

                            if (heat.GRADE_1.HasValue)
                                int.TryParse(heat.GRADE_1.Value.ToString(), out grade);

                            if (heat.STEEL_LADLE_NUMBER.HasValue)
                                int.TryParse(heat.STEEL_LADLE_NUMBER.Value.ToString(), out ladleNo);

                            HotConnect hotConnect = hotConnects
                                        .Where(hc => hc.HeatNumber == heat.HEAT_NUMBER)
                                        .Where(hc => hc.HNS == heat.HNS)
                                        .FirstOrDefault();

                            if (hotConnect != null)
                            {
                                isHotConnect = true;
                            }

                            ProductionEvent productionEvent;

                            //Add Pour Info -- ** TODO: Unit Number **
                            if (heat.PLANNED_POUR_TIME.HasValue)
                            {
                                productionEvent =
                                    new ProductionEvent(
                                        heat.HEAT_NUMBER, heat.HNS, 1,
                                        heat.PLANNED_POUR_TIME.Value.AddMinutes(-18),
                                        heat.PLANNED_POUR_TIME.Value,
                                        programNumber, casterNumber,
                                        vesselNumber, true, grade, 0);

                                productionEvent.IsHotConnect = isHotConnect;
                                AddPlannedEventToList(events, productionEvent);
                            }

                            //Add Desulph Info -- ** TODO: Unit Number **
                            if (heat.PLANNED_POUR_TIME.HasValue &&
                                heat.PLANNED_END_DESULPH_TIME.HasValue)
                            {
                                productionEvent =
                                    new ProductionEvent(
                                    heat.HEAT_NUMBER, heat.HNS, 3,
                                    heat.PLANNED_END_DESULPH_TIME.Value.AddMinutes(-25),
                                    heat.PLANNED_END_DESULPH_TIME.Value,
                                    programNumber, casterNumber,
                                    vesselNumber, true, grade, 0);

                                productionEvent.IsHotConnect = isHotConnect;
                                AddPlannedEventToList(events, productionEvent);
                            }

                            //Add Vessel Plan
                            if (heat.PLANNED_CHARGE_TIME.HasValue &&
                                heat.PLANNED_TAP_TIME.HasValue)
                            {
                                productionEvent =
                                    new ProductionEvent(
                                    heat.HEAT_NUMBER,
                                    heat.HNS,
                                    GetUnitNumber("Vessel",
                                        HelperFunctions.GetStringFromObjectSafely(
                                            vesselNumber)),
                                    heat.PLANNED_CHARGE_TIME.Value,
                                    heat.PLANNED_TAP_TIME.Value,
                                    programNumber, casterNumber,
                                    vesselNumber, true, grade, ladleNo);

                                productionEvent.IsHotConnect = isHotConnect;
                                AddPlannedEventToList(events, productionEvent);
                            }

                            //Secondary Steel
                            if (heat.PLANNED_TAP_TIME.HasValue &&
                                heat.PLANNED_END_SS_TIME.HasValue)
                            {
                                if (heat.SS_UNIT.Contains("-"))
                                {//Add Two SS Events
                                    string[] ssUnits = heat.SS_UNIT.Split('-');

                                    if (ssUnits.Count() > 1)
                                    {
                                        //FIRST SS EVENT
                                        productionEvent =
                                            new ProductionEvent(
                                            heat.HEAT_NUMBER, heat.HNS,
                                            GetUnitNumber("SS", ssUnits[0]),
                                            heat.PLANNED_END_SS_TIME.Value.AddMinutes(-65),
                                            heat.PLANNED_END_SS_TIME.Value.AddMinutes(-35),
                                            programNumber, casterNumber,
                                            vesselNumber, true, grade, ladleNo);

                                        productionEvent.IsHotConnect = isHotConnect;
                                        AddPlannedEventToList(events, productionEvent);

                                        //SECOND SS EVENT
                                        productionEvent =
                                            new ProductionEvent(
                                            heat.HEAT_NUMBER, heat.HNS,
                                            GetUnitNumber("SS", ssUnits[1]),
                                            heat.PLANNED_END_SS_TIME.Value.AddMinutes(-30),
                                            heat.PLANNED_END_SS_TIME.Value,
                                            programNumber, casterNumber,
                                            vesselNumber, true, grade, ladleNo);

                                        productionEvent.IsHotConnect = isHotConnect;
                                        AddPlannedEventToList(events, productionEvent);
                                    }
                                }
                                else
                                {
                                    productionEvent =
                                        new ProductionEvent(
                                        heat.HEAT_NUMBER, heat.HNS,
                                        GetUnitNumber("SS", heat.SS_UNIT),
                                        heat.PLANNED_TAP_TIME.Value.AddMinutes(10),
                                        heat.PLANNED_END_SS_TIME.Value,
                                        programNumber, casterNumber,
                                        vesselNumber, true, grade, ladleNo);

                                    productionEvent.IsHotConnect = isHotConnect;
                                    AddPlannedEventToList(events, productionEvent);
                                }
                            }

                            //Caster
                            if (heat.PLANNED_START_CAST_TIME.HasValue &&
                                heat.PLANNED_END_CAST_TIME.HasValue)
                            {
                                productionEvent =
                                    new ProductionEvent(
                                    heat.HEAT_NUMBER, heat.HNS,
                                    GetUnitNumber("Caster", casterNumber),
                                    heat.PLANNED_START_CAST_TIME.Value,
                                    heat.PLANNED_END_CAST_TIME.Value,
                                    programNumber, casterNumber,
                                    vesselNumber, true, grade, ladleNo);

                                if (heat.QACastingTime.HasValue)
                                    productionEvent.IdealCastingTime = heat.QACastingTime.Value;

                                if (heat.CAST_DURATION.HasValue)
                                    productionEvent.CastDuration = heat.CAST_DURATION.Value;

                                productionEvent.IsHotConnect = isHotConnect;
                                AddPlannedEventToList(events, productionEvent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading Planned Events -- ", ex);
            }
            return events;
        }

        /// <summary>
        /// Gets all planned heats from the new Elvis Database
        /// for the casters only.
        /// </summary>
        /// <returns>A list of event objects.</returns>
        public static List<ProductionEvent> GetCasterPlannedHeats()
        {
            List<CoordLink> plannedHeats = GetCoordLink();
            List<ProductionEvent> events = new List<ProductionEvent>();

            try
            {
                if (plannedHeats != null && plannedHeats.Count > 0)
                {
                    if (plannedHeats[0].UPDATE_TIME.HasValue)
                    {
                        DateTime dtConvert = new DateTime();
                        if (DateTime.TryParse(plannedHeats[0].UPDATE_TIME.ToString(), out dtConvert))
                        {
                            PlanPublishTime = dtConvert;
                        }
                    }

                    foreach (CoordLink heat in plannedHeats)
                    {
                        if (heat != null)
                        {
                            string casterNumber = GetPlanCasterName(heat.CASTER_NUMBER.ToString());
                            int programNumber = 0;
                            int vesselNumber = 0;
                            int grade = 0;
                            int ladleNo = 0;

                            if (heat.PROGRAM_NUMBER.HasValue)
                                int.TryParse(heat.PROGRAM_NUMBER.Value.ToString(), out programNumber);

                            if (heat.VESSEL_NUMBER.HasValue)
                                int.TryParse(heat.VESSEL_NUMBER.Value.ToString(), out vesselNumber);

                            if (heat.GRADE_1.HasValue)
                                int.TryParse(heat.GRADE_1.Value.ToString(), out grade);

                            if (heat.STEEL_LADLE_NUMBER.HasValue)
                                int.TryParse(heat.STEEL_LADLE_NUMBER.Value.ToString(), out ladleNo);

                            ProductionEvent productionEvent;

                            //Caster
                            if (heat.PLANNED_START_CAST_TIME.HasValue &&
                                heat.PLANNED_END_CAST_TIME.HasValue)
                            {
                                productionEvent =
                                    new ProductionEvent(
                                    heat.HEAT_NUMBER, heat.HNS,
                                    GetUnitNumber("Caster", casterNumber),
                                    heat.PLANNED_START_CAST_TIME.Value,
                                    heat.PLANNED_END_CAST_TIME.Value,
                                    programNumber, casterNumber,
                                    vesselNumber, true, grade, ladleNo);

                                if (heat.QACastingTime.HasValue)
                                    productionEvent.IdealCastingTime = heat.QACastingTime.Value;

                                if (heat.CAST_DURATION.HasValue)
                                    productionEvent.CastDuration = heat.CAST_DURATION.Value;

                                AddPlannedEventToList(events, productionEvent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading Caster Planned Events -- ", ex);
            }
            return events;
        }

        /// <summary>
        /// Gets the coord link data safely.
        /// </summary>
        /// <returns>Returns a List of Coord Link Data.</returns>
        private static List<CoordLink> GetCoordLink()
        {
            try
            {
                return EntityHelper.CoordLink.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- " +
                    "GetCoordLink()", ex);
            }
            return new List<CoordLink>();
        }
        #endregion

        #region Data
        /// <summary>
        /// Gets all existing data events from the new Elvis Database
        /// </summary>
        /// <returns>A list of ProductionEvent objects.</returns>
        public static List<ProductionEvent> GetData()
        {
            List<ProductionEvent> events = new List<ProductionEvent>();
            List<Tracking> trackingEvents = GetTrackingData();
            List<ProgramHistory> programHistory = GetProgramHistory();
            List<MiscastMain> miscasts = Miscasts.GetMiscastData();
            List<TapWeight> tapWeights = GetTapWeights();
            List<CoordLinkFull> coordLinks = GetCoordLinkData();
            List<HMPour> hmPours = GetHMPourData();
            List<HotConnect> hotConnects = GetHotConnectData();

            try
            {
                foreach (Tracking trackEvent in trackingEvents)
                {
                    int programNumber =
                        GetCurrentProgramNumber(
                            programHistory,
                            trackEvent.HeatNumber);

                    string casterName =
                        GetCasterName(
                            trackingEvents,
                            programNumber,
                            trackEvent.HeatNumber);

                    int vesselNumber =
                        GetVesselNo(
                            trackingEvents,
                            trackEvent.HeatNumber);

                    int grade =
                        GetGradeNo(
                            programHistory,
                            trackEvent.HeatNumber,
                            trackEvent.HNS);

                    int ladleNo = 0;

                    if (trackEvent.UnitNumber < 5)
                    {//Get from HMPour data for ladle numbers.
                        ladleNo = GetLadleNo(
                            hmPours,
                            trackEvent.HeatNumber,
                            trackEvent.HNS);
                    }
                    else
                    {//Get From Tap weights
                        ladleNo = GetLadleNo(
                                tapWeights,
                                trackEvent.HeatNumber,
                                trackEvent.HNS);

                        if (ladleNo == 0)
                        {//Try the coord lock data for ladle number.
                            ladleNo = GetLadleNo(
                                coordLinks,
                                trackEvent.HeatNumber,
                                trackEvent.HNS);
                        }
                    }

                    if ((trackEvent.HeatNumber > 0) &&
                        (trackEvent.TimeStampStart != null))
                    {//Adds all Valid Events
                        ProductionEvent productionEvent =
                            new ProductionEvent(trackEvent.TrackIndex,
                                trackEvent.HeatNumber,
                                trackEvent.HNS,
                                trackEvent.UnitNumber,
                                0, trackEvent.TimeStampStart,
                                trackEvent.TimeStampEnd,
                                programNumber,
                                casterName,
                                vesselNumber,
                                false, grade,
                                ladleNo);

                        if (miscasts != null && miscasts.Count > 0 &&
                            productionEvent.UnitId >= 11 && productionEvent.UnitId <= 13)
                        {
                            productionEvent.MiscastType = Miscasts.GetMiscastTypeByProductionEvent(
                                miscasts, productionEvent);
                        }

                        if (productionEvent.EndTime.HasValue || productionEvent.IsInProgress)
                            events.Add(productionEvent);

                        var hotConnect = hotConnects
                            .Where(hc => hc.HeatNumber == productionEvent.HeatNumber)
                            .Where(hc => hc.HNS == productionEvent.HeatNumberSet)
                            .FirstOrDefault();

                        if (hotConnect != null)
                        {
                            productionEvent.IsHotConnect = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading Events -- ", ex);
            }
            return events;
        }

        /// <summary>
        /// Gets the final grade number for a heat.
        /// </summary>
        /// <param name="programHistory">A list of the programHistory frmo the last 20 days</param>
        /// <param name="heatNumber">The Heat Number as int.</param>
        /// <param name="heatNumberSet">The Heat Number Set as int.</param>
        /// <returns></returns>
        private static int GetGradeNo(List<ProgramHistory> programHistory,
            int heatNumber, int heatNumberSet)
        {
            int grade = 0;
            ProgramHistory history =
                programHistory.OrderByDescending(o =>
                        o.TimeCreated)
                    .FirstOrDefault(p =>
                        p.HeatNumber == heatNumber &&
                        p.HNS == heatNumberSet);

            if (history != null && history.TargetGrade.HasValue)
            {
                int.TryParse(history.TargetGrade.ToString(), out grade);
            }

            return grade;
        }

        /// <summary>
        /// Gets the Ladle Number from a list of Tap weight data.
        /// </summary>
        /// <param name="tapWeights">The tap weight from the last x days.</param>
        /// <param name="heatNo">The Heat Number.</param>
        /// <param name="heatNoSet">The Heat Number Set.</param>
        /// <returns>An int representing the ladle number.</returns>
        private static int GetLadleNo(List<TapWeight> tapWeights, int heatNo, int heatNoSet)
        {
            int ladleNo = 0;

            TapWeight tapWeight = tapWeights.FirstOrDefault(t =>
                t.HeatNumber == heatNo &&
                t.HNS == heatNoSet
                );

            if (tapWeight != null && tapWeight.LadleNumber.HasValue)
            {
                ladleNo = tapWeight.LadleNumber.Value;
            }

            return ladleNo;
        }

        /// <summary>
        /// Gets the Ladle Number from a list of HM Pour data for
        /// the Hot Metal units.
        /// </summary>
        /// <param name="hmPours">The tap weight from the last x days.</param>
        /// <param name="heatNo">The Heat Number.</param>
        /// <param name="heatNoSet">The Heat Number Set.</param>
        /// <returns>An int representing the ladle number.</returns>
        private static int GetLadleNo(List<HMPour> hmPours, int heatNo, int heatNoSet)
        {
            int ladleNo = 0;

            HMPour hmPour = hmPours.FirstOrDefault(t =>
                t.HeatNumber == heatNo &&
                t.HNS == heatNoSet
                );

            if (hmPour != null && hmPour.LadleNumber.HasValue)
            {
                ladleNo = hmPour.LadleNumber.Value;
            }

            return ladleNo;
        }

        /// <summary>
        /// A backup get for the ladle number if the Tap Weight table
        /// does not have the data.
        /// </summary>
        /// <param name="coordLinks">A list of coordination data.</param>
        /// <param name="heatNo">The Heat Number.</param>
        /// <param name="heatNoSet">The Heat Number Set.</param>
        /// <returns>The Ladle Number as an int.</returns>
        private static int GetLadleNo(List<CoordLinkFull> coordLinks, int heatNo, int heatNoSet)
        {
            int ladleNo = 0;

            CoordLinkFull coordLink = coordLinks
                .OrderByDescending(t => t.TimeStamp)
                .FirstOrDefault(t =>
                    t.HEAT_NUMBER == heatNo &&
                    t.HNS == heatNoSet
                );

            if (coordLink != null && coordLink.STEEL_LADLE_NUMBER.HasValue)
            {
                ladleNo = coordLink.STEEL_LADLE_NUMBER.Value;
            }

            return ladleNo;
        }

        /// <summary>
        /// Gets Tracking Data up front for the last X days
        /// </summary>
        /// <returns>List of Tracking Objects</returns>
        private static List<Tracking> GetTrackingData()
        {
            try
            {
                return EntityHelper.Tracking.GetLastXDays(Settings.Default.OverviewDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetTrackingData() -- " +
                    "Getting tracking data from database -- ", ex);
                return new List<Tracking>();
            }
        }

        /// <summary>
        /// Gets program history up front for the last X days
        /// </summary>
        /// <returns>List of ProgramHistory Objects</returns>
        private static List<ProgramHistory> GetProgramHistory()
        {
            try
            {
                return EntityHelper.ProgramHistory.GetLastXDays(Settings.Default.OverviewDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetProgramHistory() -- " +
                    "Getting Program History data from database -- ", ex);
                return new List<ProgramHistory>();
            }
        }

        /// <summary>
        /// Gets TapWeight history up front for the last X days
        /// </summary>
        /// <returns>List of TapWeight Objects</returns>
        private static List<TapWeight> GetTapWeights()
        {
            try
            {
                return EntityHelper.TapWeights.GetLastXDays(Settings.Default.OverviewDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetTapWeights() -- " +
                    "Getting Tap Weight data from database -- ", ex);
                return new List<TapWeight>();
            }
        }

        /// <summary>
        /// Gets the Coord Link Full records for the last X Days.
        /// </summary>
        /// <returns>A list of CoordLinkFull objects.</returns>
        private static List<CoordLinkFull> GetCoordLinkData()
        {
            try
            {
                return EntityHelper.CoordLinkFull.GetLastXDays(Settings.Default.OverviewDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetCoordLinkData() -- " +
                    "Getting CoordLinkFull data from database -- ", ex);
                return new List<CoordLinkFull>();
            }
        }

        /// <summary>
        /// Gets the HM Pour records for the last X Days.
        /// </summary>
        /// <returns>A list of HMPour objects.</returns>
        private static List<HMPour> GetHMPourData()
        {
            try
            {
                return EntityHelper.HMPour.GetLastXDays(Settings.Default.OverviewDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetHMPourData() -- " +
                    "Getting HMPour data from database -- ", ex);
                return new List<HMPour>();
            }
        }

        /// <summary>
        /// Gets the Hot Connect records for the last X Days.
        /// </summary>
        /// <returns>A list of Hot Connect objects.</returns>
        private static List<HotConnect> GetHotConnectData()
        {
            try
            {
                return EntityHelper.HotConnects.GetLastXDays(Settings.Default.OverviewDaysToShow)
                    .Where(hc => hc.HotConnectFlag.Value == 1)
                    .ToList();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetHotConnectData() -- " +
                    "Getting Hot Connect data from database -- ", ex);
                return new List<HotConnect>();
            }
        }

        #endregion

        #endregion

        #region Support Functions
        //Hard coded to get the unit number of a specific unit area for planning
        private static int GetUnitNumber(string unit, string value)
        {
            if (unit == "SS")
            {
                switch (value.Trim().ToUpper())
                {
                    case "CAS1": return 9;
                    case "RD": return 8;
                    case "RH": return 7;
                    case "CAS2": return 10;
                }
            }
            else if (unit == "Vessel")
            {
                if (value == "1") return 5;
                else return 6;
            }
            else if (unit == "Caster")
            {
                switch (value)
                {
                    case "CC1": return 11;
                    case "CC2": return 12;
                    case "CC3": return 13;
                }
            }
            return 100;//Used as an Unknown Unit Value
        }

        /// <summary>
        /// Checks if there's a valid UnitID before adding to list.
        /// </summary>
        /// <param name="events">List of Events</param>
        /// <param name="productionEvent">Object to add to list</param>
        private static void AddPlannedEventToList(List<ProductionEvent> events, ProductionEvent productionEvent)
        {
            if (productionEvent != null && productionEvent.UnitId < 100)
                events.Add(productionEvent);
        }

        /// <summary>
        /// Generates a Caster Number as a Short Description String e.g. CC1
        /// </summary>
        /// <param name="casterNumber">Caster Number as string</param>
        private static string GetPlanCasterName(string casterNumber)
        {
            return "CC" + casterNumber;
        }

        /// <summary>
        /// Gets Caster Number Using HeatNumber for Events
        /// Caster 1 UnitNumber = 11 (Unit Table in Database)
        /// Caster 2 UnitNumber = 12 (Unit Table in Database)
        /// Caster 3 UnitNumber = 13 (Unit Table in Database)
        /// </summary>
        /// <param name="trackingData">A list of current Tracking Data to search</param>
        /// <param name="programNumber">The Current Program Number of the Event 
        /// (used if unable to find caster number</param>
        /// <param name="heatNumber">The Heat Number</param>
        /// <returns>Caster Number as integer</returns>
        private static string GetCasterName(List<Tracking> trackingData,
                        int programNumber,
                        int heatNumber)
        {
            try
            {
                Tracking casterResult = trackingData
                    .OrderByDescending(
                        h => h.TimeStampStart)
                    .FirstOrDefault(
                        h => h.HeatNumber == heatNumber &&
                             h.UnitNumber >= 11 &&
                             h.UnitNumber <= 13);

                if (casterResult != null)
                {
                    switch (casterResult.UnitNumber)
                    {
                        case 11: return "CC1";
                        case 12: return "CC2";
                        case 13: return "CC3";
                    }
                }
                //if no casterResult found then get Program Number by other means
                return GetCasterByProgramNumber(programNumber);
            }
            catch (Exception ex)
            {
                logger.ErrorException("ERROR -- GetCasterName() -- ", ex);
            }
            return "Unavailable";
        }

        /// <summary>
        /// Fail safe to ensure there is a caster number for the most recent events
        /// </summary>
        /// <param name="programNumber">Program Number of Event</param>
        /// <returns>Caster Number in Short Description String e.g. CC1</returns>
        private static string GetCasterByProgramNumber(int programNumber)
        {
            if (programNumber == 0)//Error
                return "Unavailable";
            else if (programNumber < 300)//Caster 1 Programs
                return "CC1";
            else if (programNumber < 600)//Caster 2 Programs
                return "CC2";
            else//Caster 3 Programs
                return "CC3";
        }

        /// <summary>
        /// Gets Vessel Number Using HeatNumber
        /// Vessel 1 UnitNumber = 5 (Unit Table in Database)
        /// Vessel 2 UnitNumber = 6 (Unit Table in Database)
        /// </summary>
        /// <param name="trackingData">A list of current Tracking Data to search</param>
        /// <param name="heatNumber">The Heat Number</param>/// 
        /// <returns>Vessel Number as integer, 0 is error value</returns>
        private static int GetVesselNo(List<Tracking> trackingData, int heatNumber)
        {
            try
            {
                Tracking vesselResult = trackingData
                    .OrderByDescending(h => h.TimeStampStart)
                    .FirstOrDefault(
                        h => h.HeatNumber == heatNumber &&
                                h.UnitNumber >= 5 &&
                                h.UnitNumber <= 6);

                if (vesselResult != null)
                {
                    if (vesselResult.UnitNumber == 5)
                        return 1;
                    else if (vesselResult.UnitNumber == 6)
                        return 2;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("ERROR -- GetVesselNo() -- ", ex);
            }
            return 0;
        }

        /// <summary>
        /// Gets the Current Program Number from Program History List using 
        /// heatNumber and heatNumberSet
        /// </summary>
        /// <returns>Returns the value as an integer</returns>
        public static int GetCurrentProgramNumber(
                                    List<ProgramHistory> phList,
                                    int heatNumber)
        {
            try
            {
                if (phList != null)
                {
                    ProgramHistory ph = phList
                                .OrderByDescending(p => p.TimeCreated)
                                .FirstOrDefault(p => p.HeatNumber == heatNumber);
                    if (ph != null && ph.ProgramNumber != null)
                    {
                        return int.Parse(ph.ProgramNumber.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("ERROR -- GetCurrentProgramNumber() -- ", ex);
            }
            return 0;
        }
        #endregion
    }
}
