using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Application.Common.Interfaces.Services;
using BubaEats.Infrastructure.Authentication;
using BubaEats.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        => service
        .AddSingleton<IDateTimeProvider, DateTimeProvider>()
        .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
}