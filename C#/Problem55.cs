using System.Linq;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem55
    {
        public static int TotalLychrelNumbers()
        {
            int totalLychrelNumbers = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (IsLychrelNumber(i)) totalLychrelNumbers++;
            }
            return totalLychrelNumbers;
        }

        private static bool IsLychrelNumber(BigInteger num)
        {
            for (int i = 0; i < 49; i++)
            {
                num = num + Reverse(num);
                if (IsPalindrome(num)) return false;
            }
            return true;
        }

        private static bool IsPalindrome(BigInteger num)
        {
            return num == Reverse(num);
        }

        private static BigInteger Reverse(BigInteger num)
        {
            return BigInteger.Parse(new string(num.ToString().Reverse().ToArray()));
        }
    }
}