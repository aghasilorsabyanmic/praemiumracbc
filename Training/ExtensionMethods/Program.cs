using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "Anna";
            var s2 = "anna";

            Console.WriteLine(s1.IsPolindrome());
            Console.WriteLine(s2.IsPolindrome(true));
        }
    }
}
