using System;
using System.Numerics;
using NUnit.Framework;
using UlearnMeExercises;

namespace Tests
{
    public static class TestsLine
    {
        static float ISQR2 = (float)(1 / Math.Sqrt(2));

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(3, 2, 1)]
        [TestCase(0.5, -0.5, 1.44)]
        public static void TestLineSimpleConstructor(double a, double b, double c)
        {
            var line = new Line(a, b, c);
            Assert.AreEqual(a, line.A, 0.001);
            Assert.AreEqual(b, line.B, 0.001);
            Assert.AreEqual(c, line.C, 0.001);
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(-10, -20)]
        [TestCase(10, 20)]
        public static void TestLineAngleConstructor(double m, double y0)
        {
            var line = new Line(m, y0);
            Assert.AreEqual(m, line.M, 0.001);
            Assert.AreEqual(y0, line.Y0, 0.001);
        }

        public static object[] LineFromPointsConstructorSlopeTestData =
        {
            new object[] { new Vector2(0, 0), new Vector2(10, 10), 1, 0 },
            new object[] { new Vector2(-10, -10), new Vector2(10, 10), 1, 0 },
            new object[] { new Vector2(-2, -1), new Vector2(2, 3), 1, 1 },
            new object[] { new Vector2(2, 3), new Vector2(-2, -1), 1, 1 },
            new object[] { new Vector2(-3, 0), new Vector2(4, -7), -1, -3 },
            new object[] { new Vector2(4, -7), new Vector2(-3, 0), -1, -3 },
            new object[]
            {
                new Vector2(1, 3), new Vector2(1, -5), double.PositiveInfinity,
                double.PositiveInfinity
            },
        };

        [Test]
        [TestCaseSource(nameof(LineFromPointsConstructorSlopeTestData))]
        public static void TestSlopeWithLineFromPointsConstructor(Vector2 pointA, Vector2 pointB,
            double expectedM,
            double expectedY0)
        {
            var line = new Line(pointA, pointB);
            Assert.AreEqual(expectedM, line.M, 0.001);
            Assert.AreEqual(expectedY0, line.Y0, 0.001);
        }

        public static object[] DistanceToPointTestData =
        {
            new object[] { new Line(1, 0), new Vector2(1, 1), 0 },
            new object[] { new Line(1, 0), new Vector2(-1, -1), 0 },
            new object[] { new Line(1, 0), new Vector2(0, 0), 0 },
            new object[] { new Line(1, 0), new Vector2(1, -1), Math.Sqrt(2) },
            new object[] { new Line(1, 0), new Vector2(-1, 1), Math.Sqrt(2) },
            new object[] { new Line(-1, 5), new Vector2(0, 0), 2.5 * Math.Sqrt(2) },
            new object[] { new Line(-1, 5), new Vector2(-0.5f, -2.5f), 4 * Math.Sqrt(2) },
            new object[]
                { new Line(new Vector2(-5, 3), new Vector2(5, 3)), new Vector2(-2, -2), 5 },
            new object[] { new Line(new Vector2(-5, 3), new Vector2(5, 3)), new Vector2(3, 5), 2 },
        };

        [Test]
        [TestCaseSource(nameof(DistanceToPointTestData))]
        public static void TestMeasureDistanceToPoint(Line line, Vector2 point,
            double expectedDistance)
        {
            Assert.AreEqual(expectedDistance, line.MeasureDistance(point), 0.001);
        }

        public static object[] FindParallelVectorTestData =
        {
            new object[] { new Line(new Vector2(-1, 0), new Vector2(1, 0)), new Vector2(1, 0) },
            new object[] { new Line(new Vector2(-1, 1), new Vector2(1, 1)), new Vector2(1, 0) },
            new object[] { new Line(new Vector2(-1, -1), new Vector2(1, -1)), new Vector2(1, 0) },
            new object[] { new Line(new Vector2(2, 10), new Vector2(2, -10)), new Vector2(0, 1) },
            new object[] { new Line(new Vector2(-2, 10), new Vector2(-2, -10)), new Vector2(0, 1) },
            new object[]
                { new Line(new Vector2(-3, 3), new Vector2(3, -3)), new Vector2(ISQR2, -ISQR2) },
            new object[]
                { new Line(new Vector2(0, 0), new Vector2(1, 1)), new Vector2(ISQR2, ISQR2) },
            new object[]
                { new Line(new Vector2(0, 0), new Vector2(1, -1)), new Vector2(ISQR2, -ISQR2) },
        };

        [Test]
        [TestCaseSource(nameof(FindParallelVectorTestData))]
        public static void TestFindParallelUnitVector(Line line, Vector2 expectedParallel)
        {
            var parallel = line.FindParallelUnitVector();
            Assert.AreEqual(expectedParallel, parallel);
            Assert.AreEqual(1, parallel.Length(), 0.001);
        }

