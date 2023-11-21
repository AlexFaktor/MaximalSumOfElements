using System.Collections.Generic;
using System.Globalization;

namespace Maximal_sum_of_elements
{
    public class TextTools
    {
        /// <summary>
        /// Receives text and returns the sum of elements in it, if it fails, marks it as "Broken line" 
        /// </summary>
        private static double SumOfElementsInLine(string line)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));

            NumberFormatInfo numberFormatInfo = new()
            {
                NumberDecimalSeparator = ".",
            };

            string[] numString = line.Split(',');
            double[] numsDouble = new double[numString.Length];

            double sum = 0;

            for (int i = 0; i < numString.Length; i++)
            {  
                try
                {
                    numsDouble[i] = double.Parse(numString[i], numberFormatInfo);
                    sum += numsDouble[i];
                }
                catch
                {
                    throw new ArgumentException("Incorrect input");
                }
            }
 
            return sum; 
        }

        /// <summary>
        /// Returns an array where the index will indicate the number of the line, and under the index should be the sum of the elements of this line
        /// </summary>
        public static string[] SumsOfElementsInText(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string[] textLines = text.Split('\n');

            for (int i = 0; i < textLines.Length; i++)
            {
                try
                {
                    textLines[i] = SumOfElementsInLine(textLines[i]).ToString();
                }
                catch
                {
                    textLines[i] = "Broken";
                }
            }

            return textLines; 
        }

        /// <summary>
        /// Returns the line number with the largest sum of elements
        /// </summary>
        public static int LineNumberWithHighestSum(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string[] textLines = text.Split('\n');

            int result = 0;
            double maxSum = 0;

            for (int i = 0; i < textLines.Length; i++)
            {
                try
                {
                    double lineSum = SumOfElementsInLine(textLines[i]);

                    if (lineSum > maxSum)
                    {
                        result = i;
                        maxSum = lineSum;
                    }

                }
                catch
                {
                }
            }

            return result+1;
        }

        /// <summary>
        /// Returns a list of line numbers that are marked as Broken
        /// </summary>
        public static List<int> LinesNumberWithInvalidElements(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string[] textLines = text.Split('\n');

            List<int> result = new();

            for (int i = 0; i < textLines.Length; i++)
            {
                try
                {
                    double lineSum = SumOfElementsInLine(textLines[i]);
                }
                catch
                {
                    result.Add(i+1);
                }
            }

            return result;
        }
    }
}
