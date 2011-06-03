using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EulerProblem.Utils;

namespace EulerProblem
{
    public static class Problem79
    {
        
        public static string MinimumPossiblePassword()
        {
            var inputPasswords = PruneInputData();
            return "";
        }


        private static List<int> PruneInputData()
        {
            var threeCharectersOfPasswords = new HashSet<int>();
            using (var fileStream = File.OpenText("Problem79.txt"))
            {
                while (!fileStream.EndOfStream)
                {
                    threeCharectersOfPasswords.Add(Convert.ToInt32(fileStream.ReadLine()));
                }
            }
            using (var fileStream = File.CreateText("C:\\a.txt"))
            {
                foreach (var threeCharectersOfPassword in threeCharectersOfPasswords.OrderBy(i => i))
                {
                    fileStream.WriteLine(threeCharectersOfPassword);
                }
            }
            return threeCharectersOfPasswords.OrderBy(i => i).ToList();
        }
    }
}