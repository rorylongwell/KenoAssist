using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KenoAssist.Web.Controllers
{
    public class LoginController : Controller
    {
        [ActionName("Index")]
        public IActionResult Index()
        {
            return View();
        }


        [ActionName("Login")]
        public IActionResult Login(UserLoginViewModel model)
        {

            if(model.Username.ToLower().Equals("staff")){
                HttpContext.Session.SetString("UserType", "staff");
                return RedirectToAction("Clients","Staff");
            }

            if (model.Username.ToLower().Equals("family"))
            {
                HttpContext.Session.SetString("UserType", "family");
                return RedirectToAction("Client", "Client");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}