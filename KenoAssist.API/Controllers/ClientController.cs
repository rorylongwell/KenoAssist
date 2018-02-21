using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keno.Business.Implementation;
using Keno.Common;
using Keno.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : KenoController
    {
        KenoService service = new KenoService();

        [HttpGet("GetAllClients")]
        public IActionResult GetAllClients()
        {
            var clients = service.GetAllClients();
            return (clients != null && clients.Any()) ? CreateResponse(new ResultModel<List<ClientViewModel>>(clients, "Success")) : DataNotFoundResponse("Get Data Failed");
        }
    }
}
