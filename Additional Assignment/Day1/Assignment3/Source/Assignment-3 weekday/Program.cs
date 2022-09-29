using System;

namespace Assignment_3_weekday
{
    class Program
    {
        enum Days
        {
            Sunday = 1,
            Monday,
            Tuesday,
            Wednesday,
            Thusday,
            Friday,
            Saturday
        }
        static void Main(string[] args)
        {
            // Declare variable
            int day;
            // Input From User
            Console.WriteLine("Enter any number:");
            day = Convert.ToInt32(Console.ReadLine());

            Days dayname = (Days)day;
            Console.WriteLine(dayname);
                      
        }
    }
}
