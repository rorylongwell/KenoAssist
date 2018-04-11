using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KenoAssist.Web.Models
{
    public class IncidentReportModel
    {
        public long IncidentId { get; set; }
        public string Injury { get; set; }
        public string InjuryArea { get; set; }
        public List<string> StaffNames { get; set; } 
        public List<string> PhotoUrl { get; set; } 
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
