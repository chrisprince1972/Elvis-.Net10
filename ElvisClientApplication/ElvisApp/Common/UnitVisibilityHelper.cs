using System;
using System.Collections.Generic;
using System.Linq;
using Elvis.Properties;

namespace Elvis.UserControls
{
    /// <summary>
    /// Stores and retrieves the users choices of which units to show or hide on screen.
    /// </summary>
    internal static class UnitVisibilityHelper
    {
        /// <summary>
        /// Enumeration of which type of settings to save/retrieve.
        /// </summary>
        internal enum UnitGroupVisibilitySettings { Heat, Tib };

        /// <summary>
        /// Stores a list of the units the user wants to hide on screen in their user settings.
        /// </summary>
        /// <param name="unitsToHide">The Unit Numbers of the units to hide</param>
        /// <param name="groupSettingsType">The group ie Heat or TIB</param>
        internal static void SetUnitsToHide(List<int> unitsToHide, UnitGroupVisibilitySettings groupSettingsType)
        {
            string settingsToSave = String.Join(",", unitsToHide
                .Select(u => u.ToString())
                .ToArray());

            switch (groupSettingsType)
            {
                case UnitGroupVisibilitySettings.Heat:
                    Settings.Default.HeatUnitsToHide = settingsToSave;
                    break;
                case UnitGroupVisibilitySettings.Tib:
                    Settings.Default.TibUnitsToHide = settingsToSave;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Retrieves a list of the units the user wants to hide on screen from their user settings.
        /// </summary>
        /// <param name="groupSettingsType">The group ie Heat or TIB</param>
        /// <returns>A collections of the hidden unit numbers or null if no units are to be hidden.</returns>
        internal static List<int> GetUnitsToHide(UnitGroupVisibilitySettings groupSettingsType)
        {
            List<int> units = null;

            switch (groupSettingsType)
            {
                case UnitGroupVisibilitySettings.Heat:

                    if (!String.IsNullOrEmpty(Settings.Default.HeatUnitsToHide))
                    {
                        units = Settings.Default.HeatUnitsToHide
                            .Split(',')
                            .Select(u => Int32.Parse(u))
                            .ToList();
                    }
                    break;
                case UnitGroupVisibilitySettings.Tib:
                    if (!String.IsNullOrEmpty(Settings.Default.TibUnitsToHide))
                    {
                        units = Settings.Default.TibUnitsToHide
                            .Split(',')
                            .Select(u => Int32.Parse(u))
                            .ToList();
                    }
                    break;
                default:
                    break;
            }

            return units;
        }
    }
}
