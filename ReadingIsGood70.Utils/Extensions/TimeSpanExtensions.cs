using System;

namespace ReadingIsGood70.Utils.Extensions
{
    public static class TimeSpanExtensions
    {
        public static DateTime ToDateTimeFromUtcNow(this TimeSpan timeSpan)
        {
            return DateTime.UtcNow.AddTicks(timeSpan.Ticks);
        }
    }
}