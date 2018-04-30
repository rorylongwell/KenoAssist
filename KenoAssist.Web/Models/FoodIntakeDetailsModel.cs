using System;
namespace KenoAssist.Web.Models
{
    public class FoodIntakeDetailsModel
    {
        public int MealId { get; set; }
        public FoodModel Main { get; set; }
        public FoodModel Side { get; set; }
        public string Summary { get; set; }
    }
}
