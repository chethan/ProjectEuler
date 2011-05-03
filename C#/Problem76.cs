using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace EulerProblem
{
    public static class Problem76
    {
        private static readonly IDictionary<int,BigInteger> Cache= new Dictionary<int,BigInteger>();

        //refer wikipedia for number partitioning: p(k) = p(k − 1) + p(k − 2) − p(k − 5) − p(k − 7) + p(k − 12) + p(k − 15) − p(k − 22)
        public static BigInteger TotalNumberOfCombinations(int n)
        {
            if(n==0) return 1;
            if(n<0) return 0;

            if (Cache.ContainsKey(n)) return Cache[n];
            BigInteger totalCombinations = 0;
            for (int i = 1,sign = 1; ; i++,sign *=-1)
            {
                int i1 = n - NextTerm(i);
                if(i1<0) break;
                totalCombinations+=TotalCombinations(sign, i1);
                i1 = n - NextTerm(-i);
                if (i1 < 0) break;
                totalCombinations +=TotalCombinations(sign, i1);
            }
            return totalCombinations;
        }

        public static HashSet<Combination> GenerateCombinations(int n)
        {
            var allCombinations = new List<HashSet<Combination>>{new HashSet<Combination>{new Combination(new List<int>{0})}};
            for (int i = 1; i <= n; i++)
            {
                var combinations = new HashSet<Combination>();
                for (int j = 0; j < i; j++)
                {
                    foreach (var combination in allCombinations[j])
                    {
                        combinations.Add(new Combination(combination, i - j));
                    }
                }
                allCombinations.Add(combinations);
            }
            return allCombinations[n];
        }

        private static BigInteger TotalCombinations(int sign, int i1)
        {
            BigInteger totalNumberOfCombinations = TotalNumberOfCombinations(i1);
            Cache[i1] = totalNumberOfCombinations;
            return (sign*totalNumberOfCombinations);
        }

        private static int NextTerm(int i)
        {
            return Math.Abs((i*(3*i - 1))/2);
        }
    }

    public class Combination
    {
        private readonly List<int> values;

        public Combination(List<int> values)
        {
            this.values = values;
        }

        public Combination(Combination combination,int newValue)
        {
            var ints = new List<int>(combination.values) {newValue};
            values = ints;
        }

        public bool Equals(Combination other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
           return  (GetHashCode() == other.GetHashCode() && 
             values.All(i => values.Count(i1 => i==i1) == other.values.Count(i2 => i2==i)));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Combination)) return false;
            return Equals((Combination) obj);
        }

        public override int GetHashCode()
        {
            return values.Aggregate(values.Count, (current, t) => unchecked((t+1)*345619) * current);
        }

        public override string ToString()
        {
            var builder=new StringBuilder();
            values.ForEach(i => builder.Append(i).Append(" "));
            return builder.ToString();
        }
    }
}