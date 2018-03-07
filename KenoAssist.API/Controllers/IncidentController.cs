using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keno.Business.Implementation;
using Keno.Common;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KenoAssist.API.Controllers
{
    [Route("api/[controller]")]
    public class IncidentController : KenoController
    {
        KenoService service = new KenoService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetIncidentReportById")]
        public IActionResult GetIncidentReportById(long incidentId)
        {
            var incidentReport = new IncidentReportModel();

            var incident = service.GetIncidentById(incidentId);
            var staff = service.GetUsersByIncidentId(incidentId);
            var staffNames = new List<string>();
            var photos = service.GetIncidentPhotosByIncidentId(incidentId);
            var photoUrls = new List<string>();

            foreach (var item in staff)
            {
                staffNames.Add(item.Forename +" "+ item.Surname);
            }

            foreach (var item in photos)
            {
                photoUrls.Add(item.Url);
            }

            incidentReport.IncidentId = incidentId;
            incidentReport.Injury = incident.Injury;
            incidentReport.PhotoUrl = photoUrls;
            incidentReport.Description = incident.Description;
            incidentReport.StaffNames = staffNames;
            //incidentReport.Date = incident.Date;

            return (incidentReport != null) ? CreateResponse(new ResultModel<IncidentReportModel>(incidentReport, "Success")) : DataNotFoundResponse("Get Data Failed");
        }
    }
}