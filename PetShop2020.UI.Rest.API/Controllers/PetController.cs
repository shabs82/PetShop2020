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
        private readonly IPetService _petService; // cannot be overriden ever once read only is set//


        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get(Filter filter)
        {
            try
            {
                //write codes for filtering

                return Ok(_petService.GetPets().ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/pets/5 -- READ BY ID
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.ReadById(id);
        }

        /*[HttpGet]
        public List<Pet> Get(string OrderBy)
        {
            return _petService.SortPetByPrice(OrderBy);
        }
        */
        // POST api/pets -- CREATE
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.Create(pet));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/pets/5 - UPDATE
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (id != pet.ID)
                {
                    return BadRequest( $"Parameter ID({id}) and pet ID({pet.ID}) have to be the same");
                }

                return Ok(_petService.Update(pet));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }






        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _petService.Delete(id);
                return Ok($"Deleted pet with Id: {id}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        

    }
}
