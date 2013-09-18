using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EulerProblem
{
    public static class Problem17
    {
        
        public static int TotalNumberOfCharecters(int num)
        {
            int totalCount = 0;
            for (int i = 1; i <= num; i++)
            {
                totalCount += NumbersToString(i).Length;
            }
            return totalCount;
        }
        
        private static string NumbersToString(int num)
        {
            var hashMap = GetHashMap();
            var builder=new StringBuilder();
            int thousandthValue = num/1000;
            if (thousandthValue != 0) builder.Append(hashMap[thousandthValue]).Append(hashMap[1000]);
            int hundredthValue = (num % 1000)/100;
            if (hundredthValue != 0)
            {
                if (thousandthValue != 0) builder.Append("And");
                builder.Append(hashMap[hundredthValue]).Append(hashMap[100]);
            }
            int tenthValue = (num%100);
            if (tenthValue != 0)
            {
                if (hundredthValue != 0) builder.Append("And");
                if (hashMap.ContainsKey(tenthValue)) builder.Append(hashMap[tenthValue]);
                else
                {
                    var digitValue = tenthValue%10;
                    builder.Append(hashMap[(tenthValue/10)*10]).Append(hashMap[digitValue]);
                }
            } 
            return builder.ToString();
        }

        private static IDictionary<int,string> GetHashMap()
        {
            var dictionary = new Dictionary<int,string>();
            using(var fs = File.OpenText("NumberToString.txt"))
            {
                while (!fs.EndOfStream)
                {
                    string[] strings = fs.ReadLine().Split(',');
                    dictionary.Add(Convert.ToInt32(strings[0]),strings[1]);
                }
            }
            return dictionary;
        }
    }
}