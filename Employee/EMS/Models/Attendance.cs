using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public int? Attendance1 { get; set; }
        public int? UserId { get; set; }

        public virtual TypeOfObject Attendance1Navigation { get; set; }
        public virtual User User { get; set; }
    }
}
