using System;

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

        static void Main(string[] args)
        {
            int sizeArray;
            int minValueArray;
            int maxValueArray;

            Console.Write("Введите размер числового массива: ");
            sizeArray = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минимальное значение целочисленного массива: ");
            minValueArray = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимальное значение целочисленного массива (не включительно):  ");
            maxValueArray = Convert.ToInt32(Console.ReadLine());

            string[] arrayNumbers = GenerateArrayStringNumber(sizeArray, minValueArray, maxValueArray);
            //Array.Sort(arrayNumbers);
        }
    }
}
