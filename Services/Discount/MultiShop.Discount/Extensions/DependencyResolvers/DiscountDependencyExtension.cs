using MultiShop.Discount.Context;
using MultiShop.Discount.Services;
using MultiShop.Discount.Services.Decorators;

namespace MultiShop.Discount.Extensions.DependencyResolvers
{
    public static class DiscountDependencyExtension
    {
        public static IServiceCollection AddDiscountDependencies(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.Decorate<IDiscountService>((inner, provider) => new LoggingDiscountDecorator(
             inner,
             provider.GetRequiredService<ILogger<LoggingDiscountDecorator>>()
         ));

            return services;
        }
    }
}
