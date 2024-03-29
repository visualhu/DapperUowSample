﻿using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Data.Context
{
    public static class DapperDbContextServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperDbContext<T>(this IServiceCollection services,string name, Action<DapperDbContextOptions> setupAction) where T : DapperDbContext
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddOptions();
            services.Configure(name,setupAction);
            services.AddScoped<IContext, T>();


            return services;
        }
    }
}
