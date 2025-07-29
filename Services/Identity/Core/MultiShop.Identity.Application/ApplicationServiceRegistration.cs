using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Identity.Application.Behaviours.Exception;
using MultiShop.Identity.Application.Behaviours.Transaction;
using MultiShop.Identity.Application.Behaviours.Validation;
using MultiShop.Identity.Application.Common.Strategies.Failure.Factories;
using System.Reflection;

namespace MultiShop.Identity.Application
{
    public static class ApplicationServiceRegistration
    {

        public static ServiceCollection AddApplicationServices(ServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>),typeof(ExceptionHandlingBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>),typeof(TransactionBehaviour<,>));
                
            });
            services.AddScoped<IFailureResponseStrategyFactory, FailureResponseStrategyFactory>();
            services.AddValidatorsFromAssembly(assembly);
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
