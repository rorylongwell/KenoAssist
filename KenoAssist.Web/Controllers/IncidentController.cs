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
        private List<KeyValuePair<int, string>> descriptions;

        // Constructor
        public IncidentController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;

            descriptions = new List<KeyValuePair<int, string>> {
                new KeyValuePair<int, string>(1,"Whilst {0} was trying to move the bed side table out of the way to stand up it fell over landing on {0}'s right foot. When {0} pushed the table it wasn't far enough out to allow enough space to safely pass safely resulting in it falling onto {0}'s foot. The swelling is rather bad and it was treated with an ice pack and is under supervision. {0} has complained of pain and was given Ibuprofen and is on bed rest to try and reduce pain and swelling. Apart from the pain {0} is in a good mood and the table has been moved to try and make it easier for {0} to get in and out of bed. We are working on getting a new, smaller table which is easier to move."),
                new KeyValuePair<int, string>(2,"{0} has got multiple bruises at the top of the right arm. They resemble hand markings and we are raising this with all members of staff. Currently no one has admitted that it was them who caused it, although with the medication {0} is prone to bruising easily. This is no excuse for this level of bruising. No complaint of pain, we have circulated that everyone must be more aware of the pressure that they are putting on clients skin. {0} has said that it may have happened whilst getting showered or dried after."),
                new KeyValuePair<int, string>(3,"{0} was walking down the corridor with aid of a walking stick, although lost balance and tripped. {0} was shaken after the event and was helped to the living area. Bruising has started to develop on the left leg. {0} has complained that it is sore to touch, although it is not causing any bother. We have checked to ensure that {0} has not hurt anywhere else, although this will need to be monitored for a few days. {0} has been nervous to walk about alone, which is understandable. We are ensuring that a member of the care team stays with {0} if walking."),
                new KeyValuePair<int, string>(4,"The right side of {0}'s chest is covered in numerous small cuts and scratches. We are not aware of where they have came from, although our current thought is that this happened from the velcro strap on a pillow on {0}'s bed. We have messaged the family to see about getting either a new pillow or getting the velcro covered again. For the meantime we have put a pillowcase over the pillow. {0} said that the cuts are not painful, and it is not bleeding or causing any pain."),
                new KeyValuePair<int, string>(5,"{0}'s right ear seems to be swelling very badly. This morning when wakening there was a complaint of itch on the right ear. It is swollen, red and irritated. The nurse came to view and it looks as if it is cut, although no one is sure how this occurred. {0} may have cut it whilst scratching as it was itchy. It has been cleaned with sterile water and cream for itch has being applied around the area. We have put a patch over it to prevent {0} scratching, although we are hoping to remove this in a few hours to see if the redness has went down any. If this persists in 24 hours we will request a doctor."),
                new KeyValuePair<int, string>(6,"{0} was being brought to the dining room in a wheelchair when Jane misjudged where she was pushing {0} which resulted in hitting a foot on the doorframe. Jane came and got myself to check the foot. {0} was in pain from the incident and we placed an ice pack on the injury throughout dinner to try and reduce bruising and swelling. {0} has been put on bed rest to reduce the injury."),
            };

            incidentReports = new List<IncidentReportModel>()
            {
                new IncidentReportModel()
                {
                    IncidentId = 1,
                    Injury = "Bruising",
                    InjuryArea = "top of right foot",
                    StaffNames = new List<string>() { "Emma Willis", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_6/injury6_photo1.jpg"},
                    Date = DateTime.Now,
                },
                new IncidentReportModel()
                {
                    IncidentId = 2,
                    Injury = "Bruising",
                    InjuryArea = "top of right arm",
                    StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_2/injury2_photo1.jpg" },
                    Date = DateTime.Now.AddDays(-1),
                },
                new IncidentReportModel()
                {
                IncidentId = 3,
                Injury = "Bruising",
                InjuryArea = "bottom left leg",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_3/injury3_photo1.jpg" },
                    Date = DateTime.Now.AddDays(-3),
                },
                new IncidentReportModel()
                {
                IncidentId = 4,
                Injury = "Cut",
                InjuryArea = "right side of chest",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_4/injury4_photo1.jpg" },
                    Date = DateTime.Now.AddDays(-4),
                },
                new IncidentReportModel()
                {
                IncidentId = 5,
                Injury = "Swelling",
                InjuryArea = "right ear",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_5/injury5_photo1.jpg"},
                    Date = DateTime.Now.AddDays(-4),
                },
                new IncidentReportModel()
                {
                IncidentId = 6,
                Injury = "Bruising",
                InjuryArea = "top right of foot",
                StaffNames = new List<string>() { "Joe Bloggs", "Jane Doe" },
                    PhotoUrl = new List<string>() { "~/images/injury_imgs/injury_1/injury1_photo1.jpg", "~/images/injury_imgs/injury_1/injury1_photo2.jpg" },
                    Date = DateTime.Now.AddDays(-6),
                },
            };
        }


        public IEnumerable<SelectListItem> staff = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Select Staff", Value = "Select Staff" },
            new SelectListItem { Text = "You- Emma Willis", Value = "Emma Willis" },
            new SelectListItem { Text = "Cara White", Value = "Cara White" },
            new SelectListItem { Text = "Carissa Ferguson", Value = "Carissa Ferguson" },
            new SelectListItem { Text = "David Wright", Value = "David Wright" },
            new SelectListItem { Text = "Gemma Stewart", Value = "Gemma Stewart" },
            new SelectListItem { Text = "Hannah Lynn", Value = "Hannah Lynn" },
            new SelectListItem { Text = "John Brown", Value = "John Brown" },
            new SelectListItem { Text = "Kimberly Stephens", Value = "Kimberly Stephens" },
            new SelectListItem { Text = "Laura Brown", Value = "Laura Brown" },
            new SelectListItem { Text = "Matthew Richards", Value = "Matthew Richards" },
            new SelectListItem { Text = "Nathan Boyd", Value = "Nathan Boyd" },
            new SelectListItem { Text = "Paige Allen", Value = "Paige Allen" },
            new SelectListItem { Text = "Rachael Large", Value = "Rachael Large" },
            new SelectListItem { Text = "Samantha Blair", Value = "Samantha Blair" },
            new SelectListItem { Text = "Sammy Ferguson", Value = "Sammy Ferguson" },
            new SelectListItem { Text = "Tammy McKenna", Value = "Tammy McKenna" },
            new SelectListItem { Text = "Victoria Ward", Value = "Victoria Ward" },
        };

        // GET: /<controller>/
        public IActionResult Incidents()
        {
            ViewBag.ProfileImage = HttpContext.Session.GetString("Photo");
            ViewBag.Name = string.Format("{0}, {1}",HttpContext.Session.GetString("Name"), HttpContext.Session.GetString("Room"));
            var name = HttpContext.Session.GetString("Name");
            var firstName = name.Substring(0, name.IndexOf(" "));

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

            foreach(var incident in incidentReports)
            {
                var description = descriptions.Where(m =>m.Key == incident.IncidentId).FirstOrDefault();
                incident.Description = string.Format(description.Value,firstName);
            }

            return View(incidentReports);
        }

        public IActionResult Incident(long incidentId)
        {
            ViewBag.IsForm = false;
            IncidentReportModel incidentReport = incidentReports.Where(i => i.IncidentId == incidentId).FirstOrDefault();
            var name = HttpContext.Session.GetString("Name");
            var firstName = name.Substring(0, name.IndexOf(" "));

            var user= HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

            var description = descriptions.Where(m => m.Key == incidentReport.IncidentId).FirstOrDefault();
            incidentReport.Description = string.Format(description.Value, firstName);
     
            return View(incidentReport);
        }

        public IActionResult AddIncident()
        {
            ViewBag.StaffList = staff;

            IncidentReportModel incidentReport = new IncidentReportModel()
            {
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
					ViewBag.PhotoSelected = false;
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
            
			ViewBag.PhotoSelected = false;
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

					ViewBag.PhotoSelected = true;
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

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

            if (!ModelState.IsValid)
                return View(incidentReport);

            ViewBag.IsForm = isForm;
            incidentReport.Date = incidentReport.Date + incidentReport.Time;
            return View("Incident", incidentReport);
        }
    }
}
