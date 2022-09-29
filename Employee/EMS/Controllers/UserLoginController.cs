
using EMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        public IUserLoginService userLoginService { get; set; }

        private readonly IJWTManagerRepository jWTManager;
        public UserLoginController(IJWTManagerRepository jWTManager,IUserLoginService userLoginService)
        {
            this.jWTManager = jWTManager;
            this.userLoginService = userLoginService;
        }
        // GET: api/<UserLoginController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await userLoginService.Get());
        }

        // GET: api/<UserLoginController>
        [HttpGet("PersonalDetails")]
        public async Task<IActionResult> GetUSER()
        {
            return Ok(await userLoginService.GetUser());
        }

        // GET api/<UserLoginController>/5
        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            return Ok(userLoginService.GetById(id));
        }

        // POST api/<UserLoginController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            return Ok(await userLoginService.Post(user));
        }

        // POST api/<UserLoginController>
        [HttpPost("Login")]
        public IActionResult Auth([FromBody] User user)
        {
            var token = jWTManager.Authenticate(user);
            if(token == null)
            {
                return Unauthorized("CREDENTIALS DO NOT MATCH");
            }
            else
            {
                return Ok(token);
            }
        }




        // PUT api/<UserLoginController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] User user)
        {
            var Old = userLoginService.GetById(id);
             userLoginService.Update(Old, user);
            return "User Updated Successfully";
        }

        // DELETE api/<UserLoginController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var Old = userLoginService.GetById(id);
            userLoginService.Delete(Old);
            return "User Deleted Successfully";
        }
    }
}
