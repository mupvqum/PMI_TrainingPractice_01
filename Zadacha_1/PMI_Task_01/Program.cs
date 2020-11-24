using System;

namespace PMI_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Здравствуй путник, ты забрел в лавку хранителя кристаллов"); //Приветствие
            System.Console.Write("Сколько золота в твоем кошельке: "); //Вывод на экран требований к пользователю, ввести начальное количество золота
            int goldAmount = int.Parse(Console.ReadLine()); //Инициализация переменной и последующее копирование значения, введенного пользователем в переменную (количество золота в кошельке)
            
            int priceForOneCrystal = 4; //Инициализация переменной, в которой будет храниться значение цены за один кристалл
            
            int maxAmountForAllCrystal = goldAmount / priceForOneCrystal; //Инийиализация переменной, в которой хранится максимальное количество кристаллов, которое может купить пользователь
            System.Console.WriteLine("Максимальное количество кристаллов, которое ты можешь купить: " + maxAmountForAllCrystal); //Вывод максимального количества кристаллов, которое может приобрести пользователь
                        
            System.Console.Write("Введи количество кристаллов, которое хочешь купить: "); // Вывод на экран требований к пользователю, ввести количество приобретаемых кристаллов
            int crystalAmount = int.Parse(Console.ReadLine()); //Инициализация переменной и последующее копирование значения, введенного пользователем в переменную (количество приобретаемых кристаллов)           
            
            int priceForAllCrystal = priceForOneCrystal * crystalAmount; //Инициализация переменной и последующее копирование в нее значения, с помощью вычисления общей цены за все 

            if (crystalAmount > 0 && crystalAmount <= maxAmountForAllCrystal)
            {
                goldAmount -= priceForAllCrystal; //Конвертация золота
                System.Console.WriteLine("Цена за все кристаллы = " + priceForAllCrystal); //Вывод цены за все кристаллы на экран
                System.Console.WriteLine("Остаток золота = " + goldAmount); //Вывод пользователю остатка золота после конвертации
                System.Console.WriteLine("Количество кристаллов = " + crystalAmount); //Вывод пользователю количество приобретенных кристаллов
            }
            else System.Console.WriteLine("Недостаточно ресурсов"); 
        }
    }
}
