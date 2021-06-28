using System;
using System.Linq;

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
            (first, second) = Solution.SwapVariables(first, second);
            Console.WriteLine($"Variables after exchange: {first} {second}");

            string sFirst = "Hello,", sSecond = "Sailor!";
            Console.WriteLine($"Variables before exchange: {sFirst} {sSecond}");
            (sFirst, sSecond) = Solution.SwapVariables(sFirst, sSecond);
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
                int angle = Solution.GetClockArrowsAngle(hour);
                Console.WriteLine($"Clocks arrows angle at hour {hour} is {angle}");
            }
        }

        public class Solution
        {
            public static (T, T) SwapVariables<T>(T first, T second)
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

            public static int GetClockArrowsAngle(uint hour)
            {
                if (hour >= 24)
                {
                    throw new ArgumentOutOfRangeException(nameof(hour));
                }

                const int degreesPerHour = 30;
                const int maxClockHour = 12;
                int clockHour = (int)hour % 12;

                if (clockHour <= 6)
                {
                    return clockHour * degreesPerHour;
                }

                return (maxClockHour - clockHour) * degreesPerHour;
            }
        }
    }
}