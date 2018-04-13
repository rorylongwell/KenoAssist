using System;
namespace KenoAssist.Web.Helper
{
    public static class Common
    {
        public static string GetDayName(DateTime date)
        {
            string result = string.Empty;

            if (date.Date == DateTime.Today)
            {
                return "Today";
            }
            if (date.Date == DateTime.Today.AddDays(1))
            {
                return "Tomorrow";
            }
            if (date.Date == DateTime.Today.AddDays(-1))
            {
                return "Yesterday";
            }

            result = date.ToString("d");

            return result;

        }

        public static string GetTimeString(DateTime date)
        {
            string result = string.Empty;

            result = date.ToString("t");

            return result;

        }
    }
}
