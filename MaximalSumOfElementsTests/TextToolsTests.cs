using Maximal_sum_of_elements;

namespace MaximalSumOfElementsTests
{
    [TestClass]
    public class TextToolsTests
    {
        [TestMethod]
        public void SumsOfElementsInText_WithNullInput_ThrowException()
        {
            string? input = null;

            Assert.ThrowsException<ArgumentNullException>(() => TextTools.SumsOfElementsInText(input));
        }

        [TestMethod]
        public void SumsOfElementsInText_WithValidInput_ShouldReturnExpectedValue()
        {
            string input = "2.0,0, 12.1, 100.5  \n" +
                           "11, 0, 30, 40.4, 5  \n" +
                           "invalidData         \n" +
                           "0, 3, 12, 65, 0, 3  \n";

            string[] actual = TextTools.SumsOfElementsInText(input);
            string[] expected = { "114,6", "86,4", "Broken", "83", "Broken" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LineNumberWithHighestSum_WithNullInput_ThrowException()
        {
            string? input = null;

            Assert.ThrowsException<ArgumentNullException>(() => TextTools.LineNumberWithHighestSum(input));
        }

        [TestMethod]
        public void LineNumberWithHighestSum_WithValidInput_ShouldReturnExpectedValue()
        {
            string input = "2.0,0, 12.1, 100.5  \n" +
                           "11, 0, 30, 40.4, 5  \n" +
                           "invalidData         \n" +
                           "0, 3, 12, 65, 0, 3  \n";

            int actual = TextTools.LineNumberWithHighestSum(input);
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinesNumberWithInvalidElements_WithNullInput_ThrowException()
        {
            string? input = null;

            Assert.ThrowsException<ArgumentNullException>(() => TextTools.LinesNumberWithInvalidElements(input));
        }

        [TestMethod]
        public void LinesNumberWithInvalidElements_WithValidInput_ShouldReturnExpectedValue()
        {
            string input = "2.0,0, 12.1, 100.5  \n" +
                           "11, 0, 30, 40.4, 5  \n" +
                           "invalidData         \n" +
                           "0, 3, 12, 65, 0, 3  \n";

            List<int> actual = TextTools.LinesNumberWithInvalidElements(input);
            List<int> expected = new() { 3, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}