using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private List<IncidentReportModel> incidentReports; 

        // Constructor
        public IncidentController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;

            incidentReports = new List<IncidentReportModel>()
            {
                new IncidentReportModel()
                {
                IncidentId = 1,
                Injury = "Bruising",
                InjuryArea = "top of right foot",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_6/injury6_photo1.jpg"},
                Description = "This was an accident",
                Date = DateTime.Now,
                },
                new IncidentReportModel()
                {
                IncidentId = 2,
                Injury = "Bruising",
                InjuryArea = "top of right arm",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_2/injury2_photo1.jpg" },
                Description = "This was an accident",
                    Date = DateTime.Now.AddDays(-1),
                },
                new IncidentReportModel()
                {
                IncidentId = 3,
                Injury = "Bruising",
                InjuryArea = "bottom left leg",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_3/injury3_photo1.jpg" },
                Description = "This was an accident",
                    Date = DateTime.Now.AddDays(-3),
                },
                new IncidentReportModel()
                {
                IncidentId = 4,
                Injury = "Cut",
                InjuryArea = "right side of chest",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_4/injury4_photo1.jpg" },
                Description = "This was an accident",
                    Date = DateTime.Now.AddDays(-4),
                },
                new IncidentReportModel()
                {
                IncidentId = 5,
                Injury = "Swelling",
                InjuryArea = "right ear",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_5/injury5_photo1.jpg"},
                Description = "This was an accident",
                    Date = DateTime.Now.AddDays(-4),
                },
                new IncidentReportModel()
                {
                IncidentId = 6,
                Injury = "Bruising",
                InjuryArea = "top right of foot",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_1/injury1_photo1.jpg", "~/images/injury_imgs/injury_1/injury1_photo2.jpg" },
                Description = "This was an accident",
                    Date = DateTime.Now.AddDays(-6),
                },
            };
        }


        public IEnumerable<SelectListItem> staff = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Select Staff", Value = "Select Staff" },
            new SelectListItem { Text = "Joe Bloggs", Value = "Joe Bloggs" },
            new SelectListItem { Text = "Jane Doe", Value = "Jane Doe" },
        };

        // GET: /<controller>/
        public IActionResult Incidents()
        {
            ViewBag.ProfileImage = HttpContext.Session.GetString("Photo");
            ViewBag.Name = string.Format("{0}, {1}",HttpContext.Session.GetString("Name"), HttpContext.Session.GetString("Room"));


            return View(incidentReports);
        }

        public IActionResult Incident(long incidentId)
        {
            ViewBag.IsForm = false;
            IncidentReportModel incidentReport = incidentReports.Where(i => i.IncidentId == incidentId).FirstOrDefault();
            return View(incidentReport);
        }

        public IActionResult AddIncident()
        {
            ViewBag.StaffList = staff;

            IncidentReportModel incidentReport = new IncidentReportModel()
            {
                //Date = DateTime.Now.Date,
                //Time = DateTime.Now.TimeOfDay,
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

            if (incidentReport.Date == null)
            {
                ModelState.AddModelError("Date", "Select date");
            }

            if (incidentReport.Time == null)
            {
                ModelState.AddModelError("Time", "Select time");
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
                ModelState.AddModelError("Injury", "Enter injury");
            }

            if (string.IsNullOrEmpty(incidentReport.InjuryArea))
            {
                ModelState.AddModelError("InjuryArea", "Enter injury areas");
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

                    if(incidentReport.PhotoUrl != null){
                        ViewBag.Images = incidentReport.PhotoUrl.Count;
                        ViewBag.UploadEnabled = incidentReport.PhotoUrl.Count > 0;
                    }
                    else
                    {
                        ViewBag.Images = 0;
                        ViewBag.UploadEnabled = false;
                    }

                    return View("IncidentReport", incidentReport);
                default:
                    return View();
            }
        }

        [HttpPost]
        public IActionResult IncidentReport(IncidentReportModel incidentReport, bool isForm = false)
        {
            if (string.IsNullOrEmpty(incidentReport.Description))
            {
                ModelState.AddModelError("Description", "Enter a report");
            }

            if (!ModelState.IsValid)
                return View(incidentReport);

            ViewBag.IsForm = isForm;
            incidentReport.Date = incidentReport.Date + incidentReport.Time;
            return View("Incident", incidentReport);
        }
    }
}
