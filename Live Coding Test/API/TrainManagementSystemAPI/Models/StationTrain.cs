using System;
using System.Collections.Generic;

#nullable disable

namespace TrainManagementSystemAPI.Models
{
    public partial class StationTrain
    {
        public int StationTrainId { get; set; }
        public int? TrainId { get; set; }
        public int? StationId { get; set; }

        public virtual Station Station { get; set; }
        public virtual Train Train { get; set; }
    }
}
