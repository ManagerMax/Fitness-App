using System;
namespace Fitness.BL.Logic
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        #region свойства 
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }
        //не добавляем set, потому что пользователь вводит имя единожды и не может менять
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// рост
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        /* вот более корректная реализация расчета возраста по дате рождения и текущему году
         * DateTime nowDate = DateTime.Today;
         * int Age = nowDate.Year - birthDate.Year;
         * if (birthDate > nowDate.AddYears(-Age)) Age--;*/ //Тут мы проверяем, наступил ли в текущем году день рождения
                                                           //Если нет, то отнимаем один год

        #endregion
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="gender"> Пол </param>
        /// <param name="birthDate"> Дата рождения </param>
        /// <param name="weight"> Вес </param>
        /// <param name="height"> Рост </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region проверка исключений
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше 0 или 0", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
