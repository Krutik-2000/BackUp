using System;
using System.Collections.Generic;

#nullable disable

namespace TrainManagementSystemAPI.Models
{
    public partial class Station
    {
        public Station()
        {
            BookingFromStationNavigations = new HashSet<Booking>();
            BookingToStationNavigations = new HashSet<Booking>();
            StationTrains = new HashSet<StationTrain>();
        }

        public int StationId { get; set; }
        public string StationName { get; set; }

        public virtual ICollection<Booking> BookingFromStationNavigations { get; set; }
        public virtual ICollection<Booking> BookingToStationNavigations { get; set; }
        public virtual ICollection<StationTrain> StationTrains { get; set; }
    }
}
