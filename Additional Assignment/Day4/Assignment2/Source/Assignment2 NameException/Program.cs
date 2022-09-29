//Create a user defined exception class NameException which will validate a Name and name should contain only character. If name does not contain proper value it should throw an exception. You need to handle exception in student class.
using System;
using System.Text.RegularExpressions;

namespace Assignment2_NameException
{
    class Program
    {
        static void Main(string[] args)
        {
            Student newStudent = null;

            try
            {
                newStudent = new Student();
                Console.WriteLine("Enter Your Name:");
                newStudent.StudentName = Convert.ToString(Console.ReadLine());
                ValidateStudent(newStudent);
            }
            catch (NameExcepiton ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }

        private static void ValidateStudent(Student std)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (!regex.IsMatch(std.StudentName))
            {
                throw new NameExcepiton(std.StudentName);
            }
            else { Console.WriteLine( "Name is valid"); }
                
        }
    }

    public class NameExcepiton : Exception
    {
        public NameExcepiton(string Name) :base(String.Format("Invalid Student Name: {0}", Name))
        {
                  
        }
    }

    public class Student
    {
       public string StudentName { get; set; }
    }
}
