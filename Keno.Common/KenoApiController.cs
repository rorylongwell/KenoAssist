using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.ModelBinding;

namespace Keno.Common
{
    public class KenoApiController: ApiController
    {
        protected IHttpActionResult InvalidRequest()
        {
            var result = new ResultModel<string>();
            result.Message = string.Join(", ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            result.Error = true;
            return new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.BadRequest, result));
        }

        protected IHttpActionResult InvalidRequest(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.BadRequest, result);
        }

        protected IHttpActionResult CreateResponse<T>(HttpStatusCode statusCode, ResultModel<T> result)
        {
            return new ResponseMessageResult(Request.CreateResponse(statusCode, result));
        }

        protected IHttpActionResult CreateResponse<T>( ResultModel<T> result)
        {
            return new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.OK, result));
        }

        protected IHttpActionResult DataNotFoundResponse(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message, 
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.NotFound ,result);
        }

        protected IHttpActionResult DataConflictResponse(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.Conflict, result);
        }

        protected IHttpActionResult ResourceUnavailable(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.Gone, result);
        }

        protected IHttpActionResult UnsupportMediaTypeWarning(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.UnsupportedMediaType, result);
        }
        protected IHttpActionResult ResourceAlreadyExits(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.Conflict, result);
        }
        

        protected IHttpActionResult BadRequestResponse(string message)
        {
            var result = new ResultModel<object>()
            {
                Error = true,
                Message = message,
                DataReturn = null
            };
            return CreateResponse(HttpStatusCode.BadRequest, result);
        }

        protected IHttpActionResult InternalServerErrorResponse(Exception ex)
        {
            ResultModel<Exception> result = new ResultModel<Exception>()
            {
                Error = true,
                Message = ex.Message,
                DataReturn = ex
            };
            return CreateResponse(HttpStatusCode.InternalServerError, result);
        }
    }
}
