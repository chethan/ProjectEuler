using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EulerProblem
{
    public static class Problem89
    {
        public static long NumberOfCharectersSaved()
        {
            long total=0,count=0;
            StreamReader streamReader = File.OpenText("C:\\roman.txt");
            while (!streamReader.EndOfStream)
            {
                string inputRomanNum = streamReader.ReadLine();
                if (inputRomanNum.Length <= ToRoman(FromRoman(inputRomanNum)).Length)
                {
                    Console.WriteLine(inputRomanNum + ".........." + ToRoman(FromRoman(inputRomanNum)));
                }
                total +=  (inputRomanNum.Length -ToRoman(FromRoman(inputRomanNum)).Length);
                count++;
            }
            return total;
        }

        public static long FromRoman(string romanNum)
        {
            long num = 0;
            var dictionary = new Dictionary<char,long>();
            dictionary.Add('M',1000);
            dictionary.Add('D',500);
            dictionary.Add('C',100);
            dictionary.Add('L',50);
            dictionary.Add('X',10);
            dictionary.Add('V',5);
            dictionary.Add('I',1);
            for (int i = romanNum.Length - 1; i>= 0;)
            {
                int j = i - 1;
                num += dictionary[romanNum[i]];
                if(i<=0) break;
                while (j>=0 && dictionary[romanNum[i]] > dictionary[romanNum[j]])
                {
                    num -= dictionary[romanNum[j]];
                    j--;
                }
                i = j;
            }
            return num;
        }
        
        public static string ToRoman(long num)
        {
            StringBuilder builder=new StringBuilder();
            var dictionary=new Dictionary<long, string>
                                                   {
                                                       {1000, "M"},
                                                       {500, "D"},
                                                       {100, "C"},
                                                       {50, "L"},
                                                       {10, "X"},
                                                       {5, "V"},
                                                       {1, "I"},
                                                   };

            int divisor = 2,seed =1000;
            for (; num!= 0; )
            {
                long div = num / seed;
                AppendTimes(builder, dictionary[seed], div);
                long rem = num % seed;
                if (rem >= seed / divisor )
                {
                    int key = divisor == 2 ? (seed / 10) : (seed / 5);
                    string temp = dictionary[key];
                    if(rem >= (seed - (key*2)))
                    {
                        AppendTimes(builder, temp, (seed -(rem/key)*key)/key);
                        builder.Append(dictionary[seed]);
                    }
                    else
                    {
                        builder.Append(dictionary[seed / divisor]);
                        AppendTimes(builder, temp, (((rem / key) * key)-(seed/divisor)) / key);
                    }
                    num = rem % key;
                }
                else
                {
                    num = rem;
                }
                seed = seed/divisor;
                divisor = GetNextDivisor(divisor);
            }
            return builder.ToString();
        }

        private static int GetNextDivisor(int divisor)
        {
            return divisor == 2 ? 5 : 2;
        }

        private static StringBuilder AppendTimes(StringBuilder sb,string s,long times)
        {
            for (int i = 0; i < times; i++)
            {
                sb.Append(s);
            }
            return sb;
        } 
    }
}