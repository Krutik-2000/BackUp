using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;
using TrainManagementSystemAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService { get; set; }
        
        public IJWTRepositoryManager jWTRepository { get; set; }
        public UserController(IJWTRepositoryManager jWTRepository, IUserService userService)
        {
            this.jWTRepository = jWTRepository;
            this.userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await userService.Get());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok( userService.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User  user)
        {
            return Ok( await userService.Post(user));
        }


        // POST api/<UserController>
        [HttpPost ("Login")]
        public IActionResult  Auth([FromBody] User user)
        {
            var token = jWTRepository.Authenticate(user);
            if (token == null)
            {
                return Unauthorized("CREDENTIALS DO NOT MATCH");
            }
            else
            {
                return Ok(token);
            }
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
