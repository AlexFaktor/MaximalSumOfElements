using Maximal_sum_of_elements;
using System.Diagnostics;

namespace MaximalSumOfElementsTests
{
    [TestClass]
    public class TextToolsTests
    {
        public string? pathToExe;
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

        private static string RunConsoleAppWithArguments(string pathToExe, string args)
        {
            if (File.Exists(pathToExe))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = pathToExe,
                    Arguments = args,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                var process = Process.Start(psi);

                StreamReader reader = process.StandardOutput;
                string actualOutput = reader.ReadToEnd();
                process.WaitForExit();

                return actualOutput;
            }
            else throw new Exception();
        }

        private static string RunConsoleAppWithoutArguments(string pathToExe, string consoleInput)
        {
            if (File.Exists(pathToExe))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = pathToExe,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                var process = Process.Start(psi);
                process.StandardInput.WriteLine(consoleInput);

                StreamReader reader = process.StandardOutput;
                string actualOutput = reader.ReadToEnd();
                process.WaitForExit();

                return actualOutput;
            }
            else throw new Exception();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            pathToExe = Path.Combine(Directory.GetCurrentDirectory(), "MaximalSumOfElements.exe");
            tempFilePath = Path.Combine(Path.GetTempPath(), "tempFile.txt");
            File.WriteAllText(tempFilePath, content);
        }

        [TestMethod]
        public void LineGetTaskInfo_NullInput_ShouldThrowException()
        {
            string? input = null;

            Assert.ThrowsException<ArgumentNullException>(() => TextTools.LineGetTaskInfo(input));
        }

        [TestMethod]
        public void LineGetTaskInfo_WithValidInput_ShouldReturnExpectedValue()
        {
            string input = content;
            int expectedLineMaxSum = 6;
            List<int> expectedLinesBroken = new() { 3, 4, 5, 8 };

            var actual = TextTools.LineGetTaskInfo(input);

            Assert.AreEqual(expectedLineMaxSum, actual.LineMaxSum);
            CollectionAssert.AreEqual(expectedLinesBroken, actual.LinesBroken);
        }

        [TestMethod]
        public void Main_WithValidInputWithArguments_ShouldReturnExpectedValue()
        {
            string expectedOutput = "Line number with the highest amount: 7\r\n" +
                                    "List of lines with invalid elements: 4 5 6 9 ";

            string currentDirectory = Directory.GetCurrentDirectory();
            string pathToExe = Path.Combine(currentDirectory, "MaximalSumOfElements.exe");
            string actualOutput = TextToolsTests.RunConsoleAppWithArguments(pathToExe, tempFilePath);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Main_WithValidInputWithoutArguments_ShouldReturnExpectedValue()
        {
            string expectedOutput = "Enter the path to the file: Line number with the highest amount: 7\r\n" +
                                    "List of lines with invalid elements: 4 5 6 9 ";

            string currentDirectory = Directory.GetCurrentDirectory();
            string pathToExe = Path.Combine(currentDirectory, "MaximalSumOfElements.exe");
            string actualOutput = TextToolsTests.RunConsoleAppWithoutArguments(pathToExe, tempFilePath);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(tempFilePath))
                File.Delete(tempFilePath);
        }
    }
}