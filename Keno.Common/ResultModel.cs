using System;
using System.Collections.Generic;
using System.Net;

namespace Keno.Common
{
    public class ResultModel<T>
    {       
        public T DataReturn { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }

        public ResultModel()
        { }

        public ResultModel(T data, string message = null)
        {
            Error = false;
            DataReturn = data;
            Message = message;      
        }
    }
}
