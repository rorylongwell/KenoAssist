using System;
namespace KenoAssist.Web.Models
{
    public class ClientModel
    {
        public long Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Location { get; set; }
    }
}
