namespace UnitTest1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTextLength_WithLeadSpacedText_ReturnsLength()
        {
            //Arrange
            string input = "  Hello  ";
            int expected = 5;

            //Act
            int actual = Methods.GetTextLength(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSummationResult_ReturnsValue()
        {
            double input1 = 3;
            double input2 = 2;
            double expected = 5;

            double actual = Methods.Summation(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSubtractionResult_ReturnsValue()
        {
            double input1 = 3;
            double input2 = 2;
            double expected = 1;

            double actual = Methods.Subtraction(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMultiplicationResult_ReturnsValue()
        {
            double input1 = 3;
            double input2 = 2;
            double expected = 6;

            double actual = Methods.Multiplication(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDivisionResult_ReturnsValue()
        {
            double input1 = 4;
            double input2 = 2;
            double expected = 2;

            double actual = Methods.Division(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPowerResult_ReturnsValue()
        {
            double input1 = 3;
            double input2 = 2;
            double expected = 9;

            double actual = Methods.Power(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSqrtResult_ReturnsValue()
        {
            double input1 = 25;
            double expected = 5;

            double actual = Methods.Sqrt(input1);

            Assert.AreEqual(expected, actual);
        }
    }
}