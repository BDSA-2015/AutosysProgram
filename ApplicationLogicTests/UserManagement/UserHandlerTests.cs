using System;
using ApplicationLogics.Repository;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.StorageFasade.Mapping;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Entities;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    /// Test for the userHandler class
    /// </summary>
    [TestClass]
    public class UserHandlerTests
    {

        [TestInitialize]
        public void Initialize()
        {
            var mapper = new BaseMapper();
        }

        [TestMethod]
        public void CreateUserTest()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredUser>>();
            var storedUser = new StoredUser(){ Name = "name", MetaData = "metaData"};
            var expectedReturnId = 0;
            repositoryMock.Setup(r => r.Create(storedUser)).Returns(expectedReturnId);
            var userFacade = new UserFasade(repositoryMock.Object);

            var user = new User() { Name = "name", Metadata = "metaData" };

            //Act
            var actualId = userFacade.Create(user);


            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredUser>>();
            var storedUser = new StoredUser() {Id = 0, Name = "name", MetaData = "metaData" };
            repositoryMock.Setup(r => r.Delete(storedUser));
            repositoryMock.Setup(r => r.Read(storedUser.Id)).Returns(storedUser);
            var userFacade = new UserFasade(repositoryMock.Object);

            //Act
            var user = new User() {Id = 0, Name = "name", Metadata = "metaData" };

            userFacade.Delete(user);


        }
    }
}
