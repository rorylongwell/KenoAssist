using Core.API.Common;
using System.Collections.Generic;
using System.Net;

namespace Keno.Consumer
{
    public class ResponseModel<T> : ResultModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }
    }
}
