using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Interfaces.Logging;
using MultiShop.Order.Application.Interfaces.Logging.Strategies.Database;
using MultiShop.Order.Infrastructure.Logging;
using MultiShop.Order.Infrastructure.Logging.Nlog;
using MultiShop.Order.Infrastructure.Logging.Nlog.Factories;
using MultiShop.Order.Infrastructure.Logging.Serilog;
using MultiShop.Order.Infrastructure.Logging.Serilog.Factory;
using MultiShop.Order.Infrastructure.Logging.Strategies.Database;
using Serilog;

namespace MultiShop.Order.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services)
        {
            var configuration=services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddSingleton<ISerilogSinkFactory>(sp =>
                new FileSinkFactory(
                    configuration!["Logging:Serilog:File:Path"]!,
                    configuration["Logging:Serilog:File:Template"]!
                ));

            services.AddSingleton<ISerilogSinkFactory>(sp=> 
                  new MsSqlServerSinkFactory(
                     configuration!["Logging:Serilog:SqlServer:ConnectionString"]!,
                     configuration["Logging:Serilog:SqlServer:TableName"]!
                  ));


            services.AddSingleton<ISerilogSinkFactory>(sp =>
                  new ElasticSearchSinkFactory(
                      configuration!["ElasticSettings:Uri"]!,
                      configuration["ElasticSettings:FailureSinkPath"]!,
                      configuration["ElasticSettings:UserName"]!,
                      configuration["ElasticSettings:Password"]!
                  ));

            services.AddScoped<ILogHandler, SerilogLogHandler>();


            var dbProvider = configuration!.GetValue<string>("Logging:NLog:DatabaseProvider");
            if (!String.IsNullOrEmpty(dbProvider))
            {
                switch (dbProvider.ToLowerInvariant())
                {
                    case "mssql":
                        services.AddSingleton<IDbLogStorageStrategy, MSSQLDbLogStorageStrategy>(sp =>
                        {
                            return new MSSQLDbLogStorageStrategy(
                                configuration.GetValue<string>("Logging:NLog:MSSQL:ConnectionString")!,
                                configuration.GetValue<string>("Logging:NLog:MSSQL:TableName")!);
                            
                        });
                        break;

                    case "mongodb":
                        services.AddSingleton<IDbLogStorageStrategy, MongoDbLogStorageStrategy>(sp =>
                        {
                            return new MongoDbLogStorageStrategy(
                                configuration.GetValue<string>("Logging:NLog:MongoDB:ConnectionString")!,
                                configuration.GetValue<string>("Logging:NLog:MongoDB:DatabaseName")!,
                                configuration.GetValue<string>("Logging:NLog:MongoDB:CollectionName")!);
                        });
                        break;

                    case "redis":
                        services.AddSingleton<IDbLogStorageStrategy, RedisDbLogStorageStrategy>(sp =>
                        {
                            return new RedisDbLogStorageStrategy(
                                configuration.GetValue<string>("Logging:NLog:Redis:ConnectionString")!,
                                configuration.GetValue<string>("Logging:NLog:Redis:KeyPrefix")!);
                        });
                        break;

                    default:
                        break;


                }

                services.AddSingleton<INLogFactory, DatabaseNLogFactory>(sp =>
                {
                    var dbStrategy = sp.GetRequiredService<IDbLogStorageStrategy>();
                    return new DatabaseNLogFactory(dbStrategy,NLog.LogLevel.Info);
                });

                services.AddScoped<ILogHandler, NlogLogHandler>();
            }

            services.AddScoped<ILoggerService, LoggerService>();

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