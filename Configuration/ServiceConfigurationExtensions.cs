using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ParliamentApp.GovernmentAPI;
using ParliamentApp.Infrastructure;
using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Infrastructure.QueryEvaluators;
using ParliamentApp.Services;
using System.Reflection;

namespace ParliamentApp.Configuration
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddParliamentAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddThirdPartyServices(services);
            
           services.AddDbContext<ParliamentContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IHttpWrapper, HttpWrapper>();

            services.AddScoped<IParliamentDataService, ParliamentDataService>();

            services.AddScoped<IGovernmentDataProcessingService, GovernmentDataProcessingService>();


            services.AddScoped<IMembersOfParliamentResourceParameterQueryEvaluator, MembersOfParliamentResourceParameterQueryEvaluator>();
            services.AddScoped<IMemberVotesResourceParameterQueryEvaluator, MemberVotesResourceParameterQueryEvaluator>();
            return services;
        }
    }
}
