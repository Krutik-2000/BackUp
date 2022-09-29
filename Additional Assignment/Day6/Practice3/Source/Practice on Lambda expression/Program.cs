using System;
using System.Linq;
namespace Practice_on_Lambda_expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");
            
        }
    }
}
