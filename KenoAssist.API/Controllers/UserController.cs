using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keno.Common;
using Microsoft.AspNetCore.Mvc;

namespace KenoAssist.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : KenoController
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return CreateResponse<bool>(new ResultModel<bool>(true));
        }
    }
}