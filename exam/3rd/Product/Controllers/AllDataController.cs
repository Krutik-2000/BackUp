using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Product.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllDataController : ControllerBase
    {
        public IAllDataService dataService { get; set; }
        public AllDataController(IAllDataService dataService)
        {
            this.dataService = dataService;
        }

        
        // GET: api/<AllDataController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dataService.Get());
        }

        // GET api/<AllDataController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await dataService.GetById(id));
        }

        // POST api/<AllDataController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AllDatum data )
        {
            return Ok(await dataService.Add(data));
        }
        // PUT api/<AllDataController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AllDatum data)
        {
            return Ok(await dataService.Update(id,data));
        }

        //// PUT api/<AllDataController>/5
        //[HttpGet("data/{id}")]
        //public async Task<IActionResult> Procedure(int id)
        //{
        //    return Ok(await dataService.UpdateEntities(id));
        //}
        [HttpGet("data/{id}")]
        public IActionResult Procedure(int id)
        {
            return Ok( dataService.UpdateEntities(id));
        }


        // DELETE api/<AllDataController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await dataService.DeleteData(id));
        }
    }
}
