using BubaEats.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BubaEats.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
