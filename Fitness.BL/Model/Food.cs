using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        #region Свойства
        public int Id { get; set; }
        /// <summary>
        /// Наименование еды
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }    

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Калории на 100 грамм 
        /// </summary>
        public double Calories { get; set; }

        private double CaloriesPerGramm { get { return Calories / 100.0; } }
        private double FatsPerGramm { get { return Fats / 100.0; } }
        private double CarbohydratesPerGramm { get { return Carbohydrates / 100.0; } }
        #endregion

        public Food() { }

        public Food (string name) : this(name, 0, 0, 0, 0) { } 
        //Обращается к основному конструктору, в котором указано максимальное кол-во параметров и реализованы проверки                             
        
        public Food(string name, double proteins, double calories, double fats, double carbohydrates)
        {
            //TODO: ПРОВЕРКА
            Name = name;
            Proteins = proteins / 100.0;
            Calories = calories / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
