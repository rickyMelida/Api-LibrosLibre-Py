using Api.LibrosLibre.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.LibrosLibre.Persistence
{


    public static class ServiceExtension
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connecionString = configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connecionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }


    }
}
