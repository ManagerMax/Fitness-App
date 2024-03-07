﻿using Fitness.BL.Logic;
using System;
using System.IO;
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
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user"> Имя пользователя </param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController (string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            //TODO: Реализовать проверку

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);        
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)//Реализация пока только на одного пользователя
                {
                    User = user;
                }
                //TODO: Что делать если пользователя не прочитали?
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
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns> Пользователь приложения </returns>
        /// <exception cref="FileLoadException"></exception>        
    }
}