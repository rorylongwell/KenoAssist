using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class UserIncidentRepository : Repository<UserIncident>, IUserIncidentRepository
    {
        public UserIncidentRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
