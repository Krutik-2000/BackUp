using System.Collections.Generic;
using System.Linq;
using System;

namespace Practice_on_LINQ_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student() { StudentID = 1, StudentName = "Rohan" , Age = 18},
                new Student() {StudentID = 2, StudentName = "Raj" , Age = 20},
                new Student() {StudentID = 3 , StudentName = "Joice" , Age = 26},
                new Student() {StudentID = 4 , StudentName = "Ram", Age = 19}
            };

            var areAllStudentsTeenAger = studentList.All(s => s.Age > 14 && s.Age < 24);
            Console.WriteLine(areAllStudentsTeenAger);
        }
    }

    internal class Student
    {
        public Student()
        {
        }

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
