using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class Incident
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Injury { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<UserIncident> UserIncident { get; set; }
        //public virtual ICollection<ClientIncident> ClientIncident { get; set; }
        public virtual ICollection<IncidentPhoto> IncidentPhoto { get; set; }
    }
}
