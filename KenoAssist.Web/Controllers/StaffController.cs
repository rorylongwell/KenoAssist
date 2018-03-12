using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Clients()
        {
            var clients = new List<ClientModel>(){
                new ClientModel(){
                    Id = 1,
                    Forename = "John",
                    Surname = "Ellison",
                    Location = "Room 41",
                    ImageUrl = "../images/account_imgs/male_1.png"
                },
                new ClientModel(){
                    Id = 2,
                    Forename = "Bert",
                    Surname = "Macklin",
                    Location = "Room 38",
                    ImageUrl = "../images/account_imgs/male_1.png"
                },
                new ClientModel(){
                    Id = 3,
                    Forename = "Kip",
                    Surname = "Hackman",
                    Location = "Room 34",
                    ImageUrl = "../images/account_imgs/male_1.png"
                },
                new ClientModel(){
                    Id = 4,
                    Forename = "Andrew",
                    Surname = "Dwyer",
                    Location = "Room 43",
                    ImageUrl = "../images/account_imgs/male_1.png"
                }
            };

            return View(clients);
        }

        public IActionResult StaffAccount(){
            return View();
        }
    }
}
