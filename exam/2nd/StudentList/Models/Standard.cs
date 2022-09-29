using System;
using System.Collections.Generic;

#nullable disable

namespace StudentList.Models
{
    public partial class Standard
    {
        public Standard()
        {
            ClassTeachers = new HashSet<ClassTeacher>();
            Students = new HashSet<Student>();
        }

        public int StandardId { get; set; }
        public string Standard1 { get; set; }

        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
