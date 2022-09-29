using System;
using System.Collections.Generic;
namespace Practice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var Map = new Dictionary<string, int>();
            Map.Add("Ring", 50000);
            Map.Add("NeckLess", 7500000);
            Map.Add("Pendent", 5000);
            Map.Add("ANkles", 10000);
            Console.WriteLine("Priducts With it's Price");
            foreach (var i in Map)
            {
                Console.WriteLine(i);
            }
            int P;
            if (Map.TryGetValue("Ring", out P))
            {
                Console.WriteLine($"Price of the Ring is : {P}");
            }
            int Price = Map["Pendent"];
            Console.WriteLine($"Price of the Pendent is : {Price}");

        }
    }
}
    