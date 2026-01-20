//-----------------------------------------------------------------------
// <copyright file="Unit.cs" company="Tata Steel Europe">
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
    /// A model of a Steel Plant Unit.
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Gets or sets the unit number. This Id is common across multiple systems.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Gets or sets the name of the unit.
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit.
        /// </summary>
        public int UnitType { get; set; }
    }
}
