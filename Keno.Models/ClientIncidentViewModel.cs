using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Models
{
    public class ClientIncidentViewModel
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long IncidentId { get; set; }
    }
}
