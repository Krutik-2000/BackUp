using System;

namespace Practice_on_Errors_Exceptions
{
    public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; } set { _name = value; }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            if (p == null)
                return false;
            else
             
            return this.Name.Equals(p.Name);
        }
        }

    public class Example
    {
        public static void Main()
        {
            Person p1 = new Person();
            p1.Name = "Krutik";
            Person p2 = null;

            Console.WriteLine("p1 = p2 {0}", p1.Equals(p2));
        }
    }
}
