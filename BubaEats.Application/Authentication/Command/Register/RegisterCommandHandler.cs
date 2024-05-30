using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Application.Common.Interfaces.Persistent;
using BubaEats.Domain.Entities;
using BubaEats.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BubaEats.Application.Authentication.Common;

namespace BubaEats.Application.Authentication.Command.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // Create user (generate unique ID) & persist in DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        _userRepository.Add(user);

        // Create JWT Token
        var token = await Task.Run(() => _jwtTokenGenerator.GenerateToken(user.Id, command.FirstName, command.LastName));

        return new AuthenticationResult(
            user.Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            token);
    }
}
