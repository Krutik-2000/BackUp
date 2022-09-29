using System;
using System.Collections.Generic;

#nullable disable

namespace EmpOvertime1.Models
{
    public partial class VOvertime
    {
        public string EmpName { get; set; }
        public int? Jan { get; set; }
        public int? Feb { get; set; }
        public int? March { get; set; }
        public int? April { get; set; }
        public int? May { get; set; }
        public int? June { get; set; }
        public int? July { get; set; }
        public int? Aug { get; set; }
        public int? Sept { get; set; }
        public int? Oct { get; set; }
        public int? Nov { get; set; }
        public int? Dec { get; set; }
        public int? TotalOverTime { get; set; }
    }
}
