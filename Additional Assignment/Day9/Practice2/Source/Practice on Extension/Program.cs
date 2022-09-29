using System;
using System.Linq;

namespace Practice_on_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 10, 45, 15, 39, 55, 25 };
            var result = ints.OrderBy(f => f);
            foreach (var item in result)
            {
                System.Console.WriteLine(item + " ");
            }
        }
    }
}
