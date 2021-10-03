﻿using Lesson_11__games_.Enums;
using Lesson_11__games_.Models;

namespace Lesson_11__games_.Models
{
    public abstract class Human
    {
        public string Fio { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Money { get; set; }

        public Human(string fio, int age, Gender gender)
        {
            Fio = fio;
            Age = age;
            Gender = gender;
        }

        public Human(string fio, int age, Gender gender, double money) : this(fio, age, gender)
        {
            Money = money;
        }
    }
}