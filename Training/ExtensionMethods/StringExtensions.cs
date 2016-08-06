using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsPolindrome(this string s, bool ignoreCase = false)
        {
            if(ignoreCase)
            {
                s = s.ToLower();
            }
            
            var reverse = new string(s.Reverse().ToArray());
            return reverse == s;
        }
    }
}
