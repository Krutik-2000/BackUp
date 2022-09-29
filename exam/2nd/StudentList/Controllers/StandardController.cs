using Microsoft.AspNetCore.Mvc;
using StudentList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        public IStandardService standardService { get; set; }

        public StandardController(IStandardService standardService)
        {
            this.standardService = standardService;
        }
        // GET: api/<StandardController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await standardService.Get());
        }

        // GET api/<StandardController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await standardService.GetById(id));
        }

        // POST api/<StandardController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Standard standard )
        {
            return Ok(await standardService.Add(standard));
        }

        // PUT api/<StandardController>/5
        [HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] Standard standard)
        //{
        //    return Ok(await standardService.Update(id, standard));
        //}

        // DELETE api/<StandardController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await standardService.Delete(id));
        }
    }
}
