using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class ClientViewModel
    {
        public long Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Location { get; set; }
        public string PhotoUrl { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
