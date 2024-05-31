using BubaEats.Application.Authentication.Command.Register;
using BubaEats.Application.Authentication.Common;
using BubaEats.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BubaEats.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        service.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            ValidationRegisterCommandBehavior>();
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return service;
    }

}