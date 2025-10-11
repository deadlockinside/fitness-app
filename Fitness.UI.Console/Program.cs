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

            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите вес: ");
            var weight = double.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();
        }
    }
}
