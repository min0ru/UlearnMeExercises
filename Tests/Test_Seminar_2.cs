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
    }
}