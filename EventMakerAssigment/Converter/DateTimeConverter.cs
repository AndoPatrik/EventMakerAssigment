using System;

namespace EventMakerAssigment.Converter
{
     public class DateTimeConverter
    {
        #region Constructor(s)

        public DateTimeConverter()
        {
            
        }

        #endregion

        #region Method(s)

        public static DateTime DateTimeOffsetAndDateTimeSetToDateTime(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year,date.Month,date.Day,time.Hours,time.Minutes,time.Seconds);
        }

        #endregion
    }
}
