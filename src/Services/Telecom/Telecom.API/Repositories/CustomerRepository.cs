using NHibernate;
using NHibernate.Linq;
using System.Threading.Tasks;
using Telecom.API.Data;
using Telecom.API.Entities;

namespace Telecom.API.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {

       private readonly  ITelecomContext _context;
        public CustomerRepository(ITelecomContext context)
        {
           _context = context ?? throw new ArgumentException(nameof(_context));
        }
        public async Task<IEnumerable<Customer>> getCustomers()
        {
              return await _context._customers.ToListAsync();
        }
    }
}
