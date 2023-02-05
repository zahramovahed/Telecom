using Telecom.API.Entities;

namespace Telecom.API.Repositories
{
    public interface ICustomerRepository
    {
        public  Task<IEnumerable<Customer>> getCustomers();
    }
}
