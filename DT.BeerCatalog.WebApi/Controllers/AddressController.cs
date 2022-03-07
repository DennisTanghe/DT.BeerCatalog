using DT.BeerCatalog.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DT.BeerCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _addressRepository.GetAllAddresses();
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return _addressRepository.GetAddress(id);
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // TODO
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // TODO
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO
        }
    }
}
