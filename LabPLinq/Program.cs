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

         /// <summary>
        /// Поиск нечетных чисел в строковом массиве
        /// </summary>
        /// <param name="arrayNumbers">Строковый массив для поиска</param>
        /// <param name="time">Время выполнения запроса</param>
        /// <returns>Отсортированный по убыванию строковый массив нечетных чисел</returns>
        static List<int> FindOddNumbers(string[] arrayNumbers, out double time)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;
            int[] tempArray = arrayNumbers.Select(str => Int32.Parse(str)).ToArray();

            stopwatch.Start();
            List<int> evenNumbers = tempArray.Where(i => i % 2 == 1).OrderByDescending(i => i).ToList();
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;

            return evenNumbers;
        }

        /// <summary>
        /// Параллельный поиск нечетных чисел в строковом массиве
        /// </summary>
        /// <param name="arrayNumbers">Строковый массив для поиска</param>
        /// <param name="time">Время выполнения запроса</param>
        /// <returns>Отсортированный по убыванию строковый массив нечетных чисел</returns>
        static List<int> FindOddNumbersParallel(string[] arrayNumbers, out double time)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;
            int[] tempArray = arrayNumbers.Select(str => Int32.Parse(str)).ToArray();

            stopwatch.Start();
            List<int> evenNumbers = tempArray.AsParallel().Where(i => i % 2 == 1).OrderByDescending(i => i).ToList();
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;

            return evenNumbers;
        }

        /// <summary>
        /// Функция нахождения всех чисел чья сумма второй и предпоследней цифры равны заданному числу
        /// </summary>
        /// <param name="arrayNumbers">Строковый массив чисел</param>
        /// <param name="rightNumber">Число которое должно получится при сумме</param>
        /// <param name="time">Время выполнения</param>
        /// <returns>Список чисел у которых сумма второй и предпоследней цифры равны заданному числу</returns>
        static List<int> FindSumSecondAndPenultimateNumbers(string[] arrayNumbers, int rightNumber, out double time)
        {
            Func<string, int, bool> sumCertainDigit = (str, rightNumber) =>
              {
                  if (str.Length < 3)
                  {
                      return false;
                  }
                  int secondNumber = int.Parse(str[1].ToString());
                  int penultimateNumber = int.Parse(str[str.Length - 2].ToString());

                  if (secondNumber + penultimateNumber == rightNumber)
                  {
                      return true;
                  }
                  else
                  {
                      return false;
                  }
              };

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;

            stopwatch.Start();
            List<int> listNumbers = arrayNumbers.Where((str)=>sumCertainDigit(str,rightNumber)).Select(str => Int32.Parse(str)).OrderByDescending(i => i).ToList();
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;

            return listNumbers;
        }

        /// <summary>
        /// Функция нахождения всех чисел чья сумма второй и предпоследней цифры равны заданному числу
        /// </summary>
        /// <param name="arrayNumbers">Строковый массив чисел</param>
        /// <param name="rightNumber">Число которое должно получится при сумме</param>
        /// <param name="time">Время выполнения</param>
        /// <returns>Список чисел у которых сумма второй и предпоследней цифры равны заданному числу</returns>
        static List<int> FindSumSecondAndPenultimateNumbersParallel(string[] arrayNumbers, int rightNumber, out double time)
        {
            Func<string, int, bool> sumCertainDigit = (str, rightNumber) =>
            {
                if (str.Length < 3)
                {
                    return false;
                }
                int secondNumber = int.Parse(str[1].ToString());
                int penultimateNumber = int.Parse(str[str.Length - 2].ToString());

                if (secondNumber + penultimateNumber == rightNumber)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;

            stopwatch.Start();
            List<int> listNumbers = arrayNumbers.AsParallel().Where((str) => sumCertainDigit(str, rightNumber)).Select(str => Int32.Parse(str)).OrderByDescending(i => i).ToList();
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;

            return listNumbers;
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

            List<int> oddNumbers = FindOddNumbers(arrayNumbers, out time);
            PrintTimeExecution("Нечетные числа", time);
            //PrintArray("Нечетные числа", time, oddNumbers);

            List<int> oddNumbersParallel = FindOddNumbersParallel(arrayNumbers, out time);
            PrintTimeExecution("Нечетные числа (параллельно)", time);
            //PrintArray("Нечетные числа (параллельно)", time, oddNumbersParallel);

            List<int> sumCertainDigit = FindSumSecondAndPenultimateNumbers(arrayNumbers, 6, out time);
            PrintTimeExecution("Сумма второго и предпоследнего числа", time);
            //PrintArray("Сумма второго и предпоследнего числа", time, sumCertainDigit);

            List<int> sumCertainDigitParallel = FindSumSecondAndPenultimateNumbersParallel(arrayNumbers, 6, out time);
            PrintTimeExecution("Сумма второго и предпоследнего числа (параллельно)", time);
            //PrintArray("Сумма второго и предпоследнего числа (параллельно)", time, sumCertainDigitParallel);

            Console.WriteLine("\n\nНажмите любую клавишу для выхода: ");
            Console.ReadKey();
        }
    }
}