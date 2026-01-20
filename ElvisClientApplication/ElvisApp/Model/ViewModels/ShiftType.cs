// -----------------------------------------------------------------------
// <copyright file="ShiftType.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Elvis.Model.ViewModels
{
    using System;
    using System.ComponentModel;

    public enum ShiftType
    {
        [Description("Day Shift")]
        Day,

        [Description("Night Shift")]
        Night,

        [Description("10:00 AM Plan")]
        TenAMPlan,

        [Description("07:00 AM Plan")]
        SevenAMPlan
    }
}
