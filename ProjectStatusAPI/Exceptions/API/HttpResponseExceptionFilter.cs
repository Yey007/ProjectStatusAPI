using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectStatusAPI.Exceptions.API
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new JsonResult(new
                {
                    Message = exception.Value
                })
                {
                    StatusCode = (int) exception.Status,
                };
                context.ExceptionHandled = true;
            }
        }
    }


}