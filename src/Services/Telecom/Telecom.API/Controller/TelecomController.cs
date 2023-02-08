using Microsoft.AspNetCore.Mvc;
using System.Net;
using Telecom.API.Entities;
using Telecom.API.GlobalClasses;
using Telecom.API.Repositories;

namespace Telecom.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TelecomController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IContractRepository _contractRepository;
        private readonly ILogger<TelecomController> _logger;

        public TelecomController(ICustomerRepository repository, IContractRepository contractRepository, ILogger<TelecomController> logger)
        {
            _customerRepository = repository ?? throw new ArgumentNullException(nameof(_customerRepository));
            _contractRepository = contractRepository ?? throw new ArgumentNullException(nameof(_contractRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        [Route("[action]", Name = "GetCustomers")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.getCustomers();
            if (customers == null||customers.Count()==0)
            {
                _logger.LogInformation("No customer Founds");
                return NotFound();
            }
            
            return Ok(customers);
        }

        [Route("[action]",Name ="GetCustomersByFilter")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByFilter(string? lastName,string? address,CustomerType? customerType )
        {
            var customers = await _customerRepository.getCustomersByFilter(lastName, address, customerType);
            if(customers==null)
            {
                _logger.LogError($"No customer with name:{lastName}found");
                return NotFound();
            }
            return Ok(customers);
        }

        [Route("[action]",Name="CreateCustomer")]
        [HttpPost]
        [ProducesResponseType(typeof(Customer),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            await _customerRepository.createCustomer(customer);
            return Ok(customer);
        }

        [Route("[action]",Name ="CreateContract")]
        [HttpPost]
        [ProducesResponseType(typeof(Contract),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Contract>> CreateContract([FromBody]Contract contract)
        {
            await _contractRepository.createContract(contract);
            return Ok(contract);
        }
        [Route("[action]",Name ="getCurrentDate")]
        [HttpGet]
        [ProducesResponseType(typeof(string),(int)HttpStatusCode.OK)]
        public ActionResult GetCurrentDate()
        {
           var datetime= DateTime.Now.GetPersionDateString();
           //string result= PersianDateTime.GetPersionDateString(datetime);
            return Ok(datetime);
        }

    }
}
