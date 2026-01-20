using System;

namespace Elvis.Common
{
    /// <summary>
    /// Helper class to provide access to data about the process thread.
    /// </summary>
    public static class ProcessHelper
    {
        /// <summary>
        /// Gets the duration of the current process thread as a TimeSpan.
        /// </summary>
        public static TimeSpan GetProcessDuraton
        {
            get
            {
                return DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;
            }
        }
    }
}
