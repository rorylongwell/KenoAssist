using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }

        public IActionResult StaffAccount()
        {
            return View();
        }
    }
}
