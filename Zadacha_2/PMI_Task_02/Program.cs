using System;

namespace PMI_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("ВЫ можете написать тут свой текст, для выхода напишите exit"); //Обращение к пользователю

            string message = (Console.ReadLine( )); //Инициализация переменной в которую копируются значения, введенну пользователем
          

            while (true) //Условия цикла всегда true, вечный цикл
            {
                if (message.CompareTo("exit") == 0) //Сравление значения переменной с нужным словом
                {
                    break; //Остановка цикла
                }
                message = Console.ReadLine(); //Ввод значения с клавиатуры
            }
        }
    }
}
