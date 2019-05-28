using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenses.Api.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();        

            return services;
        }

        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
