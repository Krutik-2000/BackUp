using System;
using System.Collections.Generic;

#nullable disable

namespace TrainManagementSystemAPI.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
