using System;

namespace Practice_on_StringClass
{
    class Program
    {
        static void Main()
        {
            char[] chars = { 'w', 'o', 'r', 'd' };
            sbyte[] bytes = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

   
            string string1 = new string(chars);
            Console.WriteLine(string1);

            
            string string2 = new string('k', 20);
            Console.WriteLine(string2);

            string stringFromBytes = null;
            string stringFromChars = null;
            unsafe
            {
                fixed (sbyte* pbytes = bytes)
                {
                    
                    stringFromBytes = new string(pbytes);
                }
                fixed (char* pchars = chars)
                {
                   
                    stringFromChars = new string(pchars);
                }
            }
            Console.WriteLine(stringFromBytes);
            Console.WriteLine(stringFromChars);
           

        }
    }
}
