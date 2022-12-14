using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public ITeacherService teacherService { get;  set; }

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await teacherService.Get());
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await teacherService.GetTeacherByStdId(id));
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
