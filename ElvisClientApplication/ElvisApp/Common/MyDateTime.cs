using System;
using System.Collections.Generic;
using System.Text;

namespace Elvis.Common
{
    public static class MyDateTime
    {
        private static readonly DateTime FixedNow =
            new DateTime(2025, 9, 18, 9, 19, 55, DateTimeKind.Local);

        public static DateTime Now => FixedNow;
    }
}