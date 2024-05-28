using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubaEats.Api;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

        if (exceptionHandlerFeature != null)
        {
            var exception = exceptionHandlerFeature.Error;
            return Problem(title: exception.Message, statusCode: 400);
        }

        return Problem(title: "An unknown error occurred.", statusCode: 400);
    }
}
