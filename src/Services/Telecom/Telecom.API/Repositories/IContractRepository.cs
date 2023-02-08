using Telecom.API.Data;
using Telecom.API.Entities;

namespace Telecom.API.Repositories
{
    public interface IContractRepository
    {
        public Task<IEnumerable<Contract>> getContracts();
        public Task createContract(Contract contract);



    }
}