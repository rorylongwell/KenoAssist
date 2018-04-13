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
    public class ClientController : Controller
    {
        // GET: /<controller>/
        public IActionResult Client(long id)
        {
            var clients = new List<ClientModel>(){
                new ClientModel(){
                    Id = 1,
                    Forename = "John",
                    Surname = "Ellison",
                    Location = "Room 12",
                    ImageUrl = "~/images/profile_imgs/john_ellison.png"
                },
                new ClientModel(){
                    Id = 2,
                    Forename = "Adam",
                    Surname = "Brown",
                    Location = "Room 8",
                    ImageUrl = "~/images/profile_imgs/adam_brown.png"
                },
                new ClientModel(){
                    Id = 3,
                    Forename = "Anna",
                    Surname = "Lynn",
                    Location = "Room 5",
                    ImageUrl = "~/images/profile_imgs/anna_lynn.png"
                },
                new ClientModel(){
                    Id = 4,
                    Forename = "Carrie",
                    Surname = "Smith",
                    Location = "Room 1",
                    ImageUrl = "~/images/profile_imgs/carrie_smith.png"
                },
                new ClientModel(){
                    Id = 5,
                    Forename = "Mark",
                    Surname = "Boyd",
                    Location = "Room 10",
                    ImageUrl = "~/images/profile_imgs/mark_boyd.png"
                },
                new ClientModel(){
                    Id = 6,
                    Forename = "Mary",
                    Surname = "Louise",
                    Location = "Room 2",
                    ImageUrl = "~/images/profile_imgs/mary_louise.png"
                },
                new ClientModel(){
                    Id = 7,
                    Forename = "Norman",
                    Surname = "McCormack",
                    Location = "Room 4",
                    ImageUrl = "~/images/profile_imgs/norman_mccormack.png"
                },

            };

            var client = clients.Where(c => c.Id == id).FirstOrDefault();

            if (client != null)
            {
                HttpContext.Session.SetString("Name", string.Format("{0} {1}", client.Forename, client.Surname));
                HttpContext.Session.SetString("Room", client.Location);
                HttpContext.Session.SetString("Photo", client.ImageUrl);
            }

            var user =  HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff=(user == "staff");
         
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Room = HttpContext.Session.GetString("Room");
            ViewBag.Photo = HttpContext.Session.GetString("Photo");

            return View();
        }
    }
}
