using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Repositories;

namespace MultiShop.Order.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<OrderContext>();
            services.AddScoped<IOrderingRepository, EfCoreOrderingRepository>();
            services.AddScoped<IOrderDetailRepository, EfCoreOrderDetailRepository>();
            services.AddScoped<IAddressRepository, EfCoreAddressRepository>();

            return services;

        }
    }
}
