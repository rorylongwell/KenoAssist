using System;
namespace KenoAssist.Web.Models
{
    public class FoodIntakeDetailsModel
    {
        public FoodModel Main { get; set; }
        public FoodModel Side { get; set; }
        public string Summary { get; set; }
    }
}
