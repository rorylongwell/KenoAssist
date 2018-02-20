using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientIncident
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long IncidentId { get; set; }


        public virtual Client Client { get; set; }
        public virtual Incident Incident { get; set; }
    }
}
