using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Identity.Application.Interfaces.Repositories.EmailAuthenticator;
using MultiShop.Identity.Application.Interfaces.Repositories.OperationClaim;
using MultiShop.Identity.Application.Interfaces.Repositories.OtpAuthenticator;
using MultiShop.Identity.Application.Interfaces.Repositories.RefreshToken;
using MultiShop.Identity.Application.Interfaces.Repositories.User;
using MultiShop.Identity.Application.Interfaces.Repositories.UserOperationClaim;
using MultiShop.Identity.Application.Interfaces.Repositories;
using MultiShop.Identity.Infrastructure.Persistence.EfCore;
using MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories;
using MultiShop.Identity.Application.Interfaces.UnitOfWork;
using MultiShop.Identity.Infrastructure.Persistence.EfCore.UnitOfWork;


namespace MultiShop.Identity.Infrastructure.Persistence
{
    public static class PersistenceServiceRegisteration
    {

        public static IServiceCollection AddIdentityPersistence(
        this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<MultiShopIdentityContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("Identity")));
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            services.AddScoped<IUserRepository, UserEfCoreRepository>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorEfCoreRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenEfCoreRepository>();
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorEfCoreRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimEfCoreRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimEfCoreRepository>();

            // İsteğe bağlı: generic fallback (IAsyncRepository<T,K> doğrudan istenir ise)
            //services.AddScoped(typeof(IAsyncRepository<,>),
            //                   typeof(BaseEntityFrameworkCoreRepository<>));



            return services;
        }
    }
}
