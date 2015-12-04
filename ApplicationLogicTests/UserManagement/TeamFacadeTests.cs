// TeamHandlerTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    /// Test for the TeamHandler Class
    /// </summary>
    [TestClass]
    public class TeamFacadeTests
    {

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
        }

        [TestMethod]
        public void CreateTeam_Success_Test()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam {Name = "name", Metadata = "metaData", UserIDs = new[] {1, 2, 3}};
            const int expectedReturnId = 0;
            repositoryMock.Setup(r => r.Create(storedTeam)).Returns(expectedReturnId);
            var teamFacade = new TeamFacade(repositoryMock.Object);

            var team = new Team {Name = "name", Metadata = "metaData", UserIDs = new[] {1, 2, 3}};


            //Act
            
            var actualId = teamFacade.Create(team);


            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }

        [TestMethod]
        public void DeleteTeam_Success_Test()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam {Id = 0, Name = "name", Metadata = "metaData", UserIDs = new[] { 1, 2, 3 } };
            repositoryMock.Setup(r => r.Read(storedTeam.Id)).Returns(storedTeam);
            repositoryMock.Setup(r => r.Delete(storedTeam));

            var teamFacade = new TeamFacade(repositoryMock.Object);

            var team = new Team { Name = "name", Metadata = "metaData", UserIDs = new[] { 1, 2, 3 } };


            //Act
            teamFacade.Delete(team);


            //Assert
            //Todo How mock if an item has been deleted?
        }

        /// <summary>
        /// Test when trying to delete a non-existing team.
        /// Exception must be thrown to pass test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteTeam_Fail_TeamDoesNotExist_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var toDeleteId = 0;
            repositoryMock.Setup(r => r.Read(toDeleteId));
            var teamFacade = new TeamFacade(repositoryMock.Object);
            var team = new Team { Id= toDeleteId, Name = "name", Metadata = "metaData", UserIDs = new[] { 1, 2, 3 } };


            //Act
            teamFacade.Delete(team);

            //Assert
                //Exception must be thrown

        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DeleteTeam_Fail_TeamToDeleteHasBeenUpdated_Test()
        {
            //Arrange
            var storedTeam = new StoredTeam() { Id = 0, Name = "name", Metadata = "metaData", UserIDs = new[] { 1, 2, 3 } };
            var team = new Team() { Id = 0, Name = "Changed name", Metadata = "Changed metaData", UserIDs = new[] { 1, 2 } }; 

            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            repositoryMock.Setup(r => r.Read(team.Id)).Returns(storedTeam);
            
            var teamFacade = new TeamFacade(repositoryMock.Object);

            //Act
            teamFacade.Delete(team);

            //Assert
                //Exception must be thrown
        }

    }
}