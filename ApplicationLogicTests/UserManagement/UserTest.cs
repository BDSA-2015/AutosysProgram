using System;
using ApplicationLogics.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            //Arrange
            const string expectedName = "Name";
            const string expectedMeta = "metaData";

            //Act
            var user = new User() {Name= expectedName, Metadata = expectedMeta};

            //Assert
            Assert.AreEqual(expectedName,user.Name,expectedMeta,user.Metadata);
            
        }
    }
}
