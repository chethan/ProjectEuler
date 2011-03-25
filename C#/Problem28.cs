namespace EulerProblem
{
    public static class Problem28
    {
        public static long SumOfDiagonals(int spiralLength)
        {
            long total = 1;
            int step = 2,number =1,limit = spiralLength /2;
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    number+= step;
                    total +=number;
                }
                step += 2;
            }
            return total;
        }
        
    }
}