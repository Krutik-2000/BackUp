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
    public class StationTrainController : ControllerBase
    {
        public IStationTrainService stationTrainService { get; set; }

        public StationTrainController(IStationTrainService stationTrainService)
        {
            this.stationTrainService = stationTrainService;
        }
        // GET: api/<StationTrainController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await stationTrainService.GetStationTrain());
        }

        // GET api/<StationTrainController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(stationTrainService.GetById(id));
        }

        // POST api/<StationTrainController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StationTrain stationTrain)
        {
            return Ok(await stationTrainService.Post(stationTrain));
        }

        // PUT api/<StationTrainController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] StationTrain stationTrain)
        {
            var old = stationTrainService.GetById(id);
            stationTrainService.Update(old, stationTrain);
            return "Data Updated Sucessfully";

        }

        // DELETE api/<StationTrainController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            var old = stationTrainService.GetById(id);
            stationTrainService.Delete(old);
            return "Data Deleted Sucessfully";
        }
    }
}
