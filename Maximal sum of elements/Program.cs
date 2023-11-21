namespace Maximal_sum_of_elements
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter the path to the file: ");
            string Text = FileDataManager.WritePathForTextInFile();

            ShowTextToolsResult.ShowSumOfElementsInText(Text);

            Console.WriteLine("Line number with the highest amount: " + TextTools.LineNumberWithHighestSum(Text));
            Console.Write("List of lines with invalid elements: ");

            List<int> Numbers = TextTools.LinesNumberWithInvalidElements(Text);

            foreach (int num in Numbers)
            {
                Console.Write($"{num} ");
            }
        }
    }
}
