using System;

namespace ProjectStatusAPI.Exceptions.Data
{
    public class ResourceNotFoundException : DataAccessException
    {
        public ResourceNotFoundException(string resourceDescription) :
            base(FormatError(resourceDescription))
        {
        }

        public ResourceNotFoundException(string resourceDescription, Exception inner) :
            base(FormatError(resourceDescription), inner)
        {
        }

        private static string FormatError(string error)
        {
            return $"The resource with the following description could not be found: {error}";
        }
    }
}