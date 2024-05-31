using BubaEats.Api.Common.Errors;
using BubaEats.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BubaEats.Api;

public static class Extension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMapping();
        // builder.Services.AddControllers(
        //     options => options.Filters.Add<ErrorHandlingFilterAttribute>() // Global error filter. You can use it only for one controller or even route.
        //     );
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, BubaEatsProblemDetailsFactory>();
        return services;
    }
}
