using System;
using System.Collections.Generic;

#nullable disable

namespace StudentList.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int? RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int StandardId { get; set; }
        public int TeacherId { get; set; }

        public virtual Standard Standard { get; set; }
        public virtual ClassTeacher Teacher { get; set; }
    }
}
