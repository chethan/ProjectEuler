using System;
using System.Numerics;
using System.Linq;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem30
    {
        public static BigInteger SumOfFifthPowers()
        {
            BigInteger total = 0;
            for (int i = 11; i < 354294; i++)
            {
                if (MathUtils.GetDigits(i).Sum(l => Math.Pow(l,5)) == i) total += i;
            }
            return total;
        }
    }
}