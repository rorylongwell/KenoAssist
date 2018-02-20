using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class DrinkViewModel
    {
        public long Id { get; set; }
        public long Name { get; set; }

        public virtual ICollection<ClientDrinkViewModel> ClientDrinks { get; set; }
    }
}
