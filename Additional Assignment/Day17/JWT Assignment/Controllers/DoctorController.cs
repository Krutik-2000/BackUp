using DocumentFormat.OpenXml.Spreadsheet;
using JWT_Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users = JWT_Assignment.Models.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_Assignment.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private IDoctorService doctorService { get; set; }
        public DoctorController(IJWTManagerRepository jWTManager, IDoctorService doctorService)
        {
            _jWTManager = jWTManager;
            this.doctorService = doctorService;
        }


        // GET: api/<DoctorController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await doctorService.Get());
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await doctorService.GetbyId(id));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        // POST api/<DoctorController>
        [Authorize]
        [RequestActionFilter(RequiredRole = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            return Ok(await doctorService.Add(doctor));
        }

        // PUT api/<DoctorController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctor doctor)
        {
            return Ok(await doctorService.Update(id, doctor));
        }

        // DELETE api/<DoctorController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await doctorService.Delete(id));
        }
    }
}
