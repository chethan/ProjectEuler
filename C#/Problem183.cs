using System;
using System.Numerics;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem183
    {
        public static int SummationOfDofN(int lowerLimit,int higherLimit)
        {
            int sum = 0;
            for (var i = lowerLimit; i <=higherLimit; i++)
            {
                sum += DofN(i);
            }
            return sum;
        }

        private static int DofN(int number)
        {
            return IsTerminatingDecimal(PartsMax(number)) ? -number : number;
        }


        private static BigInteger PartsMax(int number)
        {
            const double E = 2.718281828;
            var i = (int) Math.Round(number / E);
            return i/MathUtils.GCD(i,number);
        }
        
        private static bool IsTerminatingDecimal(BigInteger denominator)
        {
            while (denominator % 2 == 0) denominator = denominator/2;
            while (denominator % 5 == 0) denominator = denominator/5;
            return denominator == 1;
        }
    }
}