using Microsoft.AspNetCore.Mvc;

namespace ProjectStatusAPI.API.Error
{
    [ApiController]
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}