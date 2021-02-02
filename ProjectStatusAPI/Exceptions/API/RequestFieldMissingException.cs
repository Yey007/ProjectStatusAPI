using System.Net;

namespace ProjectStatusAPI.Exceptions.API
{
    public class RequestFieldMissingException : HttpResponseException
    {
        public RequestFieldMissingException(string missingFieldName)
        {
            Status = HttpStatusCode.BadRequest;
            Value = $"The following field is missing from the request body: {missingFieldName}";
        }
    }
}