        public static object[] FindNormalUnitVectorTestData =
        {
            new object[] { new Line(new Vector2(-1, 0), new Vector2(1, 0)), new Vector2(0, 1) },
            new object[] { new Line(new Vector2(-1, 1), new Vector2(1, 1)), new Vector2(0, 1) },
            new object[] { new Line(new Vector2(-1, -1), new Vector2(1, -1)), new Vector2(0, 1) },
            new object[] { new Line(new Vector2(2, 10), new Vector2(2, -10)), new Vector2(-1, 0) },
            new object[]
                { new Line(new Vector2(-2, 10), new Vector2(-2, -10)), new Vector2(-1, 0) },
            new object[]
                { new Line(new Vector2(-3, 3), new Vector2(3, -3)), new Vector2(ISQR2, ISQR2) },
            new object[]
                { new Line(new Vector2(0, 0), new Vector2(1, 1)), new Vector2(-ISQR2, ISQR2) },
            new object[]
                { new Line(new Vector2(0, 0), new Vector2(1, -1)), new Vector2(ISQR2, ISQR2) },
        };

        [Test]
        [TestCaseSource(nameof(FindNormalUnitVectorTestData))]
        public static void TestFindNormalUnitVector(Line line, Vector2 expectedNormal)
        {
            var normal = line.FindNormalUnitVector();
            Assert.AreEqual(expectedNormal, normal);
            Assert.AreEqual(1, normal.Length(), 0.001);
        }


        public static object[] FindLinesIntersectionTestData =
        {
            new object[]
            {
                new Line(new Vector2(0, -4), new Vector2(0, 4)),
                new Line(new Vector2(-4, 0), new Vector2(4, 0)),
                true,
                new Vector2(0, 0)
            },
            new object[]
            {
                new Line(new Vector2(-4, 0), new Vector2(4, 0)),
                new Line(new Vector2(0, -4), new Vector2(0, 4)),
                true,
                new Vector2(0, 0)
            },
            new object[]
            {
                new Line(new Vector2(3, -4), new Vector2(3, 4)),
                new Line(new Vector2(-4, 6), new Vector2(4, 6)),
                true,
                new Vector2(3, 6)
            },
            new object[]
            {
                new Line(new Vector2(0, 0), new Vector2(2, 2)),
                new Line(new Vector2(-6, 6), new Vector2(4, -4)),
                true,
                new Vector2(0, 0)
            },
            new object[]
            {
                new Line(new Vector2(-7, -2), new Vector2(3, 2)),
                new Line(new Vector2(-7, 4), new Vector2(-7, -4)),
                true,
                new Vector2(-7, -2)
            },
            new object[]
            {
                new Line(new Vector2(-7, -2), new Vector2(3, 2)),
                new Line(new Vector2(2, 8), new Vector2(3, 2)),
                true,
                new Vector2(3, 2)
            },
            new object[]
            {
                new Line(new Vector2(-7, -2), new Vector2(3, 2)),
                new Line(new Vector2(-1, 6), new Vector2(-3, -6)),
                true,
                new Vector2(-2, 0)
            },
            new object[]
            {
                new Line(new Vector2(-7, -2), new Vector2(3, 2)),
                new Line(new Vector2(-2, -4), new Vector2(2, -4)),
                true,
                new Vector2(-12, -4)
            },
            // Non intersecting examples
            new object[]
            {
                new Line(new Vector2(-7, -2), new Vector2(3, 2)),
                new Line(new Vector2(-7, 2), new Vector2(3, 6)),
                false,
                new Vector2(0, 0)
            },
            // Same lines, but intersection point is not valid
            new object[]
            {
                new Line(new Vector2(-7, -2), new Vector2(3, 2)),
                new Line(new Vector2(-7, 2), new Vector2(3, 6)),
                false,
                new Vector2(100, 100)
            },
            new object[]
            {
                new Line(new Vector2(-5, 0), new Vector2(5, 0)),
                new Line(new Vector2(-10, 2), new Vector2(10, 2)),
                false,
                new Vector2(int.MaxValue, int.MaxValue)
            },
            new object[]
            {
                new Line(new Vector2(-3, 10), new Vector2(-3, -10)),
                new Line(new Vector2(0, 20), new Vector2(0, -20)),
                false,
                new Vector2(int.MinValue, int.MinValue)
            },
        };

        [Test]
        [TestCaseSource(nameof(FindLinesIntersectionTestData))]
        public static void TestLinesIntersection(Line line, Line other, bool isIntersectsExpected,
            Vector2 expected)
        {
            var (isIntersects, intersection) = line.Intersect(other);
            var (isIntersectsInverted, invertedIntersection) = other.Intersect(line);
            Assert.AreEqual(isIntersects, isIntersectsInverted);
            Assert.AreEqual(isIntersects, isIntersectsExpected);

            // Checking for valid intersection point only in case if lines does intersect.
            if (isIntersects)
            {
                Assert.AreEqual(intersection, invertedIntersection);
                Assert.AreEqual(expected, intersection);
            }
        }

        public static object[] FindPointProjectionTestData =
        {
            //TODO: Create test data
        };

        [Test]
        [TestCaseSource(nameof(FindPointProjectionTestData))]
        public static void TestPointProjection(Line line, Vector2 point, Vector2 expected)
        {
            var projection = line.Project(point);
            Assert.AreEqual(expected, projection);
        }
    }
}