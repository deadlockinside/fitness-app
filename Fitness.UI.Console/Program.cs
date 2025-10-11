using Fitness.Core.Controllers;
using System;

namespace Fitness.UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();

                DateTime birthdate = ParseDateTime();

                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthdate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
        }

        private static DateTime ParseDateTime()
        {
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthdate))
                    return birthdate;

                Console.WriteLine("Неверный формат даты рождения.");
            }
        }

        private static double ParseDouble(string paramName) 
        {
            while (true) 
            {
                Console.Write($"Введите {paramName}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;

                Console.WriteLine($"Неверный формат параметра {paramName}");
            }
        }
    }
}
