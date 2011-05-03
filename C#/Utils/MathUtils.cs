namespace EulerProblem.Utils
{
    public class MathUtils
    {
        public static int GCD(int number1, int number2)
        {
            while (number1 % number2 != 0)
            {
                int temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }
            return number2;
        }
    }
}