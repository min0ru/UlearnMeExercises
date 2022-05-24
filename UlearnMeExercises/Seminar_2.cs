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
        }
    }
}