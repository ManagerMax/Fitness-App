using Fitness.BL.Logic;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    //Для пользователя заводим прием пищи и добавляем в него различные продукты, после чего сохраняем в файл    
    public class MealsController : ControllerBase
    {
        private const string Foods_File = "foods.dat";
        private const string Meals_File = "meals.dat";

        private readonly User user;

        public List<Food> Foods { get; }

        public Meals Meals { get; }
        public MealsController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Foods = GetFoodList();
            Meals = GetMeal();
        }

        //Если продукта нет, то добавляем его 
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Meals.Add(food, weight);
                Save();
            }
            else
            {
                Meals.Add(product, weight);
                Save();     
            }
        }

        private Meals GetMeal()
        {
            return Load<Meals>(Meals_File) ?? new Meals(user);
        }

        private List<Food> GetFoodList() 
        {
            return Load<List<Food>>(Foods_File) ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods_File, Foods);
            Save(Meals_File, Meals);    
        }
    }
}
