using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class IncidentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Incidents()
        {
            List<IncidentModel> incidents = new List<IncidentModel>() 
            { 
                new IncidentModel()
                {
                    Id = 1,
                    Description = "John fell",
                    Date = DateTime.Now
                },

                new IncidentModel()
                {
                    Id = 2,
                    Description = "John cut himself",
                    Date = DateTime.Now
                },

                new IncidentModel()
                {
                    Id = 3,
                    Description = "John wasn't feeling well",
                    Date = DateTime.Now

                },

            };

            return View(incidents);
        }

        public IActionResult Incident(long incidentId)
        {
            //    public long IncidentId { get; set; }
            //public string Injury { get; set; }
            //public List<string> StaffNames { get; set; }
            //public List<string> PhotoUrl { get; set; }
            //public string Description { get; set; }
            //public string Date { get; set; }
            //public string Time { get; set; }

            IncidentReportModel incidentReport = new IncidentReportModel()
            {
                IncidentId = 1,
                Injury = "Bruised leg",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                PhotoUrl = new List<string>() { "~/images/louis1.jpg", "~/images/louis2.jpg", "~/images/louis3.jpg" },
                Description = "This was an accident",
                Date = DateTime.Now,                  
            };

            return View(incidentReport);
        }

        public IActionResult AddIncident()
        {
            IncidentReportModel incidentReport = new IncidentReportModel()
            {
                IncidentId = 0,
                StaffNames = new List<string>()
            };
            return View(incidentReport);
        }

        [HttpPost]
        public IActionResult AddIncident(IncidentReportModel incidentReport,string submitButton)
        {
            switch (submitButton)
            {
                case "AddStaff":
                    
                    return View(incidentReport);
                case "Next":
                    
                    return View();
                default:
           
                    return View();
            }
        }
    }
}
