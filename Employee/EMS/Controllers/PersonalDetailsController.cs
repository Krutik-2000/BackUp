using CloudinaryDotNet.Actions;
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
    public class PersonalDetailsController : ControllerBase
    {
        public IPersonalDetailsService personalDetails { get; set; }
        public PersonalDetailsController( IPersonalDetailsService personalDetails)
        {
            this.personalDetails = personalDetails;
        }


        // GET: api/<PersonalDetailsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await personalDetails.GetPersonalDetails());
        }

        // GET api/<PersonalDetailsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok( await personalDetails.GetPersonalDetailsById(id));
        }

        // POST api/<PersonalDetailsController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] PersonalDetail detail)
        //{
        //    return Ok(await personalDetails.Post(detail));
        //}


        [HttpPost]
        public async Task<ActionResult<ImageUploadResult>> AddRecipeImage([FromForm] ProfileImageVM Obj)
        {
            var result = await personalDetails.AddImages(Obj.ProfileImage);
            if (result == null) return new BadRequestObjectResult("Image is not Uploaded");
            var image = new PersonalDetail
            {
                ProfileImage = result.SecureUrl.AbsoluteUri,
                FirstName = Obj.FirstName,
                LastName = Obj.LastName,
                EmailId = Obj.EmailId,
                MobileNumber = Obj.MobileNumber,
                Address = Obj.Address,
                BirthDate = Obj.BirthDate,
                Gender = Obj.Gender,
                MaritalStatus = Obj.MaritalStatus,
                Salary = Obj.Salary,
                HireDate = Obj.HireDate,
                Department = Obj.Department,
                Post = Obj.Post,
                UserId = Obj.UserId
                
        
 
   
    };
            await personalDetails.Post(image);
            return result;
        }
        // PUT api/<PersonalDetailsController>/5
        [HttpPut("{id}")]
        
        public async Task<ActionResult<ImageUploadResult>> UpdateDetails(int id, [FromForm] ProfileImageVM profileImageVM)
        {
            var result = await personalDetails.AddImages(profileImageVM.ProfileImage);
            if (result == null) return new BadRequestObjectResult("Image is not Uploaded");
            var image = new PersonalDetail
            {
                ProfileImage = result.SecureUrl.AbsoluteUri,
                FirstName = profileImageVM.FirstName,
                LastName = profileImageVM.LastName,
                EmailId = profileImageVM.EmailId,
                MobileNumber = profileImageVM.MobileNumber,
                Address = profileImageVM.Address,
                BirthDate = profileImageVM.BirthDate,
                Gender = profileImageVM.Gender,
                MaritalStatus = profileImageVM.MaritalStatus,
                Salary = profileImageVM.Salary,
                HireDate = profileImageVM.HireDate,
                Department = profileImageVM.Department,
                Post = profileImageVM.Post,
                UserId = profileImageVM.UserId

            };
            var Old = personalDetails.GetById(id);
             personalDetails.Update(Old,image);
            return result;
        }

        // DELETE api/<PersonalDetailsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var Old = personalDetails.GetById(id);
            personalDetails.Delete(Old);
            return "Data Deleted ";
        }
    }
}
