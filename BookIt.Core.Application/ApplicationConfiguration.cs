using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookIt.Core.Application.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookIt.Core.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<HashConfig>(configuration.GetSection(nameof(HashConfig)));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
