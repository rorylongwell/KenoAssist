using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace KenoAssist.Web.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FoodModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long FoodTypeId { get; set; }
        public decimal PercentageAmount { get; set; }
    }
}
