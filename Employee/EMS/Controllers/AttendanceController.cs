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
    public class AttendanceController : ControllerBase
    {
        public IAttendanceService attendance { get; set; }
        public AttendanceController( IAttendanceService attendance)
        {
            this.attendance = attendance;
        }


        // GET: api/<AttendanceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await attendance.Get());
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok( await attendance.GetAttendancesbyUserID(id));
        }

        // GET api/<AttendanceController>/5
        [HttpGet("value/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            return Ok(await attendance.GetAttendanceValue(id));
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Attendance attdance)
        {
            return Ok( await attendance.Post(attdance));
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Attendance attdance)
        {
            var old = attendance.GetById(id);
            attendance.Update(old, attdance);
            return "Attendance Updated";
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var old = attendance.GetById(id);
            attendance.Delete(old);
            return "Attendance Deleted";
        }
    }
}
