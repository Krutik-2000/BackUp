using System;
using System.Collections.Generic;
namespace Practice2_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> Age = new Stack<int>();
            Age.Push(21);
            Age.Push(19);
            Age.Push(17);

            foreach(int A in Age)
            {
                Console.WriteLine(A);
            }
        }
    }
}
