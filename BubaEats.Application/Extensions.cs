using Microsoft.Extensions.DependencyInjection;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service
        .AddScoped<IAuthenticationService, AuthenticationService>();
    }

}