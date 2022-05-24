using System;
using System.Linq;
using System.Numerics;

namespace UlearnMeExercises
{
    /// <summary>
    /// https://ulearn.me/course/basicprogramming/Zadachi_na_seminar_aef25d82-818b-4a50-a2f0-bba842eeeedc
    /// </summary>
    public class Seminar1
    {
        /// <summary>
        /// Expr1.
        /// Как поменять местами значения двух переменных?
        /// Можно ли это сделать без ещё одной временной переменной.
        /// Стоит ли так делать?
        /// </summary>
        public static void Exercise1()
        {
            Console.WriteLine("=> Excercise 1 demo");

            int first = 10, second = 20;
            Console.WriteLine($"Variables before exchange: {first} {second}");
            (first, second) = Solution.Swap(first, second);
            Console.WriteLine($"Variables after exchange: {first} {second}");

            string sFirst = "Hello,", sSecond = "Sailor!";
            Console.WriteLine($"Variables before exchange: {sFirst} {sSecond}");
            (sFirst, sSecond) = Solution.Swap(sFirst, sSecond);
            Console.WriteLine($"Variables after exchange: {sFirst} {sSecond}");
        }

        /// <summary>
        /// Expr2.
        /// Задается натуральное трехзначное число (гарантируется, что трехзначное).
        /// Развернуть его, т.е. получить трехзначное число, записанное теми же цифрами в обратном порядке. 
        /// </summary>
        public static void Exercise2()
        {
            Console.WriteLine("=> Excercise 2 demo");

            foreach (var number in new[] {0, 1, 12, 123, 1234, 12345, 123456, 1234567890})
            {
                var reversedNumber = Solution.RotateInteger(number);
                Console.WriteLine($"Reverse representation of number {number} is {reversedNumber}");
            }
        }

        /// <summary>
        /// Expr3.
        /// Задано время Н часов (ровно).
        /// Вычислить угол в градусах между часовой и минутной стрелками.
        /// Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. Не использовать циклы.
        /// </summary>
        public static void Exercise3()
        {
            Console.WriteLine("=> Exercise 3 demo");
            foreach (var hour in new[] {0u, 1u, 3u, 6u, 9u, 12u, 15u})
            {
                int angle = Solution.MeasureClockArrowsAngle(hour);
                Console.WriteLine($"Clocks arrows angle at hour {hour} is {angle}");
            }
        }

        /// <summary>
        /// Expr4.
        /// Найти количество чисел меньших N, которые имеют простые делители X или Y.
        /// </summary>
        public static void Exercise4()
        {
            Console.WriteLine("=> Exercise 4 demo");

            foreach (var (x, y, n) in new[]
            {
                (1u, 1u, 100u),
                (2u, 3u, 10u),
                (3u, 5u, 100u),
                (5u, 3u, 100u),
                (6u, 7u, 500u),
            })
            {
                uint count = Solution.CountCommonDividedInRange(x, y, n);
                Console.WriteLine(
                    $"Count of commonly divided numbers for range {n,3} and divisors {x,3}, {y,3} is {count,3}");
            }
        }

        /// <summary>
        /// Expr5.
        /// Найти количество високосных лет на отрезке [a, b] не используя циклы.
        /// </summary>
        public static void Exercise5()
        {
            Console.WriteLine("=> Exercise 5 demo");

            var exampleYearRanges = new[]
            {
                (2000u, 2012u),
                (2000u, 2021u),
                (1000u, 3000u),
                (2000u, 2100u),
                (1900u, 3000u),
            };

            foreach (var (begin, end) in exampleYearRanges)
            {
                var leapYearsCount = Solution.CountLeapYearsInRange(begin, end);
                Console.WriteLine($"Number of leap years in range ({begin}, {end}) is {leapYearsCount}");
            }
        }

        /// <summary>
        /// Expr6.
        /// Посчитать расстояние от точки до прямой, заданной двумя разными точками.
        /// </summary>
        public static void Exercise6()
        {
            Console.WriteLine("=> Exercise 6 demo");

            var exampleLineAndPoints = new[]
            {
                (new Vector2(0, 0), new Vector2(10, 10), new Vector2(3, 17)),
                (new Vector2(-6, -17), new Vector2(3, -5), new Vector2(9, -14)),
                (new Vector2(8, -9), new Vector2(7, 14), new Vector2(2, 3)),
            };

            foreach (var (linePointA, linePointB, point) in exampleLineAndPoints)
            {
                var distance = Solution.MeasureLineToPointDistance(linePointA, linePointB, point);
                Console.WriteLine(
                    $"Distance between line [({linePointA}), ({linePointB}] and point {point} is {distance}");
            }
        }

