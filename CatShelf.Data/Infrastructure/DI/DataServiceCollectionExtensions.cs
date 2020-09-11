using System;
using System.Collections.Generic;
using System.Text;
using CatShelf.Data.Providers;
using CatShelf.Data.Repositories.Implementation;
using CatShelf.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CatShelf.Data.Infrastructure.DI
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICatRepository, CatRepository>();
            services.AddTransient<IDateProvider, DateProvider>();

            return services;
        }
    }
}
