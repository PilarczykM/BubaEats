using BubaEats.Api.Filter;
using BubaEats.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers(
        options => options.Filters.Add<ErrorHandlingFilterAttribute>() // Global error filter. You can use it only for one controller or even route.
        );
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}