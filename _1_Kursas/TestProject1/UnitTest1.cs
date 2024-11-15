using _13_paskaita_Foreach_ir_dvimaciai_masyvai;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestForPositiveResult()
        {
            int[] numbers = { 2, 5 };
            double expected = 3.5;

            double actual = Methods.SumAverage(numbers);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TestForNegativeResult()
        {
            int[] numbers = { -2, -5 };
            double expected = -3.5;

            double actual = Methods.SumAverage(numbers);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestForPositiveNumsExtractionFromAnArray1()
        {
            int[] numbers = { 2, -5, -3, 7, -9 };
            int[] expected = {2, 7 };

            int[] actual = Methods.GetPositiveNumbers(numbers);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestForPositiveNumsExtractionFromAnArray2()
        {
            int[] numbers = { 2, 5, 3, 7, 9 };
            int[] expected = { 2, 5, 3, 7, 9 };

            int[] actual = Methods.GetPositiveNumbers(numbers);
            Assert.AreEqual(expected, actual);
        }
    }
}