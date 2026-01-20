// -----------------------------------------------------------------------
// <copyright file="ElvisDbFunctions.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ElvisDataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity.Core.Objects.DataClasses;

    /// <summary>
    /// Class to access User Defined Functions in the Elvis database. Note: these functions cannot be called
    /// directly, they can only be used in LINQ Queries.
    /// </summary>
    public static class ElvisDbFunctions
    {
        /// <summary>
        /// Calls the ElvisDB.Config.GetHNS() user defined function.
        /// </summary>
        /// <returns>The current Heat Number Set</returns>
        [EdmFunction("ElvisDBModel.Store", "GetHNS")]
        public static int GetHNS()
        {
            throw new NotSupportedException("Direct calls are not supported");
        }
    }
}
