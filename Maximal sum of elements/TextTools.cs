using System.Globalization;

namespace Maximal_sum_of_elements
{
    public class TextTools
    {
        public record DataForTask(int LineMaxSum, List<int> LinesBroken);

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
        /// Returns a record containing the number of the line with the largest amount and a list of broken lines
        /// </summary>
        public static DataForTask LineGetTaskInfo(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string[] textLines = text.Split('\n');

            int indexMaxSum = 0;
            double maxSum = 0;
            List<int> brokenElements = new();

            for (int i = 0; i < textLines.Length; i++)
            {
                try
                {
                    double lineSum = SumOfElementsInLine(textLines[i]);

                    if (lineSum > maxSum)
                    {
                        indexMaxSum = i;
                        maxSum = lineSum;
                    }
                }
                catch
                {
                    brokenElements.Add(i);
                }
            }
            DataForTask dataForTask = new(indexMaxSum, brokenElements);

            return dataForTask;
        }
    }
}
