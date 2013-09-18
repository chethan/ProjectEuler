using System;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem230
    {
        const string FIRST_TERM = "1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";
        const string SECOND_TERM = "8214808651328230664709384460955058223172535940812848111745028410270193852110555964462294895493038196";
        public static BigInteger SummationOnNthTermOfFibonacciWord()
        {
            BigInteger sum = 0;
            for (int i = 0; i < 18; i++)
            {
                sum += (BigInteger.Pow(10, i) * (NthCharOfFibbonaciWord(((127 + 19 * i) * BigInteger.Pow(7, i)))));
            }
            return sum;
        }



        public static decimal OrderOfFibbonaci(decimal fibNum)
        {
            double phi = (1 + Math.Sqrt(5))/2.0;

            var @decimal = ((decimal)Math.Log10((double)fibNum/100.0)+ (decimal)Math.Log10(Math.Sqrt(5)))/(decimal)Math.Log10(phi);

            if(Math.Truncate(@decimal)<@decimal)
            {
                return Math.Truncate(@decimal) + 1;
            }
            
            return Math.Truncate(@decimal);
        }

        public static BigInteger NthFibbonaci1(decimal n)
        {
            double phi = (1 + Math.Sqrt(5)) / 2.0;
            double pow = Math.Pow(phi,(Decimal.ToDouble(n))) / Math.Sqrt(5);
            return new BigInteger(pow);
        }

        public static BigInteger NearestFibNum(BigInteger num)
        {
            BigInteger firtFib = 1;
            BigInteger nextFib = 1;
            BigInteger nearestFib = 1;
            for (; (nearestFib*100) < num;)
            {
                nearestFib = firtFib + nextFib;
                firtFib = nextFib;
                nextFib = nearestFib;
            }
            return nearestFib;
        }

        public static int NthCharOfFibbonaciWord(BigInteger num)
        {
            decimal phi = (decimal) ((1 + Math.Sqrt(5)) / 2.0);
            BigInteger nearestFibNum = NthFibbonaci1(OrderOfFibbonaci((decimal)num));
//            BigInteger nearestFibNum = NearestFibNum(num);
            decimal term = (decimal)(nearestFibNum-((num/100)+1));
            int digit = (int)(num%100)-1;
            decimal d = 2+Math.Floor((term+1) * phi) -Math.Floor((term+2) * phi);
           return int.Parse((d == 1? FIRST_TERM[digit] : SECOND_TERM[digit]).ToString());
        }

    }
    }
