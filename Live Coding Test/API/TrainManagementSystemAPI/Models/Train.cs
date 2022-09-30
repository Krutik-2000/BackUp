using System;
using System.Collections.Generic;

#nullable disable

namespace TrainManagementSystemAPI.Models
{
    public partial class Train
    {
        public Train()
        {
            Bookings = new HashSet<Booking>();
            StationTrains = new HashSet<StationTrain>();
        }

        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public int Seats { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<StationTrain> StationTrains { get; set; }
    }
}
