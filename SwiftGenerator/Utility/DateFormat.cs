using System;

namespace SwiftGenerator.Utility
{
    internal class DateFormat
    {
        public string GetToday()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string GetNewDateFormat(string date, string datePattern)
        {
            return DateTime.Parse(date).ToString(datePattern);
        }
    }
}