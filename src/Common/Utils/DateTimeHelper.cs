using System;

namespace Common.Utils
{
    public class DateTimeHelper
    {
        public static int Date2Int(DateTime dt)
        {
            return dt.Year * 10000 + dt.Month * 100 + dt.Day;
        }

        public static int Time2Int(DateTime dt)
        {
            return dt.Hour * 10000 + dt.Minute * 100 + dt.Second;
        }

        public static int GetDateNowInt()
        {
            return Date2Int(DateTime.Now);
        }

        public static int GetTimeNowInt()
        {
            return Time2Int(DateTime.Now);
        }
    }
}