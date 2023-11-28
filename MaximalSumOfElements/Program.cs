namespace MaximalSumOfElements
{
    public class Program
    {
        private static string GetFilePathFromUser()
        {
            Console.Write("Enter the path to the file: ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string text = args.Length == 1 ? File.ReadAllText(args[0]) : File.ReadAllText(GetFilePathFromUser());

            var data = TextTools.LineGetTaskInfo(text);

            Console.WriteLine($"Line number with the highest amount: {data.LineMaxSum + 1}");
            Console.Write("List of lines with invalid elements: ");

            foreach (int num in data.LinesBroken)
            {
                Console.Write($"{num + 1} ");
            }
        }
    }
}
