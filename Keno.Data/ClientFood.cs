using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientFood
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long FoodId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Food Food { get; set; }
    }
}
