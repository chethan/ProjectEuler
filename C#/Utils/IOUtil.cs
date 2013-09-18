using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EulerProblem.Utils
{
    public class IOUtil
    {
        public static int[,] ReadToMatrix(string filePath, char separator=' ')
        {
            using (var fileStream = File.OpenText(filePath))
            {
                string readToEnd = fileStream.ReadToEnd();
                string[] strings = readToEnd.Split('\n');
                var matrix = new int[strings.Length, strings.Length];
                for (int i = 0; i < strings.Length; i++)
                {
                    string[] numbers = strings[i].Split(separator);
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(numbers[j]);
                    }
                }
                return matrix;
            }
        }

        public static List<long> PrimeNumbesList()
        {
            var primeNumbers = new List<long>();
            using (var fileStream = File.OpenText("PrimeNumbers.txt"))
            {
                string line;
                while ((line=fileStream.ReadLine())!=null)
                {
                    List<string> list = line.Trim().Split(' ').ToList();
                    list.ForEach(s => primeNumbers.Add(Convert.ToInt32(s)));
                }
            }
            return primeNumbers;
        }
    }
}