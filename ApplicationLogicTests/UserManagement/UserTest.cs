using System;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    /// This class test the user in application logic.
    /// </summary>
    [TestClass]
    public class UserTest
    {
        /// <summary>
        /// Creates a valid user.
        /// </summary>
        [TestMethod]
        public void CreateUser_NewUser_Valid_Test()
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
