using System;

namespace Assignment3_DateException
{
    class Program
    {
        public class DateException : Exception
        {
            public DateException(string message) : base(message)
            {

            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a Date");
            DateTime date = Convert.ToDateTime (Console.ReadLine());
            try
            {
                validate(date);
            }
            catch(DateException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        static void validate(DateTime date)
        {
            if(DateTime.Compare(date, DateTime.Today)<0)
            {
                throw new DateException("Date is not valid");
            }
            else
            {
                Console.WriteLine("Date is correct!");
            }
        }
            
        
    }
}

    
    
    
    
   

    

