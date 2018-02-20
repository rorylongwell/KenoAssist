using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class Food
    {
        public long Id { get; set; }
        public long Name { get; set; }

        public virtual ICollection<ClientFood> ClientFoods { get; set; }
    }
}
