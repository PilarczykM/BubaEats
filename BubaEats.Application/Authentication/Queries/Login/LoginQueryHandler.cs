using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Application.Common.Interfaces.Persistent;
using BubaEats.Domain.Entities;
using BubaEats.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BubaEats.Application.Authentication.Common;

namespace BubaEats.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        // Validate if the user exists.
        if (_userRepository.GetUserByEmail(command.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Validate the password is correct
        if (user.Password != command.Password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // Create JWT token
        var token = await Task.Run(() => _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName));
        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Password,
            token);
    }
}
