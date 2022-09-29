using System;

namespace Assignment_2_vowel_char
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            String Name = "Krutik";
            int count = 0;
            for(int i=0; i < Name.Length; i++)
            {
                if(Name[i]=='a' || Name[i]=='A' || Name[i] =='e' || Name[i] =='E' || Name[i] =='i' || Name[i] =='I' || Name[i] =='o' || Name[i] =='O' || Name[i] == 'u'|| Name[i] == 'U')
                {
                    count++;
                }
            }
            Console.WriteLine($"Total Vowels in the string:{count}" );
            Console.ReadKey();
        }
    }
}
