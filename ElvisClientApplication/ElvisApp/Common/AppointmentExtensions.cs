using Elvis.Model;
using MLJSystems.Calendars;

namespace Elvis.Common
{
    public static class AppointmentExtensions
    {
        public static ProductionEvent GetHeatData(this Appointment appointment)
        {
            if (appointment.Tag is ProductionEvent)
                return (ProductionEvent)appointment.Tag;
            return new ProductionEvent();
        }
        public static TibEvent GetTibData(this Appointment appointment)
        {
            if (appointment.Tag is TibEvent)
                return (TibEvent)appointment.Tag;
            return new TibEvent();
        }
    }
}
