using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Employee> employees = new List<Employee>
            {
                new Employee(){ ID=1,FirstName="John",LastName="Abraham",Salary=1000000,JoiningDate=new DateTime(2013,1,1,12,0,0),Deparment="Banking"}, 
                new Employee(){ID=2,FirstName="Michael",LastName="Clarke",Salary=800000,JoiningDate=new DateTime(2013,1,1,12,0,0),Deparment="Insurance"}, 
                new Employee(){ID=3,FirstName="Roy",LastName="Thomas",Salary=700000,JoiningDate=new DateTime(2013,2,1,12,0,0),Deparment="Banking"}, 
                new Employee(){ID=4,FirstName="Tom",LastName="Jose",Salary=600000,JoiningDate=new DateTime(2013,2,1,12,0,0),Deparment="Insurance"}, 
                new Employee(){ID=5,FirstName="Jerry",LastName="Pinto",Salary=650000,JoiningDate=new DateTime(2013,2,1,12,0,0),Deparment="Insurance"},
                new Employee(){ID=6,FirstName="Philip",LastName="Mathew",Salary=750000,JoiningDate=new DateTime(2013,1,1,12,0,0),Deparment="Services"},
                new Employee(){ID=7,FirstName="TestName1",LastName="123",Salary=650000,JoiningDate=new DateTime(2013,1,1,12,0,0),Deparment="Services"},
                new Employee(){ID=8,FirstName="TestName2",LastName="Lname%",Salary=600000,JoiningDate=new DateTime(2013,2,1,12,0,0),Deparment="Insurance"},
            
            };

            List<Incentive> incentives = new List<Incentive>() { 
                new Incentive() { ID = 1, IncentiveAmount = 5000, IncentiveDate = new DateTime(2013, 02, 01) }, 
                new Incentive() { ID = 2, IncentiveAmount = 3000, IncentiveDate = new DateTime(2013, 02, 01) }, 
                new Incentive() { ID = 3, IncentiveAmount = 4000, IncentiveDate = new DateTime(2012, 02, 01) }, 
                new Incentive() { ID = 1, IncentiveAmount = 4500, IncentiveDate = new DateTime(2012, 01, 01) },
                new Incentive() { ID = 2, IncentiveAmount = 3500, IncentiveDate = new DateTime(2012, 01, 01) }
            };



            //1. Get all employee details from the employee table
            var query1 = from e1 in employees
                         select e1;

            query1.ToList().ForEach(e1 => Console.WriteLine($"Employee Details (ID: {e1.ID} FirstName: {e1.FirstName} LastName: {e1.LastName} Salary: {e1.Salary} JD: {e1.JoiningDate} Department: {e1.Deparment} "));
            Console.WriteLine("**********************************01***************************************");

            //2. Get First_Name, Last_Name from employee table

            var query2 = from e2 in employees
                         select new { e2.FirstName, e2.LastName };

            query2.ToList().ForEach(e2 => Console.WriteLine($"Employee's Firstname: {e2.FirstName} Lastname: {e2.LastName}"));
            Console.WriteLine("**********************************02***************************************");

            //3. Get First_Name from employee table using alias name “Employee Name”

            var query3 = from e3 in employees
                         select  e3.FirstName ;

            foreach (var item in query3)
            {
                Console.WriteLine($"Employee Name: { item}");
            }
            Console.WriteLine("*********************************03****************************************");
            //4. Select first 3 characters of FIRST_NAME from EMPLOYEE.

            var query4 = from e4 in employees
                         select (e4.FirstName);
            int found = 0;
            
            foreach (string item in query4)
            {
                found = item.IndexOf(": ");
                Console.WriteLine( "Employee's FirstName: {0}", item.Substring(found + 1,3));
            }
            Console.WriteLine("*****************************04********************************************");
            //5. Get First_Name from employee table in upper case

            var query5 = from e5 in employees
                         select e5.FirstName;
            foreach (var item in query5)
            {
                Console.WriteLine("Employee's FirstName: {0}",item.ToUpper());
            }
            Console.WriteLine("******************************05*******************************************");
            //6.  Get First_Name from employee table in lower case
            var query6 = from e6 in employees
                         select e6.FirstName;
            foreach (var item in query6)
            {
                Console.WriteLine("Employee's FirstName: {0}", item.ToLower());
            }
            Console.WriteLine("********************************06*****************************************");

            //7. Get unique DEPARTMENT from employee table

          

            var query7 = (from e7 in employees
                         select e7.Deparment).Distinct();

            //query7.ToList().ForEach(e7 => Console.WriteLine("Employee's Department: {0}", e7.Distinct()));

            foreach (var i in query7)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*******************************07******************************************");
            //8. Get position of 'o' in name 'John' from employee table
            var query8 = from e8 in employees
                         where e8.FirstName == "John"
                         select e8.FirstName;
            //query8.ToList().ForEach(e8 => Console.WriteLine("Employee's Department: {0}", e8.IndexOf("o")));
            foreach (var i in query8)
            {
                Console.WriteLine("Index of character 'o' is " + i.IndexOf("o"));
            }
            Console.WriteLine("*********************************08****************************************");

            //9. Get FIRST_NAME from employee table after removing white spaces from right side
            var query9 = from e9 in employees
                         select e9.FirstName;

            foreach (var item in query9)
            {
                Console.WriteLine("Employee's Name: {0}", item.TrimEnd());
            }
            Console.WriteLine("*********************************09****************************************");
            //10. Get FIRST_NAME from employee table after removing white spaces from left side
            var query10 = from e10 in employees
                         select e10.FirstName;

            foreach (var item in query10)
            {
                Console.WriteLine("Employee's Name: {0}", item.TrimStart());
            }
            Console.WriteLine("**********************************10***************************************");
            //11. Get length of FIRST_NAME from employee table
            var query11 = from e11 in employees
                          select e11.FirstName;
            foreach (var item in query11)
            {
                Console.WriteLine("Employee's Name: {0}", item.Length);
            }
            Console.WriteLine("************************************11*************************************");

            //12. Get First_Name from employee table after replacing 'o' with '$'
            var query12 = from e12 in employees
                          select e12.FirstName;
            foreach (var item in query12)
            {
                Console.WriteLine("Employee's Name: {0}", item.Replace("o","$"));
            }
            Console.WriteLine("************************************12*************************************");

            //13. Get First_Name and Last_Name as single column from employee table separated by a '_'
            var query13 = from e13 in employees
                          select new{ e13.FirstName, e13.LastName};
            query13.ToList().ForEach(e13 => Console.WriteLine($"Employees FullName: {e13.FirstName}_{e13.LastName}"));
            Console.WriteLine("*************************************13************************************");

            //14. Get FIRST_NAME ,Joining year,Joining Month and Joining Date from employee table
            var query14 = from e14 in employees
                          select e14;
            foreach (var item in query14)
            {
                Console.WriteLine($"Employee's  (Name:{item.FirstName} JoiningDate: {item.JoiningDate} JoiningYear: {item.JoiningDate.Year} JoiningMonth: {item.JoiningDate.Month}");
            }
            Console.WriteLine("********************************14*****************************************");
            //15. Get all employee details from the employee table order by First_Name Ascending
            var query15 = from e15 in employees
                          orderby e15.FirstName ascending
                          select e15 ;
            foreach (var item in query15)
            {
                Console.WriteLine("Employee's Name in ascending order: " + item.FirstName);
            }
            Console.WriteLine("********************************15*****************************************");

            //16. Get all employee details from the employee table order by First_Name descending
            var query16 = from e16 in employees
                          orderby e16.FirstName descending
                          select e16;
            foreach (var item in query16)
            {
                Console.WriteLine("Employee's Name in ascending order: " + item.FirstName);
            }
            Console.WriteLine("**********************************16***************************************");
            //17. Get all employee details from the employee table order by First_Name Ascending and Salary descending
            var query17 = from e17 in employees
                          orderby e17.Salary descending
                          select new { e17.FirstName , e17.Salary};
            // It sorts the collection in ascending order by default because ascending keyword is optional here.
            foreach (var item in query17)
            {
                Console.WriteLine("Employee's Name in Ascending and Salary in Descending    " + item.FirstName+" " + item.Salary);
            }
            Console.WriteLine("***********************************17**************************************");
            //18. Get employee details from employee table whose employee name is “John”
            
                var query18 = from e18 in employees
                              where e18.FirstName == "John" 
                              select e18;
                foreach (var item in query18)
                {
                      Console.WriteLine("Employee Details: "+item);    
            }
            Console.WriteLine("***********************************18**************************************");
            // 19.Get employee details from employee table whose employee name are “John” and “Roy”
            var query19 = employees.Where(e19 => e19.FirstName == "John" || e19.FirstName == "Roy");
            foreach (var item in query19)
            {
                Console.WriteLine("Employee Details: " + item);
            }
            Console.WriteLine("*********************************19****************************************");
            //20. Get employee details from employee table whose employee name are not “John” and “Roy”
            var query20 = employees.Where(e20 => e20.FirstName != "John" && e20.FirstName != "Roy");
            foreach (var item in query20)
            {
                Console.WriteLine("Employee Details: " + item);
            }
            Console.WriteLine("**********************************20***************************************");
            //21. Get employee details from employee table whose first name starts with 'J'
            var query21 = employees.Where(e21 => e21.FirstName.StartsWith("J"));
            foreach (var item in query21)
            {
                Console.WriteLine("Employee whose firstname starts with 'o' " + item);
            }
            Console.WriteLine("***********************************21**************************************");
            //22. Get employee details from employee table whose first name contains 'o'
            var query22 = employees.Where(e22 => e22.FirstName.Contains("o"));
            foreach (var i in query22)
            {
                Console.WriteLine("Employee whose firstname contains 'o' "+ i);
            }
            Console.WriteLine("***********************************22**************************************");

            //23. Get employee details from employee table whose first name ends with 'n'
            var query23 = employees.Where(e23 => e23.FirstName.EndsWith("n"));
            foreach (var i in query23)
            {
                Console.WriteLine("Employee whose firstname ends with 'n' " + i);
            }
            Console.WriteLine("*********************************23****************************************");

            //24. Get employee details from employee table whose first name ends with 'n' and name contains 4 letters
            var query24 = employees.Where(e24 => e24.FirstName.EndsWith("n") && e24.FirstName.Length<=4);
            foreach (var i in query24)
            {
                Console.WriteLine("Employee whose firstname Startwith 'n' and name contains 4 letters" + i);
            }
            Console.WriteLine("*********************************24****************************************");

            //25. Get employee details from employee table whose first name starts with 'J' and name contains 4 letters
            var query25 = employees.Where(e25 => e25.FirstName.StartsWith("J") && e25.FirstName.Length <= 4);
            foreach (var i in query25)
            {
                Console.WriteLine("Employee whose firstname Startwith 'J'  and name contains 4 letters" + i);
            }
            Console.WriteLine("********************************25*****************************************");

            //26. Get employee details from employee table whose Salary greater than 600000
            var query26 = from e26 in employees
                          where e26.Salary > 600000
                          select e26;
            query26.ToList().ForEach(e26 => Console.WriteLine($"Employee Details {e26}"));
            Console.WriteLine("********************************26*****************************************");

            //27. Get employee details from employee table whose Salary less than 800000
            var query27 = from e27 in employees
                          where e27.Salary < 800000
                          select e27;
            query27.ToList().ForEach(e27 => Console.WriteLine($"Employee Details {e27}"));
            Console.WriteLine("*********************************27****************************************");

            //28. Get employee details from employee table whose Salary between 500000 and 800000
            var query28 = employees.Where(e28 => e28.Salary > 500000 && e28.Salary < 800000);
            foreach (var item in query28)
            {
                Console.WriteLine($"Employee Details {item}");
            }
            Console.WriteLine("*********************************28****************************************");

            //29. Get employee details from employee table whose name is 'John' and 'Michael'
            var query29 = employees.Where(e29 => e29.FirstName == "John" || e29.FirstName == "Michael");
            foreach (var item in query29)
            {
                Console.WriteLine($"Employee Details: {item}");
            }
            Console.WriteLine("*********************************29****************************************");

            //30. Get employee details from employee table whose joining year is “2013”
            var query30 = employees.Where(e30 => e30.JoiningDate.Year == 2013);
            foreach (var item in query30)
            {
                Console.WriteLine($"Employee Details whose joining year is 2013 {item}");
            }
            Console.WriteLine("**********************************30***************************************");
            //31. Get employee details from employee table whose joining month is “January”
            var query31 = employees.Where(e31 => e31.JoiningDate.Month == 1);
            foreach (var item in query31)
            {
                Console.WriteLine($"Employee Details whose joining month is “January” {item}");
            }
            Console.WriteLine("**********************************31***************************************");

            //32. Get employee details from employee table who joined before January 31st 2013
            DateTime before = new DateTime(2013, 01, 31);

            var query32 = employees.Where(e32 => e32.JoiningDate.Date < before );
            foreach (var item in query32)
            {
                Console.WriteLine($"Employee Details whose joining before January 31st 2013 {item}");
            }
            Console.WriteLine("**********************************32***************************************");

            //33. Get employee details from employee table who joined after January 31st 2013
            DateTime after = new DateTime(2013, 01, 31);

            var query33 = employees.Where(e33 => e33.JoiningDate.Date > after);
            foreach (var item in query33)
            {
                Console.WriteLine($"Employee Details whose joining after January 31st 2013 {item}");
            }
            Console.WriteLine("********************************33*****************************************");

            //34. Get Joining Date and Time from employee table

            var query34 = from e34 in employees
                          select e34.JoiningDate;

            query34.ToList().ForEach(e34 => Console.WriteLine($"Joining Date and Time: {e34}"));
            Console.WriteLine("********************************34*****************************************");


            //35. Get Joining Date,Time including milliseconds from employee table
            var query35 = employees.Select(e35 => e35.JoiningDate);

            query35.ToList().ForEach(e35 => Console.WriteLine($"Joining Date and Time  : {e35} and miliseconds: {e35.Millisecond}"));
            Console.WriteLine("*******************************35******************************************");

            //36. Get difference between JOINING_DATE and INCENTIVE_DATE from employee and incentives table
            var query36 = employees.Join(incentives, employees => employees.ID, incentives => incentives.ID, (employees, incentives) => new { JD = employees.JoiningDate, ID = incentives.IncentiveDate, diff = incentives.IncentiveDate.Subtract(employees.JoiningDate) });
            query36.ToList().ForEach(e36 => Console.WriteLine($"Diff between JOINING_DATE and INCENTIVE_DATE {e36}"));
            Console.WriteLine("*********************************36****************************************");
            //37. Get database date
            var query37 = DateTime.Now;
            Console.WriteLine(query37);
            Console.WriteLine("*********************************37****************************************");
            //38. Get names of employees from employee table who has '%' in Last_Name. 
            var query38 = employees.Where(e38 =>e38.LastName.Contains("%"));
            foreach (var item in query38)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("********************************38*****************************************");
            //39. Get Last Name from employee table after replacing special character with white space
            var query39 = from e39 in employees
                          select e39.LastName;
            foreach (var item in query39)
            {
                Console.WriteLine("Employee's LastName: {0}", item.Replace("%", " "));
            }
            Console.WriteLine("********************************39*****************************************");
            //40. Get department,total salary with respect to a department from employee table.
            var query40 = employees.GroupBy(e40 => e40.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                TotalSalary = Depart.Sum(s => s.Salary)
            });

            foreach (var item in query40)
            {
                Console.WriteLine($"total salary with respect to a department:- Departmet: {item.Key} => TotalSalary: {item.TotalSalary}");
            }
            Console.WriteLine("******************************40*******************************************");

            //41. Get department,total salary with respect to a department from employee table order by total salary descending
            var query41 = employees.GroupBy(e41 => e41.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                TotalSalary = Depart.Sum(s => s.Salary)
            }).OrderByDescending(a => a.TotalSalary);

            foreach (var item in query41)
            {
                Console.WriteLine($"total salary with respect to a department:- Department: {item.Key} => TotalSalary: {item.TotalSalary}");
            }
            Console.WriteLine("*******************************41******************************************");

            //42. Get department.no of employees in a department,total salary with respect to a department from employee table order by total salary descending
            var query42 = employees.GroupBy(e42 => e42.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                TotalSalary = Depart.Sum(s => s.Salary),
                emp = Depart.Count()

            }).OrderByDescending(a => a.TotalSalary); 
            foreach (var item in query42)
            {
                Console.WriteLine($"total salary with respect to a department:- Departmet: {item.Key} => TotalSalary: {item.TotalSalary} => no of emp in depart : {item.emp}");
               
            }
            Console.WriteLine("*******************************42******************************************");

            //43. Get department wise average salary from employee table order by salary ascending
            var query43 = employees.GroupBy(e43 => e43.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                AvgSalary = Depart.Average(a => a.Salary)
            }).OrderBy(a => a.AvgSalary);
            foreach (var item in query43)
            {
                Console.WriteLine($"Department: {item.Key} => Average Salary: {item.AvgSalary}");
            }
            Console.WriteLine("********************************43*****************************************");
            //44. Get department wise maximum salary from employee table order by salary ascending
            var query44 = employees.GroupBy(e44 => e44.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                MaxSalary = Depart.Max(a => a.Salary)
            }).OrderBy(a => a.MaxSalary);
            foreach (var item in query44)
            {
                Console.WriteLine($"Department: {item.Key} => Maximum Salary: {item.MaxSalary}");
            }
            Console.WriteLine("*******************************44******************************************");

            //45. Get department wise minimum salary from employee table order by salary ascending
            var query45 = employees.GroupBy(e45 => e45.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                MinSalary = Depart.Min(a => a.Salary)
            }).OrderBy(a => a.MinSalary);
            foreach (var item in query45)
            {
                Console.WriteLine($"Department: {item.Key} => Minimum Salary: {item.MinSalary}");
            }
            Console.WriteLine("*******************************45******************************************");

            //46. Select no of employees joined with respect to year and month from employee table
            var query46 = employees.GroupBy(e46 => e46.JoiningDate).Select(JD => new
            {
                Key = JD.Key.Year,
                Key2 = JD.Key.Month,
                Totalemp = JD.Count()
            });
            foreach (var item in query46)
            {
                Console.WriteLine($"Joining Year: {item.Key} Month: {item.Key2} TotalEmployees : {item.Totalemp}");
            }
            Console.WriteLine("********************************46*****************************************");
            //47. Select department,total salary with respect to a department from employee table
            var query47 = employees.GroupBy(e47 => e47.Deparment).Select(Depart => new
            {
                Key = Depart.Key,
                TotalSalary = Depart.Sum(S => S.Salary)
            });
            foreach (var item in query47)
            {
                Console.WriteLine($"Total Salary with respect to Department: {item.Key} TotalSalary: {item.TotalSalary}");
            }
            Console.WriteLine("*********************************47****************************************");
            //48. Select first_name, incentive amount from employee and incentives table for those employees who have incentives
            var query48 = employees.Join(incentives, employees => employees.ID, incentives => incentives.ID, (employees, incentives) => 
            new { Name = employees.FirstName, IncentiveAmount = incentives.IncentiveAmount });
            foreach (var item in query48)
            {
                Console.WriteLine($"First_Name : {item.Name} => IncentiveAmount: {item.IncentiveAmount}");
            }
            Console.WriteLine("**********************************48***************************************");

            //49. Select first_name, incentive amount from employee and incentives table for those employees who have incentives and incentive amount greater than 3000
            var query49 = employees.Join(incentives, employees => employees.ID, incentives => incentives.ID, (employees, incentives) =>
           new { Name = employees.FirstName, IncentiveAmount = incentives.IncentiveAmount > 3000}
           
           );
            foreach (var item in query49)
            {
                Console.WriteLine($"First_Name : {item.Name} => IncentiveAmount: {item.IncentiveAmount} incentive amount greater than 3000");
            }
            Console.WriteLine("*********************************49****************************************");
            //50. Select first_name, incentive amount from employee and incentives table for all employed even if they didn't get incentives.
            var query50 = from first_name in employees
                          join incentive in incentives on first_name.ID equals incentive.ID
                          into first from subincetive in first.DefaultIfEmpty()
                          select new {
                              first_name.FirstName, allemp = subincetive?.IncentiveAmount 
            };
                foreach (var item in query50)
            {
                Console.WriteLine($"First_Name : {item.FirstName} => IncentiveAmount: {item.allemp} ");
                
            }
            Console.WriteLine("******************************50*******************************************");

            //51. Select first_name, incentive amount from employee and incentives table for all employees even if they didn't get incentives and set incentive amount as 0 for those employees who didn't get incentives.
            var query51 = from first_name in employees
                          join incentive in incentives on first_name.ID equals incentive.ID
                          into first
                          from subincetive in first.DefaultIfEmpty()
                          select new
                          {
                              first_name.FirstName,
                              allemp = subincetive?.IncentiveAmount
                          };
            foreach (var item in query50)
            {
                Console.WriteLine($"First_Name : {item.FirstName} => IncentiveAmount: {item.allemp} ");

            }
            Console.WriteLine("******************************51*******************************************");

        }

    }
}
    

