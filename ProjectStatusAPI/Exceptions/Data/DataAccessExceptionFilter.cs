using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectStatusAPI.Exceptions.API;

namespace ProjectStatusAPI.Exceptions.Data
{
    public class DataAccessExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 9;

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ResourceNotFoundException resourceNotFoundException)
            {
                throw new HttpResponseException
                {
                    Status = HttpStatusCode.NotFound,
                    Value = resourceNotFoundException.Message
                };
            }
            if (context.Exception is DataAccessException dataAccessException)
            {
                throw new HttpResponseException
                {
                    Value = dataAccessException.Message
                };
            }
        }
    }
}