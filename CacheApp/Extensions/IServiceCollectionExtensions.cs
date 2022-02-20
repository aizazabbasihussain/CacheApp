using CacheRefresherProject;
using CacheRefresherProject.Contracts;
using CacheRefresherProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheApp.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICacheRefresherService, CacheRefresherService>()
                .AddScoped<IRefreshCollectionService, RefreshCollectionService>()
                .AddSwaggerGen(c =>
                 {
                     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Noon Payments", Version = "v1" });
                     c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                     {
                         Name = "Authorization",
                         Type = SecuritySchemeType.Http,
                         Scheme = "basic",
                         In = ParameterLocation.Header,
                         Description = "Noon Payments.(UserName = 'admin' and Password = 'admin123')"
                     });
                     c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                              new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "basic"
                                    }
                                },
                                new string[] {}
                        }
                    });
                 }); 
        }
    }

}
