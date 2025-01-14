using Microsoft.Extensions.DependencyInjection;

namespace Api.LibrosLibre.Application 
{
    public static class ServiceExtension
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookImagesService, ImagesServices>();
            services.AddScoped<IUserService, UserService>();
        }

    }

}