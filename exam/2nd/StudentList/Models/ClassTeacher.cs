using System;
using System.Collections.Generic;

#nullable disable

namespace StudentList.Models
{
    public partial class ClassTeacher
    {
        public ClassTeacher()
        {
            Students = new HashSet<Student>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int? StandardId { get; set; }

        public virtual Standard Standard { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
