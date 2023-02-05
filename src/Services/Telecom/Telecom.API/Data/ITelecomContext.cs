using NHibernate;
using NHibernate.Cfg;
using Telecom.API.Entities;

namespace Telecom.API.Data
{
    public interface ITelecomContext
    {
        public IQueryable<Customer> _customers { get;  }

      


    }
}
