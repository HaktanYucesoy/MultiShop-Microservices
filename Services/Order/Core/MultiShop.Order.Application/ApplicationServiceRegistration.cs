using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Behaviors;
using MultiShop.Order.Application.Rules;
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

            service.AddSubClassesOfType(assembly, typeof(BaseBusinessRules));
            return service;

        }


        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection service,
            Assembly assembly,
            Type type,
            Func<IServiceCollection,Type,IServiceCollection>? addWithLifeCylcle=null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();


            foreach (var t in types)
            {
                if (addWithLifeCylcle != null)
                {
                    addWithLifeCylcle(service, t);
                }
                else
                {
                    service.AddScoped(t);
                }
            }

            return service;
        }
    }
}
