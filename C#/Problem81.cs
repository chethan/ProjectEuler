using System;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem81
    {
       public static long MinimalPathSum()
       {
           var matrix = IOUtil.ReadToMatrix("Problem81.txt", ',');
           var length = (int) Math.Sqrt(matrix.Length);
           var minimualPathSums = new int[length,length];
           for (int row = 0; row < length; row++)
           {
               for (int col = 0; col < length; col++)
               {
                   minimualPathSums[row, col] = matrix[row, col];
                   if(row==0 && col==0) continue;
                   int sum1 = row > 0 ? minimualPathSums[row - 1, col] : int.MaxValue;
                   int sum2 = col > 0 ? minimualPathSums[row, col - 1] : int.MaxValue;
                   minimualPathSums[row, col] += Math.Min(sum1, sum2);
               }
           }
           return minimualPathSums[length - 1, length - 1];
       }
    }
}