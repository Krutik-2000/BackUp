using System;
using System.Collections.Generic;

#nullable disable

namespace JWT_Assignment.Models
{
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
