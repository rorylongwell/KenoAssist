using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientInformation
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Client Client { get; set; }
    }
}
