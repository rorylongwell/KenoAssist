using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Models
{
    public class FoodViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long FoodTypeId { get; set; }
    }
}
