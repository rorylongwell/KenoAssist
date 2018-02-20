using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class Drink
    {
        public long Id { get; set; }
        public long Name { get; set; }

        public virtual ICollection<ClientDrink> ClientDrinks { get; set; }
    }
}
