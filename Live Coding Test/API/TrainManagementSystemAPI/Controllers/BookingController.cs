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
    public class BookingController : ControllerBase
    {
        public IBookingService bookingService { get; set; }

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await bookingService.Get());
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(bookingService.GetById(id));
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Booking booking)
        {
            return Ok(bookingService.Post(booking));
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Booking booking)
        {
            var old = bookingService.GetById(id);
            bookingService.Update(old, booking);
            return "Data Updated Sucessfully";
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var old = bookingService.GetById(id);
            bookingService.Delete(old);
            return "Data Deleted Sucessfully";
        }
    }
}
