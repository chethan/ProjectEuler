using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem52
    {
        public static long CompareDigits()
        {
            long i = 1;
            for (long j = 1; j < Int64.MaxValue; j*=10)
            {
                for (i=j; i < i*10; i++)
                {
                    List<long> digits = GetDigits(i);
                    var numbers = new List<long> { 2 * i, 3* i, 4 * i, 5 * i,6*i };
                    if (GetDigits(6 * i).Count > digits.Count) break;
                    bool allEqual = true;
                    foreach (var number in numbers)
                    {
                        List<long> numDigits = GetDigits(number);

                        if (!numDigits.All(digits.Contains) || !digits.All(numDigits.Contains))
                        {
                            allEqual = false;
                            break;
                        }
                    }
                    if (allEqual) return i;
                }
            }
            return i;
        }

       public static List<long> GetDigits(BigInteger number)
        {
            BigInteger a = number;
            var digits=new List<long>();
            while (a!=0)
            {
                digits.Add((long)(a%10));
                a = a/10;
            }
            return digits;
        }
    }
}