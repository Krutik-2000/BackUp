using System;
using System.Collections.Generic;

#nullable disable

namespace EmpOvertime1.Models
{
    public partial class User
    {
        public User()
        {
            Overtimes = new HashSet<Overtime>();
        }

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int? UserStatus { get; set; }

        public virtual ObjectType UserStatusNavigation { get; set; }
        public virtual ICollection<Overtime> Overtimes { get; set; }
    }
}
