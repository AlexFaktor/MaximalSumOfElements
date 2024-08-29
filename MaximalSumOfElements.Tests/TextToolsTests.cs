using MaximalSumOfElements;
using System.Diagnostics;

namespace MaximalSumOfElementsTests
{
    [TestClass]
    public class TextToolsTests
    {
        private string? tempFilePath;
        private readonly string content = "1\n" +
                "1, 1.0, 0.5, 100  , 5\n" +
                "500, 100, 0\n" +
                "Broken\n" +
                "\n" +
                ",,,,,\n" +
                "435,233,423,423,43\n" +
                "0,0,0\n" +
                "Broken";

        private static string RunConsoleApp(string pathToExe, string? args, string? consoleInput)
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
            var process = Process.Start(psi)!;

            // write input
            if (!string.IsNullOrEmpty(consoleInput))
            {
                process.StandardInput.WriteLine(consoleInput);
            }

            var reader = process.StandardOutput;
            var actualOutput = reader.ReadToEnd();

            process.WaitForExit();

            return actualOutput;
        }

        [TestMethod]
        public void LineGetTaskInfo_WithValidInputNegativeNumbers_ShouldReturnExpectedValue()
        {
            string input = "-100, -200, 1.3\n0, -1, -2, -4\n-10, -2";
            int expectedLineMaxSum = 1;
            List<int> expectedLinesBroken = new() { };

            var actual = TextTools.GetIndexLineMaxSumAndIndexesIncorrectLines(input);

            Assert.AreEqual(expectedLineMaxSum, actual.LineMaxSum);
            CollectionAssert.AreEqual(expectedLinesBroken, actual.LinesBroken);
        }

        [TestMethod]
        public void LineGetTaskInfo_NullInput_ShouldThrowException()
        {
            string? input = null;

            Assert.ThrowsException<ArgumentNullException>(() => TextTools.GetIndexLineMaxSumAndIndexesIncorrectLines(input));
        }

        [TestMethod]
        public void LineGetTaskInfo_WithValidInput_ShouldReturnExpectedValue()
        {
            string input = content;
            int expectedLineMaxSum = 6;
            List<int> expectedLinesBroken = new() { 3, 4, 5, 8 };

            var actual = TextTools.GetIndexLineMaxSumAndIndexesIncorrectLines(input);

            Assert.AreEqual(expectedLineMaxSum, actual.LineMaxSum);
            CollectionAssert.AreEqual(expectedLinesBroken, actual.LinesBroken);
        }

        [TestMethod]
        public void Main_WithValidInputWithArguments_ShouldReturnExpectedValue()
        {
            tempFilePath = Path.Combine(Path.GetTempPath(), "tempFile.txt");
            File.WriteAllText(tempFilePath, content);

            string expectedOutput = "Line number with the highest amount: 7\r\n" +
                                    "List of lines with invalid elements: 4 5 6 9 ";

            string currentDirectory = Directory.GetCurrentDirectory();
            string pathToExe = Path.Combine(currentDirectory, "MaximalSumOfElements.exe");
            string actualOutput = TextToolsTests.RunConsoleApp(pathToExe, consoleInput: null, args: tempFilePath);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Main_WithValidInputWithoutArguments_ShouldReturnExpectedValue()
        {
            tempFilePath = Path.Combine(Path.GetTempPath(), "tempFile.txt");
            File.WriteAllText(tempFilePath, content);

            string expectedOutput = "Enter the path to the file: Line number with the highest amount: 7\r\n" +
                                    "List of lines with invalid elements: 4 5 6 9 ";

            string currentDirectory = Directory.GetCurrentDirectory();
            string pathToExe = Path.Combine(currentDirectory, "MaximalSumOfElements.exe");
            string actualOutput = TextToolsTests.RunConsoleApp(pathToExe, args: null ,consoleInput : tempFilePath);

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