using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop2020.Core.Application_Service;
using PetShop2020.Core.Entity;
using PetShop2020.Core.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop2020.UI.Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private IAuthenticationHelper _authenticationHelper;

        public UsersController(IUserService userService, IAuthenticationHelper authenticationHelper)
        {
            _userService = userService;
            _authenticationHelper = authenticationHelper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users -- LOG IN
        [HttpPost]
        public ActionResult Login([FromBody] LoginInputModel loginInputModel)
        {
            try
            {
                User user = _userService.ValidateUser(loginInputModel);
                string token = _authenticationHelper.GenerateToken(user);
                return Ok(new { user.Username, user.IsAdmin, token });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
