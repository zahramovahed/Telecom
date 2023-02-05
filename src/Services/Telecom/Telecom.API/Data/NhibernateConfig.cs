using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Reflection;

namespace Telecom.API.Data
{
    public static class NhibernateConfig
    {
        public static NHibernate.ISession AddHibernateConfig(IConfiguration configuration)
        {
            var mapper = new ModelMapper();
            var ConfigSql = new Configuration();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            ConfigSql.DataBaseIntegration(x =>
            {
                x.ConnectionString = configuration.GetValue<string>("DatabaseSettings:Connectionstring");
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
            ConfigSql.AddAssembly(Assembly.GetExecutingAssembly());
            ConfigSql.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
         return   ConfigSql.BuildSessionFactory().OpenSession();
        }
    }
}
