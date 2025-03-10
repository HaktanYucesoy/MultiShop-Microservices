using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Behaviors;
using System.Reflection;

namespace MultiShop.Order.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            var assembly=Assembly.GetExecutingAssembly();
            service.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            });
            service.AddValidatorsFromAssembly(assembly);
            service.AddAutoMapper(assembly);
            return service;

        }
    }
}
