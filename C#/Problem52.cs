using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EulerProblem.Utils;

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
                    List<int> digits = i.GetDigits();
                    var numbers = new List<long> { 2 * i, 3* i, 4 * i, 5 * i,6*i };
                    if ((6 * i).GetDigits().Count > digits.Count) break;
                    bool allEqual = true;
                    foreach (var number in numbers)
                    {
                        List<int> numDigits = number.GetDigits();

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
    }
}