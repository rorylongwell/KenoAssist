using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public interface IUserIncidentRepository : IRepository<UserIncident>
    {
        List<UserIncident> GetUserIncidentsByIncidentId(long incidentId);
    }
}
