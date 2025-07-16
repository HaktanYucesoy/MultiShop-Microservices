using Microsoft.Extensions.DependencyInjection;
using MultiShop.Identity.Application.Common.Strategies.Failure.Factories;


namespace MultiShop.Identity.Application.Common.Strategies.Failure.Extensions
{
    public static class FailureResponseStrategyDependencyExtension
    {
        public static IServiceCollection AddFailureResponseStrategies(this IServiceCollection services)
        {
            // Register all strategies
            services.AddTransient<IFailureResponseStrategy, IResultFailureResponseStrategy>();
            services.AddTransient<IFailureResponseStrategy, BaseResponseFailureResponseStrategy>();
            services.AddTransient<IFailureResponseStrategy, ReflectionFailureResponseStrategy>();
            services.AddTransient<IFailureResponseStrategy, BooleanFailureResponseStrategy>();
            services.AddTransient<IFailureResponseStrategy, NullableFailureResponseStrategy>();
            services.AddTransient<IFailureResponseStrategy, DefaultFailureResponseStrategy>();

            // Register factory
            services.AddTransient<IFailureResponseStrategyFactory, FailureResponseStrategyFactory>();

            return services;
        }
    }
}
