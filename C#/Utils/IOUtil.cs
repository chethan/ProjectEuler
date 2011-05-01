using System;
using System.IO;

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
    }
}