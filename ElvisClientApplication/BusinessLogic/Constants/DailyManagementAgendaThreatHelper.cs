using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Constants
{
    public enum ThreatLocationId
    {
        Unknown = 0,
        Safety,
        HmBay,
        HmDesulph,
        Converter1,
        Converter2,
        ChargingBayCranesincluding50tCrane,
        TeemingBayCranesincluding63tMonoRail,
        CasOb1,
        CasOb2,
        RdKtb,
        RhDegasser,
        Ladles
    }

    public enum ThreatTimescales
    {
        Unknown = 0,
        Hour24Threat,
        LongTermPm
    }
}
