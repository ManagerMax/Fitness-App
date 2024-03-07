using Fitness.BL.Controller;
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

            Console.WriteLine("Введите пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: TryParse

            Console.WriteLine("Введите вес:");
            var weight = double.Parse(Console.ReadLine()); //TODO: TryParse

            Console.WriteLine("Введите рост:");
            var height = double.Parse(Console.ReadLine()); //TODO: TryParse

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
            /*if (name.Length <= 1) 
            {

            }*/
        }
    }
}
