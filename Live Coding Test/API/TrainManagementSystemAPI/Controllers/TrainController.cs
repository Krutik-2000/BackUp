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
    public class TrainController : ControllerBase
    {
        public  ITrainService trainService { get; set; }

        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }
        // GET: api/<TrainController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await trainService.Get());
        }

        // GET api/<TrainController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(trainService.GetById(id));
        }

        // POST api/<TrainController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Train train)
        {
            return Ok(await trainService.Post(train));
        }

        // PUT api/<TrainController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Train train)
        {
            var old = trainService.GetById(id);
            trainService.Update(old,train);
            return "Data Updated Sucessfully";
        }

        // DELETE api/<TrainController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var old = trainService.GetById(id);
            trainService.Delete(old);
            return "Data Deleted Sucessfully";
        }
    }
}
