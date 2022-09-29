using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_on_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] scores = { 97, 92, 81, 60 };

            
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            
        }
    }
}
