using Fitness.Core.Controllers;
using Fitness.Core.Entities;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness.UI.Console.Languages.Messages", typeof(Program).Assembly);

            System.Console.WriteLine(resourceManager.GetString("Hello", culture));

            System.Console.Write(resourceManager.GetString("EnterName", culture));
            var name = System.Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                System.Console.Write("Введите пол: ");
                var gender = System.Console.ReadLine();

                DateTime birthdate = ParseDateTime();

                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthdate, weight, height);
            }

            System.Console.WriteLine(userController.CurrentUser);

            System.Console.WriteLine("Что вы хотите сделать?");
            System.Console.WriteLine("E - ввести прием пищи");

            var key = System.Console.ReadKey();

            if (key.Key == ConsoleKey.E) 
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                    System.Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            System.Console.Write("Введите имя продукта: ");
            var foodName = System.Console.ReadLine();

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
                System.Console.Write("Введите дату рождения (dd.MM.yyyy): ");

                if (DateTime.TryParse(System.Console.ReadLine(), out DateTime birthdate))
                    return birthdate;

                System.Console.WriteLine("Неверный формат даты рождения.");
            }
        }

        private static double ParseDouble(string paramName) 
        {
            while (true) 
            {
                System.Console.Write($"Введите {paramName}: ");

                if (double.TryParse(System.Console.ReadLine(), out double value))
                    return value;

                System.Console.WriteLine($"Неверный формат параметра {paramName}");
            }
        }
    }
}
