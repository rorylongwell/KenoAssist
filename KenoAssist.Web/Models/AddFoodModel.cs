using System;
using System.Collections.Generic;

namespace KenoAssist.Web.Models
{
    public class AddFoodModel
    {
        public long ClientId { get; set; }
        public DateTime Date { get; set; }
        public List<FoodModel> Food { get; set; } 
    }
}
