using Microsoft.AspNetCore.Mvc;
using System.Net;
using Telecom.API.Entities;
using Telecom.API.Repositories;

namespace Telecom.API.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TelecomController:ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public TelecomController(ICustomerRepository repository)
        {
            _repository = repository??throw new ArgumentNullException(nameof(_repository));
        }
        [Route("[action]",Name ="GetCustomers")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _repository.getCustomers();
            return Ok(customers);
        }
    }
}
