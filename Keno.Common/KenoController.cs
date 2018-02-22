using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Keno.Common
{
    public class KenoController : Controller
    {
        public IActionResult CreateResponse<T>(ResultModel<T> model)
        {
            return Ok(model);
        }

        public IActionResult DataNotFoundResponse(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };

            return NotFound(result);
        }

    }
}
