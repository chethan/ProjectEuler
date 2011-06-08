using System.Numerics;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem53
    {
        public static long NumberOfCombinationsAboveOneMillion()
        {
            long aboveOneMillion = 0;
            for (BigInteger n = 1; n <= 100; n++)
            {
                for (BigInteger r = 1; r <= n / 2; r++)
                {
                    BigInteger ncr = MathUtils.Factorial(n) / (MathUtils.Factorial(r) * MathUtils.Factorial(n - r));
                    if(ncr > 1000000)
                    {
                        if(r != (n-r)) aboveOneMillion += 1;
                        aboveOneMillion += 1;
                    }
                }
            }
            return aboveOneMillion;
        }
    }
}