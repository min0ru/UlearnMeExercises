using System;
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
            var (newFirst, newSecond) = Seminar1.Solution.Swap(first, second);
            Assert.AreEqual(first, newSecond);
            Assert.AreEqual(second, newFirst);
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
            Assert.AreEqual(expected, Seminar1.Solution.ReverseText(text));
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
            Assert.AreEqual(expected, Seminar1.Solution.RotateInteger(number));
        }

        [Test]
        [TestCase(0u, 0)]
        [TestCase(1u, 30)]
        [TestCase(2u, 60)]
        [TestCase(3u, 90)]
        [TestCase(4u, 120)]
        [TestCase(5u, 150)]
        [TestCase(6u, 180)]
        [TestCase(7u, 150)]
        [TestCase(8u, 120)]
        [TestCase(9u, 90)]
        [TestCase(10u, 60)]
        [TestCase(11u, 30)]
        [TestCase(12u, 0)]
        [TestCase(13u, 30)]
        [TestCase(18u, 180)]
        [TestCase(20u, 120)]
        [TestCase(23u, 30)]
        public void TestClockArrowsAngle(uint hour, int expectedAngle)
        {
            Assert.AreEqual(expectedAngle, Seminar1.Solution.MeasureClockArrowsAngle(hour));
        }

        [Test]
        [TestCase(24u)]
        [TestCase(25u)]
        [TestCase(26u)]
        [TestCase(30u)]
        [TestCase(120u)]
        public void TestGetClockArrowsAngleParameterRange(uint hour)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { Seminar1.Solution.MeasureClockArrowsAngle(hour); }
            );
        }

        [Test]
        [TestCase(1u, 1u, 0u, 0u)]
        [TestCase(1u, 1u, 1u, 1u)]
        [TestCase(1u, 1u, 10u, 10u)]
        [TestCase(1u, 10u, 10u, 1u)]
        [TestCase(1u, 10u, 20u, 2u)]
        [TestCase(1u, 10u, 100u, 10u)]
        [TestCase(10u, 1u, 10u, 1u)]
        [TestCase(10u, 1u, 20u, 2u)]
        [TestCase(10u, 1u, 100u, 10u)]
        [TestCase(2u, 3u, 0u, 0u)]
        [TestCase(2u, 3u, 1u, 0u)]
        [TestCase(2u, 3u, 2u, 0u)]
        [TestCase(2u, 3u, 3u, 0u)]
        [TestCase(2u, 3u, 6u, 1u)]
        [TestCase(2u, 3u, 7u, 1u)]
        [TestCase(2u, 3u, 11u, 1u)]
        [TestCase(2u, 3u, 12u, 2u)]
        [TestCase(2u, 3u, 13u, 2u)]
        [TestCase(2u, 3u, 18u, 3u)]
        [TestCase(2u, 3u, 19u, 3u)]
        [TestCase(2u, 3u, 24u, 4u)]
        [TestCase(5u, 3u, 100u, 6u)]
        [TestCase(3u, 5u, 100u, 6u)]
        public void TestCountCommonDevisorsInRange(uint x, uint y, uint n, uint expected)
        {
            Assert.AreEqual(expected, Seminar1.Solution.CountCommonDividedInRange(x, y, n));
        }

        [Test]
        [TestCase(0u, 0u, 1u)]
        [TestCase(2000u, 2004u, 2u)]
        [TestCase(2000u, 2020u, 6u)]
        [TestCase(2000u, 2100u, 24u)]
        [TestCase(1901u, 1999u, 24u)]
        [TestCase(1932u, 1936u, 2u)]
        [TestCase(1932u, 1937u, 2u)]
        [TestCase(1932u, 1939u, 2u)]
        [TestCase(1932u, 1940u, 3u)]
        [TestCase(1900u, 3000u, 266u)]
        public void TestCountLeapYearsInRange(uint begin, uint end, uint expected)
        {
            Assert.AreEqual(expected, Seminar1.Solution.CountLeapYearsInRange(begin, end));
        }

        [Test]
        [TestCase(1000u, 0u)]
        [TestCase(1997u, 1996u)]
        public void TestCountLeapYearsInRangeOutOfRangeArguments(uint begin, uint end)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { Seminar1.Solution.CountLeapYearsInRange(begin, end); });
        }
    }
}