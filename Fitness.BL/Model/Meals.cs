using Fitness.BL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Приемы пищи
    /// </summary>
    public class Meals
    {
        #region Свойства
        /// <summary>
        /// Когда поел
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список употребленных продуктов
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        
        /// <summary>
        /// Кто из пользователей поел
        /// </summary>
        public User User { get; }
        #endregion

        public Meals(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(User));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        //Обертка для удобства
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
