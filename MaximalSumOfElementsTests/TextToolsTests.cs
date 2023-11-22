using Maximal_sum_of_elements;

namespace MaximalSumOfElementsTests
{
    [TestClass]
    public class TextToolsTests
    {
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
            int expected = 1;

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
            List<int> expected = new() { 3, 5 };

            var actual = TextTools.LineGetTaskInfo(input);

            CollectionAssert.AreEqual(expected, actual.LinesBroken);
        }
    }
}