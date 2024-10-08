﻿using System.Globalization;

namespace MaximalSumOfElements
{
    public class TextTools
    {
        public record DataForTask(int LineMaxSum, List<int> LinesBroken);

        /// <summary>
        /// Receives text and returns the sum of elements in it, if it fails, marks it as "Broken line" 
        /// </summary>
        private static bool SumOfElementsInLine(string line, out double sum)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));

            string[] numString = line.Split(',');
            sum = 0;

            for (int i = 0; i < numString.Length; i++)
            {
                if (!double.TryParse(numString[i], NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    return false; 
                }

                sum += num;
            }

            return true;
        }

        /// <summary>
        /// Returns a record containing the number of the line with the largest amount and a list of broken lines
        /// </summary>
        public static DataForTask GetIndexLineMaxSumAndIndexesIncorrectLines(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string[] textLines = text.Split('\n');

            int indexMaxSum = 0;
            double maxSum = double.MinValue;
            List<int> brokenElements = new();

            for (int i = 0; i < textLines.Length; i++)
            {
                if (!SumOfElementsInLine(textLines[i], out var lineSum))
                {
                    brokenElements.Add(i);
                }
                if (lineSum > maxSum)
                {
                    indexMaxSum = i;
                    maxSum = lineSum;
                }
            }
            DataForTask dataForTask = new(indexMaxSum, brokenElements);

            return dataForTask;
        }
    }
}
