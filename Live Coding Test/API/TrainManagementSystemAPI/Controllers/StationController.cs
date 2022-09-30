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
    public class StationController : ControllerBase
    {
        public IStationService stationService { get; set; }

        public StationController(IStationService stationService)
        {
            this.stationService = stationService; 
        }
        // GET: api/<StationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await stationService.Get());
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(stationService.GetById(id));
        }

        // POST api/<StationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Station station )
        {
            return Ok(await stationService.Post(station));
        }

        // PUT api/<StationController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Station station)
        {
            var Old = stationService.GetById(id);
            stationService.Update(Old, station);
            return "Station Updated";
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var old = stationService.GetById(id);
            stationService.Delete(old);
            return "Station Deleted Sucessfully";

        }
    }
}
