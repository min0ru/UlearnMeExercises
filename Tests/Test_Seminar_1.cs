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
            Assert.AreEqual(Seminar1.Solution.GetClockArrowsAngle(hour), expectedAngle);
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
                delegate { Seminar1.Solution.GetClockArrowsAngle(hour); }
            );
        }
    }
}