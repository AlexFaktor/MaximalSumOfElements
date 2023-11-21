namespace Maximal_sum_of_elements
{
    public class FileDataManager
    {
        /// <summary>
        /// The method accepts the path to the file from the user, and then returns the entire text of the file
        /// </summary>
        public static string WritePathForTextInFile()
        {
            string path = Console.ReadLine() ?? throw new ArgumentNullException();

            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                throw new FileLoadException();
            }
        }
    }
}
