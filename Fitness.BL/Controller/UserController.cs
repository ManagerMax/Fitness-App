using Fitness.BL.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; }

        public User currentUser { get; }

        public bool IsNewUser { get; }
        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user"> Имя пользователя </param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController (string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();

            currentUser = Users.SingleOrDefault(u => u.Name ==  userName);  

            if (currentUser == null)
            {
                currentUser = new User(userName);//если на этом этапе человек зарегистрирован, то получаем его статистику
                                                //иначе создаем нового пользователя и устанавливаем его имя
                Users.Add(currentUser);//добавляем нового пользователя в список пользователей
                IsNewUser = true;//устанавливаем флаг, что это новый пользователь, потому что в таком случае надо еще
                                //запросить ввод пола и других данных
            }
        }
        /// <summary>
        /// Задать данные нового пользователя
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //TODO: ПРОВЕРКА

            currentUser.Gender = new Gender(genderName);
            currentUser.BirthDate = birthDate;
            currentUser.Weight = weight;
            currentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)//Реализация на список пользователей => небезопасна
                                                                  //нужно строить через IEnumerable, так как доступ извне можем получить    
                {
                    return users;
                }
                else
                {
                    return new List<User>();//иначе возвращаем пустой список 
                }
            }
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns> Пользователь приложения </returns>
        /// <exception cref="FileLoadException"></exception>        
    }
}