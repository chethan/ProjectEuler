using EulerProblem.Utils;

namespace EulerProblem
{
    public class Problem67
    {
        public static long MaximumSumToBase()
        {
            var triangleNumbers = new TriangleNumbers("Problem67.txt");
            return triangleNumbers.MaximumSum();
        }
    }
}