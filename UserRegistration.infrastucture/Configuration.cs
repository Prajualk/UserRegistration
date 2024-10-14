using Domain.Iqueries;
using Domain.Irepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserRegistration.infrastucture.Data;
using UserRegistration.infrastucture.Queries;
using UserRegistration.infrastucture.Repository;

namespace UserRegistration.infrastucture
{
    public static class Configuration
    {

        public static IServiceCollection addinfrservices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserRegistation_Dbcontext>(op => op.UseSqlServer
            (configuration.GetConnectionString("UseregiConnectionString")));
            services.AddTransient<IRepbase, Rep>();
            services.AddTransient<IUser, UserQueries>();
            services.AddTransient<IRoles, Rolequeries>();


            return services;
        }
    }
}

