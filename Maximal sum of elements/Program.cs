namespace Maximal_sum_of_elements
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter the path to the file: ");
            string Text = FileDataManager.GetTextFromFile();

            var Data = TextTools.LineGetTaskInfo(Text);

            Console.WriteLine($"Line number with the highest amount: {Data.LineMaxSum}");
            Console.Write("List of lines with invalid elements: ");

            foreach (int num in Data.LinesBroken)
            {
                Console.Write($"{num} ");
            }
        }
    }
}
