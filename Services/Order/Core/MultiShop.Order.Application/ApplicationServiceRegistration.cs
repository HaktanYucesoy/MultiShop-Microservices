﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Behaviors;
using System.Reflection;


namespace MultiShop.Order.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service,IConfiguration configuration)
        {
            var assembly=Assembly.GetExecutingAssembly();
            service.AddMediatR(cfg=> {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            });
            service.AddAutoMapper(assembly);
            return service;

        }
    }
}
