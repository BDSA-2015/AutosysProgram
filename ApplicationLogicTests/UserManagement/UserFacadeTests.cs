// UserHandlerTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement.Entities;
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
        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
        }

        /// <summary>
        /// Test when a user can be created
        /// </summary>
        [TestMethod]
        public void CreateUser_Success_Test()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredUser>>();
            var storedUser = new StoredUser {Name = "name", MetaData = "metaData"};
            const int expectedReturnId = 0;
            repositoryMock.Setup(r => r.Create(storedUser)).Returns(expectedReturnId);
            var userFacade = new UserFacade(repositoryMock.Object);

            var user = new User {Name = "name", Metadata = "metaData"};

            //Act
            var actualId = userFacade.Create(user);


            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }

        /// <summary>
        /// Test if a user can be deleted.
        /// </summary>
        [TestMethod]
        public void DeleteUser_Success_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredUser>>();
            var storedUser = new StoredUser {Id = 0, Name = "name", MetaData = "metaData"};
            repositoryMock.Setup(r => r.Delete(storedUser));
            repositoryMock.Setup(r => r.Read(storedUser.Id)).Returns(storedUser);
            var userFacade = new UserFacade(repositoryMock.Object);

            //Act
            var user = new User {Id = 0, Name = "name", Metadata = "metaData"};

            userFacade.Delete(user);
        }
    }
}