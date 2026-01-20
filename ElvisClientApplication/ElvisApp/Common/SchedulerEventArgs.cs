using System;
using System.Windows.Forms;
using MLJSystems.Calendars;

namespace Elvis.Common
{
    /// <summary>
    /// Event args passed data back from the graphical Heat Schedule user control.
    /// </summary>
    public class SchedulerEventArgs : EventArgs
    {
        public MouseEventArgs MouseEventArgs { get; set; }

        public AppointmentClickEventArgs AppointmentClickEventArgs { get; set; }

        public Appointment Appointment { get; set; }
    }
}