using Microsoft.Extensions.DependencyInjection;

namespace Api.LibrosLibre.Application 
{
    public static class ServiceExtension
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IImagesService, ImagesServices>();
            services.AddScoped<IUserBookService, UserBookService>();
            services.AddScoped<IUserService, UserService>();
        }

    }

}