using System;
using KenoAssist.Web.Models;

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

			var start = date.ToString("dd");
            var end = date.ToString("MMMM yyyy");
            
			var suffix = GetSuffix(start);
			start = start.TrimStart('0');
			result = string.Format("{0}{1} {2}",start,suffix,end);

            return result;

        }

		public static string GetSuffix(string day){
			int _day = Convert.ToInt32(day);
			switch (_day)
            {
                case 1:
                case 21:
                case 31:
					return "st";
                case 2:
                case 22:
					return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
		}

        public static string RemoveSuffix(string date)
        {
            if(date.Contains("st")){
                return date.Replace("st","");   
            }
            if (date.Contains("rd"))
            {
                return date.Replace("rd", "");
            }
            if (date.Contains("nd"))
            {
                return date.Replace("nd", "");
            }
            if (date.Contains("th"))
            {
                return date.Replace("th", "");
            }
            return date;
        }

        public static string GetTimeString(DateTime date)
        {
            string result = string.Empty;

            result = date.ToString("t");

            return result;

        }

        public static FoodModel MapCheckBoxToFood(FoodCheckBoxModel model){

            var result = new FoodModel()
            {
                Id = model.Id,
                Name = model.Name,
                FoodTypeId = model.FoodTypeId,
                PercentageAmount = model.PercentageAmount
            };

            return result;

        }
    }
}
