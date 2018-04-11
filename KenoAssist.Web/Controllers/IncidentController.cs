using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IHostingEnvironment _environment;

        // Constructor
        public IncidentController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
        }


        public IEnumerable<SelectListItem> staff = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Select Staff", Value = "0" },
            new SelectListItem { Text = "Joe Bloggs", Value = "1" },
            new SelectListItem { Text = "Jane Doe", Value = "2" },
        };

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
            ViewBag.StaffList = staff;

            IncidentReportModel incidentReport = new IncidentReportModel()
            {
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay,
                StaffNames = new List<string>() { "" }
            };
            return View(incidentReport);
        }

        [HttpPost]
        public IActionResult AddIncident(IncidentReportModel incidentReport,string submitButton)
        {
            ViewBag.StaffList = staff;

            if(incidentReport.StaffNames.Count < 1){
                ModelState.AddModelError("StaffNames","Select staff member");
            }
            else if(incidentReport.StaffNames.Contains("0")){
                ModelState.AddModelError("StaffNames", "Select staff member");
            }

            if (incidentReport.Date == new DateTime())
            {
                ModelState.AddModelError("DateOfIncident", "Select date");
            }

            if (incidentReport.Time == new TimeSpan())
            {
                ModelState.AddModelError("TimeOfIncident", "Select time");
            }

            switch (submitButton)
            {
                case "Add Staff":                    
                    incidentReport.StaffNames.Add("");
                    return View(incidentReport);
                case "Next":
                    if (!ModelState.IsValid)
                        return View(incidentReport);

                    ViewBag.UploadEnabled = false;
                    return View("AddInjury",incidentReport);
                default:
                    return View();
            }
        }

        [HttpPost]
        public IActionResult AddInjury(IncidentReportModel incidentReport, string submitButton)
        {
            if (string.IsNullOrEmpty(incidentReport.Injury))
            {
                ModelState.AddModelError("Date", "Enter injury");
            }

            if (string.IsNullOrEmpty(incidentReport.InjuryArea))
            {
                ModelState.AddModelError("Time", "Enter injury areas");
            }


            switch (submitButton)
            {
                case "Upload":
                    var files = HttpContext.Request.Form.Files;

                    if(incidentReport.PhotoUrl == null){
                        incidentReport.PhotoUrl = new List<string>();
                    }

                    foreach(var file in files)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var path = Path.Combine(_environment.WebRootPath,"images/incident_images", fileName);

                        using (FileStream fs = System.IO.File.Create(path))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        incidentReport.PhotoUrl.Add(Path.Combine("~/images/incident_images", fileName));
                    }


                    return View(incidentReport);
                case "Next":
                    if (!ModelState.IsValid)
                        return View(incidentReport);

                    ViewBag.Images = incidentReport.PhotoUrl.Count;
                    ViewBag.UploadEnabled = incidentReport.PhotoUrl.Count > 0;
                    return View("IncidentReport", incidentReport);
                default:
                    return View();
            }
        }

        [HttpPost]
        public IActionResult IncidentReport(IncidentReportModel incidentReport)
        {
            incidentReport.Date = incidentReport.Date + incidentReport.Time;
            return View("Incident", incidentReport);
        }

    }
}
