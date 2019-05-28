﻿using DailyExpenses.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace DailyExspenses.Api.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("LocalConnection") ??
                             "Data Source=DESKTOP-H9LEKDB\\SQLEXPRESS;Initial Catalog=DailyExpenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }

            services.AddDbContextPool<DailyExpensesContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}
