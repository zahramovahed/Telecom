using System.Runtime.CompilerServices;
using Telecom.API.Data;
using Telecom.API.Repositories;

namespace Telecom.API
{
    public static class TelecomSetups
    {
        public static IServiceCollection AddTelecomInfos(this IServiceCollection services,WebApplicationBuilder builder)
        {
            services.AddScoped<ITelecomContext, TelecomContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddSingleton<NHibernate.ISession>(ISession => NhibernateConfig.AddHibernateConfig(builder.Configuration));
            return services;

        }
    }
}
