using System;
using System.Collections.Generic;

#nullable disable

namespace JWT_Assignment.Models
{
    public partial class DoctorPatient
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
