using System.Collections.Generic;
using System.Linq;
using EulerProblem.Domain;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem57
    {
        public static int CountOfExpansions()
        {
            return GenerateExpansions(1000).Count(CompareNumeratorWithDenominator);
        }

        private static IEnumerable<Fraction> GenerateExpansions(int n)
        {
            var expansions = new List<Fraction> {new Fraction(1, 2)};
            for (int i = 1; i < n; i++)
            {
                var fraction = new Fraction(expansions[i - 1].Denominator,
                                            2*expansions[i - 1].Denominator + expansions[i - 1].Numerator);
                expansions.Add(fraction);
            }
            return expansions;
        }

        private static bool CompareNumeratorWithDenominator(Fraction fraction)
        {
            Fraction newFraction = fraction.Add(1);
            return newFraction.Numerator.GetDigits().Count > newFraction.Denominator.GetDigits().Count;
        }
    }
}