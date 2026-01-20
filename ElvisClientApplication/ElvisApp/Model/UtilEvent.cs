//-----------------------------------------------------------------------
// <copyright file="UtilEvent.cs" company="Tata Steel Europe">
//     Copyright (c) Tata Steel Europe. All rights reserved.
// </copyright>
// <author>Matt Joslin | MLJ Systems Ltd written for Tata Steel</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elvis.Model
{
    /// <summary>
    /// Represents the unit events stored in the database.
    /// </summary>
    [Serializable]
    public class UtilEvent
    {
        public int UnitId { get; set; }

        public int EventType { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int HeatNumber { get; set; }

        public int HeatNumberSet { get; set; }

        public int ProgramNumber { get; set; }

        public bool IsPlanningBlock { get; set; }

        /// <summary>
        /// Gets the Caster Number for this Heat.
        /// </summary>
        public int Caster
        {
            get
            {
                if (this.ProgramNumber < 300)
                {
                    return 1;
                }
                else if (this.ProgramNumber < 600) 
                { 
                    return 2; 
                } 
                else 
                { 
                    return 3;
                }
            }
        }
    }
}
