using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using Telecom.API.Entities;

namespace Telecom.API.Data
{
    public  class TelecomContext:ITelecomContext
    {

        private readonly NHibernate.ISession _session;
        public IQueryable<Customer> _customers => _session.Query<Customer>();

        public TelecomContext(NHibernate.ISession session)
        {
            _session = session ?? throw new ArgumentException(nameof(_session));
        }
      

    }
}
