using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class ClientConditionRepository : Repository<ClientCondition>, IClientConditionRepository
    {
        public ClientConditionRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }
    }
}
