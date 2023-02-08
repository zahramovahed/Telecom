using NHibernate.Linq;
using Telecom.API.Data;
using Telecom.API.Entities;

namespace Telecom.API.Repositories
{
    public class ContractRepository:IContractRepository
    {
        private readonly ITelecomContext _context;

        public ContractRepository(ITelecomContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }
        public async Task<IEnumerable<Contract>> getContracts()
        {
            return await  _context._contracts.ToListAsync<Contract>();
        }
        public async Task createContract(Contract contract)
        {
            await _context.SaveContract(contract);

        }
    }
}
