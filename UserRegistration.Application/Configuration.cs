using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserRegistration.Application
{
    public static class Configuration
    {
        public static IServiceCollection addApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(o =>
            {
                o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            }
            );
            return services;
        }
    }
}
