using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace FitnessConsole.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток! Это FitnessApp");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var mealsController = new MealsController(userController.currentUser);
            //userController.Save();//нам не нужен ручной save отдельным методом, потому что если пользователь ввел nameUser
            //и его нет в списке пользователей, мы создаем, устанавливаем имя и добавляем его в список
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.currentUser);

            Console.WriteLine("Вам необходимо: ");
            Console.WriteLine("Нажмите 'E' - чтобы записать прием пищи");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterMeal();
                mealsController.Add(foods.Food, foods.Weight);

                foreach(var item in mealsController.Meals.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
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

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
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
