﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Linq;

namespace EulerProblem.Utils
{
    public static class MathUtils
    {
        public static BigInteger GCD(BigInteger number1, BigInteger number2)
        {
            while (number1 % number2 != 0)
            {
                BigInteger temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }
            return number2;
        }

        public static List<long> PrimeFactors(this long num)
        {
            var primeFactors = new List<long>();
            var primeNumbesList = IOUtil.PrimeNumbesList();
            while (true)
            {
                if(primeNumbesList.Contains(num))
                {
                    primeFactors.Add(num);
                    break;
                }

                var primeFactor = primeNumbesList.First(l => num%l == 0);
                primeFactors.Add(primeFactor);
                num = num/primeFactor;
            }
            return primeFactors;
        } 

        public static long DigtialRoot(this long number)
        {
            while (number>=10)
            {
                number = number.GetDigits().Sum();
            }
            return number;
        }

        public static List<int> GetDigits(this BigInteger number)
        {
            BigInteger a = number;
            var digits = new List<int>();
            while (a != 0)
            {
                digits.Add((int)(a % 10));
                a = a / 10;
            }
            return digits;
        }

        public static List<int> GetDigits(this long number)
        {
           return GetDigits((BigInteger)number);
        }

        public static List<List<int>> Permutations(List<int> list)
        {
            if (list.Count == 1) return new List<List<int>> {new List<int> {list[0]}};
            var allPermutations = new List<List<int>>();
            for (int i = 0; i < list.Count; i++)
            {
                List<List<int>> permutations = Permutations(list.Where((i1,index) => index!=i).ToList());
                permutations.ForEach(ints => ints.Add(list[i]));
                allPermutations.AddRange(permutations);
            }
            return allPermutations;
        } 

        public static IEnumerable<T> RotateWith<T,TKey>(this IEnumerable<T> enumeration, Func<T, TKey> func)
        {
            var first = enumeration.OrderBy(func).First();
            return enumeration.SkipWhile(arg => !arg.Equals(first)).Concat(enumeration.TakeWhile(arg => !arg.Equals(first)));
        }

        public static BigInteger Factorial(BigInteger num)
        {
            BigInteger factorial = 1;
            if (num == 0) return 1;
            while (num!=1)
            {
                factorial *= num;
                num -= 1;
            }
            return factorial;
        }
    }
}