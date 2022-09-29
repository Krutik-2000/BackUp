using System;

namespace Assignment_5_ternary_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;
            Console.WriteLine("Enter Your Age");
            age = Convert.ToInt32(Console.ReadLine());

            string vote(int age) => age > 18 ? "You are eligible  FOR VOTING" : "You are not eligible  for voting";
            Console.WriteLine(vote(age));

        }
    }
    
}

