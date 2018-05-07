using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string userType = HttpContext.Session.GetString("UserType");

            if(userType.Equals("staff")){
                return RedirectToAction("StaffAccount", "Account");
            }

            if (userType.Equals("family"))
            {
                return RedirectToAction("FamilyAccount", "Account");
            }

            return View();
        }

        public IActionResult FamilyAccount()
        {
            var notifications = new List<NotificationModel>(){

                new NotificationModel(){
                    Id = 1,
                    Description ="Incident & injury report involving you was created. It has been submitted for review bu management.",
                    Date = DateTime.Now,
                    NotificationTypeId = 1

                },
                new NotificationModel(){
                    Id = 2,
                    Description ="How is he doing today? My son isn't too well and was sent home from school. I was going to visit tomorrow instead of tonight.",
                    Date = DateTime.Now,
                    NotificationTypeId = 2
                }

            };


            return View(notifications);
        }

        public IActionResult StaffAccount()
        {
            var notifications = new List<NotificationModel>(){

                new NotificationModel(){
                    Id = 1,
                    Description ="Incident & injury report involving you was created. It has been submitted for review bu management.",
                    Date = DateTime.Now,
                    NotificationTypeId = 1

                },
                new NotificationModel(){
                    Id = 2,
                    Description ="How is he doing today? My son isn't too well and was sent home from school. I was going to visit tomorrow instead of tonight.",
                    Date = DateTime.Now,
                    NotificationTypeId = 2
                }

            };


            return View(notifications);
        }

        public IActionResult RedirectToIncident()
        {
            var client = new ClientModel()
            {
                Id = 1,
                Forename = "John",
                Surname = "Ellison",
                Location = "Room 12",
                ImageUrl = "~/images/profile_imgs/john_ellison.png"
            };

            //HttpContext.Session.SetString("Name", string.Format("{0} {1}", client.Forename, client.Surname));
            //HttpContext.Session.SetString("Room", client.Location);
            //HttpContext.Session.SetString("Photo", client.ImageUrl);

            return RedirectToAction("Incident", "Incident", new { incidentId = "1" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
