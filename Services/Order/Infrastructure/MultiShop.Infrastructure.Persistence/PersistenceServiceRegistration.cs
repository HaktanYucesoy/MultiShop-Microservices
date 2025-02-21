using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Application.Interfaces.Transaction;
using MultiShop.Order.Application.Interfaces.UnitOfWork;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Repositories;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Transaction;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.UnitOfWork;

namespace MultiShop.Order.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });         
            services.AddScoped<ITransaction, EfCoreTransaction>();
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<IOrderingRepository, EfCoreOrderingRepository>();
            services.AddScoped<IOrderDetailRepository, EfCoreOrderDetailRepository>();
            services.AddScoped<IAddressRepository, EfCoreAddressRepository>();

            return services;

        }
    }
}
