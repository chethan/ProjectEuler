using System;
using System.Collections.Generic;
using System.Linq;
using EulerProblem.Domain;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem34
    {
        private static readonly Dictionary<int,int> Factorials = new Dictionary<int, int>(10); 
        
        public static long SumOfAllFactorions()
        {
            return Factorions().Sum();
        }
        
        private static IEnumerable<long> Factorions()
        {
            var allCuriousNumbers = new List<long>();
            const long LIMIT = 362880*6;
            for (long i = LIMIT; i >= 10; i--)
            {
               var digits = i.GetDigits();
               if(digits.Select(GetCachedFactorial).Sum()==i)
               {
                   allCuriousNumbers.Add(i);
               }
            }
            return allCuriousNumbers;
        }

        private static int GetCachedFactorial(int num)
        {
            if (!Factorials.ContainsKey(num)) Factorials[num]=Convert.ToInt32(MathUtils.Factorial(num).ToString());
            return Factorials[num];
        }
    }
}