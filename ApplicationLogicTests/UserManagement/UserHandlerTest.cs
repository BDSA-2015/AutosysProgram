using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class UserHandlerTest
    {
        private Mock<IAdapter<User, StoredUser>> _adapterMock;
        private User _user;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _adapterMock = new Mock<IAdapter<User, StoredUser>>();
            _user = new User {Id = 0, MetaData = "Meta", Name = "name"};
        }

        /// <summary>
        ///     Test of valid user creation
        /// </summary>
        [TestMethod]
        public async void CreateUser_Valid_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Create(_user)).Returns(Task.FromResult(_user.Id));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var returnedId = await userHandler.Create(_user);

            //Assert
            Assert.IsTrue(returnedId == _user.Id);
        }

        /// <summary>
        ///     Whitespaces in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateUser_Invalid_userInformationWhiteSpace_Test()
        {
            //Arrange
            var user = new User {Name = " ", MetaData = " "};
            _adapterMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var result = await userHandler.Create(user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Empty strings in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateUser_Invalid_userInformationEmptyString_Test()
        {
            //Arrange
            var user = new User {Name = "", MetaData = ""};
            _adapterMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var result = await userHandler.Create(user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Null in users are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateUser_Invalid_userInformationNull_Test()
        {
            //Arrange
            var user = new User {Name = null, MetaData = null};
            _adapterMock.Setup(r => r.Create(user));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var result = await userHandler.Create(user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     user parameter null is not allowed.
        ///     Exception must be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateUser_Invalid_userIsNull_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Create(null));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var result = await userHandler.Create(null);

            //Assert
            //Exception must be thrown
        }


        /// <summary>
        ///     Test if an existing user is being deleted
        /// </summary>
        [TestMethod]
        public async void DeleteUser_Valid_Test()
        {
            //Arrange
            const int idToDelete = 0;
            _adapterMock.Setup(a => a.DeleteIfExists(idToDelete)).Returns(Task.FromResult(true));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var result = await userHandler.Delete(idToDelete);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     Test if non existing user is being deleted
        ///     Exception must be thrown here.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public async void DeleteUser_Invalid_NoExistingUser_Test()
        {
            //Arrange
            _adapterMock.Setup(a => a.DeleteIfExists(_user.Id)).Throws(new NullReferenceException());
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var result = await userHandler.Delete(_user.Id);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Test deletion with invalid id
        ///     Exception must be thrown here.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void DeleteUser_Invalid_InvalidId_Test()
        {
            //Arrange
            var userHandler = new UserHandler(_adapterMock.Object);
            var invalidId = -1;

            //Act
            var result = await userHandler.Delete(invalidId);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Test if existing user is not null when retrieved
        /// </summary>
        [TestMethod]
        public void ReadUser_Valid_IsNotNull_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Read(_user.Id)).Returns(Task.FromResult(_user));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var user = userHandler.Read(_user.Id);

            //Assert
            Assert.IsNotNull(user);
        }

        /// <summary>
        ///     Test if existing user is an instance of user when retrieved
        /// </summary>
        [TestMethod]
        public async void ReadUser_Valid_TypeOfUser_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Read(_user.Id)).Returns(Task.FromResult(_user));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var user = await userHandler.Read(_user.Id);

            //Assert
            Assert.IsInstanceOfType(user, typeof (User));
        }


        /// <summary>
        ///     Test if existing user containts correct information
        /// </summary>
        [TestMethod]
        public async void ReadUser_Valid_CorrectInformation_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Read(_user.Id)).Returns(Task.FromResult(_user));
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var actualUser = await userHandler.Read(_user.Id);

            //Assert
            Assert.IsTrue(actualUser.Id == _user.Id);
            Assert.IsTrue(actualUser.Name == _user.Name);
            Assert.IsTrue(actualUser.MetaData == _user.MetaData);
        }

        /// <summary>
        ///     Test if get all User returns the correct number of users.
        /// </summary>
        [TestMethod]
        public void ReadAllTeams_Valid_CorrectNumberOfTeams_Test()
        {
            //Arrange
            var team1 = new User {Id = 0, Name = "User1", MetaData = "Meta1"};
            var team2 = new User {Id = 1, Name = "User2", MetaData = "Meta2"};
            var users = new List<User> {team1, team2};
            _adapterMock.Setup(r => r.Read()).Returns(users.AsQueryable());
            var userHandler = new UserHandler(_adapterMock.Object);

            //Act
            var actualUsers = userHandler.GetAll();
            var counter = actualUsers.Count();


            //Assert
            Assert.IsTrue(counter == users.Count);
        }
    }
}