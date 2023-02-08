using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using Telecom.API.Controller;
using Telecom.API.Entities;

namespace Telecom.API.Data
{
    public  class TelecomContext:ITelecomContext
    {

        private readonly NHibernate.ISession _session;
        private readonly ILogger<TelecomContext> _logger;

        

        public IQueryable<Customer> _customers => _session.Query<Customer>();
        public IQueryable<Contract> _contracts => _session.Query<Contract>();

        public TelecomContext(NHibernate.ISession session, ILogger<TelecomContext> logger)
        {
            _session = session ?? throw new ArgumentException(nameof(_session));
            _logger = logger;
           }
      public async Task<object> SaveCustomer(Customer customer)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var response = await _session.SaveAsync(customer);
                    tx.Commit();
                    return response;
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    _logger.LogError("Exception in saving Customer"+e.Message);
                    throw;
                }
            }
            
        }
        public async Task<object> SaveContract(Contract contract)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    var response = await _session.SaveAsync(contract);
                    tx.Commit();
                    return response;
                }
                catch(Exception e)
                {
                    tx.Rollback();
                    _logger.LogError("error in saving contract" + e.Message);
                    throw;
                }
            }
        }
    }
}
