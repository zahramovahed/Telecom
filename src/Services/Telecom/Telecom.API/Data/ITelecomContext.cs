using NHibernate;
using NHibernate.Cfg;
using Telecom.API.Entities;

namespace Telecom.API.Data
{
    public interface ITelecomContext
    {
        public IQueryable<Customer> _customers { get;  }
        public IQueryable<Contract> _contracts { get; }

        public  Task<object> SaveCustomer(Customer customer);

        public Task<object> SaveContract(Contract contract);




    }
}
