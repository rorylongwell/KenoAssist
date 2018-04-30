using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace KenoAssist.Web.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FoodSelectionModel
    {
        public List<FoodModel> Food { get; set; }
        public long SelectedFood { get; set; }
    }

}
