using System;
using System.Threading.Tasks;

namespace Practice_on_Async_and_await
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();
            Method2();
            Console.ReadKey();
        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Method1");
                    Task.Delay(10).Wait();
                }
            });
        }

        public static async Task Method2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine("Method2");
                    Task.Delay(10).Wait();
                }
            });
        }
    }
}
