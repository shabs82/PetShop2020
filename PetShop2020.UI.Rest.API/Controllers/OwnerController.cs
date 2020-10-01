using System;
using System.Collections.Generic;
using System.Data;
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
        // GET api/owners -- READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                return _ownerService.ReadAll();
            }
            catch (DataException e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.ReadById(id);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult Post([FromBody]Owner owner)
        {
            try
            {
                return Ok(_ownerService.Create(owner));
            }

            catch (MissingMemberException e)
            {
                return NotFound(e.Message);
            }
             
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.Update(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_ownerService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
