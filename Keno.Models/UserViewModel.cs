using System;
using System.Collections.Generic;

namespace Keno.Data
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public long UserTypeId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
