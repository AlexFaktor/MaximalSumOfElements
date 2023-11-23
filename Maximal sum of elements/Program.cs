namespace Maximal_sum_of_elements
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Text;

            try
            {
                Text = File.ReadAllText(args[0]);
            }
            catch
            {
                Console.Write("Enter the path to the file: ");
                Text = FileDataManager.GetTextFromFile();
            }  

            var Data = TextTools.LineGetTaskInfo(Text);

            Console.WriteLine($"Line number with the highest amount: {Data.LineMaxSum + 1}");
            Console.Write("List of lines with invalid elements: ");

            foreach (int num in Data.LinesBroken)
            {
                Console.Write($"{num + 1} ");
            }
        }
    }
}
