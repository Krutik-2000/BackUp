using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS
{
    public interface IPersonalDetailsService:IRepository<PersonalDetail>
    {
        Task<List<PersonalDetail>> GetPersonalDetails();

        Task<PersonalDetail> GetPersonalDetailsById(int id);

        Task<ImageUploadResult> AddImages(IFormFile formFile);

        
    }
    public class PersonalDetailsService : Repository<PersonalDetail>, IPersonalDetailsService
    {
        private readonly Cloudinary cloudinary;
        public PersonalDetailsService(EmployeeContext employeeContext,IOptions<CloudinarySettings> options) : base(employeeContext)
        {
            var account = new Account
            (
                options.Value.CloudName,
                options.Value.ApiKey,
                options.Value.ApiSecret
            );
            cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddImages(IFormFile formFile)
        {
            var UploadImgFile = new ImageUploadResult();



            if (formFile.Length > 0)
            {
                //Reading Streams
                await using var stream = formFile.OpenReadStream();
                var uploadParameters = new ImageUploadParams
                {
                    File = new FileDescription(formFile.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };



                UploadImgFile = await cloudinary.UploadAsync(uploadParameters);



            }
            return UploadImgFile;
        }

        public async Task<List<PersonalDetail>> GetPersonalDetails()
        {
            return await employeeContext.PersonalDetails.Include(x => x.DepartmentNavigation).Include(x => x.PostNavigation).ToListAsync();
        }

        public async Task<PersonalDetail> GetPersonalDetailsById(int id)
        {
            return await employeeContext.PersonalDetails.Include(x => x.DepartmentNavigation).Include(x => x.GenderNavigation).Include(x => x.MaritalStatusNavigation).Include(x => x.PostNavigation).Where(x => x.UserId == id).FirstAsync();
        }

        
    }
}
