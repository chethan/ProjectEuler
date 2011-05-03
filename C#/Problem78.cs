using System;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem78
    {
        public static int LeastNumberDivisable(BigInteger num)
        {
            for (int i = 1;; i++)
            {
                BigInteger totalNumberOfCombinations = Problem76.TotalNumberOfCombinations(i);
                if (totalNumberOfCombinations > num && totalNumberOfCombinations % num == 0) return i;
            }
        }
    }
}