using NUnit.Framework;
using UlearnMeExercises;

namespace Tests
{
    public class Tests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(100, 200)]
        [TestCase("First", "Second")]
        [TestCase(true, false)]
        public void TestSwapVariables<T>(T first, T second)
        {
            var (swappedFirst, swappedSecond) = Seminar1.Solution.SwapVariables(first, second);
            Assert.AreEqual(first, swappedSecond);
            Assert.AreEqual(second, swappedFirst);
        }

        [Test]
        [TestCase("", "")]
        [TestCase("0", "0")]
        [TestCase("Hello!", "!olleH")]
        [TestCase("12", "21")]
        [TestCase("123", "321")]
        [TestCase("123 321", "123 321")]
        [TestCase("TENET", "TENET")]
        public void TestReverseText(string text, string expected)
        {
            Assert.AreEqual(Seminar1.Solution.ReverseText(text), expected);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(10, 1)]
        [TestCase(100, 1)]
        [TestCase(12, 21)]
        [TestCase(123, 321)]
        [TestCase(123456789, 987654321)]
        [TestCase(1234567890, 987654321)]
        public void TestRotateInteger(int number, int expected)
        {
            Assert.AreEqual(Seminar1.Solution.RotateInteger(number), expected);
        }
    }
}