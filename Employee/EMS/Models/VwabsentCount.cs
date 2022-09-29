using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Models
{
    public partial class VwabsentCount
    {
        public int? Absent { get; set; }
        public int? UserId { get; set; }
        public string Month { get; set; }
    }
}
