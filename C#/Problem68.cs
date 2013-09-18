using System.Collections.Generic;
using System.Linq;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem68
    {
        public static string Magic5GonRing()
        {
            List<List<List<int>>> magic5GonValues =
                MathUtils.Permutations(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}).
                    Select(permutation => new List<List<int>>
                                              {
                                                  new List<int> {permutation[0], permutation[1], permutation[2]},
                                                  new List<int> {permutation[3], permutation[2], permutation[4]},
                                                  new List<int> {permutation[5], permutation[4], permutation[6]},
                                                  new List<int> {permutation[7], permutation[6], permutation[8]},
                                                  new List<int> {permutation[9], permutation[8], permutation[1]},
                                              }).ToList();
            return
                magic5GonValues.Where(IsMagic5Gon).Select(
                    solution =>
                    solution.Select(oneValue => oneValue.Aggregate("", (acc, i1) => acc + i1)).RotateWith(long.Parse).
                        Aggregate("", (acc, i1) => acc + i1)).Where(s => s.Length == 16).OrderByDescending(s => s).First();
        }

        private static bool IsMagic5Gon(List<List<int>> numbers)
        {
            int sum = numbers[0].Sum();
            return numbers.Select(ints => ints.Sum()).All(i => i == sum);
        }
    }
}