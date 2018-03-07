using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class ClientInformationRepository : Repository<ClientInformation>, IClientInformationRepository
    {
        public ClientInformationRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
