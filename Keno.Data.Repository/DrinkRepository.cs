using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class DrinkRepository : Repository<Drink>, IDrinkRepository
    {
        public DrinkRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
