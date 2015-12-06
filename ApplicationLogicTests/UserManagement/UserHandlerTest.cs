using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using ApplicationLogicTests.UserManagement.Stub;
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
            var result = userHandler.Create(_user);

            //Assert
            Assert.IsTrue(result == _user.Id);
        }

        /// <summary>
        /// Whitespaces in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userInformationWhiteSpace_Test()
        {
            //Arrange
            var user = new User {Name = " ", MetaData = " "};
            _facadeMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.Create(user);

            //Assert
                //Exception must be thrown
        }

        /// <summary>
        /// Empty strings in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userInformationEmptyString_Test()
        {
            //Arrange
            var user = new User { Name = "", MetaData = "" };
            _facadeMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.Create(user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// Null in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userInformationNull_Test()
        {
            //Arrange
            var user = new User { Name = null, MetaData = null};
            _facadeMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.Create(user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// user parameter null is not allowed.
        /// Exception must be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_Invalid_userIsNull_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Create(null));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var result = userHandler.Create(null);

            //Assert
            //Exception must be thrown
        }


        /// <summary>
        /// Test if an existing user is being deleted
        /// </summary>
        [TestMethod]
        public void DeleteUser_Valid_Test()
        {
            //Arrange
            var facade = new UserFacade(new RepositoryStub<StoredUser>());
            var userHandler = new UserHandler(facade);
            var user = new User() {Name = "Name1", MetaData = "data"};
            const int idToDelete = 0;

            //Act
            userHandler.Create(user);
            Assert.IsNotNull(userHandler.Read(idToDelete));
            userHandler.Delete(idToDelete);

            //Assert
            Assert.IsNull(userHandler.Read(idToDelete));
        }

        /// <summary>
        /// Test if non existing user is being deleted
        /// Exception must be thrown here.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteUser_Invalid_NoExistingUser_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Read(_user.Id));
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            userHandler.Delete(_user.Id);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// Test if existing user is not null when retrieved
        /// </summary>
        [TestMethod]
        public void ReadUser_Valid_IsNotNull_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Read(_user.Id)).Returns(_user);
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var user = userHandler.Read(_user.Id);

            //Assert
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Test if existing user is an instance of user when retrieved
        /// </summary>
        [TestMethod]
        public void ReadUser_Valid_TypeOfUser_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Read(_user.Id)).Returns(_user);
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var user = userHandler.Read(_user.Id);

            //Assert
            Assert.IsInstanceOfType(user,typeof(User));
        }


        /// <summary>
        /// Test if existing user containts correct information
        /// </summary>
        [TestMethod]
        public void ReadUser_Valid_CorrectInformation_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Read(_user.Id)).Returns(_user);
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var actualUser = userHandler.Read(_user.Id);

            //Assert
            Assert.IsTrue(actualUser.Id == _user.Id);
            Assert.IsTrue(actualUser.Name == _user.Name);
            Assert.IsTrue(actualUser.MetaData == _user.MetaData);   
        }

        /// <summary>
        /// Test if get all User returns the correct number of users.
        /// </summary>
        [TestMethod]
        public void ReadAllTeams_Valid_CorrectNumberOfTeams_Test()
        {
            //Arrange
            var team1 = new User() { Id = 0, Name = "User1", MetaData = "Meta1"};
            var team2 = new User() { Id = 1, Name = "User2", MetaData = "Meta2"};
            var users = new List<User>() { team1, team2 };
            _facadeMock.Setup(r => r.Read()).Returns(users);
            var userHandler = new UserHandler(_facadeMock.Object);

            //Act
            var actualUsers = userHandler.GetAll();
            var counter = actualUsers.Count();


            //Assert
            Assert.IsTrue(counter == users.Count);
        }


    }
}
