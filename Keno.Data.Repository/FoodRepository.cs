using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class FoodRepository : Repository<Food>,IFoodRepository
    {
        public FoodRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }
    }
}
