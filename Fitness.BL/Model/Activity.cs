using System;

namespace Fitness.BL.Model
{
    [Serializable] //так как будем сериализовать данные в файл 
    public class Activity
    {
        /// <summary>
        /// Параметр наименования упражнения
        /// </summary>
        public string Name { get; } 
        /// <summary>
        /// Параметр количества сжигаемых в минуту калорий
        /// </summary>
        public double CaloriesBurnedPerMinute { get; set; }

        /// <summary>
        /// Конструктор Acivity
        /// </summary>
        /// <param name="name"> наименование </param>
        /// <param name="caloriesBurnedPerMinute"> количество сжигаемых в минуту калорий </param>
        public Activity(string name, double caloriesBurnedPerMinute)
        {
            //TODO: ПРОВЕРКА

            Name = name;
            CaloriesBurnedPerMinute = caloriesBurnedPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
