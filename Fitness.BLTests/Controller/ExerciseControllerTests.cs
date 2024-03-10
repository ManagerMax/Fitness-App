using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var start = DateTime.Now.AddHours(0);
            var finish = DateTime.Now.AddHours(1);
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.currentUser);
            var activity = new Activity(activityName, rnd.Next(10, 30));
            //var exercise = new Exercise(start, finish, activityName, user);

            //Action
            exerciseController.Add(activity, start, finish);

            //Assert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);       
        }
    }
}