using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Models
{
    public partial class PersonalDetail
    {
        public int PersonalDetailsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public decimal? MobileNumber { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public int? MaritalStatus { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public string ProfileImage { get; set; }
        public int? Department { get; set; }
        public int? Post { get; set; }
        public int? UserId { get; set; }

        public virtual TypeOfObject DepartmentNavigation { get; set; }
        public virtual TypeOfObject GenderNavigation { get; set; }
        public virtual TypeOfObject MaritalStatusNavigation { get; set; }
        public virtual TypeOfObject PostNavigation { get; set; }
        public virtual User User { get; set; }
    }
    [Keyless]
    public partial class ProfileImageVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public decimal? MobileNumber { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public int? MaritalStatus { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public IFormFile ProfileImage { get; set; }
        public int? Department { get; set; }
        public int? Post { get; set; }
        public int? UserId { get; set; }
    }
}
