using Microsoft.Extensions.DependencyInjection;
using Task.Services.Abstracts;
using Task.Services.Implementations;

namespace Task.Services
{
    public static class ModuleServiceDependences
    {
        public static IServiceCollection AddServiceDependences(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IOrderServices, OrderServices>();

            return services;
        }
    }
}
