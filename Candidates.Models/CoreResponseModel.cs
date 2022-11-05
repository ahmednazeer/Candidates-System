using System;
using System.Net;

namespace Candidates.Models
{
    public class CoreResponseModel<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public CoreResponseModel(T returnObject, HttpStatusCode status)
        {
            Data = returnObject;
            StatusCode = status;
        }
        public CoreResponseModel(T returnObject, HttpStatusCode status, bool success)
        {
            Data = returnObject;
            StatusCode = status;
            Success = success;
        }

        public CoreResponseModel(T returnObject, HttpStatusCode status, string exceptionText)
            : this(returnObject, status)
        {
            Message = exceptionText;
        }

    }
}
