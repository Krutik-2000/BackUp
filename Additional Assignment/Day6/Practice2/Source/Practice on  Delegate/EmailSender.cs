using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_on__Delegate
{
    public class EmailSender
    {
        private int sendResult;
        public int SendEmail()
        {
            Console.WriteLine("Simulating sending emai");
            sendResult = 0;
            return sendResult;
        }
    }
}
