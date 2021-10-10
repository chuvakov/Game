using Games.Application.Enums;
using System;
using System.Collections.Generic;

namespace Games.Application.Models
{
    public class Player : Human
    {
        public Account Account { get; set; }
        public string NickName { get; set; }
        public Game Game { get; set; }  //это свойство (поле это без Гет Сет)

        public Player(string nickName)
        {
            NickName = nickName;
        }

        public Player(string fio, int age, Gender gender, string nickName) : base(fio, age, gender)
        {
            NickName = nickName;
        }

        public Player(string fio, int age, Gender gender, string nickName, double money) : base(fio, age, gender, money)
        {
            NickName = nickName;
        }

        public static void PrintPlayers(List<Player> players)
        {
            int i = 1;            

            foreach (Player player in players)
            {
                Console.WriteLine($"{i}. {player.NickName}");                
                i++;                
            }            
        }

        /// <summary>
        /// Создаем аккаунт в игре (метод игрока)
        /// </summary>        
        public bool CreateAccount(string login, string password)
        {
            if (Game != null)
            {
                Account acount = Game.CreateAccount(login, password);

                if (acount != null)
                {
                    Account = acount;
                    Menu.PrintSuccess($"Аккаунт {acount} создан у игрока {NickName} - успешно");
                    return true;
                }

                return false;
            }
            else
            {
                Menu.PrintEror("Игра не установлена");
                return false;
            }
        }

        public void DeleteAccount()
        {
            Game.DeleteAccount(Account);
            Account = null;
            Console.WriteLine($"Аккаунт играка {NickName} из игры {Game.Name} удален");
        }

        public void SendMoney(double sumMoney)
        {
            if (sumMoney <= this.Money && this.Account != null)
            {
                this.Account.AddMoney(sumMoney);
                this.Money -= sumMoney;
            }
            else if (this.Account == null)
            {
                Console.WriteLine("Акаунта не существует");
            }
            else
            {
                Console.WriteLine("Запрашиваемая сумма превышает имеющуюся сумму");
            }
        }

        public void BackMoney(double sumMoney)
        {
            this.Money += this.Account.RemoveMoney(sumMoney);
        }

        public void Play()
        {
            if (this.Account.AuthorizationFlag == true)
            {
                Console.WriteLine($"игрок с ником вошел в систему и начал играть в игру (!!!!!название)");
            }
            else
            {
                while (this.Account.AuthorizationFlag == false)
                {
                    Console.WriteLine("Введите логин:");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();
                    this.Account.AuthorizationFlag = this.Account.AuthorizationCheck(login, password);
                    Console.WriteLine($"игрок с ником вошел в систему и начал играть в игру (!!!!!название)");
                }
            }
        }

        public override string ToString()
        {
            return 
                $"Аккаунт: {Account}\n" +
                $"Никнейм: {NickName}\n" +
                $"Игра: {Game}\n";
        }
    }
}
