using System;
using System.Collections.Generic;

#nullable disable

namespace EmpOvertime1.Models
{
    public partial class Overtime
    {
        public int OtId { get; set; }
        public int? EmpId { get; set; }
        public DateTime Otdate { get; set; }
        public int ExpectedBillable { get; set; }
        public int ActualBillable { get; set; }
        public int? ActualOvertime { get; set; }
        public int? OtStatus { get; set; }

        public virtual User Emp { get; set; }
        public virtual ObjectType OtStatusNavigation { get; set; }
    }
}
