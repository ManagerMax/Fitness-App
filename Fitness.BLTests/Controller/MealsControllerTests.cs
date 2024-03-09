using Fitness.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class MealsControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var mealsController = new MealsController(userController.currentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            //Act
            mealsController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, mealsController.Meals.Foods.First().Key.Name);
        }
    }
}