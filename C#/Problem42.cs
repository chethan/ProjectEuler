using System;

namespace EulerProblem
{
    public static class Problem42
    {
        public static long NextTriangleNumber()
        {
            for (long i = 55385; i < Int64.MaxValue; i++)
            {
                long triangle = (i*i) + i;
                double temp1=(1 + Math.Sqrt(1 + (4*3*triangle)))/6;
                if(temp1 == Math.Truncate(temp1))
                {
                    double temp2 = (2 + Math.Sqrt(4 + (4*4*triangle)))/8;

                    if(temp2 == Math.Truncate(temp2)) return triangle/2;
                }
            }
            return Int64.MaxValue;
        }
    }
}