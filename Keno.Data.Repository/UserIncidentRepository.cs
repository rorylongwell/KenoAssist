using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keno.Data.Contracts
{
    public class UserIncidentRepository : Repository<UserIncident>, IUserIncidentRepository
    {
        public UserIncidentRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }

        public List<UserIncident> GetUserIncidentsByIncidentId(long incidentId)
        {
            return context.UserIncidents.Where(i => i.IncidentId == incidentId).ToList();
        }
    }
}