        /// <summary>
        /// Expr7.
        /// Найти вектор, параллельный прямой.
        /// Перпендикулярный прямой.
        /// Прямая задана коэффициентами уравнения прямой.
        /// </summary>
        public static void Exercise7()
        {
            Console.WriteLine("=> Exercise 7 demo");

            var lines = new[]
            {
                new Line(1, 2, 3),
                new Line(3, 2, 1),
                new Line(1.7, 0.32, 3.4),
                new Line(3.5, 8.4),
                new Line(Math.PI, Math.E),
            };

            foreach (var line in lines)
            {
                var normal = line.FindNormalUnitVector();
                var parallel = line.FindParallelUnitVector();
                Console.WriteLine($"Line: {line} Normal: {normal} Parallel: {parallel}");
            }
        }

        /// <summary>
        /// Expr8.
        /// Дана прямая L и точка A.
        /// Найти точку пересечения прямой L с перпендикулярной ей прямой P, проходящей через точку A.
        /// Можете считать, что прямая задана либо двумя точками, либо коэффициентами уравнения прямой — как вам удобнее.
        /// </summary>
        public static void Exercise8()
        {
            Console.WriteLine("=> Exercise 8 demo");

            var linesAndPoints = new[]
            {
                (new Line(3, 14), new Vector2(-7, 12)),
                (new Line(9, 2), new Vector2(6, 8)),
                (new Line(3.14, -14.02), new Vector2(14.71f, 13.66f)),
                (new Line(17, -4.39), new Vector2(1.11f, 2.21f)),
            };
            
            foreach (var (line, point) in linesAndPoints)
            {
                var projection = line.Project(point);
                Console.WriteLine($"Point({point}) orthogonal projection on {line} is {projection}");
            }
        }

        public static class Solution
        {
            public static (T, T) Swap<T>(T first, T second)
            {
                (first, second) = (second, first);
                return (first, second);
            }

            public static string ReverseText(string text)
            {
                return new string(text.Reverse().ToArray());
            }

            public static int RotateInteger(int number)
            {
                string textRepresentation = number.ToString();
                textRepresentation = ReverseText(textRepresentation);
                return int.Parse(textRepresentation);
            }

            public static int MeasureClockArrowsAngle(uint hour)
            {
                if (hour >= 24)
                {
                    throw new ArgumentOutOfRangeException(nameof(hour));
                }

                const int degreesPerHour = 30;
                const int maxClockHour = 12;
                int clockHour = (int) hour % 12;

                if (clockHour <= 6)
                {
                    return clockHour * degreesPerHour;
                }

                return (maxClockHour - clockHour) * degreesPerHour;
            }

            /// <summary>
            /// Count numbers that is divided by both "x" and "y" in range (0, n].
            /// </summary>
            /// <param name="x">First Divisor</param>
            /// <param name="y">Second Divisor</param>
            /// <param name="n">Range (0, n] to search for divided numbers</param>
            /// <returns>Resulting count of divided numbers</returns>
            public static uint CountCommonDividedInRange(uint x, uint y, uint n)
            {
                uint count = 0;
                long commonDivisor = x * y;
                long currentNumber = commonDivisor;
                while (currentNumber <= n)
                {
                    count++;
                    currentNumber += commonDivisor;
                }

                return count;
            }

            /// <summary>
            /// Count number of leap years in dates range [begin, end].
            /// </summary>
            /// <param name="begin">Begin year</param>
            /// <param name="end">End year</param>
            /// <returns>Number of leap years</returns>
            public static uint CountLeapYearsInRange(uint begin, uint end)
            {
                if (end < begin)
                {
                    throw new ArgumentOutOfRangeException(nameof(end));
                }

                uint count = 0;

                for (uint year = begin; year <= end; year++)
                {
                    if ((year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0)))
                    {
                        count++;
                    }
                }

                return count;
            }

            public static double MeasureLineToPointDistance(Vector2 linePointA, Vector2 linePointB, Vector2 point)
            {
                var line = new Line(linePointA, linePointB);
                return line.MeasureDistance(point);
            }
        }
    }
}