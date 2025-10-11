using Fitness.Core.Controllers;
using Fitness.Core.Entities;
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
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.E) 
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();

            var calories = ParseDouble("каллорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var foodWeight = ParseDouble("вес порции");

            var product = new Food(foodName, proteins, fats, carbs, calories);

            return (Food: product, Weight: foodWeight); // System.ValueTuple
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
