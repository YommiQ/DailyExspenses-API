using Microsoft.Extensions.DependencyInjection;
using DailyExpenses.DataLayer.Repositories;
using DailyExpenses.Domain;
using DailyExpenses.Domain.IRepositories;
using DailyExpenses.Domain.Services;

namespace DailyExpenses.Api.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();        

            return services;
        }

        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
