using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.InfrastructureBases;
using Task.Infrastructure.Implemintaion;
using Task.Infrastructure.InfrastructureBases;
using Task.Infrastructure.Repositry;
using Task.Infrastructure.UnitOfWorks;

namespace Task.Infrastructure
{
    public static class ModuleInfrastructureDependences
    {
        public static IServiceCollection AddInfrastructureDependences(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositryAsync<>), typeof(GenericRepositryAsync<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoryRepositry, CategoryRepositry>();

            return services;
        }
    }
}
