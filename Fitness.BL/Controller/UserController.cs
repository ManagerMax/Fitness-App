using CodeBlogFitness.BL.Controller;
using Fitness.BL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь приложения
        /// </summary>
        public User currentUser { get; }

        public bool IsNewUser { get; } = false;
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
            return Load<User>() ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            Save(Users);
        }       
    }
}