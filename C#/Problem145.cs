using System;
using System.Linq;
using System.Numerics;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem145
    {
        public static long TotalReversibleNumbers()
        {
            long total=0;
            for (BigInteger i = 0; i < 1000000000; i++)
            {
                if (IsReversible(i))
                {
                    Console.WriteLine(i);
                    total += 1;
                }
            }
            return total;
        }
        
        public static bool IsReversible(BigInteger num)
        {
            BigInteger bigInteger = num+BigInteger.Parse(new string(num.ToString().Reverse().ToArray()));
            return bigInteger.GetDigits().All(l => l%2==1);
        }
    }
}