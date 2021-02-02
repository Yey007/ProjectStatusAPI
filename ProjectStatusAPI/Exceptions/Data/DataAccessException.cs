using System;

namespace ProjectStatusAPI.Exceptions.Data
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message)
        {
        }

        public DataAccessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}