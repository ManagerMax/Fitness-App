﻿using System;

namespace Fitness.BL.Logic
{
    /// <summary>
    /// Пол
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name"> имя пола </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)//вызываем конструктор
        {
            if (string.IsNullOrWhiteSpace(name))//проверяем введенное значение на пустоту или отступы типо tab или space
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
               //Для читаемости указывает характе нашего Exception            
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}