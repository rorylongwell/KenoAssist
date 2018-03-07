using Keno.Data.Contracts;
using System;

namespace Keno.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
