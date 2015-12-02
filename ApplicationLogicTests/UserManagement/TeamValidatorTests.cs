using System;
using ApplicationLogics.Repository;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Entities;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class TeamValidatorTests
    {
        [TestMethod]
        public void ValidDataInTeamTest()
        {
            //Arrange
            var validTeam = new Team() {Id = 0, Name="Name",Metadata = "Data", UserIDs = new [] {0,1}};
            
            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvalidDataInTeamTest_invalidID()
        {
            //Arrange
            var validTeam = new Team() { Id = -1, Name = "Name", Metadata = "Data", UserIDs = new[] { 0, 1 }};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidDataInTeamTest_EmptyString()
        {
            //Arrange
            var validTeam = new Team() { Id = 0, Name = "", Metadata = "", UserIDs = new[] { 0, 1 }};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidDataInTeamTest_WhiteSpace()
        {
            //Arrange
            var validTeam = new Team() { Id = 0, Name = " ", Metadata = " ",  UserIDs = new[] { 0, 1 } };

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidDataInTeamTest_NoUserIDs()
        {
            //Arrange
            var validTeam = new Team() { Id = 0, Name = " ", Metadata = " ", UserIDs = new int[10]};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }


        public void CheckExistingTeam()
        {
            //Arrange
            var id = 0;
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam() { Id = 0, Name = "name", Metadata = "metaData", UserIDs = new[] { 1, 2, 3 } };
            repositoryMock.Setup(r => r.Read(id)).Returns(storedTeam);

            var teamFacade = new TeamFasade(repositoryMock.Object);

            //Act
            var result = TeamValidator.ValidateExistence(0,teamFacade);

            //Assert
            Assert.IsTrue(result);
        }

        public void CheckNonExistingTeam()
        {
            //Arrange
            var id = 0;
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam() { Id = 0, Name = "name", Metadata = "metaData", UserIDs = new[] { 1, 2, 3 } };
            repositoryMock.Setup(r => r.Read(id));

            var teamFacade = new TeamFasade(repositoryMock.Object);

            //Act
            var result = TeamValidator.ValidateExistence(0, teamFacade);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
