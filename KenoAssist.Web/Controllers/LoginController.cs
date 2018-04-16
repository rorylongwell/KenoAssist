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
        private const string PASSWORD = "KenoCares";

        [ActionName("Index")]
        public IActionResult Index(bool invalidLogin = false)
        {
            ViewBag.InvalidLogin = invalidLogin;
            return View();
        }


        [ActionName("Login")]
        public IActionResult Login(UserLoginViewModel model)
        {
            if(model.Password != PASSWORD){
                return RedirectToAction("Index", "Login", new { invalidLogin = true });
            }

            if (model.Username != null)
            {
                if (model.Username.ToLower().Equals("staff"))
                {
                    HttpContext.Session.SetString("UserType", "staff");
                    return RedirectToAction("Clients", "Staff");
                }

                if (model.Username.ToLower().Equals("family"))
                {
                    HttpContext.Session.SetString("UserType", "family");
                    return RedirectToAction("Client", "Client");
                }
            }

            return RedirectToAction("Index", "Login", new { invalidLogin = true });
        }
    }
}