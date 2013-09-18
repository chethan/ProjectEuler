using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace EulerProblem
{
    public static class Problem21
    {
        public static long SumOfAmicablePairs()
        {
            long total = 0;
            for (int i = 2; i < 10000; i++)
            {
                int sum = GetSumOfProperDivisors(i);
                if(i==sum) continue;
                int sumOfProperDivisors = GetSumOfProperDivisors(sum);
                if (i == sumOfProperDivisors) total += i;
            }
            return total;
        }

        private static int GetSumOfProperDivisors(int i)
        {
            List<BigInteger> bigIntegers = Problem12.GetDivisors(i);
            bigIntegers.Remove(i);
            return bigIntegers.Sum(integer => (int)integer);
        }
    }
}