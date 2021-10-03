using Lesson_11__games_.Enums;
using Lesson_11__games_.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lesson_11__games_
{
    class Program
    {
        static void Main(string[] args)
        {             
            List<Game> games = new List<Game>();
            List<Player> players = new List<Player>();
            
            while (true)
            {
                Console.Clear();
                Menu.PrintBaseMenu();     
            
                BaseCommand? command = Menu.GetBaseCommand();                 
                
                if (command.HasValue)   // это команда есть только у типов данных с ?знаком на конце
                {
                    switch (command)
                    {                        
                        case BaseCommand.CreatePlayer:
                            {
                                Menu.PrintTitle("Выбрана команда - Создать игрока");

                                Console.WriteLine("Введите Ник игрока:");
                                string namePlayer = Console.ReadLine();

                                Player player = new Player(namePlayer);
                                players.Add(player);

                                Menu.PrintSuccess("Создание игрока прошло успешно");
                                Thread.Sleep(2000);
                                break;
                            }

                        case BaseCommand.DeletePlayer:
                            Console.Clear();
                            Console.WriteLine("Выбрана команда - Удалить игрока");
                            break;

                        case BaseCommand.SelectPlayer:
                            Console.Clear();
                            Console.WriteLine("Выбрана команда - Выбрать игрока");
                            break;

                        case BaseCommand.CreateGame:
                            {
                                Menu.PrintTitle("Выбрана команда - Создать игру");
                                Console.WriteLine("Введите название игры:");

                                Game game = new Game(Console.ReadLine());
                                games.Add(game);

                                Menu.PrintSuccess("Создание игры прошло успешно");
                                Thread.Sleep(2000);  //заставить поток уснуть (зависнуть)
                                break;
                            }

                        case BaseCommand.DeleteGame:
                            {
                                Menu.PrintTitle("Выбрана команда - Удалить игру");

                                Game.PrintGames(games);

                                Console.WriteLine($"\nКакую игру удалить?");

                                if (int.TryParse(Console.ReadLine(), out int numberGame))
                                {
                                    if (numberGame < 1 || numberGame > games.Count)
                                    {
                                        Menu.PrintEror("Такой игры нет в списке установленых игр");
                                        Thread.Sleep(2000);
                                        break;
                                    }

                                    games.RemoveAt(numberGame - 1); // -1 т.к. нумерация с 0 в списке

                                    Menu.PrintSuccess("Удаление игры прошло успешно");
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    Menu.PrintEror("Вы ввели некоректную информацию");
                                    Thread.Sleep(2000);
                                }
                                break;
                            }

                        case BaseCommand.ShowListGame:
                            {
                                Menu.PrintTitle("Выбрана команда - Просмотреть список игр");
                                Game.PrintGames(games);

                                Console.WriteLine("\nДля продолжения работы программы, нажмите любую клавишу");
                                Console.ReadLine();
                                break;
                            }

                        case BaseCommand.Exit:                            
                            return;                            
                    }               
                }
            }
        }
    }
}
