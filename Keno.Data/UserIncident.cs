using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class UserIncident
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long IncidentId { get; set; }

        public virtual User User { get; set; }
        public virtual Incident Incident { get; set; }
    }
}
