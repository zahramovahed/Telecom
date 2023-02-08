using Telecom.API.Entities;

namespace Telecom.API.Repositories
{
    public interface ICustomerRepository
    {
        public  Task<IEnumerable<Customer>> getCustomers();

        public Task createCustomer(Customer customer);
        public Task<IEnumerable<Customer>> getCustomersByFilter(string? lastName, string? address, CustomerType? customerType);



    }
}
