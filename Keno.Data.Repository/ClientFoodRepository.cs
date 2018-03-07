﻿using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class ClientFoodRepository : Repository<ClientFood>, IClientFoodRepository
    {
        public ClientFoodRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
