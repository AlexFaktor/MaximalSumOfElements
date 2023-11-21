namespace Maximal_sum_of_elements
{
    public class ShowTextToolsResult
    {
        public static void ShowSumOfElementsInText(string input)
        {
            string[] result = TextTools.SumsOfElementsInText(input);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {result[i]}");
            }
        }
    }
}
