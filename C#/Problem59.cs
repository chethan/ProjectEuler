using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EulerProblem
{
    public static class Problem59
    {
        private const string ASCIISkipList = "#$*+/[]^_{|}";

        public static int DecypherText()
        {
            var strings = File.ReadAllText("Problem59.txt").Split(',');
            var allPasswords = GeneratePossoblePasswordCharecters(strings);
            int index = 0,totalASCIIValue=0;
            foreach (var s in strings)
            {
                var value = Convert.ToInt16(s) ^ allPasswords[index][0];
                totalASCIIValue += value;
                Console.Write(Convert.ToChar(value));
                index = index == 2 ? 0 : index + 1;
            }
            return totalASCIIValue;
        }

        private static List<List<int>> GeneratePossoblePasswordCharecters(string[] strings)
        {
            var allPasswords = new List<List<int>>();
            for (int password = 0; password <= 2; password++)
            {
                allPasswords.Add(new List<int>());
                for (int i = Convert.ToInt16('a'); i <= Convert.ToInt16('z'); i++)
                {
                    var validPassword = true;
                    for (var index = password; index < strings.Length; index += 3)
                    {
                        var value = Convert.ToInt16(strings[index]) ^ i;
                        if (!IsValidASCII(value))
                        {
                            validPassword = false;
                            break;
                        }
                    }
                    if (validPassword) allPasswords[password].Add(i);
                }
            }
            return allPasswords;
        }

        private static bool IsValidASCII(int value)
        {
            return ((value >= 32 && value <= 126) && !ASCIISkipList.Contains(Convert.ToChar(value)));
        }
    }
}