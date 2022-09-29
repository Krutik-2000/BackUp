using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Models
{
    public partial class User
    {
        public User()
        {
            Attendances = new HashSet<Attendance>();
            PersonalDetails = new HashSet<PersonalDetail>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int? Role { get; set; }

        public virtual TypeOfObject RoleNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<PersonalDetail> PersonalDetails { get; set; }
    }
}
