using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace MultiShop.Order.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service,IConfiguration configuration)
        {
            var assembly=Assembly.GetExecutingAssembly();
            service.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));
            service.AddAutoMapper(assembly);
            return service;

        }
    }
}
