using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Application.Common.Interfaces.Persistent;
using BubaEats.Domain.Entities;

namespace BubaEats.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate if the user exists.
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with the given email does not exists.");
        }

        // Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }
        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Password,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with the given email already exists.");
        }
        // Create user (generate unique ID) & persist in DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

        return new AuthenticationResult(
            user.Id,
            firstName,
            lastName,
            email,
            password,
            token);
    }
}