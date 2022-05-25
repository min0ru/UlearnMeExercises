using System;

namespace UlearnMeExercises
{
    /// <summary>
    /// https://ulearn.me/course/basicprogramming/Zadachi_na_seminar_d6cc4e30-a72f-4daa-ac1f-aa9e69deb91f?autoplay=true
    /// </summary>
    public class Seminar2
    {
        /// <summary>
        /// Expr10.
        /// Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.
        /// </summary>
        public static void Exercise10()
        {
            Console.WriteLine("=> Excercise 10 demo");
            int sum;
            sum = Solution.SumNumbersWithDividers(0, 10, new int[] { 3, 5 });
            Console.WriteLine($"Sum of numbers that is divided by 3 and 5 from 0 to 10 is {sum}");
            sum = Solution.SumNumbersWithDividers(0, 100, new int[] { 3, 5 });
            Console.WriteLine($"Sum of numbers that is divided by 3 and 5 from 0 to 100 is {sum}");
            sum = Solution.SumNumbersWithDividers(0, 1000, new int[] { 3, 5 });
            Console.WriteLine($"Sum of numbers that is divided by 3 and 5 from 0 to 1000 is {sum}");
        }

        /// <summary>
        /// Expr11.
        /// Дано время в часах и минутах.
        /// Найти угол от часовой к минутной стрелке на обычных часах.
        /// </summary>
        public static void Exercise11()
        {
            Console.WriteLine("=> Excercise 11 demo");
            var exampleClocks = new[]
            {
                (0, 0),
                (10, 20),
                (23, 54),
                (18, 57),
                (13, 21),
            };

            foreach (var (hour, minute) in exampleClocks)
            {
                var angle = Solution.CalculateAngleBetweenClockArrows(hour, minute);
                Console.WriteLine(
                    $"Angle between clock arrows at {hour}:{minute} is {angle} degrees.");
            }
        }

        /// <summary>
        /// Expr12.
        /// Timus Online Judge #1885 Комфорт пассажиров. 
        /// https://acm.timus.ru/problem.aspx?num=1885
        /// Самолёт должен набрать высоту h метров в течение первых t секунд полёта и удерживать её в течение всего полёта.
        /// Разрешён набор высоты со скоростью не более чем v метров в секунду.
        /// До полного набора высоты запрещено снижаться.
        /// Известно, что уши заложены в те и только те моменты времени, когда самолёт поднимается со скоростью более x метров в секунду.
        /// Посчитайте минимальное и максимальное возможное время, в течение которого у пассажиров будут заложены уши.
        /// Считайте, что самолёт способен изменять скорость мгновенно.
        /// </summary>
        public static void Exercise12()
        {
            Console.WriteLine("=> Excercise 12 demo");
        }

        /// <summary>
        /// Expr13.
        /// Timus Online Judge #1084 Пусти козла в огород.
        /// https://acm.timus.ru/problem.aspx?num=1084
        /// Козла пустили в квадратный огород и привязали к колышку.
        /// Колышек воткнули точно в центре огорода.
        /// Козёл ест всё, до чего дотянется, не перелезая через забор огорода и не разрывая веревку.
        /// Какая площадь огорода будет объедена? Даны длина веревки и размеры огорода.
        /// </summary>
        public static void Exercise13()
        {
            Console.WriteLine("=> Excercise 13 demo");
        }

        public static class Solution
        {
            /// <summary>
            /// Calculates sum of numbers in interval [from, to) dividable by one of given divisors. 
            /// </summary>
            /// <param name="from">Interval begin (included).</param>
            /// <param name="to">Interval end (excluded).</param>
            /// <param name="dividers">Array of divisors to test on.</param>
            /// <returns>Sum of numbers.</returns>
            public static int SumNumbersWithDividers(int from, int to, int[] dividers)
            {
                int sum = 0;
                for (int i = from; i < to; i++)
                {
                    foreach (var divider in dividers)
                    {
                        if (i % divider == 0)
                        {
                            sum += i;
                            break;
                        }
                    }
                }

                return sum;
            }

            /// <summary>
            /// Calculates angle between hour and minute arrow of clocks in degrees.
            /// </summary>
            /// <param name="hour">Hour between [0, 24).</param>
            /// <param name="minute">Minute between [0, 60).</param>
            /// <returns>Angle in degrees.</returns>
            public static double CalculateAngleBetweenClockArrows(int hour, int minute)
            {
                int maxHour = 12;
                int maxMinute = 60;
                double degreePerHour = 360.0 / maxHour;
                double degreePerMinute = 360.0 / maxMinute;

                hour %= maxHour;
                var hourArrowAngle = (360.0 / 12) * hour;
                var minuteArrowAngle = (360.0 / 60) * minute;
                var angle = Math.Abs(hourArrowAngle - minuteArrowAngle);
                angle = angle > 180 ? 180 - (angle % 180) : angle;

                return angle;
            }

            public static (double tMin, double tMax) CalculateMinMaxTimeOfBlockedEarsOnPlane(
                int h,
                int t,
                int v,
                int x
            )
            {
                throw new NotImplementedException("Implement me!");
            }
        }
    }
}