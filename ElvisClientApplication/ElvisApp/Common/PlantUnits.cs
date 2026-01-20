//-----------------------------------------------------------------------
// <copyright file="PlantUnits.cs" company="Tata Steel Europe">
//     Copyright (c) Tata Steel Europe. All rights reserved.
// </copyright>
// <author>Matt Joslin | MLJ Systems Ltd written for Tata Steel</author>
//-----------------------------------------------------------------------

namespace Elvis.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Elvis.Model;

    /// <summary>
    /// A container class that contains List of Units on the plant. Singleton.
    /// </summary>
    public sealed class PlantUnits
    { 
        private PlantUnits() { }
        
        private static List<Unit> units;

        public static List<Unit> Units
        {
            get
            {
                if (units == null)
                {
                    units = new List<Unit>();
                    LoadUnits();
                }
                return units;
            }
        }

        public static void LoadUnits()
        {
            units.Add(new Unit() { UnitId = 10, UnitName = "HM N" });
            units.Add(new Unit() { UnitId = 20, UnitName = "HM S" });
            units.Add(new Unit() { UnitId = 70, UnitName = "Scrap B (N)" });
            units.Add(new Unit() { UnitId = 80, UnitName = "Scrap B (S)" });
            units.Add(new Unit() { UnitId = 30, UnitName = "DS N" });
            units.Add(new Unit() { UnitId = 40, UnitName = "DS S" });
            units.Add(new Unit() { UnitId = 50, UnitName = "VS 1" });
            units.Add(new Unit() { UnitId = 60, UnitName = "VS 2" });
            units.Add(new Unit() { UnitId = 100, UnitName = "CAS 1" });
            units.Add(new Unit() { UnitId = 120, UnitName = "RD" });
            units.Add(new Unit() { UnitId = 130, UnitName = "RH" });
            units.Add(new Unit() { UnitId = 110, UnitName = "CAS 2" });
            units.Add(new Unit() { UnitId = 210, UnitName = "CC 1" });
            units.Add(new Unit() { UnitId = 220, UnitName = "CC 2" });
            units.Add(new Unit() { UnitId = 230, UnitName = "CC 3" });
        }

        public static string GetUnitName(int id)
        {
            return Units.Where(u => u.UnitId == id).FirstOrDefault().UnitName;
        }

    }
}
