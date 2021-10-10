using Games.Application.Enums;
using Games.Application.Models;
using System;
using System.Threading;

namespace Games.ConsoleApp.Models
{
    public static class PlayerMenu
    {

        private static void Print() //дз
        {
            string menu =
                "1. Добавить игру\n" +
                "2. Создать аккаунт\n" +
                "3. Напечатать информацию о игроке\n" +
                "4. Выйти из игрока\n";

            Console.WriteLine(menu);
        }

        private static PlayerComand? GetComand()
        {
            PlayerComand? result;

            Console.Write("Введите пункт меню и нажмите клавишу 'ENTER': ");
            if (int.TryParse(Console.ReadLine(), out int inputCommand))
            {
                if (Enum.IsDefined(typeof(PlayerComand), inputCommand))
                {
                    result = (PlayerComand)inputCommand;
                }
                else
                {
                    Console.WriteLine("Такого пункта меню не существует, попробуйте снова.");
                    result = null;
                }
            }
            else
            {
                Console.WriteLine("Такого пункта меню не существует, попробуйте снова.");
                result = null;
            }

            return result;
        }

        public static void Init(Player player)
        {
            while (true)
            {
                Console.Clear();
                Print();

                PlayerComand? command2 = GetComand();

                if (command2.HasValue)
                {
                    switch (command2)
                    {
                        case PlayerComand.AddGame:
                            Menu.PrintTitle("Выбрана команда - Добавить игру");

                            Console.WriteLine("Введите название игры:");
                            string nameGame = Console.ReadLine();
                            Game game = new Game(nameGame);

                            player.Game = game;

                            Menu.PrintSuccess("Создание игры прошло успешно");
                            Thread.Sleep(2000);
                            break;

                        case PlayerComand.CreateAccount:
                            Menu.PrintTitle("Выбрана команда - Создать аккаунт");

                            Console.Write("Введите Логин: ");
                            string login = Console.ReadLine();

                            Console.Write("Введите Пароль: ");
                            string password = Console.ReadLine();

                            player.CreateAccount(login, password);
                            Thread.Sleep(2000);
                            break;

                        case PlayerComand.PrintInfo:
                            Menu.PrintTitle("Выбрана команда - Показать информацию игрока");

                            Console.WriteLine(player);

                            Console.WriteLine("Для возврата в предыдущее меню, нажмите любую клавишу");
                            Console.ReadLine();

                            //после того как найдем игрока
                            //нужно обратиться от него к акаунту и показать всю инфу акккаунта + никнейм + 
                            // + возможно нужно переделать переменную игры в список игр, так как у игрока может быть много игр
                            // и показать список его игр
                            break;

                        case PlayerComand.Exit:
                            return;
                    }
                }
            }
        }

    }
}
