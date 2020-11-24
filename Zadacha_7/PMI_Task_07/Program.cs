using System;

namespace PMI_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Введите размер одномерного массива: "); 
            int size = int.Parse(Console.ReadLine());
            
            int[] arrayOfNumbers = new int[size]; //Инициализация массива с размеров равынм введенному пользователем значению
            //ВЫзов функции заполнения массива случайными числами от 1 до 1000
            FillingArrayFunction(ref arrayOfNumbers);

            System.Console.Write("\nОдномерный массив: [");
            //Вызоы функции вывода заполненного массива
            PrintArrayFunction(ref arrayOfNumbers);
            //Вызов функции изменения положения элементов в массиве
            ShuffleArrayFunction(ref arrayOfNumbers);

            System.Console.Write("Перемешенный массив: [");
            //Вызов функции вывода измененного массива
            PrintArrayFunction(ref arrayOfNumbers);
        }
        static void FillingArrayFunction(ref int[] arrayOfNumbers) //Функция заполнения массива
        {
            Random fillingArray = new Random();

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = fillingArray.Next(1, 1000);
            }
        }
        static void PrintArrayFunction(ref int[] arrayOfNumbers) //Функция вывода массива
        {   
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                if (i + 1 == arrayOfNumbers.Length)
                {
                    System.Console.Write(arrayOfNumbers[i]);
                }
                else
                {
                    System.Console.Write(arrayOfNumbers[i] + ", ");
                }
            }
            System.Console.WriteLine("]" + "\n");
        }
        static void ShuffleArrayFunction(ref int[] arrayOfNumbers) //Функция перемешивания элементов
        {
            Random random = new Random();
            int rIndex;
            int cap;

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                rIndex = random.Next(0, arrayOfNumbers.Length - 1);

                cap = arrayOfNumbers[rIndex];
                arrayOfNumbers[rIndex] = arrayOfNumbers[i];
                arrayOfNumbers[i] = cap;
            }
        }
    }
}
