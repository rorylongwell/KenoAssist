using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class ClientIncidentRepository : Repository<ClientIncident>, IClientIncidentRepository
    {
        public ClientIncidentRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }
    }
}
