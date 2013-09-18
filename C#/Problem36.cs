using System;
using System.Numerics;
using System.Text;
using System.Linq;

namespace EulerProblem
{
    public static class Problem36
    {
        public static BigInteger SumOfAllPalindromes()
        {
            BigInteger total = 0;
            for (int i = 1; i < 1000000; i++)
            {
                string temp = i.ToString();
                if (temp.Equals(new string(temp.Reverse().ToArray())) && IsBinaryPalindrome(i)) total += i;
            }
            return total;
        }
        
        public static bool IsBinaryPalindrome(int base10Value)
        {

            var builder=new StringBuilder();
            while (base10Value!=0)
            {
                builder.Append(base10Value%2);
                base10Value /= 2;
            }
            string binaryString = builder.ToString();
            return binaryString.Equals(new string(binaryString.Reverse().ToArray()));
        } 
    }
}