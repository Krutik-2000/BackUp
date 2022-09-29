using System;
using System.Collections.Generic;

#nullable disable

namespace JWT_Assignment.Models
{
    public partial class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientNumber { get; set; }
        public int? AssistantId { get; set; }

        public virtual Assistant Assistant { get; set; }
    }
}
