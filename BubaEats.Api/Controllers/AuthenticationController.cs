using BubaEats.Application.Services.Authentication;
using BubaEats.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BubaEats.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(request.Email, request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Password,
            authResult.Token);
    }
}