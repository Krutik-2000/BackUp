
// Exception Handling 
using System;

namespace Practice_on_ExceptionClass
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 0;

            try
            {
                int B = 100 / A;
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine($"ArithmeticException Handler: {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic Exception Handler: {e}");
            }
        }
    }
}
