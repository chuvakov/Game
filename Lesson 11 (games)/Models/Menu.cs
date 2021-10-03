using Lesson_11__games_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11__games_.Models
{
    public static class Menu
    {

        public static void SetConsoleTextColorComand() //метод для изменения цвета заголовков
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; //изменить цвет текста в консоли
        }

        public static void PrintTitle(string title)
        {
            Console.Clear();
            SetConsoleTextColorComand();

            Console.WriteLine(title + "\n");
            Console.ResetColor(); // сброс цвета на стандартный
        }

        public static void PrintEror(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + text); // то же самое что ($"\n{text}");
            Console.ResetColor();
        }

        public static void PrintSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n" + text);
            Console.ResetColor();
        }

        public static void PrintBaseMenu()
        {
            string menu =
                "1. Создать игрока\n" +
                "2. Удалить игрока\n" +
                "3. Выбрать игрока\n" +
                "4. Создать игру\n" +
                "5. Удалить игру\n" +
                "6. Просмотреть список игр\n" +
                "7. Выйти из программы\n";

            Console.WriteLine(menu);
        }

        public static void PrintPlayerMenu()
        {
            string menu =
                "1. Добавить игру\n" +
                "2. Создать аккаунт\n" +
                "3. Напечатать информацию о игроке\n" +
                "4. Выйти из игрока\n";               

            Console.WriteLine(menu);
        }

        public static BaseCommand? GetBaseCommand()  //после примитивного типа данных ?знак позволяет ему хранить значение NULL
                                                     //(изначально ENUM не соддержит NULL, изначально NULL содержат только ссылочные типы данных как Классы)
        {
            BaseCommand? result;

            Console.WriteLine("Введите пунк меню");   
            if (int.TryParse(Console.ReadLine(), out int inputCommand))  //мы тут же объявили переменную (так можно делать только с входными параметрами, которые помечены ключевым словом out)
            {  
                if (Enum.IsDefined(typeof(BaseCommand), inputCommand)) //typeof, тоже самое что и Gettype, т.е. получаем тип сущности (того что передали)
                { // IsDefind возвращает true если переданное значение содержиться в переданом ENUM
                    result = (BaseCommand)inputCommand;  //явное приведение типов (приказывать нужно когда уверен что тип соответствует)
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
    }
}
