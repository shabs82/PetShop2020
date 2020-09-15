using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop2020.Core.Application_Service;
using PetShop2020.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop2020.UI.Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return null;
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _ownerService.ReadById(id);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
