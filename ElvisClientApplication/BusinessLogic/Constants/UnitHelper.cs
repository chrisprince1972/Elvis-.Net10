using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Constants
{
    public enum UnitGroup
    {
        Vessles = 3,
        Cas = 5,
        Degassers = 6,
        Casters = 7,
        Unknown

    }
    public enum Unit
    {
        HotMetalNorth = 1,
        HotMetalSouth,
        DesulphNorth,
        DesulphSouth,
        Vessel1,
        Vessel2,
        Rh,
        Rd,
        Cas1,
        Cas2,
        Cc1,
        Cc2,
        Cc3,
        LimePlant,
        SteelLadle,
        ScrapNorth,
        ScrapSouth,
        AllUnits,
        Unknown
    }

    public class UnitHelper
    {
        public static UnitGroup GetUnitGroup(Unit u)
        {
            UnitGroup returnValue = UnitGroup.Unknown;
            switch (u)
            {
                case Unit.Vessel1:
                case Unit.Vessel2:
                    returnValue = UnitGroup.Vessles;
                    break;
                case Unit.Rh:
                case Unit.Rd:
                    returnValue = UnitGroup.Degassers;
                    break;
                case Unit.Cas1:
                case Unit.Cas2:
                    returnValue = UnitGroup.Cas;
                    break;
                case Unit.Cc1:
                case Unit.Cc2:
                case Unit.Cc3:
                    returnValue = UnitGroup.Casters;
                    break;
            }

            return returnValue;
        }

        public static List<Unit> GetUnits(List<UnitGroup> unitGroups)
        {
            List<Unit> returnValue = new List<Unit>();
            foreach (UnitGroup group in unitGroups)
            {
                returnValue.AddRange(GetUnits(group));
            }
            return returnValue;
        }

        public static List<Unit> GetUnits(UnitGroup ug)
        {
            List<Unit> returnValue = null;

            switch(ug)
            {
                case UnitGroup.Vessles:
                    returnValue = new List<Unit>()
                    {
                        Unit.Vessel1,
                        Unit.Vessel2
                    };
                    break;
                case UnitGroup.Degassers:
                    returnValue = new List<Unit>()
                    {
                        Unit.Rh,
                        Unit.Rd
                    };
                    break;
                case UnitGroup.Cas:
                    returnValue = new List<Unit>()
                    {
                        Unit.Cas1,
                        Unit.Cas2
                    };
                    break;
                case UnitGroup.Casters:
                    returnValue = new List<Unit>()
                    {
                        Unit.Cc1,
                        Unit.Cc2,
                        Unit.Cc3
                    };
                    break;
                default:
                    returnValue = new List<Unit>();
                    break;
            }

            return returnValue;
        }

    }
}
