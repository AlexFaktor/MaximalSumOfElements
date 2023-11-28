namespace MaximalSumOfElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text;

            if(args.Length == 1)
            {
                text = File.ReadAllText(args[0]);
            }
            else
            {
                Console.Write("Enter the path to the file: ");
                text = File.ReadAllText(Console.ReadLine());
            }

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
