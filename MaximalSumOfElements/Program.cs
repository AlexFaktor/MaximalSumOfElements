namespace MaximalSumOfElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            var filePath = args.Length > 0 ? args[0] : null;

            if (string.IsNullOrEmpty(filePath))
            {
                Console.Write("Enter the path to the file: ");
                filePath = Console.ReadLine();
            }

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file was not found {filePath}");
            
            var data = TextTools.LineGetTaskInfo(File.ReadAllText(filePath));

            Console.WriteLine($"Line number with the highest amount: {data.LineMaxSum + 1}");
            Console.Write("List of lines with invalid elements: ");

            foreach (int num in data.LinesBroken)
            {
                Console.Write($"{num + 1} ");
            }
        }
    }
}
