using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.Core.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest() 
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "боевой вертолет";
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);

            // Act
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.Birthdate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}