using Mapster;
using System.Reflection;

namespace BubaEats.Api.Common.Mapping;

public static class Extensions
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddMapster();
        return services;
    }
}
