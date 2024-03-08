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

            var userController = new UserController(name);
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
            Console.ReadLine();
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
                    Console.WriteLine($"Некорректный ввод {name}а");
                } 
            }
        }
    }
}
