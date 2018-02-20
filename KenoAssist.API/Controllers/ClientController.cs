using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Keno.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.API.Controllers
{
    public class ClientController : KenoApiController
    {
        KenoService service = new KenoService();

        // GET: /<controller>/
        public IHttpActionResult GetAllClients()
        {
            var
            return View();
        }
    }
}
