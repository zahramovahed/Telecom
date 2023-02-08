using NHibernate;
using NHibernate.Engine;
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
        public async Task<IEnumerable<Customer>> getCustomersByFilter(string? lastName,string? address,CustomerType? customerType )
        {
            var isNameNullOrEmpty = string.IsNullOrEmpty(lastName);
            var isAddressNullOrEmpty = string.IsNullOrEmpty(address);
            var isNullCustomerType=!customerType.HasValue;
        return await    _context._customers.Where(f => (isNameNullOrEmpty || f.LastName.Contains(lastName)) && (isAddressNullOrEmpty || f.Address.Contains(address))
            && (isNullCustomerType || f.CustomerType == customerType)).ToListAsync();
        }
        public async Task createCustomer(Customer customer)
        {
           await _context.SaveCustomer(customer);

        }
    }
}
