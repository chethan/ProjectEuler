using System.Collections.Generic;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem12
    {
        public static BigInteger Above500Divisors()
        {
            BigInteger triangleNumber;
            for (BigInteger i = 0; ; i++)
            {
                triangleNumber = NthTriangleNumber(i);
                int numberOfDivisors = NumberOfDivisors(triangleNumber);
                if(numberOfDivisors>500) break;
            }
            return triangleNumber;
        }
        
        public static int NumberOfDivisors(BigInteger n)
        {
            List<BigInteger> divisors = GetDivisors(n);
            return divisors.Count;
        }

        public static List<BigInteger> GetDivisors(BigInteger n)
        {
            var divisors=new List<BigInteger>();
            BigInteger divisor = 0;
            for (BigInteger i = 1; i < (n/2); i++)
            {
                if(BigInteger.Remainder(n,i)==0)
                {
                    BigInteger temp = BigInteger.Divide(n,i);
                    if(temp==divisor) break;
                    if(i==temp)
                    {
                        divisors.Add(i);
                        break;
                    }

                    divisor = i;
                    divisors.Add(i);
                    divisors.Add(temp);
                }
            }
            return divisors;
        }

        public static BigInteger NthTriangleNumber(BigInteger n)
        {
            return (n*(n + 1))/2;
        }
    }
}