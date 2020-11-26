using System;
using System.IO;

namespace PMI_Task_05
{
    class Program
    {
        static int width = 5;
        static int height = 5;

        static int userPositionX = 2;
        static int userPositionY = 2;
        static int userLastPositionX = 2;
        static int userLastPositionY = 2;

        static int userLife = 100;
        const int minLife = 0;
        const int maxLife = 100;
        static bool win = false;
        static char[,] map;
        static void Main(string[] args)
        {
            LoadMap(); //Вызов функции подключения и загрузки файла с лабиринтом
            FindPlayer(); //Вызов функции нахождения местоположения игрока
            while (userLife != 0 && !win)
            {
                Print(); //Вызов функции вывода лабиринта и уровня жиизни
                UserMove(); //Вызов функции передвежения игрока по лабиринту
                UpdateMaze(); //Вызов функции обновления позиции пользователя в лабиринте
            }

            if(win)
            {
                Console.WriteLine("Вы выирали");
            }
            else
            {
                Console.WriteLine("Вы проиграли");
            }
        }
        //Функция отвечающая за печать лабиринта и уровня жизни
        static void Print()
        {
            Console.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    System.Console.Write(map[i,j]);
                }
                System.Console.WriteLine();
            }

            System.Console.Write("Life: [");
            for (int i = minLife; i < userLife; i += 10)
            {
                System.Console.Write("$");
            }
            for (int i = userLife + 1; i < maxLife; i += 10)
            {
                System.Console.Write("%");
            }
            System.Console.WriteLine("]");
        }
        //Функция отвечающая за перемещение пользователя по лабиринту
        static void UserMove()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            int x = userPositionX;
            int y = userPositionY;

            switch (pressedKey.Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    y++;
                    break;
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    return; 
            }
            if (map[y, x] == '#')
            {
                return;
            }
            if (map[y, x] == '*')
            {
                userLife -= 10;
            }
            if (map[y, x] == '-')
            {
                win = true;
            }
            userLastPositionX = userPositionX;
            userLastPositionY = userPositionY;
            userPositionX = x;
            userPositionY = y;
        }
        //Функция обновления позиции пользователя в лабиринте
        static void UpdateMaze()
        {
            map[userLastPositionY, userLastPositionX] = ' ';
            map[userPositionY, userPositionX] = '@';
        }
        //Функция подключения текстового файла
        static void LoadMap()
        {
            if(!File.Exists("Maze.txt"))
            {
                Console.WriteLine("Ошибка! Не найден файл с лабиринтом.");
                System.Environment.Exit(-1);
            }

            string[] maze = File.ReadAllLines("Maze.txt");
            int maxWidth = 0;
            foreach(string line in maze)
            {
                if(maxWidth < line.Length)
                {
                    maxWidth = line.Length;
                }
            }
            map = new char[maze.Length, maze[0].Length];
            int i = 0, j = 0;
            foreach(string line in maze)
            {
                foreach(char block in line)
                {
                    map[i, j] = block;
                    ++j;
                }
                j = 0;
                ++i;
            }
            width = maxWidth;
            height = maze.Length;
        }
        //Функция нахождения местоположения игрока
        static void FindPlayer()
        {
            for(int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {
                    if(map[i, j] == '@')
                    {
                        userLastPositionX = userPositionX = j;
                        userLastPositionY = userPositionY = i;
                        return;
                    }
                }
            }
            Console.WriteLine("Не могу найти игрока!");
            System.Environment.Exit(-2);
        }
    }
}
