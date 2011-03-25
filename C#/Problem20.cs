using System.Collections.Generic;

namespace EulerProblem
{
    public static class Problem15
    {
        public static long NumberOfWays(int gridSize)
        {
            long count = 1 + gridSize;
            var tempRoutes = new List<long>();
            for (int i = 0; i < gridSize; i++)
            {
                tempRoutes.Add(1);
            }
            for (var i = 1; i <gridSize; i++)
            {
                var temp = new List<long>();
                for (var j = 0; j < gridSize; j++)
                {
                    long tempCount = 0;
                    for (var k = 0; k <= j; k++)
                    {
                        tempCount += tempRoutes[k];
                    }
                    count += tempCount;
                    temp.Add(tempCount);
                }
                tempRoutes = temp;
            }
            return count;
        }
    }
}