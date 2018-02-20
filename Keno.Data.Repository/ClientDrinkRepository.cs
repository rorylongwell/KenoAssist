using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class ClientDrinkRepository : Repository<ClientDrink>, IClientDrinkRepository
    {
        public ClientDrinkRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }
    }
}
