using System;


namespace Games.Application.Models
{
    public class Account
    {
        public string Id { get; set; }
        public double SumMoney { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public bool AuthorizationFlag = false;

        public Account(string id)
        {
            Id = id;
        }

        public Account(string id, double sumMoney) : this(id)
        {
            SumMoney = sumMoney;
        }

        public void AddMoney(double money)
        {
            SumMoney += money;
        }

        public double RemoveMoney(double money) //проверка
        {
            if (SumMoney >= money)
            {
                SumMoney -= money; //*
                return money;
            }
            else
            {
                money = SumMoney; //будем возвращать все что осталось на счету
                SumMoney = 0;
                return money;
            }
        }
        public bool AuthorizationCheck(string login, string password)
        {
            if (Login == login && Password == password)
            {
                Console.WriteLine("Авторизация прошла успешно");
                return true;
            }
            else
            {
                Console.WriteLine("Авторизация не прошла!");
                return false;
            }
        }

        public override string ToString()
        {
            return $"Id:{Id} Login:{Login} Password:{Password}";
        }
    }
}
