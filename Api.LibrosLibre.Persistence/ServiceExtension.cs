using Api.LibrosLibre.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.LibrosLibre.Persistence
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connecionString = configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connecionString));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }


    }
}
