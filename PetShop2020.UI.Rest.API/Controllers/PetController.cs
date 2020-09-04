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
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;// cannot be overriden ever once read only is set//


        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        // GET: api/<PetController>
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.GetPets().ToList();
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.ReadById(id);
        }

        // POST api/<PetController>
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petService.Create(pet);
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Pet pet)
        {
            _petService.Update(pet);
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id , string name)
        {
            _petService.Delete(id , name);
        }
    }
}
