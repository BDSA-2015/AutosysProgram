// UserHandlerTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement.Entities;
using ApplicationLogicTests.UserManagement.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    /// Test for the userHandler class
    /// </summary>
    [TestClass]
    public class UserFacadeTests
    {
        private Mock<IRepository<StoredUser>> _repositoryMock;
        private StoredUser _storedUser;
        private User _user;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _repositoryMock = new Mock<IRepository<StoredUser>>();
            _storedUser = new StoredUser {Id = 0, Name = "name", MetaData = "metaData"};
            _user = new User {Id = 0, Name = "name", MetaData = "metaData"};
        }

        /// <summary>
        /// Test when a user can be created
        /// </summary>
        [TestMethod]
        public void CreateUser_Success_Test()
        {
            //Arrange 
            const int expectedReturnId = 0;
            _repositoryMock.Setup(r => r.CreateOrUpdate(_storedUser)).Returns(expectedReturnId);
            var userFacade = new UserFacade(_repositoryMock.Object);

            //Act
            var actualId = userFacade.Create(_user);


            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }

        /// <summary>
        /// Test if read does not return null when given a valid user id
        /// </summary>
        [TestMethod]
        public void GetUser_Valid_NotNull_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(_storedUser);
            var userFacade = new UserFacade(_repositoryMock.Object);

            //Act
            var returnedUser = userFacade.Read(idToRead);

            //Assert
            Assert.IsNotNull(returnedUser);
        }

        /// <summary>
        /// Test if read returns a user object when given a valid user id
        /// </summary>
        [TestMethod]
        public void GetUser_Valid_IsUser_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(_storedUser);
            var userFacade = new UserFacade(_repositoryMock.Object);

            //Act
            var returnedUser = userFacade.Read(idToRead);

            //Assert
            Assert.IsInstanceOfType(returnedUser, typeof (User));
        }


        /// <summary>
        /// Test if read returns a user object with correct information
        /// </summary>
        [TestMethod]
        public void GetUser_Valid_CorrectUserInfo_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(_storedUser);
            var userFacade = new UserFacade(_repositoryMock.Object);

            //Act
            var returnedUser = userFacade.Read(idToRead);

            //Assert
            Assert.IsTrue(_user.Name == returnedUser.Name);
            Assert.IsTrue(_user.MetaData == returnedUser.MetaData);
            Assert.IsTrue(_user.Id == returnedUser.Id);
        }

        /// <summary>
        /// Test that returned user is null if user does not exist.
        /// </summary>
        [TestMethod]
        public void GetUser_Invalid_NoExistingUser_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead));
            var userFacade = new UserFacade(_repositoryMock.Object);

            //Act
            var returnedUser = userFacade.Read(idToRead);

            //Assert
            Assert.IsNull(returnedUser);
        }

        /// <summary>
        /// Test if read with parameters returns correct numbers of users
        /// </summary>
        [TestMethod]
        public void GetAllUsers_Valid_ReturnsCorrectNumberOfUsers_Test()
        {
            //Arrange
            var user1 = new StoredUser {Name = "name1", MetaData = "metaData1"};
            var user2 = new StoredUser {Name = "name2", MetaData = "metaData2"};
            var user3 = new StoredUser {Name = "name3", MetaData = "metaData3"};
            IEnumerable<StoredUser> list = new List<StoredUser> {user1, user2, user3};
            _repositoryMock.Setup(r => r.Read()).Returns(list);
            var userFacade = new UserFacade(_repositoryMock.Object);
            var expectedCount = 3;

            //Act
            var actualCount = userFacade.Read().Count();

            //Assert
            Assert.IsTrue(expectedCount == actualCount);
        }

        /// <summary>
        /// Test if read with parameters returns users with correct information
        /// </summary>
        [TestMethod]
        public void GetAllUsers_Valid_ReturnsCorrectUsers_Test()
        {
            //Arrange
            var user1 = new StoredUser {Name = "name1", MetaData = "metaData1"};
            var user2 = new StoredUser {Name = "name2", MetaData = "metaData2"};
            var user3 = new StoredUser {Name = "name3", MetaData = "metaData3"};
            IEnumerable<StoredUser> list = new List<StoredUser> {user1, user2, user3};
            _repositoryMock.Setup(r => r.Read()).Returns(list);
            var userFacade = new UserFacade(_repositoryMock.Object);

            //Act
            var actualUsers = userFacade.Read().ToArray();

            //Assert
            var counter = 0;
            foreach (var actualUser in list)
            {
                var returnedUser = actualUsers[counter];
                Assert.IsTrue(returnedUser.Name == actualUser.Name);
                Assert.IsTrue(returnedUser.MetaData == actualUser.MetaData);
                Assert.IsTrue(returnedUser.Id == actualUser.Id);
                counter++;
            }
        }


        /// <summary>
        /// Test if a user can be deleted.
        /// </summary>
        [TestMethod]
        public void DeleteUser_Success_Test()
        {
            //Arrange
            var toDeleteId = 0;
            var user = new User {Id = toDeleteId, Name = "name", MetaData = "metaData"};
            var userFacade = new UserFacade(new RepositoryStub<StoredUser>());

            //Act
            userFacade.Create(user);
            Assert.IsNotNull(userFacade.Read(toDeleteId));
            userFacade.Delete(user);

            //Assert
            Assert.IsNull(userFacade.Read(toDeleteId));
        }


        /// <summary>
        /// Test when trying to delete a non-existing user.
        /// Exception must be thrown to pass test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void DeleteUser_Fail_UserDoesNotExist_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredUser>>();
            var toDeleteId = 0;
            repositoryMock.Setup(r => r.Read(toDeleteId));
            var userFacade = new UserFacade(repositoryMock.Object);
            var user = new User {Id = toDeleteId, Name = "name", MetaData = "metaData"};


            //Act
            userFacade.Delete(user);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// Test deleting a user that has been updated
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DeleteUser_Fail_UserToDeleteHasBeenUpdated_Test()
        {
            //Arrange
            var storedUser = new StoredUser {Id = 0, Name = "name"};
            var user = new User {Id = 0, Name = "Changed name", MetaData = "Changed metaData"};

            var repositoryMock = new Mock<IRepository<StoredUser>>();
            repositoryMock.Setup(r => r.Read(user.Id)).Returns(storedUser);

            var userFacade = new UserFacade(repositoryMock.Object);

            //Act
            userFacade.Delete(user);

            //Assert
                //Exception must be thrown
        }
    }
}