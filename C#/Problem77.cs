using System;
using System.Collections.Generic;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem77
    {
        public static int GeneratePrimeCombinations()
        {
            List<int> primeNumbesList = IOUtil.PrimeNumbesList();
            var allCombinations = new List<HashSet<Combination>>
                                      {
                                          new HashSet<Combination> { new Combination(new List<int> { -1 }) },
                                          new HashSet<Combination> { new Combination(new List<int> { 0 }) },
                                          new HashSet<Combination> { new Combination(new List<int> { 2 }) },
                                      };
            for (int i = 3; ; i++)
            {
                var combinations = new HashSet<Combination>();
                if (primeNumbesList.Contains(i)) combinations.Add(new Combination(new List<int> {i}));
                for (int j = 2; j < i; j++)
                {
                    if (!primeNumbesList.Contains(i - j)) continue;
                    foreach (var combination in allCombinations[j])
                    {
                        combinations.Add(new Combination(combination, i - j));
                    }
                }
                allCombinations.Add(combinations);
                Console.WriteLine("Combinations count for "+i+" "+ combinations.Count);
                if (combinations.Count > 5000) return i;
            }
            
        }

    }
}