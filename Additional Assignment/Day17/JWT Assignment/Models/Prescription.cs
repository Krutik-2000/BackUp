using System;
using System.Collections.Generic;

#nullable disable

namespace JWT_Assignment.Models
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public int? PatientId { get; set; }
        public int? DrugId { get; set; }
        public bool? Morning { get; set; }
        public bool? AfterNoon { get; set; }
        public bool? Night { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
