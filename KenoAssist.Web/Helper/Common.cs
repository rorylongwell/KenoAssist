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

            result = date.ToString("d");

            return result;

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
