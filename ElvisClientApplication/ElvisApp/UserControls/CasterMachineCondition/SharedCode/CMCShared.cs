using ElvisDataModel.EDMX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Elvis.UserControls.CasterMachineCondition.SharedCode
{
    public static class CMCShared
    {

        public static Brush SetInternalCriticalColorCode(string cellValue)
        {
            if (cellValue.Equals("Yes"))
            {
                return Brushes.LimeGreen;
            }
            else if (cellValue.Equals("No"))
            {
                return Brushes.OrangeRed;
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public static Brush SetDaysSinceLastSarcladColorCode(string cellValue, int caster, int strand)
        {
            Lookup fieldLookup = GetFieldLookups(caster, strand, "DaysSinceLastSarclad");
            float cellValueDec;
            float.TryParse(cellValue, out cellValueDec);

            if(string.IsNullOrEmpty(cellValue))
            {
                return Brushes.Transparent;
            }
            else if (cellValueDec >= fieldLookup.RedLookup)
            {
                return Brushes.OrangeRed;
            }
            else
            {
                return Brushes.LimeGreen;
            }
        }


        public static Color SetICbgColor(string cellValue, float greenLookup, float redLookup)
        {
            float cellValueFloat;
            float.TryParse(cellValue, out cellValueFloat);

            if (cellValueFloat == greenLookup)
            {
                return Color.LimeGreen;
            }
            else if (cellValueFloat > greenLookup && cellValueFloat < redLookup)
            {
                return Color.Yellow;
            }
            else
            {
                return Color.OrangeRed;
            }
        }
        public static Lookup GetFieldLookups(int caster, int strand, string fieldName)
        {
            Lookup fieldLookup = ElvisDataModel.EntityHelper.CasterMachineCondition
                                             .GetSingle<Lookup>("it.Caster = " + caster +
                                                                " and it.Strand = " + strand +
                                                                " and it.Field = '" + fieldName + "'");
            return fieldLookup;
        }

        public  static Color SetSegmentTonnageColor(string cellValue, decimal plannedTonnage, decimal needsReplacingTonnage)
        {
            decimal cellValueFloat;
            decimal.TryParse(cellValue, out cellValueFloat);

            if (cellValueFloat < plannedTonnage)
            {
                return Color.LimeGreen;
            }
            else if (cellValueFloat >= plannedTonnage && cellValueFloat < needsReplacingTonnage)
            {
                return Color.Yellow;
            }

            else
            {
                return Color.OrangeRed;
            }
        }
    }
}
