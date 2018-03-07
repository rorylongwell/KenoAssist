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
    public class MessageController : KenoController
    {
        KenoService service = new KenoService();

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetInbox")]
        public IActionResult GetInbox(long userId)
        {
            var messages = service.GetRecievedMessagesByUserId((int)Constants.EUserType.Staff);
            return (messages != null && messages.Any()) ? CreateResponse(new ResultModel<List<Message>>(messages, "Success")) : DataNotFoundResponse("Get Data Failed");
        }
        [HttpGet("GetSentItems")]
        public IActionResult GetSentItems(long userId)
        {
            var messages = service.GetSentMessagesByUserId((int)Constants.EUserType.Staff);
            return (messages != null && messages.Any()) ? CreateResponse(new ResultModel<List<Message>>(messages, "Success")) : DataNotFoundResponse("Get Data Failed");
        }
        [HttpPost("SendMessage")]
        public IActionResult SendMessage(Message message)
        {
            var sentMessage = service.SendMessage(message);
            return (sentMessage != null) ? CreateResponse(new ResultModel<long>(sentMessage.Id, "Success")) : DataNotFoundResponse("Get Data Failed");
        }
    }
}