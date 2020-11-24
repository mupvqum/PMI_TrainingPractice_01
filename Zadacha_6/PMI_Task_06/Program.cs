using System;
using System.Collections;

namespace PMI_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {   
            string[] fullName = new string[0]; //Масссив хранящий ФИО
            string[] position = new string[0]; //Массив хранящий должность
            
            int lenghtFullName = 0;
            lenghtFullName = fullName.Length;

            int lenghtPosition = 0;
            lenghtPosition = position.Length;

            while (true)
            {   //Интерфейс
                System.Console.WriteLine(" Отдел кадров");
                System.Console.WriteLine(" 1" + " - " + "добавить досье");
                System.Console.WriteLine(" 2" + " - " + "вывести все досье");
                System.Console.WriteLine(" 3" + " - " + "удалить досье");
                System.Console.WriteLine(" 4" + " - " + "поиск по фамилии");
                System.Console.WriteLine(" 5" + " - " + "выход");

                System.Console.Write("\n " + "Введите пункт меню: ");
                int menuItem = getNumber(); 

                if (menuItem == 1)
                {
                    AddFunction(ref fullName, ref position);
                }
                else if (menuItem == 2)
                {
                    OutputFunction(ref fullName, ref position);
                }
                else if (menuItem == 3)
                {
                    DeleteFunction(ref fullName, ref position);
                }
                else if (menuItem == 4)
                {
                    SearchLastNameFunction(ref fullName, ref position);
                }
                else if (menuItem == 5)
                {
                    break;
                }
                System.Console.Write(" Нажмите любую клавишу: ");
                System.Console.ReadKey(false);
                System.Console.Clear();
            }          
        }
        //Функция добавления досье
        static void AddFunction(ref string[] fullName, ref string[] position)
        {
            Array.Resize(ref fullName, fullName.Length + 1); //Расширение массивов
            Array.Resize(ref position, position.Length + 1);
            string fio = "";
            System.Console.WriteLine("\n Добавление досье");
            System.Console.Write(" Введите фамилию: ");
            fio += Console.ReadLine() + " ";
            System.Console.Write(" Введите имя: ");
            fio += Console.ReadLine() + " ";
            System.Console.Write(" Введите отчество: ");
            fio += Console.ReadLine() + " ";

            System.Console.Write(" Введите должность: ");
            fullName[fullName.Length - 1] = fio;
            position[position.Length - 1] = Console.ReadLine();

            System.Console.WriteLine("\n Данные занесены!");
        }
        //Функция вывода досье
        static void OutputFunction(ref string[] fullName, ref string[] position)
        {
            if (fullName.Length <= 0)
            {
                System.Console.WriteLine(" Досье отсутствуют, для добавления досье введите 1");
                return;
            }
            
            System.Console.WriteLine(" Вывод досье:" + "\n");

            for(int i = 0; i < fullName.Length; i++)
            {
                System.Console.WriteLine(i + 1 + " "+ fullName[i] + " - " + position[i]);
            }
        }
        //Функция удаления досье
        static void DeleteFunction(ref string[] fullName, ref string[] position)
        {
            System.Console.Write(" Для удаления введите номер досье: ");
            int deleteNum = getNumber();

            if (fullName.Length <= 0)
            {
                System.Console.WriteLine(" Досье отсутствуют, для добавления досье введите 1");
                return;
            }
            
            if (deleteNum < 1 || deleteNum > fullName.Length)
            {
                System.Console.WriteLine(" Досье с таким номером не существует");
                return;
            }

            deleteNum--;

            Array.Copy(fullName, deleteNum + 1, fullName, deleteNum, fullName.Length - deleteNum - 1);
            Array.Copy(position, deleteNum + 1, position, deleteNum, position.Length - deleteNum - 1);

            Array.Resize(ref fullName, fullName.Length - 1);
            Array.Resize(ref position, position.Length - 1);

            System.Console.WriteLine(" Досье удалено!");
        }
        //Функция поиска по фамилии
        static void SearchLastNameFunction(ref string[] fullName, ref string[] position) 
        {
            if (fullName.Length <= 0)
            {
                System.Console.WriteLine(" Досье отсутствуют, для добавления досье введите 1");
                return;
            }

            System.Console.Write(" Введите фамилию:");
            string lastName = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {
                if (fullName[i].Contains(lastName))
                {
                    System.Console.WriteLine(" {0}: {1} - {2}", i + 1, fullName[i], position[i]);
                    return;
                }                   
            }
            System.Console.WriteLine(" В досье не нашлось людей с этой фамилией");

        }
        //Функция получения числа
        static int getNumber()
        {
            int num = 0;
            string inputLine;
            do
            {
                inputLine = System.Console.ReadLine();
                if(int.TryParse(inputLine, out num)) {
                    return num;
                }
            } while (true);
        }
       
    } 
}
