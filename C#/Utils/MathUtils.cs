using System.Collections.Generic;
using System.Numerics;

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
    }
}