using System;
using System.Collections.Generic;
using Keno.Models;

namespace KenoAssist.Web.Models
{
    public class FoodIntakeModel
    {
        public long ClientId { get; set; }
        public DateTime Date {get; set;}
        public List<FoodModel> Breakfast{get; set;}
        public List<FoodModel> Lunch { get; set; }
        public List<FoodModel> Dinner { get; set; }
        public List<FoodModel> Snacks { get; set; }
    }
}
