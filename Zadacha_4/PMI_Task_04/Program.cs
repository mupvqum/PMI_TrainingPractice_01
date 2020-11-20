using System;

namespace PMI_Task_04
{
    /* Создаем класс "Существо" для последующего создания босса и игрока
     * Так было сделано для того, чтобы не писать одинаковые свойства
     * Босса и игрока, а просто их унаследовать.
     */
    public class Entity 
    {
        public int life;
        public int power;
        public int state;
    }

    /*
     * Создаем игрока. Дополнительное свойство - мораль
     */
    class Player : Entity
    {
        public int morale;
    }

    /*
     * Создаем босса. У боса нет дополнительных свойств, однако
     * для удобочитаемости и чтобы избежать подобного конфуза:
     *    Entity boss = new Entity();
     *    Player player = new Player(); <- То есть игрок изначально является боссом, т.е. злом
     * создаем отдельный класс.
     */
    class Boss : Entity { }

    class Program
    {
        //Создаем глобальные переменные с заклинаниями
        const string fireBoll = "FIREBOLL";
        const string fireWall = "FIREWALL";
        const string covertAttack = "COVERT ATTACK";
        const string invisibility = "INVISIBILITY";
        const string phoenix = "PHORNIX";
        const string raisingMorale = "RAISING MORALE";

        static void Main(string[] args)
        {
            //Создаем экземпляры наших классов: босса и игрока
            Boss boss = new Boss();
            Player player = new Player();
            //Присваиваем случайные значения
            Random random = new Random();
            boss.life = random.Next(50, 500);
            player.life = random.Next(50, 500);
            player.morale = random.Next(1, 15);

            int roundNum = 1; //Инициализация счетчика раундов
            //Сюжетные реплики
            System.Console.WriteLine("Помощник: слушай, у нас проблемы" + "\n" + "Этот тип похоже силен, будь бдителен, нам нужно успеть спасти твоего товарища" + "\n");
            System.Console.WriteLine("Босс: так, так, так" + "\n" + "Неужели до меня добрался достойный соперник?" + "\n" + "Ну чтож, поглядим..." + "\n");
            //Описание заклинаний
            System.Console.WriteLine("Список заклинаний и их характеристики:" + "\n");
            System.Console.WriteLine("FIREBOLL: наносит 80 ед. урона, сила атаки увеличивается за счет боевого духа игрока, отнимает 20 ед.жизни" + "\n");
            System.Console.WriteLine("FIREWALL: восстанавливает 120 ед. жизни, игрок не может атаковать босса в течении одного раунда" + "\n");
            System.Console.WriteLine("COVERT ATTACK: наносит 120 ед. урона, босс не может атаковать в ответ, снижает показатель боевого духа до нуля, отнимает 80 ед. жизни" + "\n");
            System.Console.WriteLine("INVISIBILITY: делает игрока невидимым на 2 раунда, отнимает 50 ед.жизни" + "\n");
            System.Console.WriteLine("RAISING MORALE: поднимает боевой дух, увеличивая силу атаки, отнимает 18 ед. жизни" + "\n");

            string spell; //Инициализация переменной, в которой будет хранится заклининие, введенное пользователем 
            
            while (player.life > 0 && boss.life > 0) //Условие длительности игры, пока показатель жизни босса и игрока больше нуля, работаем
            {
                boss.power = random.Next(10, 120); //Присвоение силе удара босса разную величину, показатель меняется в каждом раунде
                System.Console.WriteLine("РАУНД №" + roundNum++); //Вывод номера раунда, затем увеличение номера на 1
                //Вывод ключевых показателей игроку
                System.Console.WriteLine("Уровень жизни босса: " + boss.life + "\n" + "Уровень жизни игрока: " + player.life + "\n" + "Уровень боевого духа игрока: " + player.morale + "\n" + "Уровень силы атаки босса: " + boss.power);
                System.Console.Write("Прочитайте заклинание: ");
                
                spell = System.Console.ReadLine(); //Ввод заклинания с клавиатуры

                PlayerAttack(spell, ref player, ref boss); //Вызов функции, которая отвечет за действие зклинаний
            }
            //Вывод пользователю, результата игры (кто победил)
            if (player.state < 0) 
            {
                System.Console.WriteLine("Вы проиграли!");
            } else if (boss.life < 0)
            {
                System.Console.WriteLine("Вы победили!");
            }
                        
        }
        static public void PlayerAttack(string spell, ref Player player, ref Boss boss) //Инициализация функции
        {
            bool bossMiss = boss.state != 0; 
            bool playerMiss = player.state != 0;
            int moralPower = (player.morale / 2 <= 0) ? 1 : player.morale / 2;
     
            //Определение действий заклинания, введенного пользователем
            if (spell == fireBoll) 
            {
                boss.life -= (playerMiss) ? 0 : 80 * moralPower;
                player.life += (bossMiss) ? 0 : 20 - boss.power;
            }
            else if (spell == fireWall)
            {
                player.life += (playerMiss) ? 0 : 120 - boss.power;
                player.state += 1;
            }
            else if (spell == covertAttack)
            {
                boss.life -= (playerMiss) ? 0 : 120 * moralPower;
                player.life -= 80;
                player.morale = 0;
                boss.state += 1;
            }
            else if (spell == invisibility)
            {
                player.life -= 50;
                boss.state += 2;
            }
            else if (spell == raisingMorale)
            {
                player.life -= (bossMiss) ? 18 : 18 + boss.power;
                player.power += 20;
                player.morale += 10;
            }
            if (playerMiss)
            {
                player.state--;
            } 
            if (bossMiss)
            {
                boss.state--;
            }
        }
    }

}
