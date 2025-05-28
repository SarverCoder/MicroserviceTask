using Microsoft.EntityFrameworkCore;
using OrderService.DataAccess;
using OrderService.Repository;
using OrderService.Repository.Interfaces;
using Serilog;

namespace OrderService.Extensions;

public static class Extensions
{

    public static IServiceCollection AddOrderService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<OrderDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();
        });

        services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(Program)));

        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddSerilog((serviceProvider, loggerConfiguration) =>
        {
            loggerConfiguration
                .ReadFrom
                .Configuration(configuration);
        });

        return services;

    }

}
