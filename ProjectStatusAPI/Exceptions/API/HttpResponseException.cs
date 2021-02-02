using System;
using System.Net;

namespace ProjectStatusAPI.Exceptions.API
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;

        public object Value { get; set; }
    }
}