using System.Text;

namespace EulerProblem
{
    public static class Problem206
    {
        public static long UniqueSquareNumber()
        {
            for(long i = 1010101070; i <= 1389026623; i+=100)
            {
                if (IsOfPattern(i*i)) return i;
            }
            return 0;
        }

        public static bool IsOfPattern(long bigInteger)
        {
            string s = bigInteger.ToString();
            const long pattern = 1234567890;
            var value=new StringBuilder();
            for (int i = 0; i < s.Length; i+=2)
            {
                value.Append(s[i]);
            }
            return (pattern - long.Parse(value.ToString())) == 0;
        }
    }
}