using System;
using System.Collections.Generic;

namespace Lesson_11__games_.Models
{
    public class Game
    {
        public string Name { get; set; }
        public List<Acount> Acounts { get; set; }        

        //public List<Game> Games { get; set; } //**

        public Game()
        {
            //Games = new List<Game>();//**
        }

        public Game(string name)
        {
            Name = name;
            //Games = new List<Game>();  //**
            Acounts = new List<Acount>(); //создаем пустой список и кладем ссылку на него в переменную                      
        }

        public Game(string name, List<Acount> acounts) : this(name)
        {
            if (acounts != null)
            {
                Acounts = acounts; // кладем в переменную ссылку на готовый список 
            }
            else
            {
                Acounts = new List<Acount>();
            }
        }

        public static void PrintGames(List<Game> games)
        {
            int i = 1;

            foreach (Game game in games)
            {
                Console.WriteLine($"{i}. {game.Name}");
                i++;
            }
        }


        public Acount CreateAccount(string login, string password)
        {
            if (IsExistAccount(login, password))
            {
                Console.WriteLine("Такой аккаунт уже есть");
                return null;
            }
            else
            {
                Acount account = new Acount(Guid.NewGuid().ToString());
                account.Login = login;
                account.Password = password;

                Acounts.Add(account);

                return account;
            }
        }

        private bool IsExistAccount(string login, string password)
        {
            foreach (Acount acount in Acounts)
            {
                if (login == acount.Login && password == acount.Password)
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteAccount(Acount acount)
        {
            Acounts.Remove(acount);
        }
    }
}
