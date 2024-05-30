using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return service;
    }

}