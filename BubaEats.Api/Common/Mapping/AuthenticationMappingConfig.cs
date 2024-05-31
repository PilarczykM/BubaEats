using BubaEats.Application.Authentication.Command.Register;
using BubaEats.Application.Authentication.Queries.Login;
using BubaEats.Contracts.Authentication;
using Mapster;
using Microsoft.AspNetCore.Authentication;

namespace BubaEats.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        // Example how to map object to another object
        // Example is silly because this are the same objects.
        //
        // Other: .Map(dest => dest.Token, src => src.Token)
        //        .Map(dest => dest, src => src.User);
        config.NewConfig<AuthenticateResult, AuthenticationResponse>()
        .Map(dest => dest, src => src);
    }
}
