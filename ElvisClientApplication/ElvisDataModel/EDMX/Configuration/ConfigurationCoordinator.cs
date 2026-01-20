// -----------------------------------------------------------------------
// <copyright file="ConfigurationCoordinator.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ElvisDataModel.Configuration
{
    using System;

    /// <summary>
    /// Coordintates the loading and saving of the user-configurable system parameters.
    /// </summary>
    public static class ConfigurationCoordinator
    {
        // Constants for the Primary Key Index values in the Config.Parameters table, to avoid
        // the use of "Magic Numbers" in the code.
        public const int TARGET_CASTING_RATE_INDEX = 6;

        /// <summary>
        /// Loads an instance of <c>SystemConfiguration</c> containing the user-configurable
        /// system parameters.
        /// </summary>
        /// <returns>An object containing the System Parameters.</returns>
        public static SystemConfiguration LoadConfiguration()
        {
            SystemConfiguration systemConfiguration = new SystemConfiguration();

            // TargetCastingRate
            systemConfiguration.TargetCastingRate =
                Int32.Parse(EntityHelper.GetSetConfigurableParameters.GetParameter(TARGET_CASTING_RATE_INDEX));

            return systemConfiguration;
        }

        /// <summary>
        /// Saves a the System Configuration containing user-configurable system parameters.
        /// </summary>
        /// <param name="systemConfiguration">An object containing the System Parameters.</param>
        public static void SaveConfiguration(SystemConfiguration systemConfiguration)
        {
            if (systemConfiguration == null) return;

            // Target Casting Rate
            EntityHelper.GetSetConfigurableParameters.SetParameter(TARGET_CASTING_RATE_INDEX,
                systemConfiguration.TargetCastingRate.ToString());
        }
    }
}
