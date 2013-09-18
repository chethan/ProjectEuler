using System.IO;
using EulerProblem.Utils;

namespace EulerProblem
{
    public class Problem18
    {
        public static long MaximumSumToBase()
        {
            var triangleNumbers = new TriangleNumbers("Problem18.txt");
            return triangleNumbers.MaximumSum();
        }
    }
}