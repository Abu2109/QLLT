using System;

namespace QLLT.Utils
{
    public static class DateHelper
    {
        public static DateTime StartOfDay(this DateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        public static DateTime EndOfDay(this DateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);

        /// <summary>Ghép ngày từ DateTimePicker + giờ phút từ masked textbox "HH:mm".</summary>
        public static DateTime MergeDateTime(DateTime date, string hhmm)
        {
            if (string.IsNullOrWhiteSpace(hhmm)) hhmm = "00:00";
            var parts = hhmm.Split(':');
            int h = 0, m = 0;
            int.TryParse(parts[0], out h);
            if (parts.Length > 1) int.TryParse(parts[1], out m);
            return new DateTime(date.Year, date.Month, date.Day, h, m, 0);
        }
    }
}
