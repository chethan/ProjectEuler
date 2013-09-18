using System;
using System.Collections.Generic;
using System.Numerics;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem112
    {
        private static readonly IDictionary<BigInteger, BouncyType> Bouncy = new Dictionary<BigInteger, BouncyType>();

        public static BigInteger NumberOfBouncy(int requiredPercentage)
        {
            for (BigInteger i = 10, bouncyCount = 0; ; i++)
            {
                var digits = i.GetDigits();
                if (digits.Count > 2)
                {
                    Bouncy[i] = GetBouncyType(Bouncy[i / 10],digits[1],digits[0]);
                }
                else
                {
                    Bouncy[i] = digits[0] > digits[1] ? BouncyType.Increasing : (digits[0] < digits[1]) ? BouncyType.Decreasing : BouncyType.Equal;
                }
                if (Bouncy[i] == BouncyType.Bouncy) bouncyCount++;
                if (requiredPercentage <= (int)(bouncyCount * 100 / i)) return i;
            }
        }

        private static BouncyType GetBouncyType(BouncyType bouncyType,int prev,int current)
        {
            if (bouncyType == BouncyType.Bouncy || prev == current) return bouncyType;
            if ((bouncyType == BouncyType.Increasing || bouncyType == BouncyType.Equal) && current > prev)
                return BouncyType.Increasing;
            if ((bouncyType == BouncyType.Decreasing || bouncyType == BouncyType.Equal) && current < prev)
                return BouncyType.Decreasing;
            return BouncyType.Bouncy;
        }
    }

    public enum BouncyType
    {
        Increasing,Decreasing,Bouncy,Equal 
    }
}