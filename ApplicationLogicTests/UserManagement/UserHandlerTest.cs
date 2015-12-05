using System;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class UserHandlerTest
    {
        private Mock<IFacade<User>> _facadeMock;
        private User _user;
            
        [TestInitialize]
        public void Initialize()
        {
            _facadeMock = new Mock<IFacade<User>>();
            _user = new User() {Id=0, MetaData = "Meta", Name = "name"};
        }

        /// <summary>
        /// Test of valid user creation
        /// </summary>
        [TestMethod]
        public void CreateUser_Valid_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Create(_user)).Returns(_user.Id);
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.CreateUser(_user);

            //Assert
            Assert.IsTrue(result == _user.Id);
        }

        /// <summary>
        /// Whitespaces in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userInformationWhiteSpace()
        {
            //Arrange
            var user = new User {Name = " ", MetaData = " "};
            _facadeMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.CreateUser(_user);

            //Assert
                //Exception must be thrown
        }

        /// <summary>
        /// Empty strings in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userInformationEmptyString()
        {
            //Arrange
            var user = new User { Name = "", MetaData = "" };
            _facadeMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.CreateUser(_user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// Null in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userInformationNull()
        {
            //Arrange
            var user = new User { Name = null, MetaData = null};
            _facadeMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.CreateUser(_user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// user parameter null is not allowed.
        /// Exception must be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userIsNull()
        {
            //Arrange
            _facadeMock.Setup(r => r.Create(null));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.CreateUser(null);

            //Assert
            //Exception must be thrown
        }


    }
}
