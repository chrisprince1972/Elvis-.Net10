using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Models.Reports.DailyManagementAgendaThreats;
using BusinessLogic.Constants;

namespace BusinessLogic.Models.ViewModels.Reports
{
    public class DailyManagementAgendaThreatIndex
    {
        ThreatLocationId LocationId { get; set; }
        public string LocationDescription { get; set; }
        public DailyManagementAgendaThreat ShortTermThreat { get; set; }
        public DailyManagementAgendaThreat LongTermThreat { get; set; }


        public DailyManagementAgendaThreatIndex(ThreatLocation location,
            DailyManagementAgendaThreat shortTermThreat,
            DailyManagementAgendaThreat longTermThreat)
        {
            LocationId = location.LocationId;
            LocationDescription = location.LocationDescription;
            ShortTermThreat = shortTermThreat;
            LongTermThreat = longTermThreat;
        }
    }
}
