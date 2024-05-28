using Microsoft.AspNetCore.Mvc;

namespace BubaEats.Api;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
