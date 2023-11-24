using Maximal_sum_of_elements;
using System.Diagnostics;

namespace MaximalSumOfElementsTests
{
    [TestClass]
    public class TextToolsTests
    {
        public string? currentDirectory;
        public string? tempPath;
        public string? tempFilePath;
        public string content = "1\n" +
                "1, 1.0, 0.5, 100  , 5\n" +
                "500, 100, 0\n" +
                "Broken\n" +
                "\n" +
                ",,,,,\n" +
                "435,233,423,423,43\n" +
                "0,0,0\n" +
                "Broken";

        [TestInitialize]
        public void TestInitialize()
        {
            currentDirectory = Directory.GetCurrentDirectory();

            tempPath = Path.GetTempPath();

            tempFilePath = Path.Combine(tempPath, "tempFile.txt");

            File.WriteAllText(tempFilePath, content);
        }

        [TestMethod]
        public void LineGetTaskInfo_NullInput_ShouldThrowException()
        {
            string input = null;

            Assert.ThrowsException<ArgumentNullException>(() => TextTools.LineGetTaskInfo(input));
        }

        [TestMethod]
        public void LineGetTaskInfo_WithValidInput_ShouldReturnExpectedValueLineMaxSum()
        {
            string input = "2.0,0, 12.1, 100.5\n" +
                           "11, 0, 30, 40.4, 5\n" +
                           "invalidData\n" +
                           "0, 3, 12, 65, 0, 3\n" +
                           "";
            int expected = 0;

            var actual = TextTools.LineGetTaskInfo(input);

            Assert.AreEqual(expected, actual.LineMaxSum);
        }

        [TestMethod]
        public void LineGetTaskInfo_WithValidInput_ShouldReturnExpectedValueLinesBroken()
        {
            string input = "2.0,0, 12.1, 100.5\n" +
                           "11, 0, 30, 40.4, 5\n" +
                           "invalidData\n" +
                           "0, 3, 12, 65, 0, 3\n" +
                           "";
            List<int> expected = new() { 2, 4 };

            var actual = TextTools.LineGetTaskInfo(input);

            CollectionAssert.AreEqual(expected, actual.LinesBroken);
        }

        [TestMethod]
        public void Main_WithValidInputWithArguments_ShouldReturnExpectedValue()
        {
            string expectedOutput = "Line number with the highest amount: 7\r\n" +
                                    "List of lines with invalid elements: 4 5 6 9 ";
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string pathToExe = Path.Combine(currentDirectory, "MaximalSumOfElements.exe");

                if (File.Exists(pathToExe))
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = pathToExe,
                        Arguments = tempFilePath,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    Process process = Process.Start(psi);
                    process.Start();

                    StreamReader reader = process.StandardOutput;
                    string actualOutput = reader.ReadToEnd();
                    process.WaitForExit();

                    Assert.AreEqual(expectedOutput, actualOutput);
                }
                else
                {
                    Assert.Fail($"Error: File {pathToExe} was not found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.Message}");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(tempFilePath))
                File.Delete(tempFilePath);
        }
    }
}