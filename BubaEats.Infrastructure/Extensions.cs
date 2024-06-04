using BubaEats.Application.Common.Interfaces.Authentication;
using BubaEats.Application.Common.Interfaces.Persistent;
using BubaEats.Application.Common.Interfaces.Services;
using BubaEats.Infrastructure.Authentication;
using BubaEats.Infrastructure.Persistent;
using BubaEats.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service,
        ConfigurationManager configuration)
    {
        service.AddAuth(configuration);
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        service.AddScoped<IUserRepository, InMemoryUserRepository>();

        return service;
    }

    public static IServiceCollection AddAuth(
    this IServiceCollection service,
    ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        service.AddSingleton(Options.Create(jwtSettings));
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        service.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return service;
    }

}