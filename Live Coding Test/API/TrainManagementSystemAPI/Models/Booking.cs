using System;
using System.Collections.Generic;

#nullable disable

namespace TrainManagementSystemAPI.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int Ticket { get; set; }
        public int? FromStation { get; set; }
        public int? ToStation { get; set; }
        public int? TrainId { get; set; }
        public int? UserId { get; set; }

        public virtual Station FromStationNavigation { get; set; }
        public virtual Station ToStationNavigation { get; set; }
        public virtual Train Train { get; set; }
        public virtual User User { get; set; }
    }
}
