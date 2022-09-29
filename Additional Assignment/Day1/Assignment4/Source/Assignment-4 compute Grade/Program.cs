using System;

namespace Assignment_4_compute_Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            Students[] student = new Students[10];

            for (int i = 0; i < 10; i++)
            {
                Students temp = new Students();
                Console.WriteLine("Enter Your Name:");
                temp.Name = Console.ReadLine();
                Console.WriteLine("Enter Your Address:");
                temp.Address = Console.ReadLine();
                Console.WriteLine("Enter Your Hindi Marks:");
                temp.Hindi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Your English Marks:");
                temp.English = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Your Maths Marks:");
                temp.Maths = Convert.ToInt32(Console.ReadLine());

                student[i] = temp;
            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.Write("Name  Address  Hindi  English  Math  Total  Grade");
            Console.WriteLine("------------------------------------------------------------------");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(student[i].Name + "  ");
                Console.Write(student[i].Address + "  ");
                Console.Write(student[i].Hindi + "  ");
                Console.Write(student[i].English + "  ");
                Console.Write(student[i].Maths + "  ");
                Console.Write(student[i].Total + "  ");
                Console.Write(student[i].Grade + "  ");
                Console.WriteLine("                                                                ");
            }
        }
    }
}