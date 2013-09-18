using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem79
    {
        public static string MinimumPossiblePassword()
        {
            var inputPasswords = PruneInputData();
            var finalPassword = new Dictionary<int, int>(10);
            foreach (var digits in inputPasswords.Select(inputPassword => MathUtils.GetDigits(inputPassword)))
            {
                for (var i = 0; i < digits.Count; i++)
                {
                    if (!finalPassword.ContainsKey(digits[i])) finalPassword[digits[i]] = i;
                    else
                    {
                        var tempOrder = i + (i>0?finalPassword[digits[i-1]]:0);
                        if (tempOrder > finalPassword[digits[i]]) finalPassword[digits[i]] = tempOrder;
                    }
                }
            }
            var builder = new StringBuilder();
            foreach (var keyValuePair in finalPassword.OrderByDescending(pair => pair.Value))
            {
                builder.Append(keyValuePair.Key);
            }
            return builder.ToString();
        }


        private static IEnumerable<int> PruneInputData()
        {
            var threeCharectersOfPasswords = new HashSet<int>();
            using (var fileStream = File.OpenText("Problem79.txt"))
            {
                while (!fileStream.EndOfStream)
                {
                    threeCharectersOfPasswords.Add(Convert.ToInt32(fileStream.ReadLine()));
                }
            }
            return threeCharectersOfPasswords;
        }
    }
}