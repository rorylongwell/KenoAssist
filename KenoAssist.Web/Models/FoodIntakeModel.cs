using System;
using System.Collections.Generic;
using Keno.Models;

namespace KenoAssist.Web.Models
{
    public class FoodIntakeModel
    {
        public long ClientId { get; set; }
        public DateTime Date {get; set;}
        public List<FoodViewModel> Breakfast{get; set;}
        public List<FoodViewModel> Lunch { get; set; }
        public List<FoodViewModel> Dinner { get; set; }
        public List<FoodViewModel> Snacks { get; set; }
    }
}
