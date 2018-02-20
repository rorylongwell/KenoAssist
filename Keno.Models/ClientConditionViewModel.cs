using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientConditionViewModel
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Description { get; set; }

        public virtual ClientViewModel Client { get; set; }
    }
}
