// -----------------------------------------------------------------------
// <copyright file="SystemConfiguration.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ElvisDataModel.Configuration
{
    using System.ComponentModel;

    /// <summary>
    /// Class containing properties representing user-configurable System Parameters.
    /// </summary>
    public class SystemConfiguration
    {
        [Category("Casters")]
        [Description("The target casting rate in tonnes per minute")]
        public int TargetCastingRate { get; set; }
    }
}
