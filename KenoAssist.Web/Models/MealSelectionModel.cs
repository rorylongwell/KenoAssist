using System;
using System.Collections.Generic;

namespace KenoAssist.Web.Models
{
    public class MealSelectionModel
    {
		public List<FoodModel> Mains { get; set; }
		public List<FoodModel> Sides { get; set; }
		public long SelectedMain { get; set; }
		public long SelectedSide { get; set; }
    }
}
