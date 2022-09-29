using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_Rental_Bikes
{
    class Mobike
    {
        public string customer_name { get; set; }

        public int phone_number { get; set; }

        public string bike_number { get; set; }

        public int NoofDays { get; set; }

        public void input()
        {
            Console.WriteLine("Enter customer's name:");
            customer_name = Console.ReadLine();

            Console.WriteLine("Enter phone_number:");
            phone_number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter bike_number:");
            bike_number = Console.ReadLine();

            Console.WriteLine("Enter No of Days:");
            NoofDays = Convert.ToInt32(Console.ReadLine());
        }

        public int compute()
        {
            int charge;

            if(NoofDays <= 5)
            {
                charge = NoofDays * 500;
            }
            else if(NoofDays <= 10)
            {
                charge = 5 * 500 + (NoofDays - 5) * 400;
            }
            else
            {
                charge = 5 * 500 + 5 * 400 + (NoofDays - 10) * 100;
            }
            return charge;
        }

        public void display()
        {

            Console.WriteLine($"{customer_name} {compute()}");
        }
    }

  

}
