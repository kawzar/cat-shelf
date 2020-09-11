using CatShelf.Services.Implementation;
using CatShelf.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CatShelf.Services.DI
{
    public static class ServicesServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICatService, CatService>();

            return services;
        }
    }
}
