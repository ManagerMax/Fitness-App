﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 170;
            var gender = "man";
            var controller = new UserController(userName);
            
            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.currentUser.Name);
            Assert.AreEqual(birthDate, controller2.currentUser.BirthDate);
            Assert.AreEqual(weight, controller2.currentUser.Weight);
            Assert.AreEqual(height, controller2.currentUser.Height);
            Assert.AreEqual(gender, controller2.currentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.currentUser.Name);
        }
    }
}