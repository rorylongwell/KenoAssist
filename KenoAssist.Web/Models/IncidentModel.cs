﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KenoAssist.Web.Models
{
    public class IncidentModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
