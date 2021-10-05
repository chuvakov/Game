using System;
using System.Collections.Generic;

namespace Lesson_11__games_.Models
{
    public class Game
    {
        public string Name { get; set; }
        public List<Account> Acounts { get; set; }

        public Game()
        { }

        public Game(string name)
        {
            Name = name;            
            Acounts = new List<Account>(); //создаем пустой список и кладем ссылку на него в переменную                      
        }

        public Game(string name, List<Account> acounts) : this(name)
        {
            if (acounts != null)
            {
                Acounts = acounts; // кладем в переменную ссылку на готовый список 
            }
            else
            {
                Acounts = new List<Account>();
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


        public Account CreateAccount(string login, string password)
        {
            if (IsExistAccount(login, password))
            {
                Menu.PrintEror("Такой аккаунт уже есть");
                return null;
            }
            else
            {
                Account account = new Account(Guid.NewGuid().ToString());
                account.Login = login;
                account.Password = password;

                Acounts.Add(account);

                return account;
            }
        }

        private bool IsExistAccount(string login, string password)
        {
            foreach (Account acount in Acounts)
            {
                if (login == acount.Login && password == acount.Password)
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteAccount(Account acount)
        {
            Acounts.Remove(acount);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
