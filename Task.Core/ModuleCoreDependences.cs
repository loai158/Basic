using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Task.Core.Behavior;

namespace Task.Core
{
    public static class ModuleCoreDependences
    {
        public static IServiceCollection AddCoreDependences(this IServiceCollection services)
        {
            //cofig for mediator
            services.AddMediatR(cfg =>

                                 cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())
                                );
            //config for automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;



        }

    }
}
