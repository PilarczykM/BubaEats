using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return service;
    }

}