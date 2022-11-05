using System;
using System.Net;

namespace Candidates.Models
{
    public class CoreResponseModel<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
