using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Linq;
using EulerProblem.Domain;

namespace EulerProblem
{
    public static class Problem155
    {
        public static BigInteger NumberOfDistinctCapacitences(int numberOfCapacitors, int capacitance)
        {
            var allDistinctCapacitances = new List<HashSet<Fraction>> {new HashSet<Fraction> {},new HashSet<Fraction> {new Fraction(capacitance,1)}};
            for (var i = 2; i <=numberOfCapacitors; i++)
            {
                var capacitances = new HashSet<Fraction>();
                for (var j = 1; j <= i/2; j++)
                {
                    foreach (var each in allDistinctCapacitances[j])
                    {
                        capacitances.Add(each); 
                        foreach (var second in allDistinctCapacitances[i-j])
                        {
                            capacitances.Add(second);
                            capacitances.Add(ConnectParallel(each, second));
                            capacitances.Add(ConnectSeries(each, second));
                        }
                    }
                }
                Console.WriteLine("No: "+i+" C: "+capacitances.Count);
                allDistinctCapacitances.Add(capacitances);

            }
            return allDistinctCapacitances[numberOfCapacitors].LongCount();
        }

        private static Fraction ConnectSeries(Fraction capacitance1, Fraction capacitance2)
        {
            return capacitance1.Add(capacitance2);
        }

        private static Fraction ConnectParallel(Fraction capacitance1, Fraction capacitance2)
        {
            return capacitance1.Reciprocal().Add(capacitance2.Reciprocal()).Reciprocal();
        }
    }
}