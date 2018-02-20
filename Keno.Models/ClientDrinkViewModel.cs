using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientDrinkViewModel
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long DrinkId { get; set; }
        public long Volume { get; set; }
    }
}
