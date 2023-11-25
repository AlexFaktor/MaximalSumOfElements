namespace Maximal_sum_of_elements
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text;

            try
            {
                text = File.ReadAllText(args[0]);
            }
            catch
            {
                Console.Write("Enter the path to the file: ");
                text = File.ReadAllText(Console.ReadLine()
                    ?? throw new ArgumentNullException())
                    ?? throw new FileLoadException();
            }

            var Data = TextTools.LineGetTaskInfo(text);

            Console.WriteLine($"Line number with the highest amount: {Data.LineMaxSum + 1}");
            Console.Write("List of lines with invalid elements: ");

            foreach (int num in Data.LinesBroken)
            {
                Console.Write($"{num + 1} ");
            }
        }
    }
}
