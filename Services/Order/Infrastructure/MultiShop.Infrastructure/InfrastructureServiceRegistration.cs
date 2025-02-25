using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Interfaces.Logging;
using MultiShop.Order.Infrastructure.Logging.Serilog;
using MultiShop.Order.Infrastructure.Logging.Serilog.Factory;
using Serilog;

namespace MultiShop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<ISerilogSinkFactory>(sp =>
                new FileSinkFactory(
                    configuration["Serilog:File:Path"]!,
                    configuration["Serilog:File:Template"]!
                ));

            services.AddSingleton<ISerilogSinkFactory>(sp=> 
                  new MsSqlServerSinkFactory(
                     configuration["Serilog:SqlServer:ConnectionString"]!,
                     configuration["Serilog:SqlServer:TableName"]!
                  ));

            services.AddScoped<ILogHandler, SerilogLogHandler>();

            return services;
        }

        public static IServiceCollection AddLoggingConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Logger = logger;

            return services;
        }
    }
}