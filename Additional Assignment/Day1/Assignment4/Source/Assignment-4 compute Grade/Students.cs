// Accept 10 student Name,Address,Hindi,English,Maths Marks ,do the Total and compute Grade. 
//Note do it with Array and display the result in grid format
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_compute_Grade
{
    class Students
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Hindi { get; set; }

        public int English { get; set; }

        public int Maths { get; set; }

        public int Total { get { return Compute(); } }


        public int Compute()
        {
            return Hindi + English + Maths;
        }

        public char Grade 
        {
            get
            {
                if ((Total / 3) >= 90)
                {
                    return 'A';
                }
                else if((Total / 3)>=75)
                {
                    return 'B';
                }
                else if((Total / 3) >= 65)
                {
                    return 'C';
                }
                else if((Total / 3) >=35)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }
        }
    }
}
