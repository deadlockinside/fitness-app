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
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.UI.Console.Languages.Messages", typeof(Program).Assembly);

            System.Console.WriteLine(resourceManager.GetString("Hello", culture));

            System.Console.Write(resourceManager.GetString("EnterName", culture));
            var name = System.Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                System.Console.Write("Введите пол: ");
                var gender = System.Console.ReadLine();

                DateTime birthdate = ParseDateTime("дата рождения");

                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthdate, weight, height);
            }

            System.Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                System.Console.WriteLine("Что вы хотите сделать?");
                System.Console.WriteLine("E - ввести прием пищи");
                System.Console.WriteLine("A - ввести упражнение");
                System.Console.WriteLine("Q - выход");

                var key = System.Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                            System.Console.WriteLine($"\t{item.Key} - {item.Value}");
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.begin, exe.end);

                        foreach(var item in exerciseController.Exercises)
                            System.Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (DateTime begin, DateTime end, Activity activity) EnterExercise()
        {
            System.Console.WriteLine("Введите название упражнения: ");
            var name = System.Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало управжнения");
            var end = ParseDateTime("окончание управжнения");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string paramName)
        {
            while (true)
            {
                System.Console.Write($"Введите {paramName} (dd.MM.yyyy): ");

                if (DateTime.TryParse(System.Console.ReadLine(), out DateTime birthdate))
                    return birthdate;

                System.Console.WriteLine($"Неверный формат параметра {paramName}.");
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
