using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientFoodViewModel
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long FoodId { get; set; }

        public virtual ClientViewModel Client { get; set; }
        public virtual FoodViewModel Food { get; set; }
    }
}
