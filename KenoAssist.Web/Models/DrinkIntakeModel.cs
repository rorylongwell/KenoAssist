using System;
using System.Collections.Generic;

namespace KenoAssist.Web.Models
{
    public class DrinkIntakeModel
    {
        public long ClientId { get; set; }
        public DateTime Date {get; set; }
        public List<DrinkModel> Drinks {get; set;}
        public Decimal TotalVolume { get; set; }
    }
}
