using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Application.Common.Interfaces.Services;
using BubaEats.Infrastructure.Authentication;
using BubaEats.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service,
        ConfigurationManager configuration)
        => service
        .Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName))
        .AddSingleton<IDateTimeProvider, DateTimeProvider>()
        .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
}