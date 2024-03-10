using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessConsole.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var managerResources = new ResourceManager("FitnessConsole.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(managerResources.GetString("Hello", culture));

            Console.WriteLine(managerResources.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var mealsController = new MealsController(userController.currentUser);
            var exerciseController = new ExerciseController(userController.currentUser);
            //userController.Save();//нам не нужен ручной save отдельным методом, потому что если пользователь ввел nameUser
            //и его нет в списке пользователей, мы создаем, устанавливаем имя и добавляем его в список
            if (userController.IsNewUser)
            {
                Console.WriteLine(managerResources.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.currentUser);

            while (true)
            {
                Console.WriteLine("Вам необходимо: ");
                Console.WriteLine("Нажмите 'E' - чтобы записать прием пищи");
                Console.WriteLine("Нажмите 'A' - чтобы ввести упражнение");
                Console.WriteLine("Нажмите 'Q' - чтобы выйти");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterMeal();
                        mealsController.Add(foods.Food, foods.Weight);

                        foreach (var item in mealsController.Meals.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exc = EnterExcercice();
                        exerciseController.Add(exc.Activity, exc.Begin, exc.Finish);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                    break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime Finish, Activity Activity) EnterExcercice()
        {
            Console.WriteLine("Введите название упражнения:");
            var name = Console.ReadLine();
            var energy = ParseDouble("Расход энергии в мунуту");

            var begin = ParseDateTime("Начало упражнения");
            var finish = ParseDateTime("Время окончания");

            var activity = new Activity(name, energy);
            return (begin, finish, activity);
        }

        private static (Food Food, double Weight) EnterMeal()
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("Калорийность");
            var proteins = ParseDouble("Белки");
            var fats = ParseDouble("Жиры");
            var carbohydrates = ParseDouble("Углеводы");
                

            var weight = ParseDouble("Вес порции");

            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Некорректный ввод в поле: {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Некорректный ввод в поле: {name}");
                } 
            }
        }
    }
}
