using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LabPLinq
{
    internal class Program
    {
        /// <summary>
        /// Генерирует массив случайных чисел в строковом представлении
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="minValue">Минимальное значение чисел</param>
        /// <param name="maxValue">Максимальное значение чисел (не включительно)</param>
        /// <returns>Массив целых чисел в строковом представлении</returns>
        static string[] GenerateArrayStringNumber(int size, int minValue, int maxValue)
        {
            int[] numbers = new int[size];
            string[] arrayNumbers = new string[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                numbers[i] = rand.Next(minValue, maxValue);
                arrayNumbers[i] = numbers[i].ToString();
            }
            
            return arrayNumbers;
        }

        /// <summary>
        /// Вывод списка в консоль
        /// </summary>
        /// <param name="message">Поясняющее сеообщение о выводе</param>
        /// <param name="time">Информация о времени выполнения</param>
        /// <param name="arrayNumbers">Список, который требуется вывести</param>
        static void PrintArray(string message, double time, List<int> arrayNumbers)
        {
            Console.WriteLine(message + " (" + time.ToString() + " мс):");
            for (int i = 0; i < arrayNumbers.Count; i++)
            {
                Console.WriteLine(arrayNumbers[i]);
            }
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// Вывод времени выполнения запроса
        /// </summary>
        /// <param name="message">Информация о запросе</param>
        /// <param name="time">Время выполнения запроса</param>
        static void PrintTimeExecution(string message, double time)
        {
            Console.WriteLine(message + " время выполнения запроса = " + time.ToString() + " мс");
        }

        /// <summary>
        /// Поиск четных чисел в строковом массиве
        /// </summary>
        /// <param name="arrayNumbers">Строковый массив для поиска</param>
        /// <param name="time">Время выполнения запроса</param>
        /// <returns>Отсортированный по убыванию строковый массив четных чисел</returns>
        static List<int> FindEvenNumbers(string[] arrayNumbers, out double time)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;
            int[] tempArray = arrayNumbers.Select(str => Int32.Parse(str)).ToArray();

            stopwatch.Start();
            List<int> evenNumbers = tempArray.Where(i => i % 2 == 0).OrderByDescending(i => i).ToList();
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;

            return evenNumbers;
        }

        /// <summary>
        /// Параллельный поиск четных чисел в строковом массиве
        /// </summary>
        /// <param name="arrayNumbers">Строковый массив для поиска</param>
        /// <param name="time">Время выполнения запроса</param>
        /// <returns>Отсортированный по убыванию строковый массив четных чисел</returns>
        static List<int> FindEvenNumbersParallel(string[] arrayNumbers, out double time)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;
            int[] tempArray = arrayNumbers.Select(str => Int32.Parse(str)).ToArray();

            stopwatch.Start();
            List<int> evenNumbers = tempArray.AsParallel().Where(i => i % 2 == 0).OrderByDescending(i => i).ToList();
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;

            return evenNumbers;
        }

        static void Main(string[] args)
        {
            int sizeArray;
            int minValueArray;
            int maxValueArray;
            double time;

            Console.Write("Введите размер числового массива: ");
            sizeArray = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минимальное значение целочисленного массива: ");
            minValueArray = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимальное значение целочисленного массива (не включительно):  ");
            maxValueArray = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            string[] arrayNumbers = GenerateArrayStringNumber(sizeArray, minValueArray, maxValueArray);

            List<int> evenNumbers = FindEvenNumbers(arrayNumbers, out time);
            PrintTimeExecution("Четные числа", time);
            //PrintArray("Четные числа", time, evenNumbers);
            List<int> evenNumbersParallel = FindEvenNumbersParallel(arrayNumbers, out time);
            PrintTimeExecution("Четные числа (параллельно)", time);
            //PrintArray("Четные числа (параллельно)", time, evenNumbersParallel);
        }
    }
}