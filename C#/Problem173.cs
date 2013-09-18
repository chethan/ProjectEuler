using System;
using System.Numerics;

namespace EulerProblem
{
    public static class Problem173
    {
        public static BigInteger CountLamineSquares(long numTiles)
        {
            BigInteger lamineSquaresCount=0;
            long limit = ((numTiles + 4) / 4);
            for (long n = 3; n<=limit; n++)
            {
                long gap = n - 2;
                while (gap>0)
                {
                    if((n*n)-(gap*gap)<=numTiles) lamineSquaresCount++;
                    gap = gap - 2;
                }
                Console.WriteLine(n);
            }
            return lamineSquaresCount;
        }
    }
}