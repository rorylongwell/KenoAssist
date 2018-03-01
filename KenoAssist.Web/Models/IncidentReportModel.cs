﻿using System;
using System.Collections.Generic;

namespace KenoAssist.Web.Models
{
    public class IncidentReportModel
    {
        public long IncidentId { get; set; }
        public string Injury { get; set; }
        public List<string> StaffNames { get; set; } 
        public List<string> PhotoUrl { get; set; } 
        public string Description { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    
    }
}
