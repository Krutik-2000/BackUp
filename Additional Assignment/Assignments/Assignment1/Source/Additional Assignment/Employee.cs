﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_Assignment
{
    
    class Employee
    { 
        public int ID { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public double Salary { get; set; } 
        public DateTime JoiningDate { get; set; } 
        public string Deparment { get; set; }

        public override string ToString()
        {
            return ID + " " + FirstName + " " + LastName + " " + Salary + " " + JoiningDate + " " + Deparment;
        }
    }

   
   
}
