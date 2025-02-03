using Castle.DynamicProxy;
using MultiShop.Catalog.Aspects.ExceptionHandling;

namespace MultiShop.Catalog.Aspects.Extensions
{
    public static class DomainExceptionServiceExtension
    {
        public static IServiceCollection AddDomainService<TDomain, TService, TImplementation>(
        this IServiceCollection services,
        DomainExceptionMap<TDomain> exceptionMap)
        where TService : class
        where TImplementation : class, TService
        {

            var registry = services.BuildServiceProvider().GetRequiredService<DomainExceptionRegistery>();
            services.AddScoped<TImplementation>();
            services.AddScoped(provider =>
            {
                var proxyGenerator = new ProxyGenerator();
                var implementation = provider.GetRequiredService<TImplementation>();
                var interceptor = new DomainExceptionInterceptor<TDomain>(registry);
                return proxyGenerator.CreateInterfaceProxyWithTarget<TService>(
                    implementation,
                    interceptor);
            });

            return services;
        }
    }
}
