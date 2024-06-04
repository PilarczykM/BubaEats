using BubaEats.Application.Authentication.Command.Register;
using BubaEats.Application.Authentication.Queries.Login;
using BubaEats.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BubaEats.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        // var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // var query = new LoginQuery(request.Email, request.Password);
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}