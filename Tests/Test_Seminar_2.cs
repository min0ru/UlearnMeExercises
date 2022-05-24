using NUnit.Framework;
using UlearnMeExercises;

namespace Tests
{
    public class TestsSeminar2
    {
        [Test]
        [TestCase(0, 0, new int[] { }, 0)]
        [TestCase(0, 1000, new int[] { }, 0)]
        [TestCase(0, 1, new int[] { 1 }, 0)]
        [TestCase(0, 2, new int[] { 1 }, 1)]
        [TestCase(0, 10, new int[] { 1 }, 45)]
        [TestCase(0, 10, new int[] { 1, 2 }, 45)]
        [TestCase(0, 10, new int[] { 1, 2, 9 }, 45)]
        [TestCase(0, 10, new int[] { 2 }, 20)]
        [TestCase(0, 10, new int[] { 3 }, 18)]
        public void TestSumNumbersWithDividers(int from, int to, int[] dividers, int expected)
        {
            var sum = Seminar2.Solution.SumNumbersWithDividers(from, to, dividers);
            Assert.AreEqual(sum, expected);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(1, 5, 0)]
        [TestCase(2, 10, 0)]
        [TestCase(3, 15, 0)]
        [TestCase(5, 25, 0)]
        [TestCase(6, 30, 0)]
        [TestCase(10, 50, 0)]
        [TestCase(12, 0, 0)]
        [TestCase(13, 5, 0)]
        [TestCase(14, 10, 0)]
        [TestCase(15, 15, 0)]
        [TestCase(20, 40, 0)]
        [TestCase(22, 50, 0)]
        [TestCase(0, 1, 6)]
        [TestCase(0, 2, 15)]
        [TestCase(0, 3, 18)]
        [TestCase(0, 4, 24)]
        [TestCase(0, 5, 30)]
        [TestCase(0, 15, 90)]
        [TestCase(0, 16, 96)]
        [TestCase(0, 25, 150)]
        [TestCase(0, 30, 180)]
        [TestCase(0, 31, 174)]
        [TestCase(0, 32, 168)]
        [TestCase(0, 40, 60)]
        [TestCase(0, 41, 54)]
        [TestCase(3, 15, 0)]
        [TestCase(3, 45, 180)]
        [TestCase(4, 5, 90)]
        [TestCase(18, 25, 30)]
        [TestCase(19, 10, 150)]
        [TestCase(10, 49, 6)]
        [TestCase(10, 51, 6)]
        [TestCase(8, 43, 18)]
        [TestCase(19, 18, 102)]
        public void TestCalculateAngleBetweenClockArrows(int hour, int minute, double expected)
        {
            double angle = Seminar2.Solution.CalculateAngleBetweenClockArrows(hour, minute);
            Assert.AreEqual(expected, angle, 0.001);
        }
    }
}