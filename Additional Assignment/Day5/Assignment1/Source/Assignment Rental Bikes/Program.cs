using System;
using System.Collections.Generic;
namespace Assignment_Rental_Bikes
{
    class Program
    {
        
        
        static void Main(string[] args)
        {

            List<Mobike> user = new List<Mobike>();

            while (true)
            {
                Console.WriteLine("Enter operation you want tto perform");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Delete");

                int i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Mobike mb = new Mobike();
                        mb.input();
                        user.Add(mb);
                        break;
                    case 2:
                        foreach (var item in user)
                        {
                            item.display();
                        }
                        break;

                    case 3:
                        Console.WriteLine("enter bike number");
                        string bi = Console.ReadLine();
                        Mobike deletedelement = null;
                        foreach (var item in user)
                        {
                            if (item.bike_number == bi)
                            {
                                deletedelement = item;
                            }

                        }
                        user.Remove(deletedelement);

                        break;
                    case 4:
                        Console.WriteLine("enter bike number");
                        string binum = Console.ReadLine();
              
                        foreach(var item in user)
                        {
                            if (item.bike_number == binum)
                            {
                                 item.display();
                            }
                            
                        }
                        
                        break;

                    case 5:
                        break;
                    default:
                        break;

                }

                if (i== 5)
                    {
                    break;
                    }
            }
               
            

        }

        
    }
}
