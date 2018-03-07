using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keno.Business.Implementation;
using Keno.Common;
using Keno.Data;
using Microsoft.AspNetCore.Mvc;

namespace KenoAssist.API.Controllers
{
    

    [Route("api/[controller]")]
    public class UserController : KenoController
    {
        KenoService service = new KenoService();

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return CreateResponse<bool>(new ResultModel<bool>(true));
        }
        [HttpGet("GetStaffUsers")]
        public IActionResult GetStaffUsers()
        {
            var staff = service.GetUsersByUserTypeId((int)Constants.EUserType.Staff);
            return (staff != null && staff.Any()) ? CreateResponse(new ResultModel<List<UserViewModel>>(staff, "Success")) : DataNotFoundResponse("Get Data Failed");
        }

        [HttpGet("GetFamilyUsers")]
        public IActionResult GetFamilyUsers()
        {
            var familyMembers = service.GetUsersByUserTypeId((int)Constants.EUserType.Family);
            return (familyMembers != null && familyMembers.Any()) ? CreateResponse(new ResultModel<List<UserViewModel>>(familyMembers, "Success")) : DataNotFoundResponse("Get Data Failed");
        }
    }
}