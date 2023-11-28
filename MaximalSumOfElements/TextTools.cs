using System.Globalization;

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
            double[] numsDouble = new double[numString.Length];
            sum = 0;

            for (int i = 0; i < numString.Length; i++)
            {
                if (!double.TryParse(numString[i], NumberStyles.Any, CultureInfo.InvariantCulture, out numsDouble[i]))
                {
                    return false; 
                }

                sum += numsDouble[i];
            }

            return true;
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
                double lineSum = 0;
                if (!SumOfElementsInLine(textLines[i], out lineSum))
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
