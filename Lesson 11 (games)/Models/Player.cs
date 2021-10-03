using Lesson_11__games_.Enums;
using System;

namespace Lesson_11__games_.Models
{
    public class Player : Human
    {
        public Acount Acount { get; set; }
        public string NickName { get; set; }
        public Game Game { get; set; }  //это свойство (поле это без Гет Сет)

        //public List<Game> Games { get; set; } //**

        public Player(string nickName)
        {
            NickName = nickName;
        }

        public Player(string fio, int age, Gender gender, string nickName) : base(fio, age, gender)
        {
            NickName = nickName;
            //Games = new List<Game>();
        }

        public Player(string fio, int age, Gender gender, string nickName, double money) : base(fio, age, gender, money)
        {
            NickName = nickName;
            //Games = new List<Game>();
        }

        //public void CreateGame() //**
        //{
        //    string gameName = Console.ReadLine();
        //    Game game = new Game(gameName);
        //    //game.Games.Add(game);
        //    //Games.Add(game);
        //}

        //public void ShowGameList() //**
        //{
        //    foreach (Game games in Games)
        //    {
        //        Console.WriteLine(games.Name);
        //    }
        //}

        /// <summary>
        /// Создаем аккаунт в игре (метод игрока)
        /// </summary>        
        public bool CreateAccount(string login, string password)
        {
            if (Game != null)
            {
                Acount acount = Game.CreateAccount(login, password);

                if (acount != null)
                {
                    Acount = acount;
                    Console.WriteLine($"Аккаунт {acount} создан у игрока {NickName}");
                    return true;
                }

                return false;
            }
            else
            {
                Console.WriteLine("Игра не установлена");
                return false;
            }
        }

        public void DeleteAccount()
        {
            Game.DeleteAccount(Acount);
            Acount = null;
            Console.WriteLine($"Аккаунт играка {NickName} из игры {Game.Name} удален");
        }

        public void SendMoney(double sumMoney)
        {
            if (sumMoney <= this.Money && this.Acount != null)
            {
                this.Acount.AddMoney(sumMoney);
                this.Money -= sumMoney;
            }
            else if (this.Acount == null)
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
            this.Money += this.Acount.RemoveMoney(sumMoney);
        }

        public void Play()
        {
            if (this.Acount.AuthorizationFlag == true)
            {
                Console.WriteLine($"игрок с ником вошел в систему и начал играть в игру (!!!!!название)");
            }
            else
            {
                while (this.Acount.AuthorizationFlag == false)
                {
                    Console.WriteLine("Введите логин:");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();
                    this.Acount.AuthorizationFlag = this.Acount.AuthorizationCheck(login, password);
                    Console.WriteLine($"игрок с ником вошел в систему и начал играть в игру (!!!!!название)");
                }
            }
        }
    }
}
