using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem56
    {
        public static long MaximumDigitalSum()
        {
            long maxSum = 0;
            for (int a = 0; a < 100; a++)
            {
                for (int b = 0; b < 100; b++)
                {
                    var digits = Problem52.GetDigits(BigInteger.Pow(a,b));
                    var sum = digits.Sum();
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        Console.WriteLine(maxSum);
                    }
                }
            }
            return maxSum;
        }
    }
}