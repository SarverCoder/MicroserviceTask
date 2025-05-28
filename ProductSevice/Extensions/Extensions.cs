using Microsoft.EntityFrameworkCore;
using ProductService.DataAccess;
using ProductService.Repository;
using ProductService.Repository.Interfaces;
using Serilog;

namespace ProductService.Extensions
{
    public static class Extensions
    {

        public static IServiceCollection AddProductService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(Program)));

            services.AddSerilog((serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration
                    .ReadFrom
                    .Configuration(configuration);
            });

            return services;
        }
    }
}
